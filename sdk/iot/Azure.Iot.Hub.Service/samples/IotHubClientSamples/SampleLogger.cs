using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Iot.Hub.Service.Samples
{
    internal static class SampleLogger
    {
        internal static void PrintHeader(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"\n\n==={message.ToUpperInvariant()}===\n");
            Console.ResetColor();
        }

        internal static void FatalError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Environment.Exit(0);
        }

        internal static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        internal static void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }
    }
}
