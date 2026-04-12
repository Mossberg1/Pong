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
        private readonly int _speed = 3;
        private int _x;
        private int _y;
        private float _dx = 1f;
        private float _dy = 1f;

        public int X => _x;
        public int Y => _y;

        public Ball(int startX, int startY) 
        {
            _startX = startX;
            _startY = startY;
            _x = startX;
            _y = startY;
        }

        public void Bounce(Paddle paddle)
        {
            float paddleCenter = paddle.Y + paddle.Height / 2f;
            float ballCenter = _y + 8;
            float offset = (ballCenter - paddleCenter) / (paddle.Height / 2f);

            _dx *= -1;
            _dy = (int)(offset * 5);

            if (_dy == 0)
            {
                _dy = (_y < paddleCenter) ? -1 : 1;
            }
        }

        public void Move() 
        {
            _x += (int)(_dx * _speed);
            _y += (int)(_dy * _speed);

            if (_y <= 0 || _y >= 480 - 16) 
            {
                _dy *= -1;
            }
        }

        public void Reset() 
        {
            _x = _startX;
            _y = _startY;
            _dx = 1;
            _dy = 1;
        }
    }
}
