using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Compute
{
    public partial class VirtualMachinePublisherImpl : IVirtualMachinePublisher
    {
        private IVirtualMachineOffers offers;

        internal VirtualMachinePublisherImpl(Region location, string publisher, IVirtualMachineImagesOperations client)
        {
            Region = location;
            Name = publisher;
            offers = new VirtualMachineOffersImpl(client, this);
        }

        public string Name
        {
            get; private set;
        }

        public Region? Region
        {
            get; private set;
        }

        public IVirtualMachineOffers Offers()
        {
            return offers;
        }
    }
}
