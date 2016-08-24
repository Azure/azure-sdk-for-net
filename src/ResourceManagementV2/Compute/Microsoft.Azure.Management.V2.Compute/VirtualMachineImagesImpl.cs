using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Compute
{
    public partial class VirtualMachineImagesImpl : IVirtualMachineImages
    {
        private IVirtualMachinePublishers publishers;

        internal VirtualMachineImagesImpl(IVirtualMachineImagesOperations client)
        {
            publishers = new VirtualMachinePublishersImpl(client);
        }

        public PagedList<IVirtualMachineImage> ListByRegion(Region region)
        {
            return ListByRegion(EnumNameAttribute.GetName(region));
        }

        public PagedList<IVirtualMachineImage> ListByRegion(string regionName)
        {
            PagedList<IVirtualMachinePublisher> publishers = Publishers().ListByRegion(regionName);

            PagedList<IVirtualMachineOffer> offers = new ChildListFlattener<IVirtualMachinePublisher, IVirtualMachineOffer>(publishers, 
                (IVirtualMachinePublisher publisher) =>
                    {
                        return publisher.Offers().List();
                    }).Flatten();

            PagedList<IVirtualMachineSku> skus = new ChildListFlattener<IVirtualMachineOffer, IVirtualMachineSku>(offers,
                (IVirtualMachineOffer offer) =>
                    {
                        return offer.Skus().List();
                    }).Flatten();

            PagedList<IVirtualMachineImage> images = new ChildListFlattener<IVirtualMachineSku, IVirtualMachineImage>(skus,
                (IVirtualMachineSku sku) =>
                    {
                        return sku.Images().List();
                    }).Flatten();

            return images;
        }

        public IVirtualMachinePublishers Publishers()
        {
            return publishers;
        }
    }
}
