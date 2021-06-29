using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tilemaptest
{
    public class Player
    {
        public Rectangle playerPos;
        private int speed,fallspeed;
        private Animation idleAnim;
        private Animation runAnim;
        public bool isFalling = false;
        private bool isIdle, isRunning,isJumping;
        
        public Player(Rectangle startPos,int playerSpeed,Texture2D[] playerTex)
        {
            playerPos = startPos;
            speed = playerSpeed;
            idleAnim = new Animation(playerTex[0],32,32);
            runAnim = new Animation(playerTex[1], 32, 32);
            isIdle = true;
            isRunning = false;
            fallspeed = 6;

        }

        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();
            
            if (isFalling)
            {
                fallspeed = 6;
            }
            else if (!isFalling)
            {
                fallspeed = 0;
            }
            
            playerPos.Y += fallspeed;
            if (keyboard.IsKeyDown(Keys.A))
            {
                playerPos.X -= speed;
                isIdle = false;
                isRunning = true;
            }

           
           
            else if (keyboard.IsKeyDown(Keys.D))
            {
                playerPos.X += speed;
                isIdle = false;
                isRunning = true;
            }
            else
            {
                isIdle = true;
                isRunning = false;
            }

            
        }

        
        public void Draw(SpriteBatch _spriteBatch,GameTime gameTime)
        {
            if (isIdle)
            {
                idleAnim.Draw(_spriteBatch,playerPos,gameTime,100);
            }
            else if (isRunning)
            {
                runAnim.Draw(_spriteBatch, playerPos, gameTime, 100);
            }
        }
    }
}