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
    public class Ball
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed;

        public void LoadContent(ContentManager content) {
            _texture = content.Load<Texture2D>("ball");
        }
        public void SetPosition(Vector2 position) => _position = position;
        public Vector2 GetPosition() => _position;
        public void SetSpeed(float speed) => _speed = speed;
        public float GetSpeed() => _speed;  
        public Texture2D GetTexture() => _texture;  
    }
}
