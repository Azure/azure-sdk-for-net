// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Resource.Fluent.Core;
    using System.Collections.Generic;
    using Management.Compute.Fluent.Models;
    using Resource.Fluent.Core.ChildResourceActions;
    using Newtonsoft.Json;

    /// <summary>
    /// Implementation of VirtualMachineScaleSetExtension.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldEV4dGVuc2lvbkltcGw=
    internal partial class VirtualMachineScaleSetExtensionImpl :
        ChildResource<VirtualMachineScaleSetExtensionInner,
            VirtualMachineScaleSetImpl,
            IVirtualMachineScaleSet>,
        IVirtualMachineScaleSetExtension,
        VirtualMachineScaleSetExtension.Definition.IDefinition<VirtualMachineScaleSet.Definition.IWithCreate>,
        VirtualMachineScaleSetExtension.UpdateDefinition.IUpdateDefinition<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>,
        VirtualMachineScaleSetExtension.Update.IUpdate
    {
        private IDictionary<string,object> publicSettings;
        private IDictionary<string,object> protectedSettings;

        internal VirtualMachineScaleSetExtensionImpl (VirtualMachineScaleSetExtensionInner inner, VirtualMachineScaleSetImpl parent) : base(inner, parent)
        {
            InitializeSettings();
        }

        public override string Name()
        {
            return this.Inner.Name;
        }

        public string PublisherName()
        {
            return this.Inner.Publisher;
        }
        public string TypeName()
        {
            return this.Inner.Type;
        }
        public string VersionName()
        {
            return this.Inner.TypeHandlerVersion;
        }
        public bool AutoUpgradeMinorVersionEnabled()
        {
            return this.Inner.AutoUpgradeMinorVersion.Value;
        }
        public IDictionary<string, object> PublicSettings()
        {
            return this.publicSettings;
        }
        public string PublicSettingsAsJsonString()
        {
            if (this.PublicSettings() != null)
            {
                return JsonConvert.SerializeObject(this.PublicSettings());
            }
            return null;
        }
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

        public VirtualMachineScaleSetExtensionImpl WithImage (IVirtualMachineExtensionImage image)
        {
            Inner.Publisher = image.PublisherName;
            Inner.Type = image.TypeName;
            Inner.TypeHandlerVersion = image.VersionName;
            return this;
        }

        public VirtualMachineScaleSetExtensionImpl WithPublisher (string extensionImagePublisherName)
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

        public VirtualMachineScaleSetExtensionImpl WithPublicSettings (IDictionary<string,object> settings)
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

        public VirtualMachineScaleSetExtensionImpl WithType (string extensionImageTypeName)
        {
            Inner.Type = extensionImageTypeName;
            return this;
        }

        public VirtualMachineScaleSetExtensionImpl WithVersion (string extensionImageVersionName)
        {
            Inner.TypeHandlerVersion = extensionImageVersionName;
            return this;
        }

        private void NullifySettingsIfEmpty ()
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