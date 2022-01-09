using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SzaloneCyfry
{
    public partial class Game1 : Game
    {
        Vector2 vecEndScore, vecEndLose;
        private SpriteFont EndScore, EndLose;
        Rectangle recFlag1Button, recFlag2Button;
        Color colFlag1Button = Color.White, colFlag2Button = Color.White;
        Texture2D texFlag1Button, texFlag2Button;
        bool work1 = true, work2 = true; //flags can be activated once
        bool flag; //for controling the collision
        private void LoadContentLose()
        {
            EndScore = Content.Load<SpriteFont>("EndScore");
            EndLose = Content.Load<SpriteFont>("EndLose");
            texFlag1Button = Content.Load<Texture2D>("media/flag1");
            texFlag2Button = Content.Load<Texture2D>("media/flag2");
            texBackground = Content.Load<Texture2D>("media/background");
        }
        private void DrawLose()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texBackground, recBackground, colBackground);
            _spriteBatch.DrawString(EndScore, "Score: " + score, vecEndScore, Color.Black);
            _spriteBatch.DrawString(EndLose, "You Lose! :(", vecEndLose, Color.Black);
            _spriteBatch.Draw(texQuitButton, recQuitButton, colQuitButton);
            //Flags
            if (score >= 10 && score < 20 && work1 == true)
            {
                _spriteBatch.Draw(texFlag1Button, recFlag1Button, colFlag1Button);
            }
            else if (score >= 20 && work2==true)
            {
                _spriteBatch.Draw(texFlag2Button, recFlag2Button, colFlag2Button);
            }
            _spriteBatch.End();
        }
        private void UpdateLose()
        {
            //location & dimensions
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
            //Flag1
            if (score >= 10 && score < 20 && work1 == true)
            {
                recFlag1Button.X = 192 - recFlag1Button.Width / 2;
                recFlag1Button.Y = 576;
                recFlag1Button.Height = 125;
                recFlag1Button.Width = 250;
            }
            //Flag2
            if (score >= 20 && work2 == true)
            {
                recFlag2Button.X = 832 - recFlag2Button.Width / 2;
                recFlag2Button.Y = 576;
                recFlag2Button.Height = 125;
                recFlag2Button.Width = 250;
            }
            //methods
            UpdateCursorPosition();
            ButtonEvents();
        }
    }
}
