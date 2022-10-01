using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD51
{
    public interface GameObject
    {
        public void LoadContent();
        public void Update(GameTime gameTime);
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
