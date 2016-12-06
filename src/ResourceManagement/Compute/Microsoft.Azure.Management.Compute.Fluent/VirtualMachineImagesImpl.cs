// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    internal partial class VirtualMachineImagesImpl : IVirtualMachineImages
    {
        private IVirtualMachinePublishers publishers;
        private IVirtualMachineImagesOperations client;

        internal VirtualMachineImagesImpl(IVirtualMachinePublishers publishers, IVirtualMachineImagesOperations client)
        {
            this.publishers = publishers;
            this.client = client;
        }

        public IVirtualMachineImage GetImage(Region region, string publisherName, string offerName, string skuName, string version)
        {
            VirtualMachineImageInner innerImage = this.client.Get(region.Name,
                publisherName, offerName, skuName, version);
            return new VirtualMachineImageImpl(region, publisherName, offerName, skuName, version, innerImage);
        }
        
        public PagedList<IVirtualMachineImage> ListByRegion(Region region)
        {
            return ListByRegion(region.Name);
        }

        public PagedList<IVirtualMachineImage> ListByRegion(string regionName)
        {
            PagedList<IVirtualMachinePublisher> publishers = Publishers.ListByRegion(regionName);

            PagedList<IVirtualMachineOffer> offers = new ChildListFlattener<IVirtualMachinePublisher, IVirtualMachineOffer>(publishers, 
                (IVirtualMachinePublisher publisher) =>
                    {
                        return publisher.Offers.List();
                    }).Flatten();

            PagedList<IVirtualMachineSku> skus = new ChildListFlattener<IVirtualMachineOffer, IVirtualMachineSku>(offers,
                (IVirtualMachineOffer offer) =>
                    {
                        return offer.Skus.List();
                    }).Flatten();

            PagedList<IVirtualMachineImage> images = new ChildListFlattener<IVirtualMachineSku, IVirtualMachineImage>(skus,
                (IVirtualMachineSku sku) =>
                    {
                        return sku.Images.List();
                    }).Flatten();

            return images;
        }

        public IVirtualMachinePublishers Publishers
        {
            get
            {
                return publishers;
            }
        }
    }
}
