// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace Azure.ResourceManager.Chaos.Mocking
{
    public partial class MockableChaosSubscriptionResource
    {
        /// <summary> Gets a collection of ChaosTargetTypeResources in the SubscriptionResource. </summary>
        /// <param name="locationName"> String that represents a Location resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="locationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of ChaosTargetTypeResources and their operations over a ChaosTargetTypeResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public virtual ChaosTargetTypeCollection GetChaosTargetTypes(string locationName)
        {
            return new ChaosTargetTypeCollection(Client, Id, locationName);
        }

        /// <summary>
        /// Get a Target Type resources for given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TargetTypes_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosTargetTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationName"> String that represents a Location resource name. </param>
        /// <param name="targetTypeName"> String that represents a Target Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locationName"/> or <paramref name="targetTypeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="locationName"/> or <paramref name="targetTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public virtual Response<ChaosTargetTypeResource> GetChaosTargetType(string locationName, string targetTypeName, CancellationToken cancellationToken = default)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            return GetChaosTargetTypes(locationName).Get(targetTypeName, cancellationToken);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        /// <summary>
        /// Get a Target Type resources for given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TargetTypes_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosTargetTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationName"> String that represents a Location resource name. </param>
        /// <param name="targetTypeName"> String that represents a Target Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locationName"/> or <paramref name="targetTypeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="locationName"/> or <paramref name="targetTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public virtual async Task<Response<ChaosTargetTypeResource>> GetChaosTargetTypeAsync(string locationName, string targetTypeName, CancellationToken cancellationToken = default)
        {
            return await GetChaosTargetTypes(locationName).GetAsync(targetTypeName, cancellationToken).ConfigureAwait(false);
        }
    }
}
