// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;
using static Azure.ResourceManager.Network.Tests.CompatibilityTestHelpers;

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkNativePropertyRenameTests
    {
        [TestCase(typeof(ApplicationGatewayData), "AvailabilityZones", "Zones", "zones", typeof(IList<string>), false, """{"zones":["zone-a"]}""")]
        [TestCase(typeof(ApplicationGatewayPrivateEndpointConnectionData), "ConnectionState", "PrivateLinkServiceConnectionState", "properties.privateLinkServiceConnectionState", typeof(NetworkPrivateLinkServiceConnectionState), true, """{"properties":{"privateLinkServiceConnectionState":{"status":"Approved"}}}""")]
        [TestCase(typeof(CloudServiceSwapData), "CloudServiceSwapSlotType", "SwapResourceSlotType", "properties.slotType", typeof(SwapSlotType?), true, """{"properties":{"slotType":"Production"}}""")]
        [TestCase(typeof(ApplicationGatewayOnDemandProbe), "IsProbeProxyProtocolHeaderEnabled", "EnableProbeProxyProtocolHeader", "enableProbeProxyProtocolHeader", typeof(bool?), true, """{"enableProbeProxyProtocolHeader":true}""")]
        [TestCase(typeof(ConnectivityInformation), "NetworkConnectionStatus", "ConnectionStatus", "connectionStatus", typeof(NetworkConnectionStatus?), false, """{"connectionStatus":"Connected"}""")]
        [TestCase(typeof(Models.NetworkManagerDeploymentStatus), "DeploymentState", "DeploymentStatus", "deploymentStatus", typeof(NetworkManagerDeploymentState?), false, """{"deploymentStatus":"Deployed"}""")]
        [TestCase(typeof(NetworkPrivateLinkServiceConnection), "ConnectionState", "PrivateLinkServiceConnectionState", "properties.privateLinkServiceConnectionState", typeof(NetworkPrivateLinkServiceConnectionState), true, """{"properties":{"privateLinkServiceConnectionState":{"status":"Approved"}}}""")]
        [TestCase(typeof(NvaInterfaceConfigurationsProperties), "PropertiesType", "Type", "type", typeof(IList<NvaNicType>), false, """{"type":["PrivateNic"]}""")]
        [TestCase(typeof(TunnelConnectionHealth), "LastConnectionEstablishedOn", "LastConnectionEstablishedUtcTime", "lastConnectionEstablishedUtcTime", typeof(string), false, """{"lastConnectionEstablishedUtcTime":"2026-01-01T00:00:00Z"}""")]
        public void ReleasedNameIsNativeAndRetainsWireContract(Type modelType, string name, string alias, string wirePath, Type propertyType, bool writable, string payload)
        {
            PropertyInfo property = modelType.GetProperty(name);
            Assert.That(property, Is.Not.Null);
            Assert.That(property.PropertyType, Is.EqualTo(propertyType));
            Assert.That(property.GetMethod.IsPublic, Is.True);
            Assert.That(property.SetMethod?.IsPublic ?? false, Is.EqualTo(writable));
            Assert.That(property.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(modelType.GetProperty(alias), Is.Null);
            Assert.That(GetWirePath(property), Is.EqualTo(wirePath));
            Assert.That(modelType.GetProperties().Count(p => GetWirePath(p) == wirePath), Is.EqualTo(1));

            CheckRoundTrip(modelType, payload, wirePath);
        }

        private static void CheckRoundTrip(Type modelType, string payload, string wirePath)
        {
            object model = ModelReaderWriter.Read(BinaryData.FromString(payload), modelType, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);
            using JsonDocument expected = JsonDocument.Parse(payload);
            using JsonDocument actual = JsonDocument.Parse(ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json));
            JsonElement expectedValue = expected.RootElement;
            JsonElement actualValue = actual.RootElement;
            string[] segments = wirePath.Split('.');
            foreach (string segment in segments)
            {
                Assert.That(actualValue.EnumerateObject().Count(p => p.Name == segment), Is.EqualTo(1));
                expectedValue = expectedValue.GetProperty(segment);
                actualValue = actualValue.GetProperty(segment);
            }
            Assert.That(actualValue.GetRawText(), Is.EqualTo(expectedValue.GetRawText()));
        }
    }
}
