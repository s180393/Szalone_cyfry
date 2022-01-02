using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        private void animObstacle()
        {
            counterAnim = new System.Timers.Timer();
            counterAnim.Interval = log + 1000;
            counterAnim.Elapsed += CounterAnim_Elapsed;
            counterAnim.AutoReset = true;
            counterAnim.Enabled = true;
            log = 5000 * (int)System.Math.Log(exception, 2);
            //Obstacle1
            recObstacleH1.X = recObstacleH1.X - speed + move1;
            recObstacleD1.X = recObstacleD1.X - speed + move1;
            recObstacleH1.Height = 24 + level1;
            recObstacleD1.Y = recObstacleH1.Height + recSquare.Height;
            recObstacleD1.Height = 768 - recObstacleD1.Y;
            //Obstacle2
            recObstacleH2.X = recObstacleH2.X - speed + move2;
            recObstacleD2.X = recObstacleD2.X - speed + move2;
            recObstacleH2.Height = 24 + level2;
            recObstacleD2.Y = recObstacleH2.Height + recSquare.Height;
            recObstacleD2.Height = 768 - recObstacleD2.Y;
            //Obstacle3
            recObstacleH3.X = recObstacleH3.X - speed + move3;
            recObstacleD3.X = recObstacleD3.X - speed + move3;
            recObstacleH3.Height = 24 + level3;
            recObstacleD3.Y = recObstacleH3.Height + recSquare.Height;
            recObstacleD3.Height = 768 - recObstacleD3.Y;
            //Obstacle4
            recObstacleH4.X = recObstacleH4.X - speed + move4;
            recObstacleD4.X = recObstacleD4.X - speed + move4;
            recObstacleH4.Height = 24 + level4;
            recObstacleD4.Y = recObstacleH4.Height + recSquare.Height;
            recObstacleD4.Height = 768 - recObstacleD4.Y;
            //moving&drawing
            if (recObstacleD1.X <= -60)
            {
                move1 = move1 + 1368;
                level1 = randLevel();
            }
            if (recObstacleD2.X <= -60)
            {
                move2 = move2 + 1368;
                level2 = randLevel();
            }
            if (recObstacleD3.X <= -60)
            {
                move3 = move3 + 1368;
                level3 = randLevel();
            }
            if (recObstacleD4.X <= -60)
            {
                move4 = move4 + 1368;
                level4 = randLevel();
            }
            speed = speed + (int)System.Math.Log(exception, 2) / 2;
        }
        private void CounterAnim_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            exception++;
            System.Threading.Thread.Sleep((int)counterAnim.Interval);
        }
        private void createObstacle()
        {
            //Obstacle1            
            recObstacleH1.X = tmp * number;
            recObstacleH1.Y = 0;
            recObstacleH1.Height = 24;
            recObstacleH1.Width = 60;
            recObstacleD1.X = tmp * number;
            recObstacleD1.Y = recObstacleH1.Height + recSquare.Height;
            recObstacleD1.Height = 768 - recObstacleD1.Y;
            recObstacleD1.Width = 60;
            //Obstacle2
            recObstacleH2.X = tmp * (number + 1);
            recObstacleH2.Y = 0;
            recObstacleH2.Height = 24;
            recObstacleH2.Width = 60;
            recObstacleD2.X = tmp * (number + 1);
            recObstacleD2.Y = recObstacleH2.Height + recSquare.Height;
            recObstacleD2.Height = 768 - recObstacleD2.Y;
            recObstacleD2.Width = 60;
            //Obstacle3
            recObstacleH3.X = tmp * (number + 2);
            recObstacleH3.Y = 0;
            recObstacleH3.Height = 24;
            recObstacleH3.Width = 60;
            recObstacleD3.X = tmp * (number + 2);
            recObstacleD3.Y = recObstacleH3.Height + recSquare.Height;
            recObstacleD3.Height = 768 - recObstacleD3.Y;
            recObstacleD3.Width = 60;
            //Obstacle4
            recObstacleH4.X = tmp * (number + 3);
            recObstacleH4.Y = 0;
            recObstacleH4.Height = 24;
            recObstacleH4.Width = 60;
            recObstacleD4.X = tmp * (number + 3);
            recObstacleD4.Y = recObstacleH4.Height + recSquare.Height;
            recObstacleD4.Height = 768 - recObstacleD4.Y;
            recObstacleD4.Width = 60;
        }
    }
}
