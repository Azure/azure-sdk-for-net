// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System.Linq;

namespace Azure.Generator.Tests.Providers
{
    internal class ResourceProviderTests
    {
        [TestCase]
        public void Verify_ResourceProviderGeneration()
        {
            var (client, models) = InputData.ClientWithResource();
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);

            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceProvider) as ResourceProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;

            var exptected = Helpers.GetExpectedFromFile();

            Assert.AreEqual(exptected, result);
        }
    }
}
