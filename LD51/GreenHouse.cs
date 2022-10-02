using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD51
{
    public class GreenHouse : HouseBase
    {
        public GreenHouse(MonoGameSetup game) : base(game, "green-house", 44)
        {
            chimneyHitBox = new Rectangle((int)pos.X + 152, (int)pos.Y + 16, 36, 8);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            chimneyHitBox.X = (int)pos.X + 152;
            chimneyHitBox.Y = (int)pos.Y + 16;
        }

    }
}
