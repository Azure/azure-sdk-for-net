// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.TestHelpers;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    public class ManagementTypeFactoryTests
    {
        [TestCase("Azure.ResourceManager.Compute", ExpectedResult = "Compute")]
        [TestCase("Azure.ResourceManager.Storage", ExpectedResult = "Storage")]
        [TestCase("Azure.ResourceManager.Network", ExpectedResult = "Network")]
        [TestCase("Azure.ResourceManager.PostgreSql.FlexibleServers", ExpectedResult = "PostgreSqlFlexibleServers")]
        [TestCase("Azure.ResourceManager", ExpectedResult = "AzureResourceManager")] // not sure what we should expect on this since we did not get there yet.
        public string ValidateResourceProviderName(string primaryNamespace)
        {
            var plugin = ManagementMockHelpers.LoadMockPlugin(primaryNamespace: primaryNamespace);
            return plugin.Object.TypeFactory.ResourceProviderName;
        }
    }
}
