// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.OperationalInsights.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.OperationalInsights
{
    // Backward-compat justification: the GA SDK exposed deleted-workspace list operations as GetDeletedWorkspaces extension methods.
    public static partial class OperationalInsightsExtensions
    {
        /// <summary>
        /// Gets recently deleted workspaces in a resource group, available for recovery.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/deletedWorkspaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeletedWorkspaces_ListByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-10-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableOperationalInsightsResourceGroupResource.GetDeletedWorkspaces(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="OperationalInsightsWorkspaceResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<OperationalInsightsWorkspaceResource> GetDeletedWorkspacesAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableOperationalInsightsResourceGroupResource(resourceGroupResource).GetDeletedWorkspacesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets recently deleted workspaces in a resource group, available for recovery.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/deletedWorkspaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeletedWorkspaces_ListByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-10-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableOperationalInsightsResourceGroupResource.GetDeletedWorkspaces(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> A collection of <see cref="OperationalInsightsWorkspaceResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<OperationalInsightsWorkspaceResource> GetDeletedWorkspaces(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableOperationalInsightsResourceGroupResource(resourceGroupResource).GetDeletedWorkspaces(cancellationToken);
        }

        /// <summary>
        /// Gets recently deleted workspaces in a subscription, available for recovery.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.OperationalInsights/deletedWorkspaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeletedWorkspaces_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-10-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableOperationalInsightsSubscriptionResource.GetDeletedWorkspaces(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="OperationalInsightsWorkspaceResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<OperationalInsightsWorkspaceResource> GetDeletedWorkspacesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableOperationalInsightsSubscriptionResource(subscriptionResource).GetDeletedWorkspacesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets recently deleted workspaces in a subscription, available for recovery.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.OperationalInsights/deletedWorkspaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeletedWorkspaces_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-10-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableOperationalInsightsSubscriptionResource.GetDeletedWorkspaces(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="OperationalInsightsWorkspaceResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<OperationalInsightsWorkspaceResource> GetDeletedWorkspaces(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableOperationalInsightsSubscriptionResource(subscriptionResource).GetDeletedWorkspaces(cancellationToken);
        }
    }
}
