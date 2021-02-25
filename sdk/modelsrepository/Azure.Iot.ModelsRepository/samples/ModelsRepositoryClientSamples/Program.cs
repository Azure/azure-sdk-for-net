// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Diagnostics;
using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace Azure.Iot.ModelsRepository.Samples
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Forward all the events written to the console output with a specific format.
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (e, message) =>
                    Console.WriteLine("[{0:HH:mm:ss:fff}][{1}] {2}", DateTimeOffset.Now, e.Level, message),
                level: EventLevel.Verbose);

            // Client init samples
            ModelResolutionSamples.ClientInitialization();

            // Model Resolution samples
            await ModelResolutionSamples.ResolveExistingModelsFromEndpointAsync();
            await ModelResolutionSamples.ResolveExistingModelsFromLocalAsync();
            await ModelResolutionSamples.TryResolveFromEndpointButNotFoundAsync();
            await ModelResolutionSamples.TryResolveFromLocalButNotFoundAsync();
            await ModelResolutionSamples.TryResolveWithInvalidDtmi();

            // Parser integration samples
            await ParserIntegrationSamples.ParseAndResolveAsync();
            await ParserIntegrationSamples.ResolveAndParseAsync();
        }
    }
}
