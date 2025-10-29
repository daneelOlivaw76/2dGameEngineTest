using gameEngine;
using GameEngine.Source;
using SFML.Graphics;

namespace GameEngine
{
    internal class Game : Engine
    {
        private const string ClassName = "Game";
        public Game() : base((uint)800, (uint)800, "Engine Test", Color.Black) {  }

        Player player = new Player(new Vector2(), new Vector2(), "player");

        public override void OnLoad()
        {
    
        }
        
        public override void OnUpdate()
        {
            Log.Info(ClassName, $"Player's Position: {player.Position.x} | {player.Position.y}");

            base.OnUpdate();
        }
    }
}