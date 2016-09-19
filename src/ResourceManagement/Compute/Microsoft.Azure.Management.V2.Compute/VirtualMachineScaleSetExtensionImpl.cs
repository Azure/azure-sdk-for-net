/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    using Management.Compute.Models;
    using Resource.Core.ChildResourceActions;

    /// <summary>
    /// Implementation of {@link VirtualMachineScaleSetExtension}.
    /// </summary>
    public partial class VirtualMachineScaleSetExtensionImpl  :
        ChildResource<VirtualMachineScaleSetExtensionInner, VirtualMachineScaleSetImpl>,
        IVirtualMachineScaleSetExtension,
        IDefinition<IWithCreate>,
        IUpdateDefinition<IWithApplicable>,
        VirtualMachineScaleSetExtension.Update.IUpdate
    {
        private IDictionary<string,object> publicSettings;
        private IDictionary<string,object> protectedSettings;
        internal  VirtualMachineScaleSetExtensionImpl (VirtualMachineScaleSetExtensionInner inner, VirtualMachineScaleSetImpl parent) : base(inner.Id, inner, parent)
        {

            //$ VirtualMachineScaleSetImpl parent) {
            //$ super(inner, parent);
            //$ initializeSettings();
            //$ }

        }

        public string Name
        {
            get
            {
            //$ return this.inner().name();


                return null;
            }
        }
        public string PublisherName
        {
            get
            {
            //$ return this.inner().publisher();


                return null;
            }
        }
        public string TypeName
        {
            get
            {
            //$ return this.inner().type();


                return null;
            }
        }
        public string VersionName
        {
            get
            {
            //$ return this.inner().typeHandlerVersion();


                return null;
            }
        }
        public bool? AutoUpgradeMinorVersionEnabled
        {
            get
            {
            //$ return this.inner().autoUpgradeMinorVersion();


                return null;
            }
        }
        public IDictionary<string,object> PublicSettings
        {
            get
            {
            //$ return Collections.unmodifiableMap(this.publicSettings);


                return null;
            }
        }
        public string PublicSettingsAsJsonString
        {
            get
            {
            //$ return null;


                return null;
            }
        }
        public string ProvisioningState
        {
            get
            {
            //$ return this.inner().provisioningState();


                return null;
            }
        }
        public VirtualMachineScaleSetExtensionImpl WithAutoUpgradeMinorVersionEnabled ()
        {

            //$ this.inner().withAutoUpgradeMinorVersion(true);
            //$ return this;

            return this;
        }

        public VirtualMachineScaleSetExtensionImpl WithAutoUpgradeMinorVersionDisabled ()
        {

            //$ this.inner().withAutoUpgradeMinorVersion(false);
            //$ return this;

            return this;
        }

        /*
        //TODO Uncomment this after moving IVirtualMachineExtensionImage from Java
        //
        public VirtualMachineScaleSetExtensionImpl WithImage (IVirtualMachineExtensionImage image)
        {

            //$ this.inner().withPublisher(image.publisherName())
            //$ .withType(image.typeName())
            //$ .withTypeHandlerVersion(image.versionName());
            //$ return this;

            return this;
        }
        */

        public VirtualMachineScaleSetExtensionImpl WithPublisher (string extensionImagePublisherName)
        {

            //$ this.inner().withPublisher(extensionImagePublisherName);
            //$ return this;

            return this;
        }

        public VirtualMachineScaleSetExtensionImpl WithPublicSetting (string key, object value)
        {

            //$ this.publicSettings.put(key, value);
            //$ return this;

            return this;
        }

        public VirtualMachineScaleSetExtensionImpl WithProtectedSetting (string key, object value)
        {

            //$ this.protectedSettings.put(key, value);
            //$ return this;

            return this;
        }

        public VirtualMachineScaleSetExtensionImpl WithPublicSettings (IDictionary<string,object> settings)
        {

            //$ this.publicSettings.clear();
            //$ this.publicSettings.putAll(settings);
            //$ return this;

            return this;
        }

        public VirtualMachineScaleSetExtensionImpl WithProtectedSettings (IDictionary<string,object> settings)
        {

            //$ this.protectedSettings.clear();
            //$ this.protectedSettings.putAll(settings);
            //$ return this;

            return this;
        }

        public VirtualMachineScaleSetExtensionImpl WithType (string extensionImageTypeName)
        {

            //$ this.inner().withType(extensionImageTypeName);
            //$ return this;

            return this;
        }

        public VirtualMachineScaleSetExtensionImpl WithVersion (string extensionImageVersionName)
        {

            //$ this.inner().withTypeHandlerVersion(extensionImageVersionName);
            //$ return this;

            return this;
        }

        private void NullifySettingsIfEmpty ()
        {

            //$ if (this.publicSettings.size() == 0) {
            //$ this.inner().withSettings(null);
            //$ }
            //$ if (this.protectedSettings.size() == 0) {
            //$ this.inner().withProtectedSettings(null);
            //$ }
            //$ }

        }

        private void InitializeSettings ()
        {

            //$ if (this.inner().settings() == null) {
            //$ this.publicSettings = new LinkedHashMap<>();
            //$ this.inner().withSettings(this.publicSettings);
            //$ } else {
            //$ this.publicSettings = (LinkedHashMap<String, Object>) this.inner().settings();
            //$ }
            //$ 
            //$ if (this.inner().protectedSettings() == null) {
            //$ this.protectedSettings = new LinkedHashMap<>();
            //$ this.inner().withProtectedSettings(this.protectedSettings);
            //$ } else {
            //$ this.protectedSettings = (LinkedHashMap<String, Object>) this.inner().protectedSettings();
            //$ }
            //$ }

        }

        public VirtualMachineScaleSetImpl Attach()
        {
            return null;
        }
        VirtualMachineScaleSet.Update.IUpdate ISettable<VirtualMachineScaleSet.Update.IUpdate>.Parent()
        {
            return base.Parent;
        }
    }
}