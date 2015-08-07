using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TileEngine;

namespace TileGame
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TileMap tileMap = new TileMap();
        Camera camera = new Camera();

        List<NPC> npcs = new List<NPC>();

        List<AnimatedSprite> renderList = new List<AnimatedSprite>();
        Comparison<AnimatedSprite> renderSort = new Comparison<AnimatedSprite>(renderSpriteCompare);

        AnimatedSprite sprite;

        Dialog dialog;

        Texture2D treasureChestTexture;
        Texture2D doorTexture;

        int originalLayerIndex = 0;

        static int renderSpriteCompare(AnimatedSprite a, AnimatedSprite b)
        {
            return a.Origin.Y.CompareTo(b.Origin.Y);
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.IsFullScreen = false;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            dialog = new Dialog(this, Content);
            Components.Add(dialog);
            dialog.Enabled = false;
            dialog.Visible = false;

            base.Initialize(); 

            FrameAnimation up = new FrameAnimation(2, 32, 32, 0, 0);
            up.FramesPerSecond = 6;
            sprite.Animations.Add("Up", up);

            FrameAnimation down = new FrameAnimation(2, 32, 32, 32 * 2, 0);
            down.FramesPerSecond = 6;
            sprite.Animations.Add("Down", down);

            FrameAnimation left = new FrameAnimation(2, 32, 32, 32 * 4, 0);
            left.FramesPerSecond = 6;
            sprite.Animations.Add("Left", left);

            FrameAnimation right = new FrameAnimation(2, 32, 32, 32 * 6, 0);
            right.FramesPerSecond = 6;
            sprite.Animations.Add("Right", right);

            Random rand = new Random();

            foreach (AnimatedSprite s in npcs)
            {
                s.OriginOffset = new Vector2(16, 30);
                s.Animations.Add("Up", new FrameAnimation(2, 32, 32, 0, 0));
                s.Animations.Add("Down", new FrameAnimation(2, 32, 32, 32*2, 0));
                s.Animations.Add("Left", new FrameAnimation(2, 32, 32, 32*4, 0));
                s.Animations.Add("Right", new FrameAnimation(2, 32, 32, 32*6, 0));
                
                
                // used once all sprites are loaded the same
                //s.Animations.Add("Up", (FrameAnimation)up.Clone());
                //s.Animations.Add("Down", (FrameAnimation)down.Clone());
                //s.Animations.Add("Left", (FrameAnimation)left.Clone());
                //s.Animations.Add("Right", (FrameAnimation)right.Clone());

                int animation = rand.Next(3);

                switch (animation)
                {
                    case 0:
                        s.CurrentAnimationName = "Up";
                        break;
                    case 1:
                        s.CurrentAnimationName = "Down";
                        break;
                    case 2:
                        s.CurrentAnimationName = "Left";
                        break;
                    case 3:
                        s.CurrentAnimationName = "Right";
                        break;
                }

                s.Postition = new Vector2(rand.Next(600), rand.Next(400));

                renderList.Add(s);
            }

            sprite.CurrentAnimationName = "Down";

            renderList.Add(sprite);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            treasureChestTexture = Texture2D.FromStream(GraphicsDevice, new System.IO.StreamReader("content/treasurechest.png").BaseStream);
            doorTexture = Texture2D.FromStream(GraphicsDevice, new System.IO.StreamReader("content/door.png").BaseStream);

            tileMap = Content.Load<TileMap>("Maps/OneHouseTest");

            sprite = new AnimatedSprite(Content.Load<Texture2D>("Sprites/npc3"));
            sprite.OriginOffset = new Vector2(16, 30);

            NPC npc = new NPC(Content.Load<Texture2D>("Sprites/npc3"), dialog, Content.Load<Script>("Scripts/NPC1"));
            npc.Target = sprite;
            npcs.Add(npc);

            

            npcs.Add(new NPC(Content.Load<Texture2D>("Sprites/amg2"), null, null));
            npcs.Add(new NPC(Content.Load<Texture2D>("Sprites/avt1"), null, null));
            npcs.Add(new NPC(Content.Load<Texture2D>("Sprites/avt2"), null, null));
            npcs.Add(new NPC(Content.Load<Texture2D>("Sprites/npc6"), null, null));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

//// temp exit key!!
            if (InputHelper.IsNewPress(Keys.Escape))
                this.Exit();           
                

            InputHelper.Update();

            if (!dialog.Enabled)
            {
                Vector2 motion = Vector2.Zero;

                if (InputHelper.IsKeyDown(Keys.Up))
                    motion.Y--;
                if (InputHelper.IsKeyDown(Keys.Down))
                    motion.Y++;
                if (InputHelper.IsKeyDown(Keys.Left))
                    motion.X--;
                if (InputHelper.IsKeyDown(Keys.Right))
                    motion.X++;

                if (motion != Vector2.Zero)
                {
                    motion.Normalize();

                    motion = CheckCollisionForMotion(motion, sprite);

                    sprite.Postition += motion * sprite.Speed;
                    UpdateSpriteAnimation(motion);
                    sprite.IsAnimating = true;

                    CheckForUnwalkableTiles(sprite);
                    if (InputHelper.IsNewPress(Keys.Space))
                    {
                        CheckForTreasureChest(sprite);
                        CheckForDoor(sprite);
                    }
                }
                else
                {
                    sprite.IsAnimating = false;
                }

                sprite.ClampToArea(tileMap.GetWidthInPixels(), tileMap.GetHeightInPixels());
            }

            sprite.Update(gameTime);

            foreach (AnimatedSprite s in npcs)
            {
                s.Update(gameTime);

                if (AnimatedSprite.AreColliding(sprite, s))
                {
                    Vector2 d = Vector2.Normalize(s.Origin - sprite.Origin);

                    sprite.Postition = s.Postition - (d * (sprite.CollisionRadius + s.CollisionRadius));
                }

                if (s is NPC)
                {
                    NPC character = s as NPC;

                    if (character.InSpeakingRange(sprite) && !dialog.Enabled && InputHelper.IsNewPress(Keys.Space))
                    {
                        character.StartConversation("Greetings");
                    }
                }
            }

            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;

            camera.LockToTarget(sprite, screenWidth, screenHeight);
            
            camera.ClampToArea(
                tileMap.GetWidthInPixels() - screenWidth,
                tileMap.GetHeightInPixels() - screenHeight);

            base.Update(gameTime);
        }

        private void CheckForUnwalkableTiles(AnimatedSprite sprite)
        {
            Point spriteCell = Engine.ConvertPositionToCell(sprite.Center);

            Point? upLeft = null, up = null, upRight = null, left = null, right = null, downLeft = null, down = null, downRight = null;

            if (spriteCell.Y > 0)
                up = new Point(spriteCell.X, spriteCell.Y - 1);
            if (spriteCell.Y < tileMap.CollisionLayer.Height - 1)
                down = new Point(spriteCell.X, spriteCell.Y + 1);
            if (spriteCell.X > 0)
                left = new Point(spriteCell.X - 1, spriteCell.Y);
            if (spriteCell.X < tileMap.CollisionLayer.Width - 1)
                right = new Point(spriteCell.X + 1, spriteCell.Y);                      
            if (spriteCell.X > 0 && spriteCell.Y > 0)
                upLeft = new Point(spriteCell.X - 1, spriteCell.Y - 1);
            if (spriteCell.X < tileMap.CollisionLayer.Width - 1 && spriteCell.Y > 0)
                upRight = new Point(spriteCell.X + 1, spriteCell.Y - 1);
            if (spriteCell.X > 0 && spriteCell.Y < tileMap.CollisionLayer.Height - 1)
                downLeft = new Point(spriteCell.X - 20, spriteCell.Y + 20);
            if (spriteCell.X < tileMap.CollisionLayer.Width - 1 &&
                spriteCell.Y < tileMap.CollisionLayer.Height - 1)
                downRight = new Point(spriteCell.X + 1, spriteCell.Y + 1);


            
            if (up != null && tileMap.CollisionLayer.GetCellIndex(up.Value) == 0)
            {
                Rectangle cellRect = Engine.CreateRectForCell(up.Value);
                Rectangle spriteRect = sprite.Bounds;

                if (cellRect.Intersects(spriteRect))
                {
                    sprite.Postition.Y = spriteCell.Y * Engine.TileHeight;
                }
            }
            if (down != null && tileMap.CollisionLayer.GetCellIndex(down.Value) == 0)
            {
                Rectangle cellRect = Engine.CreateRectForCell(down.Value);
                Rectangle spriteRect = sprite.Bounds;

                if (cellRect.Intersects(spriteRect))
                {
                    sprite.Postition.Y = down.Value.Y * Engine.TileHeight - sprite.Bounds.Height;
                }
            }
            if (left != null && tileMap.CollisionLayer.GetCellIndex(left.Value) == 0)
            {
                Rectangle cellRect = Engine.CreateRectForCell(left.Value);
                Rectangle spriteRect = sprite.Bounds;

                if (cellRect.Intersects(spriteRect))
                {
                    sprite.Postition.X = spriteCell.X * Engine.TileWidth;
                }
            } 
            if (right != null && tileMap.CollisionLayer.GetCellIndex(right.Value) == 0)
            {
                Rectangle cellRect = Engine.CreateRectForCell(right.Value);
                Rectangle spriteRect = sprite.Bounds;

                if (cellRect.Intersects(spriteRect))
                {
                    sprite.Postition.X = right.Value.X * Engine.TileWidth - sprite.Bounds.Width;
                }
            }
            if (upLeft != null && tileMap.CollisionLayer.GetCellIndex(upLeft.Value) == 0)
            {
                Rectangle cellRect = Engine.CreateRectForCell(upLeft.Value);
                Rectangle spriteRect = sprite.Bounds;

                if (cellRect.Intersects(spriteRect))
                {
                    sprite.Postition.X = spriteCell.X * Engine.TileWidth;
                    sprite.Postition.Y = spriteCell.Y * Engine.TileHeight;
                }
            }
                if (upRight != null && tileMap.CollisionLayer.GetCellIndex(upRight.Value) == 0)
            {
                Rectangle cellRect = Engine.CreateRectForCell(upRight.Value);
                Rectangle spriteRect = sprite.Bounds;

                if (cellRect.Intersects(spriteRect))
                {
                    sprite.Postition.X = right.Value.X * Engine.TileWidth - sprite.Bounds.Width;
                    sprite.Postition.Y = spriteCell.Y * Engine.TileHeight;
                }
            }
                if (downLeft != null && tileMap.CollisionLayer.GetCellIndex(downLeft.Value) == 0)
            {
                Rectangle cellRect = Engine.CreateRectForCell(downLeft.Value);
                Rectangle spriteRect = sprite.Bounds;

                if (cellRect.Intersects(spriteRect))
                {
                    sprite.Postition.X = spriteCell.X * Engine.TileWidth;
                    sprite.Postition.Y = down.Value.Y * Engine.TileHeight - sprite.Bounds.Height;
                }
            }
                if (downRight != null && tileMap.CollisionLayer.GetCellIndex(downRight.Value) == 0)
                {
                    Rectangle cellRect = Engine.CreateRectForCell(downRight.Value);
                    Rectangle spriteRect = sprite.Bounds;

                    if (cellRect.Intersects(spriteRect))
                    {
                        sprite.Postition.X = right.Value.X * Engine.TileWidth - sprite.Bounds.Width;
                        sprite.Postition.Y = down.Value.Y * Engine.TileHeight - sprite.Bounds.Height;
                    }
                }

        }

        private void CheckForTreasureChest(AnimatedSprite sprite)
        {
            Point cell = Engine.ConvertPositionToCell(sprite.Origin);
            int upOne = cell.Y -= 1;
            Vector2 check;
            check.X = cell.X;
            check.Y = upOne;
            string chest;
                   
            foreach (TileLayer layer in tileMap.Layers)
            {
                if (layer.ContainsChest(check) != null && !dialog.Enabled)
                {
                    layer.ContainsChest(check).CurrentAnimationName = "Open";

                    if (layer.ContainsChest(check).Item != null && layer.ContainsChest(check).Quantity == 1 && layer.ContainsChest(check).ItemType != "Gold")
                        chest = "You found a " + layer.ContainsChest(check).Item;
                    else if (layer.ContainsChest(check).Item != null && layer.ContainsChest(check).Quantity > 1 && layer.ContainsChest(check).ItemType != "Gold")
                        chest = "You found " + layer.ContainsChest(check).Item + " x " + layer.ContainsChest(check).Quantity;
                    else if (layer.ContainsChest(check).Item != null && layer.ContainsChest(check).ItemType == "Gold")
                        chest = "You found " + layer.ContainsChest(check).Quantity + " Gold";
                    else
                        chest = "Empty";

                    TextToScreen(chest);

                    layer.RemoveChestContents(check);
                }
            }
        }

        private bool CheckForDoor(AnimatedSprite sprite)
        {
            Point cell = Engine.ConvertPositionToCell(sprite.Origin);
            int upOne = cell.Y -= 1;
            int x = cell.X;
            int downOne = cell.Y += 1;
            Vector2 check;
            check.X = x;
            check.Y = upOne;
            

            foreach (TileLayer layer in tileMap.Layers)
            {
                if (layer.ContainsDoor(check) != null && !dialog.Enabled)
                {
                    layer.ContainsDoor(check).CurrentAnimationName = "Open";
                    int layercount = tileMap.Layers.IndexOf(layer) + 50;
                    tileMap.CollisionLayer.SetCellIndex(x, upOne, layercount);
                    tileMap.CollisionLayer.SetCellIndex(x, downOne, 50);
                }
            }
            return false;
        }

        private void UpdateSpriteAnimation(Vector2 motion)
        {
            float motionAngle = (float)Math.Atan2(motion.Y, motion.X);

            if (motionAngle >= -MathHelper.PiOver4 && motionAngle <= MathHelper.PiOver4)
                sprite.CurrentAnimationName = "Right";
            else if (motionAngle >= MathHelper.PiOver4 && motionAngle <= 3f * MathHelper.PiOver4)
                sprite.CurrentAnimationName = "Down";
            else if (motionAngle <= -MathHelper.PiOver4 && motionAngle >= -3f * MathHelper.PiOver4)
                sprite.CurrentAnimationName = "Up";
            else
                sprite.CurrentAnimationName = "Left";
        }

        private Vector2 CheckCollisionForMotion(Vector2 motion, AnimatedSprite sprite)
        {
            Point cell = Engine.ConvertPositionToCell(sprite.Origin);

            int colIndex = tileMap.CollisionLayer.GetCellIndex(cell);

            if (colIndex == 2)
                return motion * .2f;

            return motion;
        }

        private void TextToScreen(string text)
        {
            ConversationHandlerAction endConversation = new ConversationHandlerAction("EndConversation", null);
            ConversationHandler handler = new ConversationHandler("Continue", endConversation);
            Conversation textDialog = new Conversation("text", text, handler);
            
            this.dialog.Enabled = true;
            this.dialog.Visible = true;
            this.dialog.FirstFrame = true;
            this.dialog.Conversation = textDialog;
            NPC textNPC = new NPC(null, dialog, null);
            this.dialog.Npc = textNPC;
            textNPC.StartConversation("text"); 
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            int layerIndex = tileMap.CollisionLayer.ShowLayer(sprite, originalLayerIndex);
            originalLayerIndex = layerIndex;
            tileMap.Draw(spriteBatch, camera, layerIndex, treasureChestTexture, doorTexture);

            spriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                null, null, null, null,
                camera.TransformMatrix);

            renderList.Sort(renderSort);

            foreach (AnimatedSprite s in renderList)
                s.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }          
    }
}
