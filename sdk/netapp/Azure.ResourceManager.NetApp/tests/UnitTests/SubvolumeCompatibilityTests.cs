// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class SubvolumeCompatibilityTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";

        [TestCase(null, "2026-08-01")]
        [TestCase("2026-08-15-preview", "2026-08-15-preview")]
        public async Task SubvolumeGetUsesLegacyVersionUnlessOverridden(string apiVersion, string expectedVersion)
        {
            ResourceIdentifier volumeId = NetAppVolumeResource.CreateResourceIdentifier(SubscriptionId, "group", "account", "pool", "volume");
            ResourceIdentifier subvolumeId = NetAppSubvolumeInfoResource.CreateResourceIdentifier(SubscriptionId, "group", "account", "pool", "volume", "subvolume");
            var response = new MockResponse(200);
            response.SetContent(JsonSerializer.Serialize(new { id = subvolumeId.ToString(), name = "subvolume" }));
            var transport = new MockTransport(response, response);
            var options = new ArmClientOptions { Transport = transport };
            if (apiVersion != null)
            {
                options.SetApiVersion(NetAppSubvolumeInfoResource.ResourceType, apiVersion);
            }
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);

            var fromVolume = await client.GetNetAppVolumeResource(volumeId).GetNetAppSubvolumeInfoAsync("subvolume");
            var fromClient = client.GetNetAppSubvolumeInfoResource(subvolumeId).Get();

            Assert.That(fromVolume.Value.Data.Id, Is.EqualTo(subvolumeId));
            Assert.That(fromClient.Value.Data.Id, Is.EqualTo(subvolumeId));
            Assert.That(transport.Requests.Count, Is.EqualTo(2));
            foreach (MockRequest request in transport.Requests)
            {
                Assert.That(request.Uri.Path, Is.EqualTo(subvolumeId.ToString()));
                Assert.That(request.Uri.Query, Is.EqualTo($"?api-version={expectedVersion}"));
            }
        }

        [Test]
        public void LegacyVolumeFlagRoundTripsOnWire()
        {
            var options = new ModelReaderWriterOptions("W");
            var volume = ModelReaderWriter.Read<NetAppVolumeData>(
                BinaryData.FromString("{\"location\":\"westus2\",\"properties\":{\"enableSubvolumes\":\"Enabled\"}}"),
                options, AzureResourceManagerNetAppContext.Default);
            Assert.That(volume.EnableSubvolumes, Is.EqualTo(EnableNetAppSubvolume.Enabled));

            volume.EnableSubvolumes = EnableNetAppSubvolume.Disabled;
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(volume, options, AzureResourceManagerNetAppContext.Default));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("enableSubvolumes").GetString(), Is.EqualTo("Disabled"));
        }
    }
}
