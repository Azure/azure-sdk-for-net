// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Chaos.Mocking;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace Azure.ResourceManager.Chaos
{
    /// <summary>
    /// Partial class of customized ChaosExtensions
    /// </summary>
    public static partial class ChaosExtensions
    {
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableChaosSubscriptionResource.GetChaosTargetType(string, string, CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> String that represents a Location resource name. </param>
        /// <param name="targetTypeName"> String that represents a Target Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationName"/> or <paramref name="targetTypeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="locationName"/> or <paramref name="targetTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public static Response<ChaosTargetTypeResource> GetChaosTargetType(this SubscriptionResource subscriptionResource, string locationName, string targetTypeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableChaosSubscriptionResource(subscriptionResource).GetChaosTargetType(locationName, targetTypeName, cancellationToken);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableChaosSubscriptionResource.GetChaosTargetType(string, string, CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> String that represents a Location resource name. </param>
        /// <param name="targetTypeName"> String that represents a Target Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationName"/> or <paramref name="targetTypeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="locationName"/> or <paramref name="targetTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public static async Task<Response<ChaosTargetTypeResource>> GetChaosTargetTypeAsync(this SubscriptionResource subscriptionResource, string locationName, string targetTypeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableChaosSubscriptionResource(subscriptionResource).GetChaosTargetTypeAsync(locationName, targetTypeName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a collection of ChaosTargetTypeResources in the SubscriptionResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableChaosSubscriptionResource.GetChaosTargetTypes(string)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationName"> String that represents a Location resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="locationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="locationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of ChaosTargetTypeResources and their operations over a ChaosTargetTypeResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public static ChaosTargetTypeCollection GetChaosTargetTypes(this SubscriptionResource subscriptionResource, string locationName)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableChaosSubscriptionResource(subscriptionResource).GetChaosTargetTypes(locationName);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ChaosTargetTypeResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ChaosTargetTypeResource.CreateResourceIdentifier" /> to create a <see cref="ChaosTargetTypeResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableChaosArmClient.GetChaosTargetTypeResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ChaosTargetTypeResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public static ChaosTargetTypeResource GetChaosTargetTypeResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableChaosArmClient(client).GetChaosTargetTypeResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ChaosCapabilityTypeResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ChaosCapabilityTypeResource.CreateResourceIdentifier" /> to create a <see cref="ChaosCapabilityTypeResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableChaosArmClient.GetChaosCapabilityTypeResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ChaosCapabilityTypeResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public static ChaosCapabilityTypeResource GetChaosCapabilityTypeResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableChaosArmClient(client).GetChaosCapabilityTypeResource(id);
        }
    }
}
