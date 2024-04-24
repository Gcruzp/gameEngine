using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class MenuScreen : IScreen
{
    private Button _playButton;
    private Button _exitButton;
    private Texture2D _bg;

    public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
    {
        _playButton = new Button(content.Load<Texture2D>("play_button"), Play);
        _exitButton = new Button(content.Load<Texture2D>("exit_button"), Exit);
        _bg = content.Load<Texture2D>("bg");
    }

    public void Initialize()
    {
        _playButton.Position = new Point((Globals.SCREEN_WIDTH - _playButton.Bounds.Width)/2, 200);
        _exitButton.Position = new Point((Globals.SCREEN_WIDTH - _exitButton.Bounds.Width)/2, 250);
    }

    public void Update(float deltaTime)
    {
        _playButton.Update(deltaTime);
        _exitButton.Update(deltaTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
         spriteBatch.Draw(_bg, new Rectangle(0, 0, Globals.SCREEN_WIDTH, Globals.SCREEN_HEIGHT), Color.White);
        _playButton.Draw(spriteBatch);
        _exitButton.Draw(spriteBatch);
    }

    private void Play()
    {
        Globals.GameInstance.ChangeScreen(MyGame.EScreen.Game);
    }

    private void Exit()
    {
        Globals.GameInstance.Exit();
    }
}