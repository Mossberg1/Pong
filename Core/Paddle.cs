namespace Core
{
    public class Paddle
    {
        private readonly int _width = 16;
        private readonly int _height = 128;
        private readonly int _speed = 8;
        private readonly int _x;
        private int _y;

        public int Width => _width;
        public int Height => _height;
        public int X => _x;
        public int Y => _y;

        public Paddle(int x, int y) 
        {
            _x = x;
            _y = y;
        }

        public void MoveUp() => _y = Math.Max(0, _y - _speed);

        public void MoveDown() => _y = Math.Min(480 - _height, _y + _speed);
    }
}
