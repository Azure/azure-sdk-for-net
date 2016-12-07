// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    internal partial class VirtualMachineSkusImpl : ReadableWrappers<IVirtualMachineSku, VirtualMachineSkuImpl, VirtualMachineImageResourceInner>, IVirtualMachineSkus
    {
        private IVirtualMachineImagesOperations innerCollection;
        private IVirtualMachineOffer offer;

        internal VirtualMachineSkusImpl(IVirtualMachineOffer offer, IVirtualMachineImagesOperations innerCollection)
        {
            this.offer = offer;
            this.innerCollection = innerCollection;
        }

        public PagedList<IVirtualMachineSku> List()
        {
            IEnumerable<VirtualMachineImageResourceInner> innerSkus = innerCollection.ListSkus(offer.Region.Name, offer.Publisher.Name, offer.Name);
            var pagedList = new PagedList<VirtualMachineImageResourceInner>(innerSkus);
            return WrapList(pagedList);
        }

        protected override IVirtualMachineSku WrapModel(VirtualMachineImageResourceInner inner)
        {
            return new VirtualMachineSkuImpl(this.offer, inner.Name, innerCollection);
        }
    }
}
