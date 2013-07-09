using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace Colorful_Turret
{
    class Turret
    {
        Texture2D shipTexture;
        Texture2D projectileTexture;
        Vector2 shipOrigin;
        Vector2 shipPosition;
        double projectileSpeed;  //change to double
        List<Projectile> projectileList = new List<Projectile>();
        

        public Turret(Vector2 shipPosition, Texture2D shipTexture)
        {
            this.shipPosition = shipPosition;
            this.shipTexture = shipTexture;
            this.shipOrigin.X = shipTexture.Width / 2;
            this.shipOrigin.Y = shipTexture.Height / 2;
            this.projectileSpeed = 10;
            this.projectileTexture = Game1.projectileTexture;
        }

        private float direction;
        public void Update(GraphicsDevice graphicsDevice)
        {
            
            float mouseX = InputHandler.MouseX();
            float mouseY = InputHandler.MouseY();
            direction = (float)Math.Atan2(shipPosition.Y - mouseY, shipPosition.X - mouseX);
            if (InputHandler.NewMouseLeftClick())
            {
                Debug.WriteLine("Mouse clicked");
                projectileList.Add(new Projectile(this.projectileTexture, this.shipPosition, this.projectileSpeed, (new Vector2(mouseX, mouseY)), direction));

            }

        for(int i=projectileList.Count - 1; i>0; i--)
        {
         Projectile NextProjectile = projectileList[i];

         NextProjectile.Update();

            if(NextProjectile.Lifespan > 5)
                projectileList.RemoveAt(i);
        }
        }

        public float shipAngle () {
            return direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shipTexture, shipPosition, null, Color.White, direction, shipOrigin, 1.0f, SpriteEffects.None, 0f);

            foreach(Projectile i in projectileList){
                i.Draw(spriteBatch);
            }

        }
    }
}
