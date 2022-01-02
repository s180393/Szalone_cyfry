using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        Texture2D texSquare, texMenuButton, texScore, texGround, texObstacleD, texObstacleH;
        Rectangle recSquare, recMenuButton, recScore, recGround, recObstacleH1, recObstacleD1, recObstacleH2, recObstacleD2, recObstacleH3, recObstacleD3, recObstacleH4, recObstacleD4;
        Vector2 vecSpeed;
        Color colMenuButton = Color.White;
        Color blank = Color.White;
        int uses;
        int temp;
        int c;
        int score=0;
        int change;
        int tmp = 342;
        int speed = 1;
        int number = 1;
        int exception = 1;
        int log = 1;
        int move1 = 0, move2 = 0, move3 = 0, move4 = 0;
        private static System.Timers.Timer counterAnim;
        private SpriteFont font;
        
        private void Scoring()
        {
            //scoring
            if (recObstacleD1.X == 0 || recObstacleD2.X == 0 || recObstacleD3.X == 0 || recObstacleD4.X == 0)
            {
                score++;
            }
        }
        private int randLevel()
        { 
            var rand = new System.Random();
            var compare = rand.Next(0, 19);
            if (compare == 0||compare==17) c = 0;          
            else if (compare == 1 || compare == 10) c = 60;
            else if (compare == 2 || compare == 15) c = 60 * 2;
            else if (compare == 3 || compare == 12) c = 60 * 3;
            else if (compare == 4 || compare == 16) c = 60 * 4;
            else if (compare == 5 || compare == 18) c = 60 * 5;
            else if (compare == 6 || compare == 11) c = 60 * 6;
            else if (compare == 7 || compare == 14) c = 60 * 7;
            else if (compare == 8 || compare == 19) c = 60 * 8;
            else if (compare == 9 || compare == 13) c = 60 * 9;

            return c;
        }
        private void LoadContentGame()
        {
            texMenuButton = Content.Load<Texture2D>("media/menu");
            texSquare = Content.Load<Texture2D>("media/square");
            texScore = Content.Load<Texture2D>("media/score");
            texGround = Content.Load<Texture2D>("media/ground");
            texObstacleD = Content.Load<Texture2D>("media/obstacleD");
            texObstacleH = Content.Load<Texture2D>("media/obstacleH");
            recSquare.Height = 60;
            recSquare.Width = 60;
            recSquare.X = GraphicsDevice.Viewport.Width >> 4;
            recSquare.Y = randLevel()+24;
            level1 = randLevel();
            level2 = randLevel();
            level3 = randLevel();
            level4 = randLevel();
            change = level1;
            font = Content.Load<SpriteFont>("Score");
            texBackground = Content.Load<Texture2D>("media/background");
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
            _spriteBatch.DrawString(font, "Score: " + score, vecSpeed, Color.DodgerBlue);
            _spriteBatch.End();
            UpdateCursorPosition();
            ButtonEvents();
        }
        private void UpdateGame()
        {
            //Background
            recBackground.X = 0;
            recBackground.Y = 0;
            recBackground.Height = 768;
            recBackground.Width = 1024;
            //Menu czcionka Lithos Pro weight=850
            recMenuButton.X = 38;
            recMenuButton.Y = 642;
            recMenuButton.Height = 60;
            recMenuButton.Width = 112;
            //Score
            recScore.X = (GraphicsDevice.Viewport.Width >> 4) - (GraphicsDevice.Viewport.Height >> 5);
            recScore.Y = GraphicsDevice.Viewport.Height - (GraphicsDevice.Viewport.Height >> 6) - recScore.Size.Y;
            recScore.Height = GraphicsDevice.Viewport.Height >> 4;
            recScore.Width = (GraphicsDevice.Viewport.Height >> 4) + (GraphicsDevice.Viewport.Width >> 4);
            //Speed
            vecSpeed.X = recScore.X+3;
            vecSpeed.Y = recScore.Y+10;
            //Ground
            recGround.X = 0; 
            recGround.Y = 648+24;
            recGround.Height = 756 - 648;
            recGround.Width = 1024;
            //Obstacle
            createObstacle();
            animObstacle();
            //Square
            temp = 60;
            Control();
            Collision();
            Changes();
            ChangeTexture(); //czcionka SimSun
            Scoring();
            if (score == 30)
            {
                scene = CurrentScene.Win;
            }
        }
    }
}
