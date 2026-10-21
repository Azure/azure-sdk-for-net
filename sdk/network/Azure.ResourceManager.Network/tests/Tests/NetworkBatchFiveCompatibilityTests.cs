// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class NetworkBatchFiveCompatibilityTests
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
        public void CloudServiceSwapAliasRemainsConnectedAndIsHidden()
        {
            var value = new CloudServiceSwapData();
#pragma warning disable CS0618
            value.CloudServiceSwapSlotType = SwapSlotType.Production;
            Assert.That(value.SwapResourceSlotType, Is.EqualTo(value.CloudServiceSwapSlotType));
            value.SwapResourceSlotType = SwapSlotType.Staging;
            Assert.That(value.CloudServiceSwapSlotType, Is.EqualTo(value.SwapResourceSlotType));
#pragma warning restore CS0618

            var property = typeof(CloudServiceSwapData).GetProperty("CloudServiceSwapSlotType");
            Assert.That(Attribute.IsDefined(property, typeof(ObsoleteAttribute)), Is.True);
            Assert.That(((EditorBrowsableAttribute)Attribute.GetCustomAttribute(property, typeof(EditorBrowsableAttribute))).State, Is.EqualTo(EditorBrowsableState.Never));
        }

        [Test]
        public async Task CloudServiceSwapCollectionRetainsEmptyEnumeration()
        {
            var value = new TestCloudServiceSwapCollection();
            Assert.That((IEnumerable<CloudServiceSwapResource>)value, Is.Empty);
            Assert.That((IEnumerable)value, Is.Empty);
            await using var enumerator = ((IAsyncEnumerable<CloudServiceSwapResource>)value).GetAsyncEnumerator();
            Assert.That(await enumerator.MoveNextAsync(), Is.False);
        }

        private sealed class TestCloudServiceSwapCollection : CloudServiceSwapCollection
        {
        }
    }
}
