// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using CommandLine;

namespace Azure.Iot.Hub.Service.Samples
{
    public class Program
    {
        /// <summary>
        /// Main entry point to the sample.
        /// </summary>
        public static async Task Main(string[] args)
        {
            // Parse and validate parameters

            CommandLineOptions options = null;
            ParserResult<CommandLineOptions> result = Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(parsedOptions =>
                {
                    options = parsedOptions;
                })
                .WithNotParsed(errors =>
                {
                    Environment.Exit(1);
                });

            // Instantiate the client
            IoTHubServiceClient hubClient = new IoTHubServiceClient(options.IotHubConnectionString);

            // Run the samples
            var moduleIdentityLifecycleSamples = new ModuleIdentityLifecycleSamples(hubClient);
            await moduleIdentityLifecycleSamples.RunSampleAsync();
        }
    }
}
