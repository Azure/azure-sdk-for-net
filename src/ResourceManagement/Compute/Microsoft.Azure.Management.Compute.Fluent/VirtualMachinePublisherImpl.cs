// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    internal partial class VirtualMachinePublisherImpl : IVirtualMachinePublisher
    {
        private IVirtualMachineOffers offers;
        private IVirtualMachineExtensionImageTypes extensionTypes;

        internal VirtualMachinePublisherImpl(Region location, 
            string publisher, 
            IVirtualMachineImagesOperations vmImagesClient,
            IVirtualMachineExtensionImagesOperations vmExtensionImagesClient)
        {
            Region = location;
            Name = publisher;
            offers = new VirtualMachineOffersImpl(vmImagesClient, this);
            extensionTypes = new VirtualMachineExtensionImageTypesImpl(vmExtensionImagesClient, this);
        }

        public string Name
        {
            get; private set;
        }

        public Region Region
        {
            get; private set;
        }

        public IVirtualMachineOffers Offers
        {
            get
            {
                return offers;
            }
        }

        public IVirtualMachineExtensionImageTypes ExtensionTypes
        {
            get
            {
                return extensionTypes;
            }
        }
    }
}
