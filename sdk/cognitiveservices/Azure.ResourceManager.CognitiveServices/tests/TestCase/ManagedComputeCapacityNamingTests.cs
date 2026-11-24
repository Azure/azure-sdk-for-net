// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
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

        [TestCase(false)]
        [TestCase(true)]
        public async Task CapacityListUsesExpectedRequest(bool async)
        {
            const string subscriptionId = "83aa47df-e3e9-49ff-877b-94304bf3d3ad";
            var deploymentId = new ResourceIdentifier("/subscriptions/83aa47df-e3e9-49ff-877b-94304bf3d3ad/resourceGroups/rg/providers/Microsoft.CognitiveServices/accounts/account/deployments/deployment");
            string requestUri = null;
            var options = new ArmClientOptions
            {
                Transport = new MockTransport(request =>
                {
                    requestUri = request.Uri.ToString();
                    var response = new MockResponse(200);
                    response.SetContent("{\"value\":[]}");
                    return response;
                })
            };
            var client = new ArmClient(new MockCredential(), subscriptionId, options);
            var subscription = client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{subscriptionId}"));

            if (async)
            {
                await foreach (var item in subscription.GetCognitiveServicesManagedComputeCapacitiesAsync("offer", "gpu", deploymentId, "eastus"))
                {
                    Assert.Fail("Expected no capacities.");
                }
            }
            else
            {
                Assert.IsEmpty(subscription.GetCognitiveServicesManagedComputeCapacities("offer", "gpu", deploymentId, "eastus").ToList());
            }

            Assert.NotNull(requestUri);
            var uri = new Uri(requestUri);
            Assert.AreEqual($"/subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/managedComputeCapacities", uri.AbsolutePath);
            string query = Uri.UnescapeDataString(uri.Query);
            StringAssert.Contains("offer=offer", query);
            StringAssert.Contains("acceleratorType=gpu", query);
            StringAssert.Contains($"deploymentId={deploymentId}", query);
            StringAssert.Contains("location=eastus", query);
            StringAssert.Contains("api-version=2026-11-01", query);
        }
    }
}
