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

namespace Jogo.Content.Sprites
{
   public class Enemy : aviao
    {
        
        
        public Enemy(Texture2D texture)
            :base(texture)
        {
            Position = new Vector2(Game1.Random.Next(700, Game1.ScreenWidth - _texture.Width), Game1.Random.Next(0, Game1.ScreenHeight - _texture.Height));
              
        }
        public override void Update(GameTime gameTime, List<aviao> avioes, SoundEffect effect)
        {

            if (Rectangle.Bottom <= Game1.ScreenWidth)
            {
                Position.X -= speed/2 ;

                if(Rectangle.Left <= 0)
                {
                    IsRemoved = true;
                    foreach(var nave in avioes)
                    {
                        nave.score= nave.score -2;
                    }
                }

            }

        foreach(var aviao in avioes)
            {
                if(aviao  is nave)
                {
                    speed = 3;
                    if (level1.level == 1)
                    {
                        if (aviao.score < 10) speed = Game1.Random.Next(5, 11);
                        if (aviao.score >= 10 && aviao.score < 20) speed = Game1.Random.Next(8, 14);
                        if (aviao.score >= 20 && aviao.score < 25) speed = Game1.Random.Next(10, 18);
                        if (aviao.score >= 25 && aviao.score < 30) speed = Game1.Random.Next(6, 16);
                        if (aviao.score >= 30 && aviao.score < 35) speed = Game1.Random.Next(7, 12);
                        if (aviao.score >= 35 && aviao.score < 40) speed = Game1.Random.Next(6, 13);
                        if (aviao.score >= 40 && aviao.score < 45) speed = Game1.Random.Next(8, 12);
                        if (aviao.score >= 45) speed = Game1.Random.Next(16, 20);

                    }

                    if(level1.level == 2)
                    {
                        if (aviao.score < 10) speed = Game1.Random.Next(1, 20);
                        if (aviao.score >= 10 && aviao.score < 20) speed = Game1.Random.Next(3, 10);
                        if (aviao.score >= 20 && aviao.score < 35) speed = Game1.Random.Next(5, 12);
                        if (aviao.score >= 35 && aviao.score < 50) speed = Game1.Random.Next(6, 14);
                        if (aviao.score >= 50 && aviao.score < 60) speed = Game1.Random.Next(4, 18);
                        if (aviao.score >= 60 && aviao.score < 67) speed = Game1.Random.Next(5, 19);
                        if (aviao.score >= 67 && aviao.score < 75) speed = Game1.Random.Next(11, 15);
                        if (aviao.score >= 75) speed = Game1.Random.Next(13, 21);
                    }

                }




                if (aviao is Enemy)      
                continue;
                {     
                    if (aviao.Rectangle.Intersects(this.Rectangle) )
                        
                    {
                        foreach (var nave in avioes)
                        {
                                  
                                IsRemoved = true;
                                nave.score++;
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
                
        }

    }
}
