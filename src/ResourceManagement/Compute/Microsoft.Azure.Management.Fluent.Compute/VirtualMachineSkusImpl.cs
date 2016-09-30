// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Fluent.Compute
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
            IEnumerable<VirtualMachineImageResourceInner> innerSkus = innerCollection.ListSkus(EnumNameAttribute.GetName(offer.Region), offer.Publisher().Name, offer.Name);
            var pagedList = new PagedList<VirtualMachineImageResourceInner>(innerSkus);
            return WrapList(pagedList);
        }

        protected override IVirtualMachineSku WrapModel(VirtualMachineImageResourceInner inner)
        {
            return new VirtualMachineSkuImpl(this.offer, inner.Name, innerCollection);
        }
    }
}
