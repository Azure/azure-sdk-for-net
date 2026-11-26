// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.CognitiveServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class ManagedComputeCapacityNamingTests
    {
        [Test]
        public void ModelFactoryMethodsAcceptOmittedArguments()
        {
            object[] models =
            {
                ArmCognitiveServicesModelFactory.CognitiveServicesAccountData(),
                ArmCognitiveServicesModelFactory.CognitiveServicesAccountDeploymentData(),
                ArmCognitiveServicesModelFactory.CognitiveServicesAccountModel(),
                ArmCognitiveServicesModelFactory.CognitiveServicesCapabilityHostProperties(),
                ArmCognitiveServicesModelFactory.CognitiveServicesEncryptionScopeData(),
                ArmCognitiveServicesModelFactory.CognitiveServicesPrivateEndpointConnectionData(),
                ArmCognitiveServicesModelFactory.CognitiveServicesProjectData(),
                ArmCognitiveServicesModelFactory.CommitmentPlanAccountAssociationData(),
                ArmCognitiveServicesModelFactory.CommitmentPlanData(),
                ArmCognitiveServicesModelFactory.DefenderForAISettingData(),
                ArmCognitiveServicesModelFactory.RaiBlocklistData(),
                ArmCognitiveServicesModelFactory.RaiBlocklistItemData(),
                ArmCognitiveServicesModelFactory.RaiPolicyData()
            };

            Assert.That(models, Is.All.Not.Null);
        }

        [Test]
        public void ModelFactoryMethodsPreserveNamedArguments()
        {
            const string name = "test-resource";

            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.CognitiveServicesAccountData(name: name).Name);
            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.CognitiveServicesAccountDeploymentData(name: name).Name);
            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.CognitiveServicesAccountModel(name: name).Name);
            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.CognitiveServicesCapabilityHostProperties(description: name).Description);
            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.CognitiveServicesEncryptionScopeData(name: name).Name);
            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.CognitiveServicesPrivateEndpointConnectionData(name: name).Name);
            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.CognitiveServicesProjectData(name: name).Name);
            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.CommitmentPlanAccountAssociationData(name: name).Name);
            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.CommitmentPlanData(name: name).Name);
            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.DefenderForAISettingData(name: name).Name);
            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.RaiBlocklistData(name: name).Name);
            Assert.AreEqual(name, ArmCognitiveServicesModelFactory.RaiBlocklistItemData(name: name).Name);

            var properties = new RaiPolicyProperties();
            var policy = ArmCognitiveServicesModelFactory.RaiPolicyData(name: name, properties: properties);
            Assert.AreEqual(name, policy.Name);
            Assert.AreSame(properties, policy.Properties);
        }

        [Test]
        public void ModelFactoryPreservesBothBlocklistPositionalSignatures()
        {
            var resourceId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.CognitiveServices/accounts/account/raiBlocklists/blocklist");
            var resourceType = new ResourceType("Microsoft.CognitiveServices/accounts/raiBlocklists");
            var etag = new ETag("test-etag");
            var tags = new Dictionary<string, string> { ["key"] = "value" };

            var legacy = ArmCognitiveServicesModelFactory.RaiBlocklistData(resourceId, "blocklist", resourceType, null, etag, tags, "description");
            var current = ArmCognitiveServicesModelFactory.RaiBlocklistData(resourceId, "blocklist", resourceType, null, "description", etag, tags);

            foreach (var blocklist in new[] { legacy, current })
            {
                Assert.AreEqual(resourceId, blocklist.Id);
                Assert.AreEqual("blocklist", blocklist.Name);
                Assert.AreEqual(resourceType, blocklist.ResourceType);
                Assert.AreEqual(etag, blocklist.ETag);
                Assert.AreEqual("value", blocklist.Tags["key"]);
                Assert.AreEqual("description", blocklist.RaiBlocklistDescription);
            }
        }

        [Test]
        public void ReleasedAccountPropertiesFactoryPreservesValues()
        {
            var properties = ArmCognitiveServicesModelFactory.CognitiveServicesAccountProperties(
                default, "endpoint", default, default, default, default, default, default, default,
                default, default, default, default, default, default, default, default, default,
                true, default, default, default, default, default, default, default, default,
                default, default, default, default, default, true, "project", new[] { "project" },
                new CognitiveServicesTrustedCertificateSource[0]);

            Assert.AreEqual("endpoint", properties.Endpoint);
            Assert.AreEqual(true, properties.IsA365LoggingEnabled);
            Assert.AreEqual(true, properties.AllowProjectManagement);
            Assert.AreEqual("project", properties.DefaultProject);
            CollectionAssert.AreEqual(new[] { "project" }, properties.AssociatedProjects);
            Assert.IsEmpty(properties.TrustedCertificateSources);
        }

        [Test]
        public void ReleasedDeploymentPropertiesFactoryPreservesValues()
        {
            var cacheId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000");
            var capabilities = new Dictionary<string, string> { ["key"] = "value" };
            var routing = new CognitiveServicesDeploymentRouting();
            var properties = ArmCognitiveServicesModelFactory.CognitiveServicesAccountDeploymentProperties(
                default, default, cacheId, default, capabilities, "policy", default, default, default,
                default, default, default, "parent", "spillover", default, default, routing);

            Assert.AreEqual(cacheId, properties.ContextCacheContainerId);
            Assert.AreEqual("value", properties.Capabilities["key"]);
            Assert.AreEqual("policy", properties.RaiPolicyName);
            Assert.AreEqual("parent", properties.ParentDeploymentName);
            Assert.AreSame(routing, properties.Routing);
        }

        [Test]
        public void DeploymentPropertiesFactoryPreservesPartialPositionalCalls()
        {
            var cacheId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000");
            var scaleSettings = new CognitiveServicesAccountDeploymentScaleSettings { Capacity = 2 };
            var capabilities = new Dictionary<string, string> { ["key"] = "value" };
            var properties = ArmCognitiveServicesModelFactory.CognitiveServicesAccountDeploymentProperties(
                default, default, cacheId, scaleSettings, capabilities, "policy");

            Assert.AreEqual(cacheId, properties.ContextCacheContainerId);
            Assert.AreSame(scaleSettings, properties.ScaleSettings);
            Assert.AreEqual("value", properties.Capabilities["key"]);
            Assert.AreEqual("policy", properties.RaiPolicyName);
        }

        [Test]
        public void DeploymentPropertiesFactoryPreservesOptionalAndNewArguments()
        {
            Assert.IsNotNull(ArmCognitiveServicesModelFactory.CognitiveServicesAccountDeploymentProperties());

            var scaleSettings = new CognitiveServicesAccountDeploymentScaleSettings { Capacity = 2 };
            var speculativeDecoding = ArmCognitiveServicesModelFactory.DeploymentSpeculativeDecoding(draftTokenCount: 3);
            var properties = ArmCognitiveServicesModelFactory.CognitiveServicesAccountDeploymentProperties(
                scaleSettings: scaleSettings, speculativeDecoding: speculativeDecoding);

            Assert.AreSame(scaleSettings, properties.ScaleSettings);
            Assert.AreSame(speculativeDecoding, properties.SpeculativeDecoding);
        }

        [Test]
        public void ReleasedRaiPolicyPropertiesFactoryPreservesValues()
        {
            var egressPolicy = new RaiEgressPolicyConfig();
            var properties = ArmCognitiveServicesModelFactory.RaiPolicyProperties(
                RaiPolicyType.UserManaged, RaiPolicyMode.Blocking, "base", default, default, default, egressPolicy);

            Assert.AreEqual(RaiPolicyType.UserManaged, properties.PolicyType);
            Assert.AreEqual(RaiPolicyMode.Blocking, properties.Mode);
            Assert.AreEqual("base", properties.BasePolicyName);
            Assert.AreSame(egressPolicy, properties.EgressPolicy);
        }

        [Test]
        public void RaiPolicyPropertiesFactoryPreservesPartialPositionalCalls()
        {
            var policy = ArmCognitiveServicesModelFactory.RaiPolicyProperties(RaiPolicyType.UserManaged);
            Assert.AreEqual(RaiPolicyType.UserManaged, policy.PolicyType);

            var properties = ArmCognitiveServicesModelFactory.RaiPolicyProperties(
                RaiPolicyType.UserManaged, RaiPolicyMode.Blocking, "base");
            Assert.AreEqual(RaiPolicyType.UserManaged, properties.PolicyType);
            Assert.AreEqual(RaiPolicyMode.Blocking, properties.Mode);
            Assert.AreEqual("base", properties.BasePolicyName);
        }

        [Test]
        public void RaiPolicyPropertiesFactoryPreservesOptionalAndNewArguments()
        {
            Assert.IsNotNull(ArmCognitiveServicesModelFactory.RaiPolicyProperties());

            var policy = ArmCognitiveServicesModelFactory.RaiPolicyProperties(policyType: RaiPolicyType.UserManaged);
            Assert.AreEqual(RaiPolicyType.UserManaged, policy.PolicyType);

            var properties = ArmCognitiveServicesModelFactory.RaiPolicyProperties(
                RaiPolicyType.UserManaged, RaiPolicyMode.Blocking, "base", format: RaiPolicyFormat.ACS);
            Assert.AreEqual(RaiPolicyType.UserManaged, properties.PolicyType);
            Assert.AreEqual(RaiPolicyMode.Blocking, properties.Mode);
            Assert.AreEqual("base", properties.BasePolicyName);
            Assert.AreEqual(RaiPolicyFormat.ACS, properties.Format);
        }
    }
}
