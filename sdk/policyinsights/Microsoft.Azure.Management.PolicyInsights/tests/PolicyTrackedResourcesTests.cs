// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace PolicyInsights.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.PolicyInsights;
    using Microsoft.Azure.Management.PolicyInsights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class PolicyTrackedResourcesTests
    {
        #region Test setup

        private static string ManagementGroupName = "ArtTest1";
        private static string SubscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
        private static string ResourceGroupName = "elpere-sdk-tests";

        private static string PolicyAssignmentId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourceGroups/elpere-sdk-tests/providers/Microsoft.Authorization/policyAssignments/18c66454099644de94931534";
        private static string PolicySetDefinitionId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/providers/Microsoft.Authorization/policySetDefinitions/71289c53-22e7-4f31-a6dd-780b532380c6";
        private static string PolicyDefinitionId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/providers/Microsoft.Authorization/policyDefinitions/71289c53-22e7-4f31-a6dd-780b532380c2";
        private static string PolicyDefinitionReferenceId = "6346022531429970426";

        private static string DeployedNsgRuleId1 = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/elpere-sdk-tests/providers/microsoft.network/networksecuritygroups/policytrackedresources-sdk-tests/securityrules/policytrackedresources-sdk-tests-rule1";
        private static string DeployedNsgRuleId2 = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/elpere-sdk-tests/providers/microsoft.network/networksecuritygroups/policytrackedresources-sdk-tests/securityrules/policytrackedresources-sdk-tests-rule2";

        private static string CreatedByDeploymentId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourceGroups/elpere-sdk-tests/providers/Microsoft.Resources/deployments/90e5d900-381d-4224-987c-8ff6978a8955";
        private static string LastModifiedByDeploymentId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourceGroups/elpere-sdk-tests/providers/Microsoft.Resources/deployments/d903a662-8372-4fe0-8a18-467b0b6354b8";

        #endregion

        #region Validation

        private void Validate(PolicyTrackedResource[] responseObjects, string[] expectedTrackedResourceIds)
        {
            foreach (var expectedTrackedResourceId in expectedTrackedResourceIds)
            {
                var trackedResource = responseObjects.Single(responseObject => responseObject.TrackedResourceId.Equals(expectedTrackedResourceId, StringComparison.InvariantCultureIgnoreCase));

                Assert.NotNull(trackedResource.PolicyDetails);
                Assert.Equal(trackedResource.PolicyDetails.PolicyAssignmentId, PolicyAssignmentId, StringComparer.InvariantCultureIgnoreCase);
                Assert.Equal(trackedResource.PolicyDetails.PolicyDefinitionId, PolicyDefinitionId, StringComparer.InvariantCultureIgnoreCase);
                Assert.Equal(trackedResource.PolicyDetails.PolicySetDefinitionId, PolicySetDefinitionId, StringComparer.InvariantCultureIgnoreCase);
                Assert.Equal(trackedResource.PolicyDetails.PolicyDefinitionReferenceId, PolicyDefinitionReferenceId, StringComparer.InvariantCultureIgnoreCase);

                Assert.NotNull(trackedResource.CreatedBy);
                Assert.NotNull(trackedResource.CreatedBy.PolicyDetails);
                Assert.Equal(trackedResource.CreatedBy.PolicyDetails.PolicyAssignmentId, PolicyAssignmentId, StringComparer.InvariantCultureIgnoreCase);
                Assert.Equal(trackedResource.CreatedBy.PolicyDetails.PolicyDefinitionId, PolicyDefinitionId, StringComparer.InvariantCultureIgnoreCase);
                Assert.Equal(trackedResource.CreatedBy.PolicyDetails.PolicySetDefinitionId, PolicySetDefinitionId, StringComparer.InvariantCultureIgnoreCase);
                Assert.Equal(trackedResource.CreatedBy.PolicyDetails.PolicyDefinitionReferenceId, PolicyDefinitionReferenceId, StringComparer.InvariantCultureIgnoreCase);
                Assert.Equal(trackedResource.CreatedBy.DeploymentId, CreatedByDeploymentId, StringComparer.InvariantCultureIgnoreCase);

                Assert.NotNull(trackedResource.LastModifiedBy);
                Assert.NotNull(trackedResource.LastModifiedBy.PolicyDetails);
                Assert.Equal(trackedResource.LastModifiedBy.PolicyDetails.PolicyAssignmentId, PolicyAssignmentId, StringComparer.InvariantCultureIgnoreCase);
                Assert.Equal(trackedResource.LastModifiedBy.PolicyDetails.PolicyDefinitionId, PolicyDefinitionId, StringComparer.InvariantCultureIgnoreCase);
                Assert.Equal(trackedResource.LastModifiedBy.PolicyDetails.PolicySetDefinitionId, PolicySetDefinitionId, StringComparer.InvariantCultureIgnoreCase);
                Assert.Equal(trackedResource.LastModifiedBy.PolicyDetails.PolicyDefinitionReferenceId, PolicyDefinitionReferenceId, StringComparer.InvariantCultureIgnoreCase);
                Assert.Equal(trackedResource.LastModifiedBy.DeploymentId, LastModifiedByDeploymentId, StringComparer.InvariantCultureIgnoreCase);
            }
        }

        #endregion

        #region MG Scope

        [Fact]
        public void PolicyTrackedResources_ManagementGroupScopeQueries()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();

                // Map between different query options to the expected tracked resources in the response.
                // In case more than 1 result is expected, the test will also try to use 'top' and check that paging is working properly.
                var queryOptionsToExpectedResults = new Dictionary<QueryOptions, string[]>
                {
                    // No filter
                    { new QueryOptions(), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },

                    // Single filter
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}'"), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },
                    { new QueryOptions(filter: $"policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },
                    { new QueryOptions(filter: $"trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },

                    // 2 filters
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },
                    { new QueryOptions(filter: $"trackedResourceId eq '{DeployedNsgRuleId1}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1 } },

                    // 3 filters
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}' and trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },
                };

                foreach (var queryOptionsToExpectedResult in queryOptionsToExpectedResults)
                {
                    var queryOptions = queryOptionsToExpectedResult.Key ?? new QueryOptions();
                    var expectedTrackedResources = queryOptionsToExpectedResult.Value;

                    // Get tracked resources using the query
                    var response = policyInsightsClient.PolicyTrackedResources.ListQueryResultsForManagementGroupWithHttpMessagesAsync(managementGroupName: ManagementGroupName, queryOptions: queryOptions).Result;
                    this.Validate(
                        responseObjects: response.Body.Where(trackedResource => expectedTrackedResources.Contains(trackedResource.TrackedResourceId, StringComparer.InvariantCultureIgnoreCase)).ToArray(),
                        expectedTrackedResourceIds: expectedTrackedResources);

                    // Test paging if possible
                    if (expectedTrackedResources.Length > 1)
                    {
                        var responseObjects = new List<PolicyTrackedResource>();

                        queryOptions.Top = 1;
                        var trackedResourcesPage = policyInsightsClient.PolicyTrackedResources.ListQueryResultsForManagementGroupWithHttpMessagesAsync(managementGroupName: ManagementGroupName, queryOptions: queryOptions).Result;
                        responseObjects.AddRange(trackedResourcesPage.Body);

                        var nextLink = trackedResourcesPage.Body.NextPageLink;
                        do
                        {
                            trackedResourcesPage = policyInsightsClient.PolicyTrackedResources.ListQueryResultsForManagementGroupNextWithHttpMessagesAsync(nextPageLink: nextLink).Result;
                            responseObjects.AddRange(trackedResourcesPage.Body);
                            nextLink = trackedResourcesPage.Body.NextPageLink;
                        } while (nextLink != null);

                        this.Validate(
                            responseObjects: responseObjects.Where(trackedResource => expectedTrackedResources.Contains(trackedResource.TrackedResourceId, StringComparer.InvariantCultureIgnoreCase)).ToArray(),
                            expectedTrackedResourceIds: expectedTrackedResources);
                    }
                }
            }
        }

        #endregion

        #region Subscription Scope

        [Fact]
        public void PolicyTrackedResources_SubscriptionScopeQueries()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();

                // Map between different query options to the expected tracked resources in the response.
                // In case more than 1 result is expected, the test will also try to use 'top' and check that paging is working properly.
                var queryOptionsToExpectedResults = new Dictionary<QueryOptions, string[]>
                {
                    // No filter
                    { new QueryOptions(), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },

                    // Single filter
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}'"), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },
                    { new QueryOptions(filter: $"policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },
                    { new QueryOptions(filter: $"trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },

                    // 2 filters
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },
                    { new QueryOptions(filter: $"trackedResourceId eq '{DeployedNsgRuleId1}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1 } },

                    // 3 filters
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}' and trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },
                };

                foreach (var queryOptionsToExpectedResult in queryOptionsToExpectedResults)
                {
                    var queryOptions = queryOptionsToExpectedResult.Key ?? new QueryOptions();
                    var expectedTrackedResources = queryOptionsToExpectedResult.Value;

                    // Get tracked resources using the query
                    var response = policyInsightsClient.PolicyTrackedResources.ListQueryResultsForSubscriptionWithHttpMessagesAsync(subscriptionId: SubscriptionId, queryOptions: queryOptions).Result;
                    this.Validate(
                        responseObjects: response.Body.Where(trackedResource => expectedTrackedResources.Contains(trackedResource.TrackedResourceId, StringComparer.InvariantCultureIgnoreCase)).ToArray(),
                        expectedTrackedResourceIds: expectedTrackedResources);

                    // Test paging if possible
                    if (expectedTrackedResources.Length > 1)
                    {
                        var responseObjects = new List<PolicyTrackedResource>();

                        queryOptions.Top = 1;
                        var trackedResourcesPage = policyInsightsClient.PolicyTrackedResources.ListQueryResultsForSubscriptionWithHttpMessagesAsync(subscriptionId: SubscriptionId, queryOptions: queryOptions).Result;
                        responseObjects.AddRange(trackedResourcesPage.Body);

                        var nextLink = trackedResourcesPage.Body.NextPageLink;
                        do
                        {
                            trackedResourcesPage = policyInsightsClient.PolicyTrackedResources.ListQueryResultsForSubscriptionNextWithHttpMessagesAsync(nextPageLink: nextLink).Result;
                            responseObjects.AddRange(trackedResourcesPage.Body);
                            nextLink = trackedResourcesPage.Body.NextPageLink;
                        } while (nextLink != null);

                        this.Validate(
                            responseObjects: responseObjects.Where(trackedResource => expectedTrackedResources.Contains(trackedResource.TrackedResourceId, StringComparer.InvariantCultureIgnoreCase)).ToArray(),
                            expectedTrackedResourceIds: expectedTrackedResources);
                    }
                }
            }
        }

        #endregion

        #region Resource group Scope

        [Fact]
        public void PolicyTrackedResources_RsourceGroupScopeQueries()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();

                // Map between different query options to the expected tracked resources in the response.
                // In case more than 1 result is expected, the test will also try to use 'top' and check that paging is working properly.
                var queryOptionsToExpectedResults = new Dictionary<QueryOptions, string[]>
                {
                    // No filter
                    { new QueryOptions(), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },

                    // Single filter
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}'"), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },
                    { new QueryOptions(filter: $"policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },
                    { new QueryOptions(filter: $"trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },

                    // 2 filters
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1, DeployedNsgRuleId2 } },
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },
                    { new QueryOptions(filter: $"trackedResourceId eq '{DeployedNsgRuleId1}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1 } },

                    // 3 filters
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}' and trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },
                };

                foreach (var queryOptionsToExpectedResult in queryOptionsToExpectedResults)
                {
                    var queryOptions = queryOptionsToExpectedResult.Key ?? new QueryOptions();
                    var expectedTrackedResources = queryOptionsToExpectedResult.Value;

                    // Get tracked resources using the query
                    var response = policyInsightsClient.PolicyTrackedResources.ListQueryResultsForResourceGroupWithHttpMessagesAsync(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, queryOptions: queryOptions).Result;
                    this.Validate(
                        responseObjects: response.Body.Where(trackedResource => expectedTrackedResources.Contains(trackedResource.TrackedResourceId, StringComparer.InvariantCultureIgnoreCase)).ToArray(),
                        expectedTrackedResourceIds: expectedTrackedResources);

                    // Test paging if possible
                    if (expectedTrackedResources.Length > 1)
                    {
                        var responseObjects = new List<PolicyTrackedResource>();

                        queryOptions.Top = 1;
                        var trackedResourcesPage = policyInsightsClient.PolicyTrackedResources.ListQueryResultsForResourceGroupWithHttpMessagesAsync(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, queryOptions: queryOptions).Result;
                        responseObjects.AddRange(trackedResourcesPage.Body);

                        var nextLink = trackedResourcesPage.Body.NextPageLink;
                        do
                        {
                            trackedResourcesPage = policyInsightsClient.PolicyTrackedResources.ListQueryResultsForResourceGroupNextWithHttpMessagesAsync(nextPageLink: nextLink).Result;
                            responseObjects.AddRange(trackedResourcesPage.Body);
                            nextLink = trackedResourcesPage.Body.NextPageLink;
                        } while (nextLink != null);

                        this.Validate(
                            responseObjects: responseObjects.Where(trackedResource => expectedTrackedResources.Contains(trackedResource.TrackedResourceId, StringComparer.InvariantCultureIgnoreCase)).ToArray(),
                            expectedTrackedResourceIds: expectedTrackedResources);
                    }
                }
            }
        }

        #endregion

        #region Resource Scope

        [Fact]
        public void PolicyTrackedResources_RsourceScopeQueries()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();

                // Map between different query options to the expected tracked resources in the response.
                // In case more than 1 result is expected, the test will also try to use 'top' and check that paging is working properly.
                var queryOptionsToExpectedResults = new Dictionary<QueryOptions, string[]>
                {
                    // No filter
                    { new QueryOptions(), new[] { DeployedNsgRuleId1 } },

                    // Single filter
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}'"), new[] { DeployedNsgRuleId1 } },
                    { new QueryOptions(filter: $"policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1 } },
                    { new QueryOptions(filter: $"trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },

                    // 2 filters
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1 } },
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },
                    { new QueryOptions(filter: $"trackedResourceId eq '{DeployedNsgRuleId1}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}'"), new[] { DeployedNsgRuleId1 } },

                    // 3 filters
                    { new QueryOptions(filter: $"policyAssignmentId eq '{PolicyAssignmentId}' and policyDefinitionReferenceId eq '{PolicyDefinitionReferenceId}' and trackedResourceId eq '{DeployedNsgRuleId1}'"), new[] { DeployedNsgRuleId1 } },
                };

                foreach (var queryOptionsToExpectedResult in queryOptionsToExpectedResults)
                {
                    var queryOptions = queryOptionsToExpectedResult.Key ?? new QueryOptions();
                    var expectedTrackedResources = queryOptionsToExpectedResult.Value;

                    // Get tracked resources using the query
                    var response = policyInsightsClient.PolicyTrackedResources.ListQueryResultsForResourceWithHttpMessagesAsync(resourceId: DeployedNsgRuleId1, queryOptions: queryOptions).Result;
                    this.Validate(
                        responseObjects: response.Body.Where(trackedResource => expectedTrackedResources.Contains(trackedResource.TrackedResourceId, StringComparer.InvariantCultureIgnoreCase)).ToArray(),
                        expectedTrackedResourceIds: expectedTrackedResources);
                }
            }
        }

        #endregion
    }
}
