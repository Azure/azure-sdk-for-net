// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// The implementation for VirtualMachineImagesInSku.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVJbWFnZXNJblNrdUltcGw=
    internal partial class VirtualMachineImagesInSkuImpl :
        IVirtualMachineImagesInSku
    {
        private IVirtualMachineSku sku;
        private IVirtualMachineImagesOperations innerCollection;

        ///GENMHASH:7C57EFD7D244A6EB7441F4C4C8306084:56F19A0547690A0FACCDBCAEDCD6DC26
        internal VirtualMachineImagesInSkuImpl(IVirtualMachineSku sku, IVirtualMachineImagesOperations innerCollection)
        {
            this.sku = sku;
            this.innerCollection = innerCollection;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:F11EF4E68CC9208DDB5333BF63B56234
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage> List()
        {
            List<IVirtualMachineImage> firstPage = new List<IVirtualMachineImage>();
            var innerImages = innerCollection.List(sku.Region.Name, sku.Publisher.Name, sku.Offer.Name, sku.Name);
            foreach(var innerImage in innerImages)
            {
                var version = innerImage.Name;
                firstPage.Add(new VirtualMachineImageImpl(sku.Region,
                    sku.Publisher.Name,
                    sku.Offer.Name,
                    sku.Name,
                    version,
                    innerCollection.Get(sku.Region.Name, sku.Publisher.Name, sku.Offer.Name, sku.Name, version)));
            }
            return new PagedList<IVirtualMachineImage>(firstPage);
        }
    }
}
