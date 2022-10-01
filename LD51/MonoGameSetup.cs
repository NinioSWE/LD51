using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace LD51
{
    public class MonoGameSetup : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameScene gameScene;

        public MonoGameSetup()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = Settings.windowTitle;
            _graphics.PreferredBackBufferWidth = Settings.windowWidth;
            _graphics.PreferredBackBufferHeight = Settings.windowHeight;

            _graphics.ApplyChanges();
            _graphics.SynchronizeWithVerticalRetrace = false;
            gameScene = new GameScene(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            gameScene.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color((byte)46,(byte)52,(byte)64));

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            gameScene.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}