// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VirtualMachineScaleSetTagTests
    {
        [Test]
        public async Task SetTagsFailureDoesNotDeleteExistingTags()
        {
            const string subscriptionId = "83aa47df-e3e9-49ff-877b-94304bf3d3ad";
            var id = VirtualMachineScaleSetResource.CreateResourceIdentifier(subscriptionId, "rg", "vmss");
            var tags = new Dictionary<string, string> { ["existing"] = "keep" };
            int failedWrites = 0;

            var options = new ArmClientOptions
            {
                Transport = new MockTransport(request =>
                {
                    string path = request.Uri.ToUri().AbsolutePath;
                    if (path.EndsWith($"/subscriptions/{subscriptionId}", StringComparison.OrdinalIgnoreCase) && request.Method == RequestMethod.Get)
                    {
                        return new MockResponse(200).SetContent($"{{\"id\":\"/subscriptions/{subscriptionId}\",\"subscriptionId\":\"{subscriptionId}\",\"displayName\":\"test\",\"state\":\"Enabled\"}}");
                    }
                    if (path.EndsWith("/providers/Microsoft.Resources", StringComparison.OrdinalIgnoreCase) && request.Method == RequestMethod.Get)
                    {
                        return new MockResponse(200).SetContent($"{{\"id\":\"/subscriptions/{subscriptionId}/providers/Microsoft.Resources\",\"namespace\":\"Microsoft.Resources\",\"resourceTypes\":[{{\"resourceType\":\"tags\"}}]}}");
                    }
                    if (path.EndsWith("/providers/Microsoft.Resources/tags/default", StringComparison.OrdinalIgnoreCase))
                    {
                        if (request.Method == RequestMethod.Delete)
                        {
                            tags.Clear();
                            return new MockResponse(200).SetContent("{}");
                        }
                        if (request.Method == RequestMethod.Get)
                        {
                            string value = tags.Count == 0 ? "{}" : "{\"existing\":\"keep\"}";
                            return new MockResponse(200).SetContent($"{{\"id\":\"{path}\",\"properties\":{{\"tags\":{value}}}}}");
                        }
                    }
                    if (request.Method == RequestMethod.Put || request.Method == RequestMethod.Patch)
                    {
                        failedWrites++;
                        return new MockResponse(400).SetContent("{\"error\":{\"code\":\"FeatureNotRegistered\",\"message\":\"Tag update rejected\"}}");
                    }
                    Assert.Fail($"Unexpected request: {request.Method} {request.Uri}");
                    return null;
                })
            };

            var client = new ArmClient(new MockCredential(), subscriptionId, options);
            var vmss = client.GetVirtualMachineScaleSetResource(id);
            Assert.ThrowsAsync<RequestFailedException>(async () => await vmss.SetTagsAsync(new Dictionary<string, string> { ["replacement"] = "new" }));

            Assert.AreEqual(1, failedWrites, "The replacement request must be attempted and rejected.");
            Assert.That(tags, Is.EquivalentTo(new Dictionary<string, string> { ["existing"] = "keep" }),
                "A failed replacement must not remove the original tags.");
        }
    }
}
