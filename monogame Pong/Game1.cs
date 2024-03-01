using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_Pong
{
    public class PongGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public const int windowWidth = 1024;
        public const int windowHeight = 768;

        private int playerScore = 0;
        private bool isGameOver = false;

        public bool GetGameOverStatus() => isGameOver;
        public bool SetGameOverStatus(bool status) => isGameOver = status;
        public void ResetPlayerScore() => playerScore = 0;
        public void IncreasePlayerScore() => playerScore ++;
        public int GetPlayerScore() => playerScore;

        private InputManager _InputManager;
        private BallPhysics _BallPhysics;
        private RenderManager _RenderManager;
        private SoundManager _soundManager;
        private Paddle[] _paddles;
        private Ball _ball;
        private float paddleSpeed = 5f;
        public Ball GetBall() => _ball;
        public SoundManager GetSoundManager() => _soundManager;

        //Position 0 refering to the left paddle and position 1 refering to the right paddle
        public Paddle[] GetPaddles() => _paddles;
        public PongGame() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            // Set the window size based on the board size and block size
            _graphics.PreferredBackBufferWidth = (int)(windowWidth);
            _graphics.PreferredBackBufferHeight = (int)(windowHeight);
        }

        protected override void Initialize() {
            _ball = new Ball();
            _paddles = new Paddle[2];
            for (int i = 0; i < _paddles.Length; i++) {
                _paddles[i] = new Paddle(paddleSpeed);
            }
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _ball.LoadContent(Content);
            foreach (var paddle in _paddles) {
                paddle.LoadContent(Content);
            }
            _InputManager = new InputManager(this);
            _InputManager.Initialize(Content);
            _BallPhysics = new BallPhysics(this, _ball);
            _BallPhysics.Initialize();
            _RenderManager = new RenderManager(this, Content);
            _soundManager = new SoundManager();
            _soundManager.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime) {
            _InputManager.KeyboardInput(Content);
            _BallPhysics.Update();
                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            _RenderManager.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}