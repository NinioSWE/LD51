using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace LD51
{
    public class GameScene : GameObject
    {
        private Random random = new Random();
        private MonoGameSetup game;
        private Player player;
        private BackgroundStars backgroundStar;
        private List<Airplane> airplanes = new List<Airplane>();
        private List<HouseBase> houses = new List<HouseBase>();
        private float spawnTimer = 3;
        private float spawnhouseTimer = 1;
        private float spawnHouseTempTimer = 0;
        private float spawnTempTimer = 0;
        private Song bgSong;

        public GameScene(MonoGameSetup game)
        {
            this.game = game;
            this.LoadContent();
            this.player = new Player(game, new PlayerAnimation());
            this.backgroundStar = new BackgroundStars(game);
            this.game.score = new Score(this.game);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(bgSong);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            backgroundStar.Draw(gameTime, spriteBatch);

            foreach (HouseBase house in houses)
            {
                house.Draw(gameTime, spriteBatch);
            }

            foreach (Airplane airplane in airplanes)
            {
                airplane.Draw(gameTime, spriteBatch);
            }
            player.Draw(gameTime, spriteBatch);
            this.game.score.Draw(gameTime, spriteBatch);
        }

        public void LoadContent()
        {
           this.bgSong = this.game.Content.Load<Song>("christmas-piano");
        }

        public void Update(GameTime gameTime)
        {
            backgroundStar.Update(gameTime);
            player.Update(gameTime);
            spawnTimer -= 0.0005F;
            spawnTempTimer++;
            spawnHouseTempTimer++;
            this.game.speed += 0.1F;

            foreach (HouseBase house in houses)
            {
                house.Update(gameTime);

                if (house.hitbox.Intersects(player.hitbox) 
                    || house.hitbox2.Intersects(player.hitbox))
                {
                    this.player.Die();
                }
            }

            foreach (Airplane airplane in airplanes)
            {
                airplane.Update(gameTime);

                if (airplane.GetHitBox().Intersects(player.hitbox))
                {
                    this.player.Die();
                }
            }
            List<Gift> tempRemovelist = new List<Gift>();
            foreach (Gift gift in this.player.gifts)
            {
                gift.Update(gameTime);

                foreach (HouseBase house in houses)
                {
                    if (gift.hitbox.Intersects(house.chimneyHitBox))
                    {
                        this.game.score.AddPoints(1000, house.chimneyHitBox.Location.ToVector2());
                        tempRemovelist.Add(gift);
                    }
                }
            }

            foreach (var temp in tempRemovelist)
            {
                this.player.gifts.Remove(temp);
            }

            if (spawnHouseTempTimer / 60 >= spawnhouseTimer)
            {
                spawnhouseTimer = (float)random.NextDouble() * (2 - 0) + 0.5F;
                this.spawnHouse();
                spawnHouseTempTimer = 0;
            }

            if (spawnTempTimer / 60 >= spawnTimer)
            {
                this.spawnAirplane();
                spawnTempTimer = 0;
            }
            this.removeObjectsOutOfScreen();

            this.game.score.Update(gameTime);
        }

        private void spawnAirplane()
        {
            this.airplanes.Add(new Airplane(this.game));
        }

        private void spawnHouse()
        {
            var houseIndex = this.random.Next(2);

            if (houseIndex == 0)
            {
                this.houses.Add(new RedHouse(this.game));
            } else
            {
                this.houses.Add(new GreenHouse(this.game));
            }        
        }

        private void removeObjectsOutOfScreen()
        {
            this.airplanes.RemoveAll(x => x.pos.X < 0 - x.GetWidth());
            this.houses.RemoveAll(x => x.pos.X < 0 - x.GetWidth());
        }
    }
}
