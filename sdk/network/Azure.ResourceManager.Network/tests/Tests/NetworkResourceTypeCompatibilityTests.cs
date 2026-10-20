// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
#pragma warning disable CS0618 // Verify the shipped obsolete Type aliases remain connected.
    public class NetworkResourceTypeCompatibilityTests
    {
        private const string ResourceTypeName = "Microsoft.Network/applicationGateways/authenticationCertificates";

        public static IEnumerable<TestCaseData> ResourceTypeFactoryCases()
        {
            foreach (var method in typeof(ArmNetworkModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                var type = method.ReturnType;
                if (!typeof(NetworkResourceData).IsAssignableFrom(type)
                    && !typeof(NetworkTrackedResourceData).IsAssignableFrom(type)
                    && !typeof(NetworkWritableResource).IsAssignableFrom(type)
                    && type != typeof(EndpointServiceResult)
                    && type != typeof(ApplicationGatewayAdvancedRoutingMap)
                    && type != typeof(ApplicationGatewayAdvancedRoutingConditionSet)
                    && type != typeof(ApplicationGatewayAdvancedRoutingRule)
                    && type != typeof(ExpressRouteLagLink)
                    && type != typeof(ExpressRouteLagMember))
                {
                    continue;
                }

                var parameters = method.GetParameters();
                int typeIndex = Array.FindIndex(parameters, p =>
                    (p.Name == "resourceType" && p.ParameterType == typeof(ResourceType?))
                    || (p.Name == "type" && p.ParameterType == typeof(string)));
                if (typeIndex < 0 || parameters.Any(p => !p.IsOptional))
                {
                    continue;
                }

                foreach (string value in new[] { null, ResourceTypeName })
                {
                    yield return new TestCaseData(method, typeIndex, value)
                        .SetName($"ResourceTypeFactory_{method.Name}_{parameters[typeIndex].Name}_{parameters.Length}_{(value is null ? "Null" : "Populated")}");
                }
            }
        }

        [TestCaseSource(nameof(ResourceTypeFactoryCases))]
        public void AllRelatedFactoryOverloadsPreserveResourceType(MethodInfo factory, int typeIndex, string value)
        {
            var parameters = factory.GetParameters();
            object[] arguments = parameters.Select(p => p.DefaultValue).ToArray();
            arguments[typeIndex] = parameters[typeIndex].ParameterType == typeof(string) ? (object)value : ToResourceType(value);
            var model = factory.Invoke(null, arguments);
            var property = factory.ReturnType.GetProperty("ResourceType", typeof(ResourceType?))
                ?? factory.ReturnType.GetProperty("ResourceType", typeof(ResourceType));
            var expected = property.PropertyType == typeof(ResourceType) ? (object)(ToResourceType(value) ?? default) : ToResourceType(value);

            Assert.AreEqual(expected, property.GetValue(model), factory.ToString());
            if (factory.ReturnType == typeof(ApplicationGatewayAdvancedRoutingMap)
                || factory.ReturnType == typeof(ApplicationGatewayAdvancedRoutingConditionSet)
                || factory.ReturnType == typeof(ApplicationGatewayAdvancedRoutingRule))
            {
                Assert.IsNull(factory.ReturnType.GetProperty("Type"), factory.ToString());
            }
            else
            {
                Assert.AreEqual(value, factory.ReturnType.GetProperty("Type").GetValue(model), factory.ToString());
            }
        }

        [TestCase("{}")]
        [TestCase("{\"type\":null}")]
        [TestCase("{\"type\":\"" + ResourceTypeName + "\"}")]
        public void DeserializeNetworkResourcePreservesResourceType(string json)
        {
            var model = ModelReaderWriter.Read<NetworkResourceData>(BinaryData.FromString(json));
            using var document = JsonDocument.Parse(json);
            string expected = document.RootElement.TryGetProperty("type", out var type) ? type.GetString() : null;

            AssertResourceType(model, expected);
        }

        [TestCase(null)]
        [TestCase(ResourceTypeName)]
        public void StandaloneOptionalNativeMetadataPreservesResourceType(string value)
        {
            var json = BinaryData.FromString(JsonSerializer.Serialize(new { type = value }));
            AssertWireType(ModelReaderWriter.Read<ApplicationGatewayAdvancedRoutingMap>(json), value, m => m.ResourceType, null);
            AssertWireType(ModelReaderWriter.Read<ApplicationGatewayAdvancedRoutingConditionSet>(json), value, m => m.ResourceType, null);
            AssertWireType(ModelReaderWriter.Read<ApplicationGatewayAdvancedRoutingRule>(json), value, m => m.ResourceType, null);
        }

        [Test]
        public void StandaloneRequiredMetadataAliasesPreserveResourceType()
        {
            var json = BinaryData.FromString("{\"type\":\"" + ResourceTypeName + "\"}");
            AssertWireType(ModelReaderWriter.Read<ExpressRouteLagLink>(json), ResourceTypeName, m => m.ResourceType, m => m.Type);
            AssertWireType(ModelReaderWriter.Read<ExpressRouteLagMember>(json), ResourceTypeName, m => m.ResourceType, m => m.Type);
        }

        [TestCase(null, false)]
        [TestCase(ResourceTypeName, false)]
        [TestCase(null, true)]
        [TestCase(ResourceTypeName, true)]
        public void NetworkResourceFactoryPreservesResourceType(string value, bool useTypedOverload)
        {
            var model = useTypedOverload
                ? ArmNetworkModelFactory.NetworkResourceData(resourceType: ToResourceType(value))
                : ArmNetworkModelFactory.NetworkResourceData(type: value);

            AssertResourceType(model, value);
        }

        [TestCase(null, false)]
        [TestCase(ResourceTypeName, false)]
        [TestCase(null, true)]
        [TestCase(ResourceTypeName, true)]
        public void AuthenticationCertificateFactoryPreservesResourceType(string value, bool useTypedOverload)
        {
            var model = useTypedOverload
                ? ArmNetworkModelFactory.ApplicationGatewayAuthenticationCertificate(resourceType: ToResourceType(value))
                : ArmNetworkModelFactory.ApplicationGatewayAuthenticationCertificate(type: value);

            AssertResourceType(model, value);
        }

        [Test]
        public void ResourceTypeIsPreferredTypedProperty()
        {
            foreach (var modelType in new[] { typeof(NetworkResourceData), typeof(NetworkTrackedResourceData), typeof(EndpointServiceResult), typeof(NetworkWritableResource), typeof(PolicySignaturesOverridesForIdpsData) })
            {
                var property = modelType.GetProperty("ResourceType");
                Assert.AreEqual(typeof(ResourceType?), property.PropertyType, modelType.Name);
                Assert.IsTrue(property.CanWrite, modelType.Name);
                Assert.IsNull(property.GetCustomAttribute<ObsoleteAttribute>(), modelType.Name);
                Assert.AreNotEqual(EditorBrowsableState.Never, property.GetCustomAttribute<EditorBrowsableAttribute>()?.State, modelType.Name);
                Assert.NotNull(modelType.GetProperty("Type").GetCustomAttribute<ObsoleteAttribute>(), modelType.Name);
            }
        }

        [TestCase(null)]
        [TestCase(ResourceTypeName)]
        public void TrackedResourceFactoriesPreserveResourceType(string value)
        {
            AssertWireType(ArmNetworkModelFactory.NetworkTrackedResourceData(resourceType: ToResourceType(value)), value, m => m.ResourceType, m => m.Type);
            AssertWireType(ArmNetworkModelFactory.NetworkTrackedResourceData(type: value), value, m => m.ResourceType, m => m.Type);
        }

        [TestCase(null)]
        [TestCase(ResourceTypeName)]
        public void EndpointServiceFactoriesPreserveResourceType(string value)
        {
            AssertWireType(ArmNetworkModelFactory.EndpointServiceResult(resourceType: ToResourceType(value)), value, m => m.ResourceType, m => m.Type);
            AssertWireType(ArmNetworkModelFactory.EndpointServiceResult(type: value), value, m => m.ResourceType, m => m.Type);
        }

        [TestCase(null)]
        [TestCase(ResourceTypeName)]
        public void WritableResourceFactoryPreservesResourceType(string value)
        {
            AssertWireType(ArmNetworkModelFactory.PolicySignaturesOverridesForIdpsData(type: value), value, m => m.ResourceType, m => m.Type, writable: true);
        }

        [Test]
        public void CompatibleSettersUpdateNativeStorage()
        {
            AssertSetter(new NetworkResourceData(), (m, v) => m.ResourceType = v, m => m.ResourceType, m => m.Type);
            AssertSetter(new NetworkTrackedResourceData(), (m, v) => m.ResourceType = v, m => m.ResourceType, m => m.Type);
            AssertSetter(ArmNetworkModelFactory.EndpointServiceResult(type: null), (m, v) => m.ResourceType = v, m => m.ResourceType, m => m.Type);
            AssertSetter(new PolicySignaturesOverridesForIdpsData(), (m, v) => m.ResourceType = v, m => m.ResourceType, m => m.Type, writable: true);

            var writable = new PolicySignaturesOverridesForIdpsData();
            writable.Type = ResourceTypeName;
            AssertWireType(writable, ResourceTypeName, m => m.ResourceType, m => m.Type, writable: true);
            writable.Type = null;
            AssertWireType(writable, null, m => m.ResourceType, m => m.Type, writable: true);
        }

        [TestCase(null)]
        [TestCase(ResourceTypeName)]
        public void LegacySslOptionsFactoryPreservesMetadata(string value)
        {
            var model = ArmNetworkModelFactory.ApplicationGatewayAvailableSslOptionsInfo(resourceType: ToResourceType(value));
            AssertWireType(model, value, m => ((NetworkTrackedResourceData)m).ResourceType, m => m.Type);
            Assert.AreEqual(ToResourceType(value) ?? default, model.ResourceType);
        }

        [TestCase(null)]
        [TestCase(ResourceTypeName)]
        public void LegacyInboundRuleFactoryPreservesMetadata(string value)
        {
            var model = ArmNetworkModelFactory.InboundSecurityRule(resourceType: ToResourceType(value), ruleType: null);
            AssertWireType(model, value, m => m.ResourceType, m => m.Type);
            InboundSecurityRuleData converted = model;
            AssertResourceType(converted, value);
        }

        [TestCase(null)]
        [TestCase(ResourceTypeName)]
        public void CustomApplianceFactoryPreservesResourceType(string value)
        {
            var model = ArmNetworkModelFactory.VirtualNetworkApplianceData(resourceType: ToResourceType(value));
            AssertWireType(model, value, m => m.ResourceType, m => m.Type);
        }

        [TestCase(null)]
        [TestCase(ResourceTypeName)]
        public void CustomP2SFactoryPreservesResourceType(string value)
        {
            var model = ArmNetworkModelFactory.P2SConnectionConfiguration(
                id: null, name: null, resourceType: ToResourceType(value), etag: null,
                vpnClientAddressPrefixes: null, routingConfiguration: null, enableInternetSecurity: null,
                configurationPolicyGroupAssociations: null, previousConfigurationPolicyGroupAssociations: null,
                provisioningState: null);
            AssertWireType(model, value, m => m.ResourceType, m => m.Type);
        }

        [Test]
        public void SslPredefinedPolicyPrefersWireMetadataOverId()
        {
            var model = ModelReaderWriter.Read<ApplicationGatewaySslPredefinedPolicy>(
                BinaryData.FromString("{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies/policy\",\"type\":\"" + ResourceTypeName + "\"}"));
            Assert.AreEqual(new ResourceType(ResourceTypeName), model.ResourceType);
            AssertWireType(model, ResourceTypeName, m => ((NetworkResourceData)m).ResourceType, m => m.Type);
        }

        private static ResourceType? ToResourceType(string value)
            => value is null ? (ResourceType?)null : new ResourceType(value);

        private static void AssertResourceType(NetworkResourceData model, string expected)
            => AssertWireType(model, expected, m => m.ResourceType, m => m.Type);

        private static void AssertSetter<T>(T model, Action<T, ResourceType?> set, Func<T, ResourceType?> get, Func<T, string> getAlias, bool writable = false)
        {
            set(model, null);
            AssertWireType(model, null, get, getAlias, writable);
            set(model, new ResourceType(ResourceTypeName));
            AssertWireType(model, ResourceTypeName, get, getAlias, writable);
            set(model, null);
            AssertWireType(model, null, get, getAlias, writable);
        }

        private static void AssertWireType<T>(T model, string expected, Func<T, ResourceType?> get, Func<T, string> getAlias, bool writable = false)
        {
            Assert.AreEqual(ToResourceType(expected), get(model));
            if (getAlias is null)
            {
                Assert.IsNull(typeof(T).GetProperty("Type"));
            }
            else
            {
                Assert.AreEqual(expected, getAlias(model));
            }

            var persisted = ModelReaderWriter.Write(model);
            using var document = JsonDocument.Parse(persisted.ToString());
            if (expected is null)
            {
                Assert.IsFalse(document.RootElement.TryGetProperty("type", out _));
            }
            else
            {
                Assert.AreEqual(expected, document.RootElement.GetProperty("type").GetString());
            }

            using var wire = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")).ToString());
            if (writable && expected is not null)
            {
                Assert.AreEqual(expected, wire.RootElement.GetProperty("type").GetString());
            }
            else
            {
                Assert.IsFalse(wire.RootElement.TryGetProperty("type", out _));
            }

            var roundTrip = ModelReaderWriter.Read<T>(persisted);
            Assert.AreEqual(ToResourceType(expected), get(roundTrip));
            if (getAlias is not null)
            {
                Assert.AreEqual(expected, getAlias(roundTrip));
            }
        }
    }
#pragma warning restore CS0618
}
