// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Relationships.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Relationships.Tests.Scenario
{
    public class ContainsRelationshipTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string ResourceGroupName = "rg-contains";
        private const string Filter = "properties.metadata.targetType eq 'Microsoft.KeyVault/vaults'";

        [TestCase(false)]
        [TestCase(true)]
        public async Task GetByResourceGroupContainsRelationships_EncodesFilterAndFollowsNextLink(bool async)
        {
            string sourceId = $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}";
            string firstTargetId = $"{sourceId}/providers/Microsoft.KeyVault/vaults/vault1";
            string secondTargetId = $"{sourceId}/providers/Microsoft.KeyVault/vaults/vault2";
            string nextLink = $"https://management.azure.com{sourceId}/providers/Microsoft.Relationships/contains?api-version=2026-08-01&$skiptoken=page2";
            var transport = new MockTransport(
                CreateResponse(CreatePage("contains1", sourceId, firstTargetId, nextLink)),
                CreateResponse(CreatePage("contains2", sourceId, secondTargetId)));
            var client = CreateClient(transport);
            ResourceGroupResource resourceGroup = client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName));

            List<Page<ContainsRelationship>> pages;
            if (async)
            {
                pages = new List<Page<ContainsRelationship>>();
                await foreach (Page<ContainsRelationship> page in resourceGroup.GetByResourceGroupContainsRelationshipsAsync(Filter).AsPages())
                {
                    pages.Add(page);
                }
            }
            else
            {
                pages = resourceGroup.GetByResourceGroupContainsRelationships(Filter).AsPages().ToList();
            }

            Assert.AreEqual(2, pages.Count);
            Assert.AreEqual(nextLink, pages[0].ContinuationToken);
            Assert.IsNull(pages[1].ContinuationToken);
            AssertContainsRelationship(pages[0].Values.Single(), "contains1", sourceId, firstTargetId);
            AssertContainsRelationship(pages[1].Values.Single(), "contains2", sourceId, secondTargetId);
            Assert.AreEqual($"{sourceId}/providers/Microsoft.Relationships/contains", transport.Requests[0].Uri.Path);
            StringAssert.Contains($"$filter={Filter}", Uri.UnescapeDataString(transport.Requests[0].Uri.Query));
            Assert.AreEqual(new Uri(nextLink).PathAndQuery, transport.Requests[1].Uri.PathAndQuery);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task GetBySubscriptionContainsRelationships_EncodesFilterAndFollowsNextLink(bool async)
        {
            string sourceId = $"/subscriptions/{SubscriptionId}";
            string firstTargetId = $"{sourceId}/resourceGroups/{ResourceGroupName}";
            string secondTargetId = $"{sourceId}/resourceGroups/rg-contains-2";
            string nextLink = $"https://management.azure.com{sourceId}/providers/Microsoft.Relationships/contains?api-version=2026-08-01&$skiptoken=page2";
            var transport = new MockTransport(
                CreateResponse(CreatePage("contains1", sourceId, firstTargetId, nextLink)),
                CreateResponse(CreatePage("contains2", sourceId, secondTargetId)));
            var client = CreateClient(transport);
            SubscriptionResource subscription = client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));

            List<Page<ContainsRelationship>> pages;
            if (async)
            {
                pages = new List<Page<ContainsRelationship>>();
                await foreach (Page<ContainsRelationship> page in subscription.GetBySubscriptionContainsRelationshipsAsync(Filter).AsPages())
                {
                    pages.Add(page);
                }
            }
            else
            {
                pages = subscription.GetBySubscriptionContainsRelationships(Filter).AsPages().ToList();
            }

            Assert.AreEqual(2, pages.Count);
            Assert.AreEqual(nextLink, pages[0].ContinuationToken);
            Assert.IsNull(pages[1].ContinuationToken);
            AssertContainsRelationship(pages[0].Values.Single(), "contains1", sourceId, firstTargetId);
            AssertContainsRelationship(pages[1].Values.Single(), "contains2", sourceId, secondTargetId);
            Assert.AreEqual($"{sourceId}/providers/Microsoft.Relationships/contains", transport.Requests[0].Uri.Path);
            StringAssert.Contains($"$filter={Filter}", Uri.UnescapeDataString(transport.Requests[0].Uri.Query));
            Assert.AreEqual(new Uri(nextLink).PathAndQuery, transport.Requests[1].Uri.PathAndQuery);
        }

        private static ArmClient CreateClient(MockTransport transport)
        {
            var options = new ArmClientOptions { Transport = transport };
            return new ArmClient(new MockCredential(), SubscriptionId, options);
        }

        private static MockResponse CreateResponse(string content)
        {
            return new MockResponse(200).SetContent(content).AddHeader("Content-Type", "application/json");
        }

        private static string CreatePage(string name, string sourceId, string targetId, string nextLink = null)
        {
            string id = $"{sourceId}/providers/Microsoft.Relationships/contains/{name}";
            string continuation = nextLink == null ? string.Empty : $",\"nextLink\":\"{nextLink}\"";
            return $"{{\"value\":[{{\"id\":\"{id}\",\"name\":\"{name}\",\"type\":\"Microsoft.Relationships/contains\",\"properties\":{{\"sourceId\":\"{sourceId}\",\"targetId\":\"{targetId}\",\"targetTenant\":\"tenant1\",\"metadata\":{{\"sourceType\":\"Microsoft.Resources/resourceGroups\",\"targetType\":\"Microsoft.KeyVault/vaults\"}},\"provisioningState\":\"Succeeded\"}}}}]{continuation}}}";
        }

        private static void AssertContainsRelationship(ContainsRelationship relationship, string name, string sourceId, string targetId)
        {
            Assert.AreEqual(name, relationship.Name);
            Assert.AreEqual("Microsoft.Relationships/contains", relationship.ResourceType.ToString());
            Assert.AreEqual(new ResourceIdentifier(sourceId), relationship.Properties.SourceId);
            Assert.AreEqual(new ResourceIdentifier(targetId), relationship.Properties.TargetId);
            Assert.AreEqual("tenant1", relationship.Properties.TargetTenant);
            Assert.AreEqual("Microsoft.Resources/resourceGroups", relationship.Properties.Metadata.SourceType.ToString());
            Assert.AreEqual("Microsoft.KeyVault/vaults", relationship.Properties.Metadata.TargetType.ToString());
            Assert.AreEqual(RelationshipProvisioningState.Succeeded, relationship.Properties.ProvisioningState);
        }
    }
}
