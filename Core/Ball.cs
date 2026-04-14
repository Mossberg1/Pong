using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Ball
    {
        private readonly int _startX;
        private readonly int _startY;
        private readonly int _speed = 6;
        private readonly PlayingField _field;
        private int _x;
        private int _y;
        private float _dx;
        private float _dy;

        public int X => _x;
        public int Y => _y;

        public Ball(PlayingField field) 
        {
            _field = field;
            _startX = _field.StartX + (_field.Width / 2) - 8;
            _startY = _field.StartY + (_field.Height / 2) - 8;
            _x = _startX;
            _y = _startY;
            _dx = _speed;
            _dy = 0;
        }

        public void Bounce(Paddle paddle)
        {
            float paddleCenter = paddle.Y + paddle.Height / 2f;
            float offset = (Y + 8 - paddleCenter) / (paddle.Height / 2f);

            _dx = -MathF.Sign(_dx) * _speed;
            _dy = offset * _speed;
        }

        public void Move()
        {
            _x += (int)_dx;
            _y += (int)_dy;

            if (_y <= _field.StartY || _y >= _field.StartY + _field.Height - 16)
            {
                _dy *= -1;
            }
        }

        public void Reset() 
        {
            Random rand = new Random();

            _x = _startX;
            _y = _startY;
            _dx = rand.Next(2) == 0 ? _speed : -_speed ;
            _dy = rand.Next(-2, 3);
        }
    }
}
