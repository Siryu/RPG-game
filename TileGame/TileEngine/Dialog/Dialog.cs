using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TileEngine
{
    public class Dialog : DrawableGameComponent
    {
        public Conversation Conversation = null;
        public NPC Npc = null;

        public bool FirstFrame = true;

        public Rectangle Area = new Rectangle(0, 0, 300, 200);

        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Texture2D background;
        ContentManager content;

        int currentHandler = 0;
        KeyboardState lastState;

        public Dialog(Game game, ContentManager content)
            : base(game)
        {
            this.content = content;
        }

        public override void Initialize()
        {
            lastState = Keyboard.GetState();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = content.Load<SpriteFont>("Fonts/Arial");

            background = new Texture2D(GraphicsDevice, 1, 1, true, SurfaceFormat.Color);

            background.SetData<Color>(new Color[] { Color.White });
        }

        public override void Update(GameTime gameTime)
        {
            if (Conversation != null && Npc != null)
            {
                if (!FirstFrame)
                {
                    if (InputHelper.IsNewPress(Keys.Up))
                    {
                        currentHandler--;
                        if (currentHandler < 0)
                            currentHandler = Conversation.Handlers.Count - 1;
                    }

                    if (InputHelper.IsNewPress(Keys.Down))
                    {
                        currentHandler = (currentHandler + 1) % Conversation.Handlers.Count;
                    }

                    if (InputHelper.IsNewPress(Keys.Space))
                    {
                        Conversation.Handlers[currentHandler].Invoke(Npc);
                        currentHandler = 0;
                    }
                }
                
                else
                    FirstFrame = false;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Rectangle dest = new Rectangle(
                GraphicsDevice.Viewport.Width / 2 - Area.Width / 2,
                GraphicsDevice.Viewport.Height / 2 - Area.Height / 2,
                Area.Width,
                Area.Height);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(background, dest, new Color(0, 0, 0, 100));
            spriteBatch.End();

            if (Conversation == null)
                return;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            string fullText = WrapText(Conversation.Text);

            spriteBatch.DrawString(
                spriteFont,
                fullText,
                new Vector2(dest.X, dest.Y),
                Color.White);

            int lineHeight = (int)spriteFont.MeasureString(" ").Y;
            int startingHeight = (int)spriteFont.MeasureString(fullText).Y + lineHeight;

            for (int i = 0; i < Conversation.Handlers.Count; i++)
            {
                string caption = Conversation.Handlers[i].Caption;

                Color color = (i == currentHandler) ? Color.Yellow : Color.White;

                spriteBatch.DrawString(
                    spriteFont,
                    caption,
                    new Vector2(dest.X, dest.Y + startingHeight + (i * lineHeight)),
                    color);
            }

            spriteBatch.End();
        }

        private string WrapText(string text)
        {
            string[] words = text.Split(' ');

            StringBuilder sb = new StringBuilder();

            float lineWidth = 0f;

            float spaceWidth = spriteFont.MeasureString(" ").X;

            foreach (string word in words)
            {
                Vector2 size = spriteFont.MeasureString(word);

                if (lineWidth + size.X < Area.Width)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }

            return sb.ToString();
        }

    }
}
