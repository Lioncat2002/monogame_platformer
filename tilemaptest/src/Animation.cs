using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace tilemaptest
{
    public class Animation
    {
        private Texture2D spritesheet;

        private int cellwidth, cellheight;

        private int textureWidth;

        private int frames;
       
        int timeSinceLastFrame = 0;
        //int millisecondsPerFrame = 50;

        private int c = 0;
        /*This class accepts a spritesheet
         and outputs it as an sprite animation*/
        public Animation(Texture2D spritesheet,int cellwidth,int cellheight=0)
        {
            this.spritesheet = spritesheet;
            this.cellheight = cellheight;
            this.cellwidth = cellwidth;
            textureWidth = spritesheet.Width;
            frames = textureWidth / cellwidth;
        }

        public void Draw(SpriteBatch _spriteBatch, Rectangle pos,GameTime gameTime,int millisecondsPerFrame = 500)
        { 
            
            if (c < frames)
            {
                
                _spriteBatch.Draw(spritesheet,pos,new Rectangle(cellwidth*c,0,cellwidth,cellheight),Color.White);
                timeSinceLastFrame +=gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > millisecondsPerFrame){
                    Console.WriteLine("c:"+c);
                    timeSinceLastFrame -= millisecondsPerFrame;
                    c++;
                    if (c == frames)
                        c = 0;
                }
            }
          
        }
    }
}