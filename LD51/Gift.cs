using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LD51
{
    public class Gift : GameObject
    {
        private MonoGameSetup game;
        private Texture2D giftSprite;

        public Vector2 pos;
        private Vector2 velocity;
        private Vector2 gravity;
        private int giftIndex;

        public Gift(MonoGameSetup game, Vector2 startPos)
        {
            this.game = game;
            this.LoadContent();
            this.pos = startPos;
            Random random = new Random();
            this.giftIndex = random.Next(3);
            this.gravity = new Vector2(0, 1000);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                giftSprite,
                pos,
                new Rectangle(giftIndex * 20, 0, 20, 24),
                Color.White
            );
        }

        public void LoadContent()
        {
            this.giftSprite = game.Content.Load<Texture2D>("presents");
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            pos += velocity * deltaTime;
            velocity += gravity * deltaTime;
        }
    }
}
