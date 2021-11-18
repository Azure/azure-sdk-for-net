// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.DigitalTwins.Parser;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Azure.IoT.ModelsRepository.Samples
{
    internal class ParserIntegrationSamples
    {
        public static async Task GetModelAndParseAsync()
        {
            #region Snippet:ModelsRepositorySamplesParserIntegrationGetModelsAndParseAsync

            var client = new ModelsRepositoryClient();
            var dtmi = "dtmi:com:example:TemperatureController;1";
            ModelResult result = await client.GetModelAsync(dtmi).ConfigureAwait(false);
            var parser = new ModelParser();
            IReadOnlyDictionary<Dtmi, DTEntityInfo> parseResult = await parser.ParseAsync(result.Content.Values);
            Console.WriteLine($"{dtmi} resolved in {result.Content.Count} interfaces with {parseResult.Count} entities.");

            #endregion Snippet:ModelsRepositorySamplesParserIntegrationGetModelsAndParseAsync
        }

        public static async Task ParseAndGetModelWithExtensionAsync()
        {
            #region Snippet:ModelsRepositorySamplesParserIntegrationParseAndGetModelsAsync

            var client = new ModelsRepositoryClient();
            var dtmi = "dtmi:com:example:TemperatureController;1";
            ModelResult result = await client.GetModelAsync(dtmi, ModelDependencyResolution.Disabled).ConfigureAwait(false);
            var parser = new ModelParser
            {
                // Usage of the ModelsRepositoryClientExtensions.ParserDtmiResolver extension.
                DtmiResolver = client.ParserDtmiResolver
            };
            IReadOnlyDictionary<Dtmi, DTEntityInfo> parseResult = await parser.ParseAsync(result.Content.Values);
            Console.WriteLine($"{dtmi} resolved in {result.Content.Count} interfaces with {parseResult.Count} entities.");

            #endregion Snippet:ModelsRepositorySamplesParserIntegrationParseAndGetModelsAsync
        }
    }
}
