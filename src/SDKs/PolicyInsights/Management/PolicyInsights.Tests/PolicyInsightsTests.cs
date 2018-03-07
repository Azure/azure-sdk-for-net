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
        private static readonly HttpRecorderMode Mode = HttpRecorderMode.Playback;

        static PolicyInsightsTests()
        {
            if (HttpRecorderMode.Record == Mode)
            {
                Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=d0610b27-9663-4c05-89f8-5b4be01e86a5;Environment=Prod;HttpRecorderMode=Record;");
                Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
            }
            else
            {
                Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=d0610b27-9663-4c05-89f8-5b4be01e86a5;Environment=Prod;HttpRecorderMode=Playback;");
                Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            }

            TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
        }

        public static TestEnvironment TestEnvironment { get; }

        private void ValidatePolicyEventsQueryResults(PolicyEventsQueryResults queryResults)
        {
            Assert.NotNull(queryResults);
            Assert.NotNull(queryResults.Odatacontext);
            Assert.True(queryResults.Odatacount.HasValue);
            Assert.True(queryResults.Odatacount.Value > 0);
            Assert.NotNull(queryResults.Value);
            Assert.NotEmpty(queryResults.Value);
        }

        private PolicyInsightsClient GetPolicyInsightsClient(MockContext context)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.RecordsDirectory = @"C:\Git\bulentelmaci\azure-sdk-for-net\src\SDKs\PolicyInsights\Management\PolicyInsights.Tests\SessionRecords";
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };
            var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>(TestEnvironment, handlers: handler);
            return policyInsightsClient;
        }

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
    }
}
