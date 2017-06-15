// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// The implementation for VirtualMachinePublisher.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVQdWJsaXNoZXJJbXBs
    internal partial class VirtualMachinePublisherImpl :
        IVirtualMachinePublisher
    {
        private Region location;
        private string publisher;
        private IVirtualMachineOffers offers;
        private IVirtualMachineExtensionImageTypes extensionTypes;
        ///GENMHASH:2545F15E7242CF7DFF52ABD27674BC68:0CC035167100F57523060A76A803AC57
        internal VirtualMachinePublisherImpl(Region location, string publisher, IVirtualMachineImagesOperations vmImagesClient, IVirtualMachineExtensionImagesOperations extensionsClient)
        {
            this.location = location;
            this.publisher = publisher;
            offers = new VirtualMachineOffersImpl(vmImagesClient, this);
            extensionTypes = new VirtualMachineExtensionImageTypesImpl(extensionsClient, this);
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:AC71B793CB602017F7CD103CEACA5AD0
        public string Name()
        {
            return this.publisher;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:B0F0BE5FE7AB84929ACF2368E8415A69
        public Region Region()
        {
            return this.location;
        }

        ///GENMHASH:2AF94D69423DCC37AD09FE0A6EC64302:C1C60389A9204D57159CB98652967C45
        public IVirtualMachineOffers Offers()
        {
            return this.offers;
        }

        ///GENMHASH:D48F4C8BF96BEAC6A998FD401981617B:94F028044532F00E1BD5D2787A62E530
        public IVirtualMachineExtensionImageTypes ExtensionTypes()
        {
            return this.extensionTypes;
        }
    }
}
