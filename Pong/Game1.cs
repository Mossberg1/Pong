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
        private Texture2D _texture;
        private Paddle _leftPaddle;
        private Paddle _rightPaddle;
        private PlayingField _playingField;
        private Ball _ball;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
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

            _playingField = new PlayingField(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height - 128);
            _leftPaddle = new Paddle(_playingField, PaddlePosition.Left);
            _rightPaddle = new Paddle(_playingField, PaddlePosition.Right);
            _ball = new Ball(_playingField);
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
            DrawPlayingFieldBoundary();

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

            if (_ball.X <= 0 || _ball.X >= _playingField.Width)
            {
                _ball.Reset();
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawPlayingFieldBoundary() 
        {
            Rectangle boundary = new Rectangle(0, _playingField.Height, GraphicsDevice.Viewport.Width, 8);
            _spriteBatch.Draw(_texture, boundary, Color.White);
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
