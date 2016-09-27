// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.V2.Compute
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
                innerCollection.ListOffers(EnumNameAttribute.GetName(publisher.Region), publisher.Name);
            var pagedList = new PagedList<VirtualMachineImageResourceInner>(innerOffers);
            return WrapList(pagedList);
        }

        protected override IVirtualMachineOffer WrapModel(VirtualMachineImageResourceInner inner)
        {
            return new VirtualMachineOfferImpl(publisher, inner.Name, innerCollection);
        }
    }
}