// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.KeyVault.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    public class ModelFactoryCompatibilityTests
    {
        [Test]
        public void KeyVaultModelFactoryPreservesLegacyParameterOrder()
        {
            Dictionary<string, string> tags = new Dictionary<string, string> { ["environment"] = "test" };

            KeyVaultCreateOrUpdateContent content = ArmKeyVaultModelFactory.KeyVaultCreateOrUpdateContent(AzureLocation.WestUS2, tags);
            Assert.AreEqual(AzureLocation.WestUS2, content.Location);
            Assert.AreSame(tags, content.Tags);

            KeyVaultPatch patch = ArmKeyVaultModelFactory.KeyVaultPatch(tags);
            Assert.AreSame(tags, patch.Tags);
        }
    }
}
