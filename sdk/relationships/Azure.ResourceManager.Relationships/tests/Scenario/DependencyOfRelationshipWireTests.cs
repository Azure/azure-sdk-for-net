// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Relationships.Tests.Scenario
{
    public class DependencyOfRelationshipWireTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string ResourceGroupId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg-relationships";
        private const string TargetServiceGroupId = "/providers/Microsoft.Management/serviceGroups/target-sg";

        [Test]
        public async Task GetAll_SyncAndAsyncWrapResources()
        {
            const string firstName = "dependency1";
            const string secondName = "dependency2";
            string firstRelationship = CreateDependencyRelationship(firstName, ResourceGroupId, TargetServiceGroupId);
            string secondRelationship = CreateDependencyRelationship(secondName, ResourceGroupId, TargetServiceGroupId);
            string nextLink = $"https://management.azure.com{ResourceGroupId}/providers/Microsoft.Relationships/dependencyOf?api-version=2026-08-01&$skiptoken=page2";
            var transport = new MockTransport(
                CreateResponse(CreatePage(firstRelationship, nextLink)),
                CreateResponse(CreatePage(secondRelationship)),
                CreateResponse(CreatePage(firstRelationship, nextLink)),
                CreateResponse(CreatePage(secondRelationship)));
            var client = CreateClient(transport);
            DependencyOfRelationshipCollection collection = client.GetDependencyOfRelationships(new ResourceIdentifier(ResourceGroupId));

            var asyncPages = await collection.GetAllAsync().AsPages().ToEnumerableAsync();
            var syncPages = collection.GetAll().AsPages().ToList();

            Assert.AreEqual(2, asyncPages.Count);
            Assert.AreEqual(2, syncPages.Count);
            AssertDependencyResource(asyncPages[0].Values.Single(), firstName, ResourceGroupId, TargetServiceGroupId);
            AssertDependencyResource(asyncPages[1].Values.Single(), secondName, ResourceGroupId, TargetServiceGroupId);
            AssertDependencyResource(syncPages[0].Values.Single(), firstName, ResourceGroupId, TargetServiceGroupId);
            AssertDependencyResource(syncPages[1].Values.Single(), secondName, ResourceGroupId, TargetServiceGroupId);
            Assert.AreEqual(nextLink, asyncPages[0].ContinuationToken);
            Assert.AreEqual(nextLink, syncPages[0].ContinuationToken);
            Assert.AreEqual($"{ResourceGroupId}/providers/Microsoft.Relationships/dependencyOf", transport.Requests[0].Uri.Path);
            Assert.AreEqual(new Uri(nextLink).PathAndQuery, transport.Requests[1].Uri.PathAndQuery);
            Assert.AreEqual(transport.Requests[0].Uri.Path, transport.Requests[2].Uri.Path);
            Assert.AreEqual(new Uri(nextLink).PathAndQuery, transport.Requests[3].Uri.PathAndQuery);
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

        private static void AssertDependencyResource(DependencyOfRelationshipResource resource, string name, string sourceId, string targetId)
        {
            Assert.AreEqual(name, resource.Data.Name);
            Assert.AreEqual(new ResourceIdentifier(sourceId), resource.Data.Properties.SourceId);
            Assert.AreEqual(new ResourceIdentifier(targetId), resource.Data.Properties.TargetId);
        }
    }
}
