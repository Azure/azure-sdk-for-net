// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.NetworkCloud.Mocking;
using Azure.ResourceManager.Resources;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public static partial class NetworkCloudExtensions
    {
        /// <summary>
        /// Get a list of bare metal machines in the provided subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/bareMetalMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BareMetalMachines_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBareMetalMachineResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableNetworkCloudSubscriptionResource.GetNetworkCloudBareMetalMachines(int?,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="NetworkCloudBareMetalMachineResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachinesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableNetworkCloudSubscriptionResource(subscriptionResource).GetNetworkCloudBareMetalMachinesAsync(cancellationToken);
        }

        /// <summary>
        /// Get a list of bare metal machines in the provided subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/bareMetalMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BareMetalMachines_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBareMetalMachineResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableNetworkCloudSubscriptionResource.GetNetworkCloudBareMetalMachines(int?,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="NetworkCloudBareMetalMachineResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachines(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableNetworkCloudSubscriptionResource(subscriptionResource).GetNetworkCloudBareMetalMachines(cancellationToken);
        }
    }
}
