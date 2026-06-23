// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A Class representing a DomainOwnershipIdentifier along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="DomainOwnershipIdentifierResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetDomainOwnershipIdentifierResource method.
    /// Otherwise you can get one from its parent resource <see cref="AppServiceDomainResource"/> using the GetDomainOwnershipIdentifier method.
    /// </summary>
    [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DomainOwnershipIdentifierResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DomainOwnershipIdentifierResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="domainName"> The domainName. </param>
        /// <param name="name"> The name. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName, string name)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly DomainOwnershipIdentifierData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.DomainRegistration/domains/domainOwnershipIdentifiers";

        /// <summary> Initializes a new instance of the <see cref="DomainOwnershipIdentifierResource"/> class for mocking. </summary>
        protected DomainOwnershipIdentifierResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DomainOwnershipIdentifierResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DomainOwnershipIdentifierResource(ArmClient client, DomainOwnershipIdentifierData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DomainOwnershipIdentifierResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DomainOwnershipIdentifierResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(ResourceType, out string domainOwnershipIdentifierDomainsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DomainOwnershipIdentifierData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DomainOwnershipIdentifierResource>> GetAsync(CancellationToken cancellationToken = default)
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DomainOwnershipIdentifierResource> Get(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Delete ownership identifier for domain
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_DeleteOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Delete ownership identifier for domain
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DomainRegistration/domains/{domainName}/domainOwnershipIdentifiers/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Domains_DeleteOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
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
        /// <description>Domains_UpdateOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> A JSON representation of the domain ownership properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<DomainOwnershipIdentifierResource>> UpdateAsync(DomainOwnershipIdentifierData data, CancellationToken cancellationToken = default)
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
        /// <description>Domains_UpdateOwnershipIdentifier</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DomainOwnershipIdentifierResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> A JSON representation of the domain ownership properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<DomainOwnershipIdentifierResource> Update(DomainOwnershipIdentifierData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace. Please use the same API from that namespace.");
        }
    }
}
