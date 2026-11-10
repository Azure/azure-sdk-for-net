// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkCollectionCompatibilityTests
    {
        private const string ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/loadBalancers/lb/inboundNatRules/rule";

        [Test]
        public void ActiveSecurityAdminRuleCollectionsReadFlattenedState()
        {
            var value = ModelReaderWriter.Read<ActiveSecurityAdminRule>(BinaryData.FromString("""
                {"kind":"Custom","properties":{"protocol":"Tcp","access":"Allow","priority":100,"direction":"Inbound","sources":[{"addressPrefix":"10.0.0.0/24","addressPrefixType":"IPPrefix"}],"destinations":[{"addressPrefix":"10.1.0.0/24","addressPrefixType":"IPPrefix"}],"sourcePortRanges":["1000"],"destinationPortRanges":["443"]}}
                """));

            Assert.That(value.Sources[0].AddressPrefix, Is.EqualTo("10.0.0.0/24"));
            Assert.That(value.Destinations[0].AddressPrefix, Is.EqualTo("10.1.0.0/24"));
            Assert.That(value.SourcePortRanges, Is.EqualTo(new[] { "1000" }));
            Assert.That(value.DestinationPortRanges, Is.EqualTo(new[] { "443" }));

            var restored = ModelReaderWriter.Read<ActiveSecurityAdminRule>(ModelReaderWriter.Write(value));
            Assert.That(restored.Sources[0].AddressPrefix, Is.EqualTo(value.Sources[0].AddressPrefix));
            Assert.That(restored.Destinations[0].AddressPrefix, Is.EqualTo(value.Destinations[0].AddressPrefix));
            Assert.That(restored.SourcePortRanges, Is.EqualTo(value.SourcePortRanges));
            Assert.That(restored.DestinationPortRanges, Is.EqualTo(value.DestinationPortRanges));
        }

        [Test]
        public void ActiveSecurityAdminRuleMissingPropertiesRemainNull()
        {
            var value = ModelReaderWriter.Read<ActiveSecurityAdminRule>(BinaryData.FromString("""{"kind":"Custom"}"""));

            Assert.That(value.Sources, Is.Null);
            Assert.That(value.Destinations, Is.Null);
            Assert.That(value.SourcePortRanges, Is.Null);
            Assert.That(value.DestinationPortRanges, Is.Null);
        }

        [Test]
        public void BackendAddressPoolCollectionsInitializeFlattenedState()
        {
            var value = new BackendAddressPoolData();

            Assert.That(value.InboundNatRules, Is.Empty);
            Assert.That(value.LoadBalancingRules, Is.Empty);
            Assert.That(value.OutboundRules, Is.Empty);
            Assert.That(value.InboundNatRules, Is.SameAs(value.InboundNatRules));
            Assert.That(value.LoadBalancingRules, Is.SameAs(value.LoadBalancingRules));
            Assert.That(value.OutboundRules, Is.SameAs(value.OutboundRules));
        }

        [Test]
        public void BackendAddressPoolCollectionsReadAndPersistFlattenedState()
        {
            var value = ModelReaderWriter.Read<BackendAddressPoolData>(BinaryData.FromString($$$"""
                {"properties":{"inboundNatRules":[{"id":"{{{ResourceId}}}"}],"loadBalancingRules":[{"id":"{{{ResourceId}}}"}],"outboundRules":[{"id":"{{{ResourceId}}}"}]}}
                """));

            Assert.That(value.InboundNatRules[0].Id.ToString(), Is.EqualTo(ResourceId));
            Assert.That(value.LoadBalancingRules[0].Id.ToString(), Is.EqualTo(ResourceId));
            Assert.That(value.OutboundRules[0].Id.ToString(), Is.EqualTo(ResourceId));
            using JsonDocument persisted = JsonDocument.Parse(ModelReaderWriter.Write(value));
            foreach (string wireName in new[] { "inboundNatRules", "loadBalancingRules", "outboundRules" })
            {
                Assert.That(persisted.RootElement.GetProperty("properties").GetProperty(wireName)[0].GetProperty("id").GetString(), Is.EqualTo(ResourceId));
            }
        }

        [Test]
        public void CloudServiceSwapUsesOnlyTheReleasedSlotProperty()
        {
            var value = new CloudServiceSwapData { CloudServiceSwapSlotType = SwapSlotType.Production };
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(value));
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("slotType").GetString(), Is.EqualTo("Production"));
            var property = typeof(CloudServiceSwapData).GetProperty("CloudServiceSwapSlotType");
            Assert.That(Attribute.IsDefined(property, typeof(ObsoleteAttribute)), Is.False);
            Assert.That(typeof(CloudServiceSwapData).GetProperty("SwapResourceSlotType"), Is.Null);
        }

        [Test]
        public async Task CloudServiceSwapCollectionEnumerationDelegatesToGetAll()
        {
            var value = new TestCloudServiceSwapCollection();
            Assert.That((IEnumerable<CloudServiceSwapResource>)value, Is.Empty);
            Assert.That((IEnumerable)value, Is.Empty);
            await using var enumerator = ((IAsyncEnumerable<CloudServiceSwapResource>)value).GetAsyncEnumerator();
            Assert.That(await enumerator.MoveNextAsync(), Is.False);
            Assert.That(value.SyncCalls, Is.EqualTo(2));
            Assert.That(value.AsyncCalls, Is.EqualTo(1));
        }

        private sealed class TestCloudServiceSwapCollection : CloudServiceSwapCollection
        {
            public int SyncCalls { get; private set; }
            public int AsyncCalls { get; private set; }

            public override Pageable<CloudServiceSwapResource> GetAll(CancellationToken cancellationToken = default)
            {
                SyncCalls++;
                return Pageable<CloudServiceSwapResource>.FromPages(new[]
                {
                    Page<CloudServiceSwapResource>.FromValues(Array.Empty<CloudServiceSwapResource>(), null, new MockResponse(200))
                });
            }

            public override AsyncPageable<CloudServiceSwapResource> GetAllAsync(CancellationToken cancellationToken = default)
            {
                AsyncCalls++;
                return AsyncPageable<CloudServiceSwapResource>.FromPages(new[]
                {
                    Page<CloudServiceSwapResource>.FromValues(Array.Empty<CloudServiceSwapResource>(), null, new MockResponse(200))
                });
            }
        }
    }
}
