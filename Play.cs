using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        Texture2D texSquare, texMenuButton, texScore, texGround, texObstacle;
        Rectangle recSquare, recMenuButton, recScore, recGround, recObstacle;
        Color colMenuButton = Color.White;
        Color blank = Color.White;
        int temp;
        int tmp = 1;
        int speed = 1;
        int log = 1 ;
        int create = 1;
        private static System.Timers.Timer counterAnim;
        private static System.Timers.Timer go;
        private void animObstacle()
        {
            counterAnim = new System.Timers.Timer();
            go = new System.Timers.Timer();
            counterAnim.Interval = 100000-log;
            go.Interval = 1000;
            counterAnim.Elapsed += CounterAnim_Elapsed;
            go.Elapsed += CounterAnim_Elapsed;
            counterAnim.AutoReset = true;
            go.AutoReset = false;
            counterAnim.Enabled = true;
            go.Enabled = true;
            log = 2000*(int)System.Math.Log(speed,2);

            recObstacle.X = recObstacle.X - speed;
        }

        private void CounterAnim_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            speed++;
        }

        private void createObstacle()
        {
            recObstacle.X = 1024;
            recObstacle.Y = 0;
            recObstacle.Height = 24;
            recObstacle.Width = 60;
            
        }

        private void LoadContentGame()
        {
            texMenuButton = Content.Load<Texture2D>("media/menu");
            texSquare = Content.Load<Texture2D>("media/square");
            texScore = Content.Load<Texture2D>("media/score");
            texGround = Content.Load<Texture2D>("media/score");
            texObstacle = Content.Load<Texture2D>("media/score");
            recSquare.Height = 60;
            recSquare.Width = 60;
            recSquare.X = GraphicsDevice.Viewport.Width >> 4;
            recSquare.Y = 24;
        }
        private void DrawGame()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texObstacle, recObstacle, Color.Blue);
            _spriteBatch.Draw(texGround, recGround, Color.Black);
            _spriteBatch.Draw(texMenuButton, recMenuButton, colMenuButton);
            _spriteBatch.Draw(texSquare, recSquare, blank);
            _spriteBatch.Draw(texScore, recScore, blank);
            _spriteBatch.End();
        }
        private void UpdateGame()
        {
            //Menu
            recMenuButton.X = GraphicsDevice.Viewport.Width >> 4;
            recMenuButton.Y = GraphicsDevice.Viewport.Height - (GraphicsDevice.Viewport.Height >> 5) - 2*recMenuButton.Size.Y;
            recMenuButton.Height = GraphicsDevice.Viewport.Height >> 4;
            recMenuButton.Width = GraphicsDevice.Viewport.Width >> 4;
            //Score
            recScore.X = (GraphicsDevice.Viewport.Width >> 4) - (GraphicsDevice.Viewport.Height >> 5);
            recScore.Y = GraphicsDevice.Viewport.Height - (GraphicsDevice.Viewport.Height >> 6) - recScore.Size.Y;
            recScore.Height = GraphicsDevice.Viewport.Height >> 4;
            recScore.Width = (GraphicsDevice.Viewport.Height >> 4) + (GraphicsDevice.Viewport.Width >> 4);
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
            UpdateCursorPosition();
            ButtonEvents();
        }
    }
}
