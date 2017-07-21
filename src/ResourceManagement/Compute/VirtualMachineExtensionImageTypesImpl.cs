// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for VirtualMachineExtensionImageTypes.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFeHRlbnNpb25JbWFnZVR5cGVzSW1wbA==
    internal partial class VirtualMachineExtensionImageTypesImpl :
        ReadableWrappers<IVirtualMachineExtensionImageType, VirtualMachineExtensionImageTypeImpl, VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImageTypes
    {
        private IVirtualMachineExtensionImagesOperations client;
        private IVirtualMachinePublisher publisher;
        ///GENMHASH:BC226EF2EAB4AB4B0C4E94FED5D962F0:D11D3C231EE92D6F7F22BDA2782F6427
        internal VirtualMachineExtensionImageTypesImpl (IVirtualMachineExtensionImagesOperations client, IVirtualMachinePublisher publisher)
        {
            this.client = client;
            this.publisher = publisher;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:59EB64D540FD3901775AB588B47D36A4
        public IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType> List()
        {
            return WrapList(Extensions.Synchronize(() => this.client.ListTypesAsync(this.publisher.Region.Name, this.publisher.Name)));
        }

        public async Task<IPagedCollection<IVirtualMachineExtensionImageType>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IVirtualMachineExtensionImageType, VirtualMachineExtensionImageInner>.LoadPage(
                async (cancellation) => await this.client.ListTypesAsync(this.publisher.Region.Name, this.publisher.Name, cancellation),
                WrapModel, cancellationToken);
        }

        ///GENMHASH:3823A118AF47AF7328798BEA74521A04:3305DDE8944B084B78FD8F84BA96EEED
        protected override IVirtualMachineExtensionImageType WrapModel(VirtualMachineExtensionImageInner inner)
        {
            return new VirtualMachineExtensionImageTypeImpl(this.client, this.publisher, inner);
        }
    }
}
