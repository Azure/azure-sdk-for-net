// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Collections.Generic;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Implementation of VirtualMachineScaleSetVMInstanceExtension.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldFZNSW5zdGFuY2VFeHRlbnNpb25JbXBs
    internal partial class VirtualMachineScaleSetVMInstanceExtensionImpl :
        ChildResource<Models.VirtualMachineExtensionInner, Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetVMImpl, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>,
        IVirtualMachineScaleSetVMInstanceExtension
    {
        private IDictionary<string, object> publicSettings;
        private IDictionary<string, object> protectedSettings;
        ///GENMHASH:E21E3E6E61153DDD23E28BC18B49F1AC:6FB4182F747416C98B49B59F74185782
        public VirtualMachineExtensionInstanceView InstanceView()
        {
            return this.Inner.InstanceView;
        }

        ///GENMHASH:06BBF1077FAA38CC78AFC6E69E23FB58:2E1C21AC97868331579C4445DFF8B199
        public string PublisherName()
        {
            return this.Inner.Publisher;
        }

        ///GENMHASH:E8B034BE63B3FB3349E5BCFC76224AF8:CA9E3FB93CD214E58089AA8C2C20B7A3
        public IReadOnlyDictionary<string, object> PublicSettings()
        {
            return this.publicSettings as IReadOnlyDictionary<string, object>;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:062496BB5D915E140ABE560B4E1D89B1:605B8FC69F180AFC7CE18C754024B46C
        public string TypeName()
        {
            return this.Inner.Type;
        }

        ///GENMHASH:316D51C271754F67D70A4782C8F17E3A:9790D012FA64E47343F12DB13F0AA212
        public string PublicSettingsAsJsonString()
        {
            //$ return null;

            return null;
        }

        ///GENMHASH:0016636B1947D033B76D88F9E31C3165:815BF11DE6127502A0AFCB14BE98F20E
        internal VirtualMachineScaleSetVMInstanceExtensionImpl(VirtualMachineExtensionInner inner,
            VirtualMachineScaleSetVMImpl parent) : base(inner, parent)
        {
            InitializeSettings();
        }

        ///GENMHASH:38030CBAE29B9F2F38D72F365E2E629A:E94F2D3DAC3B970EABC385A12F44BB26
        public bool AutoUpgradeMinorVersionEnabled()
        {
            return this.Inner.AutoUpgradeMinorVersion?? false;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public string ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

        ///GENMHASH:59C1C6208A5C449165066C7E1FDE11ED:D218DCBF15733B59D5054B1545063FEA
        public string VersionName()
        {
            return this.Inner.TypeHandlerVersion;
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:9B2A27091279EF147C6847EBD7A52FA9
        public IReadOnlyDictionary<string, string> Tags()
        {
            if (this.Inner.Tags == null) {
                return new Dictionary<string, string>();
            }
            return this.Inner.Tags as IReadOnlyDictionary<string, string>;
        }

        ///GENMHASH:1DE96DF05FCD164699FABE2722D3B823:DDB96B1018AF16195187204FD1A5F7F0
        private void InitializeSettings()
        {
            if (this.Inner.Settings == null)
            {
                this.publicSettings = new Dictionary<string, object>();
                this.Inner.Settings = this.publicSettings;
            }
            else
            {
                this.publicSettings = this.Inner.Settings as IDictionary<string, object>;
            }

            if (this.Inner.ProtectedSettings == null)
            {
                this.protectedSettings = new Dictionary<string, object>();
                this.Inner.ProtectedSettings = this.protectedSettings;
            }
            else
            {
                this.protectedSettings = this.Inner.ProtectedSettings as IDictionary<string, object>;
            }
        }
    }
}