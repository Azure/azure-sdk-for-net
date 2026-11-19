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
    public class ServiceGroupMemberRelationshipWireTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string ResourceGroupId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg-relationships";
        private const string SourceServiceGroupId = "/providers/Microsoft.Management/serviceGroups/source-sg";

        [Test]
        public async Task GetAll_SyncAndAsyncWrapResources()
        {
            const string firstName = "member1";
            const string secondName = "member2";
            string firstRelationship = CreateServiceGroupMemberRelationship(firstName, SourceServiceGroupId, ResourceGroupId);
            string secondRelationship = CreateServiceGroupMemberRelationship(secondName, SourceServiceGroupId, ResourceGroupId);
            string nextLink = $"https://management.azure.com{ResourceGroupId}/providers/Microsoft.Relationships/serviceGroupMember?api-version=2026-08-01&$skiptoken=page2";
            var transport = new MockTransport(
                CreateResponse(CreatePage(firstRelationship, nextLink)),
                CreateResponse(CreatePage(secondRelationship)),
                CreateResponse(CreatePage(firstRelationship, nextLink)),
                CreateResponse(CreatePage(secondRelationship)));
            var client = CreateClient(transport);
            ServiceGroupMemberRelationshipCollection collection = client.GetServiceGroupMemberRelationships(new ResourceIdentifier(ResourceGroupId));

            var asyncPages = await collection.GetAllAsync().AsPages().ToEnumerableAsync();
            var syncPages = collection.GetAll().AsPages().ToList();

            Assert.AreEqual(2, asyncPages.Count);
            Assert.AreEqual(2, syncPages.Count);
            AssertServiceGroupMemberResource(asyncPages[0].Values.Single(), firstName);
            AssertServiceGroupMemberResource(asyncPages[1].Values.Single(), secondName);
            AssertServiceGroupMemberResource(syncPages[0].Values.Single(), firstName);
            AssertServiceGroupMemberResource(syncPages[1].Values.Single(), secondName);
            Assert.AreEqual(nextLink, asyncPages[0].ContinuationToken);
            Assert.AreEqual(nextLink, syncPages[0].ContinuationToken);
            Assert.AreEqual($"{ResourceGroupId}/providers/Microsoft.Relationships/serviceGroupMember", transport.Requests[0].Uri.Path);
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

        private static string CreateServiceGroupMemberRelationship(string name, string sourceId, string targetId)
        {
            string id = $"{targetId}/providers/Microsoft.Relationships/serviceGroupMember/{name}";
            return $"{{\"id\":\"{id}\",\"name\":\"{name}\",\"type\":\"Microsoft.Relationships/serviceGroupMember\",\"properties\":{{\"sourceId\":\"{sourceId}\",\"targetId\":\"{targetId}\",\"provisioningState\":\"Succeeded\"}}}}";
        }

        private static void AssertServiceGroupMemberResource(ServiceGroupMemberRelationshipResource resource, string name)
        {
            Assert.AreEqual(name, resource.Data.Name);
            Assert.AreEqual(new ResourceIdentifier(SourceServiceGroupId), resource.Data.Properties.SourceId);
            Assert.AreEqual(new ResourceIdentifier(ResourceGroupId), resource.Data.Properties.TargetId);
        }
    }
}
