// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.GuestConfiguration.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.GuestConfiguration
{
    public static partial class GuestConfigurationExtensions
    {
        // --- GetAllGuestConfigurationAssignmentData methods ---

        /// <summary> List all guest configuration assignments for a resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableGuestConfigurationResourceGroupResource(resourceGroupResource).GetAllGuestConfigurationAssignmentData(cancellationToken);
        }

        /// <summary> List all guest configuration assignments for a resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableGuestConfigurationResourceGroupResource(resourceGroupResource).GetAllGuestConfigurationAssignmentDataAsync(cancellationToken);
        }

        /// <summary> List all guest configuration assignments for a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableGuestConfigurationSubscriptionResource(subscriptionResource).GetAllGuestConfigurationAssignmentData(cancellationToken);
        }

        /// <summary> List all guest configuration assignments for a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableGuestConfigurationSubscriptionResource(subscriptionResource).GetAllGuestConfigurationAssignmentDataAsync(cancellationToken);
        }

        // backward compatible for generator bug fixes
        /// <summary>
        /// List all guest configuration assignments for a resource group.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableGuestConfigurationResourceGroupResource.RGListAsync(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> A collection of <see cref="GuestConfigurationVmAssignmentResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<GuestConfigurationVmAssignmentResource> RGListAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableGuestConfigurationResourceGroupResource(resourceGroupResource).RGListAsync(cancellationToken);
        }

        /// <summary>
        /// List all guest configuration assignments for a resource group.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableGuestConfigurationResourceGroupResource.RGList(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> A collection of <see cref="GuestConfigurationVmAssignmentResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<GuestConfigurationVmAssignmentResource> RGList(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableGuestConfigurationResourceGroupResource(resourceGroupResource).RGList(cancellationToken);
        }
    }
}
