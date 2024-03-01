using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace monogame_Pong
{
    internal class RenderManager
    {
        private ContentManager _content;
        private PongGame _game;
        private Paddle LeftPaddle, RightPaddle;
        public RenderManager(PongGame game, ContentManager content) {
            _game = game;
            _content = content;
            LeftPaddle = _game.GetPaddles()[0];
            RightPaddle = _game.GetPaddles()[1];
        }
        public void Draw(SpriteBatch _spriteBatch) {
            _spriteBatch.Begin();
            DrawPaddles(_spriteBatch);
            DrawBall(_spriteBatch);
            DrawText(_spriteBatch);
            _spriteBatch.End();
        }
        private void DrawPaddles(SpriteBatch _spriteBatch) {
            _spriteBatch.Draw(LeftPaddle.GetTexture(), LeftPaddle.GetPosition(), Color.White);
            _spriteBatch.Draw(RightPaddle.GetTexture(), RightPaddle.GetPosition(), Color.White);
        }
        private void DrawBall(SpriteBatch _spriteBatch) {
            _spriteBatch.Draw(_game.GetBall().GetTexture(), _game.GetBall().GetPosition(), Color.White);
        }
        private void DrawText(SpriteBatch _spriteBatch) {

            _spriteBatch.DrawString(
                _content.Load<SpriteFont>("default font"),
                $"Player Score: {_game.GetPlayerScore()}",
                new Vector2(10, 10),
                Color.White);
            _spriteBatch.DrawString(
              _content.Load<SpriteFont>("default font"),
              $"Ball Speed: {_game.GetBall().GetSpeed()}",
              new Vector2(200, 10),
              Color.White);
            if (_game.GetGameOverStatus()) {
                _spriteBatch.DrawString(
                    _content.Load<SpriteFont>("default font"),
                    "Game Over!",
                    new Vector2(PongGame.windowWidth / 2 - 100, PongGame.windowHeight / 2 - 50),
                    Color.White);
            }


        }
    }
}
