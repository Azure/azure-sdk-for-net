// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.PolicyInsights;
using Microsoft.Azure.Management.PolicyInsights.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace PolicyInsights.Tests
{
    public class RemediationsTests : TestBase
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

        #endregion

        #region Management Group Scope

        [Fact]
        public void Remediations_ManagementGroupCrud()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();
                var queryResults = policyInsightsClient.PolicyEvents.ListQueryResultsForManagementGroup(ManagementGroupName, DefaultQueryOptions);
                ValidatePolicyEventsQueryResults(queryResults);
            }
        }

        #endregion
    }
}
