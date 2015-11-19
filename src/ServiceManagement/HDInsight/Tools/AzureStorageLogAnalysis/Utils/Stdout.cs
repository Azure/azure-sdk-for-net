namespace AzureLogTool
{
    using System;
    using System.IO;

    internal static class Stdout
    {
        internal static bool Verbose = false;

        internal static void TeeWriteLine(TextWriter w, string msg = "")
        {
            w.WriteLine(msg);
            Console.WriteLine(msg);
        }

        internal static void VerboseWrite(string msg)
        {
            if (Verbose)
            {
                Console.Write(msg);
            }
        }

        internal static void VerboseWriteLine(string msg = "")
        {
            if (Verbose)
            {
                Console.WriteLine(msg);
            }
        }

        internal static void Write(string msg = "")
        {
            Console.Write(msg);
        }

        internal static void WriteLine(string msg = "")
        {
            Console.WriteLine(msg);
        }
    }
}
