using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public interface IScreen
{
    void LoadContent(ContentManager content, GraphicsDevice graphicsDevice);
    void Initialize();
    void Update(float deltaTime);
    void Draw(SpriteBatch spriteBatch);
}