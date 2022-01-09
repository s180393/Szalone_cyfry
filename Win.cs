using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        Vector2 vecEndWin;
        private SpriteFont EndWin;
        private void LoadContentWin()
        {
            EndScore = Content.Load<SpriteFont>("EndScore");
            EndWin = Content.Load<SpriteFont>("EndWin");
            texBackground = Content.Load<Texture2D>("media/background");
        }
        private void DrawWin()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texBackground, recBackground, colBackground);
            _spriteBatch.DrawString(EndScore, "Score: " + score, vecEndScore, Color.Black);
            _spriteBatch.DrawString(EndWin, "You Win! :)", vecEndWin, Color.Black);
            _spriteBatch.Draw(texQuitButton, recQuitButton, colQuitButton);
            _spriteBatch.End();
        }
        private void UpdateWin()
        {
            //location & dimensions
            //Background
            recBackground.X = 0;
            recBackground.Y = 0;
            recBackground.Height = 768;
            recBackground.Width = 1024;
            //TextWin
            vecEndWin.X = 104;
            vecEndWin.Y = GraphicsDevice.Viewport.Height / 8;
            //TextScore
            vecEndScore.X = 256 + 108;
            vecEndScore.Y = GraphicsDevice.Viewport.Height / 2;
            //QuitButton
            recQuitButton.X = GraphicsDevice.Viewport.Width / 2 - recQuitButton.Width / 2;
            recQuitButton.Y = 576;
            recQuitButton.Height = 125;
            recQuitButton.Width = 250;
            //methods
            UpdateCursorPosition();
            ButtonEvents();
        }
    }
}
