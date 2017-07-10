// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.Compute.Fluent
{

    using ResourceManager.Fluent.Core;
    using Models;

    /// <summary>
    /// The implementation for VirtualMachineExtensionImage.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFeHRlbnNpb25JbWFnZUltcGw=
    internal partial class VirtualMachineExtensionImageImpl :
        Wrapper<VirtualMachineExtensionImageInner>,
        IVirtualMachineExtensionImage
    {
        private IVirtualMachineExtensionImageVersion version;

        ///GENMHASH:A7E90FDB3C926DF27F7112B4B162FAF4:18F40888397DB8447972CA66C758B20D
        internal VirtualMachineExtensionImageImpl(IVirtualMachineExtensionImageVersion version, VirtualMachineExtensionImageInner inner) : base(inner)
        {
            this.version = version;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return Inner.Id;
        }

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:3054A3D10ED7865B89395E7C007419C9
        public string RegionName()
        {
            return Inner.Location;
        }

        ///GENMHASH:06BBF1077FAA38CC78AFC6E69E23FB58:41B9E71253D9CCEFF7CA5542B45F14E6
        public string PublisherName()
        {
            return this.Version().Type.Publisher.Name;
        }

        ///GENMHASH:062496BB5D915E140ABE560B4E1D89B1:98EC48D2D2995697B6F55ED9526A5909
        public string TypeName()
        {
            return this.Version().Type.Name;
        }

        ///GENMHASH:59C1C6208A5C449165066C7E1FDE11ED:0A01677D2626423716D2A3C06AC09804
        public string VersionName()
        {
            return this.Version().Name;
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:F14EFB618E3BDB008C8709A98CBD7185
        public OperatingSystemTypes OSType()
        {
            // OperatingSystemTypes is an AutoRest generated type from the swagger
            return EnumHelper.FromEnumMemberSerializationValue<OperatingSystemTypes>(Inner.OperatingSystem);
        }

        ///GENMHASH:1D0E421DB766190CD95F143F42464EC7:6A4E7C0B70D703812B26F169D2CFCB2F
        public ComputeRoles ComputeRole()
        {
            if (Inner.ComputeRole == null)
            {
                return ComputeRoles.Unknown;
            }
            // ComputeRole is a fluent level convinence enum
            return EnumNameAttribute.FromName<ComputeRoles>(Inner.ComputeRole);
        }

        ///GENMHASH:BCB10920AA6CEA36A0DBA6F93351D65A:770B8354C3BC669CD5EB2063212873E4
        public string HandlerSchema()
        {
            return Inner.HandlerSchema;
        }

        ///GENMHASH:355015174124B234A4C86F6B973DD7B3:D292E7D1222E05DF0A23631EE2FED776
        public bool SupportsVirtualMachineScaleSets()
        {
            return Inner.VmScaleSetEnabled.Value;
        }

        ///GENMHASH:782B21B7A5982B53E0E5315FD604618E:7701C408ACEED1BDD21CBB09C82DE9ED
        public bool SupportsMultipleExtensions()
        {
            return Inner.SupportsMultipleExtensions.Value;
        }

        ///GENMHASH:493B1EDB88EACA3A476D936362A5B14C:66128BDE4C307AFBBA299AAD3751C145
        public IVirtualMachineExtensionImageVersion Version()
        {
            return this.version;
        }
    }
}
