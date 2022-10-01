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
        private BackgroundStars backgroundStar;
        private List<Airplane> airplanes = new List<Airplane>();
        private float spawnTimer = 3;
        private float spawnTempTimer = 0;

        public GameScene(MonoGameSetup game)
        {
            this.game = game;
            this.player = new Player(game, new PlayerAnimation());
            this.backgroundStar = new BackgroundStars(game);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            backgroundStar.Draw(gameTime, spriteBatch);
            player.Draw(gameTime, spriteBatch);

            foreach (Airplane airplane in airplanes)
            {
                airplane.Draw(gameTime, spriteBatch);
            }
        }

        public void LoadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            backgroundStar.Update(gameTime);
            player.Update(gameTime);
            spawnTimer -= 0.0001F;
            spawnTempTimer++;

            foreach (Airplane airplane in airplanes)
            {
                airplane.Update(gameTime);
            }

            if (spawnTempTimer / 60 >= spawnTimer)
            {
                this.spawnAirplane();
                spawnTempTimer = 0;
            }
            this.removeAirplanes();
        }

        private void spawnAirplane()
        {
            this.airplanes.Add(new Airplane(this.game));
        }

        private void removeAirplanes()
        {
            this.airplanes.RemoveAll(x => x.pos.X < 0 - x.GetWidth());
        }
    }
}
