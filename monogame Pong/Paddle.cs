using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_Pong
{
    public class Paddle
    {
        private Texture2D _texture;
        private float _paddleSpeed;
        private Vector2 _position;
        public Paddle(float speed) {
            _paddleSpeed = speed;
        }
        public void LoadContent(ContentManager content) {
            _texture = content.Load<Texture2D>("paddle");
        }
        public void SetPosition(Vector2 position) => _position = position;
        public void SetYPosition(float y) => _position.Y = y;
        public Vector2 GetPosition() => _position;
        public Texture2D GetTexture() => _texture;
        public float GetSpeed() => _paddleSpeed;
        public float SetSpeed(float speed) => _paddleSpeed = speed; 
    }
}
