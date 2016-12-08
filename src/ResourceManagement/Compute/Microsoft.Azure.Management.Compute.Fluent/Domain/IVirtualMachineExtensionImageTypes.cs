// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to virtual machine image extension types.
    /// </summary>
    public interface IVirtualMachineExtensionImageTypes :
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType>
    {
    }
}