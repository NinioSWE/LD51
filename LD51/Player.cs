﻿using Microsoft.Xna.Framework;
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

        private Vector2 pos;
        private Vector2 velocity;
        private float maxVelocity = 300;
        private float movement = 60;
        private List<Gift> gifts = new List<Gift>();
        private bool isSpaceDown = false;

        public Player(MonoGameSetup game, PlayerAnimation playerAnimation)
        {
            this.game = game;
            this.playerAnimation = playerAnimation;
            this.pos = new Vector2(Settings.windowWidth/4, Settings.windowHeight/2);
            LoadContent();
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                characterSprite,
                pos,
                new Rectangle(this.playerAnimation.GetAnimationFrame() * 144, 0,144,76),
                Color.White
            );

            foreach(Gift gift in gifts)
            {
                gift.Draw(gameTime, spriteBatch);
            }
        }

        public void LoadContent()
        {
            this.characterSprite = game.Content.Load<Texture2D>("Character");
        }

        public void Update(GameTime gameTime)
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

        private void removeGifts(KeyboardState state)
        {
            this.gifts.RemoveAll(x => x.pos.X <= 0);
        }
    }
}
