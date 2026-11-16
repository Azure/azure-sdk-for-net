// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class ManagedComputeCapacityNamingTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public async Task CapacityListUsesExpectedRequest(bool async)
        {
            const string subscriptionId = "83aa47df-e3e9-49ff-877b-94304bf3d3ad";
            const string deploymentId = "/subscriptions/83aa47df-e3e9-49ff-877b-94304bf3d3ad/resourceGroups/rg/providers/Microsoft.CognitiveServices/accounts/account/deployments/deployment";
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
