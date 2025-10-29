using SFML.Window;

namespace GameEngine.Source
{
    static internal class Input
    {
        // Inputs
        public static Dictionary<string, InputAction> AllInputActions = [];

        // add Input actions here
        public static InputAction a1 = new InputAction("Left", Keyboard.Key.A, Keyboard.Key.Left);
        public static InputAction a2 = new InputAction("Right", Keyboard.Key.D, Keyboard.Key.Right);
        public static InputAction a3 = new InputAction("Up", Keyboard.Key.W, Keyboard.Key.Up);
        public static InputAction a4 = new InputAction("Down", Keyboard.Key.S, Keyboard.Key.Down);

        private static readonly string CLASS_NAME = "Input";

        public static bool ActionPressed(string actionName)
        {
            if (AllInputActions.TryGetValue(actionName, out InputAction? value))
            {
                return value.Pressing;
            }

            Log.Error(CLASS_NAME, $"Action {actionName} not found!");
            return false;
        }

        public static bool ActionJustPressed(string actionName)
        {
            if (AllInputActions.ContainsKey(actionName))
            {
                if (!AllInputActions[actionName].Pressed && AllInputActions[actionName].Pressing)
                {
                    AllInputActions[actionName].Pressed = true;
                    return AllInputActions[actionName].Pressed;
                }
            }
            else
            {
                Log.Error(CLASS_NAME, $"Action {actionName} not found!");
            }

            return false;
        }

        public static void GetKeyUp(KeyEventArgs e)
        {
            foreach (InputAction action in AllInputActions.Values)
            {
                if (action.Key == e.Code || (action.SecKey != Keyboard.Key.Unknown && action.SecKey == e.Code))
                {
                    action.Pressing = false;
                    action.Pressed = false;
                }
            }
        }
        
        public static void GetKeyDown(KeyEventArgs e)
        {
            foreach(InputAction action in AllInputActions.Values)
            {
                if (action.Key == e.Code || (action.SecKey != Keyboard.Key.Unknown && action.SecKey == e.Code))
                {
                    action.Pressing = true;
                    action.Pressed = false;
                }
            }
        }

    }
}