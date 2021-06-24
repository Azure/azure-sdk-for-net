// -------------------------------------------------------------------------
//  <copyright file="ConsoleEx.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------

using System;

namespace ConsoleTest
{
    /// <summary>
    /// Extra console methods to display text in colors.
    /// </summary>
    public static class ConsoleEx
    {
        private static object _consoleLock = new object();
        private static ConsoleColor _defaultColor = Console.ForegroundColor;

        /// <summary>
        /// Writes text to console using the default color.
        /// </summary>
        /// <param name="format" type="string">A composite format string .</param>
        /// <param name="args" type="params object[]">An object array that contains zero or more objects to format.</param>
        public static void WriteLine(string format, params object[] args)
        {
            WriteLine(_defaultColor, string.Format(format, args));
        }

        /// <summary>
        /// Writes text to console using the specified color.
        /// </summary>
        /// <param name="color" type="ConsoleColor">Text color to be used.</param>
        /// <param name="format" type="string">A composite format string .</param>
        /// <param name="args" type="params object[]">An object array that contains zero or more objects to format.</param>
        public static void WriteLine(ConsoleColor color, string format, params object[] args)
        {
            WriteLine(color, string.Format(format, args));
        }

        /// <summary>
        /// Writes text to console using the specified color.
        /// </summary>
        /// <param name="color" type="ConsoleColor">Text color to be used.</param>
        /// <param name="message" type="string">Text message to be written.</param>
        public static void WriteLine(ConsoleColor color, string message)
        {
            Write(color, message + "\n");
        }

        /// <summary>
        /// Writes text to console using the specified color.
        /// </summary>
        /// <param name="color" type="ConsoleColor">Text color to be used.</param>
        /// <param name="format" type="string">A composite format string .</param>
        /// <param name="args" type="params object[]">An object array that contains zero or more objects to format.</param>
        public static void Write(ConsoleColor color, string format, params object[] args)
        {
            Write(color, string.Format(format, args));
        }

        /// <summary>
        /// Writes text to console using the specified color.
        /// </summary>
        /// <param name="color" type="ConsoleColor">Text color to be used.</param>
        /// <param name="message" type="string">Text message to be written.</param>
        public static void Write(ConsoleColor color, string message)
        {
            lock (_consoleLock)
            {
                // Save original color
                ConsoleColor defaultColor = Console.ForegroundColor;

                try
                {
                    // Write text message
                    Console.ForegroundColor = color;
                    Console.Write(message);
                }
                finally
                {
                    // Revert back to the original color
                    Console.ForegroundColor = defaultColor;
                }
            }
        }
    }
}
