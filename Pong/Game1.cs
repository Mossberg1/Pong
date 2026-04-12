using Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Paddle _leftPaddle;
        private Paddle _rightPaddle;
        private Ball _ball;


        Texture2D _texture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _texture = new Texture2D(GraphicsDevice, 1, 1);
            _texture.SetData([Color.White]);

            _leftPaddle = new Paddle(0, (GraphicsDevice.Viewport.Height / 2) - 64);
            _rightPaddle = new Paddle(GraphicsDevice.Viewport.Width - 16, (GraphicsDevice.Viewport.Height / 2) - 64);
            _ball = new Ball((GraphicsDevice.Viewport.Width / 2) - 8, (GraphicsDevice.Viewport.Height / 2) - 8);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.W))
            {
                _leftPaddle.MoveUp();
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                _leftPaddle.MoveDown();
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                _rightPaddle.MoveUp();
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                _rightPaddle.MoveDown();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            DrawPaddle(_leftPaddle);
            DrawPaddle(_rightPaddle);
            DrawBall(_ball);

            _ball.Move();

            if (CollisionManager.HasCollided(_leftPaddle, _ball))
            {
                _ball.Bounce(_leftPaddle);
            }
            if (CollisionManager.HasCollided(_rightPaddle, _ball))
            {
                _ball.Bounce(_rightPaddle);
            }

            if (_ball.X == 0 || _ball.X == GraphicsDevice.Viewport.Width)
            {
                _ball.Reset();
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawPaddle(Paddle paddle) 
        {
            Rectangle paddleRect = new Rectangle(paddle.X, paddle.Y, paddle.Width, paddle.Height);
            _spriteBatch.Draw(_texture, paddleRect, Color.White);
        }

        private void DrawBall(Ball ball) 
        {
            Rectangle ballRect = new Rectangle(ball.X, ball.Y, 16, 16);
            _spriteBatch.Draw(_texture, ballRect, Color.White);
        }
    }
}
