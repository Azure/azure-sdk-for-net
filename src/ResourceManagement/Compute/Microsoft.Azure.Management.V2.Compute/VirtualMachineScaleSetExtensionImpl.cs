// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.V2.Compute
{
    using Resource.Core;
    using System.Collections.Generic;
    using Management.Compute.Models;
    using Resource.Core.ChildResourceActions;

    /// <summary>
    /// Implementation of {@link VirtualMachineScaleSetExtension}.
    /// </summary>
    internal partial class VirtualMachineScaleSetExtensionImpl :
        ChildResource<VirtualMachineScaleSetExtensionInner,
            VirtualMachineScaleSetImpl,
            IVirtualMachineScaleSet>,
        IVirtualMachineScaleSetExtension,
        VirtualMachineScaleSetExtension.Definition.IDefinition<VirtualMachineScaleSet.Definition.IWithCreate>,
        VirtualMachineScaleSetExtension.UpdateDefinition.IUpdateDefinition<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApply>,
        VirtualMachineScaleSetExtension.Update.IUpdate
    {
        private IDictionary<string,object> publicSettings;
        private IDictionary<string,object> protectedSettings;
        internal VirtualMachineScaleSetExtensionImpl (VirtualMachineScaleSetExtensionInner inner, VirtualMachineScaleSetImpl parent) 
            : base(inner.Id, inner, parent)
        {
            InitializeSettings();
        }

        public override string Name
        {
            get
            {
                return this.Inner.Name;
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
                return this.Inner.Type;
            }
        }
        public string VersionName
        {
            get
            {
                return this.Inner.TypeHandlerVersion;
            }
        }
        public bool? AutoUpgradeMinorVersionEnabled
        {
            get
            {
                return this.Inner.AutoUpgradeMinorVersion;
            }
        }
        public IDictionary<string, object> PublicSettings
        {
            get
            {
                return this.publicSettings;
            }
        }
        public string PublicSettingsAsJsonString
        {
            get
            {
                return null;
            }
        }
        public string ProvisioningState
        {
            get
            {
                return this.Inner.ProvisioningState;
            }
        }
        public VirtualMachineScaleSetExtensionImpl WithMinorVersionAutoUpgrade ()
        {
            this.Inner.AutoUpgradeMinorVersion = true;
            return this;
        }

        public VirtualMachineScaleSetExtensionImpl WithoutMinorVersionAutoUpgrade ()
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

        public VirtualMachineScaleSetExtensionImpl WithPublicSetting (string key, object value)
        {
            this.publicSettings.Add(key, value);
            return this;
        }

        public VirtualMachineScaleSetExtensionImpl WithProtectedSetting (string key, object value)
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

        public VirtualMachineScaleSetExtensionImpl WithProtectedSettings (IDictionary<string,object> settings)
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