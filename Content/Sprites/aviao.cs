using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Jogo.Content.Sprites
{

    //Icloneable para usar as balas umas as outras sem afetar o original, criar um clone 
   public class aviao : ICloneable   
    {
        protected Texture2D _texture;
        protected KeyboardState currentKey;
        protected KeyboardState previousKey;
        public int score;
        public Vector2 Position;
        public Vector2 Origin;
        public Vector2 Direction;
        public Vector2 Velocity;
        public float LinearVelocity = 3f;
        public aviao Parent;
        public float LifeSpan = 0f;
        public bool IsRemoved = false;
        public float speed;
        public bool fire = true;
        public int lifes;
        public balas balas;
        
        
        
        



        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }


        public aviao(Texture2D texture)
        {
            _texture = texture;
            
        }

        public virtual void Update(GameTime gameTime, List<aviao> avioes, SoundEffect effect) 
        {
       
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Microsoft.Xna.Framework.Color.White, 0, Origin, 1, SpriteEffects.None, 0);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
