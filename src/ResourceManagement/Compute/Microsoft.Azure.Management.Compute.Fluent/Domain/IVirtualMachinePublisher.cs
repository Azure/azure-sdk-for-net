// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Represents a virtual machine image publisher.
    /// </summary>
    public interface IVirtualMachinePublisher :
        IHasName
    {
        /// <return>The offers from this publisher.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffers Offers { get; }

        /// <return>The virtual machine image extensions from this publisher.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageTypes ExtensionTypes { get; }

        /// <return>The region where virtual machine images from this publisher are available.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Region { get; }
    }
}