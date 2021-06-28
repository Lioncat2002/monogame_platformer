using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using TiledSharp;

namespace tilemaptest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //private Texture2D playerTexture;
        private Matrix matrix;
        
        private TmxMap map;
        private Texture2D tileset;
        //private Texture2D player;
        private Animation player;

       
        private TileMapManager mapRenderer;
        private List<Rectangle> collisionObjects;
        private Dictionary<string, Rectangle> specialRects;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 576;
            _graphics.ApplyChanges();
            var Width = _graphics.PreferredBackBufferWidth;
            var Height = _graphics.PreferredBackBufferHeight;
            var WindowSize = new Vector2(Width, Height);
            var mapSize = new Vector2(1024, 576);//Our tile map size
            matrix = Matrix.CreateScale(new Vector3(WindowSize / mapSize, 1));
            specialRects = new Dictionary<string, Rectangle>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player = new Animation(
                Content.Load<Texture2D>("Sprite Pack 4\\Sprite Pack 4\\1 - Agent_Mike_Running (32 x 32)"),
                32,
                32);
            map = new TmxMap("Content/map.tmx");
            tileset = Content.Load<Texture2D>("Cave Tileset\\Cave Tileset\\" + map.Tilesets[0].Name.ToString());
            int tileWidth = map.Tilesets[0].TileWidth;
            int tileHeight = map.Tilesets[0].TileHeight;
            int TileSetTilesWide = tileset.Width / tileWidth;
            mapRenderer = new TileMapManager(_spriteBatch, map, tileset, TileSetTilesWide, tileWidth, tileHeight);
            collisionObjects = new List<Rectangle>();
            foreach (var o in map.ObjectGroups["Collisions"].Objects)
            {
                collisionObjects.Add(new Rectangle((int) o.X, (int) o.Y, (int) o.Width, (int) o.Height));
                if (o.Name != "")
                {
                    specialRects.Add(o.Name, new Rectangle((int) o.X, (int) o.Y, (int) o.Width, (int) o.Height));
                }
                
            }

           
            Console.WriteLine("Start pos:"+specialRects["Start"]);
            Console.WriteLine("End pos:"+specialRects["End"]);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           
            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            mapRenderer.Draw(matrix);
            _spriteBatch.Begin();
            player.Draw(_spriteBatch,specialRects["Start"],gameTime,100);
            
            _spriteBatch.End();
            //mapRenderer.Draw();
            base.Draw(gameTime);
        }
    }
}