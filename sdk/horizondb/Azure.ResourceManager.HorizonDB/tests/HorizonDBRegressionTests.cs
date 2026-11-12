// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HorizonDB.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HorizonDB.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class HorizonDBRegressionTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";

        [TestCase(false)]
        [TestCase(true)]
        public async Task RegionalCapabilityUsesCompleteIdentifier(bool async)
        {
            string expectedPath = $"/subscriptions/{SubscriptionId}/providers/Microsoft.HorizonDb/locations/westus2/capabilities/default";
            var response = new MockResponse(200);
            response.SetContent($"{{\"id\":\"{expectedPath}\",\"name\":\"default\",\"type\":\"Microsoft.HorizonDb/locations/capabilities\"}}");
            var transport = new MockTransport(response);
            var client = CreateClient(transport);
            var subscription = client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));
            var capability = subscription.GetHorizonDBCapability(AzureLocation.WestUS2);
            Assert.That(capability.Id.ToString(), Is.EqualTo(expectedPath));
            if (async)
            {
                await capability.GetAsync();
            }
            else
            {
                capability.Get();
            }
            Assert.That(transport.Requests.Single().Uri.ToUri().AbsolutePath, Is.EqualTo(expectedPath));
        }

        [Test]
        public void LegacyCapabilityAccessorRequiresExplicitLocation()
        {
            var client = CreateClient(new MockTransport());
            var subscription = client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));

            Assert.Throws<InvalidOperationException>(() => subscription.GetHorizonDBCapability());
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task AuthenticationListingUsesChildApiVersion(bool async, bool overrideChildVersion)
        {
            var response = new MockResponse(200);
            response.SetContent("{\"value\":[]}");
            var transport = new MockTransport(response);
            var options = new ArmClientOptions { Transport = transport };
            options.SetApiVersion(HorizonDBClusterResource.ResourceType, "cluster-override");
            if (overrideChildVersion)
            {
                options.SetApiVersion("Microsoft.HorizonDb/clusters/authentications", "authentication-override");
            }
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);
            var cluster = client.GetHorizonDBClusterResource(HorizonDBClusterResource.CreateResourceIdentifier(SubscriptionId, "rg", "cluster"));

            if (async)
            {
                await foreach (var item in cluster.GetAllAsync())
                {
                    Assert.Fail("Expected an empty authentication listing.");
                }
            }
            else
            {
                Assert.That(cluster.GetAll(), Is.Empty);
            }

            Assert.That(transport.Requests.Single().Uri.ToString(), Does.Contain("/clusters/cluster/authentications?"));
            string expectedVersion = overrideChildVersion ? "authentication-override" : "2026-10-01-preview";
            Assert.That(transport.Requests.Single().Uri.ToString(), Does.Contain($"api-version={expectedVersion}"));
        }

        [Test]
        public void NullMaintenanceDoesNotMaterializeWrapper()
        {
            var patch = new HorizonDBPoolPatchProperties { NodeCount = 2, MaintenanceManagementType = null };
            AssertMaintenanceOmitted(patch);
        }

        [Test]
        public void ClearingMaintenanceOmitsEmptyWrapper()
        {
            var patch = new HorizonDBPoolPatchProperties { NodeCount = 2, MaintenanceManagementType = HorizonDBScheduledMaintenanceManagementType.System };
            using (var json = JsonDocument.Parse(ModelReaderWriter.Write(patch, new ModelReaderWriterOptions("W"))))
            {
                Assert.That(json.RootElement.GetProperty("scheduledMaintenance").GetProperty("maintenanceManagementType").GetString(), Is.EqualTo("System"));
            }

            patch.MaintenanceManagementType = null;
            AssertMaintenanceOmitted(patch);
        }

        [Test]
        public void ClearingMaintenancePreservesUnknownWrapperProperties()
        {
            var patch = ModelReaderWriter.Read<HorizonDBPoolPatchProperties>(BinaryData.FromString(
                "{\"nodeCount\":2,\"scheduledMaintenance\":{\"maintenanceManagementType\":\"System\",\"futureSetting\":true}}"));
            patch.MaintenanceManagementType = null;

            using var json = JsonDocument.Parse(ModelReaderWriter.Write(patch));
            Assert.That(json.RootElement.GetProperty("nodeCount").GetInt32(), Is.EqualTo(2));
            Assert.That(json.RootElement.GetProperty("scheduledMaintenance").GetProperty("futureSetting").GetBoolean(), Is.True);
        }

        [Test]
        public void DesignatedPoolGetterToleratesMissingWrapper()
        {
            Assert.That(new HorizonDBClusterProperties().DesignatedPoolResourceId, Is.Null);
            Assert.That(ArmHorizonDBModelFactory.HorizonDBClusterProperties().DesignatedPoolResourceId, Is.Null);
            var id = HorizonDBPoolResource.CreateResourceIdentifier(SubscriptionId, "rg", "cluster", "pool");
            Assert.That(ArmHorizonDBModelFactory.HorizonDBClusterProperties(designatedPoolResourceId: id).DesignatedPoolResourceId, Is.EqualTo(id));
        }

        [TestCase("Provisioned")]
        [TestCase("FutureComputeModel")]
        public void CapabilityDiscriminatorIsPubliclyReadableAndRoundTrips(string type)
        {
            var capability = ModelReaderWriter.Read<HorizonDBComputeModelCapability>(BinaryData.FromString($"{{\"type\":\"{type}\"}}"));

            Assert.That(capability.Type.ToString(), Is.EqualTo(type));
            Assert.That(typeof(HorizonDBComputeModelCapability).GetProperty(nameof(HorizonDBComputeModelCapability.Type)).GetSetMethod(), Is.Null);
            if (type == "Provisioned")
            {
                Assert.That(capability, Is.InstanceOf<HorizonDBProvisionedComputeModelCapability>());
            }
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(capability));
            Assert.That(json.RootElement.GetProperty("type").GetString(), Is.EqualTo(type));
        }

        [Test]
        public void CapabilityFactoryInitializesKnownDiscriminator()
        {
            var capability = ArmHorizonDBModelFactory.HorizonDBProvisionedComputeModelCapability();
            Assert.That(capability.Type, Is.EqualTo(PoolComputeModelType.Provisioned));
        }

        [TestCase("00000000-0000-4000-8000-000000000001")]
        [TestCase("future-opaque-stream-id")]
        public void LogicalStreamIdPreservesStringContract(string logicalStreamId)
        {
            var model = ArmHorizonDBModelFactory.ChangeDataCaptureConfigurationProperties(
                databaseName: "database",
                usageProfile: ChangeDataCaptureUsageProfile.Mirroring,
                destinationResourceId: new ResourceIdentifier($"/subscriptions/{SubscriptionId}/resourceGroups/rg/providers/Microsoft.Fabric/capacities/capacity"),
                logicalStreamId: logicalStreamId,
                desiredState: ChangeDataCaptureDesiredState.Enabled,
                effectiveState: ChangeDataCaptureEffectiveState.Enabled);
            string publishedValue = model.LogicalStreamId;
            Assert.That(publishedValue, Is.EqualTo(logicalStreamId));

            var roundTrip = ModelReaderWriter.Read<ChangeDataCaptureConfigurationProperties>(ModelReaderWriter.Write(model));
            Assert.That(roundTrip.LogicalStreamId, Is.EqualTo(logicalStreamId));
        }

        private static ArmClient CreateClient(MockTransport transport)
            => new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });

        private static void AssertMaintenanceOmitted(HorizonDBPoolPatchProperties patch)
        {
            Assert.That(patch.MaintenanceManagementType, Is.Null);
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(patch, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.TryGetProperty("scheduledMaintenance", out _), Is.False);
            Assert.That(json.RootElement.GetProperty("nodeCount").GetInt32(), Is.EqualTo(2));
        }
    }
}
