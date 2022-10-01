using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LD51
{
    internal class Airplane : GameObject
    {
        private MonoGameSetup game;
        private Texture2D airplaneSprite;

        public Vector2 pos;
        private Vector2 velocity;
        private int speed;

        public Airplane(MonoGameSetup game)
        {
            this.game = game;
            this.LoadContent();
            var random = new Random();
            this.pos = new Vector2(Settings.windowWidth, random.Next(Settings.windowHeight - airplaneSprite.Height));
            this.speed = 300 + random.Next(200);
        }

        public int GetWidth()
        {
            return airplaneSprite.Width;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                airplaneSprite,
                pos,
                Color.White
            );
        }

        public void LoadContent()
        {
            this.airplaneSprite = game.Content.Load<Texture2D>("airplane");
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity = new Vector2(-this.speed, 0);
            pos += velocity * deltaTime;
        }
    }
}
