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
        const int middelStarAmount = 50;
        const int bigStarAmount = 30;
        Vector2[] littleStarPositions;
        Vector2[] middelStarPositions;
        Vector2[] bigStarPositions;
        Texture2D littleStar;
        Texture2D middelStar;
        Texture2D bigStar;

        Vector2 offset;
        float speed = 200;


        public BackgroundStars(MonoGameSetup game)
        {
            movement = Point.Zero;
            littleStar = new Texture2D(game.GraphicsDevice, 1, 1);
            middelStar = new Texture2D(game.GraphicsDevice, 2, 2);
            bigStar = new Texture2D(game.GraphicsDevice, 3, 3);
            offset = Vector2.Zero;

            littleStar.SetData(new Color[] { 
                Color.White 
            });

            middelStar.SetData(new Color[] { 
                Color.White , Color.White ,
                Color.White , Color.White 
            });
            bigStar.SetData(new Color[] { 
                Color.Transparent, Color.White, Color.Transparent,
                Color.White, Color.White, Color.White,
                Color.Transparent, Color.White, Color.Transparent
            });

            random = new Random();
            this.littleStarPositions = new Vector2[littleStarAmount];
            for(int i = 0; i < littleStarAmount; i++) {
                this.littleStarPositions[i].Y = random.Next(Settings.windowHeight);
                this.littleStarPositions[i].X = random.Next(Settings.windowWidth);
            }

            this.middelStarPositions = new Vector2[littleStarAmount];
            for (int i = 0; i < middelStarAmount; i++)
            {
                this.middelStarPositions[i].Y = random.Next(Settings.windowHeight);
                this.middelStarPositions[i].X = random.Next(Settings.windowWidth);
            }

            this.bigStarPositions = new Vector2[littleStarAmount];
            for (int i = 0; i < littleStarAmount; i++)
            {
                this.bigStarPositions[i].Y = random.Next(Settings.windowHeight);
                this.bigStarPositions[i].X = random.Next(Settings.windowWidth);
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
