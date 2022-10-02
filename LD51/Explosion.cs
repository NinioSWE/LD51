using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD51
{
    public class Explosion : GameObject
    {
        private readonly MonoGameSetup game;
        private Texture2D explosionSprite;

        private Vector2 pos;
        private readonly int seenWidth = 256;
        private readonly int totalAnimationFrames = 6;
        private readonly int numberOfFrames = 5;
        private int tempTimer = 0;
        private int animationFrame = 0;
        private SpriteFont gameOverText;
        private bool showGameOver = false;

        public Explosion(MonoGameSetup game, Vector2 pos)
        {
            this.game = game;
            this.LoadContent();
            this.pos = pos;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                explosionSprite,
                pos,
                new Rectangle(this.animationFrame * seenWidth, 0, seenWidth, seenWidth),
                Color.White
            );
            if (this.showGameOver)
            {
                spriteBatch.DrawString(gameOverText, "GAME OVER! SCORE: " + game.score.score, new Vector2(100, Settings.windowHeight / 2 - 40), Color.White);
                spriteBatch.DrawString(gameOverText, "Press R to restart", new Vector2(100, Settings.windowHeight / 2 + 40), Color.White);
            }
        }

        public void LoadContent()
        {
            this.explosionSprite = game.Content.Load<Texture2D>("explosion4x");
            this.gameOverText = this.game.Content.Load<SpriteFont>("Big");
        }

        public void Update(GameTime gameTime)
        {
            this.AnimateExplosion();
        }

        private void AnimateExplosion()
        {
            if (tempTimer == numberOfFrames)
            {
                animationFrame++;
                if (animationFrame == totalAnimationFrames)
                {
                    animationFrame = totalAnimationFrames - 1;

                    this.showGameOver = true;
                    this.game.isPlaying = false;
                }
                tempTimer = 0;
            }

            tempTimer++;
        }
    }
}
