// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// The implementation for VirtualMachinePublishers.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVQdWJsaXNoZXJzSW1wbA==
    internal partial class VirtualMachinePublishersImpl
        : ReadableWrappers<IVirtualMachinePublisher, VirtualMachinePublisherImpl, VirtualMachineImageResourceInner>,
          IVirtualMachinePublishers
    {
        private readonly IVirtualMachineImagesOperations innerCollection;
        private readonly IVirtualMachineExtensionImagesOperations extensionsInnerCollection;

        ///GENMHASH:FAE60D4985B6939A3E27850EF50CF159:020EAF2CEFD87F9DC43CFF189FE7ABA9
        internal VirtualMachinePublishersImpl(IVirtualMachineImagesOperations innerCollection, IVirtualMachineExtensionImagesOperations extensionsInnerCollection)
        {
            this.innerCollection = innerCollection;
            this.extensionsInnerCollection = extensionsInnerCollection;
        }

        ///GENMHASH:360BB74037893879A730ED7ED0A3938A:0812389C333714A6DDA6CD76F7B8FEFC
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher> ListByRegion(string regionName)
        {
            IEnumerable<VirtualMachineImageResourceInner> innerPublishers = innerCollection.ListPublishers(regionName);
            var pagedList = new PagedList<VirtualMachineImageResourceInner>(innerPublishers);
            return WrapList(pagedList);
        }

        ///GENMHASH:BA2FEDDF9D78BF55786D81F6C85E907C:CD5A589A9B297BE134944F6A531D30E8
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher> ListByRegion(Region region)
        {
            return this.ListByRegion(region.Name);
        }

        ///GENMHASH:D48BEF4BAC4C0112B6930D731FFC59BD:B688575CF0F2C7EE53245AA64EA89B5D
        protected override IVirtualMachinePublisher WrapModel(VirtualMachineImageResourceInner inner)
        {
            return new VirtualMachinePublisherImpl(Region.Create(inner.Location), inner.Name, 
                this.innerCollection, 
                this.extensionsInnerCollection);
        }
    }
}
