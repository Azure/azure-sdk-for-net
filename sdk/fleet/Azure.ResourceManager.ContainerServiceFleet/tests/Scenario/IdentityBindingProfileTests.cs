// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerServiceFleet.Tests.Scenario
{
    public class IdentityBindingProfileTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public async Task ApplyPollsUntilCompleted(bool isAsync)
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000001";
            ResourceIdentifier resourceId = IdentityBindingProfileResource.CreateResourceIdentifier(
                subscriptionId, "test-rg", "test-fleet", "test-profile");
            string pollingUrl = "https://management.azure.com/subscriptions/" + subscriptionId + "/providers/Microsoft.ContainerService/locations/eastus/operationResults/test-operation?api-version=2026-11-02-preview";
            var accepted = new MockResponse(202).WithHeader("Location", pollingUrl).WithHeader("Retry-After", "0");
            var running = new MockResponse(202).WithHeader("Retry-After", "0");
            var completed = new MockResponse(200);
            completed.SetContent(BinaryData.FromObjectAsJson(new
            {
                id = resourceId.ToString(),
                name = "test-profile",
                type = "Microsoft.ContainerService/fleets/identityBindingProfiles",
                eTag = "\"updated-etag\"",
                properties = new
                {
                    provisioningState = "Succeeded",
                    memberSelector = new { byLabel = "env=production" }
                }
            }).ToString());
            var transport = new MockTransport(accepted, running, completed);
            var client = new ArmClient(new MockCredential(), subscriptionId, new ArmClientOptions { Transport = transport });
            IdentityBindingProfileResource profile = client.GetIdentityBindingProfileResource(resourceId);
            var ifMatch = new ETag("\"original-etag\"");

            ArmOperation<IdentityBindingProfileResource> operation = isAsync
                ? await profile.ApplyAsync(WaitUntil.Started, ifMatch)
                : profile.Apply(WaitUntil.Started, ifMatch);

            Assert.IsFalse(operation.HasCompleted);
            Assert.AreEqual(1, transport.Requests.Count);
            Request request = transport.Requests[0];
            Assert.AreEqual(RequestMethod.Post, request.Method);
            Assert.AreEqual("https://management.azure.com" + resourceId + "/apply?api-version=2026-11-02-preview", request.Uri.ToString());
            Assert.IsTrue(request.Headers.TryGetValue("If-Match", out string actualIfMatch));
            Assert.AreEqual(ifMatch.ToString(), actualIfMatch);
            Assert.IsNull(request.Content);

            if (isAsync)
            {
                await operation.WaitForCompletionAsync();
            }
            else
            {
                operation.WaitForCompletion();
            }

            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual(3, transport.Requests.Count);
            for (int i = 1; i < transport.Requests.Count; i++)
            {
                Assert.AreEqual(RequestMethod.Get, transport.Requests[i].Method);
                Assert.AreEqual(pollingUrl, transport.Requests[i].Uri.ToString());
            }
            Assert.AreEqual(resourceId, operation.Value.Id);
            Assert.AreEqual("test-profile", operation.Value.Data.Name);
            Assert.AreEqual("Succeeded", operation.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual("env=production", operation.Value.Data.MemberSelectorByLabel);
            Assert.AreEqual(new ETag("\"updated-etag\""), operation.Value.Data.ETag);
        }
    }
}
