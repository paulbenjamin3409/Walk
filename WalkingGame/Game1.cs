#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace WalkingGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        CharacterEntity character;

        SpriteFont DebugFont;
        Vector2 FontPos;

        CharacterEntity[] charArray = new CharacterEntity[3];

        SpiralEntity[] spiralArray = new SpiralEntity[3];

        DebugBox db;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // create several characters

            charArray[0] = new CharacterEntity(this.GraphicsDevice);

            spiralArray[0] = new SpiralEntity(this.GraphicsDevice);

            db = new DebugBox(this.GraphicsDevice);

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            DebugFont = Content.Load<SpriteFont>("Font");
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            db.Font = DebugFont;

            foreach (var chctr in charArray)
            {
                if (chctr == null)
                    continue;

                chctr.Update(gameTime);
            }

            // update spirals
            foreach (var spiral in spiralArray)
            {
                if (spiral == null)
                    continue;

                if (spiral.On)
                {
                    spiral.Update(gameTime);
                }


            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // We'll start all of our drawing here:
            spriteBatch.Begin();

            // Now we can do any entity rendering:
            int startingY = 256;
            int startingX = 512;


            // 
            foreach (var chctr in charArray)
            {
                if (chctr == null)
                    continue;

                // draw from an array of characters
                chctr.Draw(spriteBatch, startingX, startingY);

            }
            // spiral
            foreach (var spiralEntity in spiralArray)
            {
                if (spiralEntity == null)
                    continue;

                if (spiralEntity.On)
                {
                    spiralEntity.Draw(spriteBatch, 512, 256);
                    
                }
                

            }


            // End renders all sprites to the screen:
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

