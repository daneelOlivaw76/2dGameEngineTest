using SFML.Window;

namespace GameEngine.Source
{
    internal class InputAction
    {
        public string name { get; set; }

        public Keyboard.Key Key { get; set; }

        public Keyboard.Key SecKey { get; set; }

        public bool Pressing = false;
        public bool Pressed = false;

        public InputAction(string name, Keyboard.Key key)
        {
            this.name = name;
            this.Key = key;
            this.SecKey = Keyboard.Key.Unknown;
            Input.AllInputActions.Add(this.name, this);
        }

        public InputAction(string name, Keyboard.Key key, Keyboard.Key secKey)
        {
            this.name = name;
            this.Key = key;
            this.SecKey = secKey;
            Input.AllInputActions.Add(this.name, this);
        }
    }
}