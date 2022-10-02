using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD51
{
    public class BackgroundStars : GameObject
    {
        MonoGameSetup game;
        Point movement;
        Random random;
        const int littleStarAmount = 60;
        Vector2[] littleStarPositions;
        Texture2D littleStar;


        Vector2 offset;
        float speed = 200;


        public BackgroundStars(MonoGameSetup game)
        {
            movement = Point.Zero;
            littleStar = new Texture2D(game.GraphicsDevice, 1, 1);
            offset = Vector2.Zero;

            littleStar.SetData(new Color[] { 
                Color.White 
            });

            random = new Random();
            this.littleStarPositions = new Vector2[littleStarAmount];
            for(int i = 0; i < littleStarAmount; i++) {
                this.littleStarPositions[i].Y = random.Next(Settings.windowHeight);
                this.littleStarPositions[i].X = random.Next(Settings.windowWidth);
            }

            this.game = game;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < littleStarAmount; i++)
            {
                spriteBatch.Draw(littleStar, littleStarPositions[i], Color.White); 
            }
        }

        public void LoadContent()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < littleStarAmount; i++)
            {
                littleStarPositions[i].X -= deltaTime * speed;
                if (littleStarPositions[i].X < 0)
                {
                    littleStarPositions[i].X = Settings.windowWidth;
                }
            }
        }
    }
}
