// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    internal partial class VirtualMachineImagesInSkuImpl : IVirtualMachineImagesInSku
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
            var innerImages = innerCollection.List(EnumNameAttribute.GetName(sku.Region), sku.Publisher.Name, sku.Offer.Name, sku.Name);
            foreach(var innerImage in innerImages)
            {
                var version = innerImage.Name;
                firstPage.Add(new VirtualMachineImageImpl(sku.Region,
                    sku.Publisher.Name,
                    sku.Offer.Name,
                    sku.Name,
                    version,
                    innerCollection.Get(EnumNameAttribute.GetName(sku.Region), sku.Publisher.Name, sku.Offer.Name, sku.Name, version)));
            }
            return new PagedList<IVirtualMachineImage>(firstPage);
        }
    }
}
