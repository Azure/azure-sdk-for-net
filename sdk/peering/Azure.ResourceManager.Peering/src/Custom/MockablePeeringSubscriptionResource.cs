// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Peering;
using Azure.ResourceManager.Peering.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Peering.Mocking
{
    /// <summary> A class to add extension methods to <see cref="SubscriptionResource"/>. </summary>
    public partial class MockablePeeringSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Checks if the peering service provider is present within 1000 miles of customer's location
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.Peering/checkServiceProviderAvailability. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Peering_CheckServiceProviderAvailability. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-05-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<PeeringServiceProviderAvailability>> CheckPeeringServiceProviderAvailabilityAsync(CheckPeeringServiceProviderAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return null;
        }

        /// <summary>
        /// Checks if the peering service provider is present within 1000 miles of customer's location
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.Peering/checkServiceProviderAvailability. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Peering_CheckServiceProviderAvailability. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-05-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<PeeringServiceProviderAvailability> CheckPeeringServiceProviderAvailability(CheckPeeringServiceProviderAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return null;
        }
    }
}
