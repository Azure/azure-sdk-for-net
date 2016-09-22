// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

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
    public partial class VirtualMachineScaleSetExtensionImpl 
    {
        /// <summary>
        /// Specifies the type of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">extensionImageTypeName the image type name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithType (string extensionImageTypeName) {
            return this.WithType( extensionImageTypeName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the type of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">extensionImageTypeName the image type name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithType (string extensionImageTypeName) {
            return this.WithType( extensionImageTypeName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>;
        }

        /// <summary>
        /// Specifies the name of the virtual machine scale set extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">extensionImagePublisherName the publisher name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithPublisher<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithPublisher (string extensionImagePublisherName) {
            return this.WithPublisher( extensionImagePublisherName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the name of the virtual machine scale set extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">extensionImagePublisherName the publisher name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithPublisher<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithPublisher (string extensionImagePublisherName) {
            return this.WithPublisher( extensionImagePublisherName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>;
        }

        /// <returns>the public settings of the virtual machine scale set extension as key value pairs</returns>
        System.Collections.Generic.IDictionary<string,object> Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetExtension.PublicSettings
        {
            get
            {
                return this.PublicSettings as System.Collections.Generic.IDictionary<string,object>;
            }
        }
        /// <returns>the version name of the virtual machine scale set extension image this extension is created from</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetExtension.VersionName
        {
            get
            {
                return this.VersionName as string;
            }
        }
        /// <returns>the type name of the virtual machine scale set extension image this extension is created from</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetExtension.TypeName
        {
            get
            {
                return this.TypeName as string;
            }
        }
        /// <returns>the provisioning state of this virtual machine scale set extension</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetExtension.ProvisioningState
        {
            get
            {
                return this.ProvisioningState as string;
            }
        }
        /// <returns>the publisher name of the virtual machine scale set extension image this extension is created from</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetExtension.PublisherName
        {
            get
            {
                return this.PublisherName as string;
            }
        }
        /// <returns>the public settings of the virtual machine extension as a json string</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetExtension.PublicSettingsAsJsonString
        {
            get
            {
                return this.PublicSettingsAsJsonString as string;
            }
        }
        /// <returns>true if this extension is configured to upgrade automatically when a new minor version of</returns>
        /// <returns>virtual machine scale set extension image that this extension based on is published</returns>
        bool? Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetExtension.AutoUpgradeMinorVersionEnabled
        {
            get
            {
                return this.AutoUpgradeMinorVersionEnabled;
            }
        }
        /// <summary>
        /// Specifies the virtual machine scale set extension image to use.
        /// </summary>
        /// <param name="image">image the image</param>
        /// <returns>the next stage of the definition</returns>
        ///
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithImageOrPublisher<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithImage (IVirtualMachineExtensionImage image) {
            return this.WithImage( image) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the virtual machine scale set extension image to use.
        /// </summary>
        /// <param name="image">image the image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithImageOrPublisher<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithImage (IVirtualMachineExtensionImage image) {
            return this.WithImage( image) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>;
        }

        /// <summary>
        /// Specifies the version of the virtual machine scale set image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">extensionImageVersionName the version name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithVersion (string extensionImageVersionName) {
            return this.WithVersion( extensionImageVersionName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the version of the virtual machine scale set image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">extensionImageVersionName the version name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithVersion (string extensionImageVersionName) {
            return this.WithVersion( extensionImageVersionName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>;
        }

        /// <summary>
        /// enables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAutoUpgradeMinorVersion.WithAutoUpgradeMinorVersionEnabled () {
            return this.WithAutoUpgradeMinorVersionEnabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// enables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAutoUpgradeMinorVersion.WithAutoUpgradeMinorVersionDisabled () {
            return this.WithAutoUpgradeMinorVersionDisabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// enables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithAutoUpgradeMinorVersionEnabled () {
            return this.WithAutoUpgradeMinorVersionEnabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// disables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithAutoUpgradeMinorVersionDisabled () {
            return this.WithAutoUpgradeMinorVersionDisabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// enables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithAutoUpgradeMinorVersionEnabled () {
            return this.WithAutoUpgradeMinorVersionEnabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>;
        }

        /// <summary>
        /// disables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithAutoUpgradeMinorVersionDisabled () {
            return this.WithAutoUpgradeMinorVersionDisabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings.WithPublicSettings (IDictionary<string,object> settings) {
            return this.WithPublicSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings.WithProtectedSettings (IDictionary<string,object> settings) {
            return this.WithProtectedSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings.WithPublicSetting (string key, object value) {
            return this.WithPublicSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings.WithProtectedSetting (string key, object value) {
            return this.WithProtectedSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.V2.Resource.Core.IChildResource.Name {
            get
            {
                return this.Name as string;
            }
        }
        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithPublicSettings (IDictionary<string,object> settings) {
            return this.WithPublicSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithProtectedSettings (IDictionary<string,object> settings) {
            return this.WithProtectedSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithPublicSetting (string key, object value) {
            return this.WithPublicSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithProtectedSetting (string key, object value) {
            return this.WithProtectedSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithPublicSettings (IDictionary<string,object> settings) {
            return this.WithPublicSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithProtectedSettings (IDictionary<string,object> settings) {
            return this.WithProtectedSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithPublicSetting (string key, object value) {
            return this.WithPublicSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable> Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>.WithProtectedSetting (string key, object value) {
            return this.WithProtectedSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IWithApplicable>;
        }

    }
}