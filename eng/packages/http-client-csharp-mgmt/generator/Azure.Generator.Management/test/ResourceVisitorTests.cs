// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Mgmt.Tests
{
    internal class ResourceVisitorTests
    {
        [Test]
        public void OutputOnlyResourceCollectionPropertyUsesReadOnlyList()
        {
            var (client, inputModels) = InputResourceData.ClientWithResource(includeZonesList: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => inputModels, clients: () => [client]);

            var model = plugin.Object.TypeFactory.CreateModel(inputModels[0])!;

            Assert.That(model.Properties.Single(p => p.Name == "Zones").Type.FrameworkType, Is.EqualTo(typeof(IReadOnlyList<>)));
        }

        [Test]
        public void OutputOnlyResourceDictionaryPropertyUsesReadOnlyDictionary()
        {
            var (client, inputModels) = InputResourceData.ClientWithResource(isInputModel: true, isTagsReadOnly: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => inputModels, clients: () => [client]);

            var model = plugin.Object.TypeFactory.CreateModel(inputModels[0])!;

            Assert.That(model.Properties.Single(p => p.Name == "Tags").Type.FrameworkType, Is.EqualTo(typeof(IReadOnlyDictionary<,>)));
        }
    }
}
