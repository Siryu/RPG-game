using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngine
{
    public class AnimatedSprite
    {
        public Dictionary<string, FrameAnimation> Animations =
            new Dictionary<string, FrameAnimation>();

        string currentAnimation = null;
        bool animating = true;
        Texture2D texture;

        public Vector2 Postition = Vector2.Zero;

        public Vector2 OriginOffset = Vector2.Zero;

        public Vector2 Origin
        {
            get { return Postition + OriginOffset; }
        }

        public Vector2 Center
        {
            get
            {
                return Postition + new Vector2(
                    CurrentAnimation.CurrentRect.Width / 2,
                    CurrentAnimation.CurrentRect.Height / 2);
            }
        }

        public Rectangle Bounds
        {
            get
            {
                Rectangle rect = CurrentAnimation.CurrentRect;
                rect.X = (int)Postition.X;
                rect.Y = (int)Postition.Y;
                return rect;
            }
        }
        float radius = 11f;

        float speed = 4f;

        public float Speed
        {
            get { return speed; }
            set
            {
                speed = (float)Math.Max(value, .1f);
            }
        }

        public float CollisionRadius
        {
            get { return radius; }
            set { radius = (float)Math.Max(value, 1f); }
        }

        public bool IsAnimating
        {
            get { return animating; }
            set { animating = value; }
        }

        public FrameAnimation CurrentAnimation
        {
            get
            {
                if (!string.IsNullOrEmpty(currentAnimation))
                    return Animations[currentAnimation];
                else
                    return null;
            }
        }

        public string CurrentAnimationName
        {
            get { return currentAnimation; }
            set
            {
                if (Animations.ContainsKey(value))
                    currentAnimation = value;
            }
        }

        public AnimatedSprite(Texture2D texture)
        {
            this.texture = texture;
        }

        public static bool AreColliding(AnimatedSprite a, AnimatedSprite b)
        {
            Vector2 d = b.Origin - a.Origin;

            return (d.Length() < b.CollisionRadius + a.CollisionRadius);
        }

        public void ClampToArea(int width, int height)
        {
            if (Postition.X < 0)
                Postition.X = 0;
            if (Postition.Y < 0)
                Postition.Y = 0;
            if (Postition.X > width - CurrentAnimation.CurrentRect.Width - 1)
                Postition.X = width - CurrentAnimation.CurrentRect.Width - 1;
            if (Postition.Y > height - CurrentAnimation.CurrentRect.Height - 1)
                Postition.Y = height - CurrentAnimation.CurrentRect.Height - 1;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!IsAnimating)
                return;

            FrameAnimation animation = CurrentAnimation;

            if (animation == null)
            {
                if (Animations.Count > 0)
                {
                    string[] keys = new string[Animations.Count];
                    Animations.Keys.CopyTo(keys, 0);

                    currentAnimation = keys[0];

                    animation = CurrentAnimation;
                }
                else
                    return;
            }

            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            FrameAnimation animation = CurrentAnimation;

            if (animation != null)
                spriteBatch.Draw(
                    texture,
                    Postition,
                    animation.CurrentRect,
                    Color.White);
        }
    }
}
