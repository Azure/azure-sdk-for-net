// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    internal partial class VirtualMachineSkuImpl : IVirtualMachineSku
    {
        private IVirtualMachineOffer offer;
        private IVirtualMachineImagesInSku imagesInSku;

        internal VirtualMachineSkuImpl(IVirtualMachineOffer offer, string skuName, IVirtualMachineImagesOperations client)
        {
            this.offer = offer;
            Name = skuName;
            imagesInSku = new VirtualMachineImagesInSkuImpl(this, client);
        }

        public string Name
        {
            get; private set;
        }

        public Region Region
        {
            get
            {
                return offer.Region;
            }
        }

        public IVirtualMachineImagesInSku Images
        {
            get
            {
                return imagesInSku;
            }
        }

        public IVirtualMachineOffer Offer
        {
            get
            {
                return offer;
            }
        }

        public IVirtualMachinePublisher Publisher
        {
            get
            {
                return offer.Publisher;
            }
        }
    }
}
