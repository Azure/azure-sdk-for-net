// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOperator.Tests
{
    public class SystemReadinessTests
    {
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task GetSystemReadiness(bool isAsync, bool isSystemReady)
        {
            const string subscriptionId = "83aa47df-e3e9-49ff-877b-94304bf3d3ad";
            const string resourcePath = "/subscriptions/" + subscriptionId + "/providers/Microsoft.EdgeOperator/systemReadiness/default";
            int requestCount = 0;
            var transport = new MockTransport(request =>
            {
                requestCount++;
                Assert.That(request.Method, Is.EqualTo(RequestMethod.Get));
                Assert.That(
                    request.Uri.ToUri().AbsoluteUri,
                    Is.EqualTo("https://management.azure.com" + resourcePath + "?api-version=2026-06-01-preview"));

                var response = new MockResponse(200);
                response.AddHeader("Content-Type", "application/json");
                response.SetContent($$"""
                    {
                      "id": "{{resourcePath}}",
                      "name": "default",
                      "type": "Microsoft.EdgeOperator/systemReadiness",
                      "properties": {
                        "systemReady": {{isSystemReady.ToString().ToLowerInvariant()}},
                        "categories": [
                          {
                            "categoryName": "services",
                            "readinessPercentage": 100,
                            "errorMessageDetails": []
                          },
                          {
                            "categoryName": "networking",
                            "readinessPercentage": 75,
                            "errorMessageDetails": ["Network configuration is incomplete.", "DNS is unavailable."]
                          }
                        ]
                      }
                    }
                    """);
                return response;
            });
            var client = new ArmClient(new MockCredential(), subscriptionId, new ArmClientOptions { Transport = transport });
            var subscription = client.GetSubscriptionResource(new ResourceIdentifier("/subscriptions/" + subscriptionId));
            var resource = subscription.GetSystemReadiness();

            var result = isAsync ? await resource.GetAsync() : resource.Get();

            Assert.That(requestCount, Is.EqualTo(1));
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(result.Value.HasData, Is.True);
            Assert.That(result.Value.Id.ToString(), Is.EqualTo(resourcePath));
            Assert.That(result.Value.Data.Name, Is.EqualTo("default"));
            Assert.That(result.Value.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.EdgeOperator/systemReadiness"));

            var properties = result.Value.Data.Properties;
            Assert.That(properties.IsSystemReady, Is.EqualTo(isSystemReady));
            Assert.That(properties.Categories.Count, Is.EqualTo(2));
            Assert.That(properties.Categories[0].CategoryName, Is.EqualTo("services"));
            Assert.That(properties.Categories[0].ReadinessPercentage, Is.EqualTo(100));
            Assert.That(properties.Categories[0].ErrorMessageDetails, Is.Empty);
            Assert.That(properties.Categories[1].CategoryName, Is.EqualTo("networking"));
            Assert.That(properties.Categories[1].ReadinessPercentage, Is.EqualTo(75));
            Assert.That(
                properties.Categories[1].ErrorMessageDetails,
                Is.EqualTo(new[] { "Network configuration is incomplete.", "DNS is unavailable." }));
        }
    }
}
