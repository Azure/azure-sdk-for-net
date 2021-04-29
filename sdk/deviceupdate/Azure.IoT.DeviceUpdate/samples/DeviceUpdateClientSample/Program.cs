// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace ConsoleTest
{
    /// <summary>
    /// Main program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry-point for this sample application.
        /// </summary>
        /// <param name="args">An array of command-line argument strings.</param>
        /// <returns>
        /// An asynchronous result that yields exit-code for the process - 0 for success, else an error code.
        /// </returns>
        static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand("Device Update for IoT Hub client library for .NET sample");
            rootCommand.AddOption(new Option("--tenant", "AAD tenant id") { Argument = new Argument<string>(() => Environment.GetEnvironmentVariable("DEVICEUPDATE_TENANT_ID")), IsRequired = true });
            rootCommand.AddOption(new Option("--client", "AAD client id") { Argument = new Argument<string>(() => Environment.GetEnvironmentVariable("DEVICEUPDATE_CLIENT_ID")), IsRequired = true });
            rootCommand.AddOption(new Option("--clientSecret", "AAD client secret") { Argument = new Argument<string>(() => Environment.GetEnvironmentVariable("DEVICEUPDATE_CLIENT_SECRET")), IsRequired = true });
            rootCommand.AddOption(new Option("--accountEndpoint", "ADU account endpoint") { Argument = new Argument<string>(() => Environment.GetEnvironmentVariable("DEVICEUPDATE_ACCOUNT_ENDPOINT")), IsRequired = true });
            rootCommand.AddOption(new Option("--instance", "ADU instance id") { Argument = new Argument<string>(() => Environment.GetEnvironmentVariable("DEVICEUPDATE_INSTANCE_ID")), IsRequired = true });
            rootCommand.AddOption(new Option("--connectionString", "Azure Storage account connection string") { Argument = new Argument<string>(() => $"DefaultEndpointsProtocol=https;AccountName={Environment.GetEnvironmentVariable("DEVICEUPDATE_STORAGE_NAME")};AccountKey={Environment.GetEnvironmentVariable("DEVICEUPDATE_STORAGE_KEY")};EndpointSuffix=core.windows.net"), IsRequired = true });
            rootCommand.AddOption(new Option("--device", "Registered ADU simulator device id") { Argument = new Argument<string>(), IsRequired = true });
            rootCommand.AddOption(new Option("--deviceTag", "IoT Hub device tag") { Argument = new Argument<string>(), IsRequired = true });
            rootCommand.AddOption(new Option("--delete", "Delete update when finished") { Argument = new Argument<bool>(), IsRequired = false });
            
            rootCommand.Handler = CommandHandler.Create<Arguments>(async (Arguments arguments) =>
            {
                Console.WriteLine("Device Update for IoT Hub client library for .NET sample");
                Console.WriteLine();

                // Sample runner that will exercise the following:
                // * publish new update 
                // * retrieve the newly imported update
                // * create deployment/device group
                // * check that device group contains devices that can be updated with our new update
                // * create deployment for our device group to deploy our new update
                // * check device and wait until the new update is installed there
                // * check that device group contains *NO* devices that can be updated with our new update
                // * delete the update
                // * retrieve the deleted update and check that we get 404 (NotFound)
                await new Sample(
                        arguments.Tenant, 
                        arguments.Client, 
                        arguments.ClientSecret, 
                        arguments.AccountEndpoint, 
                        arguments.Instance, 
                        arguments.ConnectionString, 
                        arguments.Device, 
                        arguments.DeviceTag, 
                        arguments.Delete)
                    .RunAsync();
                
                ConsoleEx.WriteLine(ConsoleColor.Green, "Finished.");
                
                return 0;
            });

            return await rootCommand.InvokeAsync(args);
        }
    }
}
