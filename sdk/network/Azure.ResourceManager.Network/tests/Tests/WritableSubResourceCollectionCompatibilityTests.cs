// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class WritableSubResourceCollectionCompatibilityTests
    {
        private static readonly ResourceIdentifier TestResourceId =
            new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet");

        [Test]
        public void WritableSubResourceCollections_AreInitializedAndSerialized()
        {
            var backendHttpSettings = new ApplicationGatewayBackendHttpSettings();
            AssertCollection(
                backendHttpSettings,
                backendHttpSettings.AuthenticationCertificates,
                "authenticationCertificates");
            var trustedRootCertificates = new ApplicationGatewayBackendHttpSettings();
            AssertCollection(
                trustedRootCertificates,
                trustedRootCertificates.TrustedRootCertificates,
                "trustedRootCertificates");
        }

        [Test]
        public void ApplicationGatewayBackendSettings_TrustedRootCertificates_AreInitializedAndSerialized()
        {
            var model = new ApplicationGatewayBackendSettings();

            AssertCollection(
                model,
                model.TrustedRootCertificates,
                "trustedRootCertificates");
        }

        [Test]
        public void ApplicationGatewayRedirectConfiguration_Collections_AreInitializedAndSerialized()
        {
            var pathRules = new ApplicationGatewayRedirectConfiguration();
            AssertCollection(pathRules, pathRules.PathRules, "pathRules");

            var requestRoutingRules = new ApplicationGatewayRedirectConfiguration();
            AssertCollection(
                requestRoutingRules,
                requestRoutingRules.RequestRoutingRules,
                "requestRoutingRules");

            var urlPathMaps = new ApplicationGatewayRedirectConfiguration();
            AssertCollection(urlPathMaps, urlPathMaps.UrlPathMaps, "urlPathMaps");
        }

        [Test]
        public void ApplicationGatewaySslProfile_TrustedClientCertificates_AreInitializedAndSerialized()
        {
            var model = new ApplicationGatewaySslProfile();

            AssertCollection(
                model,
                model.TrustedClientCertificates,
                "trustedClientCertificates");
        }

        [Test]
        public void ContainerNetworkInterfaceConfiguration_ContainerNetworkInterfaces_AreInitializedAndSerialized()
        {
            var model = new ContainerNetworkInterfaceConfiguration();

            AssertCollection(
                model,
                model.ContainerNetworkInterfaces,
                "containerNetworkInterfaces");
        }

        [Test]
        public void NetworkSecurityPerimeterAccessRuleData_Subscriptions_AreInitializedAndSerialized()
        {
            var model = new NetworkSecurityPerimeterAccessRuleData();

            AssertCollection(
                model,
                model.Subscriptions,
                "subscriptions");
        }

        [Test]
        public void OutboundRuleData_FrontendIPConfigurations_AreInitializedAndSerialized()
        {
            var model = new OutboundRuleData();

            AssertCollection(
                model,
                model.FrontendIPConfigurations,
                "frontendIPConfigurations");
        }

        [Test]
        public void VngClientConnectionConfiguration_VirtualNetworkGatewayPolicyGroups_AreInitializedAndSerialized()
        {
            var model = new VngClientConnectionConfiguration();

            AssertCollection(
                model,
                model.VirtualNetworkGatewayPolicyGroups,
                "virtualNetworkGatewayPolicyGroups");
        }

        [Test]
        public void VpnSiteLinkConnectionData_NatRules_AreInitializedAndSerialized()
        {
            var egress = new VpnSiteLinkConnectionData();
            AssertCollection(egress, egress.EgressNatRules, "egressNatRules");

            var ingress = new VpnSiteLinkConnectionData();
            AssertCollection(ingress, ingress.IngressNatRules, "ingressNatRules");
        }

        private static void AssertCollection<T>(
            T model,
            IList<WritableSubResource> collection,
            string wireName)
            where T : IJsonModel<T>
        {
            Assert.NotNull(collection);

            collection.Add(new WritableSubResource
            {
                Id = TestResourceId
            });

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            ((IJsonModel<T>)model).Write(
                writer,
                new ModelReaderWriterOptions("W"));

            writer.Flush();

            using var document = JsonDocument.Parse(stream.ToArray());

            Assert.IsTrue(
                document.RootElement.TryGetProperty("properties", out var properties),
                "Expected serialized model to contain 'properties'.");

            Assert.IsTrue(
                properties.TryGetProperty(wireName, out var serializedCollection),
                $"Expected serialized properties to contain '{wireName}'.");

            Assert.AreEqual(JsonValueKind.Array, serializedCollection.ValueKind);
            Assert.AreEqual(1, serializedCollection.GetArrayLength());
            Assert.AreEqual(
                TestResourceId.ToString(),
                serializedCollection[0].GetProperty("id").GetString());
        }
    }
}
