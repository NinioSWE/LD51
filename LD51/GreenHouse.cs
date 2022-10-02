using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD51
{
    public class GreenHouse : HouseBase
    {
        private MonoGameSetup game;
        private Texture2D houseSprite;

        public Vector2 pos;
        private Vector2 velocity;


        public GreenHouse(MonoGameSetup game) : base(game, "green-house", 32)
        {
            
        }
    }
}
