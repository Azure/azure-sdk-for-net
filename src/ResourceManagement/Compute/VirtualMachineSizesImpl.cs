// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for VirtualMachineSizes.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTaXplc0ltcGw=
    internal partial class VirtualMachineSizesImpl :
        ReadableWrappers<IVirtualMachineSize, VirtualMachineSizeImpl, VirtualMachineSize>,
        IVirtualMachineSizes
    {
        private IVirtualMachineSizesOperations innerCollection;

        ///GENMHASH:1E68517C1A59C28E468847A80B4DD01E:486439A921BD2C43847EE93CC89E0C10
        internal VirtualMachineSizesImpl(IVirtualMachineSizesOperations innerCollection)
        {
            this.innerCollection = innerCollection;
        }

        ///GENMHASH:BA2FEDDF9D78BF55786D81F6C85E907C:CD5A589A9B297BE134944F6A531D30E8
        public IEnumerable<IVirtualMachineSize> ListByRegion(Region region)
        {
            return ListByRegion(region.Name);
        }

        ///GENMHASH:D12A67B4E55209FF4EABF023E6785823:111A3D57982318A0A8F8170E3417353A
        protected override IVirtualMachineSize WrapModel(VirtualMachineSize inner)
        {
             return new VirtualMachineSizeImpl(inner);
        }

        ///GENMHASH:360BB74037893879A730ED7ED0A3938A:1B63D16EAADAEBB8A17A72652C7477D7
        public IEnumerable<IVirtualMachineSize> ListByRegion(string regionName)
        {
            return WrapList(Extensions.Synchronize(() => innerCollection.ListAsync(regionName)));
        }

        ///GENMHASH:271CC39CE723B6FD3D7CCA7471D4B201:039795D842B96323D94D260F3FF83299
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize>> ListByRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ListByRegionAsync(region.Name, cancellationToken);
        }

        ///GENMHASH:2ED29FF482F2137640A1CA66925828A8:23E6C183E53FB66FB963B8D1F7962C4F
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize>> ListByRegionAsync(string regionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IVirtualMachineSize, VirtualMachineSize>.LoadPage(
                 async (cancellation) => await innerCollection.ListAsync(regionName, cancellation),
                 WrapModel,
                 cancellationToken);
        }
    }
}
