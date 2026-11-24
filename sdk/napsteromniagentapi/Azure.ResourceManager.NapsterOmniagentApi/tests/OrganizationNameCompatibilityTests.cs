// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.ResourceManager.NapsterOmniagentApi.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NapsterOmniagentApi.Tests
{
    public class OrganizationNameCompatibilityTests
    {
        [Test]
        public void LegacyNameUsesResourceName()
        {
            NapsterOrganizationData fromJson = ModelReaderWriter.Read<NapsterOrganizationData>(
                BinaryData.FromString("{\"name\":\"resource-name\"}"),
                ModelReaderWriterOptions.Json,
                AzureResourceManagerNapsterOmniagentApiContext.Default);
            Assert.That(fromJson.OrganizationName, Is.EqualTo("resource-name"));

            NapsterOrganizationData fromFactory = ArmNapsterOmniagentApiModelFactory.NapsterOrganizationData(
                name: "factory-name", organizationName: "legacy-argument");
            Assert.That(fromFactory.OrganizationName, Is.EqualTo("factory-name"));
            Assert.That(fromFactory.Name, Is.EqualTo("factory-name"));
        }
    }
}
