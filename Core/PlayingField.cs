using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PlayingField
    {
        public int Width { get; init; }
        public int Height { get; init; }
        public int StartX { get; init; }
        public int StartY { get; init; }

        public PlayingField(int width, int height, int startX, int startY) 
        {
            Width = width;
            Height = height;
            StartX = startX;
            StartY = startY;
        }
    }
}
