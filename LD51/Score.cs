using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LD51
{
    public class Score : GameObject
    {
        public int score = 0;

        private readonly MonoGameSetup game;
        private SpriteFont font;

        public Score(MonoGameSetup game)
        {
            this.game = game;
            this.LoadContent();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.score.ToString(), new Vector2(5, 5), Color.White);
        }

        public void LoadContent()
        {
            this.font = this.game.Content.Load<SpriteFont>("Font");
        }

        public void Update(GameTime gameTime)
        {
            this.score += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void AddPoints(int points)
        {
            this.score += points;
        }

        public void DeductPoints(int points)
        {
            this.score -= points;
        }
    }
}
