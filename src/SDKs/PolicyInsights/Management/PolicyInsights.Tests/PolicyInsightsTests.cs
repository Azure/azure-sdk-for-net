// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using Microsoft.Azure.Management.PolicyInsights;
using Microsoft.Azure.Management.PolicyInsights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using PolicyInsights.Tests.Helpers;
using Xunit;

namespace PolicyInsights.Tests
{
    public class PolicyInsightsTests : TestBase
    {
        #region Test setup

        static PolicyInsightsTests()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }
        }

        public static TestEnvironment TestEnvironment { get; }

        private static PolicyInsightsClient GetPolicyInsightsClient(MockContext context)
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };
            var policyInsightsClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<PolicyInsightsClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<PolicyInsightsClient>(handlers: handler);
            return policyInsightsClient;
        }

        #endregion

        #region Validation

        private void ValidatePolicyEventsQueryResults(PolicyEventsQueryResults queryResults)
        {
            Assert.NotNull(queryResults);

            Assert.False(string.IsNullOrEmpty(queryResults.Odatacontext));
            Assert.True(queryResults.Odatacount.HasValue);
            Assert.True(queryResults.Odatacount.Value > 0);

            Assert.NotNull(queryResults.Value);
            Assert.NotEmpty(queryResults.Value);

            foreach (var policyEvent in queryResults.Value)
            {
                Assert.NotNull(policyEvent);

                Assert.Null(policyEvent.Odataid);
                Assert.False(string.IsNullOrEmpty(policyEvent.Odatacontext));

                Assert.True(policyEvent.Timestamp.HasValue);
                Assert.False(string.IsNullOrEmpty(policyEvent.ResourceId));
                Assert.False(string.IsNullOrEmpty(policyEvent.PolicyAssignmentId));
                Assert.False(string.IsNullOrEmpty(policyEvent.PolicyDefinitionId));
                Assert.True(policyEvent.IsCompliant.HasValue);
                Assert.False(string.IsNullOrEmpty(policyEvent.SubscriptionId));
                Assert.False(string.IsNullOrEmpty(policyEvent.PolicyDefinitionAction));
                Assert.False(string.IsNullOrEmpty(policyEvent.TenantId));
                Assert.False(string.IsNullOrEmpty(policyEvent.PrincipalOid));

                Assert.NotNull(policyEvent.AdditionalProperties);
            }
        }

        private void ValidatePolicyStatesQueryResults(PolicyStatesQueryResults queryResults)
        {
            Assert.NotNull(queryResults);

            Assert.False(string.IsNullOrEmpty(queryResults.Odatacontext));
            Assert.True(queryResults.Odatacount.HasValue);
            Assert.True(queryResults.Odatacount.Value > 0);

            Assert.NotNull(queryResults.Value);
            Assert.NotEmpty(queryResults.Value);

            foreach (var policyState in queryResults.Value)
            {
                Assert.NotNull(policyState);

                Assert.Null(policyState.Odataid);
                Assert.False(string.IsNullOrEmpty(policyState.Odatacontext));

                Assert.True(policyState.Timestamp.HasValue);
                Assert.False(string.IsNullOrEmpty(policyState.ResourceId));
                Assert.False(string.IsNullOrEmpty(policyState.PolicyAssignmentId));
                Assert.False(string.IsNullOrEmpty(policyState.PolicyDefinitionId));
                Assert.True(policyState.IsCompliant.HasValue);
                Assert.False(string.IsNullOrEmpty(policyState.SubscriptionId));
                Assert.False(string.IsNullOrEmpty(policyState.PolicyDefinitionAction));

                Assert.NotNull(policyState.AdditionalProperties);
            }
        }

        private void ValidateSummarizeResults(SummarizeResults summarizeResults)
        {
            Assert.NotNull(summarizeResults);

            Assert.False(string.IsNullOrEmpty(summarizeResults.Odatacontext));
            Assert.True(summarizeResults.Odatacount.HasValue);
            Assert.True(1 == summarizeResults.Odatacount.Value);

            Assert.NotNull(summarizeResults.Value);
            Assert.True(1 == summarizeResults.Value.Count);

            var summary = summarizeResults.Value[0];

            Assert.NotNull(summary);

            Assert.Null(summary.Odataid);
            Assert.False(string.IsNullOrEmpty(summary.Odatacontext));

            Assert.NotNull(summary.Results);
            Assert.False(string.IsNullOrEmpty(summary.Results.QueryResultsUri));
            Assert.True(summary.Results.NonCompliantResources.HasValue);
            Assert.True(summary.Results.NonCompliantPolicies.HasValue);

            Assert.NotNull(summary.PolicyAssignments);
            Assert.True(summary.PolicyAssignments.Count == summary.Results.NonCompliantPolicies.Value);

            foreach (var policyAssignmentSummary in summary.PolicyAssignments)
            {
                Assert.NotNull(policyAssignmentSummary);

                Assert.False(string.IsNullOrEmpty(policyAssignmentSummary.PolicyAssignmentId));

                Assert.NotNull(policyAssignmentSummary.Results);
                Assert.False(string.IsNullOrEmpty(policyAssignmentSummary.Results.QueryResultsUri));
                Assert.True(policyAssignmentSummary.Results.NonCompliantResources.HasValue);
                Assert.True(policyAssignmentSummary.Results.NonCompliantPolicies.HasValue);

                Assert.NotNull(policyAssignmentSummary.PolicyDefinitions);
                Assert.True(policyAssignmentSummary.PolicyDefinitions.Count == policyAssignmentSummary.Results.NonCompliantPolicies.Value);

                if (policyAssignmentSummary.Results.NonCompliantPolicies.Value > 1)
                {
                    Assert.False(string.IsNullOrEmpty(policyAssignmentSummary.PolicySetDefinitionId));
                }

                foreach (var policyDefinitionSummary in policyAssignmentSummary.PolicyDefinitions)
                {
                    Assert.NotNull(policyDefinitionSummary);

                    Assert.False(string.IsNullOrEmpty(policyDefinitionSummary.PolicyDefinitionId));
                    Assert.False(string.IsNullOrEmpty(policyDefinitionSummary.Effect));

                    Assert.NotNull(policyDefinitionSummary.Results);
                    Assert.False(string.IsNullOrEmpty(policyDefinitionSummary.Results.QueryResultsUri));
                    Assert.True(policyDefinitionSummary.Results.NonCompliantResources.HasValue);
                    Assert.False(policyDefinitionSummary.Results.NonCompliantPolicies.HasValue);
                }
            }
        }

        #endregion

        #region Policy Events - Scopes

        [Fact]
        public void PolicyEvents_ManagementGroupScope()
        {
            var managementGroupName = "AzGovTest1";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForManagementGroup(managementGroupName);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_SubscriptionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForSubscription(subscriptionId);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_ResourceGroupScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var resourceGroupName = "defaultresourcegroup-eus";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForResourceGroup(subscriptionId, resourceGroupName);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_ResourceScope()
        {
            var resourceId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/defaultresourcegroup-eus/providers/microsoft.operationalinsights/workspaces/defaultworkspace-d0610b27-9663-4c05-89f8-5b4be01e86a5-eus/linkedservices/security";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForResource(resourceId);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_PolicySetDefinitionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policySetDefinitionName = "a03db67e-a286-43c3-9098-b2da83d361ad";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForPolicySetDefinition(subscriptionId, policySetDefinitionName);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_PolicyDefinitionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policyDefinitionName = "24813039-7534-408a-9842-eb99f45721b1";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForPolicyDefinition(subscriptionId, policyDefinitionName);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_SubscriptionLevelPolicyAssignmentScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policyAssignmentName = "e46af646ebdb461dba708e01";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForSubscriptionLevelPolicyAssignment(subscriptionId, policyAssignmentName);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_ResourceGroupLevelPolicyAssignmentScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var resourceGroupName = "cheggpolicy";
            var policyAssignmentName = "9cdb41aa9f304cdeb4a8b090";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForResourceGroupLevelPolicyAssignment(subscriptionId, resourceGroupName, policyAssignmentName);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        #endregion

        #region Policy States Latest - Scopes

        [Fact]
        public void PolicyStates_LatestManagementGroupScope()
        {
            var managementGroupName = "AzGovTest1";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForManagementGroup(PolicyStatesResource.Latest, managementGroupName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestSubscriptionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, subscriptionId);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestResourceGroupScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var resourceGroupName = "defaultresourcegroup-eus";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResourceGroup(PolicyStatesResource.Latest, subscriptionId, resourceGroupName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestResourceScope()
        {
            var resourceId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/defaultresourcegroup-eus/providers/microsoft.operationalinsights/workspaces/defaultworkspace-d0610b27-9663-4c05-89f8-5b4be01e86a5-eus/linkedservices/security";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResource(PolicyStatesResource.Latest, resourceId);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestPolicySetDefinitionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policySetDefinitionName = "a03db67e-a286-43c3-9098-b2da83d361ad";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForPolicySetDefinition(PolicyStatesResource.Latest, subscriptionId, policySetDefinitionName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestPolicyDefinitionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policyDefinitionName = "24813039-7534-408a-9842-eb99f45721b1";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForPolicyDefinition(PolicyStatesResource.Latest, subscriptionId, policyDefinitionName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestSubscriptionLevelPolicyAssignmentScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policyAssignmentName = "e46af646ebdb461dba708e01";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscriptionLevelPolicyAssignment(PolicyStatesResource.Latest, subscriptionId, policyAssignmentName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestResourceGroupLevelPolicyAssignmentScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var resourceGroupName = "cheggpolicy";
            var policyAssignmentName = "b413d679fbe64e90862c204f";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResourceGroupLevelPolicyAssignment(PolicyStatesResource.Latest, subscriptionId, resourceGroupName, policyAssignmentName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        #endregion

        #region Policy States Default - Scopes

        [Fact]
        public void PolicyStates_DefaultManagementGroupScope()
        {
            var managementGroupName = "AzGovTest1";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForManagementGroup(PolicyStatesResource.Default, managementGroupName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultSubscriptionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Default, subscriptionId);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultResourceGroupScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var resourceGroupName = "defaultresourcegroup-eus";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResourceGroup(PolicyStatesResource.Default, subscriptionId, resourceGroupName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultResourceScope()
        {
            var resourceId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/defaultresourcegroup-eus/providers/microsoft.operationalinsights/workspaces/defaultworkspace-d0610b27-9663-4c05-89f8-5b4be01e86a5-eus/linkedservices/security";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResource(PolicyStatesResource.Default, resourceId);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultPolicySetDefinitionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policySetDefinitionName = "a03db67e-a286-43c3-9098-b2da83d361ad";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForPolicySetDefinition(PolicyStatesResource.Default, subscriptionId, policySetDefinitionName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultPolicyDefinitionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policyDefinitionName = "24813039-7534-408a-9842-eb99f45721b1";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForPolicyDefinition(PolicyStatesResource.Default, subscriptionId, policyDefinitionName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultSubscriptionLevelPolicyAssignmentScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policyAssignmentName = "e46af646ebdb461dba708e01";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscriptionLevelPolicyAssignment(PolicyStatesResource.Default, subscriptionId, policyAssignmentName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultResourceGroupLevelPolicyAssignmentScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var resourceGroupName = "cheggpolicy";
            var policyAssignmentName = "0b6f73d144a441099992d432";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResourceGroupLevelPolicyAssignment(PolicyStatesResource.Default, subscriptionId, resourceGroupName, policyAssignmentName);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        #endregion

        #region Policy States Latest - Summarize

        [Fact]
        public void PolicyStates_SummarizeManagementGroupScope()
        {
            var managementGroupName = "AzGovTest1";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForManagementGroup(managementGroupName);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizeSubscriptionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForSubscription(subscriptionId);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizeResourceGroupScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var resourceGroupName = "defaultresourcegroup-eus";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForResourceGroup(subscriptionId, resourceGroupName);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizeResourceScope()
        {
            var resourceId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/defaultresourcegroup-eus/providers/microsoft.operationalinsights/workspaces/defaultworkspace-d0610b27-9663-4c05-89f8-5b4be01e86a5-eus/linkedservices/security";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForResource(resourceId);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizePolicySetDefinitionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policySetDefinitionName = "a03db67e-a286-43c3-9098-b2da83d361ad";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForPolicySetDefinition(subscriptionId, policySetDefinitionName);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizePolicyDefinitionScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policyDefinitionName = "24813039-7534-408a-9842-eb99f45721b1";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForPolicyDefinition(subscriptionId, policyDefinitionName);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizeSubscriptionLevelPolicyAssignmentScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var policyAssignmentName = "e46af646ebdb461dba708e01";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForSubscriptionLevelPolicyAssignment(subscriptionId, policyAssignmentName);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizeResourceGroupLevelPolicyAssignmentScope()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            var resourceGroupName = "cheggpolicy";
            var policyAssignmentName = "0b6f73d144a441099992d432";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForResourceGroupLevelPolicyAssignment(subscriptionId, resourceGroupName, policyAssignmentName);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        #endregion

        #region Query options

        [Fact]
        public void QueryOptions_QueryResultsWithFrom()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { FromProperty = DateTime.Parse("2018-03-01 15:14:13Z") };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, subscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithTo()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { To = DateTime.Parse("2018-03-01 15:14:13Z") };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, subscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithTop()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { Top = 10 };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, subscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
                Assert.True(10 == queryResults.Odatacount.Value);
                Assert.True(10 == queryResults.Value.Count);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithOrderBy()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { OrderBy = "PolicyAssignmentId desc" };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, subscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithSelect()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { Select = "Timestamp, ResourceId, PolicyAssignmentId, PolicyDefinitionId, IsCompliant, SubscriptionId, PolicyDefinitionAction" };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, subscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithFilter()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { Filter = "IsCompliant eq false and PolicyDefinitionAction eq 'deny'" };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, subscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithApply()
        {
            var subscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { Apply = "groupby((PolicyAssignmentId, PolicyDefinitionId, ResourceId))/groupby((PolicyAssignmentId, PolicyDefinitionId), aggregate($count as NumResources))" };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, subscriptionId, queryOptions);

                Assert.NotNull(queryResults);

                Assert.False(string.IsNullOrEmpty(queryResults.Odatacontext));
                Assert.True(queryResults.Odatacount.HasValue);
                Assert.True(queryResults.Odatacount.Value > 0);

                Assert.NotNull(queryResults.Value);
                Assert.NotEmpty(queryResults.Value);

                foreach (var policyState in queryResults.Value)
                {
                    Assert.NotNull(policyState);

                    Assert.Null(policyState.Odataid);
                    Assert.False(string.IsNullOrEmpty(policyState.Odatacontext));

                    Assert.False(string.IsNullOrEmpty(policyState.PolicyAssignmentId));
                    Assert.False(string.IsNullOrEmpty(policyState.PolicyDefinitionId));

                    Assert.NotNull(policyState.AdditionalProperties);
                    Assert.True(policyState.AdditionalProperties.ContainsKey("NumResources"));
                    Assert.NotNull(policyState.AdditionalProperties["NumResources"] as long?);
                }
            }
        }

        #endregion
    }
}
