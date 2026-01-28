// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Chaos
{
    /// <summary>
    /// A class representing a collection of <see cref="ChaosCapabilityTypeResource"/> and their operations.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `ChaosCapabilityMetadataCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ChaosCapabilityTypeCollection : ArmCollection, IEnumerable<ChaosCapabilityTypeResource>, IAsyncEnumerable<ChaosCapabilityTypeResource>
    {
        /// <summary> Initializes a new instance of the <see cref="ChaosCapabilityTypeCollection"/> class for mocking. </summary>
        protected ChaosCapabilityTypeCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ChaosCapabilityTypeCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ChaosCapabilityTypeCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(ChaosCapabilityTypeResource.ResourceType, out string chaosCapabilityTypeCapabilityTypesApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ChaosTargetTypeResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ChaosTargetTypeResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get a Capability Type resource for given Target Type and location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}/capabilityTypes/{capabilityTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CapabilityTypes_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosCapabilityTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityTypeName"> String that represents a Capability Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityTypeName"/> is null. </exception>
        public virtual Task<Response<ChaosCapabilityTypeResource>> GetAsync(string capabilityTypeName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get a Capability Type resource for given Target Type and location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}/capabilityTypes/{capabilityTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CapabilityTypes_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosCapabilityTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityTypeName"> String that represents a Capability Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityTypeName"/> is null. </exception>
        public virtual Response<ChaosCapabilityTypeResource> Get(string capabilityTypeName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get a list of Capability Type resources for given Target Type and location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}/capabilityTypes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CapabilityTypes_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosCapabilityTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="continuationToken"> String that sets the continuation token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ChaosCapabilityTypeResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ChaosCapabilityTypeResource> GetAllAsync(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get a list of Capability Type resources for given Target Type and location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}/capabilityTypes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CapabilityTypes_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosCapabilityTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="continuationToken"> String that sets the continuation token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ChaosCapabilityTypeResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ChaosCapabilityTypeResource> GetAll(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}/capabilityTypes/{capabilityTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CapabilityTypes_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosCapabilityTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityTypeName"> String that represents a Capability Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityTypeName"/> is null. </exception>
        public virtual Task<Response<bool>> ExistsAsync(string capabilityTypeName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}/capabilityTypes/{capabilityTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CapabilityTypes_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosCapabilityTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityTypeName"> String that represents a Capability Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityTypeName"/> is null. </exception>
        public virtual Response<bool> Exists(string capabilityTypeName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}/capabilityTypes/{capabilityTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CapabilityTypes_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosCapabilityTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityTypeName"> String that represents a Capability Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityTypeName"/> is null. </exception>
        public virtual Task<NullableResponse<ChaosCapabilityTypeResource>> GetIfExistsAsync(string capabilityTypeName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}/capabilityTypes/{capabilityTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CapabilityTypes_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosCapabilityTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityTypeName"> String that represents a Capability Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityTypeName"/> is null. </exception>
        public virtual NullableResponse<ChaosCapabilityTypeResource> GetIfExists(string capabilityTypeName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        IEnumerator<ChaosCapabilityTypeResource> IEnumerable<ChaosCapabilityTypeResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ChaosCapabilityTypeResource> IAsyncEnumerable<ChaosCapabilityTypeResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
