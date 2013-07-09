using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Colorful_Turret
{
    class Projectile
    {
        const int MAX_DISTANCE = 500;
        public bool visible = false;
        Vector2 startPosition;
        Vector2 currentPosition;
        Vector2 speed;
        Vector2 target;
        Vector2 slope;
        Vector2 rotation;
        float direction;
        Texture2D projectileTexture;

        public Projectile(Texture2D projectileTexture, Vector2 startPosition, Vector2 speed, Vector2 target, float direction)
        {
            this.startPosition = startPosition;
            this.currentPosition = startPosition;
            this.speed = speed;
            this.target = target;
            //this.direction = (this.target.Y - this.startPosition.Y / this.target.X - this.startPosition.X);
            this.slope = new Vector2 (this.target.X - this.startPosition.X, this.target.Y - this.startPosition.Y);
            this.direction = direction;
            this.projectileTexture = projectileTexture;
        }


        public void Update()
        {
            this.currentPosition += (speed)*(this.slope);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.projectileTexture,this.currentPosition,null,Color.White,this.direction,this.startPosition,1.0f,SpriteEffects.None,0f);
            //spriteBatch.Draw(shipTexture, shipPosition, null, Color.White, direction, shipOrigin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
