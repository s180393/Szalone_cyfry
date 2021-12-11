using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        Texture2D texStopButton, texPauseButton, texQuitButton;
        Rectangle recStopButton, recPauseButton, recQuitButton;
        Color colStopButton = Color.White, colPauseButton = Color.White, colQuitButton = Color.White;

        private void LoadContentMenu()
        {
            texStopButton = Content.Load<Texture2D>("media/stop");
            texPauseButton = Content.Load<Texture2D>("media/pause");
            texQuitButton = Content.Load<Texture2D>("media/quit");
        }

        private void DrawMenu()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texStopButton, recStopButton, colStopButton);
            _spriteBatch.Draw(texPauseButton, recPauseButton, colPauseButton);
            _spriteBatch.Draw(texQuitButton, recQuitButton, colQuitButton);
            _spriteBatch.End();
        }
        private void UpdateMenu()
        {
            //Stop
            recStopButton.X = 69;
            recStopButton.Y = 256 - 256/ 4;
            recStopButton.Height = 125;
            recStopButton.Width = 250;
            //Pause
            recPauseButton.X = 68+250+69;
            recPauseButton.Y = 256 - 256/ 4;
            recPauseButton.Height = 125;
            recPauseButton.Width = 250;
            //Quit
            recQuitButton.X = 69+68+68+250+250;
            recQuitButton.Y = 256-256/4;
            recQuitButton.Height = 125;
            recQuitButton.Width = 250;

            UpdateCursorPosition();
            ButtonEvents();
        }
    }
}
