using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        Texture2D texStartButton, texHowButton;
        Rectangle recStartButton, recHowButton;
        Color colStartButton = Color.White, colHowButton = Color.White;
        private SpriteFont Title;
        Vector2 vecTitle;
        private void LoadContentStart()
        {
            texStartButton = Content.Load<Texture2D>("media/start");
            texHowButton = Content.Load<Texture2D>("media/HowToPlay");
            texBackground = Content.Load<Texture2D>("media/background");
            Title = Content.Load<SpriteFont>("EndWin");
        }
        private void DrawStart()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texBackground, recBackground, colBackground);
            _spriteBatch.DrawString(Title, "Crazy Digits", vecTitle, Color.DarkBlue);
            _spriteBatch.Draw(texStartButton, recStartButton, colStartButton);
            _spriteBatch.Draw(texHowButton, recHowButton, colHowButton);
            _spriteBatch.Draw(texQuitButton, recQuitButton, colQuitButton);
            _spriteBatch.End();
        }
        private void UpdateStart()
        {
            //location & dimensions
            //Background
            recBackground.X = 0;
            recBackground.Y = 0;
            recBackground.Height = 768;
            recBackground.Width = 1024;
            //TextTitle
            vecTitle.X = 35;
            vecTitle.Y = 60;
            //StartButton
            recStartButton.X = GraphicsDevice.Viewport.Width / 2 - recStartButton.Size.X / 2;
            recStartButton.Y = GraphicsDevice.Viewport.Height / 2 - recStartButton.Size.Y / 2 + 25;
            recStartButton.Height = GraphicsDevice.Viewport.Height / 6;
            recStartButton.Width = GraphicsDevice.Viewport.Width / 3;
            //HowToPlayButton
            recHowButton.X = GraphicsDevice.Viewport.Width / 2 - recHowButton.Size.X / 2;
            recHowButton.Y = GraphicsDevice.Viewport.Height / 2 - recHowButton.Size.Y / 2 + 215 - 50;
            recHowButton.Height = recStartButton.Height * 2 / 3;
            recHowButton.Width = recStartButton.Width * 2 / 3;
            //QuitButton
            recQuitButton.X = GraphicsDevice.Viewport.Width / 2 - recQuitButton.Size.X / 2;
            recQuitButton.Y = recStartButton.Y + 275;
            recQuitButton.Height = recStartButton.Height * 2 / 3;
            recQuitButton.Width = recStartButton.Width * 2 / 3;
            //methods
            UpdateCursorPosition();
            ButtonEvents();
        }
    }
}
