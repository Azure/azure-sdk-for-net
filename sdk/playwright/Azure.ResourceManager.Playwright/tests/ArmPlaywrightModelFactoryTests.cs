// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Playwright.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Playwright.Tests
{
    public class ArmPlaywrightModelFactoryTests
    {
        [Test]
        public void WorkspacePropertiesFactoryPreservesReleasedOverload()
        {
            var overload = typeof(ArmPlaywrightModelFactory).GetMethod(
                nameof(ArmPlaywrightModelFactory.PlaywrightWorkspaceProperties),
                new[]
                {
                    typeof(PlaywrightProvisioningState?),
                    typeof(Uri),
                    typeof(PlaywrightEnablementStatus?),
                    typeof(PlaywrightEnablementStatus?),
                    typeof(string)
                });

            Assert.That(overload, Is.Not.Null);
            foreach (var parameter in overload.GetParameters())
            {
                Assert.That(parameter.IsOptional, Is.False);
            }

            Uri dataplaneUri = new Uri("https://example.com");
            PlaywrightWorkspaceProperties properties = ArmPlaywrightModelFactory.PlaywrightWorkspaceProperties(
                PlaywrightProvisioningState.Succeeded,
                dataplaneUri,
                PlaywrightEnablementStatus.Enabled,
                PlaywrightEnablementStatus.Disabled,
                "workspace-id");

            Assert.That(properties.ProvisioningState, Is.EqualTo(PlaywrightProvisioningState.Succeeded));
            Assert.That(properties.DataplaneUri, Is.EqualTo(dataplaneUri));
            Assert.That(properties.RegionalAffinity, Is.EqualTo(PlaywrightEnablementStatus.Enabled));
            Assert.That(properties.LocalAuth, Is.EqualTo(PlaywrightEnablementStatus.Disabled));
            Assert.That(properties.WorkspaceId, Is.EqualTo("workspace-id"));
            Assert.That(properties.SubnetId, Is.Null);
        }

        [Test]
        public void WorkspacePropertiesFactorySupportsDefaultArguments()
        {
            PlaywrightWorkspaceProperties properties = ArmPlaywrightModelFactory.PlaywrightWorkspaceProperties();

            Assert.That(properties.SubnetId, Is.Null);
            Assert.That(properties.WorkspaceId, Is.Null);
        }

        [Test]
        public void WorkspacePropertiesSubnetIdRoundTrips()
        {
            ResourceIdentifier subnetId = new ResourceIdentifier(
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/test-subnet");
            PlaywrightWorkspaceProperties properties = ArmPlaywrightModelFactory.PlaywrightWorkspaceProperties(subnetId: subnetId);

            BinaryData json = ModelReaderWriter.Write(properties);
            using JsonDocument document = JsonDocument.Parse(json);
            Assert.That(document.RootElement.GetProperty("subnetId").GetString(), Is.EqualTo(subnetId.ToString()));

            PlaywrightWorkspaceProperties deserialized = ModelReaderWriter.Read<PlaywrightWorkspaceProperties>(json);
            Assert.That(deserialized.SubnetId, Is.EqualTo(subnetId));
        }
    }
}
