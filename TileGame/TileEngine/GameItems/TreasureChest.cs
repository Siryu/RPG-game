using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TileEngine
{
    public class TreasureChest
    {
        public Dictionary<string, FrameAnimation> Animations =
        new Dictionary<string, FrameAnimation>();

        string currentAnimation = null;
        bool animating = false;

        public Vector2 Postition = Vector2.Zero;
        public string ItemType;
        public string Item;
        public int Quantity;

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

        public TreasureChest()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!IsAnimating)
                return;

            FrameAnimation animation = CurrentAnimation;

            if (animation == null)
            {

// same thing as the door added the count < 4
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
