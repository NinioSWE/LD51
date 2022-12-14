using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LD51
{
    public class Player : GameObject
    {
        private MonoGameSetup game;
        private PlayerAnimation playerAnimation;
        public Texture2D characterSprite;

        public Vector2 pos;
        private Vector2 velocity;
        private float maxVelocity = 300;
        private float movement = 60;
        public List<Gift> gifts = new List<Gift>();
        private bool isSpaceDown = false;
        public Rectangle hitbox;
        public int seenWidth;
        private Explosion explosion;
        private bool isAlive = true;

        public Player(MonoGameSetup game, PlayerAnimation playerAnimation)
        {
            this.game = game;
            LoadContent();
            this.playerAnimation = playerAnimation;
            this.pos = new Vector2(Settings.windowWidth/4, Settings.windowHeight/2);
            seenWidth = 144;
            hitbox = new Rectangle((int)pos.X, (int)pos.Y + 15, seenWidth, characterSprite.Height-30);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                spriteBatch.Draw(
                    characterSprite,
                    pos,
                    new Rectangle(this.playerAnimation.GetAnimationFrame() * seenWidth, 0, seenWidth, 76),
                    Color.White
                );

                foreach (Gift gift in gifts)
                {
                    gift.Draw(gameTime, spriteBatch);
                }

            }

            if (this.explosion != null)
            {
                this.explosion.Draw(gameTime, spriteBatch);
            }
        }

        public void LoadContent()
        {
            this.characterSprite = game.Content.Load<Texture2D>("Character");
        }

        public void Update(GameTime gameTime)
        {
            if (isAlive)
            {
                KeyboardState state = Keyboard.GetState();
                float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                this.playerAnimation.AnimateCharacter();
                this.MoveCharacter(state, deltaTime);
                this.KeepOnScreen();
                this.DropGift(state);

                foreach (Gift gift in gifts)
                {
                    gift.Update(gameTime);
                }
                this.removeGifts();
                hitbox.X = (int)pos.X;
                hitbox.Y = (int)pos.Y+15;
            }

            if (this.explosion != null)
            {
                this.explosion.Update(gameTime);
            }
        }

        public void Die()
        {
            if (this.explosion == null) {
                this.isAlive = false;
                this.explosion = new Explosion(this.game, new Vector2(this.pos.X + this.seenWidth / 2 - 128, this.pos.Y + this.characterSprite.Height / 2 - 128));
            }
        }

        private void MoveCharacter(KeyboardState state, float deltaTime)
        {
            if (state.IsKeyDown(Keys.W))
            {
                this.velocity.Y -= movement;
            }
            else if (state.IsKeyDown(Keys.S))
            {
                this.velocity.Y += movement;
            }
            else if (this.velocity.Y < 0)
            {
                this.velocity.Y += movement;
                if (this.velocity.Y >= 0)
                {
                    this.velocity.Y = 0;
                }
            }
            else if (this.velocity.Y > 0)
            {
                this.velocity.Y -= movement;
                if (this.velocity.Y <= 0)
                {
                    this.velocity.Y = 0;
                }
            }
            this.velocity.Y = Math.Clamp(this.velocity.Y, -maxVelocity, maxVelocity);


            pos += velocity * deltaTime;
        }

        private void KeepOnScreen()
        {
            pos.Y = Math.Clamp(pos.Y, 0, Settings.windowHeight - this.characterSprite.Height);
        }

        private void DropGift(KeyboardState state)
        {
            
            if (state.IsKeyDown(Keys.Space) && !isSpaceDown)
            {
                isSpaceDown = true;
                var gift = new Gift(this.game, this.pos + new Vector2(32, 76));
                this.gifts.Add(gift);
            }
            if (state.IsKeyUp(Keys.Space))
            {
                isSpaceDown = false;
            }
        }

        private void removeGifts()
        {
            this.gifts.RemoveAll(gift => {
                var outsideWindow = gift.pos.Y > Settings.windowHeight;

                if (outsideWindow)
                {
                    this.game.score.DeductPoints(500, gift.pos);
                } 
                return outsideWindow;
            });
        }
    }
}
