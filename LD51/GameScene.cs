using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD51
{
    public class GameScene : GameObject
    {
        private MonoGameSetup game;
        private Player player;
        private Score score;
        private BackgroundStars backgroundStar;
        private List<Airplane> airplanes = new List<Airplane>();
        private List<GreenHouse> houses = new List<GreenHouse>();
        private float spawnTimer = 3;
        private float spawnTempTimer = 0;

        public GameScene(MonoGameSetup game)
        {
            this.game = game;
            this.player = new Player(game, new PlayerAnimation());
            this.score = new Score(game);
            this.backgroundStar = new BackgroundStars(game);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            backgroundStar.Draw(gameTime, spriteBatch);

            foreach (GreenHouse house in houses)
            {
                house.Draw(gameTime, spriteBatch);
            }

            foreach (Airplane airplane in airplanes)
            {
                airplane.Draw(gameTime, spriteBatch);
            }
            player.Draw(gameTime, spriteBatch);
            score.Draw(gameTime, spriteBatch);
        }

        public void LoadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            backgroundStar.Update(gameTime);
            player.Update(gameTime);
            spawnTimer -= 0.0005F;
            spawnTempTimer++;
            this.game.speed += 0.1F;

            foreach (GreenHouse house in houses)
            {
                house.Update(gameTime);
            }

            foreach (Airplane airplane in airplanes)
            {
                airplane.Update(gameTime);

                if (airplane.GetHitBox().Intersects(player.hitbox))
                {
                    this.player.Die();
                }
            }

            if (spawnTempTimer / 60 >= spawnTimer)
            {
                this.spawnHouse();
            }

            if (spawnTempTimer / 60 >= spawnTimer)
            {
                this.spawnAirplane();
                spawnTempTimer = 0;
            }
            this.removeObjectsOutOfScreen();

            this.score.Update(gameTime);
        }

        private void spawnAirplane()
        {
            this.airplanes.Add(new Airplane(this.game));
        }

        private void spawnHouse()
        {
            this.houses.Add(new GreenHouse(this.game));
        }

        private void removeObjectsOutOfScreen()
        {
            this.airplanes.RemoveAll(x => x.pos.X < 0 - x.GetWidth());
            this.houses.RemoveAll(x => x.pos.X < 0 - x.GetWidth());
        }
    }
}
