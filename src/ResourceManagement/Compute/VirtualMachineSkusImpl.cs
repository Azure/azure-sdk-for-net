// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// The implementation for VirtualMachineSkus.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTa3VzSW1wbA==
    internal partial class VirtualMachineSkusImpl : ReadableWrappers<
        IVirtualMachineSku,
        VirtualMachineSkuImpl,
        VirtualMachineImageResourceInner>, IVirtualMachineSkus
    {
        private IVirtualMachineImagesOperations innerCollection;
        private IVirtualMachineOffer offer;

        ///GENMHASH:ED50A527AC3F81E2B0A03610C839FCF2:406B910E6447842DDB38F6122DEB7673
        internal VirtualMachineSkusImpl(IVirtualMachineOffer offer, IVirtualMachineImagesOperations innerCollection)
        {
            this.offer = offer;
            this.innerCollection = innerCollection;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:F06F4A28DDFE89624259B7BA06AB2A0E
        public IEnumerable<IVirtualMachineSku> List()
        {
            return WrapList(Extensions.Synchronize(() => innerCollection.ListSkusAsync(offer.Region.Name, offer.Publisher.Name, offer.Name)));
        }

        public async Task<IPagedCollection<IVirtualMachineSku>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IVirtualMachineSku, VirtualMachineImageResourceInner>.LoadPage(
                async (cancellation) => await innerCollection.ListSkusAsync(offer.Region.Name, offer.Publisher.Name, offer.Name, cancellation),
                WrapModel, cancellationToken);
        }

        ///GENMHASH:D48BEF4BAC4C0112B6930D731FFC59BD:3D3DBF6D2E250B46C52C216A27E376BA
        protected override IVirtualMachineSku WrapModel(VirtualMachineImageResourceInner inner)
        {
            return new VirtualMachineSkuImpl(this.offer, inner.Name, innerCollection);
        }
    }
}
