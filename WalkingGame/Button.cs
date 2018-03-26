using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WalkingGame
{
    class Button
    {
        public enum State
        {
            None,
            Pressed,
            Hover,
            Released
        }

        private Rectangle _rectangle;
        private State _state;

        private Dictionary<State, Texture2D> _textures;

        public Button(Rectangle rectangle, Texture2D noneTexture, Texture2D hoverTexture, Texture2D pressedTexture)
        {
            _rectangle = rectangle;
            _textures = new Dictionary<State, Texture2D>
            {
                {State.None, noneTexture},
                {State.Hover, hoverTexture},
                {State.Pressed, pressedTexture}
            };
        }

        public void Update(MouseState mouseState)
        {
            if (_rectangle.Contains(mouseState.X, mouseState.Y))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    _state = State.Pressed;
                else
                    _state = _state == State.Pressed ? State.Released : State.Hover;
            }
            else
            {
                _state = State.None;
            }
        }

        // Make sure Begin is called on s before you call this function
        public void Draw(SpriteBatch s)
        {
            //s.Draw(_textures[State], _rectangle);
        }

    }
}
