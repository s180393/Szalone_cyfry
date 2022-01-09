using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        Texture2D texStopButton, texPauseButton, texQuitButton, texResumeButton;
        Rectangle recStopButton, recPauseButton, recQuitButton, recResumeButton;
        Color colStopButton = Color.White, colPauseButton = Color.White, colQuitButton = Color.White, colResumeButton = Color.White;
        private void LoadContentMenu()
        {
            texStopButton = Content.Load<Texture2D>("media/stop");
            texPauseButton = Content.Load<Texture2D>("media/pause");
            texQuitButton = Content.Load<Texture2D>("media/quit");
            texResumeButton = Content.Load<Texture2D>("media/resume");
            texBackground = Content.Load<Texture2D>("media/background");
        }
        private void DrawMenu()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texBackground, recBackground, colBackground);
            _spriteBatch.Draw(texStopButton, recStopButton, colStopButton);
            if (PauseTime == false && uses == false) //PauseButton can be displayed once
            {
                _spriteBatch.Draw(texPauseButton, recPauseButton, colPauseButton);
            }
            _spriteBatch.Draw(texQuitButton, recQuitButton, colQuitButton);
            if (PauseTime == true) //ResumeButton can be displayed when PauseButton can't
            {
                _spriteBatch.Draw(texResumeButton, recResumeButton, colResumeButton);
            }
            _spriteBatch.End();
            //methods
            UpdateCursorPosition();
            ButtonEvents();
        }
        private void UpdateMenu()
        {
            //location & dimensions
            //Background
            recBackground.X = 0;
            recBackground.Y = 0;
            recBackground.Height = 768;
            recBackground.Width = 1024;
            //StopButton
            recStopButton.X = 69;
            recStopButton.Y = 256 - 256 / 4;
            recStopButton.Height = 125;
            recStopButton.Width = 250;
            //PauseButton
            recPauseButton.Width = 0;
            recPauseButton.Height = 0;
            recPauseButton.X = 0;
            recPauseButton.Y = 0;
            if (PauseTime == false) 
            {               
                if (uses == false)
                {
                    //PauseButton
                    recPauseButton.X = 68 + 250 + 69;
                    recPauseButton.Y = 256 - 256 / 4;
                    recPauseButton.Height = 125;
                    recPauseButton.Width = 250;
                }  
            }
            else if (PauseTime == true)
            {
                //ResumeButton
                recResumeButton.X = 68 + 250 + 69;
                recResumeButton.Y = 256 - 256 / 4;
                recResumeButton.Height = 125;
                recResumeButton.Width = 250;
                uses = true;
            }
            //QuitButton
            recQuitButton.X = 69+68+68+250+250;
            recQuitButton.Y = 256-256/4;
            recQuitButton.Height = 125;
            recQuitButton.Width = 250;
        }
    }
}
