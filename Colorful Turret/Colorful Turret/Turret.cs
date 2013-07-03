using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Colorful_Turret
{
    class Turret
    {
        Texture2D shipTexture;

        Vector2 shipOrigin;
        Vector2 shipPosition;

        public Turret(Vector2 shipPosition, Texture2D shipTexture)
        {
            this.shipPosition = shipPosition;
            this.shipTexture = shipTexture;
            this.shipOrigin.X = shipTexture.Width / 2;
            this.shipOrigin.Y = shipTexture.Height / 2;
        }

        private float angle;
        public void Update(MouseState mouseState)
        {
            mouseState = Mouse.GetState();
            float mouseX = mouseState.X;
            float mouseY = mouseState.Y;
            angle = (float)Math.Atan2(shipPosition.Y - mouseY, shipPosition.X - mouseX);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shipTexture, shipPosition, null, Color.White, angle, shipOrigin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
