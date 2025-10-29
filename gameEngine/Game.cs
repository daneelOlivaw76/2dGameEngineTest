using gameEngine;
using GameEngine.Source;
using SFML.Graphics;

namespace GameEngine
{
    internal class Game : Engine
    {
        private static new readonly string CLASS_NAME = "Game";
        public Game() : base((uint)800, (uint)800, "Engine Test", Color.Black) {  }

        Player player = new Player(new Vector2(), new Vector2(), "player");

        public override void OnLoad()
        {
    
        }
        
        public override void OnUpdate()
        {
            Log.Info(CLASS_NAME, $"Player's Position: {player.Position.x} | {player.Position.y}");

            base.OnUpdate();
        }
    }
}