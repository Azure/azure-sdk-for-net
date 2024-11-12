// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

[assembly: CodeGenSuppressType("TenantExtensions")]
namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subscription.
    /// </summary>
    [CodeGenSuppress("TenantResource", typeof(ArmClient), typeof(TenantData))]
    [CodeGenSuppress("Get", typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAvailableLocations", typeof(CancellationToken))]
    [CodeGenSuppress("GetAvailableLocationsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetTenants")]
    [CodeGenSuppress("CreateResourceIdentifier")]
    [CodeGenSuppress("GetGenericResourceAsync", typeof(ResourceIdentifier), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetGenericResource", typeof(ResourceIdentifier), typeof(string), typeof(CancellationToken))]
    // [CodeGenSuppress("_tenantsRestClient")] // TODO: not working for private member
    public partial class TenantResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref = "TenantResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        internal TenantResource(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "TenantResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal TenantResource(ArmClient client, TenantData data) : this(client, ResourceIdentifier.Root)
        {
            HasData = true;
            _data = data;
        }

        /// <summary>
        /// Gets all resource providers for the tenant.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Providers_ListAtTenantScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> [This parameter is no longer supported.] The number of results to return. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantResourceProvider" /> that may take multiple service requests to iterate over. </returns>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is not supported by service and will be removed in a future release.", false)]
        public virtual AsyncPageable<TenantResourceProvider> GetTenantResourceProvidersAsync(int? top, string expand, CancellationToken cancellationToken = default)
        {
            return GetTenantResourceProvidersAsync(expand, cancellationToken);
        }

        /// <summary>
        /// Gets all resource providers for the tenant.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Providers_ListAtTenantScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> [This parameter is no longer supported.] The number of results to return. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantResourceProvider" /> that may take multiple service requests to iterate over. </returns>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is not supported by service and will be removed in a future release.", false)]
        public virtual Pageable<TenantResourceProvider> GetTenantResourceProviders(int? top, string expand, CancellationToken cancellationToken = default)
        {
            return GetTenantResourceProviders(expand, cancellationToken);
        }

        /// <summary>
        /// Gets a resource by ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Resources_GetById</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> is null. </exception>
        // api-version is defined as method parameter in spec but used as client parameter for Resources_GetById to keep the contract unchaged
        [ForwardsClientCalls]
        public virtual async Task<Response<GenericResource>> GetGenericResourceAsync(ResourceIdentifier resourceId, CancellationToken cancellationToken = default)
        {
            return await GetGenericResources().GetAsync(resourceId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a resource by ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Resources_GetById</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> is null. </exception>
        // api-version is defined as method parameter in spec but used as client parameter for Resources_GetById to keep the contract unchaged
        [ForwardsClientCalls]
        public virtual Response<GenericResource> GetGenericResource(ResourceIdentifier resourceId, CancellationToken cancellationToken = default)
        {
            return GetGenericResources().Get(resourceId, cancellationToken);
        }
    }
}
