// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to DNS zone management API in Azure.
    /// </summary>
    public interface IDnsZones  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<DnsZone.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Dns.Fluent.IDnsZoneManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Dns.Fluent.IZonesOperations>
    {
        /// <summary>
        /// Asynchronously deletes the zone from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="zoneName">The name of the zone.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        Task DeleteByResourceGroupNameAsync(string resourceGroupName, string zoneName, string eTagValue, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the zone from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="zoneName">The name of the zone.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        void DeleteByResourceGroupName(string resourceGroupName, string zoneName, string eTagValue);

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        void DeleteById(string id, string eTagValue);

        /// <summary>
        /// Asynchronously delete the zone from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <param name="eTagValue">The ETag value to set on IfMatch header for concurrency protection.</param>
        /// <return>A representation of the deferred computation this delete call.</return>
        Task DeleteByIdAsync(string id, string eTagValue, CancellationToken cancellationToken = default(CancellationToken));
    }
}