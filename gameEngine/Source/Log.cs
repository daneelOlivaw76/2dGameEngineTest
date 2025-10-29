namespace GameEngine.Source
{
    public class Log
    {
        public static void Normal(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }

        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }
    }
}