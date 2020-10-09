using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameInterestingMovementSOC
{
    class PlayerController
    {
        private Input input;
        private Skater skater;

        public Vector2 skaterPosition;
        public Vector2 lakePosition;
        public Vector2 skaterDirection;
        public Vector2 skaterVelocity;
        public Vector2 skaterOrigin;

        public float acceleration;
        public float friction;
        public float skaterSpeed;
        public float skaterRotation;


        public PlayerController()
        {
            skater = new Skater();
            input = new Input();

            skaterOrigin = new Vector2(150, 215);
            skaterPosition = new Vector2(320, 670);
            skaterVelocity = new Vector2(0, 0);
            lakePosition = new Vector2(0, 0);
            skaterRotation = 0f;
            skaterDirection = new Vector2(1, 0);
            skaterSpeed = 250;
            friction = .23f;
        }

        public void FlipSprite(bool status)
        {
            skater.FlipTheSprite(status);
        }

        public Texture2D GetLakeTexture()
        {
            return skater.GetLakeTexture();
        }

        public Texture2D GetSkaterTexture()
        {
            return skater.GetSkaterTexture();
        }

        public SpriteEffects GetSpriteEffects()
        {
            return skater.GetSpriteEffects();
        }

        public void SetTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            skater.SetSpriteTextures(content);
        }

        public void KeyboardInput(PlayerController playercontroller, float time)
        {
            input.CheckInput(this, time);
        }
    }
}
