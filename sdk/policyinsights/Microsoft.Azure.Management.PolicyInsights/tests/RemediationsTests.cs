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
    /// Recorded with Service Principal app ID '2b460e05-e68d-45f0-aec8-e8f8da41b6a7', display name 'omsARMtests'.
    /// </summary>
    public class RemediationsTests : TestBase
    {
        #region Test setup
        
        private static string ManagementGroupName = "PolicyUIMG";
        private static string ManagementGroupPolicyAssignmentId = "/providers/Microsoft.Management/managementGroups/PolicyUIMG/providers/Microsoft.Authorization/policyAssignments/8b57f7161f324871acc2d3cf";
        private static string SubscriptionId = "d0610b27-9663-4c05-89f8-5b4be01e86a5";
        private static string ResourceGroupName = "cheggpolicy";
        private static string IndividualResourceId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourceGroups/cheggpolicy/providers/Microsoft.Sql/servers/cheggsql";
        private static string PolicyAssignmentId = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/951bc2f1b9194a66a9552f97";
        private static string RemediationName = "1bd6a6fd-649e-4685-a77c-23f560b27637";

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
            for (var i = 0; i < 20; i++)
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
                var remediationParams = new Remediation { PolicyAssignmentId = PolicyAssignmentId, Filters = new RemediationFilters(new[] { "westcentralus" })};

                var createdRemediation = policyInsightsClient.Remediations.CreateOrUpdateAtSubscription(subscriptionId: SubscriptionId, remediationName: remediationName, parameters: remediationParams);
                Assert.Equal(ProvisioningState.Accepted, createdRemediation.ProvisioningState);
                Assert.Equal(1, createdRemediation.DeploymentStatus.TotalDeployments);
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
                Assert.Equal("westcentralus", deployment.ResourceLocation);
                Assert.Contains("Microsoft.SQL/servers", deployment.RemediatedResourceId, StringComparison.OrdinalIgnoreCase);

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

                // List remediations in the subscription, 5 at a time, ensure next page works
                var remediationPage = policyInsightsClient.Remediations.ListForSubscription(subscriptionId: SubscriptionId, queryOptions: new QueryOptions(top: 5));
                Assert.Equal(5, remediationPage.Count());
                Assert.Equal(5, remediationPage.Select(remediation => remediation.Id).Distinct(StringComparer.OrdinalIgnoreCase).Count());
                Assert.NotNull(remediationPage.NextPageLink);

                var nextRemediationsPage = policyInsightsClient.Remediations.ListForSubscriptionNext(nextPageLink: remediationPage.NextPageLink);
                Assert.Equal(5, nextRemediationsPage.Count());
                Assert.Empty(nextRemediationsPage.Select(r => r.Id).Intersect(remediationPage.Select(r => r.Id), StringComparer.OrdinalIgnoreCase));

                // Get deployments for a remediation 11 at a time, ensure next page works
                var deploymentsPage = policyInsightsClient.Remediations.ListDeploymentsAtSubscription(subscriptionId: SubscriptionId, remediationName: RemediationName, queryOptions: new QueryOptions(top: 11));
                Assert.Equal(11, deploymentsPage.Count());
                Assert.Equal(11, deploymentsPage.Select(d => d.DeploymentId).Distinct(StringComparer.OrdinalIgnoreCase).Count());
                Assert.NotNull(deploymentsPage.NextPageLink);

                var nextDeploymentsPage = policyInsightsClient.Remediations.ListDeploymentsAtSubscriptionNext(nextPageLink: deploymentsPage.NextPageLink);
                Assert.Equal(11, nextDeploymentsPage.Count());
                Assert.Empty(nextDeploymentsPage.Select(d => d.DeploymentId).Intersect(deploymentsPage.Select(d => d.DeploymentId), StringComparer.OrdinalIgnoreCase));
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
                var remediationParams = new Remediation { PolicyAssignmentId = PolicyAssignmentId, Filters = new RemediationFilters(new[] { "westcentralus" }) };

                var createdRemediation = policyInsightsClient.Remediations.CreateOrUpdateAtResourceGroup(subscriptionId: SubscriptionId, resourceGroupName: ResourceGroupName, remediationName: remediationName, parameters: remediationParams);
                Assert.Equal(ProvisioningState.Accepted, createdRemediation.ProvisioningState);
                Assert.Equal(1, createdRemediation.DeploymentStatus.TotalDeployments);
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
                Assert.Equal("westcentralus", deployment.ResourceLocation);
                Assert.Contains("Microsoft.SQL/servers", deployment.RemediatedResourceId, StringComparison.OrdinalIgnoreCase);

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
                var remediationParams = new Remediation { PolicyAssignmentId = PolicyAssignmentId };

                var createdRemediation = policyInsightsClient.Remediations.CreateOrUpdateAtResource(resourceId: IndividualResourceId, remediationName: remediationName, parameters: remediationParams);
                Assert.Equal(ProvisioningState.Accepted, createdRemediation.ProvisioningState);
                Assert.Equal(1, createdRemediation.DeploymentStatus.TotalDeployments);
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
                Assert.Equal("westcentralus", deployment.ResourceLocation);
                Assert.Contains("Microsoft.SQL/servers", deployment.RemediatedResourceId, StringComparison.OrdinalIgnoreCase);

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
                var remediationParams = new Remediation { PolicyAssignmentId = ManagementGroupPolicyAssignmentId };

                var createdRemediation = policyInsightsClient.Remediations.CreateOrUpdateAtManagementGroup(managementGroupId: ManagementGroupName, remediationName: remediationName, parameters: remediationParams);
                Assert.Equal(ProvisioningState.Accepted, createdRemediation.ProvisioningState);
                Assert.Equal(1, createdRemediation.DeploymentStatus.TotalDeployments);
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
                Assert.Contains("/subscriptions/e78961ba-36fe-4739-9212-e3031b4c8db7", deployment.DeploymentId, StringComparison.OrdinalIgnoreCase);
                Assert.Equal("eastus", deployment.ResourceLocation);
                Assert.Contains("Microsoft.SQL/servers", deployment.RemediatedResourceId, StringComparison.OrdinalIgnoreCase);

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

        #endregion
    }
}
