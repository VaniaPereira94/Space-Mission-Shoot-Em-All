using Jogo.Content.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Jogo.States
{
    public class WinState : State
    {
        private List<Component> _components;
        private SpriteBatch _spriteBatch;

        public WinState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Font");
            _backgroundtexture = _content.Load<Texture2D>("fundoo");
            var Win = new Button(buttonTexture, buttonFont)
            {
                Position = new Microsoft.Xna.Framework.Vector2(300, 200),
                Text = "YOU WIN",
            };

            Win.Click += QuitGameButton_Click;



            _components = new List<Component>()
      {
        Win,
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

            foreach (var component in _components)
                component.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }


        public override void LoadContent()
        {
            throw new NotImplementedException();
        }
    }
}
