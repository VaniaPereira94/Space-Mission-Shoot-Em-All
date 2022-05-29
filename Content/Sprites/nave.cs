using Jogo.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media ;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo.Content.Sprites
{
    public class nave : aviao
    {
       // public balas balas;
        private float _timer; 
        private float _timer2;
        static Random rand = new Random();
        
        public bool Morto = false;
        public nave(Texture2D texture)
             : base(texture)
        {
            
            
        }

        public override void Update(GameTime gameTime, List<aviao> avioes, SoundEffect effect)
        {
            Mover(avioes, gameTime);

            
            foreach (var aviao in avioes)
            {
                if (aviao is nave)
                    continue;
               if (aviao.Rectangle.Intersects(this.Rectangle))
                {
                    
                    this.Morto = true;
                    this.score = 0;
                    
                   
                }
            }
            
            Position += Velocity;
          Velocity = Vector2.Zero;
        }

        private void Mover(List<aviao> avioes, GameTime gameTime)
        {
           
            _timer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;
            previousKey = currentKey;
            currentKey = Keyboard.GetState();

            float hacc = (float)((4 * _timer2)/500);
            float vacc = (float)((7 * _timer2) / 500);

            if ((currentKey.IsKeyDown(Keys.A)) || (currentKey.IsKeyDown(Keys.Left)))
            {
                Velocity.X = Velocity.X - (LinearVelocity / 2) - hacc;
            }
            if (currentKey.IsKeyDown(Keys.D) || (currentKey.IsKeyDown(Keys.Right)))
            {
                Velocity.X = Velocity.X + (LinearVelocity / 2) + hacc;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) || (currentKey.IsKeyDown(Keys.Up)))
            {
                Velocity.Y = (float)(Velocity.Y - LinearVelocity - vacc - 0.5);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || (currentKey.IsKeyDown(Keys.Down)))
            {
                Velocity.Y = (float)(Velocity.Y + LinearVelocity + vacc + 0.5);
            }
            

            Position = Vector2.Clamp(Position, new Vector2(0, 0), new Vector2(Game1.ScreenWidth - this.Rectangle.Width, Game1.ScreenHeight - this.Rectangle.Height));

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentKey.IsKeyDown(Keys.Space) && previousKey.IsKeyUp(Keys.Space) && _timer > 0.2f)
            {
                _timer = 0;
                Disparo(avioes);
               
               Sound.Shot.Play(0.2f, (float)rand.NextDouble(), 0);

            }

            Direction = new Vector2(1, 0);
        }

        private void Disparo(List<aviao> avioes)
        {
            
             var Balas = balas.Clone() as balas;
            Balas.Direction = this.Direction;
            Balas.Position.X = this.Position.X +75 ;
            Balas.Position.Y = this.Position.Y -10 ;
            Balas.LinearVelocity = this.LinearVelocity * 3;
            Balas.LifeSpan = 2f;
            Balas.Parent = this;
            Balas.fire = true;

            avioes.Add(Balas);
        }
    }
    }
