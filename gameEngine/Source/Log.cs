namespace GameEngine.Source
{
    public class Log
    {
        public static void Normal(string CLASS_NAME, string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{CLASS_NAME}]: {message}");
        }

        public static void Info(string CLASS_NAME, string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[{CLASS_NAME}]: {message}");
        }

        public static void Warning(string CLASS_NAME, string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{CLASS_NAME}]: {message}");
        }

        public static void Error(string CLASS_NAME, string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{CLASS_NAME}]: {message}");
        }
    }
}