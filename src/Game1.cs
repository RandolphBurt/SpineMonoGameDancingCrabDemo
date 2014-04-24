using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DancingCrabDemo
{
    using Spine;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private SkeletonRegionRenderer skeletonRenderer;
        private Skeleton skeleton;
        private Animation animation;
        private float timer = 1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            this.skeletonRenderer = new SkeletonRegionRenderer(GraphicsDevice);

            var atlas = new Atlas(@"Assets\crab.atlas", new XnaTextureLoader(GraphicsDevice));
            var json = new SkeletonJson(atlas);

            this.skeleton = new Skeleton(json.ReadSkeletonData(@"Assets\skeleton.json"));
            this.animation = this.skeleton.Data.FindAnimation("Walk");

            this.skeleton.X = 750;
            this.skeleton.Y = 700;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            var lastTimer = this.timer;
            this.timer += gameTime.ElapsedGameTime.Milliseconds / 1000f;
            this.animation.Apply(this.skeleton, lastTimer, this.timer, true, null);

            this.skeleton.UpdateWorldTransform();
            
            this.skeletonRenderer.Begin();
            this.skeletonRenderer.Draw(this.skeleton);
            this.skeletonRenderer.End();

            base.Draw(gameTime);
        }
    }
}
