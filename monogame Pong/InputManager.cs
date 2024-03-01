using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace monogame_Pong
{
    public class InputManager
    {
        private PongGame _game;
        private Vector2 paddlePosition;
        private Vector2 paddle2Position;

        private Paddle LeftPaddle, RightPaddle;
        public InputManager(PongGame game) {
            _game = game;
            LeftPaddle = _game.GetPaddles()[0];
            RightPaddle = _game.GetPaddles()[1];
        }
        public void Initialize(ContentManager content) {
            LeftPaddle.SetPosition(new Vector2(10, PongGame.windowHeight / 2 - LeftPaddle.GetTexture().Height / 2));
            _game.GetPaddles()[1].SetPosition(new Vector2(PongGame.windowWidth - 10, PongGame.windowHeight / 2 - RightPaddle.GetTexture().Height / 2));
        }

        public void KeyboardInput(ContentManager content) {
            //only lets the player control the paddles if game over is false
            if (!_game.GetGameOverStatus()) {
                ControlPaddle();
            }
            else {
                ResetGame();
            }
        }
        private void ControlPaddle() {
            var keyboardState = Keyboard.GetState();
            // Paddle movement
            if (keyboardState.IsKeyDown(Keys.W) && LeftPaddle.GetPosition().Y > 0) {
                LeftPaddle.SetYPosition(LeftPaddle.GetPosition().Y - LeftPaddle.GetSpeed());
            }

            if (keyboardState.IsKeyDown(Keys.S) && LeftPaddle.GetPosition().Y < PongGame.windowHeight - LeftPaddle.GetTexture().Height) {
                LeftPaddle.SetYPosition(LeftPaddle.GetPosition().Y + LeftPaddle.GetSpeed());
            }

            if (keyboardState.IsKeyDown(Keys.Up) && RightPaddle.GetPosition().Y > 0) {
                RightPaddle.SetYPosition(RightPaddle.GetPosition().Y - RightPaddle.GetSpeed());
            }

            if (keyboardState.IsKeyDown(Keys.Down) && RightPaddle.GetPosition().Y < PongGame.windowHeight - RightPaddle.GetTexture().Height) {
                RightPaddle.SetYPosition(RightPaddle.GetPosition().Y + RightPaddle.GetSpeed());
            }

        }
        private void ResetGame() {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Enter) && _game.GetGameOverStatus()) {
                _game.SetGameOverStatus(false);
                _game.GetSoundManager().playSoundEffect(_game.GetSoundManager().rehehehe);
                _game.ResetPlayerScore();
            }
        }
    }
}
