// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class VirtualMachinePublisherImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the virtual machine image extensions from this publisher.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher.ExtensionTypes
        {
            get
            {
                return this.ExtensionTypes() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageTypes;
            }
        }

        /// <summary>
        /// Gets the offers from this publisher.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffers Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher.Offers
        {
            get
            {
                return this.Offers() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineOffers;
            }
        }

        /// <summary>
        /// Gets the region where virtual machine images from this publisher are available.
        /// </summary>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.Resource.Fluent.Core.Region;
            }
        }
    }
}