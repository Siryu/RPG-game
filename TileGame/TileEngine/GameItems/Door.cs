using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TileEngine
{
    public class Door
    {
        public Dictionary<string, FrameAnimation> Animations =
            new Dictionary<string, FrameAnimation>();

        string currentAnimation = null;
        bool animating = false;

        public Vector2 Postition = Vector2.Zero;

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

        public virtual void Update(GameTime gameTime)
        {
            if (!IsAnimating)
                return;

            
            FrameAnimation animation = CurrentAnimation;

            if (animation == null)
            {
 // added in animations.count <4 to test if it stops animating after 4
                
                if (Animations.Count > 0 && Animations.Count < 4)
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
    }
}
