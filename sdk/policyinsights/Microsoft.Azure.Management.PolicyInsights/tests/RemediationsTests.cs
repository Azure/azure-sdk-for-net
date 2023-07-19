// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using Microsoft.Azure.Management.PolicyInsights;
using Microsoft.Azure.Management.PolicyInsights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using PolicyInsights.Tests.Helpers;
using Xunit;

namespace PolicyInsights.Tests
{
    /// <summary>
    /// Remediations API tests.
    /// Recorded with SubscriptionId=086aecf4-23d6-4dfd-99a8-a5c6299f0322;ServicePrincipal=aa1a7d99-cf7d-4af9-8a92-e466ddeee946;ServicePrincipalSecret=**;AADTenant=72f988bf-86f1-41af-91ab-2d7cd011db47;Environment=Prod;HttpRecorderMode=Record;SubscriptionId=086aecf4-23d6-4dfd-99a8-a5c6299f0322;ServicePrincipal=aa1a7d99-cf7d-4af9-8a92-e466ddeee946;ServicePrincipalSecret=XXXTenant=72f988bf-86f1-41af-91ab-2d7cd011db47;Environment=Prod;HttpRecorderMode=Record;
    /// The above service principal maps to "cheggSDKTests" in the Microsoft AAD tenant.
    /// </summary>
    public class RemediationsTests : TestBase
    {
        #region Test setup
        
        private static string ManagementGroupName = "AzGovPerfTest";
        private static string ManagementGroupPolicyAssignmentId = "/providers/Microsoft.Management/managementGroups/AzGovPerfTest/providers/Microsoft.Authorization/policyAssignments/19ec14e57445484fb8555646";
        private static string SubscriptionId = "086aecf4-23d6-4dfd-99a8-a5c6299f0322";
        private static string ResourceGroupName = "elad";
        private static string IndividualResourceId = "/subscriptions/086aecf4-23d6-4dfd-99a8-a5c6299f0322/resourcegroups/elad/providers/microsoft.keyvault/vaults/sdktest1";
        private static string PolicyAssignmentId = "/subscriptions/086aecf4-23d6-4dfd-99a8-a5c6299f0322/providers/Microsoft.Authorization/policyAssignments/c81f1bacddc8467191243da3";
        private static string RemediationName = "sdkTests";

        #endregion

        #region Validation

