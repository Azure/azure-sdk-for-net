// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.NapsterOmniagentApi.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NapsterOmniagentApi.Tests
{
    public class ModelFactoryTests
    {
        [TestCase("resource", "legacy")]
        [TestCase(null, "legacy")]
        [TestCase("resource", null)]
        public void NapsterOrganizationDataIgnoresLegacyName(string name, string legacyName)
        {
            var data = ArmNapsterOmniagentApiModelFactory.NapsterOrganizationData(name: name, organizationName: legacyName);
            Assert.That(data.Name, Is.EqualTo(name));
#pragma warning disable CS0618 // Verify the obsolete property remains an alias for Name.
            Assert.That(data.OrganizationName, Is.EqualTo(name));
#pragma warning restore CS0618
        }
    }
}
