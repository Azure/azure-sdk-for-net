// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Compute
{

    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Resource.Core;
    using System.Threading;
    using Management.Compute.Models;
    using Management.Compute;
    using System.Collections.ObjectModel;
    using Newtonsoft.Json;
    using Resource.Core.ChildResourceActions;

    /// <summary>
    /// Implementation of VirtualMachineExtension.
    /// </summary>
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
        internal  VirtualMachineExtensionImpl (string name, VirtualMachineImpl parent, VirtualMachineExtensionInner inner, IVirtualMachineExtensionsOperations client) : base(name, parent, inner)
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

        public string PublisherName
        {
            get
            {
                return this.Inner.Publisher;
            }
        }

        public string TypeName
        {
            get
            {
                return this.Inner.VirtualMachineExtensionType;
            }
        }

        public string VersionName
        {
            get
            {
                return this.Inner.TypeHandlerVersion;
            }
        }

        public bool AutoUpgradeMinorVersionEnabled
        {
            get
            {
                return this.Inner.AutoUpgradeMinorVersion.Value;
            }
        }

        public IDictionary<string,object> PublicSettings
        {
            get
            {
                return new ReadOnlyDictionary<string, object>(this.publicSettings);
            }
        }

        public string PublicSettingsAsJsonString
        {
            get
            {
                if (this.publicSettings == null)
                {
                    return null;
                }
                return JsonConvert.SerializeObject(this.publicSettings);
            }
        }

        public VirtualMachineExtensionInstanceView InstanceView
        {
            get
            {
             return this.Inner.InstanceView;
            }
        }
        public IDictionary<string,string> Tags
        {
            get
            {
                IDictionary<string, string> tags = this.Inner.Tags;
                if (tags == null)
                {
                    tags = new Dictionary<string, string>();
                }
                return new ReadOnlyDictionary<string, string>(tags);
            }
        }

        public string ProvisioningState
        {
            get
            {
                return this.Inner.ProvisioningState;
            }
        }

        public VirtualMachineExtensionImpl WithAutoUpgradeMinorVersionEnabled ()
        {
            this.Inner.AutoUpgradeMinorVersion = true;
            return this;
        }

        public VirtualMachineExtensionImpl WithAutoUpgradeMinorVersionDisabled ()
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

        public VirtualMachineExtensionImpl WithPublisher (string extensionImagePublisherName)
        {
            this.Inner.Publisher = extensionImagePublisherName;
            return this;
        }

        public VirtualMachineExtensionImpl WithPublicSetting (string key, object value)
        {
            this.publicSettings.Add(key, value);
            return this;
        }

        public VirtualMachineExtensionImpl WithProtectedSetting (string key, object value)
        {

            this.protectedSettings.Add(key, value);
            return this;
        }

        public VirtualMachineExtensionImpl WithPublicSettings (IDictionary<string, object> settings)
        {
            this.publicSettings.Clear();
            foreach (var item in settings)
            {
                this.WithPublicSetting(item.Key, item.Value);
            }
            return this;
        }

        public VirtualMachineExtensionImpl WithProtectedSettings (IDictionary<string, object> settings)
        {
            this.protectedSettings.Clear();
            foreach (var item in settings)
            {
                this.WithProtectedSetting(item.Key, item.Value);
            }
            return this;
        }

        public VirtualMachineExtensionImpl WithType (string extensionImageTypeName)
        {
            this.Inner.VirtualMachineExtensionType = extensionImageTypeName;
            return this;
        }

        public VirtualMachineExtensionImpl WithVersion (string extensionImageVersionName)
        {
            this.Inner.TypeHandlerVersion = extensionImageVersionName;
            return this;
        }

        public VirtualMachineExtensionImpl WithTags (IDictionary<string,string> tags)
        {
            this.Inner.Tags = tags;
            return this;
        }

        public VirtualMachineExtensionImpl WithTag (string key, string value)
        {
            this.Inner.Tags.Add(key, value);
            return this;
        }

        public VirtualMachineExtensionImpl WithoutTag (string key)
        {
            this.Inner.Tags.Remove(key);
            return this;
        }

        public VirtualMachineImpl Attach ()
        {
            this.NullifySettingsIfEmpty();
            return base.Parent.WithExtension(this);
        }

        public IVirtualMachineExtension Refresh()
        {
            string name;
            if (this.IsReference.Value) {
                name = ResourceUtils.NameFromResourceId(this.Inner.Id);
            } else {
                name = this.Inner.Name;
            }
            VirtualMachineExtensionInner inner = this.client.Get(this.Parent.ResourceGroupName, this.Parent.Name, name);
            this.SetInner(inner);
            return this;
        }

        public override async Task<IVirtualMachineExtension> CreateAsync (CancellationToken cancellationToken = default(CancellationToken))
        {
            VirtualMachineExtensionInner inner = await this.client.CreateOrUpdateAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name,
                this.Inner,
                cancellationToken);
            this.SetInner(inner);
            this.InitializeSettings();
            return this;
        }

        public override async Task<IVirtualMachineExtension> UpdateAsync (CancellationToken cancellationToken = default(CancellationToken))
        {
            this.NullifySettingsIfEmpty();
            if (this.IsReference.Value)
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

        public override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.client.DeleteAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name);
        }

        /// <returns>true if this is just a reference to the extension.</returns>
        /// <returns><p></returns>
        /// <returns>An extension will present as a reference when the parent virtual machine was fetched using</returns>
        /// <returns>VM list, a GET on a specific VM will return fully expanded extension details.</returns>
        /// <returns></p></returns>
        public bool? IsReference
        {
            get
            {
                return this.Inner.Name == null;
            }
        }

        private void NullifySettingsIfEmpty ()
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