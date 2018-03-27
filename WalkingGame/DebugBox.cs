using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WalkingGame
{
    public class DebugBox
    {
        public SpriteFont Font { get; set; }

        private Vector2 FontPosition { get; set; }

        private int NextPosition { get; set; }

        public DebugBox(GraphicsDevice graphicsDevice)
        {
            // initialize the entity
            // On Right Side Top
            var initialWidth = (float)(graphicsDevice.Viewport.Width - (graphicsDevice.Viewport.Width * .15));
            var initialHeight = (float)(10);

            // Find Right side of screen
            FontPosition = new Vector2(initialWidth, initialHeight);
            NextPosition = 0;
        }

        public void Draw(SpriteBatch spriteBatch, string text, int startingPosX, int startingPosY)
        {
            Vector2 FontOrigin = Font.MeasureString(text) / 2;

            FontPosition = new Vector2(FontPosition.X + startingPosX, FontPosition.Y + startingPosY);

            spriteBatch.DrawString(Font, text, FontPosition, Color.Black,
                0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

            NextPosition += 20;
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
