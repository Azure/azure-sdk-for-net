// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for VirtualMachineExtensionImageVersion.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFeHRlbnNpb25JbWFnZVZlcnNpb25JbXBs
    internal partial class VirtualMachineExtensionImageVersionImpl :
        Wrapper<VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImageVersion
    {
        private IVirtualMachineExtensionImagesOperations client;
        private IVirtualMachineExtensionImageType type;
        ///GENMHASH:D2BFC73D89DA81F8725869BCA7B43486:885573F98652685D1517794C6009732F
        internal VirtualMachineExtensionImageVersionImpl(
            IVirtualMachineExtensionImagesOperations client,
            IVirtualMachineExtensionImageType extensionImageType,
            VirtualMachineExtensionImageInner inner) : base(inner)
        {
            this.client = client;
            type = extensionImageType;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return Inner.Id;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:3054A3D10ED7865B89395E7C007419C9
        public string RegionName()
        {
            return Inner.Location;
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:2C569A24ACEA3C5633E1884DFEB08402
        public IVirtualMachineExtensionImageType Type()
        {
            return this.type;
        }

        ///GENMHASH:CAE7C5956C89A3353EA5E0FC6E8AD675:39D1FBA4A37519D7E29877939A31F436
        public IVirtualMachineExtensionImage GetImage()
        {
            VirtualMachineExtensionImageInner inner = Extensions.Synchronize(() => this.client.GetAsync(this.RegionName(),
                this.Type().Publisher.Name,
                this.Type().Name,
                this.Name()));
            return new VirtualMachineExtensionImageImpl(this, inner);
        }

        ///GENMHASH:CAE7C5956C89A3353EA5E0FC6E8AD675:39D1FBA4A37519D7E29877939A31F436
        public async Task<IVirtualMachineExtensionImage> GetImageAsync(CancellationToken cancellationToken)
        {
            VirtualMachineExtensionImageInner inner = await this.client.GetAsync(this.RegionName(),
                this.Type().Publisher.Name,
                this.Type().Name,
                this.Name(), cancellationToken);
            return new VirtualMachineExtensionImageImpl(this, inner);
        }
    }
}
