using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LD51
{
    public class MonoGameSetup : Game
    {
        public bool isPlaying = true;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public GameScene gameScene;
        public Texture2D hitboxSprite;
        public float speed = 300;
        public Score score;

        public MonoGameSetup()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
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
            this.hitboxSprite = this.Content.Load<Texture2D>("hitbox");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (isPlaying)
            {
                gameScene.Update(gameTime);
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    gameScene = new GameScene(this);
                    isPlaying = true;
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color((byte)46,(byte)52,(byte)64));

            _spriteBatch.Begin();
            gameScene.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}