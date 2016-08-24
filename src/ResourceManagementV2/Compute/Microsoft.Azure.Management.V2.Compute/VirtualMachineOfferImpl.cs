using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Compute
{
    public partial class VirtualMachineOfferImpl : IVirtualMachineOffer
    {
        private IVirtualMachinePublisher publisher;
        private IVirtualMachineSkus skus;

        internal VirtualMachineOfferImpl(IVirtualMachinePublisher publisher, string offer, IVirtualMachineImagesOperations client)
        {
            this.publisher = publisher;
            Name = offer;
            skus = new VirtualMachineSkusImpl(this, client);
        }

        public string Name
        {
            get; private set;
        }

        public Region? Region
        {
            get
            {
                return publisher.Region;
            }
        }

        public IVirtualMachinePublisher Publisher()
        {
            return publisher;
        }

        public IVirtualMachineSkus Skus()
        {
            return skus;
        }
    }
}
