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

        private static string ManagementGroupName = "azgovtest4";
        private static string SubscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
        private static string ResourceGroupName = "bulenttestrg";
        private static string ResourceId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/govintpolicyrp/providers/microsoft.network/trafficmanagerprofiles/gov-int-policy-rp";
        private static string PolicySetDefinitionName = "db6c5074-a529-4cc8-8882-43f10ef42002";
        private static string PolicyDefinitionName = "d7b13c30-e6aa-47e1-b50a-8e33f152d086";
        private static string PolicyAssignmentName = "45ab2ab7898d45ebb3087573";
        private static QueryOptions DefaultQueryOptions = new QueryOptions { FromProperty = DateTime.Parse("2018-04-04 00:00:00Z"), Top = 10 };

        public static TestEnvironment TestEnvironment { get; private set; }

        private static PolicyInsightsClient GetPolicyInsightsClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

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
            Assert.True(queryResults.Odatacount.Value >= 0);

            Assert.NotNull(queryResults.Value);

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
            Assert.True(queryResults.Odatacount.Value >= 0);

            Assert.NotNull(queryResults.Value);

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
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForManagementGroup(ManagementGroupName, DefaultQueryOptions);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_SubscriptionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForSubscription(SubscriptionId, DefaultQueryOptions);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_ResourceGroupScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForResourceGroup(SubscriptionId, ResourceGroupName, DefaultQueryOptions);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_ResourceScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForResource(ResourceId, DefaultQueryOptions);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_PolicySetDefinitionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForPolicySetDefinition(SubscriptionId, PolicySetDefinitionName, DefaultQueryOptions);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_PolicyDefinitionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForPolicyDefinition(SubscriptionId, PolicyDefinitionName, DefaultQueryOptions);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_SubscriptionLevelPolicyAssignmentScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForSubscriptionLevelPolicyAssignment(SubscriptionId, PolicyAssignmentName, DefaultQueryOptions);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyEvents_ResourceGroupLevelPolicyAssignmentScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForResourceGroupLevelPolicyAssignment(SubscriptionId, ResourceGroupName, PolicyAssignmentName, DefaultQueryOptions);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        #endregion

        #region Policy States Latest - Scopes

        [Fact]
        public void PolicyStates_LatestManagementGroupScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForManagementGroup(PolicyStatesResource.Latest, ManagementGroupName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestSubscriptionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, SubscriptionId, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestResourceGroupScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResourceGroup(PolicyStatesResource.Latest, SubscriptionId, ResourceGroupName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestResourceScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResource(PolicyStatesResource.Latest, ResourceId, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestPolicySetDefinitionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForPolicySetDefinition(PolicyStatesResource.Latest, SubscriptionId, PolicySetDefinitionName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestPolicyDefinitionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForPolicyDefinition(PolicyStatesResource.Latest, SubscriptionId, PolicyDefinitionName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestSubscriptionLevelPolicyAssignmentScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscriptionLevelPolicyAssignment(PolicyStatesResource.Latest, SubscriptionId, PolicyAssignmentName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_LatestResourceGroupLevelPolicyAssignmentScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResourceGroupLevelPolicyAssignment(PolicyStatesResource.Latest, SubscriptionId, ResourceGroupName, PolicyAssignmentName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        #endregion

        #region Policy States Default - Scopes

        [Fact]
        public void PolicyStates_DefaultManagementGroupScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForManagementGroup(PolicyStatesResource.Default, ManagementGroupName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultSubscriptionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Default, SubscriptionId, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultResourceGroupScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResourceGroup(PolicyStatesResource.Default, SubscriptionId, ResourceGroupName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultResourceScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResource(PolicyStatesResource.Default, ResourceId, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultPolicySetDefinitionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForPolicySetDefinition(PolicyStatesResource.Default, SubscriptionId, PolicySetDefinitionName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultPolicyDefinitionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForPolicyDefinition(PolicyStatesResource.Default, SubscriptionId, PolicyDefinitionName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultSubscriptionLevelPolicyAssignmentScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscriptionLevelPolicyAssignment(PolicyStatesResource.Default, SubscriptionId, PolicyAssignmentName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void PolicyStates_DefaultResourceGroupLevelPolicyAssignmentScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForResourceGroupLevelPolicyAssignment(PolicyStatesResource.Default, SubscriptionId, ResourceGroupName, PolicyAssignmentName, DefaultQueryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        #endregion

        #region Policy States Latest - Summarize

        [Fact]
        public void PolicyStates_SummarizeManagementGroupScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForManagementGroup(ManagementGroupName, DefaultQueryOptions);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizeSubscriptionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForSubscription(SubscriptionId, DefaultQueryOptions);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizeResourceGroupScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForResourceGroup(SubscriptionId, ResourceGroupName, DefaultQueryOptions);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizeResourceScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForResource(ResourceId, DefaultQueryOptions);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizePolicySetDefinitionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForPolicySetDefinition(SubscriptionId, PolicySetDefinitionName, DefaultQueryOptions);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizePolicyDefinitionScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForPolicyDefinition(SubscriptionId, PolicyDefinitionName, DefaultQueryOptions);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizeSubscriptionLevelPolicyAssignmentScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForSubscriptionLevelPolicyAssignment(SubscriptionId, PolicyAssignmentName, DefaultQueryOptions);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        [Fact]
        public void PolicyStates_SummarizeResourceGroupLevelPolicyAssignmentScope()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var summarizeResults = policyInsightsClient.PolicyStates.SummarizeForResourceGroupLevelPolicyAssignment(SubscriptionId, ResourceGroupName, PolicyAssignmentName, DefaultQueryOptions);
                ValidateSummarizeResults(summarizeResults);
            }
        }

        #endregion

        #region Query options

        [Fact]
        public void QueryOptions_QueryResultsWithFrom()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { FromProperty = DefaultQueryOptions.FromProperty };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, SubscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithTo()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { To = DefaultQueryOptions.To };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, SubscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithTop()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { Top = 10 };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, SubscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
                Assert.True(10 == queryResults.Odatacount.Value);
                Assert.True(10 == queryResults.Value.Count);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithOrderBy()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { OrderBy = "PolicyAssignmentId desc" };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, SubscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithSelect()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { Select = "Timestamp, ResourceId, PolicyAssignmentId, PolicyDefinitionId, IsCompliant, SubscriptionId, PolicyDefinitionAction" };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, SubscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithFilter()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { Filter = "IsCompliant eq false and PolicyDefinitionAction eq 'deny'" };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, SubscriptionId, queryOptions);
                ValidatePolicyStatesQueryResults(queryResults);
            }
        }

        [Fact]
        public void QueryOptions_QueryResultsWithApply()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = GetPolicyInsightsClient(context);
                var queryOptions = new QueryOptions { Apply = "groupby((PolicyAssignmentId, PolicyDefinitionId, ResourceId))/groupby((PolicyAssignmentId, PolicyDefinitionId), aggregate($count as NumResources))" };
                var queryResults = policyInsightsClient.PolicyStates.ListQueryResultsForSubscription(PolicyStatesResource.Latest, SubscriptionId, queryOptions);

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
