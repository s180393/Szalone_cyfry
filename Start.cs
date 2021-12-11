using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        Texture2D texStartButton;
        Rectangle recStartButton;
        Color colStartButton = Color.White;
        
        

        private void LoadContentStart()
        {
            texStartButton = Content.Load<Texture2D>("media/start");
        }

        private void DrawStart()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texStartButton, recStartButton, colStartButton);
            _spriteBatch.Draw(texQuitButton, recQuitButton, colQuitButton);
            _spriteBatch.End();
        }
        private void UpdateStart()
        {
            recStartButton.X = GraphicsDevice.Viewport.Width / 2 - recStartButton.Size.X / 2;
            recStartButton.Y = GraphicsDevice.Viewport.Height / 2 - recStartButton.Size.Y / 2;
            recStartButton.Height = GraphicsDevice.Viewport.Height / 6;
            recStartButton.Width = GraphicsDevice.Viewport.Width / 3;
            //Quit
            recQuitButton.X = GraphicsDevice.Viewport.Width / 2 - recQuitButton.Size.X/2;
            recQuitButton.Y = recStartButton.Y + 150;
            recQuitButton.Height = recStartButton.Height *2/3;
            recQuitButton.Width = recStartButton.Width *2/3;

            UpdateCursorPosition();
            ButtonEvents();
        }
    }
}
