// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Relationships.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Relationships.Tests.Scenario
{
    public class ServiceGroupDependencyOfRelationshipWireTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string SourceServiceGroupId = "/providers/Microsoft.Management/serviceGroups/source-sg";
        private const string TargetServiceGroupId = "/providers/Microsoft.Management/serviceGroups/target-sg";

        [Test]
        public async Task Lifecycle_CompletesLongRunningOperations()
        {
            const string relationshipName = "dependency1";
            string relationship = CreateDependencyRelationship(relationshipName, SourceServiceGroupId, TargetServiceGroupId);
            string secondRelationship = CreateDependencyRelationship("dependency2", SourceServiceGroupId, TargetServiceGroupId);
            string listPath = $"{SourceServiceGroupId}/providers/Microsoft.Relationships/dependencyOf";
            string nextLink = $"https://management.azure.com{listPath}?api-version=2026-08-01&$skiptoken=page2";
            var transport = new MockTransport(
                CreateResponse(relationship),
                CreateResponse(relationship),
                CreateResponse(relationship),
                CreateResponse(CreatePage(relationship, nextLink)),
                CreateResponse(CreatePage(secondRelationship)),
                CreateResponse(CreatePage(relationship, nextLink)),
                CreateResponse(CreatePage(secondRelationship)),
                CreateResponse(relationship),
                new MockResponse(204),
                new MockResponse(404));
            var client = CreateClient(transport);
            var sourceId = new ResourceIdentifier(SourceServiceGroupId);
            var targetId = new ResourceIdentifier(TargetServiceGroupId);
            ServiceGroupDependencyOfRelationshipCollection collection = client.GetServiceGroupDependencyOfRelationships(sourceId);
            var data = new DependencyOfRelationshipData
            {
                Properties = ArmRelationshipsModelFactory.DependencyOfRelationshipProperties(sourceId, targetId)
            };

            var createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, data);
            ServiceGroupDependencyOfRelationshipResource resource = createOperation.Value;
            Assert.IsTrue(createOperation.HasCompleted);
            Assert.AreEqual(sourceId, resource.Data.Properties.SourceId);
            Assert.AreEqual(targetId, resource.Data.Properties.TargetId);

            Response<ServiceGroupDependencyOfRelationshipResource> getResponse = await collection.GetAsync(relationshipName);
            Assert.AreEqual(resource.Id, getResponse.Value.Id);
            Assert.IsTrue((await collection.ExistsAsync(relationshipName)).Value);
            var asyncPages = await collection.GetAllAsync().AsPages().ToEnumerableAsync();
            var syncPages = collection.GetAll().AsPages().ToList();
            Assert.AreEqual(2, asyncPages.Count);
            Assert.AreEqual(2, syncPages.Count);
            Assert.AreEqual(nextLink, asyncPages[0].ContinuationToken);
            Assert.AreEqual(nextLink, syncPages[0].ContinuationToken);
            Assert.That(asyncPages.SelectMany(page => page.Values), Has.One.Matches<ServiceGroupDependencyOfRelationshipResource>(item => item.Id == resource.Id));
            Assert.That(syncPages.SelectMany(page => page.Values), Has.One.Matches<ServiceGroupDependencyOfRelationshipResource>(item => item.Id == resource.Id));

            var updateOperation = await resource.UpdateAsync(WaitUntil.Completed, data);
            Assert.IsTrue(updateOperation.HasCompleted);
            Assert.AreEqual(targetId, updateOperation.Value.Data.Properties.TargetId);

            var deleteOperation = await resource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteOperation.HasCompleted);
            Assert.IsFalse((await collection.ExistsAsync(relationshipName)).Value);

            string resourcePath = $"{listPath}/{relationshipName}";
            Assert.AreEqual(resourcePath, transport.Requests[0].Uri.Path);
            Assert.AreEqual(resourcePath, transport.Requests[1].Uri.Path);
            Assert.AreEqual(resourcePath, transport.Requests[2].Uri.Path);
            Assert.AreEqual(listPath, transport.Requests[3].Uri.Path);
            Assert.AreEqual(new Uri(nextLink).PathAndQuery, transport.Requests[4].Uri.PathAndQuery);
            Assert.AreEqual(listPath, transport.Requests[5].Uri.Path);
            Assert.AreEqual(new Uri(nextLink).PathAndQuery, transport.Requests[6].Uri.PathAndQuery);
            Assert.AreEqual(resourcePath, transport.Requests[7].Uri.Path);
            Assert.AreEqual(resourcePath, transport.Requests[8].Uri.Path);
            Assert.AreEqual(resourcePath, transport.Requests[9].Uri.Path);
        }

        [Test]
        public async Task Lifecycle_PollsPendingLongRunningOperations()
        {
            const string relationshipName = "dependency1";
            string relationship = CreateDependencyRelationship(relationshipName, SourceServiceGroupId, TargetServiceGroupId);
            string resourcePath = $"{SourceServiceGroupId}/providers/Microsoft.Relationships/dependencyOf/{relationshipName}";
            const string createPollingPath = "/providers/Microsoft.Relationships/operations/create-operation";
            const string updatePollingPath = "/providers/Microsoft.Relationships/operations/update-operation";
            const string deletePollingPath = "/providers/Microsoft.Relationships/operations/delete-operation";
            var transport = new MockTransport(
                CreatePendingResponse("Azure-AsyncOperation", createPollingPath),
                CreatePollingResponse("InProgress"),
                CreatePollingResponse("Succeeded"),
                CreateResponse(relationship),
                CreatePendingResponse("Azure-AsyncOperation", updatePollingPath),
                CreatePollingResponse("InProgress"),
                CreatePollingResponse("Succeeded"),
                CreateResponse(relationship),
                CreatePendingResponse("Location", deletePollingPath),
                CreatePendingResponse("Location", deletePollingPath),
                new MockResponse(204));
            var client = CreateClient(transport);
            var sourceId = new ResourceIdentifier(SourceServiceGroupId);
            var targetId = new ResourceIdentifier(TargetServiceGroupId);
            ServiceGroupDependencyOfRelationshipCollection collection = client.GetServiceGroupDependencyOfRelationships(sourceId);
            var data = new DependencyOfRelationshipData
            {
                Properties = ArmRelationshipsModelFactory.DependencyOfRelationshipProperties(sourceId, targetId)
            };

            ArmOperation<ServiceGroupDependencyOfRelationshipResource> createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, data);
            Assert.IsTrue(createOperation.HasCompleted);
            Assert.AreEqual(targetId, createOperation.Value.Data.Properties.TargetId);

            ArmOperation<ServiceGroupDependencyOfRelationshipResource> updateOperation = await createOperation.Value.UpdateAsync(WaitUntil.Completed, data);
            Assert.IsTrue(updateOperation.HasCompleted);
            Assert.AreEqual(targetId, updateOperation.Value.Data.Properties.TargetId);

            ArmOperation deleteOperation = await updateOperation.Value.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteOperation.HasCompleted);

            Assert.AreEqual(resourcePath, transport.Requests[0].Uri.Path);
            Assert.AreEqual(createPollingPath, transport.Requests[1].Uri.Path);
            Assert.AreEqual(createPollingPath, transport.Requests[2].Uri.Path);
            Assert.AreEqual(resourcePath, transport.Requests[3].Uri.Path);
            Assert.AreEqual(resourcePath, transport.Requests[4].Uri.Path);
            Assert.AreEqual(updatePollingPath, transport.Requests[5].Uri.Path);
            Assert.AreEqual(updatePollingPath, transport.Requests[6].Uri.Path);
            Assert.AreEqual(resourcePath, transport.Requests[7].Uri.Path);
            Assert.AreEqual(resourcePath, transport.Requests[8].Uri.Path);
            Assert.AreEqual(deletePollingPath, transport.Requests[9].Uri.Path);
            Assert.AreEqual(deletePollingPath, transport.Requests[10].Uri.Path);
        }

        private static ArmClient CreateClient(MockTransport transport)
        {
            return new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
        }

        private static MockResponse CreateResponse(string content)
        {
            return new MockResponse(200).SetContent(content).AddHeader("Content-Type", "application/json");
        }

        private static MockResponse CreatePendingResponse(string pollingHeader, string pollingPath)
        {
            return new MockResponse(202)
                .AddHeader(pollingHeader, $"https://management.azure.com{pollingPath}")
                .AddHeader("Retry-After", "0");
        }

        private static MockResponse CreatePollingResponse(string status)
        {
            return new MockResponse(200)
                .SetContent($"{{\"status\":\"{status}\"}}")
                .AddHeader("Content-Type", "application/json")
                .AddHeader("Retry-After", "0");
        }

        private static string CreatePage(string relationship, string nextLink = null)
        {
            string continuation = nextLink == null ? string.Empty : $",\"nextLink\":\"{nextLink}\"";
            return $"{{\"value\":[{relationship}]{continuation}}}";
        }

        private static string CreateDependencyRelationship(string name, string sourceId, string targetId)
        {
            string id = $"{sourceId}/providers/Microsoft.Relationships/dependencyOf/{name}";
            return $"{{\"id\":\"{id}\",\"name\":\"{name}\",\"type\":\"Microsoft.Relationships/dependencyOf\",\"properties\":{{\"sourceId\":\"{sourceId}\",\"targetId\":\"{targetId}\",\"provisioningState\":\"Succeeded\"}}}}";
        }
    }
}
