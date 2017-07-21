// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// The implementation for VirtualMachinePublishers.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVQdWJsaXNoZXJzSW1wbA==
    internal partial class VirtualMachinePublishersImpl :
        ReadableWrappers<IVirtualMachinePublisher, VirtualMachinePublisherImpl, VirtualMachineImageResourceInner>,
        IVirtualMachinePublishers
    {
        private readonly IVirtualMachineImagesOperations innerCollection;
        private readonly IVirtualMachineExtensionImagesOperations extensionsInnerCollection;

        ///GENMHASH:FAE60D4985B6939A3E27850EF50CF159:020EAF2CEFD87F9DC43CFF189FE7ABA9
        internal VirtualMachinePublishersImpl(
            IVirtualMachineImagesOperations innerCollection,
            IVirtualMachineExtensionImagesOperations extensionsInnerCollection)
        {
            this.innerCollection = innerCollection;
            this.extensionsInnerCollection = extensionsInnerCollection;
        }

        ///GENMHASH:360BB74037893879A730ED7ED0A3938A:0812389C333714A6DDA6CD76F7B8FEFC
        public IEnumerable<IVirtualMachinePublisher> ListByRegion(string regionName)
        {
            return WrapList(Extensions.Synchronize(() => innerCollection.ListPublishersAsync(regionName)));
        }

        ///GENMHASH:2ED29FF482F2137640A1CA66925828A8:FDF416505062C8F51CBE651942F05701
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher>> ListByRegionAsync(string regionName, CancellationToken cancellationToken)
        {
            return await PagedCollection<IVirtualMachinePublisher, VirtualMachineImageResourceInner>.LoadPage(
                async (cancellation) => await innerCollection.ListPublishersAsync(regionName, cancellation),
                WrapModel, cancellationToken);
        }

        ///GENMHASH:271CC39CE723B6FD3D7CCA7471D4B201:039795D842B96323D94D260F3FF83299
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher>> ListByRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ListByRegionAsync(region.Name, cancellationToken);
        }

        ///GENMHASH:BA2FEDDF9D78BF55786D81F6C85E907C:CD5A589A9B297BE134944F6A531D30E8
        public IEnumerable<IVirtualMachinePublisher> ListByRegion(Region region)
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
