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
        SpriteSortMode spriteSortMode;
        Texture2D shipTexture;
        Texture2D cursorTexture;
        Vector2 shipPosition;
        Viewport viewport;
        Cursor cursor;

        static public Texture2D projectileTexture;

        Turret turret;


        //float rotation;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //this.IsMouseVisible = true;
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
            spriteSortMode = new SpriteSortMode();
            shipTexture = Content.Load<Texture2D>("ship");
            projectileTexture = Content.Load<Texture2D>("BOUNCYBALL");
            cursorTexture = Content.Load<Texture2D>("crosshair");

            // Makes sure the ship will always be in the center of the game window.
            viewport = graphics.GraphicsDevice.Viewport;

            shipPosition.X = viewport.Width / 2;
            shipPosition.Y = viewport.Height / 2;

            turret = new Turret(shipPosition, shipTexture);
            cursor = new Cursor(cursorTexture);



        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            InputHandler.Update();
            
            turret.Update(GraphicsDevice);
            cursor.Update();
        
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //SpriteSortMode.FrontToBack();

            
            turret.Draw(spriteBatch);
            cursor.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
