using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        Vector2 vecEndScore, vecEndLose;
        private SpriteFont EndScore, EndLose;
        private void LoadContentLose()
        {
            EndScore = Content.Load<SpriteFont>("EndScore");
            EndLose = Content.Load<SpriteFont>("EndLose");
            texBackground = Content.Load<Texture2D>("media/background");

        }

        private void DrawLose()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texBackground, recBackground, colBackground);
            _spriteBatch.DrawString(EndScore, "Score: " + score, vecEndScore, Color.Black);
            _spriteBatch.DrawString(EndLose, "You Lose! :(", vecEndLose, Color.Black);
            _spriteBatch.Draw(texQuitButton, recQuitButton, colQuitButton);
            _spriteBatch.End();
        }
        private void UpdateLose()
        {
            //Background
            recBackground.X = 0;
            recBackground.Y = 0;
            recBackground.Height = 768;
            recBackground.Width = 1024;
            //TextLose
            vecEndLose.X = 84;
            vecEndLose.Y = GraphicsDevice.Viewport.Height / 8;
            //TextScore
            vecEndScore.X = 256+108;
            vecEndScore.Y = GraphicsDevice.Viewport.Height/2;
            //Quit
            recQuitButton.X = GraphicsDevice.Viewport.Width/2 - recQuitButton.Width / 2;
            recQuitButton.Y = 576;
            recQuitButton.Height = 125;
            recQuitButton.Width = 250;
            UpdateCursorPosition();
            ButtonEvents();
        }
    }
}
