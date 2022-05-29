using Jogo.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo.Content.Sprites
{
    public class Enemy2 : aviao
    {
      //  public balas balass;
        private float _timer;
        static Random rand = new Random();
        public bool Morto = false;
        public Enemy2(Texture2D texture)
            : base(texture)
        {
            Position = new Vector2(Game1.Random.Next(700, Game1.ScreenWidth - _texture.Width), Game1.Random.Next(0, Game1.ScreenHeight - _texture.Height));

            lifes = 120;

            

        }
        public override void Update(GameTime gameTime, List<aviao> avioes, SoundEffect effect)
        {


            

            if (Rectangle.Bottom <= Game1.ScreenWidth)
            {
                Position.X -= speed / 2;

                if (Rectangle.Left <= 0)
                {
                    IsRemoved = true;
                    foreach (var nave in avioes)
                    {
                        nave.score = nave.score - 10;
                    }
                }

            }

            foreach (var aviao in avioes)
            {
                speed = 3;
                if (aviao is nave)
                {
                    if(level1.level == 1)
                    {
                        if (aviao.score >= 30 && aviao.score < 40) speed = Game1.Random.Next(2, 4);
                        if (aviao.score >= 40) speed = Game1.Random.Next(4, 7);
                    } 
                    if(level1.level ==2)
                    {
                        if (aviao.score >= 5 && aviao.score < 18) speed = Game1.Random.Next(1, 3);
                        if (aviao.score >= 18 && aviao.score < 40) speed = Game1.Random.Next(2, 4);
                        if (aviao.score >= 40 && aviao.score < 70) speed = Game1.Random.Next(3, 5);
                        if (aviao.score >= 70) speed = Game1.Random.Next(5, 8);
                    }
                   
                }




                if (aviao is Enemy2)
                    continue;
                {
                    if (aviao.Rectangle.Intersects(this.Rectangle))

                    {
                        foreach (var nave in avioes)
                        {
                            lifes--;
                            if(lifes == 0)
                            {
                                IsRemoved = true;
                                nave.score = nave.score + 3;
                            }
                           
                        }



                        if (aviao is nave)
                        {
                            var nave = aviao as nave;
                            nave.IsRemoved = true;
                            nave.Morto = true;


                        }
                    }
                }
            }
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            float k;
            k =(float)((rand.Next(2, 5)) / 10.0);
            if (_timer > k)
            {
                _timer = 0;
                int x, y;
                x = rand.Next(0, 30);
                y = rand.Next(0, 50);

                if (x < 19)
                {
                    Disparo(avioes, 1);
                    Sound.Shot.Play(0.2f, (float)rand.NextDouble(), 0);
                    x = rand.Next(0, 80);
                }

                if (y < 19)
                {
                    Disparo(avioes, 2);
                    Sound.Shot.Play(0.2f, (float)rand.NextDouble(), 0);
                    y = rand.Next(0, 80);
                }

                k = 0;
                

            }
            Direction = new Vector2(-1, 0);
        }

          private void Disparo(List<aviao> avioes, int a)
          {

            if(a == 1)
            {
                var Balas = balas.Clone() as balas;
                Balas.Direction = this.Direction;
                Balas.Position.X = this.Position.X - 60;
                Balas.Position.Y = this.Position.Y  -25;
                Balas.LinearVelocity = this.speed * 2;
                Balas.LifeSpan = 2f;
                Balas.Parent = this;
                Balas.fire = true;

                avioes.Add(Balas);
            }
            if (a == 2)
            {
                var Balas = balas.Clone() as balas;
                Balas.Direction = this.Direction;
                Balas.Position.X = this.Position.X - 60;
                Balas.Position.Y = this.Position.Y + 95;
                Balas.LinearVelocity = this.speed * 2;
                Balas.LifeSpan = 2f;
                Balas.Parent = this;
                Balas.fire = true;

                avioes.Add(Balas);
            }
               

        }  
    }



}
