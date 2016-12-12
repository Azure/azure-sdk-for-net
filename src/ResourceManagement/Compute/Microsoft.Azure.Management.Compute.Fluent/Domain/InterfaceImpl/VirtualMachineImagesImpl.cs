// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    internal partial class VirtualMachineImagesImpl
    {
        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">The selected Azure region.</param>
        /// <return>List of resources.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>.ListByRegion(Region region)
        {
            return this.ListByRegion(region) as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>;
        }

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">The name of an Azure region.</param>
        /// <return>List of resources.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>.ListByRegion(string regionName)
        {
            return this.ListByRegion(regionName) as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>;
        }

        /// <summary>
        /// Gets a virtual machine image.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="publisherName">Publisher name.</param>
        /// <param name="offerName">Offer name.</param>
        /// <param name="skuName">Sku name.</param>
        /// <param name="version">Version name.</param>
        /// <return>The virtual machine image.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImages.GetImage(Region region, string publisherName, string offerName, string skuName, string version)
        {
            return this.GetImage(region, publisherName, offerName, skuName, version) as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage;
        }

        /// <return>Entry point to virtual machine image publishers.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublishers Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImages.Publishers
        {
            get
            {
                return this.Publishers() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublishers;
            }
        }
    }
}