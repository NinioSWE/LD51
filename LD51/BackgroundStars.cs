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
        int speed = 1;


        public BackgroundStars(MonoGameSetup game)
        {
            movement = Point.Zero;
            littleStar = new Texture2D(game.GraphicsDevice, 1, 1);
            middelStar = new Texture2D(game.GraphicsDevice, 2, 2);
            bigStar = new Texture2D(game.GraphicsDevice, 3, 3);

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
            foreach (var starPosition in littleStarPositions)
            {
                spriteBatch.Draw(littleStar, new Rectangle(starPosition.ToPoint() + movement, littleStar.Bounds.Size * new Point(4,4)), Color.White); 
            }

            foreach (var starPosition in middelStarPositions)
            {
                spriteBatch.Draw(middelStar, new Rectangle(starPosition.ToPoint() + movement, littleStar.Bounds.Size * new Point(4, 4)), Color.White);
            }

            foreach (var starPosition in bigStarPositions)
            {
                spriteBatch.Draw(bigStar, new Rectangle(starPosition.ToPoint() + movement, littleStar.Bounds.Size * new Point(4, 4)), Color.White);
            }
        }

        public void LoadContent()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
