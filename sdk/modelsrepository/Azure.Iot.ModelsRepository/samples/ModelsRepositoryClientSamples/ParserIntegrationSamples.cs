// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.DigitalTwins.Parser;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Azure.Iot.ModelsRepository.Samples
{
    internal class ParserIntegrationSamples
    {
        public static async Task GetModelsAndParseAsync()
        {
            #region Snippet:IoTModelsRepositorySamplesParserIntegrationGetModelsAndParseAsync

            var dtmi = "dtmi:com:example:TemperatureController;1";
            var client = new ModelsRepositoryClient();
            IDictionary<string, string> models = await client.GetModelsAsync(dtmi).ConfigureAwait(false);
            var parser = new ModelParser();
            IReadOnlyDictionary<Dtmi, DTEntityInfo> parseResult = await parser.ParseAsync(models.Values.ToArray());
            Console.WriteLine($"{dtmi} resolved in {models.Count} interfaces with {parseResult.Count} entities.");

            #endregion Snippet:IoTModelsRepositorySamplesParserIntegrationGetModelsAndParseAsync
        }

        public static async Task ParseAndGetModelsWithExtensionAsync()
        {
            #region Snippet:IoTModelsRepositorySamplesParserIntegrationParseAndGetModelsAsync

            var dtmi = "dtmi:com:example:TemperatureController;1";
            var client = new ModelsRepositoryClient(new ModelsRepositoryClientOptions(resolutionOption: DependencyResolutionOption.Disabled));
            IDictionary<string, string> models = await client.GetModelsAsync(dtmi).ConfigureAwait(false);
            var parser = new ModelParser
            {
                // Usage of the ModelsRepositoryClientExtensions.ParserDtmiResolver extension.
                DtmiResolver = client.ParserDtmiResolver
            };
            IReadOnlyDictionary<Dtmi, DTEntityInfo> parseResult = await parser.ParseAsync(models.Values.Take(1).ToArray());
            Console.WriteLine($"{dtmi} resolved in {models.Count} interfaces with {parseResult.Count} entities.");

            #endregion Snippet:IoTModelsRepositorySamplesParserIntegrationParseAndGetModelsAsync
        }
    }
}
