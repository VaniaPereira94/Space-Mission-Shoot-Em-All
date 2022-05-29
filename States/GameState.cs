using Jogo.Content.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;


namespace Jogo.States
{
    public class GameState : State
    {
        static Random rand = new Random();
        public SoundEffect effect;
        
        public static Random Random;
        public List<aviao> _avioes;
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;
       
        private SpriteFont _font;
        private float _timer;
        private float _timer2;

        private bool _hasStarted = false;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            
            Restart();
        }


        public override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
        }

        private void Restart()
        {
            Sound.start.Play(0.2f, 0, 1);
            _font = _content.Load<SpriteFont>("Font");
            var navetexture = _content.Load<Texture2D>("nave");
            _backgroundtexture = _content.Load<Texture2D>("fundoo");
           

            _avioes = new List<aviao>()
            {

                new nave(navetexture)
                {
                    Position = new Vector2 (100, 100),
                    Origin = new Vector2(navetexture.Width / 2, navetexture.Height / 2),
                    balas = new balas(_content.Load<Texture2D>("bala")),               
        },
          
            };
            _hasStarted = false;

        }


        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _hasStarted = true;
                MediaPlayer.Resume();


            }

            if (!_hasStarted) return;

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
           _timer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;


            foreach (var aviao in _avioes.ToArray())
            {
                if (aviao is nave)
                {
                    if(level1.level == 1)
                    {
                        if (aviao.score >= 50)
                        {
                            MediaPlayer.Pause();
                            Sound.win.Play(0.2f, 0, 1);
                            _game.ChangeState(new Levelwinstate(_game, _graphicsDevice, _content));
                            level1.level = 2;
                        }
                        float a;
                        a = (float)(rand.Next(5, 9));
                        if (_timer2 > a && aviao.score >= 35)
                        {
                            _timer2 = 0;
                           
                            _avioes.Add(new Enemy2(_content.Load<Texture2D>("enemy2")) { balas = new balas(_content.Load<Texture2D>("balase")), });

                        }
                    }
                    if(level1.level == 2)
                    {
                        if (aviao.score >= 80)
                        {
                            _game.ChangeState(new WinState(_game, _graphicsDevice, _content));
                            
                        }
                        float d;
                        d = (float)(rand.Next(8, 11));
                        if (_timer2 > d && aviao.score >= 10)
                        {
                            _timer2 = 0;
                            _avioes.Add(new Enemy2(_content.Load<Texture2D>("enemy2")) { balas = new balas(_content.Load<Texture2D>("balase")), });
                        }
                    }
 
                }
                aviao.Update(gameTime, _avioes, null);

            }
            SpawnEnemy();
        }
  
        private void SpawnEnemy()
        {
            if(level1.level == 1)
            {
                float b;
                b = (float)(rand.Next(55, 85))/100;
                if (_timer > b)
                {
                   

                    _avioes.Add(new Enemy(_content.Load<Texture2D>("enemyyy")));
                    _timer = 0;

                }

            }
            if(level1.level == 2)
            {
                float c;
                c = (float)((rand.Next(95, 140)) / 100.0);
                if (_timer > c)
                {
                    _timer = 0;

                    _avioes.Add(new Enemy(_content.Load<Texture2D>("enemyyy")));
                }
            }
            
        }

        public override void PostUpdate(GameTime gameTime)
        {
         for (int i = 0; i < _avioes.Count; i++)
            {
                var sprite = _avioes[i];
                if (sprite.IsRemoved)
                {
                    _avioes.RemoveAt(i);
                    i--;
                }

                if (sprite is nave)
                {
                    var nave = sprite as nave;
                    if (nave.Morto)
                    {
                        MediaPlayer.Pause();
                        Sound.end.Play(0.2f, 0, 0);
                        Restart();
                    }
                }
            } 
        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            // TODO: Add your drawing code here
           
            float offset =   screen.X;
            offset = MathHelper.Clamp(offset, 0, 50000);

            Matrix transform = Matrix.CreateTranslation(offset, 0, 0);

            _spriteBatch.Begin(transformMatrix: transform );


            _spriteBatch.Draw(_backgroundtexture, Vector2.Zero, Color.White);


            _spriteBatch.End();

            _spriteBatch.Begin();

           

               foreach (var aviao in _avioes)
                   aviao.Draw(_spriteBatch);
            
            var fontY = 10;
               var i = 0;
            foreach (var aviao in _avioes)
            {
                if (aviao is nave)
                {
                    if(_hasStarted == false)
                    {
                        _spriteBatch.DrawString(_font, string.Format("PRESS SPACE TO START"), new Vector2(_graphicsDevice.Viewport.Width / 2 - _font.MeasureString("PRESS SPACE TO START").Length() / 2, _graphicsDevice.Viewport.Height/2), Color.White);
                    }
                    if(level1.level == 1)
                    _spriteBatch.DrawString(_font, string.Format("Score: {0} / 50", ((nave)aviao).score), new Vector2(10, fontY), Color.White);
                    if (level1.level == 2)
                    _spriteBatch.DrawString(_font, string.Format("Score: {0} / 80", ((nave)aviao).score), new Vector2(10, fontY), Color.White);
                }
            }




            _spriteBatch.End();
        }
    }
}
