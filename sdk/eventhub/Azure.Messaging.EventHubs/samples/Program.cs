// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   The main entry point for executing the samples.
    /// </summary>
    ///
    public static class Program
    {
        /// <summary>
        ///   Serves as the main entry point of the application.
        /// </summary>
        ///
        /// <param name="args">The set of command line arguments passed.</param>
        ///
        public static async Task Main(string[] args)
        {
            // Parse the command line arguments determine if help was explicitly requested or if the
            // needed information was passed.

            CommandLineArguments parsedArgs = ParseArguments(args);

            if (parsedArgs.Help)
            {
                DisplayHelp();
                return;
            }

            // Display the welcome message.

            Console.WriteLine();
            Console.WriteLine("=========================================");
            Console.WriteLine("Welcome to the Event Hubs client library!");
            Console.WriteLine("=========================================");
            Console.WriteLine();

            // Prompt for the connection string, if it wasn't passed.

            while (String.IsNullOrEmpty(parsedArgs.ConnectionString))
            {
                Console.Write("Please provide the connection string for the Event Hubs namespace that you'd like to use and then press Enter: ");
                parsedArgs.ConnectionString = Console.ReadLine().Trim();
                Console.WriteLine();
            }

            // Prompt for the Event Hub name, if it wasn't passed.

            while (String.IsNullOrEmpty(parsedArgs.EventHub))
            {
                Console.Write("Please provide the name of the Event Hub that you'd like to use and then press Enter: ");
                parsedArgs.EventHub = Console.ReadLine().Trim();
                Console.WriteLine();
            }

            // Display the set of available samples and allow them to be run.

            var samples = LocateSamples();

            Console.WriteLine();
            Console.WriteLine("Available Samples:");
            Console.WriteLine();

            for (var index = 0; index < samples.Count; ++index)
            {
                Console.WriteLine($"{ index + 1 }) { samples[index].Name }");
                Console.WriteLine($"\t{ samples[index].Description }");
                Console.WriteLine();
            }

            Console.WriteLine();
            var choice = ReadSelection(samples.Count);

            if (choice == null)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Quitting...");
                Console.WriteLine();
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine($"Running: { samples[choice.Value].Name }");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine();

                await samples[choice.Value].RunAsync(parsedArgs.ConnectionString, parsedArgs.EventHub);
                return;
            }
        }

        /// <summary>
        ///   Displays the help text for running the samples to the console
        ///   output.
        /// </summary>
        ///
        private static void DisplayHelp()
        {
            Console.WriteLine();
            Console.WriteLine($"{ typeof(Program).Namespace }");
            Console.WriteLine();
            Console.WriteLine("This executable allows for running the Azure Event Hubs client library samples.  Because");
            Console.WriteLine("the samples run against live Azure services, they require an Event Hubs namespace and an");
            Console.WriteLine("Event Hub under it in order to run.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Arguments:");
            Console.WriteLine($"\t{ nameof(CommandLineArguments.Help) }:");
            Console.WriteLine("\t\tDisplays this message.");
            Console.WriteLine();
            Console.WriteLine($"\t{ nameof(CommandLineArguments.ConnectionString) }:");
            Console.WriteLine("\t\tThe connection string to the Event Hubs namespace to use for the samples.");
            Console.WriteLine();
            Console.WriteLine($"\t{ nameof(CommandLineArguments.EventHub) }:");
            Console.WriteLine("\t\tThe name of the Event Hub under the namespace to use.");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine($"\tAzure.Messaging.EventHubs.Samples.exe");
            Console.WriteLine();
            Console.WriteLine($"\tAzure.Messaging.EventHubs.Samples.exe { CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.ConnectionString) } \"Endpoint=sb://fake.servicebus.windows.net/;SharedAccessKeyName=NotReal;SharedAccessKey=[FAKE];\" { CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.EventHub) } \"SomeHub\"");
            Console.WriteLine();
            Console.WriteLine("\tAzure.Messaging.EventHubs.Samples.exe \"Endpoint=sb://fake.servicebus.windows.net/;SharedAccessKeyName=NotReal;SharedAccessKey=[FAKE];\" \"SomeHub\"");
            Console.WriteLine();
            Console.WriteLine($"\tAzure.Messaging.EventHubs.Samples.exe { CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.Help) }");
            Console.WriteLine();
        }

        /// <summary>
        ///   Reads the selection of the application's user from the
        ///   console.
        /// </summary>
        ///
        /// <param name="sampleCount">The count of available samples.</param>
        ///
        /// <returns>The validated selection that was made.</returns>
        ///
        private static int? ReadSelection(int sampleCount)
        {
            while (true)
            {
                Console.Write("Please enter the number of a sample to run or press \"X\" to exit: ");

                var value = Console.ReadLine();

                if (String.Equals(value, "X", StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                if (Int32.TryParse(value, out var choice))
                {
                    --choice;

                    if ((choice >= 0) && (choice < sampleCount))
                    {
                        return choice;
                    }
                }
            }
        }

        /// <summary>
        ///   Parses the set of arguments read from the command line.
        /// </summary>
        ///
        /// <param name="args">The command line arguments.</param>
        ///
        /// <returns>The set of parsed arguments, with any values for known items captured and cleaned.</returns>
        ///
        private static CommandLineArguments ParseArguments(string[] args)
        {

            // If at least two arguments were passed with no argument designator, then assume they're values and
            // accept them positionally.

            if ((args.Length >= 2) && (!args[0].StartsWith(CommandLineArguments.ArgumentPrefix)) && (!args[1].StartsWith(CommandLineArguments.ArgumentPrefix)))
            {
                return new CommandLineArguments { ConnectionString = args[0], EventHub = args[1] };
            }

            var parsedArgs = new CommandLineArguments();

            // Enumerate the arguments that were passed, stopping one before the
            // end, since we're scanning forward by an item to retrieve values;  if a
            // command was passed in the last position, there was no accompanying value,
            // so it isn't useful.

            for (var index = 0; index < args.Length - 1; ++index)
            {
                // Remove any excess spaces to comparison purposes.

                args[index] = args[index].Trim();

                // Help is the only flag argument supported; check for it before making
                // assumptions about argument/value pairings that comprise the other tokens.

                if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.Help) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.Help = true;
                    continue;
                }

                // Since we're evaluating the next token in sequence as a value in the
                // checks that follow, if it is an argument, we'll skip to the next iteration.

                if (args[index + 1].StartsWith(CommandLineArguments.ArgumentPrefix))
                {
                    continue;
                }

                // If the current token is one of our known arguments, capture the next token in sequence as it's
                // value, since we've already ruled out that it is another argument name.

                if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.ConnectionString) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.ConnectionString = args[index + 1].Trim();
                }
                else if (args[index].Equals($"--{ nameof(CommandLineArguments.EventHub) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.EventHub = args[index + 1].Trim();
                }
            }

            return parsedArgs;
        }

        /// <summary>
        ///   Locates the samples within the solution and creates an instance
        ///   that can be inspected and run.
        /// </summary>
        ///
        /// <returns>The set of samples defined in the solution.</returns>
        ///
        private static IReadOnlyList<IEventHubsSample> LocateSamples() =>
            typeof(Program)
              .Assembly
              .ExportedTypes
              .Where(type => (type.IsClass && typeof(IEventHubsSample).IsAssignableFrom(type)))
              .Select(type => (IEventHubsSample)Activator.CreateInstance(type))
              .ToList();

        /// <summary>
        ///   Provides a local means of collecting and passing
        ///   the command line arguments received.
        /// </summary>
        ///
        private class CommandLineArguments
        {
            /// <summary>The sequence of characters that prefix a command-line argument.</summary>
            public const string ArgumentPrefix = "--";

            /// <summary>The connection string to the Azure Event Hubs namespace for samples.</summary>
            public string ConnectionString;

            /// <summary>The name of the Event Hub to use samples.</summary>
            public string EventHub;

            /// <summary>A flag indicating whether or not help was requested.</summary>
            public bool Help;
        }
    }
}
