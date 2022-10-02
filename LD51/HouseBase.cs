using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LD51
{
    public abstract class HouseBase : GameObject
    {
        internal MonoGameSetup game;
        private Texture2D houseSprite;
        private string fileName;

        public Vector2 pos;
        private Vector2 velocity;
        public Rectangle hitbox;
        public Rectangle hitbox2;
        public Rectangle chimneyHitBox;

        public HouseBase(MonoGameSetup game, string fileName, int pixelHeightOffset)
        {
            this.game = game;
            this.fileName = fileName;
            this.LoadContent();
            var random = new Random();
            this.pos = new Vector2(Settings.windowWidth, Settings.windowHeight - houseSprite.Height + random.Next(pixelHeightOffset));
            hitbox = new Rectangle((int)pos.X, (int)pos.Y + houseSprite.Height / 2, houseSprite.Width, houseSprite.Height/2);
            hitbox2 = new Rectangle((int)pos.X + houseSprite.Width / 2, (int)pos.Y, houseSprite.Width - 40, houseSprite.Height / 2 - 30);
        }

        public int GetWidth()
        {
            return houseSprite.Width;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                houseSprite,
                pos,
                Color.White
            );

            //spriteBatch.Draw(this.game.hitboxSprite, hitbox, Color.White);
            //spriteBatch.Draw(this.game.hitboxSprite, hitbox2, Color.White);
        }

        public void LoadContent()
        {
            this.houseSprite = game.Content.Load<Texture2D>(this.fileName);
        }

        public virtual void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity = new Vector2(-this.game.speed, 0);
            pos += velocity * deltaTime;

            hitbox.X = (int)pos.X;
            hitbox.Y = (int)pos.Y + houseSprite.Height / 2;

            hitbox2.X = (int)pos.X + 20;
            hitbox2.Y = (int)pos.Y +15;
        }
    }
}
