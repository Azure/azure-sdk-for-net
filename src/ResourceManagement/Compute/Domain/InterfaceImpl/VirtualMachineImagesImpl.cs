// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    internal partial class VirtualMachineImagesImpl 
    {
        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">The selected Azure region.</param>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>.ListByRegion(Region region)
        {
            return this.ListByRegion(region) as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>;
        }

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">The name of an Azure region.</param>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>.ListByRegion(string regionName)
        {
            return this.ListByRegion(regionName) as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">The selected Azure region.</param>
        /// <return>A representation of the deferred computation of this call, returning the requested resources.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>.ListByRegionAsync(Region region, CancellationToken cancellationToken)
        {
            return await this.ListByRegionAsync(region, cancellationToken) as IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>;
        }

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">The name of an Azure region.</param>
        /// <return>A representation of the deferred computation of this call, returning the requested resources.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>.ListByRegionAsync(string regionName, CancellationToken cancellationToken)
        {
            return await this.ListByRegionAsync(regionName, cancellationToken) as IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>;
        }

        /// <summary>
        /// Gets a virtual machine image.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="publisherName">Publisher name.</param>
        /// <param name="offerName">Offer name.</param>
        /// <param name="skuName">SKU name.</param>
        /// <param name="version">Version name.</param>
        /// <return>The virtual machine image.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImages.GetImage(Region region, string publisherName, string offerName, string skuName, string version)
        {
            return this.GetImage(region, publisherName, offerName, skuName, version) as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage;
        }

        /// <summary>
        /// Gets a virtual machine image.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="publisherName">Publisher name.</param>
        /// <param name="offerName">Offer name.</param>
        /// <param name="skuName">SKU name.</param>
        /// <param name="version">Version name.</param>
        /// <return>The virtual machine image.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImagesBeta.GetImage(string region, string publisherName, string offerName, string skuName, string version)
        {
            return this.GetImage(region, publisherName, offerName, skuName, version) as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage;
        }

        /// <summary>
        /// Gets entry point to virtual machine image publishers.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublishers Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImages.Publishers
        {
            get
            {
                return this.Publishers() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublishers;
            }
        }
    }
}