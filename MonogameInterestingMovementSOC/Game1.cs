using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace MonogameInterestingMovementSOC
{
    public class Game1 : Game
    {
        //IMAGE SOURCES:
        //icy lake : https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/i/515f04c5-5954-4826-ad10-4ce082a20fee/d87thcu-e88a7692-a8aa-44c0-8f9f-eb5dd03430f3.png/v1/fill/w_1219,h_656,q_70,strp/icy_lake_on_the_mountaintop_in_whistler__bc_by_thoun_d87thcu-pre.jpg        
        //ice skater: https://www.clipartmax.com/png/middle/228-2282565_skating-clipart-transparent-background-ice-skater-clip-art.png

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        PlayerController playerController;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            //Set fps
            TargetElapsedTime = TimeSpan.FromTicks(222222);

            playerController = new PlayerController();            

            //Window size
            graphics.PreferredBackBufferWidth = 1219;
            graphics.PreferredBackBufferHeight = 656;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Set Textures
            playerController.SetTextures(Content);                
        }

        protected override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // GAME LOGIC - KEYBOARD INPUT
            playerController.KeyboardInput(playerController, time);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            // Lake texture and qualities
            spriteBatch.Draw(playerController.GetLakeTexture(), playerController.lakePosition, Color.White);
            // Skater texture and movement
            spriteBatch.Draw(playerController.GetSkaterTexture(), playerController.skaterPosition, null, Color.White, playerController.skaterRotation, playerController.skaterOrigin, new Vector2(1, 1), playerController.GetSpriteEffects(), 0f);
            spriteBatch.End();

            //Boundries
            if ((playerController.skaterPosition.X > graphics.GraphicsDevice.Viewport.Width - playerController.GetSkaterTexture().Width)
                || (playerController.skaterPosition.X < 0)
               )
            {
                playerController.skaterPosition = new Vector2(320, 670);
            }

            base.Draw(gameTime);
        }
    }
}