// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// The implementation for VirtualMachineImages.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVJbWFnZXNJbXBs
    internal partial class VirtualMachineImagesImpl :
        IVirtualMachineImages
    {
        private IVirtualMachinePublishers publishers;
        private IVirtualMachineImagesOperations client;
        ///GENMHASH:ACE7DB5EC4859832FCAB3D9EEA5A3085:F45A4D9C421A9195D289FED2F4D6740A
        internal VirtualMachineImagesImpl(IVirtualMachinePublishers publishers, IVirtualMachineImagesOperations client)
        {
            this.publishers = publishers;
            this.client = client;
        }

        ///GENMHASH:A5C3605D6EBCBFB12152B28DBA2D191F:78A0104FC3E1707F4CA255D832A69FFD
        public IVirtualMachineImage GetImage(Region region, string publisherName, string offerName, string skuName, string version)
        {
            VirtualMachineImageInner innerImage = this.client.Get(region.Name,
                publisherName, offerName, skuName, version);
            return new VirtualMachineImageImpl(region, publisherName, offerName, skuName, version, innerImage);
        }

        ///GENMHASH:BA2FEDDF9D78BF55786D81F6C85E907C:630A1B72E2D4ABD6B8949063CF2A1867
        public PagedList<IVirtualMachineImage> ListByRegion(Region region)
        {
            return ListByRegion(region.Name);
        }

        ///GENMHASH:360BB74037893879A730ED7ED0A3938A:1493616B491D8F4B92FA36631D115300
        public PagedList<IVirtualMachineImage> ListByRegion(string regionName)
        {
            PagedList<IVirtualMachinePublisher> publishers = Publishers().ListByRegion(regionName);

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

        ///GENMHASH:0BEBF248F53E3703454D841A5CB0C8BD:F1262C25E062855DE7A22FF21A820919
        public IVirtualMachinePublishers Publishers()
        {
            return publishers;
        }
    }
}
