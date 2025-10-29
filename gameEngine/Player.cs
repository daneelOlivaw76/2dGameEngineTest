using GameEngine.Source;

namespace gameEngine
{
    public class Player : GameEngine.Source.GameObject
    {
        private static readonly string CLASS_NAME = "Player";
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public Player(Vector2 position, Vector2 scale , string tag): base(position, scale, tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;
        }
        public override void OnDestroy()
        {
            Log.Info(CLASS_NAME, "Player Destroyed");
        }

        public override void OnLoad()
        {
            Log.Info(CLASS_NAME, "Player Loaded");
        }

        public override void OnUpdate()
        {
            if (Input.ActionPressed("Right"))
            {
                Position.x += 1;
            }

            if (Input.ActionPressed("Left"))
            {
                Position.x -= 1;
            }
            if (Input.ActionPressed("Up"))
            {
                Position.y += 1;
            }
            
            if (Input.ActionPressed("Down"))
            {
                Position.y -= 1;
            }
        }
    }
}