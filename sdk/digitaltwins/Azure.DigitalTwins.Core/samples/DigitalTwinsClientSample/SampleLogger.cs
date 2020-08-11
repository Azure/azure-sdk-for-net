// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.DigitalTwins.Core.Samples
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
    }
}
