using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Compute
{
    public partial class VirtualMachineSkuImpl : IVirtualMachineSku
    {
        private IVirtualMachineOffer offer;
        private IVirtualMachineImagesInSku imagesInSku;

        internal VirtualMachineSkuImpl(IVirtualMachineOffer offer, string skuName, IVirtualMachineImagesOperations client)
        {
            this.offer = offer;
            Name = skuName;
            imagesInSku = new VirtualMachineImagesInSkuImpl(this, client);
        }

        public string Name
        {
            get; private set;
        }

        public Region? Region
        {
            get
            {
                return offer.Region;
            }
        }

        public IVirtualMachineImagesInSku Images()
        {
            return imagesInSku;
        }

        public IVirtualMachineOffer Offer()
        {
            return offer;
        }

        public IVirtualMachinePublisher Publisher()
        {
            return offer.Publisher();
        }
    }
}
