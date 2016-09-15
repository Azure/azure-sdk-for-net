using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.V2.Resource.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.V2.Compute
{
    public partial class VirtualMachineImagesInSkuImpl : IVirtualMachineImagesInSku
    {
        private IVirtualMachineSku sku;
        private IVirtualMachineImagesOperations innerCollection;

        internal VirtualMachineImagesInSkuImpl(IVirtualMachineSku sku, IVirtualMachineImagesOperations innerCollection)
        {
            this.sku = sku;
            this.innerCollection = innerCollection;
        }

        public PagedList<IVirtualMachineImage> List()
        {
            List<IVirtualMachineImage> firstPage = new List<IVirtualMachineImage>();
            var innerImages = innerCollection.List(EnumNameAttribute.GetName(sku.Region), sku.Publisher().Name, sku.Offer().Name, sku.Name);
            foreach(var innerImage in innerImages)
            {
                var version = innerImage.Name;
                firstPage.Add(new VirtualMachineImageImpl(sku.Region.Value,
                    sku.Publisher().Name,
                    sku.Offer().Name,
                    sku.Name,
                    version,
                    innerCollection.Get(EnumNameAttribute.GetName(sku.Region), sku.Publisher().Name, sku.Offer().Name, sku.Name, version)));
            }
            return new PagedList<IVirtualMachineImage>(firstPage);
        }
    }
}
