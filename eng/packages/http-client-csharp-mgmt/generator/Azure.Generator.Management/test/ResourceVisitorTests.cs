// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
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
            var rendered = new TypeProviderWriter(model).Write().Content;

            Assert.That(model.Properties.Single(p => p.Name == "Zones").Type.FrameworkType, Is.EqualTo(typeof(IReadOnlyList<>)));
            Assert.That(rendered, Does.Contain("public global::System.Collections.Generic.IReadOnlyList<string> Zones"));
        }
    }
}
