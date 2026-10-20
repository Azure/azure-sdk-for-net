// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
#pragma warning disable CS0618 // Exercise the specific deprecated batch3 models and their callers.
    using InboundSecurityRule = global::Azure.ResourceManager.Network.Models.InboundSecurityRule;

    public class NetworkBatchThreeCompatibilityTests
    {
        private const string RuleJson = """
            {"id":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/networkVirtualAppliances/nva/inboundSecurityRules/rule","name":"rule","type":"Microsoft.Network/networkVirtualAppliances/inboundSecurityRules","etag":"etag-value","futureEnvelope":17,"properties":{"ruleType":"Permanent","rules":[{"name":"allow","protocol":"TCP","sourceAddressPrefix":"10.0.0.0/24","destinationPortRange":443,"destinationPortRanges":["443-444"],"appliesOn":["public-ip"]}],"provisioningState":"Succeeded","futureProperty":true}}
            """;

        [TestCase(typeof(FirewallPacketCaptureRequestContent))]
        [TestCase(typeof(InboundSecurityRule))]
        [TestCase(typeof(NetworkConnectionState))]
        [TestCase(typeof(PropagatedRouteTable))]
        public void RetiredCompatibilityModelsAreDeprecatedAndHidden(Type type)
        {
            AssertDeprecated(type);
        }

        [TestCase(typeof(FirewallPolicyIdpsSignatureSeverity))]
        [TestCase(typeof(PacketCaptureTargetType))]
        public void ActiveFixedEnumsAreGeneratedAndNotDeprecated(Type type)
        {
            Assert.That(type.IsEnum, Is.True);
            Assert.That(type.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
        }

        [Test]
        public void GeneratedFixedEnumsRetainHistoricalValuesAndWireMappings()
        {
            Assert.That((int)FirewallPolicyIdpsSignatureSeverity.One, Is.EqualTo(1));
            Assert.That((int)FirewallPolicyIdpsSignatureSeverity.Two, Is.EqualTo(2));
            Assert.That((int)FirewallPolicyIdpsSignatureSeverity.Three, Is.EqualTo(3));
            Assert.That((int)PacketCaptureTargetType.AzureVm, Is.EqualTo(0));
            Assert.That((int)PacketCaptureTargetType.AzureVmss, Is.EqualTo(1));
            var signature = ModelReaderWriter.Read<IdpsSignatureResult>(BinaryData.FromString("""{"severity":2}"""));
            Assert.That(signature.Severity, Is.EqualTo(FirewallPolicyIdpsSignatureSeverity.Two));
            var capture = new PacketCaptureCreateOrUpdateContent("target", new PacketCaptureStorageLocation()) { TargetType = PacketCaptureTargetType.AzureVmss };
            Assert.That(ModelReaderWriter.Write(capture).ToString(), Does.Contain("\"targetType\":\"AzureVMSS\""));
        }

        [Test]
        public void DeprecatedModelReferencesAreAlsoDeprecated()
        {
            AssertDeprecated(typeof(RoutingConfiguration).GetProperty(nameof(RoutingConfiguration.PropagatedRouteTables), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            foreach (MethodInfo method in typeof(ArmNetworkModelFactory).GetMethods().Where(m => m.Name == nameof(ArmNetworkModelFactory.InboundSecurityRule)))
            {
                AssertDeprecated(method);
            }
            foreach (MethodInfo method in typeof(NetworkVirtualApplianceResource).GetMethods().Where(m => m.Name.StartsWith("CreateOrUpdateInboundSecurityRule", StringComparison.Ordinal)))
            {
                AssertDeprecated(method);
            }
            foreach (MethodInfo method in typeof(AzureFirewallResource).GetMethods().Where(m => m.GetParameters().Any(p => p.ParameterType == typeof(FirewallPacketCaptureRequestContent))))
            {
                AssertDeprecated(method);
            }
        }

        [Test]
        public void InboundRuleConversionAndPersistencePreserveTheCompletePayload()
        {
            var legacy = ModelReaderWriter.Read<InboundSecurityRule>(BinaryData.FromString(RuleJson));
            AssertInboundRule(legacy);
            InboundSecurityRuleData native = legacy;
            Assert.That(native.Id, Is.EqualTo(legacy.Id));
            Assert.That(native.Name, Is.EqualTo(legacy.Name));
            Assert.That(native.ResourceType, Is.EqualTo(legacy.ResourceType));
            Assert.That(native.ETag, Is.EqualTo(legacy.ETag));
            Assert.That(native.RuleType, Is.EqualTo(legacy.RuleType));
            Assert.That(native.ProvisioningState, Is.EqualTo(legacy.ProvisioningState));
            Assert.That(native.Rules, Is.SameAs(legacy.Rules));
            Assert.That((InboundSecurityRuleData)(InboundSecurityRule)null, Is.Null);
            foreach (BinaryData persisted in new[]
            {
                ModelReaderWriter.Write(legacy),
                ((IPersistableModel<InboundSecurityRule>)legacy).Write(ModelReaderWriterOptions.Json),
                ModelReaderWriter.Write<NetworkResourceData>(legacy),
                ModelReaderWriter.Write(native)
            })
            {
                using JsonDocument document = JsonDocument.Parse(persisted);
                Assert.That(document.RootElement.GetProperty("futureEnvelope").GetInt32(), Is.EqualTo(17));
                Assert.That(document.RootElement.GetProperty("properties").GetProperty("futureProperty").GetBoolean(), Is.True);
                AssertInboundRule(ModelReaderWriter.Read<InboundSecurityRule>(persisted));
            }
        }

        [Test]
        public void InboundRuleJsonInterfacesConsumeAndRestoreThePayload()
        {
            var reader = new Utf8JsonReader(BinaryData.FromString(RuleJson).ToMemory().Span);
            var legacy = ((IJsonModel<InboundSecurityRule>)new InboundSecurityRule()).Create(ref reader, ModelReaderWriterOptions.Json);
            Assert.That(reader.TokenType, Is.EqualTo(JsonTokenType.EndObject));
            AssertInboundRule(legacy);
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<InboundSecurityRule>)legacy).Write(writer, ModelReaderWriterOptions.Json);
            }
            AssertInboundRule(ModelReaderWriter.Read<InboundSecurityRule>(BinaryData.FromBytes(stream.ToArray())));
        }

        [Test]
        public void InboundRuleWireSerializationOmitsReadOnlyMetadataButKeepsRules()
        {
            var wire = new ModelReaderWriterOptions("W");
            var legacy = ModelReaderWriter.Read<InboundSecurityRule>(BinaryData.FromString(RuleJson), wire);
            AssertInboundRule(legacy);
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(legacy, wire));
            Assert.That(document.RootElement.TryGetProperty("etag", out _), Is.False);
            Assert.That(document.RootElement.TryGetProperty("futureEnvelope", out _), Is.False);
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.That(properties.TryGetProperty("provisioningState", out _), Is.False);
            Assert.That(properties.GetProperty("rules")[0].GetProperty("name").GetString(), Is.EqualTo("allow"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void InboundRuleFactoriesRetainAllArguments(bool includeRuleType)
        {
            var original = ModelReaderWriter.Read<InboundSecurityRule>(BinaryData.FromString(RuleJson));
            InboundSecurityRule created = includeRuleType
                ? ArmNetworkModelFactory.InboundSecurityRule(original.Id, original.Name, original.ResourceType, original.ETag, original.RuleType, original.Rules, original.ProvisioningState)
                : ArmNetworkModelFactory.InboundSecurityRule(original.Id, original.Name, original.ResourceType, original.ETag, original.Rules, original.ProvisioningState);
            Assert.That(created.Id, Is.EqualTo(original.Id));
            Assert.That(created.Name, Is.EqualTo(original.Name));
            Assert.That(created.ResourceType, Is.EqualTo(original.ResourceType));
            Assert.That(created.ETag, Is.EqualTo(original.ETag));
            Assert.That(created.ProvisioningState, Is.EqualTo(original.ProvisioningState));
            Assert.That(created.Rules, Is.EqualTo(original.Rules));
            Assert.That(created.RuleType, Is.EqualTo(includeRuleType ? original.RuleType : null));
        }

        [TestCase("\"quoted\"")]
        [TestCase("W/\"quoted\"")]
        public void InboundRuleConversionEscapesEntityTagsWithoutReflection(string value)
        {
            var legacy = ArmNetworkModelFactory.InboundSecurityRule(default, default, default, new ETag(value), default(InboundSecurityRuleType?), null, default);
            InboundSecurityRuleData native = legacy;
            Assert.That(native.ETag.ToString(), Is.EqualTo(value));
            var restored = ModelReaderWriter.Read<InboundSecurityRule>(ModelReaderWriter.Write(legacy));
            Assert.That(restored.ETag.ToString(), Is.EqualTo(value));
        }

        [Test]
        public void FirewallRequestAliasRoundTripsWithoutRecursiveWriting()
        {
            const string json = """{"durationInSeconds":12,"numberOfPacketsToCapture":3,"sasUrl":"https://example.com/capture","fileName":"capture.pcap","protocol":"TCP","flags":[{"type":"syn"}],"filters":[{"sources":["10.0.0.1"],"destinations":["10.0.0.2"],"destinationPorts":["443"]}],"operation":"Start","futureField":42}""";
            var reader = new Utf8JsonReader(BinaryData.FromString(json).ToMemory().Span);
            var request = ((IJsonModel<FirewallPacketCaptureRequestContent>)new FirewallPacketCaptureRequestContent()).Create(ref reader, ModelReaderWriterOptions.Json);
            Assert.That(reader.TokenType, Is.EqualTo(JsonTokenType.EndObject));
            Assert.That(request.DurationInSeconds, Is.EqualTo(12));
            Assert.That(request.NumberOfPacketsToCapture, Is.EqualTo(3));
            Assert.That(request.FileName, Is.EqualTo("capture.pcap"));
            Assert.That(request.Flags.Count, Is.EqualTo(1));
            Assert.That(request.Filters.Count, Is.EqualTo(1));
            Assert.That(request.Filters.Single().Sources.Single(), Is.EqualTo("10.0.0.1"));
            Assert.That(request.Filters.Single().Destinations.Single(), Is.EqualTo("10.0.0.2"));
            Assert.That(request.Filters.Single().DestinationPorts.Single(), Is.EqualTo("443"));
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<FirewallPacketCaptureRequestContent>)request).Write(writer, ModelReaderWriterOptions.Json);
            }
            foreach (BinaryData persisted in new[]
            {
                BinaryData.FromBytes(stream.ToArray()),
                ModelReaderWriter.Write(request),
                ((IPersistableModel<FirewallPacketCaptureRequestContent>)request).Write(ModelReaderWriterOptions.Json),
                ModelReaderWriter.Write<FirewallPacketCaptureContent>(request)
            })
            {
                using JsonDocument document = JsonDocument.Parse(persisted);
                Assert.That(document.RootElement.GetProperty("futureField").GetInt32(), Is.EqualTo(42));
                var restored = ModelReaderWriter.Read<FirewallPacketCaptureRequestContent>(persisted);
                Assert.That(restored.DurationInSeconds, Is.EqualTo(request.DurationInSeconds));
                Assert.That(restored.SasUri, Is.EqualTo(request.SasUri));
                Assert.That(restored.Protocol, Is.EqualTo(request.Protocol));
                Assert.That(restored.Operation, Is.EqualTo(request.Operation));
                Assert.That(restored.Flags.Select(flag => flag.FlagsType), Is.EqualTo(request.Flags.Select(flag => flag.FlagsType)));
                Assert.That(restored.Filters.Single().Sources, Is.EqualTo(request.Filters.Single().Sources));
            }
        }

        [Test]
        public void LegacyAdaptersSupportNullAndRejectUnsupportedFormats()
        {
            Assert.That(ModelReaderWriter.Read<InboundSecurityRule>(BinaryData.FromString("null")), Is.Null);
            Assert.That(ModelReaderWriter.Read<FirewallPacketCaptureRequestContent>(BinaryData.FromString("null")), Is.Null);
            var unsupported = new ModelReaderWriterOptions("X");
            Assert.Throws<FormatException>(() => ((IPersistableModel<InboundSecurityRule>)new InboundSecurityRule()).Create(BinaryData.FromString("{}"), unsupported));
            Assert.Throws<FormatException>(() => ((IPersistableModel<FirewallPacketCaptureRequestContent>)new FirewallPacketCaptureRequestContent()).Create(BinaryData.FromString("{}"), unsupported));
        }

        [Test]
        public void ProvisioningStateSettersRemainWireReadOnly()
        {
            var pool = ModelReaderWriter.Read<IpamPoolProperties>(BinaryData.FromString("""{"addressPrefixes":["10.0.0.0/24"],"provisioningState":"Succeeded"}"""));
            var workspace = ModelReaderWriter.Read<NetworkVerifierWorkspaceProperties>(BinaryData.FromString("""{"provisioningState":"Succeeded"}"""));
            Assert.That(pool.ProvisioningState, Is.EqualTo(NetworkProvisioningState.Succeeded));
            Assert.That(workspace.ProvisioningState, Is.EqualTo(NetworkProvisioningState.Succeeded));
            pool.ProvisioningState = NetworkProvisioningState.Failed;
            workspace.ProvisioningState = NetworkProvisioningState.Failed;
            Assert.That(ModelReaderWriter.Write(pool).ToString(), Does.Contain("\"provisioningState\":\"Failed\""));
            Assert.That(ModelReaderWriter.Write(workspace).ToString(), Does.Contain("\"provisioningState\":\"Failed\""));
            Assert.That(ModelReaderWriter.Write(pool, new ModelReaderWriterOptions("W")).ToString(), Does.Not.Contain("provisioningState"));
            Assert.That(ModelReaderWriter.Write(workspace, new ModelReaderWriterOptions("W")).ToString(), Does.Not.Contain("provisioningState"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ReleasedBooleanConstructorsRemainCallableAndIgnoreTheArgument(bool value)
        {
            Assert.That(new DerivedRule(value).Name, Is.Null);
            Assert.That(new DerivedCollection(value).Name, Is.Null);
            Assert.That(new DerivedSku(value).InstanceCount, Is.Null);
        }

        [Test]
        public void HistoricalProtectedParameterlessRuleConstructorsRemainCallable()
        {
            Assert.That(new DerivedRule().Name, Is.Null);
            Assert.That(new DerivedCollection().Name, Is.Null);
        }

        [Test]
        public void P2SRoutingConfigurationUsesNativeStorageInsteadOfAnUnconnectedStub()
        {
            const string routeId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualHubs/hub/hubRouteTables/route";
            var configuration = ModelReaderWriter.Read<P2SConnectionConfiguration>(
                BinaryData.FromString($"{{\"properties\":{{\"routingConfiguration\":{{\"associatedRouteTable\":{{\"id\":\"{routeId}\"}},\"futureRouting\":true}}}}}}"));
            Assert.That(configuration.RoutingConfiguration.AssociatedRouteTableId.ToString(), Is.EqualTo(routeId));
            Assert.That(configuration.RoutingConfiguration, Is.SameAs(configuration.RoutingConfiguration));
            var routing = configuration.RoutingConfiguration;
            configuration.RoutingConfiguration = new RoutingConfiguration { AssociatedRouteTableId = new ResourceIdentifier(routeId) };
            var restored = ModelReaderWriter.Read<P2SConnectionConfiguration>(ModelReaderWriter.Write(configuration));
            Assert.That(restored.RoutingConfiguration.AssociatedRouteTableId.ToString(), Is.EqualTo(routeId));
            configuration.RoutingConfiguration = routing;
            Assert.That(ModelReaderWriter.Write(configuration).ToString(), Does.Contain("\"futureRouting\":true"));
            configuration.RoutingConfiguration = null;
            Assert.That(configuration.RoutingConfiguration, Is.Null);
            Assert.That(typeof(P2SConnectionConfiguration).GetProperty(nameof(P2SConnectionConfiguration.RoutingConfiguration)).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
        }

        private static void AssertInboundRule(InboundSecurityRule rule)
        {
            Assert.That(rule.Id.ToString(), Does.EndWith("/inboundSecurityRules/rule"));
            Assert.That(rule.Name, Is.EqualTo("rule"));
            Assert.That(rule.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/networkVirtualAppliances/inboundSecurityRules"));
            Assert.That(rule.ETag.ToString(), Is.EqualTo("etag-value"));
            Assert.That(rule.RuleType.ToString(), Is.EqualTo("Permanent"));
            Assert.That(rule.ProvisioningState, Is.EqualTo(NetworkProvisioningState.Succeeded));
            Assert.That(rule.Rules.Single().Name, Is.EqualTo("allow"));
            Assert.That(rule.Rules.Single().Protocol.ToString(), Is.EqualTo("TCP"));
            Assert.That(rule.Rules.Single().SourceAddressPrefix, Is.EqualTo("10.0.0.0/24"));
            Assert.That(rule.Rules.Single().DestinationPortRange, Is.EqualTo(443));
            Assert.That(rule.Rules.Single().DestinationPortRanges.Single(), Is.EqualTo("443-444"));
            Assert.That(rule.Rules.Single().AppliesOn.Single(), Is.EqualTo("public-ip"));
        }

        private static void AssertDeprecated(MemberInfo member)
        {
            Assert.That(member.GetCustomAttribute<ObsoleteAttribute>(), Is.Not.Null);
            Assert.That(member.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
        }

        private sealed class DerivedRule : FirewallPolicyRule
        {
            public DerivedRule() : base() { }
            public DerivedRule(bool value) : base(value) { }
        }

        private sealed class DerivedCollection : FirewallPolicyRuleCollectionInfo
        {
            public DerivedCollection() : base() { }
            public DerivedCollection(bool value) : base(value) { }
        }

        private sealed class DerivedSku : NetworkVirtualApplianceSkuInstances
        {
            public DerivedSku(bool value) : base(value) { }
        }
    }
#pragma warning restore CS0618
}
