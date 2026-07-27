// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Tests.TestHelpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.Generator.Management.Tests
{
    public class ArmProviderSchemaTests
    {
        [Test]
        public void FiltersRawMethodIdBeforeResolvingRemovedMethod()
        {
            IReadOnlyDictionary<string, BinaryData> arguments = new Dictionary<string, BinaryData>
            {
                ["nonResourceMethods"] = BinaryData.FromString("""[{"methodId":"Azure.ResourceManager.Operations.list"}]""")
            };
            var plugin = ManagementMockHelpers.LoadMockPlugin();

            var schema = ArmProviderSchema.Deserialize(
                arguments,
                library: plugin.Object.InputLibrary,
                shouldDeserializeMethod: methodId => methodId != "Azure.ResourceManager.Operations.list");

            Assert.That(schema.NonResourceMethods, Is.Empty);
        }
    }
}
