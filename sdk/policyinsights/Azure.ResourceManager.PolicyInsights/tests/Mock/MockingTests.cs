// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.PolicyInsights.Mocking;
using Azure.ResourceManager.PolicyInsights.Models;
using Azure.ResourceManager.Resources;
using Moq;
using NUnit.Framework;

namespace Azure.ResourceManager.PolicyInsights.Tests.Mock
{
    public class MockingTests
    {
        [Test]
        public async Task Mocking_GetPolicyAssignmentExtensions()
        {
            #region mocking data
            var subscriptionId = Guid.NewGuid().ToString();
            var policyAssignmentName = Guid.NewGuid().ToString();
            var policyAssignmentId = PolicyAssignmentResource.CreateResourceIdentifier(SubscriptionResource.CreateResourceIdentifier(subscriptionId), policyAssignmentName);
            var querySettings = new PolicyQuerySettings()
            {
                OrderBy = "PolicyAssignmentId, ResourceId asc"
            };
            var summaryResult = new List<PolicySummary>
            {
                ArmPolicyInsightsModelFactory.PolicySummary(odataContext: "1"),
                ArmPolicyInsightsModelFactory.PolicySummary(odataContext: "2"),
            };
            #endregion

            #region mocking setup
            var clientMock = new Mock<ArmClient>();
            var policyAssignmentExtensionMock = new Mock<MockablePolicyInsightsPolicyAssignmentResource>();
            var policyAssignmentResourceMock = new Mock<PolicyAssignmentResource>();
            var pageableResultMock = new Mock<AsyncPageable<PolicySummary>>();
            // set up Id
            policyAssignmentResourceMock.Setup(a => a.Id).Returns(policyAssignmentId);
            // setup the mock for getting policy assignment resource
            clientMock.Setup(c => c.GetPolicyAssignmentResource(policyAssignmentId)).Returns(policyAssignmentResourceMock.Object);
            // setup the mock for getting policy states
            // step 1: setup the extension instance
            var pageableResult = AsyncPageable<PolicySummary>.FromPages(new[] { Page<PolicySummary>.FromValues(summaryResult, null, null) });
            policyAssignmentExtensionMock.Setup(e => e.SummarizePolicyStatesAsync(PolicyStateSummaryType.Latest, querySettings, default)).Returns(pageableResult); // creating a pageable result is quite cumbersome
            // step 2: setup the extendee to return the result
            policyAssignmentResourceMock.Setup(a => a.GetCachedClient(It.IsAny<Func<ArmClient, MockablePolicyInsightsPolicyAssignmentResource>>())).Returns(policyAssignmentExtensionMock.Object);
            #endregion

            var client = clientMock.Object;
            var policyAssignmentResource = client.GetPolicyAssignmentResource(policyAssignmentId);
            var result = policyAssignmentResource.SummarizePolicyStatesAsync(PolicyStateSummaryType.Latest, querySettings);
            var count = 0;
            await foreach (var item in result)
            {
                Assert.AreEqual(summaryResult[count], item);
                count++;
            }
        }
    }
}
