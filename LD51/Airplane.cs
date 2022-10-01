using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD51
{
    internal class Airplane : GameObject
    {
        private MonoGameSetup game;
        private Texture2D airplaneSprite;

        public Vector2 pos;
        private Vector2 velocity;

        public Airplane(MonoGameSetup game)
        {
            this.game = game;
            this.LoadContent();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void LoadContent()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
