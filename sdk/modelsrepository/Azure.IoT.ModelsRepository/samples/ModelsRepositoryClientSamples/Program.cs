// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Diagnostics;
using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace Azure.IoT.ModelsRepository.Samples
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
            GetModelSamples.ClientInitialization();

            // GetModel samples
            await GetModelSamples.GetModelFromGlobalRepoAsync();
            await GetModelSamples.GetModelFromLocalRepoAsync();
            await GetModelSamples.GetModelDisabledDependencyResolution();
            await GetModelSamples.TryGetModelFromGlobalRepoButNotFoundAsync();
            await GetModelSamples.TryGetModelFromLocalRepoButNotFoundAsync();
            await GetModelSamples.TryGetModelsWithInvalidDtmiAsync();

            // Parser integration samples
            await ParserIntegrationSamples.GetModelAndParseAsync();
            await ParserIntegrationSamples.ParseAndGetModelWithExtensionAsync();

            // DtmiConventions utility samples
            DtmiConventionsSamples.IsValidDtmi();
            DtmiConventionsSamples.GetModelUri();
        }
    }
}
