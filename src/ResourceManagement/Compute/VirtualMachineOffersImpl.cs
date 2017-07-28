// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for VirtualMachineOffers.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVPZmZlcnNJbXBs
    internal partial class VirtualMachineOffersImpl :
        ReadableWrappers<IVirtualMachineOffer, VirtualMachineOfferImpl, VirtualMachineImageResourceInner>,
        IVirtualMachineOffers
    {
        private IVirtualMachineImagesOperations innerCollection;
        private IVirtualMachinePublisher publisher;

        ///GENMHASH:F79343A72AA4295A5E1D16B5530DD18B:34FB4BF5848191FF7F26FBB50A9F1E95
        internal VirtualMachineOffersImpl(IVirtualMachineImagesOperations innerCollection, IVirtualMachinePublisher publisher)
        {
            this.publisher = publisher;
            this.innerCollection = innerCollection;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:CF6916AB824B8B57D0C4089778CE6C55
        public IEnumerable<IVirtualMachineOffer> List()
        {
            return WrapList(Extensions.Synchronize(() => innerCollection.ListOffersAsync(publisher.Region.Name, publisher.Name)));
        }

        public async Task<IPagedCollection<IVirtualMachineOffer>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IVirtualMachineOffer, VirtualMachineImageResourceInner>.LoadPage(
                async (cancellation) => await innerCollection.ListOffersAsync(publisher.Region.Name, publisher.Name, cancellation),
                WrapModel, cancellationToken);
        }

        ///GENMHASH:D48BEF4BAC4C0112B6930D731FFC59BD:C7F4803C2EE7A4D67291D41041502664
        protected override IVirtualMachineOffer WrapModel(VirtualMachineImageResourceInner inner)
        {
            return new VirtualMachineOfferImpl(publisher, inner.Name, innerCollection);
        }
    }
}
