using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {//3 minuty gitówa
        Texture2D texSquare, texMenuButton, texScore, texGround, texObstacle;
        Rectangle recSquare, recMenuButton, recScore, recGround, recObstacleH1, recObstacleD1, recObstacleH2, recObstacleD2, recObstacleH3, recObstacleD3, recObstacleH4, recObstacleD4;
        Vector2 vecSpeed, vecSpeedl;
        Color colMenuButton = Color.White;
        Color blank = Color.White;
        int temp;
        int c;
        int change;
        int level1, level2, level3, level4;
        int tmp = 342;
        int speed = 1;
        int number = 1;
        int log = 1;
        int move1 = 0, move2 = 0, move3 = 0, move4 = 0;
        private static System.Timers.Timer counterAnim;
        private static System.Timers.Timer go;
        private SpriteFont font;
        private int showSpeed = 0;
        private void animObstacle()
        {
            counterAnim = new System.Timers.Timer();
            go = new System.Timers.Timer();
            counterAnim.Interval = 50000 - log;
            go.Interval = 1000;
            counterAnim.Elapsed += CounterAnim_Elapsed;
            go.Elapsed += CounterAnim_Elapsed;
            counterAnim.AutoReset = true;
            go.AutoReset = false;
            counterAnim.Enabled = true;
            go.Enabled = true;
            log = 2000 * (int)System.Math.Log(speed, 2);
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
            //moving
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
            
        }

        private void CounterAnim_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            speed++;
        }

        private void Collision()
        {
            //Obstacle1
            if (recSquare.Y < recObstacleD1.Y && recSquare.Y + 60 > recObstacleH1.Height)
            {

            }
            else if (recSquare.X + 60 > recObstacleH1.X && recSquare.X < recObstacleH1.X + 60)
            {
                scene = CurrentScene.Menu;
            }
            //Obstacle2
            if (recSquare.Y < recObstacleD2.Y && recSquare.Y + 60 > recObstacleH2.Height)
            {

            }
            else if (recSquare.X + 60 > recObstacleH2.X && recSquare.X < recObstacleH2.X + 60)
            {
                scene = CurrentScene.Menu;
            }
            //Obstacle3
            if (recSquare.Y < recObstacleD3.Y && recSquare.Y + 60 > recObstacleH3.Height)
            {

            }
            else if (recSquare.X + 60 > recObstacleH3.X && recSquare.X < recObstacleH3.X + 60)
            {
                scene = CurrentScene.Menu;
            }
            //Obstacle4
            if (recSquare.Y < recObstacleD4.Y && recSquare.Y + 60 > recObstacleH4.Height)
            {

            }
            else if (recSquare.X + 60 > recObstacleH4.X && recSquare.X < recObstacleH4.X + 60)
            {
                scene = CurrentScene.Menu;
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
            recObstacleH2.X = tmp* (number+1);
            recObstacleH2.Y = 0;
            recObstacleH2.Height = 24;
            recObstacleH2.Width = 60;
            recObstacleD2.X = tmp* (number + 1);
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
            recSquare.Y = randLevel();
            level1 = randLevel();
            level2 = randLevel();
            level3 = randLevel();
            level4 = randLevel();
            change = level1;
            font = Content.Load<SpriteFont>("File");
        }
        private void DrawGame()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texObstacle, recObstacleH1, Color.Blue);
            _spriteBatch.Draw(texObstacle, recObstacleD1, Color.Blue);
            _spriteBatch.Draw(texObstacle, recObstacleH2, Color.Blue);
            _spriteBatch.Draw(texObstacle, recObstacleD2, Color.Blue);
            _spriteBatch.Draw(texObstacle, recObstacleH3, Color.Blue);
            _spriteBatch.Draw(texObstacle, recObstacleD3, Color.Blue);
            _spriteBatch.Draw(texObstacle, recObstacleH4, Color.Blue);
            _spriteBatch.Draw(texObstacle, recObstacleD4, Color.Blue);
            _spriteBatch.Draw(texGround, recGround, Color.Black);
            _spriteBatch.Draw(texMenuButton, recMenuButton, colMenuButton);
            _spriteBatch.Draw(texSquare, recSquare, blank);
            _spriteBatch.Draw(texScore, recScore, blank);
            _spriteBatch.DrawString(font, "Speed: "+log, vecSpeed, Color.Black);
            _spriteBatch.DrawString(font, "Speed: " + speed, vecSpeedl, Color.Black);
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
            //Speed
            vecSpeed.X = recScore.X;
            vecSpeed.Y = recScore.Y;
            vecSpeedl.X = recScore.X;
            vecSpeedl.Y = recScore.Y+20;
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
            //Collision();
            Changes();
            ChangeTexture();
        }
    }
}
