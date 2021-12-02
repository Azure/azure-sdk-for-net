// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace PolicyInsights.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.PolicyInsights;
    using Microsoft.Azure.Management.PolicyInsights.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

    /// <summary>
    /// Tests for the PolicyRestrictions APIs (Microsoft.PolicyInsights/checkPolicyRestrictions). These can be run against any subscription.
    /// </summary>
    public class PolicyRestrictionsTests : TestBase
    {
        #region Test

        /// <summary>
        /// Validates policy restrictions can be checked at subscription scope.
        /// </summary>
        [Fact]
        public void PolicyRestrictions_SubscriptionScope()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                // Add a policy assignment (allowed storage account SKUs) that can be used to validate checkPolicyRestrictions
                var armPolicyClient = context.GetServiceClient<PolicyClient>();
                var policyAssignmentParams = new PolicyAssignment
                {
                    PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/7433c107-6db4-4ad1-b57a-a76dce0154a1",
                    Parameters = new Dictionary<string, ParameterValuesValue> { ["effect"] = new ParameterValuesValue("Deny"), ["listOfAllowedSKUs"] = new ParameterValuesValue(new[] { "Standard_LRS" }) }
                };

                var policyAssignment = armPolicyClient.PolicyAssignments.Create(scope: $"/subscriptions/{armPolicyClient.SubscriptionId}", policyAssignmentName: "checkRestrictSdkTest", parameters: policyAssignmentParams);

                // Send a check restrictions request with a potential list of SKUs, two will be denied
                var checkRestrictionsParams = new CheckRestrictionsRequest
                {
                    ResourceDetails = new CheckRestrictionsResourceDetails
                    {
                        ApiVersion = "2021-04-01",
                        ResourceContent = new JObject(new JProperty("type", "Microsoft.Storage/storageAccounts"))
                    },
                    PendingFields = new[]
                    {
                        new PendingField
                        {
                            Field = "Microsoft.Storage/storageAccounts/sku.name",
                            Values = new[] { "Standard_ZRS", "Premium_LRS", "Standard_LRS" }
                        }
                    }
                };

                var policyRestrictionsClient = context.GetServiceClient<PolicyInsightsClient>();
                var checkRestrictionsResult = policyRestrictionsClient.PolicyRestrictions.CheckAtSubscriptionScope(subscriptionId: armPolicyClient.SubscriptionId, parameters: checkRestrictionsParams);
                
                Assert.Equal(0, checkRestrictionsResult.ContentEvaluationResult.PolicyEvaluations.Count);
                Assert.Equal(1, checkRestrictionsResult.FieldRestrictions.Count);
                var fieldRestriction = checkRestrictionsResult.FieldRestrictions[0];
                Assert.Equal("Microsoft.Storage/storageAccounts/sku.name", fieldRestriction.Field);
                Assert.Equal(1, fieldRestriction.Restrictions.Count);
                Assert.Equal("Deny", fieldRestriction.Restrictions[0].Result);
                Assert.Equal(2, fieldRestriction.Restrictions[0].Values.Count);
                Assert.Equal(new[] { "Standard_ZRS", "Premium_LRS" }, fieldRestriction.Restrictions[0].Values, StringComparer.OrdinalIgnoreCase);

                armPolicyClient.PolicyAssignments.DeleteById(policyAssignment.Id);
            }
        }

        /// <summary>
        /// Validates policy restrictions can be checked at resource group scope.
        /// </summary>
        [Fact]
        public void PolicyRestrictions_ResourceGroupScope()
        {
            const string ResourceGroupName = "checkRestrictSdkTests";

            using (var context = MockContext.Start(this.GetType()))
            {
                // Create a resource group
                var armClient = context.GetServiceClient<ResourceManagementClient>();
                var armResourceTypes = armClient.ProviderResourceTypes.List("Microsoft.Resources");
                var resourceGroupType = armResourceTypes.Value.First(resourceType => resourceType.ResourceType.Equals("resourceGroups", StringComparison.OrdinalIgnoreCase));
                armClient.ResourceGroups.CreateOrUpdate(ResourceGroupName, new ResourceGroup(location: resourceGroupType.Locations[0]));

                // Add a policy assignment (allowed storage account SKUs) that can be used to validate checkPolicyRestrictions
                var armPolicyClient = context.GetServiceClient<PolicyClient>();
                var policyAssignmentParams = new PolicyAssignment
                {
                    PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/7433c107-6db4-4ad1-b57a-a76dce0154a1",
                    Parameters = new Dictionary<string, ParameterValuesValue> { ["effect"] = new ParameterValuesValue("Deny"), ["listOfAllowedSKUs"] = new ParameterValuesValue(new[] { "Standard_LRS" }) }
                };

                var scope = $"/subscriptions/{armPolicyClient.SubscriptionId}/resourceGroups/{ResourceGroupName}";
                armPolicyClient.PolicyAssignments.Create(scope: scope, policyAssignmentName: "checkRestrictSdkTest", parameters: policyAssignmentParams);

                // Send a check restrictions request with a potential list of SKUs, two will be denied
                var checkRestrictionsParams = new CheckRestrictionsRequest
                {
                    ResourceDetails = new CheckRestrictionsResourceDetails
                    {
                        ApiVersion = "2021-04-01",
                        ResourceContent = new JObject(new JProperty("type", "Microsoft.Storage/storageAccounts"))
                    },
                    PendingFields = new[]
                    {
                        new PendingField
                        {
                            Field = "Microsoft.Storage/storageAccounts/sku.name",
                            Values = new[] { "Standard_ZRS", "Premium_LRS", "Standard_LRS" }
                        }
                    }
                };

                var policyRestrictionsClient = context.GetServiceClient<PolicyInsightsClient>();
                var checkRestrictionsResult = policyRestrictionsClient.PolicyRestrictions.CheckAtResourceGroupScope(subscriptionId: armPolicyClient.SubscriptionId, resourceGroupName: ResourceGroupName, parameters: checkRestrictionsParams);

                Assert.Equal(0, checkRestrictionsResult.ContentEvaluationResult.PolicyEvaluations.Count);
                Assert.Equal(1, checkRestrictionsResult.FieldRestrictions.Count);
                var fieldRestriction = checkRestrictionsResult.FieldRestrictions[0];
                Assert.Equal("Microsoft.Storage/storageAccounts/sku.name", fieldRestriction.Field);
                Assert.Equal(1, fieldRestriction.Restrictions.Count);
                Assert.Equal("Deny", fieldRestriction.Restrictions[0].Result);
                Assert.Equal(2, fieldRestriction.Restrictions[0].Values.Count);
                Assert.Equal(new[] { "Standard_ZRS", "Premium_LRS" }, fieldRestriction.Restrictions[0].Values, StringComparer.OrdinalIgnoreCase);

                armClient.ResourceGroups.Delete(ResourceGroupName);
            }
        }

        #endregion
    }
}
