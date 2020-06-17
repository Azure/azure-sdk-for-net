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

        internal static void PrintSuccessfulEvent(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }

        internal static void PrintUnsuccessfulEvent(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }
    }
}
