using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LD51
{
    public abstract class HouseBase : GameObject
    {
        private MonoGameSetup game;
        private Texture2D houseSprite;
        private string fileName;

        public Vector2 pos;
        private Vector2 velocity;

        public HouseBase(MonoGameSetup game, string fileName, int pixelHeightOffset)
        {
            this.game = game;
            this.fileName = fileName;
            this.LoadContent();
            var random = new Random();
            this.pos = new Vector2(Settings.windowWidth, Settings.windowHeight - houseSprite.Height + random.Next(pixelHeightOffset));
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
            this.houseSprite = game.Content.Load<Texture2D>(this.fileName);
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity = new Vector2(-this.game.speed, 0);
            pos += velocity * deltaTime;
        }
    }
}
