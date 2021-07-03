using System;
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
        public bool isFalling = false,isJumping;
        private bool isIdle, isRunning;
        private int jumpspeed = 14;
        public int startY;
        public Player(Rectangle startPos,int playerSpeed,Texture2D[] playerTex)
        {
            playerPos = startPos;
            speed = playerSpeed;
            idleAnim = new Animation(playerTex[0],32,32);
            runAnim = new Animation(playerTex[1], 32, 32);
            isIdle = true;
            isRunning = false;
            isJumping = false;
            fallspeed = 3;

        }

        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();
            isIdle = true;
            isRunning = false;
            
            
            playerPos.Y += fallspeed;
            if (keyboard.IsKeyDown(Keys.A))
            {
                playerPos.X -= speed;
                isIdle = false;
                isRunning = true;
                
            }
            if (isJumping)
            {
                startY = playerPos.Y;
                playerPos.Y += jumpspeed;//Making it go up
                jumpspeed += 1;//Some math (explained later)
                if (playerPos.Y >= startY)
                    //If it's farther than ground
                {
                    playerPos.Y = startY;//Then set it on
                    isJumping = false;
                    isFalling = true;
                }
            }
            else
            {
                if (keyboard.IsKeyDown(Keys.W) &&isFalling) 
                {
                    isJumping = true;
                    jumpspeed = -14;//Give it upward thrust
                }
            }
            Console.WriteLine(isFalling);
            if (keyboard.IsKeyDown(Keys.D))
            {
                playerPos.X += speed;
                //Console.WriteLine(isJumping);
                isIdle = false;
                isRunning = true;
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