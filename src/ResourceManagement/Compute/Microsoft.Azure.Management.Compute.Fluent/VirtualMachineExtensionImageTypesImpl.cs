// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// The implementation for VirtualMachineExtensionImageTypes.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFeHRlbnNpb25JbWFnZVR5cGVzSW1wbA==
    internal partial class VirtualMachineExtensionImageTypesImpl :
        ReadableWrappers<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType, Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtensionImageTypeImpl, Models.VirtualMachineExtensionImageInner>,
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
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType> List()
        {
            return WrapList(this.client.ListTypes(this.publisher.Region.Name, this.publisher.Name));
        }

        ///GENMHASH:3823A118AF47AF7328798BEA74521A04:3305DDE8944B084B78FD8F84BA96EEED
        protected override IVirtualMachineExtensionImageType WrapModel(VirtualMachineExtensionImageInner inner)
        {
            return new VirtualMachineExtensionImageTypeImpl(this.client, this.publisher, inner);
        }
    }
}