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
using static Azure.ResourceManager.Network.Tests.CompatibilityTestHelpers;

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkResourceTypeCompatibilityTests
    {
        private const string ResourceTypeName = "Microsoft.Network/applicationGateways/authenticationCertificates";

        public static IEnumerable<TestCaseData> ResourceTypeFactoryCases()
        {
            foreach (MethodInfo factory in typeof(ArmNetworkModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                if (factory.ReturnType.GetProperty("ResourceType") is null)
                    continue;

                ParameterInfo[] parameters = factory.GetParameters();
                int index = Array.FindIndex(parameters, parameter => parameter.Name == "resourceType" && parameter.ParameterType == typeof(ResourceType?));
                if (index < 0)
                    continue;

                foreach (string value in new[] { null, ResourceTypeName })
                {
                    yield return new TestCaseData(factory, value)
                        .SetName($"ResourceTypeFactory_{factory.Name}_{parameters.Length}_{(value is null ? "Null" : "Populated")}");
                }
            }
        }

        [TestCaseSource(nameof(ResourceTypeFactoryCases))]
        public void AllRelatedFactoryOverloadsPreserveResourceType(MethodInfo factory, string value)
        {
            object model = InvokeFactory(factory, "resourceType", value is null ? null : new ResourceType(value));
            Assert.That(factory.ReturnType.GetProperty("ResourceType").GetValue(model)?.ToString(), Is.EqualTo(value));
        }

        [TestCase(typeof(NetworkResourceData), false)]
        [TestCase(typeof(NetworkTrackedResourceData), false)]
        [TestCase(typeof(EndpointServiceResult), false)]
        [TestCase(typeof(NetworkWritableResourceData), true)]
        [TestCase(typeof(PolicySignaturesOverridesForIdpsData), true)]
        public void ResourceTypeRetainsItsReleasedVisibilityAndMutability(Type type, bool writable)
        {
            PropertyInfo property = type.GetProperty("ResourceType");
            Assert.That(property.PropertyType, Is.EqualTo(typeof(ResourceType?)));
            Assert.That(property.GetMethod.IsPublic, Is.True);
            Assert.That(property.SetMethod?.IsPublic ?? false, Is.EqualTo(writable));
            Assert.That(property.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(property.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.Not.EqualTo(EditorBrowsableState.Never));
            Assert.That(type.GetProperty("Type"), Is.Null);

            if (writable)
            {
                object model = Activator.CreateInstance(type);
                foreach (ResourceType? value in new ResourceType?[] { null, new ResourceType(ResourceTypeName), null })
                {
                    property.SetValue(model, value);
                    AssertWireType(model, type, value?.ToString());
                }
            }
        }

        [TestCase(typeof(NetworkResourceData))]
        [TestCase(typeof(NetworkTrackedResourceData))]
        [TestCase(typeof(EndpointServiceResult))]
        [TestCase(typeof(ApplicationGatewayAdvancedRoutingMap))]
        [TestCase(typeof(ApplicationGatewayAdvancedRoutingConditionSet))]
        [TestCase(typeof(ApplicationGatewayAdvancedRoutingRule))]
        public void OptionalMetadataPreservesMissingNullAndPopulatedValues(Type type)
        {
            foreach (string payload in new[] { "{}", """{"type":null}""", "{\"type\":\"" + ResourceTypeName + "\"}" })
            {
                object model = ModelReaderWriter.Read(BinaryData.FromString(payload), type, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);
                AssertWireType(model, type, payload.Contains(ResourceTypeName) ? ResourceTypeName : null);
            }
        }

        [TestCase(typeof(ExpressRouteLagLink))]
        [TestCase(typeof(ExpressRouteLagMember))]
        public void RequiredMetadataPreservesResourceType(Type type)
        {
            object model = ModelReaderWriter.Read(BinaryData.FromString("{\"type\":\"" + ResourceTypeName + "\"}"),
                type, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);
            AssertWireType(model, type, ResourceTypeName);
        }

        [Test]
        public void SslPredefinedPolicyPrefersWireMetadataOverId()
        {
            var model = ModelReaderWriter.Read<ApplicationGatewaySslPredefinedPolicy>(
                BinaryData.FromString("{\"id\":\"/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies/policy\",\"type\":\"" + ResourceTypeName + "\"}"));
            AssertWireType(model, typeof(ApplicationGatewaySslPredefinedPolicy), ResourceTypeName);
        }

        private static void AssertWireType(object model, Type type, string expected)
        {
            PropertyInfo property = type.GetProperty("ResourceType");
            Assert.That(property.GetValue(model)?.ToString(), Is.EqualTo(expected), type.Name);
            BinaryData persisted = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);
            using JsonDocument document = JsonDocument.Parse(persisted);
            bool present = document.RootElement.TryGetProperty("type", out JsonElement resourceType);
            if (expected != null)
                Assert.That(present, Is.True, type.Name);
            if (present)
                Assert.That(resourceType.GetString(), Is.EqualTo(expected));

            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W"), AzureResourceManagerNetworkContext.Default));
            bool written = typeof(NetworkWritableResourceData).IsAssignableFrom(type) && expected != null;
            Assert.That(wire.RootElement.TryGetProperty("type", out resourceType), Is.EqualTo(written), type.Name);
            if (written)
                Assert.That(resourceType.GetString(), Is.EqualTo(expected));

            object roundTrip = ModelReaderWriter.Read(persisted, type, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);
            Assert.That(property.GetValue(roundTrip)?.ToString(), Is.EqualTo(expected), type.Name);
        }
    }
}
