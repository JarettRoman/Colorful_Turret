using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Colorful_Turret
{
    class Cursor
    {
        Texture2D cursorTexture;
        Vector2 cursorPosition;
        int textureOriginX;
        int textureOriginY;

        public Cursor(Texture2D cursorTexture)
        {
            this.cursorTexture = cursorTexture;
            //this.textureOrigin = new Vector2(cursorTexture.Width, cursorTexture.Height);
            this.textureOriginX = cursorTexture.Width / 2;
            this.textureOriginY = cursorTexture.Height / 2;
            this.cursorPosition = new Vector2();
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.cursorTexture, 
                new Rectangle((int)InputHandler.MouseX() - (this.textureOriginX), (int)InputHandler.MouseY() - (this.textureOriginY), 
                    cursorTexture.Width, cursorTexture.Height), Color.White);
        }
    }
}
