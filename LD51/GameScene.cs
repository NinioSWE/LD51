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

        }

        public void LoadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            backgroundStar.Update(gameTime);
            player.Update(gameTime);
        }
    }
}
