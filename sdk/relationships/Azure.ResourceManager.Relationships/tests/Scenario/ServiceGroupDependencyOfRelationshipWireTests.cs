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

        private static ArmClient CreateClient(MockTransport transport)
        {
            return new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
        }

        private static MockResponse CreateResponse(string content)
        {
            return new MockResponse(200).SetContent(content).AddHeader("Content-Type", "application/json");
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
