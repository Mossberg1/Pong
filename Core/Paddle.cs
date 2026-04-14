namespace Core
{
    public class Paddle
    {
        private readonly PlayingField _field;
        private readonly int _width = 16;
        private readonly int _height = 128;
        private readonly int _speed = 8;
        private readonly int _x;
        private int _y;

        public int Width => _width;
        public int Height => _height;
        public int X => _x;
        public int Y => _y;

        public Paddle(PlayingField field, PaddlePosition pos) 
        {
            _field = field;
            _y = _field.StartY + (_field.Height / 2) - 64;
            _x = _field.StartX + (pos == PaddlePosition.Left ? 0 : _field.Width - 16);
        }

        public void MoveUp() => _y = Math.Max(_field.StartY, _y - _speed);

        public void MoveDown() => _y = Math.Min(_field.StartY + _field.Height - _height, _y + _speed);

        public void Reset() 
        {
            _y = _field.StartY + (_field.Height / 2) - 64;
        }
    }
}
