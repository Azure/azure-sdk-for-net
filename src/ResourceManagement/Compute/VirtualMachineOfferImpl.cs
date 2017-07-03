// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// The implementation for VirtualMachineOffer.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVPZmZlckltcGw=
    internal partial class VirtualMachineOfferImpl :
        IVirtualMachineOffer
    {
        private IVirtualMachinePublisher publisher;
        private string offerName;
        private IVirtualMachineSkus skus;

        ///GENMHASH:2EFBA576A3195EDB2F27440330CF3856:B4E2AB9962FF6934486C326E46FDA9B8
        internal VirtualMachineOfferImpl(IVirtualMachinePublisher publisher, string offer, IVirtualMachineImagesOperations client)
        {
            this.publisher = publisher;
            this.offerName = offer;
            skus = new VirtualMachineSkusImpl(this, client);
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:30F55C79E023C794C43C833CF0BB159B
        public string Name()
        {
            return this.offerName;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:68CDD3D656DF2167E9C39FD2066C0E83
        public Region Region()
        {
            return publisher.Region;
        }

        ///GENMHASH:8E3FF63FC02A3540865E75052785D668:AC71B793CB602017F7CD103CEACA5AD0
        public IVirtualMachinePublisher Publisher()
        {
            return publisher;
        }

        ///GENMHASH:7D9DC833CD61C25D0247148117F1E9BD:C868C06D388BCDB1C1FF51CD0D7DF664
        public IVirtualMachineSkus Skus()
        {
            return skus;
        }
    }
}
