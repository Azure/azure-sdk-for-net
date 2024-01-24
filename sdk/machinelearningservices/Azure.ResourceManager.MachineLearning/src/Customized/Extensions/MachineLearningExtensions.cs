// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.MachineLearning. </summary>
    public static partial class MachineLearningExtensions
    {
        /// <summary>
        /// Lists all the available machine learning workspaces under the specified subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MachineLearningServices/workspaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Workspaces_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningWorkspaceResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<MachineLearningWorkspaceResource> GetMachineLearningWorkspacesAsync(this SubscriptionResource subscriptionResource, string skip, CancellationToken cancellationToken)
        {
            return GetMockableMachineLearningSubscriptionResource(subscriptionResource).GetMachineLearningWorkspacesAsync(skip, cancellationToken);
        }

        /// <summary>
        /// Lists all the available machine learning workspaces under the specified subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MachineLearningServices/workspaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Workspaces_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningWorkspaceResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<MachineLearningWorkspaceResource> GetMachineLearningWorkspaces(this SubscriptionResource subscriptionResource, string skip, CancellationToken cancellationToken)
        {
            return GetMockableMachineLearningSubscriptionResource(subscriptionResource).GetMachineLearningWorkspaces(skip, cancellationToken);
        }
    }
}
