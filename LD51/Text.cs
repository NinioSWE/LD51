using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD51
{
    public class Text : GameObject
    {
        MonoGameSetup game;

        private SpriteFont font;
        private string text;
        private Vector2 pos;
        public int timer = 60;

        public Text(MonoGameSetup game, string text, Vector2 pos)
        {
            this.game = game;
            this.LoadContent();
            this.text = text;
            this.pos = pos;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.text, this.pos, Color.White);
        }

        public void LoadContent()
        {
            this.font = this.game.Content.Load<SpriteFont>("Font");
        }

        public void Update(GameTime gameTime)
        {
            timer --;
            pos.Y -= 1f;
            if (timer <= 0)
            {
                timer = 0;
            }
        }
    }
}
