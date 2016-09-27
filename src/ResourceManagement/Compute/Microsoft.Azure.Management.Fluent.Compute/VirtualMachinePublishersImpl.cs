// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.V2.Compute
{
    internal partial class VirtualMachinePublishersImpl
        : ReadableWrappers<IVirtualMachinePublisher, VirtualMachinePublisherImpl, VirtualMachineImageResourceInner>,
          IVirtualMachinePublishers
    {
        private readonly IVirtualMachineImagesOperations innerCollection;
        private readonly IVirtualMachineExtensionImagesOperations extensionsInnerCollection;

        internal VirtualMachinePublishersImpl(IVirtualMachineImagesOperations innerCollection, IVirtualMachineExtensionImagesOperations extensionsInnerCollection)
        {
            this.innerCollection = innerCollection;
            this.extensionsInnerCollection = extensionsInnerCollection;
        }

        public PagedList<IVirtualMachinePublisher> ListByRegion(string regionName)
        {
            IEnumerable<VirtualMachineImageResourceInner> innerPublishers = innerCollection.ListPublishers(regionName);
            var pagedList = new PagedList<VirtualMachineImageResourceInner>(innerPublishers);
            return WrapList(pagedList);
        }

        public PagedList<IVirtualMachinePublisher> ListByRegion(Region region)
        {
            return this.ListByRegion(EnumNameAttribute.GetName(region));
        }

        protected override IVirtualMachinePublisher WrapModel(VirtualMachineImageResourceInner inner)
        {
            return new VirtualMachinePublisherImpl(EnumNameAttribute.FromName<Region>(inner.Location), inner.Name, 
                this.innerCollection, 
                this.extensionsInnerCollection);
        }
    }
}
