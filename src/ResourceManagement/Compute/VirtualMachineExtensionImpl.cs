// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using VirtualMachineExtension.UpdateDefinition;
    using System.Collections.Generic;
    using VirtualMachineExtension.Definition;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Implementation of VirtualMachineExtension.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVFeHRlbnNpb25JbXBs
    internal partial class VirtualMachineExtensionImpl :
        ExternalChildResource<IVirtualMachineExtension, VirtualMachineExtensionInner, IVirtualMachine, VirtualMachineImpl>,
        IVirtualMachineExtension,
        IDefinition<VirtualMachine.Definition.IWithCreate>,
        IUpdateDefinition<VirtualMachine.Update.IUpdate>,
        VirtualMachineExtension.Update.IUpdate
    {
        private IDictionary<string, object> publicSettings;
        private IDictionary<string, object> protectedSettings;
        ///GENMHASH:90947EC118BF5E99153E929733992E3D:2B5D1133EDB84DA652C7CF5DCF2A8534
        internal VirtualMachineExtensionImpl(string name, VirtualMachineImpl parent, VirtualMachineExtensionInner inner) :
            base(name, parent, inner)
        {
            InitializeSettings();
        }

        ///GENMHASH:712957B0CCD6FF08974D0F02498E499C:D9D3A1E2F88492FB40E494CFF83FC124
        internal static VirtualMachineExtensionImpl NewVirtualMachineExtension (string name, VirtualMachineImpl parent)
        {
            return new VirtualMachineExtensionImpl(name, parent,
                new VirtualMachineExtensionInner { Location = parent.RegionName });
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        ///GENMHASH:06BBF1077FAA38CC78AFC6E69E23FB58:2E1C21AC97868331579C4445DFF8B199
        public string PublisherName()
        {
            return Inner.Publisher;
        }

        ///GENMHASH:062496BB5D915E140ABE560B4E1D89B1:BF06270DCF74C3EB9DC7E255F7D93417
        public string TypeName()
        {
            return Inner.VirtualMachineExtensionType;
        }

        ///GENMHASH:59C1C6208A5C449165066C7E1FDE11ED:D218DCBF15733B59D5054B1545063FEA
        public string VersionName()
        {
            return Inner.TypeHandlerVersion;
        }

        ///GENMHASH:38030CBAE29B9F2F38D72F365E2E629A:E94F2D3DAC3B970EABC385A12F44BB26
        public bool AutoUpgradeMinorVersionEnabled()
        {
            return Inner.AutoUpgradeMinorVersion.Value;
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

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:497CEBB37227D75C20D80EC55C7C4F14
        public IReadOnlyDictionary<string, string> Tags()
        {
            IDictionary<string, string> tags = Inner.Tags;
            if (tags == null)
            {
                tags = new Dictionary<string, string>();
            }
            return new ReadOnlyDictionary<string, string>(tags);
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public string ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        ///GENMHASH:467F635EADCCCC617A72CEB57E5B3D41:7B7B2063CA85FFEC8E5F9CF53A22CED0
        public VirtualMachineExtensionImpl WithMinorVersionAutoUpgrade()
        {
            Inner.AutoUpgradeMinorVersion = true;
            return this;
        }

        ///GENMHASH:23B0698FE3BB00936E77BFAAD4E8C173:2897633350A3881BCCEECEB8CBDCFF63
        public VirtualMachineExtensionImpl WithoutMinorVersionAutoUpgrade()
        {
            Inner.AutoUpgradeMinorVersion = false;
            return this;
        }

        ///GENMHASH:FCA44D692D2CBD47AF19A7B5D9CEB263:ACF3758115981B4301C26F8F01A9CEB3
        public VirtualMachineExtensionImpl WithImage (IVirtualMachineExtensionImage image)
        {
            Inner.Publisher = image.PublisherName;
            Inner.VirtualMachineExtensionType = image.TypeName;
            Inner.TypeHandlerVersion = image.VersionName;
            return this;
        }

        ///GENMHASH:D09614E022482293C9A2EEE2C6E4098E:86E8D4D3B2BDB9EEBA09E6F348394801
        public VirtualMachineExtensionImpl WithPublisher(string extensionImagePublisherName)
        {
            Inner.Publisher = extensionImagePublisherName;
            return this;
        }

        ///GENMHASH:F4E714A8C40DF6CD0AE34FBA3BC4C770:79A077AE3BFC0D04AB2B4B8492338A57
        public VirtualMachineExtensionImpl WithPublicSetting(string key, object value)
        {
            if (this.publicSettings.ContainsKey(key))
            {
                this.publicSettings[key] = value;
            }
            else
            {
                this.publicSettings.Add(key, value);
            }
            return this;
        }

        ///GENMHASH:4E0AB82616606C4EEBD304EE7CA95448:C69FF63CB6446E393F7AC97CBA0B0631
        public VirtualMachineExtensionImpl WithProtectedSetting (string key, object value)
        {
            if (this.protectedSettings.ContainsKey(key))
            {
                this.protectedSettings[key] = value;
            }
            else
            {
                this.protectedSettings.Add(key, value);
            }
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
            Inner.VirtualMachineExtensionType = extensionImageTypeName;
            return this;
        }

        ///GENMHASH:5A056156A7C92738B7A05BFFB861E1B4:DA8B164AFF802F7E1F62BE36FA742A8D
        public VirtualMachineExtensionImpl WithVersion(string extensionImageVersionName)
        {
            Inner.TypeHandlerVersion = extensionImageVersionName;
            return this;
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:E462F242E1761228E205CEE8F760EDF9
        public VirtualMachineExtensionImpl WithTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this;
        }

        ///GENMHASH:FF80DD5A8C82E021759350836BD2FAD1:E70E0F84833F74462C0831B3C84D4A03
        public VirtualMachineExtensionImpl WithTag(string key, string value)
        {
            Inner.Tags.Add(key, value);
            return this;
        }

        ///GENMHASH:2345D3E100BA4B78504A2CC57A361F1E:250EC2907300FFA6125F7205F03A3E7F
        public VirtualMachineExtensionImpl WithoutTag(string key)
        {
            Inner.Tags.Remove(key);
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:915DD174AD20CD6005B14CC389FD3814
        public VirtualMachineImpl Attach()
        {
            this.NullifySettingsIfEmpty();
            return base.Parent.WithExtension(this);
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:0A7B0ED028812E214E22EAF2EB753FAB

        protected override async Task<VirtualMachineExtensionInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            var name = IsReference() ? ResourceUtils.NameFromResourceId(Inner.Id) : Inner.Name;

            return await Parent.Manager.Inner.VirtualMachineExtensions.GetAsync(Parent.ResourceGroupName, Parent.Name, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:C13D0601ACA269F4AA251080A5EAB8A3
        public async override Task<IVirtualMachineExtension> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            VirtualMachineExtensionInner inner = await Parent.Manager.Inner.VirtualMachineExtensions.CreateOrUpdateAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                Inner,
                cancellationToken);
            SetInner(inner);
            InitializeSettings();
            return this;
        }

        ///GENMHASH:F08598A17ADD014E223DFD77272641FF:E0CB43D17A95680E1FA5052B3D980A7C
        public async override Task<IVirtualMachineExtension> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.NullifySettingsIfEmpty();
            if (this.IsReference())
            {
                string extensionName = ResourceUtils.NameFromResourceId(Inner.Id);
                var resource = await Parent.Manager.Inner.VirtualMachineExtensions.GetAsync(
                    this.Parent.ResourceGroupName, 
                    this.Parent.Name, 
                    extensionName,
                    cancellationToken: cancellationToken);
                Inner.Publisher = resource.Publisher;
                Inner.VirtualMachineExtensionType = resource.VirtualMachineExtensionType;
                if (Inner.AutoUpgradeMinorVersion == null)
                {
                    Inner.AutoUpgradeMinorVersion = resource.AutoUpgradeMinorVersion;
                }
                IDictionary<string, object> existingPublicSettings = null;
                if (resource.Settings != null)
                {
                    if (resource.Settings is JObject)
                    {
                        // NOTE: Unlike Java, In C# the settings can be JObject which needs to be
                        // specially handled. In Java it is an Object that represents Dictionary.
                        //
                        var jObject = (JObject)(resource.Settings);
                        existingPublicSettings = jObject.ToObject<Dictionary<string, object>>();
                    }
                    else
                    {
                        existingPublicSettings = resource.Settings as IDictionary<string, object>;
                    }
                }
                if (existingPublicSettings != null && existingPublicSettings.Count > 0)
                {
                    IDictionary<string, object> newPublicSettings = Inner.Settings as IDictionary<string, object>;
                    if (newPublicSettings == null)
                    {
                        Inner.Settings = new Dictionary<string, object>();
                        newPublicSettings = Inner.Settings as IDictionary<string, object>;
                    }
                    foreach (var setting in existingPublicSettings)
                    {
                        if (!newPublicSettings.ContainsKey(setting.Key))
                        {
                            newPublicSettings.Add(setting.Key, setting.Value);
                        }
                    }
                }
            }
            return await this.CreateAsync(cancellationToken);
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:4ECAD0C81AFE0A2718CE4BFF1EC4C29F
        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Parent.Manager.Inner.VirtualMachineExtensions.DeleteAsync(this.Parent.ResourceGroupName, Parent.Name, Name(), cancellationToken);
        }

        /// <returns>true if this is just a reference to the extension.</returns>
        /// <returns><p></returns>
        /// <returns>An extension will present as a reference when the parent virtual machine was fetched using</returns>
        /// <returns>VM list, a GET on a specific VM will return fully expanded extension details.</returns>
        /// <returns></p></returns>

        ///GENMHASH:5034C466FD077AE4C3BB0E8BB3EBEFB3:6AC48AA816918FEA6040CB47074973FD
        public bool IsReference()
        {
            return Inner.Name == null;
        }

        ///GENMHASH:85C90F4F6082200D94668A66AEFC6726:7DA1F1B9237639B669A209E12821D17A
        private void NullifySettingsIfEmpty()
        {
            if (this.publicSettings.Count == 0)
            {
                Inner.Settings = null;
            }

            if (this.protectedSettings.Count == 0)
            {
                Inner.ProtectedSettings = null;
            }
        }

        ///GENMHASH:1DE96DF05FCD164699FABE2722D3B823:DDB96B1018AF16195187204FD1A5F7F0
        private void InitializeSettings ()
        {
            if (Inner.Settings == null)
            {
                this.publicSettings = new Dictionary<string, object>();
            }
            else if (Inner.Settings is JObject)
            {
                // NOTE: Unlike Java, In C# the settings can be JObject which needs to be
                // specially handled. In Java it is an Object that can be based to Dictionary.
                //
                var jObject = (JObject)(Inner.Settings);
                this.publicSettings = jObject.ToObject<Dictionary<string, object>>();
            }
            else
            {
                this.publicSettings = Inner.Settings as IDictionary<string, object>;
            }
            // Ensure inner settings references the same object
            //
            Inner.Settings = this.publicSettings;
            if (Inner.ProtectedSettings == null)
            {
                this.protectedSettings = new Dictionary<string, object>();
            }
            else if (Inner.ProtectedSettings is JObject)
            {
                // NOTE: Unlike Java, In C# the protectedSettings can be JObject which needs to be
                // specially handled. In Java it is an Object that can be based to Dictionary.
                //
                var jObject = (JObject)(Inner.ProtectedSettings);
                this.protectedSettings = jObject.ToObject<Dictionary<string, object>>();
            }
            else
            {
                this.protectedSettings = Inner.ProtectedSettings as IDictionary<string, object>;
            }
            // Ensure inner protected settings references the same object
            //
            Inner.ProtectedSettings = this.protectedSettings;
        }

        VirtualMachine.Update.IUpdate ISettable<VirtualMachine.Update.IUpdate>.Parent()
        {
            return this.Parent;
        }

        ///GENMHASH:6B59C2739A29FB6F0BBF714626714133:05527B968431192026F084474E921BE9
        public async Task<Models.VirtualMachineExtensionInstanceView> GetInstanceViewAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var extensionInner = await Parent.Manager.Inner.VirtualMachineExtensions.GetAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name(),
                "instanceView",
                cancellationToken);
            return extensionInner.InstanceView;
        }

        ///GENMHASH:955D294F6E1F6B9054F1EABE1AE05EA2:3B40334C37474720957E6C6B24FC2D63
        public VirtualMachineExtensionInstanceView GetInstanceView()
        {
            return ResourceManager.Fluent.Core.Extensions.Synchronize(() => GetInstanceViewAsync());
        }
    }
}
