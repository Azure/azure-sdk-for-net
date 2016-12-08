// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{

    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Resource.Fluent.Core;
    using System.Threading;
    using Management.Compute.Fluent.Models;
    using Management.Compute;
    using System.Collections.ObjectModel;
    using Newtonsoft.Json;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation of VirtualMachineExtension.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFeHRlbnNpb25JbXBs
    internal partial class VirtualMachineExtensionImpl  :
        ExternalChildResource<IVirtualMachineExtension, VirtualMachineExtensionInner, IVirtualMachine, VirtualMachineImpl>,
        IVirtualMachineExtension,
        VirtualMachineExtension.Definition.IDefinition<VirtualMachine.Definition.IWithCreate>,
        VirtualMachineExtension.UpdateDefinition.IUpdateDefinition<VirtualMachine.Update.IUpdate>,
        VirtualMachineExtension.Update.IUpdate
    {
        private IVirtualMachineExtensionsOperations client;
        private IDictionary<string, object> publicSettings;
        private IDictionary<string, object> protectedSettings;

        ///GENMHASH:90947EC118BF5E99153E929733992E3D:2B5D1133EDB84DA652C7CF5DCF2A8534
        internal VirtualMachineExtensionImpl(string name, VirtualMachineImpl parent, VirtualMachineExtensionInner inner, IVirtualMachineExtensionsOperations client) : base(name, parent, inner)
        {
            this.client = client;
            this.InitializeSettings();
        }

        internal static VirtualMachineExtensionImpl NewVirtualMachineExtension (string name, VirtualMachineImpl parent, IVirtualMachineExtensionsOperations client)
        {
            return new VirtualMachineExtensionImpl(name,
                parent,
                new VirtualMachineExtensionInner { Location = parent.RegionName },
                client);
        }

        public string Id
        {
            get
            {
                return this.Inner.Id;
            }
        }

        ///GENMHASH:06BBF1077FAA38CC78AFC6E69E23FB58:2E1C21AC97868331579C4445DFF8B199
        public string PublisherName()
        {
            return this.Inner.Publisher;
        }

        ///GENMHASH:062496BB5D915E140ABE560B4E1D89B1:BF06270DCF74C3EB9DC7E255F7D93417
        public string TypeName()
        {
            return this.Inner.VirtualMachineExtensionType;
        }

        public string VersionName()
        {
            return this.Inner.TypeHandlerVersion;
        }

        public bool AutoUpgradeMinorVersionEnabled()
        {
            return this.Inner.AutoUpgradeMinorVersion.Value;
        }

        ///GENMHASH:E8B034BE63B3FB3349E5BCFC76224AF8:CA9E3FB93CD214E58089AA8C2C20B7A3
        public IReadOnlyDictionary<string, object> PublicSettings()
        {
            return new ReadOnlyDictionary<string, object>(this.publicSettings);
        }

        ///GENMHASH:316D51C271754F67D70A4782C8F17E3A:9790D012FA64E47343F12DB13F0AA212
        public string PublicSettingsAsJsonString()
        {
            if (this.publicSettings == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(this.publicSettings);
        }

        public VirtualMachineExtensionInstanceView InstanceView()
        {
            return this.Inner.InstanceView;
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:497CEBB37227D75C20D80EC55C7C4F14
        public IReadOnlyDictionary<string, string> Tags()
        {
            IDictionary<string, string> tags = this.Inner.Tags;
            if (tags == null)
            {
                tags = new Dictionary<string, string>();
            }
            return new ReadOnlyDictionary<string, string>(tags);
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public string ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

        ///GENMHASH:467F635EADCCCC617A72CEB57E5B3D41:7B7B2063CA85FFEC8E5F9CF53A22CED0
        public VirtualMachineExtensionImpl WithMinorVersionAutoUpgrade()
        {
            this.Inner.AutoUpgradeMinorVersion = true;
            return this;
        }

        ///GENMHASH:23B0698FE3BB00936E77BFAAD4E8C173:2897633350A3881BCCEECEB8CBDCFF63
        public VirtualMachineExtensionImpl WithoutMinorVersionAutoUpgrade()
        {
            this.Inner.AutoUpgradeMinorVersion = false;
            return this;
        }

        public VirtualMachineExtensionImpl WithImage (IVirtualMachineExtensionImage image)
        {
            this.Inner.Publisher = image.PublisherName;
            this.Inner.VirtualMachineExtensionType = image.TypeName;
            this.Inner.TypeHandlerVersion = image.VersionName;
            return this;
        }

        ///GENMHASH:D09614E022482293C9A2EEE2C6E4098E:86E8D4D3B2BDB9EEBA09E6F348394801
        public VirtualMachineExtensionImpl WithPublisher(string extensionImagePublisherName)
        {
            this.Inner.Publisher = extensionImagePublisherName;
            return this;
        }

        ///GENMHASH:F4E714A8C40DF6CD0AE34FBA3BC4C770:79A077AE3BFC0D04AB2B4B8492338A57
        public VirtualMachineExtensionImpl WithPublicSetting(string key, object value)
        {
            this.publicSettings.Add(key, value);
            return this;
        }

        ///GENMHASH:4E0AB82616606C4EEBD304EE7CA95448:C69FF63CB6446E393F7AC97CBA0B0631
        public VirtualMachineExtensionImpl WithProtectedSetting (string key, object value)
        {

            this.protectedSettings.Add(key, value);
            return this;
        }

        ///GENMHASH:1D0CC09D7108E079E0215F59B279BCA8:2D5C9E48A5341416C6BDFB5BC6014FAE
        public VirtualMachineExtensionImpl WithPublicSettings(IDictionary<string, object> settings)
        {
            this.publicSettings.Clear();
            foreach (var item in settings)
            {
                this.WithPublicSetting(item.Key, item.Value);
            }
            return this;
        }

        ///GENMHASH:47A9BC4FAD4EEB04D8AA50F23064B253:8123EC3071CE1111531A48B680D93AAF
        public VirtualMachineExtensionImpl WithProtectedSettings(IDictionary<string, object> settings)
        {
            this.protectedSettings.Clear();
            foreach (var item in settings)
            {
                this.WithProtectedSetting(item.Key, item.Value);
            }
            return this;
        }

        ///GENMHASH:1B55955986893FF406609C78FCC96FEE:6289EFC386BAA3CA812B7F8EF8B95388
        public VirtualMachineExtensionImpl WithType(string extensionImageTypeName)
        {
            this.Inner.VirtualMachineExtensionType = extensionImageTypeName;
            return this;
        }

        ///GENMHASH:5A056156A7C92738B7A05BFFB861E1B4:DA8B164AFF802F7E1F62BE36FA742A8D
        public VirtualMachineExtensionImpl WithVersion(string extensionImageVersionName)
        {
            this.Inner.TypeHandlerVersion = extensionImageVersionName;
            return this;
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:E462F242E1761228E205CEE8F760EDF9
        public VirtualMachineExtensionImpl WithTags(IDictionary<string, string> tags)
        {
            this.Inner.Tags = tags;
            return this;
        }

        ///GENMHASH:FF80DD5A8C82E021759350836BD2FAD1:E70E0F84833F74462C0831B3C84D4A03
        public VirtualMachineExtensionImpl WithTag(string key, string value)
        {
            this.Inner.Tags.Add(key, value);
            return this;
        }

        ///GENMHASH:2345D3E100BA4B78504A2CC57A361F1E:250EC2907300FFA6125F7205F03A3E7F
        public VirtualMachineExtensionImpl WithoutTag(string key)
        {
            this.Inner.Tags.Remove(key);
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:915DD174AD20CD6005B14CC389FD3814
        public VirtualMachineImpl Attach()
        {
            this.NullifySettingsIfEmpty();
            return base.Parent.WithExtension(this);
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:0A7B0ED028812E214E22EAF2EB753FAB
        public IVirtualMachineExtension Refresh()
        {
            string name;
            if (this.IsReference()) {
                name = ResourceUtils.NameFromResourceId(this.Inner.Id);
            } else {
                name = this.Inner.Name;
            }
            VirtualMachineExtensionInner inner = this.client.Get(this.Parent.ResourceGroupName, this.Parent.Name, name);
            this.SetInner(inner);
            return this;
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:C13D0601ACA269F4AA251080A5EAB8A3
        public async override Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            VirtualMachineExtensionInner inner = await this.client.CreateOrUpdateAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name(),
                this.Inner,
                cancellationToken);
            this.SetInner(inner);
            this.InitializeSettings();
            return this;
        }

        ///GENMHASH:F08598A17ADD014E223DFD77272641FF:E0CB43D17A95680E1FA5052B3D980A7C
        public async override Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.NullifySettingsIfEmpty();
            if (this.IsReference())
            {
                string extensionName = ResourceUtils.NameFromResourceId(this.Inner.Id);
                var resource = await this.client.GetAsync(this.Parent.ResourceGroupName, this.Parent.Name, extensionName);
                this.Inner.Publisher = resource.Publisher;
                this.Inner.VirtualMachineExtensionType = resource.VirtualMachineExtensionType;
                if (this.Inner.AutoUpgradeMinorVersion == null)
                {
                    this.Inner.AutoUpgradeMinorVersion = resource.AutoUpgradeMinorVersion;
                }
                IDictionary<string, object> publicSettings = resource.Settings as IDictionary<string, object>;
                if (publicSettings != null && publicSettings.Count > 0)
                {
                    IDictionary<string, object> innerPublicSettings = Inner.Settings as IDictionary<string, object>;
                    if (innerPublicSettings == null)
                    {
                        Inner.Settings = new Dictionary<string, object>();
                        innerPublicSettings = Inner.Settings as IDictionary<string, object>;
                    }
                    foreach (var setting in publicSettings)
                    {
                        if (!innerPublicSettings.ContainsKey(setting.Key))
                        {
                            innerPublicSettings.Add(setting.Key, setting.Value);
                        }
                    }
                }
            }
            return await this.CreateAsync(cancellationToken);
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:4ECAD0C81AFE0A2718CE4BFF1EC4C29F
        public override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.client.DeleteAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name());
        }

        /// <returns>true if this is just a reference to the extension.</returns>
        /// <returns><p></returns>
        /// <returns>An extension will present as a reference when the parent virtual machine was fetched using</returns>
        /// <returns>VM list, a GET on a specific VM will return fully expanded extension details.</returns>
        /// <returns></p></returns>
        ///GENMHASH:5034C466FD077AE4C3BB0E8BB3EBEFB3:6AC48AA816918FEA6040CB47074973FD
        public bool IsReference()
        {
            return this.Inner.Name == null;
        }

        ///GENMHASH:85C90F4F6082200D94668A66AEFC6726:7DA1F1B9237639B669A209E12821D17A
        private void NullifySettingsIfEmpty()
        {
            if (this.publicSettings.Count == 0)
            {
                this.Inner.Settings = null;
            }

            if (this.protectedSettings.Count == 0)
            {
                this.Inner.ProtectedSettings = null;
            }
        }

        private void InitializeSettings ()
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
        VirtualMachine.Update.IUpdate ISettable<VirtualMachine.Update.IUpdate>.Parent()
        {
            return this.Parent;
        }
    }
}