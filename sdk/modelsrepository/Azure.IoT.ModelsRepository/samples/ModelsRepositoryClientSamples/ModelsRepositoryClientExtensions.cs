// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.DigitalTwins.Parser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.IoT.ModelsRepository.Samples
{
    internal static class ModelsRepositoryClientExtensions
    {
        /// <summary>
        /// The ParserDtmiResolver extension illustrates the simplicity of
        /// integrating the ModelsRepositoryClient with the Digital Twins Parser.
        /// See ParserIntegrationSamples.cs for example usage.
        /// </summary>
        public static async Task<IEnumerable<string>> ParserDtmiResolver(this ModelsRepositoryClient client, IReadOnlyCollection<Dtmi> dtmis)
        {
            IEnumerable<string> dtmiStrings = dtmis.Select(s => s.AbsoluteUri);
            List<string> modelDefinitions = new();
            foreach(var dtmi in dtmiStrings)
            {
                ModelResult result = await client.GetModelAsync(dtmi, ModelDependencyResolution.Disabled);
                modelDefinitions.Add(result.Content[dtmi]);
            }

            return modelDefinitions;
        }
    }
}
