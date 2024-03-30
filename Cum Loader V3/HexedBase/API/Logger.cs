using System;

namespace Starborn.API
{
    internal class LogHandler
    {
        private static string CLIENTNAME = "Cum Loader";
        public static void Log(string message, bool timeStamp = false, bool logToRpc = false)
        {
            if (timeStamp)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[");
                Console.Write(DateTime.Now.ToString("HH:mm.fff"));
                Console.Write("] ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("~");
            Console.Write(CLIENTNAME);
            Console.Write("~");
            Console.Write("  8==D  ");
            Console.ForegroundColor = LogHandler.getColor(LogHandler.Colors.White);
            Console.Write(message + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Log(LogHandler.Colors color, string message, bool timeStamp = false, bool logToRpc = false)
        {
            if (timeStamp)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[");
                Console.Write(DateTime.Now.ToString("HH:mm.fff"));
                Console.Write("] ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("~");
            Console.Write(CLIENTNAME);
            Console.Write("~");
            Console.Write("  8==D  ");
            Console.ForegroundColor = LogHandler.getColor(color);
            Console.Write(message + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static ConsoleColor getColor(LogHandler.Colors color)
        {
            switch (color)
            {
                case LogHandler.Colors.Red:
                    return ConsoleColor.Red;
                case LogHandler.Colors.Blue:
                    return ConsoleColor.Blue;
                case LogHandler.Colors.Black:
                    return ConsoleColor.Black;
                case LogHandler.Colors.White:
                    return ConsoleColor.White;
                case LogHandler.Colors.Green:
                    return ConsoleColor.Green;
                case LogHandler.Colors.Yellow:
                    return ConsoleColor.Yellow;
                case LogHandler.Colors.Cyan:
                    return ConsoleColor.Cyan;
                case LogHandler.Colors.DarkRed:
                    return ConsoleColor.DarkRed;
                case LogHandler.Colors.DarkGreen:
                    return ConsoleColor.DarkGreen;
                case LogHandler.Colors.DarkBlue:
                    return ConsoleColor.DarkBlue;
                case LogHandler.Colors.Grey:
                    return ConsoleColor.Gray;
                case LogHandler.Colors.Magenta:
                    return ConsoleColor.Magenta;
                case LogHandler.Colors.DarkYellow:
                    return ConsoleColor.DarkYellow;
                case LogHandler.Colors.DarkMagenta:
                    return ConsoleColor.DarkMagenta;
                case LogHandler.Colors.DarkCyan:
                    return ConsoleColor.DarkCyan;
                default:
                    return ConsoleColor.White;
            }
        }

        public enum Colors
        {
            Red,
            Blue,
            Black,
            White,
            Green,
            Yellow,
            Cyan,
            DarkRed,
            DarkGreen,
            DarkBlue,
            Grey,
            Magenta,
            DarkYellow,
            DarkMagenta,
            DarkCyan
        }
    }
}
