// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using NUnit.Framework;
using System.Linq;

namespace Azure.Generator.Tests.Providers
{
    internal class ResourceDataProviderTests
    {
        [TestCase]
        public void ValidateResourceDataProviderIsGenerated()
        {
            var (client, models) = InputData.ClientWithResource();
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);

            var resourceDataProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceDataProvider) as ResourceDataProvider;
            Assert.NotNull(resourceDataProvider);

            var serializationProvider = resourceDataProvider?.SerializationProviders.FirstOrDefault();
            Assert.NotNull(serializationProvider);
            Assert.IsTrue(serializationProvider is ResourceDataSerializationProvider);
        }
    }
}
