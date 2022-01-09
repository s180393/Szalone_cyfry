using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;
        MouseState mouseState;
        Rectangle Cursor;
        CurrentScene scene;
        Rectangle recBackground;
        Texture2D texBackground;
        Color colBackground = Color.White;
        bool PauseTime = false;
        Song song;
        private void UpdateCursorPosition()
        {
            mouseState = Mouse.GetState();
            Cursor.X = mouseState.X;
            Cursor.Y = mouseState.Y;
        }
        private void ButtonEvents() 
        {
            //StartScene
            if (scene == CurrentScene.Start)
            {
                //StartButton
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
                //HowToPlayButton
                if ((recHowButton.Intersects(Cursor)))
                {
                    colHowButton = Color.Yellow;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        scene = CurrentScene.HowToPlay;
                    }
                }
                else
                {
                    colHowButton = Color.White;
                }
                //QuitButton
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
            //LoseScene
            else if (scene == CurrentScene.Lose)
            {
                //QuitButton
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
                //Flag1Button
                if ((recFlag1Button.Intersects(Cursor)))
                {
                    colFlag1Button = Color.Green;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        score = 9;
                        flag = true; //turning off the collision
                        work1 = false; //can be activated once
                        //hiding the button
                        recFlag1Button.X = 0;
                        recFlag1Button.Y = 0;
                        recFlag1Button.Height = 0;
                        recFlag1Button.Width = 0;
                        scene = CurrentScene.Play;
                    }
                }
                else
                {
                    colFlag1Button = Color.White;
                }
                //Flag2Button
                if ((recFlag2Button.Intersects(Cursor)))
                {
                    colFlag2Button = Color.Green;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {                        
                        score = 19;
                        flag = true; //turning off the collision
                        work2 = false; //can be activated once
                        //hiding the button
                        recFlag2Button.X = 0;
                        recFlag2Button.Y = 0;
                        recFlag2Button.Height = 0;
                        recFlag2Button.Width = 0;
                        scene = CurrentScene.Play;
                    }
                }
                else
                {
                    colFlag2Button = Color.White;
                }
            }
            //WinScene
            else if (scene == CurrentScene.Win)
            {
                //QuitButton
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
            //HowToPlayScene
            else if (scene == CurrentScene.HowToPlay)
            {
                //StartButton
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
            //PlayScene
            else if (scene == CurrentScene.Play)
            {
                //MenuButton
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
            //MenuScene
            else if (scene == CurrentScene.Menu)
            {
                //QuitButton
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
                //PauseButton
                if (recPauseButton.Intersects(Cursor)&&uses==false)
                {
                    colPauseButton = Color.Yellow;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        PauseTime = true;
                        uses = true; //can be activated once
                        scene = CurrentScene.Play;
                    }
                }
                else
                {
                    colPauseButton = Color.White;
                }
                //ResumeButton
                if ((recResumeButton.Intersects(Cursor)))
                {
                    colResumeButton = Color.Green;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        PauseTime = false;
                        scene = CurrentScene.Play;
                    }
                }
                else
                {
                    colResumeButton = Color.White;
                }
                //StopButton
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
            Window.Title = "Crazy Digits";
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges();
            scene = CurrentScene.Start;
            base.Initialize();
            uses = false;
        }
        protected override void LoadContent() //loading textures
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadContentStart();
            LoadContentGame();
            LoadContentMenu();
            LoadContentLose();
            LoadContentWin();
            LoadContentHow();
            song = Content.Load<Song>("media/mainTheme");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
        }
        protected override void Update(GameTime gameTime) //activating methods
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (scene == CurrentScene.Start)
                UpdateStart();
            if (scene == CurrentScene.Play)
                if (PauseTime!=true) UpdateGame(); //can be paused
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
        protected override void Draw(GameTime gameTime) //drawing textures
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
