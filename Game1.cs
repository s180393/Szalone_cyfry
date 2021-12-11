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
        CurrentScene scene;

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
                        scene = CurrentScene.Play;
                    }
                }
                else
                {
                    colStartButton = Color.White;
                }
                if ((recQuitButton.Intersects(Cursor)))
                {
                    colQuitButton = Color.Green;
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
                if ((recQuitButton.Intersects(Cursor)))
                {
                    colQuitButton = Color.Green;
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        //Exit();
                        scene = CurrentScene.Play;
                    }
                }
                else
                {
                    colQuitButton = Color.White;
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
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadContentStart();
            LoadContentGame();
            LoadContentMenu();
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (scene == CurrentScene.Start)
                UpdateStart();
            if (scene == CurrentScene.Play)
                UpdateGame();
            if (scene == CurrentScene.Menu)
                UpdateMenu();

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

            base.Draw(gameTime);
        }
    }
}
