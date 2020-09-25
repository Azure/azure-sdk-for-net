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
    ///
    ///   The main entry point for executing the samples.
    ///
    ///   To run a sample, after a successful build, go to the following folder:
    ///
    ///   "artifacts\bin\Azure.Messaging.EventHubs.Samples\Debug\"
    ///
    ///   If using .NET Core, move to the corresponding sub-folder and launch
    ///   one of the following commands from command line:
    ///
    ///      dotnet Azure.Messaging.EventHubs.Samples.dll `
    ///          --ConnectionString "<< YOUR_CONNECTION_STRING >>" `
    ///          --EventHub "<< YOUR_EVENT_HUB_NAME >>"
    ///
    ///   To run an identity sample extra parameters will be needed:
    ///
    ///      dotnet Azure.Messaging.EventHubs.Samples.dll `
    ///          --FullyQualifiedNamespace "{yournamespace}.servicebus.windows.net" `
    ///          --EventHub "<< YOUR_EVENT_HUB_NAME >>" `
    ///          --Tenant "<< YOUR_TENANT_ID >>" `
    ///          --Client "<< YOUR_CLIENT_ID >>" `
    ///          --Secret "<< YOUR_SECRET_ID >>"
    ///
    ///   To run a SchemaRegistry sample extra parameters will be needed:
    ///
    ///      dotnet Azure.Messaging.EventHubs.Samples.dll `
    ///          --FullyQualifiedNamespace "{yournamespace}.servicebus.windows.net" `
    ///          --EventHub "<< YOUR_EVENT_HUB_NAME >>" `
    ///          --SchemaGroupName "<< YOUR_SCHEMA_GROUP_NAME >>" `
    ///          --Tenant "<< YOUR_TENANT_ID >>" `
    ///          --Client "<< YOUR_CLIENT_ID >>" `
    ///          --Secret "<< YOUR_SECRET_ID >>"
    ///
    /// </summary>
    ///
    public static class Program
    {
        /// <summary>
        ///   A set of controlling options displayed to the user on console.
        /// </summary>
        ///
        private static readonly string[] ExtraOptionsForSamples = new[]
        {
            "Explore Identity Samples",
            "Explore SchemaRegistry Samples"
        };

        /// <summary>
        ///   A set of controlling option displayed to the user if they choose to explore identity samples.
        /// </summary>
        ///
        private static readonly string[] ExtraOptionsForIdentitySamples = new[]
        {
            "Go Back"
        };

        /// <summary>
        ///   A set of controlling option displayed to the user if they choose to explore identity samples.
        /// </summary>
        ///
        private static readonly string[] ExtraOptionsForSchemaRegistrySamples = new[]
        {
            "Go Back"
        };

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

            ISample sample = RetrieveSample();

            if (sample == null)
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
                Console.WriteLine($"Running: { sample.Name }");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine();
            }

            // Run the chosen sample

            if (sample is IEventHubsSample eventHubsSample)
            {
                PromptConnectionStringIfMissing(parsedArgs);
                PromptEventHubNameIfMissing(parsedArgs);

                await eventHubsSample.RunAsync(parsedArgs.ConnectionString, parsedArgs.EventHub);
            }
            else if (sample is IEventHubsIdentitySample identitySample)
            {
                PromptFullyQualifiedNamespaceIfMissing(parsedArgs);
                PromptEventHubNameIfMissing(parsedArgs);
                PromptTenantIdIfMissing(parsedArgs);
                PromptClientIdIfMissing(parsedArgs);
                PromptSecretIfMissing(parsedArgs);

                await identitySample.RunAsync(parsedArgs.FullyQualifiedNamespace,
                                              parsedArgs.EventHub,
                                              parsedArgs.Tenant,
                                              parsedArgs.Client,
                                              parsedArgs.Secret);
            }
            else if (sample is IEventHubsSchemaRegistrySample schemaRegistrySample)
            {
                PromptFullyQualifiedNamespaceIfMissing(parsedArgs);
                PromptEventHubNameIfMissing(parsedArgs);
                PromptSchemaGroupNameIfMissing(parsedArgs);
                PromptTenantIdIfMissing(parsedArgs);
                PromptClientIdIfMissing(parsedArgs);
                PromptSecretIfMissing(parsedArgs);

                await schemaRegistrySample.RunAsync(parsedArgs.FullyQualifiedNamespace,
                    parsedArgs.EventHub,
                    parsedArgs.SchemaGroupName,
                    parsedArgs.Tenant,
                    parsedArgs.Client,
                    parsedArgs.Secret);
            }
        }

        /// <summary>
        ///   It prints a list of options to console for the user. It reads the user's
        ///   choice then it returns the chosen sample.
        /// </summary>
        ///
        /// <returns>A sample or null if that could not be determined.</returns>
        ///
        private static ISample RetrieveSample()
        {
            var samples = LocateSamples<IEventHubsSample>();

            PrintEventHubsSamples(samples);

            int? choice = ReadSelection(samples);

            if (IsEventHubsIdentity(samples, choice))
            {
                var identitySamples = LocateSamples<IEventHubsIdentitySample>();

                while (IsEventHubsIdentity(samples, choice))
                {
                    PrintEventHubsIdentitySamples(identitySamples);
                    choice = ReadSelection(identitySamples);

                    if (choice.HasValue && !IsGoBack(identitySamples, choice))
                    {
                        return identitySamples[choice.Value];
                    }
                    if (IsGoBack(identitySamples, choice))
                    {
                        return RetrieveSample();
                    }
                }
            }
            else if (IsEventHubsSchemaRegistry(samples, choice))
            {
                var schemaRegistrySamples = LocateSamples<IEventHubsSchemaRegistrySample>();

                while (IsEventHubsSchemaRegistry(samples, choice))
                {
                    PrintEventHubsSchemaRegistrySamples(schemaRegistrySamples);
                    choice = ReadSelection(schemaRegistrySamples);

                    if (choice.HasValue && !IsGoBack(schemaRegistrySamples, choice))
                    {
                        return schemaRegistrySamples[choice.Value];
                    }
                    if (IsGoBack(schemaRegistrySamples, choice))
                    {
                        return RetrieveSample();
                    }
                }
            }

            if (choice.HasValue)
            {
                return samples[choice.Value];
            }

            return null;
        }

        /// <summary>
        ///   It checks if an option is to go back.
        /// </summary>
        ///
        /// <param name="identitySamples">A list of identity samples</param>
        /// <param name="choice">The zero-based index referring to the option chosen from console</param>
        ///
        /// <returns>If the user has chosen to go back in the main sample listing.</returns>
        ///
        private static bool IsGoBack(IReadOnlyList<IEventHubsIdentitySample> identitySamples, int? choice)
        {
            return IsLastOption(identitySamples, ExtraOptionsForIdentitySamples.Length, choice);
        }

        /// <summary>
        ///   It checks if an option is to go back.
        /// </summary>
        ///
        /// <param name="schemaRegistrySamples">A list of SchemaRegistry samples</param>
        /// <param name="choice">The zero-based index referring to the option chosen from console</param>
        ///
        /// <returns>If the user has chosen to go back in the main sample listing.</returns>
        ///
        private static bool IsGoBack(IReadOnlyList<IEventHubsSchemaRegistrySample> schemaRegistrySamples, int? choice)
        {
            return IsLastOption(schemaRegistrySamples, ExtraOptionsForSchemaRegistrySamples.Length, choice);
        }

        /// <summary>
        ///   It checks if an option is to see the identity samples.
        /// </summary>
        ///
        /// <param name="samples">A list of samples</param>
        /// <param name="choice">The zero-based index referring to the option chosen from console</param>
        ///
        /// <returns>If the user has chosen to see the event hubs identity samples.</returns>
        ///
        private static bool IsEventHubsIdentity(IReadOnlyList<IEventHubsSample> samples, int? choice)
        {
            return IsLastOption(samples, ExtraOptionsForSamples.Length - 1, choice);
        }

        /// <summary>
        ///   It checks if an option is to see the SchemaRegistry samples.
        /// </summary>
        ///
        /// <param name="samples">A list of samples</param>
        /// <param name="choice">The zero-based index referring to the option chosen from console</param>
        ///
        /// <returns>If the user has chosen to see the event hubs SchemaRegistry samples.</returns>
        ///
        private static bool IsEventHubsSchemaRegistry(IReadOnlyList<IEventHubsSample> samples, int? choice)
        {
            return IsLastOption(samples, ExtraOptionsForSamples.Length, choice);
        }

        /// <summary>
        ///   It checks if an option is the last available.
        /// </summary>
        ///
        /// <param name="samples">A list of identity samples</param>
        /// <param name="numberOfExtraOptions">The number of extra options available for the category of samples</param>
        /// <param name="choice">The zero-based index referring to the option chosen from console</param>
        ///
        /// <typeparam name="TSampleCategory">The category of samples selected.</typeparam>
        ///
        /// <returns>If the users have chosen the last of the set of options that were presented to them.</returns>
        ///
        private static bool IsLastOption<TSampleCategory>(IReadOnlyList<TSampleCategory> samples, int? numberOfExtraOptions, int? choice)
        {
            return choice == (samples.Count + numberOfExtraOptions - 1);
        }

        /// <summary>
        ///   It prints to console a set of samples and controlling options.
        /// </summary>
        ///
        /// <param name="samples">A list of samples to be printed</param>
        ///
        private static void PrintEventHubsSamples(IReadOnlyList<ISample> samples)
        {
            PrintSamples(samples);

            // TODO: The -1 removes displaying the SchemaRegistry scenarios. See: https://github.com/Azure/azure-sdk-for-net/issues/15463
            for (int i = 0; i < ExtraOptionsForSamples.Length - 1; i++)
            {
                Console.WriteLine($"{ samples.Count + i + 1 }) { ExtraOptionsForSamples[i] }");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        ///   It prints to console a set of identity samples and controlling options.
        /// </summary>
        ///
        /// <param name="samples">A list of samples to be printed</param>
        ///
        private static void PrintEventHubsIdentitySamples(IReadOnlyList<ISample> samples)
        {
            PrintSamples(samples);

            for (int i = 0; i < ExtraOptionsForIdentitySamples.Length; i++)
            {
                Console.WriteLine($"{ samples.Count + i + 1 }) { ExtraOptionsForIdentitySamples[i] }");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        ///   It prints to console a set of SchemaRegistry samples and controlling options.
        /// </summary>
        ///
        /// <param name="samples">A list of samples to be printed</param>
        ///
        private static void PrintEventHubsSchemaRegistrySamples(IReadOnlyList<ISample> samples)
        {
            PrintSamples(samples);

            for (int i = 0; i < ExtraOptionsForSchemaRegistrySamples.Length; i++)
            {
                Console.WriteLine($"{ samples.Count + i + 1 }) { ExtraOptionsForSchemaRegistrySamples[i] }");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        ///   It prints to console a set of sample names and their description.
        /// </summary>
        ///
        /// <param name="samples">A list of samples to be printed</param>
        ///
        private static void PrintSamples(IReadOnlyList<ISample> samples)
        {
            // Display the set of available samples and allow the user to choose.

            Console.WriteLine();
            Console.WriteLine("Available Samples:");
            Console.WriteLine();

            for (var index = 0; index < samples.Count; ++index)
            {
                Console.WriteLine($"{ index + 1 }) { samples[index].Name }");
                Console.WriteLine($"\t{ samples[index].Description }");
                Console.WriteLine();
            }
        }

        /// <summary>
        ///   Prompt the user to insert the EventHubs connection string, if not
        ///   already passed it from command line.
        /// </summary>
        ///
        /// <param name="parsedArgs">The arguments passed from console.</param>
        ///
        private static void PromptConnectionStringIfMissing(CommandLineArguments parsedArgs)
        {
            // Prompt for the connection string, if it wasn't passed.

            while (string.IsNullOrEmpty(parsedArgs.ConnectionString))
            {
                Console.Write("Please provide the connection string for the Event Hubs namespace that you'd like to use and then press Enter: ");
                parsedArgs.ConnectionString = Console.ReadLine().Trim();
                Console.WriteLine();
            }
        }

        /// <summary>
        ///   Prompt the user to insert the EventHubs fully qualified name, if not
        ///   already passed it from command line.
        /// </summary>
        ///
        /// <param name="parsedArgs">The arguments passed from console.</param>
        ///
        private static void PromptEventHubNameIfMissing(CommandLineArguments parsedArgs)
        {
            // Prompt for the Event Hub name, if it wasn't passed.

            while (string.IsNullOrEmpty(parsedArgs.EventHub))
            {
                Console.Write("Please provide the name of the Event Hub that you'd like to use and then press Enter: ");
                parsedArgs.EventHub = Console.ReadLine().Trim();
                Console.WriteLine();
            }
        }

        /// <summary>
        ///   Prompt the user to insert the schema group name, if not
        ///   already passed it from command line.
        /// </summary>
        ///
        /// <param name="parsedArgs">The arguments passed from console.</param>
        ///
        private static void PromptSchemaGroupNameIfMissing(CommandLineArguments parsedArgs)
        {
            // Prompt for the schema group name, if it wasn't passed.

            while (string.IsNullOrEmpty(parsedArgs.SchemaGroupName))
            {
                Console.Write("Please provide the name of the schema group that you'd like to use and then press Enter: ");
                parsedArgs.SchemaGroupName = Console.ReadLine().Trim();
                Console.WriteLine();
            }
        }

        /// <summary>
        ///   Prompt the user to insert the Azure Active Directory service client id, if not
        ///   already passed it from command line.
        /// </summary>
        ///
        /// <param name="parsedArgs">The arguments passed from console.</param>
        ///
        private static void PromptClientIdIfMissing(CommandLineArguments parsedArgs)
        {
            // Prompt for the Event Hub name, if it wasn't passed.

            while (string.IsNullOrEmpty(parsedArgs.Client))
            {
                Console.Write("Please provide the Azure Active Directory client identifier of the service principal: ");
                parsedArgs.Client = Console.ReadLine().Trim();
                Console.WriteLine();
            }
        }

        /// <summary>
        ///   Prompt the user to insert the EventHubs fully qualified namespace, if not
        ///   already passed it from command line.
        /// </summary>
        ///
        /// <param name="parsedArgs">The arguments passed from console.</param>
        ///
        private static void PromptFullyQualifiedNamespaceIfMissing(CommandLineArguments parsedArgs)
        {
            // Prompt for the Fully Qualified Namespace, if it wasn't passed.

            while (string.IsNullOrEmpty(parsedArgs.FullyQualifiedNamespace))
            {
                Console.Write("Please provide the fully qualified Event Hubs namespace.  This is likely to be similar to {yournamespace}.servicebus.windows.net: ");
                parsedArgs.FullyQualifiedNamespace = Console.ReadLine().Trim();
                Console.WriteLine();
            }
        }

        /// <summary>
        ///   Prompt the user to insert the Azure Active Directory service principal secret, if not
        ///   already passed it from command line.
        /// </summary>
        ///
        /// <param name="parsedArgs">The arguments passed from console.</param>
        ///
        private static void PromptSecretIfMissing(CommandLineArguments parsedArgs)
        {
            // Prompt for the Secret, if it wasn't passed.

            while (string.IsNullOrEmpty(parsedArgs.Secret))
            {
                Console.Write("Please provide the Azure Active Directory secret of the service principal: ");
                parsedArgs.Secret = Console.ReadLine().Trim();
                Console.WriteLine();
            }
        }

        /// <summary>
        ///   Prompt the user to insert the Azure Active Directory tenant id, if not already passed it from
        ///   command line.
        /// </summary>
        ///
        /// <param name="parsedArgs">The arguments passed from console.</param>
        ///
        private static void PromptTenantIdIfMissing(CommandLineArguments parsedArgs)
        {
            // The Azure Active Directory tenant that holds the service principal.

            while (string.IsNullOrEmpty(parsedArgs.Tenant))
            {
                Console.Write("Please provide the Azure Active Directory tenant of the service principal: ");
                parsedArgs.Tenant = Console.ReadLine().Trim();
                Console.WriteLine();
            }
        }

        /// <summary>
        ///   Displays the help text for running the samples to the console output.
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
        ///   Reads the selection of the application's user from the console for samples.
        /// </summary>
        ///
        /// <param name="samples">The available samples.</param>
        ///
        /// <typeparam name="TSampleCategory">The interface associated with the category of samples.</typeparam>
        ///
        /// <returns>The validated selection that was made.</returns>
        ///
        private static int? ReadSelection<TSampleCategory>(IReadOnlyList<TSampleCategory> samples) => samples switch
        {
            IReadOnlyList<IEventHubsSample> eventHubSamples => ReadSelection(eventHubSamples.Count + ExtraOptionsForSamples.Length),
            IReadOnlyList<IEventHubsIdentitySample> identitySamples => ReadSelection(identitySamples.Count + ExtraOptionsForIdentitySamples.Length),
            IReadOnlyList<IEventHubsSchemaRegistrySample> schemaRegistrySamples => ReadSelection(schemaRegistrySamples.Count + ExtraOptionsForSchemaRegistrySamples.Length),
            _ => throw new ArgumentException()
        };

        /// <summary>
        ///   Reads the selection of the application's user from the console.
        /// </summary>
        ///
        /// <param name="optionsCount">The count of available options.</param>
        ///
        /// <returns>The validated selection that was made.</returns>
        ///
        private static int? ReadSelection(int optionsCount)
        {
            while (true)
            {
                Console.Write("Please enter the number of a sample to run or press \"X\" to exit: ");

                var value = Console.ReadLine();

                if (string.Equals(value, "X", StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                if (Int32.TryParse(value, out var choice))
                {
                    --choice;

                    if ((choice >= 0) && (choice < optionsCount))
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
                else if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.EventHub) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.EventHub = args[index + 1].Trim();
                }
                else if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.SchemaGroupName) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.SchemaGroupName = args[index + 1].Trim();
                }
                else if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.Client) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.Client = args[index + 1].Trim();
                }
                else if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.FullyQualifiedNamespace) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.FullyQualifiedNamespace = args[index + 1].Trim();
                }
                else if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.Tenant) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.Tenant = args[index + 1].Trim();
                }
                else if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.Secret) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.Secret = args[index + 1].Trim();
                }
            }

            return parsedArgs;
        }

        /// <summary>
        ///   Locates the samples within the solution and creates an instance
        ///   that can be inspected and run.
        /// </summary>
        ///
        /// <typeparam name="TSampleCategory">The interface associated with the category of samples that should be located.</typeparam>
        ///
        /// <returns>The set of samples defined in the solution.</returns>
        ///
        private static IReadOnlyList<TSampleCategory> LocateSamples<TSampleCategory>() =>
            typeof(Program)
              .Assembly
              .ExportedTypes
              .Where(type => (type.IsClass && typeof(TSampleCategory).IsAssignableFrom(type)))
              .Select(type => (TSampleCategory)Activator.CreateInstance(type))
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

            /// <summary>The name of the schema group in the Schema Registry.</summary>
            public string SchemaGroupName;

            /// <summary>The fully qualified Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c></summary>
            public string FullyQualifiedNamespace;

            /// <summary>The Azure Active Directory tenant that holds the service principal.</summary>
            public string Tenant;

            /// <summary>The Azure Active Directory client identifier of the service principal.</summary>
            public string Client;

            /// <summary>The Azure Active Directory secret of the service principal.</summary>
            public string Secret;

            /// <summary>A flag indicating whether or not help was requested.</summary>
            public bool Help;
        }
    }
}
