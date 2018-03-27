using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WalkingGame
{
    public class SpiralEntity
    {
        static Texture2D spiralTexture;


        Animation currentAnimation;
        Color tintColor;

        private float angle;
        int mAlphaValue = 1;
        int mFadeIncrement = 3;
        double mFadeDelay = .035;

        private float rotation;
        private float rotationSpeed = (float) .05;
        private float fadeOutDelay = (float).002;

        public bool On
        {
            get;set;
        }

        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }

        public float FadeValue { get; set; }

        public SpiralEntity(GraphicsDevice graphicsDevice)
        {
            if (spiralTexture == null)
            {
                using (var stream = TitleContainer.OpenStream("Content/spiral.png"))
                {
                    spiralTexture = Texture2D.FromStream(graphicsDevice, stream);
                }

            }

            currentAnimation = new Animation();
            currentAnimation.AddFrame(new Rectangle(0, 0, 256, 256), TimeSpan.FromSeconds(1));

            FadeValue = 1;
            On = true;
        }


        public void Draw(SpriteBatch spriteBatch, int startingPosX, int startingPosY)
        {
            Vector2 topLeftOfSprite = new Vector2(this.X + startingPosX, this.Y + startingPosY);

            tintColor = new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255));
            

            var sourceRectangle = currentAnimation.CurrentRectangle;
            Vector2 origin = new Vector2((spiralTexture.Width / 2), (spiralTexture.Height / 2));

            sourceRectangle.X += (sourceRectangle.Width / 2);
            sourceRectangle.Y += (sourceRectangle.Height / 2);
            
            //rotation += rotationSpeed;

            spriteBatch.Draw(spiralTexture,
                sourceRectangle, 
                null, tintColor * FadeValue, rotation, origin, SpriteEffects.None, 1.0f);


        }
        public void Update(GameTime gameTime)
        {
            var velocity = GetDesiredVelocityFromInput();
            
            // next step
            var nextX = velocity.X;
            var nextY = velocity.Y;

            angle += (float)(gameTime.ElapsedGameTime.TotalSeconds * 10.00);

            this.X = (float)(nextX + Math.Cos(angle) * 45);
            this.Y = (float)(nextY + Math.Sin(angle) * 45);

            this.X += (float)(nextX * gameTime.ElapsedGameTime.TotalSeconds);
            this.Y += (float)(nextY * gameTime.ElapsedGameTime.TotalSeconds);

            rotation += (float).05;

            // tint changing in and out
            mFadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;

            if (mFadeDelay <= 0)
            {
                //Reset the Fade delay
                mFadeDelay = .035;

                //Increment/Decrement the fade value for the image
                mAlphaValue += mFadeIncrement;

                //If the AlphaValue is equal or above the max Alpha value or
                //has dropped below or equal to the min Alpha value, then 
                //reverse the fade
                if (mAlphaValue >= 255 || mAlphaValue <= 0)
                {
                    mFadeIncrement *= -1;
                    //On = false;
                }
            }

            // fade out of scene
            //FadeValue = (float)( FadeValue - fadeOutDelay);

            if (FadeValue < 0)
            {
                On = false;
                
            }

            currentAnimation.Update(gameTime);
        }


        float radius { get; set; }
        float theta { get; set; }

        Vector2 GetDesiredVelocityFromInput()
        {
            Vector2 desiredVelocity = new Vector2();

            desiredVelocity.X = 50;
            desiredVelocity.Y = 50;

            return desiredVelocity;
        }
    }
}

