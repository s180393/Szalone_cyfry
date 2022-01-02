using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        Vector2 vecHow;
        private SpriteFont HowToPlay;
        private void LoadContentHow()
        {
 
            texBackground = Content.Load<Texture2D>("media/background");
            HowToPlay = Content.Load<SpriteFont>("HowToPlay");
        }

        private void DrawHow()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texBackground, recBackground, colBackground);
            _spriteBatch.DrawString(HowToPlay, "Kwadrat musi ominac przeszkode. \nNalezy nacisnac klawisz odpowiadajacy " +
                "\ncyfrze wyswietlonej w srodku kwadrata. \nGra konczy sie po zdobyciu 30 punktow. \n\nPOWODZENIA!", vecHow, Color.Black);
            _spriteBatch.Draw(texStartButton, recStartButton, colStartButton);
            _spriteBatch.End();
        }
        private void UpdateHow()
        {
            //Background
            recBackground.X = 0;
            recBackground.Y = 0;
            recBackground.Height = 768;
            recBackground.Width = 1024;
            //Text
            vecHow.X = 84;
            vecHow.Y = GraphicsDevice.Viewport.Height / 8;
            //Start
            recStartButton.X = 620;
            recStartButton.Y = 536;
            recStartButton.Height = 125;
            recStartButton.Width = 250;
            UpdateCursorPosition();
            ButtonEvents();
        }
    }
}
