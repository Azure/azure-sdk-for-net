// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.NapsterOmniagentApi.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NapsterOmniagentApi.Tests
{
    public class ModelFactoryTests
    {
        [TestCase("resource", "legacy", "legacy")]
        [TestCase(null, "legacy", "legacy")]
        [TestCase("resource", null, "resource")]
        public void NapsterOrganizationDataPreservesLegacyName(string name, string legacyName, string expected)
        {
            var data = ArmNapsterOmniagentApiModelFactory.NapsterOrganizationData(name: name, organizationName: legacyName);
            Assert.That(data.Name, Is.EqualTo(name));
            Assert.That(data.OrganizationName, Is.EqualTo(expected));
        }
    }
}
