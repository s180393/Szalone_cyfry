using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;
        MouseState mouseState;
        Rectangle Cursor;
        bool ttt = false;
        CurrentScene scene;
        Rectangle recBackground;
        Texture2D texBackground;
        Color colBackground = Color.White;

        private void UpdateCursorPosition()
        {
            mouseState = Mouse.GetState();
            Cursor.X = mouseState.X;
            Cursor.Y = mouseState.Y;
        }

        private void ButtonEvents()
        {
            //Start
            if (scene == CurrentScene.Start)
            {
                if ((recStartButton.Intersects(Cursor)))
                {
                    colStartButton = Color.Green;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        scene = CurrentScene.HowToPlay;
                    }
                }
                else
                {
                    colStartButton = Color.White;
                }
                if ((recQuitButton.Intersects(Cursor)))
                {
                    colQuitButton = Color.Red;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        Exit();
                    }
                }
                else
                {
                    colQuitButton = Color.White;
                }
            }
            //Lose
            else if (scene == CurrentScene.Lose)
            {
                //Quit
                if ((recQuitButton.Intersects(Cursor)))
                {
                    colQuitButton = Color.Red;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        Exit();
                    }
                }
                else
                {
                    colQuitButton = Color.White;
                }
            }
            //Win
            else if (scene == CurrentScene.Win)
            {
                //Quit
                if ((recQuitButton.Intersects(Cursor)))
                {
                    colQuitButton = Color.Red;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        Exit();
                    }
                }
                else
                {
                    colQuitButton = Color.White;
                }
            }
            //HowToPlay
            else if (scene == CurrentScene.HowToPlay)
            {
                //Start
                if ((recStartButton.Intersects(Cursor)))
                {
                    colStartButton = Color.Green;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        scene = CurrentScene.Play;
                    }
                }
                else
                {
                    colStartButton = Color.White;
                }
            }
            //Play
            else if (scene == CurrentScene.Play)
            {
                if ((recMenuButton.Intersects(Cursor)))
                {
                    colMenuButton = Color.Green;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        scene = CurrentScene.Menu;
                    }
                }
                else
                {
                    colMenuButton = Color.White;
                }
            }
            //Menu
            else if (scene == CurrentScene.Menu)
            {
                //Quit
                if ((recQuitButton.Intersects(Cursor)))
                {
                    colQuitButton = Color.Red;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        Exit();
                    }
                }
                else
                {
                    colQuitButton = Color.White;
                }
                //Pause
                if (recPauseButton.Intersects(Cursor))
                {
                    colPauseButton = Color.Yellow;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        ttt = true;
                        scene = CurrentScene.Play;
                        uses = 0;
                    }
                }
                else
                {
                    colPauseButton = Color.White;
                }
                //Resume
                if ((recResumeButton.Intersects(Cursor)))
                {
                    colResumeButton = Color.Green;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        scene = CurrentScene.Play;
                        ttt = false;
                    }
                }
                else
                {
                    colResumeButton = Color.White;
                }
                //Stop
                if ((recStopButton.Intersects(Cursor)))
                {
                    colStopButton = Color.Orange;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        scene = CurrentScene.Lose;
                    }
                }
                else
                {
                    colStopButton = Color.White;
                }
            }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            Window.Title = "Szalone Cyfry";
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges();
            scene = CurrentScene.Start;
            base.Initialize();
            uses = 1;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadContentStart();
            LoadContentGame();
            LoadContentMenu();
            LoadContentLose();
            LoadContentWin();
            LoadContentHow();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (scene == CurrentScene.Start)
                UpdateStart();
            if (scene == CurrentScene.Play)
                if (ttt!=true) UpdateGame();
            if (scene == CurrentScene.Lose)
                UpdateLose();
            if (scene == CurrentScene.Win)
                UpdateWin();
            if (scene == CurrentScene.Menu)
                UpdateMenu();
            if (scene == CurrentScene.HowToPlay)
                UpdateHow();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (scene == CurrentScene.Start)
                DrawStart();
            if (scene == CurrentScene.Play)
                DrawGame();
            if (scene == CurrentScene.Menu)
                DrawMenu();
            if (scene == CurrentScene.Lose)
                DrawLose();
            if (scene == CurrentScene.Win)
                DrawWin();
            if (scene == CurrentScene.HowToPlay)
                DrawHow();
            base.Draw(gameTime);
        }
    }
}
