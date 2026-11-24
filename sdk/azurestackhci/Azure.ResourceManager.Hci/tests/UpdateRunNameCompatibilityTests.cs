// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.ResourceManager.Hci.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Hci.Tests
{
    public class UpdateRunNameCompatibilityTests
    {
        [Test]
        public void LegacyNameUsesResourceName()
        {
            HciClusterUpdateRunData fromJson = ModelReaderWriter.Read<HciClusterUpdateRunData>(
                BinaryData.FromString("{\"name\":\"resource-name\"}"),
                ModelReaderWriterOptions.Json,
                AzureResourceManagerHciContext.Default);
            Assert.That(fromJson.UpdateRunName, Is.EqualTo("resource-name"));

            HciClusterUpdateRunData fromFactory = ArmHciModelFactory.HciClusterUpdateRunData(
                id: null, name: "factory-name", resourceType: default, systemData: null, location: null,
                provisioningState: null, timeStarted: null, lastUpdatedOn: null, duration: null, state: null,
                namePropertiesProgressName: null, description: null, errorMessage: null, status: null,
                startOn: null, endOn: null, lastCompletedOn: null, expectedExecutionTime: null, steps: null);
            Assert.That(fromFactory.UpdateRunName, Is.EqualTo("factory-name"));
        }
    }
}
