using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_Pong
{
    public class SoundManager
    {

        public SoundEffect zoinks;
        public SoundEffect rehehehe;

        public void LoadContent(ContentManager content) {
            zoinks = content.Load<SoundEffect>("zoinks");
            rehehehe = content.Load<SoundEffect>("rehehehe");
        }
        public void playSoundEffect(SoundEffect soundEffect) {
            soundEffect.Play(volume: 1f, pitch: 0.0f, pan: 0.0f);
        }

    }
}
