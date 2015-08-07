using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TileEngine
{
    public class NPC : AnimatedSprite
    {
        Dialog dialog;
        Script script;
        float speakingRadius = 50f;
        public AnimatedSprite Target;
        bool followingTarget = false;

        public float SpeakingRadius
        {
            get { return speakingRadius; }
            set { speakingRadius = (float)Math.Max(value, CollisionRadius); }
        }

        public NPC(Texture2D texture, Dialog dialog, Script script)
            : base(texture)
        {
            this.dialog = dialog;
            this.script = script;
        }

        public override void Update(GameTime gameTime)
        {
            if (Target != null && followingTarget)
            {
                Postition = Target.Center + new Vector2(Target.CollisionRadius + CollisionRadius, 0f);
            }
            
            base.Update(gameTime);
        }


        public bool InSpeakingRange(AnimatedSprite sprite)
        {
            Vector2 d = Origin - sprite.Origin;

            return (d.Length() < SpeakingRadius);
        }

        public void StartConversation(string conversationName)
        {
            if (script == null || dialog == null)
                return;

            dialog.Enabled = true;
            dialog.Visible = true;
            dialog.Npc = this;
            dialog.FirstFrame = true;
            dialog.Conversation = script[conversationName];
        }

        public void EndConversation()
        {
            //if (script == null || dialog == null)
            //    return;

            dialog.Enabled = false;
            dialog.Visible = false;
        }

        public void StartFollowing()
        {
            followingTarget = true;
        }

        public void StopFollowing()
        {
            followingTarget = false;
        }
    }
}
