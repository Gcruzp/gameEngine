using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private MenuScreen _menuScreen;
        private IScreen _gameScreen;
        private IScreen _currentScreen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void ChangeScreen(EScreen screenType)
        {
            switch (screenType)
            {
                case EScreen.Menu:
                    _currentScreen = (IScreen)_menuScreen;
                    break;
                case EScreen.Game:
                    _currentScreen = _gameScreen;
                    break;
            }

            _currentScreen.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _menuScreen = new MenuScreen();
            _menuScreen.LoadContent(Content, GraphicsDevice);
            _gameScreen = new GameScreen();
            _gameScreen.LoadContent(Content, GraphicsDevice);

            _currentScreen = (IScreen)_menuScreen;
        }

        protected override void Initialize()
        {
            base.Initialize();

            Globals.SCREEN_WIDTH = _graphics.PreferredBackBufferWidth;
            Globals.SCREEN_HEIGHT = _graphics.PreferredBackBufferHeight;
            Globals.GameInstance = this;

            _currentScreen.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            _currentScreen.Update(gameTime);

            Input.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _currentScreen.Draw(gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
