using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LD51
{
    internal class Score : GameObject
    {
        public int score = 0;

        private readonly MonoGameSetup game;
        private readonly Texture2D scoreSprite;

        public Score(MonoGameSetup game)
        {
            this.game = game;
            this.LoadContent();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawString(,playerScore.ToString(), new Vector2(10, 10), Color.White);
        }

        public void LoadContent()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            this.score += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}
