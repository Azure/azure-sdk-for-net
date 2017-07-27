// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to virtual machine image management API.
    /// </summary>
    public interface IVirtualMachineImagesBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets a virtual machine image.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="publisherName">Publisher name.</param>
        /// <param name="offerName">Offer name.</param>
        /// <param name="skuName">SKU name.</param>
        /// <param name="version">Version name.</param>
        /// <return>The virtual machine image.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage GetImage(string region, string publisherName, string offerName, string skuName, string version);
    }
}