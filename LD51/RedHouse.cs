using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD51
{
    public class RedHouse : HouseBase
    {
        public RedHouse(MonoGameSetup game) : base(game, "red-house", 44)
        {
            chimneyHitBox = new Rectangle((int)pos.X + 24 , (int)pos.Y + 20, 56, 8);

        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            chimneyHitBox.X = (int)pos.X + 24;
            chimneyHitBox.Y = (int)pos.Y + 20;
        }
    }
}
