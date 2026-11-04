// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkSecurity.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetworkSecurity.Tests
{
    public class NeuroShieldProtectedResourceWireTests
    {
        private const string SubscriptionId = "11111111-1111-1111-1111-111111111111";
        private const string ApiVersion = "2026-10-01-preview";
        private const string ParentId = "/subscriptions/" + SubscriptionId + "/resourceGroups/test-rg/providers/Microsoft.NetworkSecurity/neuroShields/test-shield";
        private const string ResourceId = ParentId + "/protectedResources/test-vm";
        private const string TargetId = "/subscriptions/" + SubscriptionId + "/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm";

        [TestCase(false)]
        [TestCase(true)]
        public async Task GetUsesResourceScopeAndDeserializesResponse(bool isAsync)
        {
            var transport = new MockTransport(new MockResponse(200).SetContent(ResourceResponse()));
            var resource = CreateClient(transport).GetNeuroShieldProtectedResource(new ResourceIdentifier(ResourceId));

            Response<NeuroShieldProtectedResource> result = isAsync ? await resource.GetAsync() : resource.Get();

            Assert.That(transport.SingleRequest.Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.SingleRequest.Uri.ToString(), Is.EqualTo($"https://management.azure.com{ResourceId}?api-version={ApiVersion}"));
            Assert.That(result.Value.HasData, Is.True);
            Assert.That(result.Value.Data.Id.ToString(), Is.EqualTo(ResourceId));
            Assert.That(result.Value.Data.Properties.TargetResourceId.ToString(), Is.EqualTo(TargetId));
            Assert.That(result.Value.Data.Properties.ProvisioningState, Is.EqualTo(ProvisioningStateNeuroShield.Succeeded));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task GetAllFollowsNextLinkAndReturnsResources(bool isAsync)
        {
            string nextLink = $"https://management.azure.com{ParentId}/protectedResources?api-version={ApiVersion}&$skipToken=next";
            var transport = new MockTransport(
                new MockResponse(200).SetContent($$"""{"value":[{{ResourceResponse()}}],"nextLink":"{{nextLink}}"}"""),
                new MockResponse(200).SetContent("""{"value":[]}"""));
            var collection = new NeuroShieldProtectedResourceCollection(CreateClient(transport), new ResourceIdentifier(ParentId));
            var resources = new List<NeuroShieldProtectedResource>();

            if (isAsync)
            {
                await foreach (var resource in collection.GetAllAsync(maxCount: 1))
                {
                    resources.Add(resource);
                }
            }
            else
            {
                resources.AddRange(collection.GetAll(maxCount: 1));
            }

            Assert.That(resources, Has.Count.EqualTo(1));
            Assert.That(resources[0].Data.Id.ToString(), Is.EqualTo(ResourceId));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(ParentId + "/protectedResources"));
            Assert.That(Uri.UnescapeDataString(transport.Requests[0].Uri.ToUri().Query), Does.Contain("$top=1"));
            Assert.That(transport.Requests[1].Uri.ToUri().AbsoluteUri, Is.EqualTo(nextLink));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateOrUpdateSerializesBodyAndConditionalHeader(bool isAsync)
        {
            var transport = new MockTransport(new MockResponse(200).SetContent(ResourceResponse()));
            var collection = new NeuroShieldProtectedResourceCollection(CreateClient(transport), new ResourceIdentifier(ParentId));
            var data = new NeuroShieldProtectedResourceData(new NeuroShieldProtectedResourceProperties(new ResourceIdentifier(TargetId)));
            var etag = new ETag("\"current-etag\"");

            ArmOperation<NeuroShieldProtectedResource> operation = isAsync
                ? await collection.CreateOrUpdateAsync(WaitUntil.Completed, "test-vm", data, etag)
                : collection.CreateOrUpdate(WaitUntil.Completed, "test-vm", data, etag);

            var request = transport.SingleRequest;
            Assert.That(request.Method, Is.EqualTo(RequestMethod.Put));
            Assert.That(request.Uri.ToString(), Is.EqualTo($"https://management.azure.com{ResourceId}?api-version={ApiVersion}"));
            Assert.That(request.Headers.TryGetValue("If-Match", out string ifMatch), Is.True);
            Assert.That(ifMatch, Is.EqualTo(etag.ToString()));
            using var stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);
            using var document = JsonDocument.Parse(stream.ToArray());
            var properties = document.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("targetResourceId").GetString(), Is.EqualTo(TargetId));
            Assert.That(properties.TryGetProperty("provisioningState", out _), Is.False);
            Assert.That(properties.TryGetProperty("targetIdentity", out _), Is.False);
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Id.ToString(), Is.EqualTo(ResourceId));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateOrUpdatePollsOperationAndRetrievesFinalResource(bool isAsync)
        {
            string pollingUri = $"https://management.azure.com/subscriptions/{SubscriptionId}/providers/Microsoft.NetworkSecurity/locations/eastus/operationStatuses/test-operation?api-version={ApiVersion}";
            var accepted = new MockResponse(201).SetContent(ResourceResponse());
            accepted.AddHeader("Azure-AsyncOperation", pollingUri);
            accepted.AddHeader("Retry-After", "0");
            var transport = new MockTransport(
                accepted,
                new MockResponse(200).SetContent("""{"status":"Succeeded"}"""),
                new MockResponse(200).SetContent(ResourceResponse()));
            var collection = new NeuroShieldProtectedResourceCollection(CreateClient(transport), new ResourceIdentifier(ParentId));
            var data = new NeuroShieldProtectedResourceData(new NeuroShieldProtectedResourceProperties(new ResourceIdentifier(TargetId)));

            ArmOperation<NeuroShieldProtectedResource> operation = isAsync
                ? await collection.CreateOrUpdateAsync(WaitUntil.Started, "test-vm", data)
                : collection.CreateOrUpdate(WaitUntil.Started, "test-vm", data);

            Assert.That(operation.HasCompleted, Is.False);
            if (isAsync)
            {
                await operation.WaitForCompletionAsync(TimeSpan.Zero, CancellationToken.None);
            }
            else
            {
                operation.WaitForCompletion(TimeSpan.Zero, CancellationToken.None);
            }

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Id.ToString(), Is.EqualTo(ResourceId));
            Assert.That(transport.Requests, Has.Count.EqualTo(3));
            Assert.That(transport.Requests[1].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[1].Uri.ToString(), Is.EqualTo(pollingUri));
            Assert.That(transport.Requests[2].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[2].Uri.ToString(), Is.EqualTo($"https://management.azure.com{ResourceId}?api-version={ApiVersion}"));
        }

        private static ArmClient CreateClient(MockTransport transport)
        {
            return new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
        }

        private static string ResourceResponse()
        {
            return $$"""
                {
                  "id": "{{ResourceId}}",
                  "name": "test-vm",
                  "type": "Microsoft.NetworkSecurity/neuroShields/protectedResources",
                  "properties": {
                    "targetResourceId": "{{TargetId}}",
                    "provisioningState": "Succeeded"
                  }
                }
                """;
        }
    }
}
