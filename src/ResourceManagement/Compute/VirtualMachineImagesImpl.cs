// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

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
            VirtualMachineImageInner innerImage = Extensions.Synchronize(() => this.client.GetAsync(
                region.Name, publisherName, offerName, skuName, version));
            if (innerImage == null)
            {
                return null;
            }
            return new VirtualMachineImageImpl(region, publisherName, offerName, skuName, version, innerImage);
        }

        ///GENMHASH:A5C3605D6EBCBFB12152B28DBA2D191F:78A0104FC3E1707F4CA255D832A69FFD
        public IVirtualMachineImage GetImage(string region, string publisherName, string offerName, string skuName, string version)
        {
            VirtualMachineImageInner innerImage = Extensions.Synchronize(() => this.client.GetAsync(region,
                publisherName, offerName, skuName, version));
            if (innerImage == null)
            {
                return null;
            }
            return new VirtualMachineImageImpl(Region.Create(region), publisherName, offerName, skuName, version, innerImage);
        }

        ///GENMHASH:BA2FEDDF9D78BF55786D81F6C85E907C:630A1B72E2D4ABD6B8949063CF2A1867
        public IEnumerable<IVirtualMachineImage> ListByRegion(Region region)
        {
            return ListByRegion(region.Name);
        }

        ///GENMHASH:360BB74037893879A730ED7ED0A3938A:1493616B491D8F4B92FA36631D115300
        public IEnumerable<IVirtualMachineImage> ListByRegion(string regionName)
        {
            return Publishers().ListByRegion(regionName)
                    .SelectMany(publisher => publisher.Offers
                                                      .List()
                                                      .SelectMany(offer => offer.Skus
                                                                                .List()
                                                                                .SelectMany(sku => sku.Images.List())));
        }

        ///GENMHASH:2ED29FF482F2137640A1CA66925828A8:680F32185EB936C7B18624E07C3721F4
        public async Task<IPagedCollection<IVirtualMachineImage>> ListByRegionAsync(string region, CancellationToken cancellationToken)
        {
            return await PagedCollection<IVirtualMachineImage, IVirtualMachineImage>
                 .LoadPage(async (cancellationToken1) =>
                 {
                     var publisherCollection = await Publishers().ListByRegionAsync(region, cancellationToken);
                     var collectionOfOfferCollection = await Task.WhenAll(publisherCollection
                         .Select(async (publisher) => await publisher.Offers.ListAsync(true, cancellationToken)));
                     var collectionOfSkuCollection = await Task.WhenAll(collectionOfOfferCollection
                         .SelectMany(offerCollection => offerCollection.Select(async (offer) => await offer.Skus.ListAsync(true, cancellationToken))));
                     var collectionOfimageCollection = await Task.WhenAll(collectionOfSkuCollection
                         .SelectMany(skuCollection => skuCollection.Select(async (sku) => await sku.Images.ListAsync(true, cancellationToken))));
                     var images = collectionOfimageCollection.SelectMany(imageCollection => imageCollection.Select(image => image));
                     return images;
                 },
                 image => image,
                 cancellationToken);
        }

        ///GENMHASH:271CC39CE723B6FD3D7CCA7471D4B201:039795D842B96323D94D260F3FF83299
        public async Task<IPagedCollection<IVirtualMachineImage>> ListByRegionAsync(Region region, CancellationToken cancellationToken)
        {
            return await ListByRegionAsync(region.Name, cancellationToken);
        }

        ///GENMHASH:0BEBF248F53E3703454D841A5CB0C8BD:F1262C25E062855DE7A22FF21A820919
        public IVirtualMachinePublishers Publishers()
        {
            return publishers;
        }
    }
}
