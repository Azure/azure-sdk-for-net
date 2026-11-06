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
    public class NetworkRestoredPropertyCompatibilityTests
    {
        [Test]
        public void AvailableRuleSetsRetainsReadOnlyLiveStorage()
        {
            PropertyInfo property = typeof(ApplicationGatewayWafDynamicManifestData).GetProperty(nameof(ApplicationGatewayWafDynamicManifestData.AvailableRuleSets));
            Assert.That(property.PropertyType, Is.EqualTo(typeof(IReadOnlyList<ApplicationGatewayFirewallManifestRuleSet>)));
            Assert.That(property.SetMethod, Is.Null);
            var empty = (ApplicationGatewayWafDynamicManifestData)Activator.CreateInstance(typeof(ApplicationGatewayWafDynamicManifestData), nonPublic: true);
            Assert.That(empty.AvailableRuleSets, Is.Null);

            var model = ModelReaderWriter.Read<ApplicationGatewayWafDynamicManifestData>(
                BinaryData.FromString("""{"properties":{"availableRuleSets":[{"ruleSetType":"OWASP","ruleSetVersion":"3.2"}]}}"""));
            var view = model.AvailableRuleSets;
            Assert.That(view, Has.Count.EqualTo(1));
            Assert.That(((ICollection<ApplicationGatewayFirewallManifestRuleSet>)view).IsReadOnly, Is.True);
            Assert.Throws<NotSupportedException>(() => ((ICollection<ApplicationGatewayFirewallManifestRuleSet>)view).Add(null));

            object properties = typeof(ApplicationGatewayWafDynamicManifestData)
                .GetProperty("Properties", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(model);
            var backing = (IList<ApplicationGatewayFirewallManifestRuleSet>)properties.GetType()
                .GetProperty("AvailableRuleSets").GetValue(properties);
            backing.Add(backing[0]);
            Assert.That(view, Has.Count.EqualTo(2));
            var roundTrip = ModelReaderWriter.Read<ApplicationGatewayWafDynamicManifestData>(ModelReaderWriter.Write(model));
            Assert.That(roundTrip.AvailableRuleSets, Has.Count.EqualTo(2));
        }

        [TestCase(typeof(NetworkResourceData))]
        [TestCase(typeof(NetworkTrackedResourceData))]
        [TestCase(typeof(EndpointServiceResult))]
        public void ResourceTypeRetainsPublicReadOnlyMetadataAndPersistence(Type modelType)
        {
            PropertyInfo property = modelType.GetProperty("ResourceType");
            Assert.That(property.PropertyType, Is.EqualTo(typeof(ResourceType?)));
            Assert.That(property.GetMethod.IsPublic, Is.True);
            Assert.That(property.SetMethod?.IsPublic ?? false, Is.False);
            CheckResourceTypePersistence(modelType);
        }

        [Test]
        public void ResourceTypeConstructorsAndFactoriesPopulateReadOnlyStorage()
        {
            var resourceType = new ResourceType("Microsoft.Network/test");
            Assert.That(new EndpointServiceResult(default, default, "endpoint", resourceType).ResourceType, Is.EqualTo(resourceType));
            Assert.That(new NetworkResourceData(default, default, "resource", resourceType).ResourceType, Is.EqualTo(resourceType));
            Assert.That(new NetworkTrackedResourceData(default, "tracked", resourceType, default, default, default).ResourceType, Is.EqualTo(resourceType));
            Assert.That(ArmNetworkModelFactory.EndpointServiceResult(name: "endpoint", resourceType: resourceType).ResourceType, Is.EqualTo(resourceType));
            Assert.That(ArmNetworkModelFactory.NetworkResourceData(resourceType: resourceType).ResourceType, Is.EqualTo(resourceType));
            Assert.That(ArmNetworkModelFactory.NetworkTrackedResourceData(resourceType: resourceType).ResourceType, Is.EqualTo(resourceType));
            Assert.That(typeof(EndpointServiceResult).GetProperty("ResourceType").SetMethod, Is.Null);
            Assert.That(typeof(NetworkResourceData).GetProperty("ResourceType").SetMethod, Is.Null);
        }

        [Test]
        public void LegacySslOptionsRetainsAllFourFactoryProperties()
        {
#pragma warning disable CS0618 // Exercise the retained legacy model, not its generated replacement.
            var model = ArmNetworkModelFactory.ApplicationGatewayAvailableSslOptionsInfo(
                resourceType: new ResourceType("Microsoft.Network/applicationGatewayAvailableSslOptions"),
                predefinedPolicies: new[] { new global::Azure.ResourceManager.Resources.Models.WritableSubResource() },
                defaultPolicy: ApplicationGatewaySslPolicyName.AppGwSslPolicy20150501,
                availableCipherSuites: new[] { ApplicationGatewaySslCipherSuite.TlsDHERsaWithAes128GcmSha256 },
                availableProtocols: new[] { ApplicationGatewaySslProtocol.Tls1_2 });
            Assert.That(model.PredefinedPolicies, Has.Count.EqualTo(1));
            Assert.That(model.DefaultPolicy, Is.EqualTo(ApplicationGatewaySslPolicyName.AppGwSslPolicy20150501));
            Assert.That(model.AvailableCipherSuites, Has.Count.EqualTo(1));
            Assert.That(model.AvailableProtocols, Has.Count.EqualTo(1));
            Assert.That(typeof(ApplicationGatewayAvailableSslOptionsInfo).GetProperty("PredefinedPolicies").SetMethod, Is.Null);
            Assert.That(typeof(ApplicationGatewayAvailableSslOptionsInfo).GetProperty("DefaultPolicy").SetMethod.IsPublic, Is.True);
            Assert.That(typeof(ApplicationGatewayAvailableSslOptionsInfo).GetProperty("AvailableCipherSuites").SetMethod, Is.Null);
            Assert.That(typeof(ApplicationGatewayAvailableSslOptionsInfo).GetProperty("AvailableProtocols").SetMethod, Is.Null);
            var roundTrip = ModelReaderWriter.Read<ApplicationGatewayAvailableSslOptionsInfo>(ModelReaderWriter.Write(model));
            Assert.That(roundTrip.ResourceType, Is.EqualTo(model.ResourceType));
#pragma warning restore CS0618
        }

        [Test]
        public void LegacySslOptionsAdapterPopulatesRealPropertyStorage()
        {
            const string subscription = "00000000-0000-0000-0000-000000000001";
            string policyId = $"/subscriptions/{subscription}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies/policy";
            var data = ModelReaderWriter.Read<ApplicationGatewayAvailableSslOptionsInfoData>(
                BinaryData.FromString(JsonSerializer.Serialize(new
                {
                    name = "default",
                    type = "Microsoft.Network/applicationGatewayAvailableSslOptions",
                    properties = new
                    {
                        predefinedPolicies = new[] { new { id = policyId } },
                        defaultPolicy = ApplicationGatewaySslPolicyName.AppGwSslPolicy20150501.ToString(),
                        availableCipherSuites = new[] { ApplicationGatewaySslCipherSuite.TlsDHERsaWithAes128GcmSha256.ToString() },
                        availableProtocols = new[] { ApplicationGatewaySslProtocol.Tls1_2.ToString() }
                    }
                })));
#pragma warning disable CS0618 // Verify the existing native-to-legacy conversion remains functional.
            var model = ApplicationGatewayAvailableSslOptionsInfo.FromData(data, subscription);
            Assert.That(model.PredefinedPolicies.Single().Id, Is.EqualTo(NetworkExtensions.CreateApplicationGatewaySslPredefinedPolicyIdentifier(subscription, "policy")));
            Assert.That(model.DefaultPolicy, Is.EqualTo(data.DefaultPolicy));
            Assert.That(model.AvailableCipherSuites, Is.EqualTo(data.AvailableCipherSuites));
            Assert.That(model.AvailableProtocols, Is.EqualTo(data.AvailableProtocols));
            Assert.That(model.ResourceType, Is.EqualTo(data.ResourceType));
#pragma warning restore CS0618
        }

        [TestCase("J")]
        [TestCase("W")]
        public void LegacyStringRulesStayIndependentOfNumericWireRules(string format)
        {
            string[] legacy = { "not-a-number", null, "999999999999999999999999999" };
#pragma warning disable CS0618 // The legacy collection intentionally remains a deprecated compatibility API.
            var model = ArmNetworkModelFactory.ManagedRuleSetRuleGroup(ruleGroupName: "group", rules: legacy);
            Assert.That(model.Rules, Is.EqualTo(legacy));
            Assert.That(model.RuleIds, Is.Empty);
            model.RuleIds.Add(42);
            Assert.That(model.Rules, Is.EqualTo(legacy));
            AssertDeprecated(typeof(ManagedRuleSetRuleGroup).GetProperty(nameof(ManagedRuleSetRuleGroup.Rules)), "RuleIds");
#pragma warning restore CS0618
            var options = new ModelReaderWriterOptions(format);
            BinaryData data = ModelReaderWriter.Write(model, options);
            using JsonDocument json = JsonDocument.Parse(data);
            Assert.That(json.RootElement.GetProperty("rules").EnumerateArray().Select(rule => rule.GetInt32()), Is.EqualTo(new[] { 42 }));
            var roundTrip = ModelReaderWriter.Read<ManagedRuleSetRuleGroup>(data, options);
            Assert.That(roundTrip.RuleIds, Is.EqualTo(new[] { 42 }));
#pragma warning disable CS0618
            Assert.That(roundTrip.Rules, Is.Empty);
#pragma warning restore CS0618
        }

        [TestCase("J")]
        [TestCase("W")]
        public void LegacyCaptchaNameUsesOnlyTheCurrentWireField(string format)
        {
            var model = new PolicySettings();
#pragma warning disable CS0618 // Verify the old name remains connected without resurrecting the old wire field.
            model.CaptchaCookieExpirationInMins = null;
            Assert.That(model.CaptchaExpirationInMins, Is.Null);
            model.CaptchaCookieExpirationInMins = 15;
            Assert.That(model.CaptchaExpirationInMins, Is.EqualTo(15));
            model.CaptchaExpirationInMins = 30;
            Assert.That(model.CaptchaCookieExpirationInMins, Is.EqualTo(30));
            AssertDeprecated(typeof(PolicySettings).GetProperty(nameof(PolicySettings.CaptchaCookieExpirationInMins)), "CaptchaExpirationInMins");
#pragma warning restore CS0618
            var options = new ModelReaderWriterOptions(format);
            BinaryData data = ModelReaderWriter.Write(model, options);
            using JsonDocument json = JsonDocument.Parse(data);
            Assert.That(json.RootElement.GetProperty("captchaExpirationInMins").GetInt32(), Is.EqualTo(30));
            Assert.That(json.RootElement.TryGetProperty("captchaCookieExpirationInMins", out _), Is.False);
            var roundTrip = ModelReaderWriter.Read<PolicySettings>(data, options);
#pragma warning disable CS0618
            Assert.That(roundTrip.CaptchaCookieExpirationInMins, Is.EqualTo(30));
#pragma warning restore CS0618
        }

        [Test]
        public void NativeSha384MatchesTheReleasedActiveValue()
        {
            Assert.That(IPsecIntegrity.Sha384.ToString(), Is.EqualTo("SHA384"));
            PropertyInfo property = typeof(IPsecIntegrity).GetProperty(nameof(IPsecIntegrity.Sha384));
            Assert.That(property.PropertyType, Is.EqualTo(typeof(IPsecIntegrity)));
            Assert.That(property.SetMethod, Is.Null);
            Assert.That(property.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(property.GetCustomAttribute<EditorBrowsableAttribute>(), Is.Null);
        }

        private static void CheckResourceTypePersistence(Type modelType)
        {
            const string resourceType = "Microsoft.Network/test";
            object model = ModelReaderWriter.Read(BinaryData.FromString("{\"type\":\"" + resourceType + "\"}"), modelType, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);
            PropertyInfo property = modelType.GetProperty("ResourceType");
            Assert.That(property.GetValue(model), Is.EqualTo(new ResourceType(resourceType)));
            object roundTrip = ModelReaderWriter.Read(ModelReaderWriter.Write(model), modelType, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);
            Assert.That(property.GetValue(roundTrip), Is.EqualTo(new ResourceType(resourceType)));
            object empty = ModelReaderWriter.Read(BinaryData.FromString("{}"), modelType, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);
            Assert.That(property.GetValue(empty), Is.Null);
        }
    }
}
