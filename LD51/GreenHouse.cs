using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LD51
{
    public class GreenHouse : GameObject
    {
        private MonoGameSetup game;
        private Texture2D houseSprite;

        public Vector2 pos;
        private Vector2 velocity;


        public GreenHouse(MonoGameSetup game)
        {
            this.game = game;
            this.LoadContent();
            var random = new Random();
            this.pos = new Vector2(Settings.windowWidth, Settings.windowHeight - houseSprite.Height + random.Next(32));
        }

        public int GetWidth()
        {
            return houseSprite.Width;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                houseSprite,
                pos,
                Color.White
            );
        }

        public void LoadContent()
        {
            this.houseSprite = game.Content.Load<Texture2D>("green-house");
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity = new Vector2(-this.game.speed, 0);
            pos += velocity * deltaTime;
        }
    }
}
