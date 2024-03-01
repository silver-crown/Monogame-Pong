using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace monogame_Pong
{
    public class BallPhysics
    {
        private Vector2 ballStartPosition;
        // Initial direction of the ball
        private Vector2 ballDirection;
        private Ball _ball;
        private float startBallSpeed = 5f;
        private Paddle LeftPaddle, RightPaddle;

        private PongGame _game;
        public BallPhysics(PongGame game, Ball ball) {
            _game = game;
            _ball = ball;
        }

        public void Initialize() {
            LeftPaddle = _game.GetPaddles()[0];
            RightPaddle = _game.GetPaddles()[1];
            _ball.SetSpeed(startBallSpeed);
            ballStartPosition = new Vector2(PongGame.windowWidth / 2 - _ball.GetTexture().Width / 2, PongGame.windowHeight / 2 - _ball.GetTexture().Height / 2);
            _ball.SetPosition(ballStartPosition);
            ballDirection = new Vector2(1, 1); 
        }
        public void Update() {
            CalculateBallPhysics();
        }
        private void CalculateBallPhysics() {

            if (!_game.GetGameOverStatus()) {
                // Ball movement
                _ball.SetPosition(_ball.GetPosition() + ballDirection * _ball.GetSpeed());

                // Ball collision with top and bottom walls
                if (_ball.GetPosition().Y <= 0 || _ball.GetPosition().Y >= PongGame.windowHeight - _ball.GetTexture().Height)
                    ballDirection.Y *= -1;

                // Ball collision with paddles
                //left paddle
                if ((_ball.GetPosition().X <= LeftPaddle.GetPosition().X + LeftPaddle.GetTexture().Width / 2) && (_ball.GetPosition().Y >= LeftPaddle.GetPosition().Y) && (_ball.GetPosition().Y <= LeftPaddle.GetPosition().Y + LeftPaddle.GetTexture().Height)) {
                    ballDirection.X *= -1;
                    _ball.SetSpeed(_ball.GetSpeed() + 0.1f);
                    IncreasePaddleSpeeds();
                    _game.IncreasePlayerScore();
                }
                //right paddle
                if (_ball.GetPosition().X + _ball.GetTexture().Width / 2 >= RightPaddle.GetPosition().X - RightPaddle.GetTexture().Width && _ball.GetPosition().Y >= RightPaddle.GetPosition().Y && _ball.GetPosition().Y <= RightPaddle.GetPosition().Y + RightPaddle.GetTexture().Height) {
                    ballDirection.X *= -1;
                    _ball.SetSpeed(_ball.GetSpeed() + 0.1f);
                    IncreasePaddleSpeeds();
                    _game.IncreasePlayerScore();
                }

                if (_ball.GetPosition().X <= 0 - _ball.GetTexture().Width || _ball.GetPosition().X >= PongGame.windowWidth) {
                    _game.SetGameOverStatus(true);
                }
            }
            else {
                _ball.SetPosition(ballStartPosition);
                _ball.SetSpeed(startBallSpeed);
                ResetPaddleSpeeds();
            }

        }
        private void IncreasePaddleSpeeds() {
            LeftPaddle.SetSpeed(LeftPaddle.GetSpeed() + 0.1f);
            RightPaddle.SetSpeed(RightPaddle.GetSpeed() + 0.1f);
        }
        private void ResetPaddleSpeeds() {
            LeftPaddle.SetSpeed(startBallSpeed);
            RightPaddle.SetSpeed(startBallSpeed);
        }

    }
}
