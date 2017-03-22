// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// The implementation for Sku.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTa3VJbXBs
    internal partial class VirtualMachineSkuImpl :
        IVirtualMachineSku
    {
        private IVirtualMachineOffer offer;
        private string skuName;
        private IVirtualMachineImagesInSku imagesInSku;

        ///GENMHASH:21D3D2F31FC065A4FFA54A06386FB988:A4610E899250FB2A5209F126FAB351F7
        internal VirtualMachineSkuImpl(IVirtualMachineOffer offer, string skuName, IVirtualMachineImagesOperations client)
        {
            this.offer = offer;
            this.skuName = skuName;
            imagesInSku = new VirtualMachineImagesInSkuImpl(this, client);
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:A38394CC8588937D0F1038F176F0B672
        public string Name()
        {
            return skuName;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:9DA174C38270AE7BB1B06EB1C598A3E8
        public Region Region()
        {
            return offer.Region;
        }

        ///GENMHASH:FD6AB89647EBCE97E9F3A5569D02CF73:2DFAD827F9A0BB61227C40DB8769EB8A
        public IVirtualMachineImagesInSku Images()
        {
            return imagesInSku;
        }

        ///GENMHASH:C45A9968A03993B152B3E8DC4FD3A429:5D3F701B1A4DB84A31B1CA4C3DE4FA5F
        public IVirtualMachineOffer Offer()
        {
            return offer;
        }

        ///GENMHASH:8E3FF63FC02A3540865E75052785D668:0E28FFA20ED765BEE7F6C4CC66A1A9CF
        public IVirtualMachinePublisher Publisher()
        {
            return offer.Publisher;
        }
    }
}
