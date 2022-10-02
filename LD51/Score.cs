using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LD51
{
    public class Score : GameObject
    {
        public int score = 0;

        private readonly MonoGameSetup game;
        private SpriteFont font;
        public List<Text> texts = new List<Text>();

        public Score(MonoGameSetup game)
        {
            this.game = game;
            this.LoadContent();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.score.ToString(), new Vector2(5, 5), Color.White);

            foreach (var text in texts)
            {
                text.Draw(gameTime, spriteBatch);
            }
        }

        public void LoadContent()
        {
            this.font = this.game.Content.Load<SpriteFont>("Font");
        }

        public void Update(GameTime gameTime)
        {
            this.score += 2;
            foreach(var text in texts)
            {
                text.Update(gameTime);
            }
            this.texts.RemoveAll(x => x.timer == 0);
        }

        public void AddPoints(int points, Vector2 pos)
        {
            this.score += points;
            this.texts.Add(new Text(this.game, "+" + points, pos));
        }

        public void DeductPoints(int points, Vector2 pos)
        {
            this.score -= points;
            this.texts.Add(new Text(this.game, "-" + points, pos));
        }
    }
}
