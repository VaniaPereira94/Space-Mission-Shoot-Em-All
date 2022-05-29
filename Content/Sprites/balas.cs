using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo.Content.Sprites
{
    public class balas : aviao
    {
        private float _timer;
        public SoundEffect effect;

        public balas(Texture2D texture)
            : base(texture)
        {
            
        }

        public override void Update(GameTime gameTime, List<aviao> avioes, SoundEffect effect)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(_timer > LifeSpan || IsRemoved == true)
            {
                fire = false;
                IsRemoved = true;
            }
            Position += Direction * LinearVelocity;

            foreach (var aviao in avioes)
            {
                if (aviao is balas)
                    continue;
                if (aviao.Rectangle.Intersects(this.Rectangle))
                {
                    _timer += _timer + 1;
                    score++;
                    if (_timer == _timer + 1)
                    {
                        
                        IsRemoved = true;
                        fire = false;
                       
                    }
                   
                }

            }

        }
    }
}
