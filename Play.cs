using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        Texture2D texSquare, texMenuButton, texScore, texGround, texObstacleD, texObstacleH;
        Rectangle recSquare, recMenuButton, recScore, recGround, recObstacleH1, recObstacleD1, 
                  recObstacleH2, recObstacleD2, recObstacleH3, recObstacleD3, recObstacleH4, recObstacleD4;
        Vector2 vecScore;
        Color colMenuButton = Color.White;
        Color blank = Color.White;
        bool uses; //for PauseTime
        int temp; //for randLevel
        int level1, level2, level3, level4; //for obstacles and square
        private static System.Timers.Timer counterAnim;
        private SpriteFont font;
        private int randLevel()
        { 
            var rand = new System.Random();
            var compare = rand.Next(0, 19);
            if (compare == 0||compare==17) temp = 0;          
            else if (compare == 1 || compare == 10) temp = squareSize;
            else if (compare == 2 || compare == 15) temp = squareSize * 2;
            else if (compare == 3 || compare == 12) temp = squareSize * 3;
            else if (compare == 4 || compare == 16) temp = squareSize * 4;
            else if (compare == 5 || compare == 18) temp = squareSize * 5;
            else if (compare == 6 || compare == 11) temp = squareSize * 6;
            else if (compare == 7 || compare == 14) temp = squareSize * 7;
            else if (compare == 8 || compare == 19) temp = squareSize * 8;
            else if (compare == 9 || compare == 13) temp = squareSize * 9;

            return temp;
        }
        private void LoadContentGame()
        {
            //textures
            texMenuButton = Content.Load<Texture2D>("media/menu");
            texSquare = Content.Load<Texture2D>("media/square");
            texScore = Content.Load<Texture2D>("media/score");
            texGround = Content.Load<Texture2D>("media/ground");
            texObstacleD = Content.Load<Texture2D>("media/obstacleD");
            texObstacleH = Content.Load<Texture2D>("media/obstacleH");
            font = Content.Load<SpriteFont>("Score");
            texBackground = Content.Load<Texture2D>("media/background");
            //square location
            recSquare.Height = squareSize;
            recSquare.Width = squareSize;
            recSquare.X = GraphicsDevice.Viewport.Width >> 4;
            recSquare.Y = randLevel() + 24;
            //obstacles level
            level1 = randLevel();
            level2 = randLevel();
            level3 = randLevel();
            level4 = randLevel();
            //square texture
            change = level1;
        }
        private void DrawGame()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texBackground, recBackground, colBackground);
            _spriteBatch.Draw(texObstacleH, recObstacleH1, blank);
            _spriteBatch.Draw(texObstacleD, recObstacleD1, blank);
            _spriteBatch.Draw(texObstacleH, recObstacleH2, blank);
            _spriteBatch.Draw(texObstacleD, recObstacleD2, blank);
            _spriteBatch.Draw(texObstacleH, recObstacleH3, blank);
            _spriteBatch.Draw(texObstacleD, recObstacleD3, blank);
            _spriteBatch.Draw(texObstacleH, recObstacleH4, blank);
            _spriteBatch.Draw(texObstacleD, recObstacleD4, blank);
            _spriteBatch.Draw(texGround, recGround, blank);
            _spriteBatch.Draw(texMenuButton, recMenuButton, colMenuButton);
            _spriteBatch.Draw(texSquare, recSquare, blank);
            _spriteBatch.Draw(texScore, recScore, blank);
            _spriteBatch.DrawString(font, "Score: " + score, vecScore, Color.DodgerBlue);
            _spriteBatch.End();
            //methods
            UpdateCursorPosition();
            ButtonEvents();
        }
        private void UpdateGame()
        {
            //location & dimensions
            //Background
            recBackground.X = 0;
            recBackground.Y = 0;
            recBackground.Height = 768;
            recBackground.Width = 1024;
            //MenuButton
            recMenuButton.X = 38;
            recMenuButton.Y = 642;
            recMenuButton.Height = 60;
            recMenuButton.Width = 112;
            //ScoreGround
            recScore.X = (GraphicsDevice.Viewport.Width >> 4) - (GraphicsDevice.Viewport.Height >> 5);
            recScore.Y = GraphicsDevice.Viewport.Height - (GraphicsDevice.Viewport.Height >> 6) - recScore.Size.Y;
            recScore.Height = GraphicsDevice.Viewport.Height >> 4;
            recScore.Width = (GraphicsDevice.Viewport.Height >> 4) + (GraphicsDevice.Viewport.Width >> 4);
            //TextScore
            vecScore.X = recScore.X + 3;
            vecScore.Y = recScore.Y + 10;
            //Ground
            recGround.X = 0; 
            recGround.Y = 648 + 24;
            recGround.Height = 756 - 648;
            recGround.Width = 1024;
            //methods
            //Obstacle
            createObstacle();
            animObstacle();
            //Square
            Control();
            if (flag == false)
            {
                Collision();
            }
            Changes();
            ChangeTexture();
            //end
            if (score == 30)
            {
                scene = CurrentScene.Win;
            }
        }
    }
}
