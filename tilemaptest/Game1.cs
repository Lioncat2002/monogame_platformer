using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using TiledSharp;

namespace tilemaptest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D playerTexture;
        


        private TmxMap map;
        private Texture2D tileset;

        private int tileWidth;
        private int tileHeight;
        private int tilesetTilesWide;
        private TileMapRenderer mapRenderer;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mapRenderer = new TileMapRenderer();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
           
            
            map = new TmxMap("Content/map.tmx");
            tileset = Content.Load<Texture2D>("Cave Tileset\\Cave Tileset\\" + map.Tilesets[0].Name.ToString());

            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;

            tilesetTilesWide = tileset.Width / tileWidth;
            // TODO: use this.Content to load your game content here
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
            mapRenderer.Draw(_spriteBatch,map,tileset,tilesetTilesWide,tileWidth,tileHeight);
            
            base.Draw(gameTime);
        }
    }
}