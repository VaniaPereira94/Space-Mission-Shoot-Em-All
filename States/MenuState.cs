using Jogo.Content.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo.States
{
    public class MenuState : State
    {
        private List<Component> _components;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            _font = _content.Load<SpriteFont>("Font");
            _backgroundtexture = _content.Load<Texture2D>("fundoo");
            var newGameButton = new Button(buttonTexture, _font)
            {
                Position = new Vector2(300, 200),
                Text = "Start Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var quitGameButton = new Button(buttonTexture, _font)
            {
                Position = new Vector2(300, 300),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
      {
        newGameButton,
        quitGameButton,
      };
        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            float offset = screen.X;
            offset = MathHelper.Clamp(offset, 0, 50000);

            Matrix transform = Matrix.CreateTranslation(offset, 0, 0);

            _spriteBatch.Begin(transformMatrix: transform);


            _spriteBatch.Draw(_backgroundtexture, Microsoft.Xna.Framework.Vector2.Zero, Color.White);


            _spriteBatch.End();
            _spriteBatch.Begin();
            
            _spriteBatch.DrawString(_font, string.Format("Space mission: Shoot em all"), new Vector2(_graphicsDevice.Viewport.Width / 2 - _font.MeasureString("Space mission: Shoot em all").Length() , _graphicsDevice.Viewport.Height / 4), Color.White,0, Vector2.Zero,2,0,0);
            _spriteBatch.End();


            _spriteBatch.Begin();

            


            foreach (var component in _components)
                component.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            MediaPlayer.Pause();
            
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
            level1.level = 1;
        }

        public override void PostUpdate(GameTime gameTime)
        {
          
        }

        public override void Update(GameTime gameTime)
        {




            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void LoadContent()
        {
            throw new NotImplementedException();
        }
    }
}
