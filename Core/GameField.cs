using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class GameField
    {
        private readonly Paddle _leftPaddle;
        private readonly Paddle _rightPaddle;
        private readonly Ball _ball;
        private readonly int _fieldHeight;
        private readonly int _fieldWidth;

        public GameField(int fieldHeight, int fieldWidth) 
        {
            _fieldHeight = fieldHeight;
            _fieldWidth = fieldWidth;
            _leftPaddle = new Paddle(0, fieldHeight / 2);
            _rightPaddle = new Paddle(fieldWidth - 16, fieldHeight / 2);
        }
    }
}
