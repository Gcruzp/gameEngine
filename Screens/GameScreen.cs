using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace MyGame
{
        public enum EScreen
    {
        Menu,
        Game
    }

    public interface IScreen
    {
        void Initialize();
        void LoadContent(ContentManager content, GraphicsDevice graphicsDevice);
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }

    public class GameScreen : IScreen
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Ship _ship;
        private List<Enemy> _listEnemys = new List<Enemy>();
        private int _lines = 4;
        private int _columns = 13;
        private int _distanceX = 50;
        private int _distanceY = 50;

        public void Initialize()
        {
            // Implemente a inicialização, se necessário
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            _spriteBatch = new SpriteBatch(graphicsDevice);
            _ship = new Ship(Globals.GameInstance);
            _ship.Position = new Vector2(350, 400);

            int posX = 0;
            int posY = _distanceY;
            Random random = new Random();
            
            for (int l = 0; l <= _lines; l++)
            {
                for (int c = 0; c <= _columns; c++)
                {
                    Enemy enemy = new Enemy(Globals.GameInstance);
                    posX += _distanceX;
                    enemy.Position = new Vector2(posX, posY);
                    enemy.Time = random.Next(1000, 15000);
                    _listEnemys.Add(enemy);
                }

                posX = 0;
                posY += _distanceY;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (Input.GetKeyDown(Keys.Escape))
            {
                Globals.GameInstance.ChangeScreen(EScreen.Menu);
            }

            // TODO: Add your update logic here
            if (_ship.Enabled)
                _ship.Update(gameTime);

           for (int x = 0; x <= _listEnemys.Count - 1; x++)
           {
                _listEnemys[x].Collide(_ship.listShoot);

                if (_listEnemys[x].Enabled == false)
                    _listEnemys.RemoveAt(x);
                else 
                {
                    _listEnemys[x].Update(gameTime);
                    _ship.Collide(_listEnemys[x].listShoot);
                }
                    
           }
        }

        public void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            if (_ship.Visible)
                _ship.Draw(_spriteBatch, gameTime);
            
            foreach (Enemy e in _listEnemys)
            {
                e.Draw(_spriteBatch, gameTime);
            }
        }
    }
}