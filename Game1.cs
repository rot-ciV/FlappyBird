using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Priquito priquito;
    private ParCano cano;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        priquito = new Priquito(new Vector2(100, 200));
        cano = new ParCano(new Vector2(800, 0), -100f, 100f, 150f);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        priquito.Sprite = Content.Load<Texture2D>("Priquito 1.0");
        cano.Sprite = Content.Load<Texture2D>("Cano 1.0");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        priquito.Update(gameTime);
        cano.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        priquito.Draw(_spriteBatch);
        cano.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
