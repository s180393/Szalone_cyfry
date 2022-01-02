using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        int level1, level2, level3, level4;
        private void Control()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.D9))
                recSquare.Y = 24;
            if (state.IsKeyDown(Keys.D8))
                recSquare.Y = 24 + temp;
            if (state.IsKeyDown(Keys.D7))
                recSquare.Y = 24 + temp * 2;
            if (state.IsKeyDown(Keys.D6))
                recSquare.Y = 24 + temp * 3;
            if (state.IsKeyDown(Keys.D5))
                recSquare.Y = 24 + temp * 4;
            if (state.IsKeyDown(Keys.D4))
                recSquare.Y = 24 + temp * 5;
            if (state.IsKeyDown(Keys.D3))
                recSquare.Y = 24 + temp * 6;
            if (state.IsKeyDown(Keys.D2))
                recSquare.Y = 24 + temp * 7;
            if (state.IsKeyDown(Keys.D1))
                recSquare.Y = 24 + temp * 8;
            if (state.IsKeyDown(Keys.D0))
                recSquare.Y = 24 + temp * 9;
        }
        private void Collision()
        {
            //Obstacle1
            if (recSquare.Y < recObstacleD1.Y && recSquare.Y + 60 > recObstacleH1.Height)
            {

            }
            else if (recSquare.X + 60 > recObstacleH1.X && recSquare.X < recObstacleH1.X + 60)
            {
                scene = CurrentScene.Lose;
            }
            //Obstacle2
            if (recSquare.Y < recObstacleD2.Y && recSquare.Y + 60 > recObstacleH2.Height)
            {

            }
            else if (recSquare.X + 60 > recObstacleH2.X && recSquare.X < recObstacleH2.X + 60)
            {
                scene = CurrentScene.Lose;
            }
            //Obstacle3
            if (recSquare.Y < recObstacleD3.Y && recSquare.Y + 60 > recObstacleH3.Height)
            {

            }
            else if (recSquare.X + 60 > recObstacleH3.X && recSquare.X < recObstacleH3.X + 60)
            {
                scene = CurrentScene.Lose;
            }
            //Obstacle4
            if (recSquare.Y < recObstacleD4.Y && recSquare.Y + 60 > recObstacleH4.Height)
            {

            }
            else if (recSquare.X + 60 > recObstacleH4.X && recSquare.X < recObstacleH4.X + 60)
            {
                scene = CurrentScene.Lose;
            }
        }

        private void Changes()
        {
            if (recSquare.X > recObstacleH1.X + 60 && recSquare.X + 60 < recObstacleH2.X)
            {
                change = level2;
            }
            if (recSquare.X > recObstacleH2.X + 60 && recSquare.X + 60 < recObstacleH3.X)
            {
                change = level3;
            }
            if (recSquare.X > recObstacleH3.X + 60 && recSquare.X + 60 < recObstacleH4.X)
            {
                change = level4;
            }
            if (recSquare.X > recObstacleH4.X + 60 && recSquare.X + 60 < recObstacleH1.X)
            {
                change = level1;
            }
        }
        private void ChangeTexture()
        {
            if (change == 0) texSquare = Content.Load<Texture2D>("media/sq9");
            else if (change == 60) texSquare = Content.Load<Texture2D>("media/sq8");
            else if (change == 2 * 60) texSquare = Content.Load<Texture2D>("media/sq7");
            else if (change == 3 * 60) texSquare = Content.Load<Texture2D>("media/sq6");
            else if (change == 4 * 60) texSquare = Content.Load<Texture2D>("media/sq5");
            else if (change == 5 * 60) texSquare = Content.Load<Texture2D>("media/sq4");
            else if (change == 6 * 60) texSquare = Content.Load<Texture2D>("media/sq3");
            else if (change == 7 * 60) texSquare = Content.Load<Texture2D>("media/sq2");
            else if (change == 8 * 60) texSquare = Content.Load<Texture2D>("media/sq1");
            else if (change == 9 * 60) texSquare = Content.Load<Texture2D>("media/sq0");
        }
    }
}
