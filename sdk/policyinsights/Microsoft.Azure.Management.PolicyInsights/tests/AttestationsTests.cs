// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace PolicyInsights.Tests
{
    using System;
    using System.Linq;
    using Microsoft.Azure.Management.PolicyInsights;
    using Microsoft.Azure.Management.PolicyInsights.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

    /// <summary>
    /// Tests for the Attestations APIs (Microsoft.PolicyInsights/attestations).
    /// </summary>
    public class AttestationsTests : TestBase
    {
        #region Test

        /// <summary>
        /// Validates attestation CRUD at subscription scope.
        /// </summary>
        [Fact]
        public void Attestations_SubscriptionScope()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                // Add a policy that can be used for testing
                var armPolicyClient = context.GetServiceClient<PolicyClient>();
                var policyDefinitionParams = new PolicyDefinition
                {
                    Mode = "All",
                    PolicyRule = JObject.Parse(@"{
                        'if': {
                            'field': 'type',
                            'equals': 'Microsoft.Resources/subscriptions'
                        },
                        'then': {
                            'effect': 'manual'
                        }
                    }")
                };

                var policyDefinition = armPolicyClient.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: "attestationSdkTest", parameters: policyDefinitionParams);

                var scope = $"/subscriptions/{armPolicyClient.SubscriptionId}";
                var policyAssignment = armPolicyClient.PolicyAssignments.Create(scope: scope, policyAssignmentName: "attestationSdkTest", parameters: new PolicyAssignment(policyDefinitionId: policyDefinition.Id));

                // Trigger an evaluation on the subscription to ensure the policy states results are updated
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();
                policyInsightsClient.PolicyStates.TriggerSubscriptionEvaluation(armPolicyClient.SubscriptionId);

                // Create an attestation
                var attestationParams = new Attestation
                {
                    Comments = ".NET SDK Test",
                    ComplianceState = "Compliant",
                    ExpiresOn = new DateTime(2030, 12, 10),
                    Owner = "Test Owner",
                    PolicyAssignmentId = policyAssignment.Id,
                    Evidence = new[]
                    {
                        new AttestationEvidence(description: "Evidence 1", sourceUri: "http://www.contoso.com/evidence1"),
                        new AttestationEvidence(description: "Evidence 2", sourceUri: "http://www.contoso.com/evidence2")
                    },
                    AssessmentDate = new DateTime(2022, 12, 5),
                    Metadata = new JObject()
                    {
                        {"DEPT_ID", "NYC4-MARKETING" }
                    }
                };

                var attestationName = "attestationSdkTestSub";
                var attestationResult = policyInsightsClient.Attestations.CreateOrUpdateAtSubscription(subscriptionId: armPolicyClient.SubscriptionId, attestationName: attestationName, parameters: attestationParams);
                this.ValidateAttestation(expected: attestationParams, actual: attestationResult);

                // Retrieve it via a single GET
                attestationResult = policyInsightsClient.Attestations.GetAtSubscription(subscriptionId: armPolicyClient.SubscriptionId, attestationName: attestationName);
                this.ValidateAttestation(expected: attestationParams, actual: attestationResult);

                // Retrieve it via a collection GET
                var listResult = policyInsightsClient.Attestations.ListForSubscription(subscriptionId: armPolicyClient.SubscriptionId).ToArray();
                var expectedAttestation = listResult.SingleOrDefault(attestation => attestation.Name.Equals(attestationName, StringComparison.OrdinalIgnoreCase));
                Assert.NotNull(expectedAttestation);
                this.ValidateAttestation(expected: attestationParams, actual: expectedAttestation);

                // Update it and ensure the update goes through
                attestationParams.Comments = "Updated via .NET SDK Test";
                attestationResult = policyInsightsClient.Attestations.CreateOrUpdateAtSubscription(subscriptionId: armPolicyClient.SubscriptionId, attestationName: attestationName, parameters: attestationParams);
                this.ValidateAttestation(expected: attestationParams, actual: attestationResult);

                // Delete it
                policyInsightsClient.Attestations.DeleteAtSubscription(subscriptionId: armPolicyClient.SubscriptionId, attestationName: attestationName);

                // Delete the policy entities
                armPolicyClient.PolicyAssignments.DeleteById(policyAssignment.Id);
                armPolicyClient.PolicyDefinitions.Delete(policyDefinition.Name);
            }
        }

        /// <summary>
        /// Validates attestation CRUD at resource group scope.
        /// </summary>
        [Fact]
        public void Attestations_ResourceGroupScope()
        {
            const string ResourceGroupName = "attestationSdkTests";

            using (var context = MockContext.Start(this.GetType()))
            {
                // Create a resource group
                var armClient = context.GetServiceClient<ResourceManagementClient>();
                var armResourceTypes = armClient.ProviderResourceTypes.List("Microsoft.Resources");
                var resourceGroupType = armResourceTypes.Value.First(resourceType => resourceType.ResourceType.Equals("resourceGroups", StringComparison.OrdinalIgnoreCase));
                armClient.ResourceGroups.CreateOrUpdate(ResourceGroupName, new ResourceGroup(location: resourceGroupType.Locations[0]));

                // Add a policy that can be used for testing
                var armPolicyClient = context.GetServiceClient<PolicyClient>();
                var policyDefinitionParams = new PolicyDefinition
                {
                    Mode = "All",
                    PolicyRule = JObject.Parse(@"{
                        'if': {
                            'field': 'type',
                            'equals': 'Microsoft.Resources/subscriptions/resourceGroups'
                        },
                        'then': {
                            'effect': 'manual'
                        }
                    }")
                };

                var policyDefinition = armPolicyClient.PolicyDefinitions.CreateOrUpdate(policyDefinitionName: "attestationSdkTest", parameters: policyDefinitionParams);

                var scope = $"/subscriptions/{armPolicyClient.SubscriptionId}/resourceGroups/{ResourceGroupName}";
                var policyAssignment = armPolicyClient.PolicyAssignments.Create(scope: scope, policyAssignmentName: "attestationSdkTest", parameters: new PolicyAssignment(policyDefinitionId: policyDefinition.Id));

                // Trigger an evaluation on the subscription to ensure the policy states results are updated
                var policyInsightsClient = context.GetServiceClient<PolicyInsightsClient>();
                policyInsightsClient.PolicyStates.TriggerResourceGroupEvaluation(subscriptionId: armPolicyClient.SubscriptionId, resourceGroupName: ResourceGroupName);

                // Create an attestation
                var attestationParams = new Attestation
                {
                    Comments = ".NET SDK Test",
                    ComplianceState = "Compliant",
                    ExpiresOn = new DateTime(2030, 12, 10),
                    Owner = "Test Owner",
                    PolicyAssignmentId = policyAssignment.Id,
                    Evidence = new[]
                    {
                        new AttestationEvidence(description: "Evidence 1", sourceUri: "http://www.contoso.com/evidence1"),
                        new AttestationEvidence(description: "Evidence 2", sourceUri: "http://www.contoso.com/evidence2")
                    },
                    AssessmentDate = new DateTime(2022, 12, 5),
                    Metadata = new JObject()
                    {
                        {"DEPT_ID", "NYC4-MARKETING" }
                    }
                };

                var attestationName = "attestationSdkTestRg";
                var attestationResult = policyInsightsClient.Attestations.CreateOrUpdateAtResourceGroup(subscriptionId: armPolicyClient.SubscriptionId, resourceGroupName: ResourceGroupName, attestationName: attestationName, parameters: attestationParams);
                this.ValidateAttestation(expected: attestationParams, actual: attestationResult);

                // Retrieve it via a single GET
                attestationResult = policyInsightsClient.Attestations.GetAtResourceGroup(subscriptionId: armPolicyClient.SubscriptionId, resourceGroupName: ResourceGroupName, attestationName: attestationName);
                this.ValidateAttestation(expected: attestationParams, actual: attestationResult);

                // Retrieve it via a collection GET
                var listResult = policyInsightsClient.Attestations.ListForResourceGroup(subscriptionId: armPolicyClient.SubscriptionId, resourceGroupName: ResourceGroupName).ToArray();
                var expectedAttestation = listResult.SingleOrDefault(attestation => attestation.Name.Equals(attestationName, StringComparison.OrdinalIgnoreCase));
                Assert.NotNull(expectedAttestation);
                this.ValidateAttestation(expected: attestationParams, actual: expectedAttestation);

                // Retrieve it via a collection GET at subscription scope
                listResult = policyInsightsClient.Attestations.ListForSubscription(subscriptionId: armPolicyClient.SubscriptionId).ToArray();
                expectedAttestation = listResult.SingleOrDefault(attestation => attestation.Name.Equals(attestationName, StringComparison.OrdinalIgnoreCase));
                Assert.NotNull(expectedAttestation);
                this.ValidateAttestation(expected: attestationParams, actual: expectedAttestation);

                // Update it and ensure the update goes through
                attestationParams.Comments = "Updated via .NET SDK Test";
                attestationResult = policyInsightsClient.Attestations.CreateOrUpdateAtResourceGroup(subscriptionId: armPolicyClient.SubscriptionId, resourceGroupName: ResourceGroupName, attestationName: attestationName, parameters: attestationParams);
                this.ValidateAttestation(expected: attestationParams, actual: attestationResult);

                // Delete it
                policyInsightsClient.Attestations.DeleteAtResourceGroup(subscriptionId: armPolicyClient.SubscriptionId, resourceGroupName: ResourceGroupName, attestationName: attestationName);

                // Delete the policy entities
                armPolicyClient.PolicyAssignments.DeleteById(policyAssignment.Id);
                armPolicyClient.PolicyDefinitions.Delete(policyDefinition.Name);
            }
        }

        #endregion

        /// <summary>
        /// Validates that two attestations are equivalent.
        /// </summary>
        /// <param name="expected">The expected attestation.</param>
        /// <param name="actual">The actual attestation.</param>
        private void ValidateAttestation(Attestation expected, Attestation actual)
        {
            Assert.Equal(expected.Comments, actual.Comments);
            Assert.Equal(expected.ComplianceState, actual.ComplianceState);
            Assert.Equal(expected.ExpiresOn, actual.ExpiresOn);
            Assert.Equal(expected.Owner, actual.Owner);
            Assert.Equal(expected.PolicyAssignmentId, actual.PolicyAssignmentId, ignoreCase: true);
            Assert.Equal(expected.PolicyDefinitionReferenceId, actual.PolicyDefinitionReferenceId, ignoreCase: true);
            Assert.Equal(expected.Evidence.Count, actual.Evidence.Count);
            Assert.Equal(expected.AssessmentDate, actual.AssessmentDate);
            Assert.Equal(expected.Metadata, actual.Metadata);

            for(var i = 0; i < expected.Evidence.Count; i++)
            {
                Assert.Equal(expected.Evidence[i].Description, actual.Evidence[i].Description);
                Assert.Equal(expected.Evidence[i].SourceUri, actual.Evidence[i].SourceUri);
            }
        }
    }
}
