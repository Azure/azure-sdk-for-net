// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A class representing a collection of <see cref="DomainOwnershipIdentifierResource"/> and their operations.
    /// Each <see cref="DomainOwnershipIdentifierResource"/> in the collection will belong to the same instance of <see cref="AppServiceDomainResource"/>.
    /// To get a <see cref="DomainOwnershipIdentifierCollection"/> instance call the GetDomainOwnershipIdentifiers method from an instance of <see cref="AppServiceDomainResource"/>.
    /// </summary>
    [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DomainOwnershipIdentifierCollection : ArmCollection, IEnumerable<DomainOwnershipIdentifierResource>, IAsyncEnumerable<DomainOwnershipIdentifierResource>
    {
        /// <summary> Initializes a new instance of the <see cref="DomainOwnershipIdentifierCollection"/> class for mocking. </summary>
        protected DomainOwnershipIdentifierCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DomainOwnershipIdentifierCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DomainOwnershipIdentifierCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(DomainOwnershipIdentifierResource.ResourceType, out string domainOwnershipIdentifierDomainsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AppServiceDomainResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AppServiceDomainResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Creates an ownership identifier for a domain or updates identifier details for an existing identifier
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_CreateOrUpdateOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="data"> A JSON representation of the domain ownership properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DomainOwnershipIdentifierResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, DomainOwnershipIdentifierData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Creates an ownership identifier for a domain or updates identifier details for an existing identifier
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_CreateOrUpdateOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="data"> A JSON representation of the domain ownership properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DomainOwnershipIdentifierResource> CreateOrUpdate(WaitUntil waitUntil, string name, DomainOwnershipIdentifierData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get ownership identifier for domain
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_GetOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<DomainOwnershipIdentifierResource>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get ownership identifier for domain
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_GetOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<DomainOwnershipIdentifierResource> Get(string name, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Lists domain ownership identifiers.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_ListOwnershipIdentifiers</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DomainOwnershipIdentifierResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DomainOwnershipIdentifierResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Lists domain ownership identifiers.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_ListOwnershipIdentifiers</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DomainOwnershipIdentifierResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DomainOwnershipIdentifierResource> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_GetOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_GetOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_GetOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<NullableResponse<DomainOwnershipIdentifierResource>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_GetOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual NullableResponse<DomainOwnershipIdentifierResource> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        IEnumerator<DomainOwnershipIdentifierResource> IEnumerable<DomainOwnershipIdentifierResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DomainOwnershipIdentifierResource> IAsyncEnumerable<DomainOwnershipIdentifierResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
