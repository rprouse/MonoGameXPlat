using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameXPlat
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D _spaceshipTexture;
        Vector2 _spaceshipPosition;
        readonly float _spaceshipSpeed = 200f;

        Color _backgroundColour = new Color(0x22, 0x28, 0x2A);

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Add your initialization logic here
            _spaceshipPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // use this.Content to load your game content here
            _spaceshipTexture = Content.Load<Texture2D>("spaceship");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Left))
            {
                _spaceshipPosition.X -= _spaceshipSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_spaceshipPosition.X < _spaceshipTexture.Width / 2f)
                    _spaceshipPosition.X = _spaceshipTexture.Width / 2f;
            }
            else if (kstate.IsKeyDown(Keys.Right))
            {
                _spaceshipPosition.X += _spaceshipSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_spaceshipPosition.X > _graphics.PreferredBackBufferWidth - _spaceshipTexture.Width / 2f)
                    _spaceshipPosition.X = _graphics.PreferredBackBufferWidth - _spaceshipTexture.Width / 2f;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColour);

            // Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_spaceshipTexture, _spaceshipPosition, null, Color.White, 0f, new Vector2(_spaceshipTexture.Width / 2, _spaceshipTexture.Height), Vector2.One, SpriteEffects.None, 0);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
