// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    internal partial class VirtualMachineOffersImpl :
        ReadableWrappers<IVirtualMachineOffer, VirtualMachineOfferImpl, VirtualMachineImageResourceInner>,
        IVirtualMachineOffers
    {
        private IVirtualMachineImagesOperations innerCollection;
        private IVirtualMachinePublisher publisher;

        internal VirtualMachineOffersImpl(IVirtualMachineImagesOperations innerCollection, IVirtualMachinePublisher publisher)
        {
            this.publisher = publisher;
            this.innerCollection = innerCollection;
        }

        public PagedList<IVirtualMachineOffer> List()
        {
            IEnumerable<VirtualMachineImageResourceInner> innerOffers =
                innerCollection.ListOffers(publisher.Region.Name, publisher.Name);
            var pagedList = new PagedList<VirtualMachineImageResourceInner>(innerOffers);
            return WrapList(pagedList);
        }

        protected override IVirtualMachineOffer WrapModel(VirtualMachineImageResourceInner inner)
        {
            return new VirtualMachineOfferImpl(publisher, inner.Name, innerCollection);
        }
    }
}