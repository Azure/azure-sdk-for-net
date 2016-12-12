// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using VirtualMachineScaleSetExtension.UpdateDefinition;
    using VirtualMachineScaleSetExtension.Update;
    using VirtualMachineScaleSetExtension.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using VirtualMachineScaleSet.Definition;
    using VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Resource.Fluent.Core.ChildResourceActions;
    using Newtonsoft.Json;

    /// <summary>
    /// Implementation of VirtualMachineScaleSetExtension.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldEV4dGVuc2lvbkltcGw=
    internal partial class VirtualMachineScaleSetExtensionImpl :
        ChildResource<Models.VirtualMachineScaleSetExtensionInner, Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetImpl, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        IVirtualMachineScaleSetExtension,
        IDefinition<VirtualMachineScaleSet.Definition.IWithCreate>,
        IUpdateDefinition<VirtualMachineScaleSet.Update.IWithApply>,
        VirtualMachineScaleSetExtension.Update.IUpdate
    {
        private IDictionary<string,object> publicSettings;
        private IDictionary<string,object> protectedSettings;

        ///GENMHASH:F8C651BFA96A5C2B1BE72B024FE8AEEF:815BF11DE6127502A0AFCB14BE98F20E
        internal VirtualMachineScaleSetExtensionImpl(VirtualMachineScaleSetExtensionInner inner, VirtualMachineScaleSetImpl parent) : base(inner, parent)
        {
            InitializeSettings();
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:06BBF1077FAA38CC78AFC6E69E23FB58:2E1C21AC97868331579C4445DFF8B199
        public string PublisherName()
        {
            return this.Inner.Publisher;
        }

        ///GENMHASH:062496BB5D915E140ABE560B4E1D89B1:605B8FC69F180AFC7CE18C754024B46C
        public string TypeName()
        {
            return this.Inner.Type;
        }

        ///GENMHASH:59C1C6208A5C449165066C7E1FDE11ED:D218DCBF15733B59D5054B1545063FEA
        public string VersionName()
        {
            return this.Inner.TypeHandlerVersion;
        }

        ///GENMHASH:38030CBAE29B9F2F38D72F365E2E629A:E94F2D3DAC3B970EABC385A12F44BB26
        public bool AutoUpgradeMinorVersionEnabled()
        {
            return this.Inner.AutoUpgradeMinorVersion.Value;
        }

        ///GENMHASH:E8B034BE63B3FB3349E5BCFC76224AF8:CA9E3FB93CD214E58089AA8C2C20B7A3
        public IReadOnlyDictionary<string, object> PublicSettings()
        {
            return this.publicSettings as IReadOnlyDictionary<string, object>;
        }

        ///GENMHASH:316D51C271754F67D70A4782C8F17E3A:9790D012FA64E47343F12DB13F0AA212
        public string PublicSettingsAsJsonString()
        {
            if (this.PublicSettings() != null)
            {
                return JsonConvert.SerializeObject(this.PublicSettings());
            }
            return null;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public string ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

        ///GENMHASH:467F635EADCCCC617A72CEB57E5B3D41:7B7B2063CA85FFEC8E5F9CF53A22CED0
        public VirtualMachineScaleSetExtensionImpl WithMinorVersionAutoUpgrade()
        {
            this.Inner.AutoUpgradeMinorVersion = true;
            return this;
        }

        ///GENMHASH:23B0698FE3BB00936E77BFAAD4E8C173:2897633350A3881BCCEECEB8CBDCFF63
        public VirtualMachineScaleSetExtensionImpl WithoutMinorVersionAutoUpgrade()
        {
            this.Inner.AutoUpgradeMinorVersion = false;
            return this;
        }

        ///GENMHASH:FCA44D692D2CBD47AF19A7B5D9CEB263:E932E565C84B68E30D666C77ECF8F4E9
        public VirtualMachineScaleSetExtensionImpl WithImage(IVirtualMachineExtensionImage image)
        {
            Inner.Publisher = image.PublisherName;
            Inner.Type = image.TypeName;
            Inner.TypeHandlerVersion = image.VersionName;
            return this;
        }

        ///GENMHASH:D09614E022482293C9A2EEE2C6E4098E:86E8D4D3B2BDB9EEBA09E6F348394801
        public VirtualMachineScaleSetExtensionImpl WithPublisher(string extensionImagePublisherName)
        {
            this.Inner.Publisher = extensionImagePublisherName;
            return this;
        }

        ///GENMHASH:F4E714A8C40DF6CD0AE34FBA3BC4C770:79A077AE3BFC0D04AB2B4B8492338A57
        public VirtualMachineScaleSetExtensionImpl WithPublicSetting(string key, object value)
        {
            this.publicSettings.Add(key, value);
            return this;
        }

        ///GENMHASH:4E0AB82616606C4EEBD304EE7CA95448:C69FF63CB6446E393F7AC97CBA0B0631
        public VirtualMachineScaleSetExtensionImpl WithProtectedSetting(string key, object value)
        {

            this.protectedSettings.Add(key, value);
            return this;
        }

        ///GENMHASH:1D0CC09D7108E079E0215F59B279BCA8:2D5C9E48A5341416C6BDFB5BC6014FAE
        public VirtualMachineScaleSetExtensionImpl WithPublicSettings(IDictionary<string, object> settings)
        {
            this.publicSettings.Clear();
            foreach(var entry in settings) {
                this.publicSettings.Add(entry.Key, entry.Value);
            }
            return this;
        }

        ///GENMHASH:47A9BC4FAD4EEB04D8AA50F23064B253:8123EC3071CE1111531A48B680D93AAF
        public VirtualMachineScaleSetExtensionImpl WithProtectedSettings(IDictionary<string, object> settings)
        {
            this.protectedSettings.Clear();
            foreach (var entry in settings)
            {
                this.protectedSettings.Add(entry.Key, entry.Value);
            }
            return this;
        }

        ///GENMHASH:1B55955986893FF406609C78FCC96FEE:1DF9D56E59684CD39EB87D1AF4CCF411
        public VirtualMachineScaleSetExtensionImpl WithType(string extensionImageTypeName)
        {
            Inner.Type = extensionImageTypeName;
            return this;
        }

        ///GENMHASH:5A056156A7C92738B7A05BFFB861E1B4:DA8B164AFF802F7E1F62BE36FA742A8D
        public VirtualMachineScaleSetExtensionImpl WithVersion(string extensionImageVersionName)
        {
            Inner.TypeHandlerVersion = extensionImageVersionName;
            return this;
        }

        ///GENMHASH:85C90F4F6082200D94668A66AEFC6726:7DA1F1B9237639B669A209E12821D17A
        private void NullifySettingsIfEmpty()
        {
            if (this.publicSettings.Count == 0) {
                this.Inner.Settings = null;
            }

            if (this.protectedSettings.Count == 0)
            {
                this.Inner.ProtectedSettings = null;
            }
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

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:A7E70E6A25505D4B6F0EF5B2C0549275
        public VirtualMachineScaleSetImpl Attach()
        {
            NullifySettingsIfEmpty();
            return this.Parent.WithExtension(this);
        }

        VirtualMachineScaleSet.Update.IUpdate ISettable<VirtualMachineScaleSet.Update.IUpdate>.Parent()
        {
            return base.Parent;
        }
    }
}