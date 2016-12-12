// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    internal partial class VirtualMachinePublisherImpl
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>The virtual machine image extensions from this publisher.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher.ExtensionTypes
        {
            get
            {
                return this.ExtensionTypes() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageTypes;
            }
        }

        /// <return>The offers from this publisher.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffers Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher.Offers
        {
            get
            {
                return this.Offers() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffers;
            }
        }

        /// <return>The region where virtual machine images from this publisher are available.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.Resource.Fluent.Core.Region;
            }
        }
    }
}