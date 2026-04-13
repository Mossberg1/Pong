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

        public PlayingField(int width, int height) 
        {
            Width = width;
            Height = height;
        }
    }
}
