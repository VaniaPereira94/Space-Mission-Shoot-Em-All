using Jogo.Content.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Jogo.States;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Jogo
{
    static class level1
    {
        public static int level;
    }
    public class Game1 : Game
    {

        //sound


        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static Random Random;
        public List<aviao> _avioes;
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        private SpriteFont _font;
        private float _timer;
        private bool _hasStarted = false;

        private State _currentState;
        private State _nextState;

        public void ChangeState(State state)
        {
            _nextState = state;
        }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            IsMouseVisible = true;
            Random = new Random();

            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.01f;
            MediaPlayer.Play(Sound.Music);
     
        }

        protected override void LoadContent()
        {
         
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentState = new MenuState(this, GraphicsDevice, Content);
            Sound.Load(Content);
            
          

            // TODO: use this.Content to load your game content here
        }

   

        protected override void Update(GameTime gameTime)
        {
            if(_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }



            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);


       

            // TODO: Add your update logic here

            base.Update(gameTime);
        }




        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _currentState.Draw(gameTime, _spriteBatch);
            base.Draw(gameTime);
        }
    }
}
