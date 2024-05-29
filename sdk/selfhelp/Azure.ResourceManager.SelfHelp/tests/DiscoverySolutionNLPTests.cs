﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.SelfHelp.Models;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SelfHelp.Tests
{
    public class DiscoverySolutionNLPTests : SelfHelpManagementTestBase
    {
        public DiscoverySolutionNLPTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task DiscoveryNlpSubscriptionScopeTest()
        {
            var discoveryNlpReqObject = GetDiscoveryNlpContent();
            var solutionNlpMetadataResource = DefaultSubscription.PostDiscoverySolutionNLPSubscriptionScopesAsync(discoveryNlpReqObject);
            var response = await solutionNlpMetadataResource.ToEnumerableAsync();

            Assert.IsNotNull(response.First());
        }

        [Test]
        public async Task DiscoveryNlpTenantScopeTest()
        {
            var discoveryNlpReqObject = GetDiscoveryNlpContent();
            var solutionNlpMetadataResource = DefaultTenantResource.PostDiscoverySolutionNLPTenantScopesAsync(discoveryNlpReqObject);
            var response = await solutionNlpMetadataResource.ToEnumerableAsync();

            Assert.IsNotNull(response.First());
        }

        private DiscoveryNlpContent GetDiscoveryNlpContent()
        {
            var issueSummary = "I am not able to make rdp connection to the virtual machine";
            var serviceId = "6f16735c-b0ae-b275-ad3a-03479cfa1396";
            var content = new DiscoveryNlpContent(issueSummary, null, serviceId, null, null);

            return content;
        }
    }
}
