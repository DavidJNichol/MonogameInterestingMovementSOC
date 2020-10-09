using Microsoft.Xna.Framework.Graphics;

namespace MonogameInterestingMovementSOC
{
    class Skater : Sprite
    {
        public Skater() 
        {
            
        }

        public void FlipTheSprite(bool status)
        {
            FlipSprite(status);
        }

        public Texture2D GetLakeTexture()
        {
            return icyLake;
        }

        public Texture2D GetSkaterTexture()
        {
            return iceSkater;
        }

        public SpriteEffects GetSpriteEffects()
        {
            return spriteEffects;
        }

        public void SetTheSpriteTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            SetSpriteTextures(content);
        }
    }
}
