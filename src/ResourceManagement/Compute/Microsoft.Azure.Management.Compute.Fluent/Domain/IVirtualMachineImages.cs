// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Resource.Fluent.Core;

    /// <summary>
    /// Entry point to virtual machine image management API.
    /// </summary>
    public interface IVirtualMachineImages  :
        ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>
    {
        /// <return>Entry point to virtual machine image publishers.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublishers Publishers { get; }

        /// <summary>
        /// Gets a virtual machine image.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="publisherName">Publisher name.</param>
        /// <param name="offerName">Offer name.</param>
        /// <param name="skuName">Sku name.</param>
        /// <param name="version">Version name.</param>
        /// <return>The virtual machine image.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage GetImage(Region region, string publisherName, string offerName, string skuName, string version);
    }
}