using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CollisionManager
    {
        public static bool HasCollided(Paddle paddle, Ball ball) 
        {             
                return ball.X < paddle.X + paddle.Width &&
                    ball.X + 16 > paddle.X &&
                    ball.Y < paddle.Y + paddle.Height &&
                    ball.Y + 16 > paddle.Y;
        }
    }
}
