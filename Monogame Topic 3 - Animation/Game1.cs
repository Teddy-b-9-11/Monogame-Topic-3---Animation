using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Topic_3___Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D tribbleGreyTexture, tribbleOrangeTexture, tribbleCreamTexture, tribbleBrownTexture;

        Rectangle tribbleGreyrect, tribbleOrangeRect, tribbleCreamRect, tribbleBrownRect;
        Vector2 tribbleGreySpeed, tribbleOrangeSpeed, tribbleCreamSpeed, tribbleBrownSpeed;

        SoundEffect tribbleCoo;

        Color tribbleGreyColorMask;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            tribbleGreySpeed = new Vector2(2, 2);
            tribbleGreyrect = new Rectangle(300, 10, 100, 100);

            tribbleOrangeSpeed = new Vector2(2, 2);
            tribbleOrangeRect = new Rectangle(0, 20, 100, 100);

            tribbleCreamSpeed = new Vector2(3, 5);
            tribbleCreamRect = new Rectangle(30, 20, 100, 100);

            tribbleBrownSpeed = new Vector2(2, 2);
            tribbleBrownRect = new Rectangle(30, 20, 100, 100);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCoo = Content.Load<SoundEffect>("tribble_Coo");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tribbleGreyrect.X += (int)tribbleGreySpeed.X;
            if(tribbleGreyrect.Right > window.Width || tribbleGreyrect.Left < 0)
            {
                tribbleGreySpeed.X *= -1;
                tribbleCoo.Play();
            }

            tribbleGreyrect.Y += (int)tribbleGreySpeed.Y;
            if (tribbleGreyrect.Bottom > window.Height || tribbleGreyrect.Top < 0)
            {
                tribbleGreySpeed.Y *= -1;
                tribbleCoo.Play();
            }

            //tribbleOrangeRect.X = (int)tribbleGreyrect.X;
            //if (tribbleGreyrect.Right == tribbleOrangeRect.Left || tribbleGreyrect.Left == tribbleOrangeRect.Right)
            //{
            //    tribbleGreySpeed.X *= -1;
            //    tribbleCoo.Play();
            //}

            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            if (tribbleOrangeRect.Bottom > window.Height || tribbleOrangeRect.Top < 0)
            {
                tribbleOrangeSpeed.Y *= -1;
                tribbleCoo.Play();
            }

            //tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            //if (tribbleOrangeRect.Right == tribbleGreyrect.Right || tribbleOrangeRect.Left == tribbleGreyrect.Left)
            //{
            //    tribbleOrangeSpeed.Y++;
            //    tribbleCoo.Play();
            //}

            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            if (tribbleBrownRect.Right > window.Width || tribbleBrownRect.Left < 0)
            {
                tribbleBrownSpeed.X *= -1;
                tribbleCoo.Play();
            }

            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            if (tribbleCreamRect.Right > window.Width || tribbleCreamRect.Left < 0)
            {
                tribbleCreamSpeed.X *= -5;
                tribbleCoo.Play();
            }

            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
            if (tribbleCreamRect.Bottom > window.Height || tribbleCreamRect.Top < 0)
            {
                tribbleCreamSpeed.Y *= -3;
                tribbleCoo.Play();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyrect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
