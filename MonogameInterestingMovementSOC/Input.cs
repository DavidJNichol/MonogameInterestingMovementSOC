using Microsoft.Xna.Framework.Input;

namespace MonogameInterestingMovementSOC
{
    class Input
    {
        public void CheckInput(PlayerController pC, float time)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                pC.skaterVelocity.X = 0;
                //Reset accel
                pC.acceleration = .01f;
                pC.FlipSprite(false);
                //Deincrement accel
                pC.acceleration += .5f;
                //Calculate velocity and move
                pC.skaterVelocity.X += pC.acceleration - pC.friction * pC.skaterVelocity.X * (time / 1000);
                pC.skaterPosition += (pC.skaterDirection * pC.skaterSpeed) * (time / 1000);
            }
            //Left
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                pC.skaterVelocity.X = 0;
                //Reset accel
                pC.acceleration = -.01f;
                pC.FlipSprite(true);
                //Deincrement accel
                pC.acceleration -= .5f;
                //Calculate velocity and move
                pC.skaterVelocity.X -= pC.acceleration - pC.friction * pC.skaterVelocity.X * (time / 1000);
                pC.skaterPosition -= (pC.skaterDirection * pC.skaterSpeed) * (time / 1000);
            }
            //Friction when keys are released
            if (Keyboard.GetState().IsKeyUp(Keys.D) || (Keyboard.GetState().IsKeyUp(Keys.A)))
            {
                pC.skaterVelocity.X += pC.acceleration - pC.friction * pC.skaterVelocity.X;
                pC.skaterPosition += pC.skaterVelocity;
                if (pC.acceleration > 0)
                {
                    pC.acceleration -= .005f;
                }
                else if (pC.acceleration < 10)
                {
                    pC.acceleration += .005f;
                }
            }
        }

    }
}
