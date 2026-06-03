// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.OperationalInsights.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.OperationalInsights
{
    // Backward-compat justification: the GA SDK exposed deleted-workspace list operations as GetDeletedWorkspaces extension methods.
    public static partial class OperationalInsightsExtensions
    {
        /// <summary> Gets recently deleted workspaces in a resource group, available for recovery. </summary>
        public static AsyncPageable<OperationalInsightsWorkspaceResource> GetDeletedWorkspacesAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
            => resourceGroupResource.GetByResourceGroupAsync(cancellationToken);

        /// <summary> Gets recently deleted workspaces in a resource group, available for recovery. </summary>
        public static Pageable<OperationalInsightsWorkspaceResource> GetDeletedWorkspaces(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
            => resourceGroupResource.GetByResourceGroup(cancellationToken);

        /// <summary> Gets recently deleted workspaces in a subscription, available for recovery. </summary>
        public static AsyncPageable<OperationalInsightsWorkspaceResource> GetDeletedWorkspacesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => subscriptionResource.GetAllAsync(cancellationToken);

        /// <summary> Gets recently deleted workspaces in a subscription, available for recovery. </summary>
        public static Pageable<OperationalInsightsWorkspaceResource> GetDeletedWorkspaces(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => subscriptionResource.GetAll(cancellationToken);
    }
}
