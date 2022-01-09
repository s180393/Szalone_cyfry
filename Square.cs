using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        int squareSize = 60;
        int change; //level for square
        private void Control() //reacting on keys
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.D9))
                recSquare.Y = 24;
            if (state.IsKeyDown(Keys.D8))
                recSquare.Y = 24 + squareSize;
            if (state.IsKeyDown(Keys.D7))
                recSquare.Y = 24 + squareSize * 2;
            if (state.IsKeyDown(Keys.D6))
                recSquare.Y = 24 + squareSize * 3;
            if (state.IsKeyDown(Keys.D5))
                recSquare.Y = 24 + squareSize * 4;
            if (state.IsKeyDown(Keys.D4))
                recSquare.Y = 24 + squareSize * 5;
            if (state.IsKeyDown(Keys.D3))
                recSquare.Y = 24 + squareSize * 6;
            if (state.IsKeyDown(Keys.D2))
                recSquare.Y = 24 + squareSize * 7;
            if (state.IsKeyDown(Keys.D1))
                recSquare.Y = 24 + squareSize * 8;
            if (state.IsKeyDown(Keys.D0))
                recSquare.Y = 24 + squareSize * 9;
        }
        private void Collision()
        {
            //Obstacle1
            if (recSquare.Y < recObstacleD1.Y && recSquare.Y + squareSize > recObstacleH1.Height)
            {

            }
            else if (recSquare.X + squareSize > recObstacleH1.X && recSquare.X < recObstacleH1.X + squareSize)
            {
                scene = CurrentScene.Lose;
            }
            //Obstacle2
            if (recSquare.Y < recObstacleD2.Y && recSquare.Y + squareSize > recObstacleH2.Height)
            {

            }
            else if (recSquare.X + squareSize > recObstacleH2.X && recSquare.X < recObstacleH2.X + squareSize)
            {
                scene = CurrentScene.Lose;
            }
            //Obstacle3
            if (recSquare.Y < recObstacleD3.Y && recSquare.Y + squareSize > recObstacleH3.Height)
            {

            }
            else if (recSquare.X + squareSize > recObstacleH3.X && recSquare.X < recObstacleH3.X + squareSize)
            {
                scene = CurrentScene.Lose;
            }
            //Obstacle4
            if (recSquare.Y < recObstacleD4.Y && recSquare.Y + squareSize > recObstacleH4.Height)
            {

            }
            else if (recSquare.X + squareSize > recObstacleH4.X && recSquare.X < recObstacleH4.X + squareSize)
            {
                scene = CurrentScene.Lose;
            }
        }
        private void Changes()
        {
            if (recSquare.X > recObstacleH1.X + squareSize && recSquare.X + squareSize < recObstacleH2.X)
            {
                change = level2;
            }
            if (recSquare.X > recObstacleH2.X + squareSize && recSquare.X + squareSize < recObstacleH3.X)
            {
                change = level3;
            }
            if (recSquare.X > recObstacleH3.X + squareSize && recSquare.X + squareSize < recObstacleH4.X)
            {
                change = level4;
            }
            if (recSquare.X > recObstacleH4.X + squareSize && recSquare.X + squareSize < recObstacleH1.X)
            {
                change = level1;
            }
        }
        private void ChangeTexture()
        {
            if (change == 0) texSquare = Content.Load<Texture2D>("media/sq9");
            else if (change == squareSize) texSquare = Content.Load<Texture2D>("media/sq8");
            else if (change == 2 * squareSize) texSquare = Content.Load<Texture2D>("media/sq7");
            else if (change == 3 * squareSize) texSquare = Content.Load<Texture2D>("media/sq6");
            else if (change == 4 * squareSize) texSquare = Content.Load<Texture2D>("media/sq5");
            else if (change == 5 * squareSize) texSquare = Content.Load<Texture2D>("media/sq4");
            else if (change == 6 * squareSize) texSquare = Content.Load<Texture2D>("media/sq3");
            else if (change == 7 * squareSize) texSquare = Content.Load<Texture2D>("media/sq2");
            else if (change == 8 * squareSize) texSquare = Content.Load<Texture2D>("media/sq1");
            else if (change == 9 * squareSize) texSquare = Content.Load<Texture2D>("media/sq0");
        }
    }
}