        /// <summary>
        /// Validates a remediation matches what is expected.
        /// </summary>
        /// <param name="expected">The expected remediation</param>
        /// <param name="actual">The actual remediation</param>
        /// <param name="remediationName">The expected remediation name</param>
        private void ValidateRemediation(Remediation expected, Remediation actual, string remediationName)
        {
            Assert.NotNull(actual);

            Assert.Equal(expected.PolicyAssignmentId, actual.PolicyAssignmentId, StringComparer.OrdinalIgnoreCase);
            Assert.Equal(expected.PolicyDefinitionReferenceId, actual.PolicyDefinitionReferenceId, StringComparer.OrdinalIgnoreCase);
            Assert.Equal(remediationName, actual.Name, StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(actual.Id);
            Assert.Equal("Microsoft.PolicyInsights/remediations", actual.Type, StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(actual.CreatedOn);
            Assert.NotNull(actual.LastUpdatedOn);
            Assert.NotNull(actual.SystemData);
            Assert.NotNull(actual.SystemData.CreatedBy);
            Assert.NotNull(actual.SystemData.CreatedAt);
            Assert.NotNull(actual.CorrelationId);
            Assert.Equal(expected.ResourceCount, actual.ResourceCount);
            Assert.Equal(expected.ParallelDeployments, actual.ParallelDeployments);

            if (expected.FailureThreshold?.Percentage != null)
            {
                Assert.Equal(expected.FailureThreshold.Percentage, actual.FailureThreshold?.Percentage);
            }
            else
            {
                Assert.Null(actual.FailureThreshold?.Percentage);
            }

            Assert.Equal(expected.Filters?.Locations?.Count, actual.Filters?.Locations?.Count);
            foreach (var location in expected.Filters?.Locations ?? Enumerable.Empty<string>())
            {
                Assert.Contains(location, actual.Filters.Locations, StringComparer.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// Validates a remediation deployment contains the appropriate properties.
        /// </summary>
        /// <param name="deployment">The remediation deployment</param>
        private void ValidateDeployment(RemediationDeployment deployment)
        {
            Assert.NotNull(deployment.CreatedOn);
            Assert.NotNull(deployment.LastUpdatedOn);
            Assert.Null(deployment.Error);
            Assert.Equal(ProvisioningState.Succeeded, deployment.Status);
            Assert.Contains("/deployments/", deployment.DeploymentId, StringComparison.OrdinalIgnoreCase);
            Assert.NotNull(deployment.RemediatedResourceId);
            Assert.NotNull(deployment.ResourceLocation);
        }

        /// <summary>
        /// Waits for a remediation to complete
        /// </summary>
        /// <param name="getRemediationFunc">The hook to retrieve the updated remediation.</param>
        /// <returns>The completed remediation.</returns>
        private Remediation WaitForCompletion(Func<Remediation> getRemediationFunc)
        {
            for (var i = 0; i < 120; i++)
            {
                var updatedRemediation = getRemediationFunc();
                if (ProvisioningState.IsTerminal(updatedRemediation.ProvisioningState))
                {
                    return updatedRemediation;
                }

                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Thread.Sleep(10000);
                }
            }

            throw new InvalidOperationException("The remediation did not complete in the allotted time.");
        }

        #endregion

        #region Subscription Scope

        /// <summary>
        /// Test remediation task operations at subscription level.
        /// </summary>
        [Fact]
        public void Remediations_SubscriptionCrud()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();

                // Create a single policy remediation
                var remediationName = "b49b6437-706d-4208-8508-65d87a9b2e37";
                var remediationParams = new Remediation
                {
                    PolicyAssignmentId = PolicyAssignmentId,
                    Filters = new RemediationFilters(new[] { "eastus" }),
                    ParallelDeployments = 1,
                    ResourceCount = 1,
                    FailureThreshold = new RemediationPropertiesFailureThreshold { Percentage = 0.42 }
                };

                var createdRemediation = policyInsightsClient.Remediations.CreateOrUpdateAtSubscription(subscriptionId: SubscriptionId, remediationName: remediationName, parameters: remediationParams);
                Assert.Equal(ProvisioningState.Accepted, createdRemediation.ProvisioningState);
                Assert.Equal(0, createdRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(0, createdRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, createdRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: createdRemediation, remediationName: remediationName);

                var completedRemediation = this.WaitForCompletion(() => policyInsightsClient.Remediations.GetAtSubscription(subscriptionId: SubscriptionId, remediationName: remediationName));
                Assert.Equal(ProvisioningState.Succeeded, completedRemediation.ProvisioningState);
                Assert.Equal(1, completedRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(1, completedRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, completedRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: completedRemediation, remediationName: remediationName);

                // List deployments for the remediation
                var deployments = policyInsightsClient.Remediations.ListDeploymentsAtSubscription(subscriptionId: SubscriptionId, remediationName: remediationName);
                Assert.Single(deployments);
                var deployment = deployments.First();
                this.ValidateDeployment(deployment);
                Assert.Contains("/subscriptions/" + SubscriptionId, deployment.DeploymentId, StringComparison.OrdinalIgnoreCase);
                Assert.Equal("eastus", deployment.ResourceLocation);
                Assert.Contains("Microsoft.KeyVault/vaults", deployment.RemediatedResourceId, StringComparison.OrdinalIgnoreCase);

                // Cancel the completed remediation, should fail
                try
                {
                    policyInsightsClient.Remediations.CancelAtSubscription(subscriptionId: SubscriptionId, remediationName: remediationName);
                    Assert.True(false, "Cancelling a completed remediation should have thrown an error");
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal("InvalidCancelRemediationRequest", ex.Body.Error.Code);
                    Assert.Contains("A completed remediation cannot be cancelled", ex.Body.Error.Message, StringComparison.OrdinalIgnoreCase);
                }


                // Delete the remediation
                var deletedRemediation = policyInsightsClient.Remediations.DeleteAtSubscription(subscriptionId: SubscriptionId, remediationName: remediationName);
                Assert.Equal(ProvisioningState.Succeeded, completedRemediation.ProvisioningState);
                Assert.Equal(1, deletedRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(1, deletedRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, deletedRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: deletedRemediation, remediationName: remediationName);
            }
        }

        /// <summary>
        /// Test remediation and remediation deployments list pagination.
        /// </summary>
        [Fact]
        public void Remediations_PaginatedListing()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();

                // List remediations in the subscription.
                // At the time this test was written, remediations are returned in pages of 100.
                // Since the subscription scope has 174 remediations, expect 2 pages. The last page should have an empty next link.
                // To quickly create many remediations (with 0 remediated resources each), you can run the following cmdlt:
                // 1..20 | foreach { Get-AzResourceGroup | select -ExpandProperty ResourceId | foreach {Start-AzPolicyRemediation -Name "$(Get-Random)" -Scope $_ -PolicyAssignmentId <assignment> -LocationFilter <location with no non-compliant resources> }}
                var remediationPage = policyInsightsClient.Remediations.ListForSubscription(subscriptionId: SubscriptionId);
                Assert.Equal(100, remediationPage.Count());
                Assert.Equal(100, remediationPage.Select(remediation => remediation.Id).Distinct(StringComparer.OrdinalIgnoreCase).Count());
                Assert.NotNull(remediationPage.NextPageLink);

                var nextRemediationsPage = policyInsightsClient.Remediations.ListForSubscriptionNext(nextPageLink: remediationPage.NextPageLink);
                Assert.Equal(74, nextRemediationsPage.Count());
                Assert.Equal(74, nextRemediationsPage.Select(remediation => remediation.Id).Distinct(StringComparer.OrdinalIgnoreCase).Count());
                Assert.Empty(nextRemediationsPage.Select(r => r.Id).Intersect(remediationPage.Select(r => r.Id), StringComparer.OrdinalIgnoreCase));
                Assert.Null(nextRemediationsPage.NextPageLink);

                // Get the top 99 remediations, should return a single page with no next link
                remediationPage = policyInsightsClient.Remediations.ListForSubscription(subscriptionId: SubscriptionId, queryOptions: new QueryOptions(top: 99));
                Assert.Equal(99, remediationPage.Count());
                Assert.Equal(99, remediationPage.Select(remediation => remediation.Id).Distinct(StringComparer.OrdinalIgnoreCase).Count());
                Assert.Null(remediationPage.NextPageLink);

                // Get the top 101 remediations, should return 2 pages. The last page should have no next link.
                remediationPage = policyInsightsClient.Remediations.ListForSubscription(subscriptionId: SubscriptionId, queryOptions: new QueryOptions(top: 101));
                Assert.Equal(100, remediationPage.Count());
                Assert.Equal(100, remediationPage.Select(remediation => remediation.Id).Distinct(StringComparer.OrdinalIgnoreCase).Count());
                Assert.NotNull(remediationPage.NextPageLink);

                nextRemediationsPage = policyInsightsClient.Remediations.ListForSubscriptionNext(nextPageLink: remediationPage.NextPageLink);
                Assert.Single(nextRemediationsPage);
                Assert.Single( nextRemediationsPage.Select(remediation => remediation.Id).Distinct(StringComparer.OrdinalIgnoreCase));
                Assert.Empty(nextRemediationsPage.Select(r => r.Id).Intersect(remediationPage.Select(r => r.Id), StringComparer.OrdinalIgnoreCase));
                Assert.Null(nextRemediationsPage.NextPageLink);

                // Get deployments for a remediation with 102 deployments. Results should be in 2 pages. The second page should have no next link.
                var deploymentsPage = policyInsightsClient.Remediations.ListDeploymentsAtSubscription(subscriptionId: SubscriptionId, remediationName: RemediationName);
                Assert.Equal(100, deploymentsPage.Count());
                Assert.Equal(100, deploymentsPage.Select(d => d.RemediatedResourceId).Distinct(StringComparer.OrdinalIgnoreCase).Count());
                Assert.NotNull(deploymentsPage.NextPageLink);

                var nextDeploymentsPage = policyInsightsClient.Remediations.ListDeploymentsAtSubscriptionNext(nextPageLink: deploymentsPage.NextPageLink);
                Assert.Equal(2, nextDeploymentsPage.Count());
                Assert.Empty(nextDeploymentsPage.Select(d => d.RemediatedResourceId).Intersect(deploymentsPage.Select(d => d.RemediatedResourceId), StringComparer.OrdinalIgnoreCase));
                Assert.Null(nextDeploymentsPage.NextPageLink);

                // Get the top 99 deployments, should return a single page with no next link 
                deploymentsPage = policyInsightsClient.Remediations.ListDeploymentsAtSubscription(subscriptionId: SubscriptionId, remediationName: RemediationName, queryOptions: new QueryOptions(top: 99));
                Assert.Equal(99, deploymentsPage.Count());
                Assert.Equal(99, deploymentsPage.Select(d => d.RemediatedResourceId).Distinct(StringComparer.OrdinalIgnoreCase).Count());
                Assert.Null(deploymentsPage.NextPageLink);

                // Get the top 101 deployments, should return 2 pages. The last page should have no next link.
                deploymentsPage = policyInsightsClient.Remediations.ListDeploymentsAtSubscription(subscriptionId: SubscriptionId, remediationName: RemediationName, queryOptions: new QueryOptions(top: 101));
                Assert.Equal(100, deploymentsPage.Count());
                Assert.Equal(100, deploymentsPage.Select(d => d.RemediatedResourceId).Distinct(StringComparer.OrdinalIgnoreCase).Count());
                Assert.NotNull(deploymentsPage.NextPageLink);

                nextDeploymentsPage = policyInsightsClient.Remediations.ListDeploymentsAtSubscriptionNext(nextPageLink: deploymentsPage.NextPageLink);
                Assert.Single(nextDeploymentsPage);
                Assert.Empty(nextDeploymentsPage.Select(d => d.RemediatedResourceId).Intersect(deploymentsPage.Select(d => d.RemediatedResourceId), StringComparer.OrdinalIgnoreCase));
                Assert.Null(nextDeploymentsPage.NextPageLink);
            }
        }

        #endregion

        #region Resource Group Scope

        /// <summary>
        /// Test remediation task operations at resource group level.
        /// </summary>
        [Fact]
        public void Remediations_ResourceGroupCrud()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();

                // Create a single policy remediation
                var remediationName = "b9e40e46-30ad-44ca-b4cd-939ee6e5fb38";
                var remediationParams = new Remediation
                {
                    PolicyAssignmentId = PolicyAssignmentId,
                    Filters = new RemediationFilters(new[] { "eastus" }),
                    ResourceDiscoveryMode = ResourceDiscoveryMode.ExistingNonCompliant,
                    ParallelDeployments = 1,
                    ResourceCount = 1,
                    FailureThreshold = new RemediationPropertiesFailureThreshold { Percentage = 0.42 }
                };

                var createdRemediation = policyInsightsClient.Remediations.CreateOrUpdateAtResourceGroup(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, remediationName: remediationName, parameters: remediationParams);
                Assert.Equal(ProvisioningState.Accepted, createdRemediation.ProvisioningState);
                Assert.Equal(0, createdRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(0, createdRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, createdRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: createdRemediation, remediationName: remediationName);

                var completedRemediation = this.WaitForCompletion(() => policyInsightsClient.Remediations.GetAtResourceGroup(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, remediationName: remediationName));
                Assert.Equal(ProvisioningState.Succeeded, completedRemediation.ProvisioningState);
                Assert.Equal(1, completedRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(1, completedRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, completedRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: completedRemediation, remediationName: remediationName);

                // List deployments for the remediation
                var deployments = policyInsightsClient.Remediations.ListDeploymentsAtResourceGroup(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, remediationName: remediationName);
                Assert.Single(deployments);
                var deployment = deployments.First();
                this.ValidateDeployment(deployment);
                Assert.Contains("/subscriptions/" + SubscriptionId, deployment.DeploymentId, StringComparison.OrdinalIgnoreCase);
                Assert.Equal("eastus", deployment.ResourceLocation);
                Assert.Contains("Microsoft.KeyVault/vaults", deployment.RemediatedResourceId, StringComparison.OrdinalIgnoreCase);

                // Cancel the completed remediation, should fail
                try
                {
                    policyInsightsClient.Remediations.CancelAtResourceGroup(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, remediationName: remediationName);
                    Assert.True(false, "Cancelling a completed remediation should have thrown an error");
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal("InvalidCancelRemediationRequest", ex.Body.Error.Code);
                    Assert.Contains("A completed remediation cannot be cancelled", ex.Body.Error.Message, StringComparison.OrdinalIgnoreCase);
                }


                // Delete the remediation
                var deletedRemediation = policyInsightsClient.Remediations.DeleteAtResourceGroup(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, remediationName: remediationName);
                Assert.Equal(ProvisioningState.Succeeded, completedRemediation.ProvisioningState);
                Assert.Equal(1, deletedRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(1, deletedRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, deletedRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: deletedRemediation, remediationName: remediationName);
            }
        }

        #endregion

        #region Resource Scope

        /// <summary>
        /// Test remediation task operations at resource level.
        /// </summary>
        [Fact]
        public void Remediations_IndividualResourceCrud()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();

                // Create a single policy remediation
                var remediationName = "5f39e0f3-3945-4587-8a24-c1161dc10ef4";
                var remediationParams = new Remediation
                {
                    PolicyAssignmentId = PolicyAssignmentId,
                    Filters = new RemediationFilters(new[] { "eastus" }),
                    ParallelDeployments = 1,
                    ResourceCount = 1,
                    FailureThreshold = new RemediationPropertiesFailureThreshold { Percentage = 0.42 }
                };

                var createdRemediation = policyInsightsClient.Remediations.CreateOrUpdateAtResource(resourceId: IndividualResourceId, remediationName: remediationName, parameters: remediationParams);
                Assert.Equal(ProvisioningState.Accepted, createdRemediation.ProvisioningState);
                Assert.Equal(0, createdRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(0, createdRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, createdRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: createdRemediation, remediationName: remediationName);

                var completedRemediation = this.WaitForCompletion(() => policyInsightsClient.Remediations.GetAtResource(resourceId: IndividualResourceId, remediationName: remediationName));
                Assert.Equal(ProvisioningState.Succeeded, completedRemediation.ProvisioningState);
                Assert.Equal(1, completedRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(1, completedRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, completedRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: completedRemediation, remediationName: remediationName);

                // List deployments for the remediation
                var deployments = policyInsightsClient.Remediations.ListDeploymentsAtResource(resourceId: IndividualResourceId, remediationName: remediationName);
                Assert.Single(deployments);
                var deployment = deployments.First();
                this.ValidateDeployment(deployment);
                Assert.Contains("/subscriptions/" + SubscriptionId, deployment.DeploymentId, StringComparison.OrdinalIgnoreCase);
                Assert.Equal("eastus", deployment.ResourceLocation);
                Assert.Contains("Microsoft.KeyVault/vaults", deployment.RemediatedResourceId, StringComparison.OrdinalIgnoreCase);

                // Cancel the completed remediation, should fail
                try
                {
                    policyInsightsClient.Remediations.CancelAtResource(resourceId: IndividualResourceId, remediationName: remediationName);
                    Assert.True(false, "Cancelling a completed remediation should have thrown an error");
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal("InvalidCancelRemediationRequest", ex.Body.Error.Code);
                    Assert.Contains("A completed remediation cannot be cancelled", ex.Body.Error.Message, StringComparison.OrdinalIgnoreCase);
                }


                // Delete the remediation
                var deletedRemediation = policyInsightsClient.Remediations.DeleteAtResource(resourceId: IndividualResourceId, remediationName: remediationName);
                Assert.Equal(ProvisioningState.Succeeded, completedRemediation.ProvisioningState);
                Assert.Equal(1, deletedRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(1, deletedRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, deletedRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: deletedRemediation, remediationName: remediationName);
            }
        }

        #endregion

        #region Management Group Scope

        /// <summary>
        /// Test remediation task operations at management group scope.
        /// </summary>
        [Fact]
        public void Remediations_ManagementGroupCrud()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();

                // Create a single policy remediation
                var remediationName = "3a014f44-0aed-4a55-ac50-8a4cb2016db2";
                var remediationParams = new Remediation
                {
                    PolicyAssignmentId = ManagementGroupPolicyAssignmentId,
                    Filters = new RemediationFilters(new[] { "eastus" }),
                    ParallelDeployments = 1,
                    ResourceCount = 1,
                    FailureThreshold = new RemediationPropertiesFailureThreshold { Percentage = 0.42 }
                };

                var createdRemediation = policyInsightsClient.Remediations.CreateOrUpdateAtManagementGroup(managementGroupId: ManagementGroupName, remediationName: remediationName, parameters: remediationParams);
                Assert.Equal(ProvisioningState.Accepted, createdRemediation.ProvisioningState);
                Assert.Equal(0, createdRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(0, createdRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, createdRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: createdRemediation, remediationName: remediationName);

                var completedRemediation = this.WaitForCompletion(() => policyInsightsClient.Remediations.GetAtManagementGroup(managementGroupId: ManagementGroupName, remediationName: remediationName));
                Assert.Equal(ProvisioningState.Succeeded, completedRemediation.ProvisioningState);
                Assert.Equal(1, completedRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(1, completedRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, completedRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: completedRemediation, remediationName: remediationName);

                // List deployments for the remediation
                var deployments = policyInsightsClient.Remediations.ListDeploymentsAtManagementGroup(managementGroupId: ManagementGroupName, remediationName: remediationName);
                Assert.Single(deployments);
                var deployment = deployments.First();
                this.ValidateDeployment(deployment);
                Assert.Contains($"/subscriptions/{RemediationsTests.SubscriptionId}", deployment.DeploymentId, StringComparison.OrdinalIgnoreCase);
                Assert.Equal("eastus", deployment.ResourceLocation, ignoreCase: true);
                Assert.Contains("Microsoft.KeyVault/vaults", deployment.RemediatedResourceId, StringComparison.OrdinalIgnoreCase);

                // Cancel the completed remediation, should fail
                try
                {
                    policyInsightsClient.Remediations.CancelAtManagementGroup(managementGroupId: ManagementGroupName, remediationName: remediationName);
                    Assert.True(false, "Cancelling a completed remediation should have thrown an error");
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal("InvalidCancelRemediationRequest", ex.Body.Error.Code);
                    Assert.Contains("A completed remediation cannot be cancelled", ex.Body.Error.Message, StringComparison.OrdinalIgnoreCase);
                }


                // Delete the remediation
                var deletedRemediation = policyInsightsClient.Remediations.DeleteAtManagementGroup(managementGroupId: ManagementGroupName, remediationName: remediationName);
                Assert.Equal(ProvisioningState.Succeeded, completedRemediation.ProvisioningState);
                Assert.Equal(1, deletedRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(1, deletedRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, deletedRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: deletedRemediation, remediationName: remediationName);
            }
        }

        /// <summary>
        /// Test a remediation task that scans resource compliance before remediating.
        /// </summary>
        [Fact]
        public void Remediations_ReEvaluateCompliance()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();

                // Create a single policy remediation
                var remediationName = "79535898-0a82-4cbc-bd17-ea08f3cd2ea0";
                var remediationParams = new Remediation
                {
                    PolicyAssignmentId = PolicyAssignmentId,
                    Filters = new RemediationFilters(new[] { "eastus" }),
                    ResourceDiscoveryMode = ResourceDiscoveryMode.ReEvaluateCompliance,
                    ParallelDeployments = 1,
                    ResourceCount = 1,
                    FailureThreshold = new RemediationPropertiesFailureThreshold { Percentage = 0.42 }
                };

                var createdRemediation = policyInsightsClient.Remediations.CreateOrUpdateAtResourceGroup(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, remediationName: remediationName, parameters: remediationParams);
                Assert.Equal(ProvisioningState.Accepted, createdRemediation.ProvisioningState);
                Assert.Equal(0, createdRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(0, createdRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, createdRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: createdRemediation, remediationName: remediationName);

                var completedRemediation = this.WaitForCompletion(() => policyInsightsClient.Remediations.GetAtResourceGroup(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, remediationName: remediationName));
                Assert.Equal(ProvisioningState.Succeeded, completedRemediation.ProvisioningState);
                Assert.Equal(1, completedRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(1, completedRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, completedRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: completedRemediation, remediationName: remediationName);

                // List deployments for the remediation
                var deployments = policyInsightsClient.Remediations.ListDeploymentsAtResourceGroup(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, remediationName: remediationName);
                Assert.Single(deployments);
                var deployment = deployments.First();
                this.ValidateDeployment(deployment);
                Assert.Contains("/subscriptions/" + SubscriptionId, deployment.DeploymentId, StringComparison.OrdinalIgnoreCase);
                Assert.Equal("eastus", deployment.ResourceLocation);
                Assert.Contains("Microsoft.KeyVault/vaults", deployment.RemediatedResourceId, StringComparison.OrdinalIgnoreCase);

                // Cancel the completed remediation, should fail
                try
                {
                    policyInsightsClient.Remediations.CancelAtResourceGroup(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, remediationName: remediationName);
                    Assert.True(false, "Cancelling a completed remediation should have thrown an error");
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal("InvalidCancelRemediationRequest", ex.Body.Error.Code);
                    Assert.Contains("A completed remediation cannot be cancelled", ex.Body.Error.Message, StringComparison.OrdinalIgnoreCase);
                }


                // Delete the remediation
                var deletedRemediation = policyInsightsClient.Remediations.DeleteAtResourceGroup(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, remediationName: remediationName);
                Assert.Equal(ProvisioningState.Succeeded, completedRemediation.ProvisioningState);
                Assert.Equal(1, deletedRemediation.DeploymentStatus.TotalDeployments);
                Assert.Equal(1, deletedRemediation.DeploymentStatus.SuccessfulDeployments);
                Assert.Equal(0, deletedRemediation.DeploymentStatus.FailedDeployments);
                this.ValidateRemediation(expected: remediationParams, actual: deletedRemediation, remediationName: remediationName);
            }
        }

        #endregion
    }
}
