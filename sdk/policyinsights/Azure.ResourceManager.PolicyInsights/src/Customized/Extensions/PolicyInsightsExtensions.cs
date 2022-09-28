// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.PolicyInsights.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PolicyInsights
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.PolicyInsights. </summary>
    [CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyEvents", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyEventsAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyEvents", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyEventsAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEvents", typeof(ResourceGroupResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEventsAsync", typeof(ResourceGroupResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEvents", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEventsAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStates", typeof(ResourceGroupResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStatesAsync", typeof(ResourceGroupResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForPolicyDefinitionPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForPolicyDefinitionPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForPolicySetDefinitionPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForPolicySetDefinitionPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForResourceGroupLevelPolicyAssignmentPolicyStates", typeof(ResourceGroupResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForResourceGroupLevelPolicyAssignmentPolicyStatesAsync", typeof(ResourceGroupResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForSubscriptionLevelPolicyAssignmentPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForSubscriptionLevelPolicyAssignmentPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    public static partial class PolicyInsightsExtensions
    {
        #region SubscriptionPolicySetDefinitionPolicyInsightsResource
        /// <summary>
        /// Gets an object representing a <see cref="SubscriptionPolicySetDefinitionPolicyInsightsResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SubscriptionPolicySetDefinitionPolicyInsightsResource.CreateResourceIdentifier" /> to create a <see cref="SubscriptionPolicySetDefinitionPolicyInsightsResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SubscriptionPolicySetDefinitionPolicyInsightsResource" /> object. </returns>
        public static SubscriptionPolicySetDefinitionPolicyInsightsResource GetSubscriptionPolicySetDefinitionPolicyInsightsResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                SubscriptionPolicySetDefinitionPolicyInsightsResource.ValidateResourceId(id);
                return new SubscriptionPolicySetDefinitionPolicyInsightsResource(client, id);
            }
            );
        }
        #endregion

        #region SubscriptionPolicyDefinitionPolicyInsightsResource
        /// <summary>
        /// Gets an object representing a <see cref="SubscriptionPolicyDefinitionPolicyInsightsResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SubscriptionPolicyDefinitionPolicyInsightsResource.CreateResourceIdentifier" /> to create a <see cref="SubscriptionPolicyDefinitionPolicyInsightsResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SubscriptionPolicyDefinitionPolicyInsightsResource" /> object. </returns>
        public static SubscriptionPolicyDefinitionPolicyInsightsResource GetSubscriptionPolicyDefinitionPolicyInsightsResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                SubscriptionPolicyDefinitionPolicyInsightsResource.ValidateResourceId(id);
                return new SubscriptionPolicyDefinitionPolicyInsightsResource(client, id);
            }
            );
        }
        #endregion

        #region SubscriptionPolicyAssignmentPolicyInsightsResource
        /// <summary>
        /// Gets an object representing a <see cref="SubscriptionPolicyAssignmentPolicyInsightsResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SubscriptionPolicyAssignmentPolicyInsightsResource.CreateResourceIdentifier" /> to create a <see cref="SubscriptionPolicyAssignmentPolicyInsightsResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SubscriptionPolicyAssignmentPolicyInsightsResource" /> object. </returns>
        public static SubscriptionPolicyAssignmentPolicyInsightsResource GetSubscriptionPolicyAssignmentPolicyInsightsResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                SubscriptionPolicyAssignmentPolicyInsightsResource.ValidateResourceId(id);
                return new SubscriptionPolicyAssignmentPolicyInsightsResource(client, id);
            }
            );
        }
        #endregion

        #region ResourceGroupPolicyAssignmentPolicyInsightsResource
        /// <summary>
        /// Gets an object representing a <see cref="ResourceGroupPolicyAssignmentPolicyInsightsResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ResourceGroupPolicyAssignmentPolicyInsightsResource.CreateResourceIdentifier" /> to create a <see cref="ResourceGroupPolicyAssignmentPolicyInsightsResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResourceGroupPolicyAssignmentPolicyInsightsResource" /> object. </returns>
        public static ResourceGroupPolicyAssignmentPolicyInsightsResource GetResourceGroupPolicyAssignmentPolicyInsightsResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ResourceGroupPolicyAssignmentPolicyInsightsResource.ValidateResourceId(id);
                return new ResourceGroupPolicyAssignmentPolicyInsightsResource(client, id);
            }
            );
        }
        #endregion
    }
}
