using Microsoft.Xna.Framework.Graphics;

namespace MonogameInterestingMovementSOC
{
    public abstract class Sprite
    {
        protected Texture2D iceSkater;
        protected Texture2D icyLake;
        protected SpriteEffects spriteEffects;

        public Sprite()
        {
            spriteEffects = new SpriteEffects();            
        }

        public void SetSpriteTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            icyLake = content.Load<Texture2D>("IcyLake");
            iceSkater = content.Load<Texture2D>("IceSkater");
        }

        protected void FlipSprite(bool status)
        {
            if(status == true)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            else if(status == false)
            {
                spriteEffects = SpriteEffects.None;
            }
        }
    }
}
