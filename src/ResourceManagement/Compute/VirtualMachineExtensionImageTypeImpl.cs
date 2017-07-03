// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// The implementation for VirtualMachineExtensionImageType.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFeHRlbnNpb25JbWFnZVR5cGVJbXBs
    internal partial class VirtualMachineExtensionImageTypeImpl :
        Wrapper<VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImageType
    {
        private IVirtualMachineExtensionImagesOperations client;
        private IVirtualMachinePublisher publisher;
        ///GENMHASH:8175A2B55D06EDD2889B5CCA8AAB9443:B3CBCEB2E89FF4D7DBD086799C1C3A5B
        internal VirtualMachineExtensionImageTypeImpl(IVirtualMachineExtensionImagesOperations client, IVirtualMachinePublisher publisher, VirtualMachineExtensionImageInner inner) : base(inner)
        {
            this.client = client;
            this.publisher = publisher;
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

        ///GENMHASH:8E3FF63FC02A3540865E75052785D668:614A841E9596603BBD981A7D09F66158
        public IVirtualMachinePublisher Publisher()
        {
            return this.publisher;
        }

        ///GENMHASH:94793EAE475C6B7C746F92BF13EFF2CA:8A3CBABE304A052103727B1255FD5A63
        public IVirtualMachineExtensionImageVersions Versions()
        {
            return new VirtualMachineExtensionImageVersionsImpl(this.client, this);
        }
    }
}
