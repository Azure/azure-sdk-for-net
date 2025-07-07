// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    internal class ResourceRenameTests
    {
        [TestCase]
        public void Verify_ModelFactoryRenameTypeToResourceType()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            //var modelFactory = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ModelFactoryProvider) as ModelFactoryProvider;

            //Assert.NotNull(modelFactory);
            //Assert.AreEqual(1, modelFactory!.Methods.Count);
            //var resourceTypeParameter = modelFactory.Methods[0].Signature.Parameters.SingleOrDefault(p => p.Name.Equals("resourceType", StringComparison.OrdinalIgnoreCase));

            var model = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ModelProvider) as ModelProvider;
            Assert.NotNull(model);
            var resourceTypeProperty = model!.Properties.SingleOrDefault(p => p.Name.Equals("ResourceType", StringComparison.OrdinalIgnoreCase));
            Assert.NotNull(resourceTypeProperty);
            Assert.True(resourceTypeProperty?.Type.Equals(typeof(ResourceType)));
        }
    }
}
