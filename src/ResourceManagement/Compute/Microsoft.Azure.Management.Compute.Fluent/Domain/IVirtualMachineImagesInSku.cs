// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to virtual machine sku images.
    /// </summary>
    public interface IVirtualMachineImagesInSku  :
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage>
    {
    }
}