using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Colorful_Turret
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D shipTexture;
        Vector2 shipPosition;
        Viewport viewport;

        Turret turret;


        //float rotation;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            shipTexture = Content.Load<Texture2D>("ship");

            // Makes sure the ship will always be in the center of the game window.
            viewport = graphics.GraphicsDevice.Viewport;

            shipPosition.X = viewport.Width / 2;
            shipPosition.Y = viewport.Height / 2;

            turret = new Turret(shipPosition, shipTexture);



        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            turret.Update(Mouse.GetState());

        
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            turret.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
