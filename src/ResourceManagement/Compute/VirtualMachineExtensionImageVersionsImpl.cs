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
    /// The implementation for VirtualMachineExtensionImageVersions.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFeHRlbnNpb25JbWFnZVZlcnNpb25zSW1wbA==
    internal partial class VirtualMachineExtensionImageVersionsImpl :
        ReadableWrappers<IVirtualMachineExtensionImageVersion, VirtualMachineExtensionImageVersionImpl, VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImageVersions
    {
        private IVirtualMachineExtensionImagesOperations client;
        private IVirtualMachineExtensionImageType type;
        ///GENMHASH:19782C525D3A76B062C3026754D341EE:8E3AF7118176C2ACD26F97CF82D7B4F2
        internal VirtualMachineExtensionImageVersionsImpl(IVirtualMachineExtensionImagesOperations client, IVirtualMachineExtensionImageType type)
        {
            this.client = client;
            this.type = type;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:DE7A9E25A3A0DA8C686B167840FC2C68
        public IEnumerable<IVirtualMachineExtensionImageVersion> List()
        {
            return WrapList(Extensions.Synchronize(() => this.client.ListVersionsAsync(
                type.RegionName,
                type.Publisher.Name,
                type.Name)));
        }

        public async Task<IPagedCollection<IVirtualMachineExtensionImageVersion>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IVirtualMachineExtensionImageVersion, VirtualMachineExtensionImageInner>.LoadPage(
                async (cancellation) => await this.client.ListVersionsAsync(type.RegionName, type.Publisher.Name, type.Name, cancellationToken: cancellation),
                WrapModel, cancellationToken);
        }

        ///GENMHASH:3823A118AF47AF7328798BEA74521A04:3A4CA90FBB86038062B022FC826008A2
        protected override IVirtualMachineExtensionImageVersion WrapModel (VirtualMachineExtensionImageInner inner)
        {
            return new VirtualMachineExtensionImageVersionImpl(client, type, inner);
        }
    }
}
