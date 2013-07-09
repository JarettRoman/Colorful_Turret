using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Colorful_Turret
{
    public class InputHandler
    {
        public static KeyboardState CurrentKeyboardState = new KeyboardState();     
        public static MouseState CurrentMouseState;

        public static KeyboardState LastKeyboardState = new KeyboardState();
        public static MouseState LastMouseState;

        public static void Update()
        {
            LastKeyboardState = CurrentKeyboardState;
            LastMouseState = CurrentMouseState;

            CurrentKeyboardState = Keyboard.GetState();
            CurrentMouseState = Mouse.GetState();
        }



        public static bool NewKeyPress(Keys key)
        {
            return (CurrentKeyboardState.IsKeyDown(key) && LastKeyboardState.IsKeyUp(key));
        }

        public static bool KeyState(Keys key)
        {
            return CurrentKeyboardState.IsKeyDown(key);
        }



        public static int MouseX()
        {
            return CurrentMouseState.X;
        }

        public static int MouseY()
        {
            return CurrentMouseState.Y;
        }

        public static bool NewMouseLeftClick()
        {
            return (CurrentMouseState.LeftButton == ButtonState.Pressed && LastMouseState.LeftButton == ButtonState.Released);
        }

        public static bool NewMouseRightClick()
        {
            return (CurrentMouseState.RightButton == ButtonState.Pressed && LastMouseState.RightButton == ButtonState.Released);
        }

        public static bool MouseLeftDown()
        {
            return (CurrentMouseState.LeftButton == ButtonState.Pressed);
        }

        public static bool MouseRightDown()
        {
            return (CurrentMouseState.RightButton == ButtonState.Pressed);
        }



        public static Vector2 MouseVector()
        {
            return new Vector2 (MouseX(), MouseY());
        }



        public static bool Quit()
        {
            return (NewKeyPress(Keys.Escape));
        }
    }
}