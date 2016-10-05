// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{

    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update;
    internal partial class VirtualMachineScaleSetExtensionImpl 
    {
        /// <summary>
        /// Specifies the type of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">extensionImageTypeName the image type name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithVersion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithType<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>.WithType(string extensionImageTypeName) { 
            return this.WithType( extensionImageTypeName) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithVersion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the type of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">extensionImageTypeName an image type name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithVersion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithType<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>.WithType(string extensionImageTypeName) { 
            return this.WithType( extensionImageTypeName) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithVersion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies the name of the publisher of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImagePublisherName">extensionImagePublisherName a publisher name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithType<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithPublisher<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>.WithPublisher(string extensionImagePublisherName) { 
            return this.WithPublisher( extensionImagePublisherName) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithType<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the name of the virtual machine scale set extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">extensionImagePublisherName the publisher name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithType<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithPublisher<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>.WithPublisher(string extensionImagePublisherName) { 
            return this.WithPublisher( extensionImagePublisherName) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithType<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <returns>the public settings of the virtual machine scale set extension as key value pairs</returns>
        System.Collections.Generic.IDictionary<string,object> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.PublicSettings
        {
            get
            { 
            return this.PublicSettings() as System.Collections.Generic.IDictionary<string,object>;
            }
        }
        /// <returns>the version name of the virtual machine scale set extension image this extension is created from</returns>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.VersionName
        {
            get
            { 
            return this.VersionName() as string;
            }
        }
        /// <returns>the type name of the virtual machine scale set extension image this extension is created from</returns>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.TypeName
        {
            get
            { 
            return this.TypeName() as string;
            }
        }
        /// <returns>the provisioning state of this virtual machine scale set extension</returns>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.ProvisioningState
        {
            get
            { 
            return this.ProvisioningState() as string;
            }
        }
        /// <returns>the publisher name of the virtual machine scale set extension image this extension is created from</returns>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.PublisherName
        {
            get
            { 
            return this.PublisherName() as string;
            }
        }
        /// <returns>the public settings of the virtual machine extension as a JSON string</returns>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.PublicSettingsAsJsonString
        {
            get
            { 
            return this.PublicSettingsAsJsonString() as string;
            }
        }
        /// <returns>true if this extension is configured to upgrade automatically when a new minor version of</returns>
        /// <returns>the extension image that this extension based on is published</returns>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.AutoUpgradeMinorVersionEnabled
        {
            get
            { 
            return this.AutoUpgradeMinorVersionEnabled();
            }
        }
        /// <summary>
        /// Specifies the virtual machine scale set extension image to use.
        /// </summary>
        /// <param name="image">image an extension image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithImageOrPublisher<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>.WithImage(IVirtualMachineExtensionImage image) { 
            return this.WithImage( image) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the virtual machine scale set extension image to use.
        /// </summary>
        /// <param name="image">image an extension image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithImageOrPublisher<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>.WithImage(IVirtualMachineExtensionImage image) { 
            return this.WithImage( image) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies the version of the virtual machine scale set image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">extensionImageVersionName the version name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithVersion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>.WithVersion(string extensionImageVersionName) { 
            return this.WithVersion( extensionImageVersionName) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the version of the virtual machine scale set image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">extensionImageVersionName a version name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithVersion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>.WithVersion(string extensionImageVersionName) { 
            return this.WithVersion( extensionImageVersionName) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Disables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IWithAutoUpgradeMinorVersion.WithoutMinorVersionAutoUpgrade() { 
            return this.WithoutMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Enables auto-upgrading of the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IWithAutoUpgradeMinorVersion.WithMinorVersionAutoUpgrade() { 
            return this.WithMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Disables auto upgrading the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>.WithoutMinorVersionAutoUpgrade() { 
            return this.WithoutMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Enables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>.WithMinorVersionAutoUpgrade() { 
            return this.WithMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Disables auto upgrade of the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>.WithoutMinorVersionAutoUpgrade() { 
            return this.WithoutMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Enables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>.WithMinorVersionAutoUpgrade() { 
            return this.WithMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IWithSettings.WithPublicSettings(IDictionary<string,object> settings) { 
            return this.WithPublicSettings( settings) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IWithSettings.WithProtectedSettings(IDictionary<string,object> settings) { 
            return this.WithProtectedSettings( settings) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IWithSettings.WithPublicSetting(string key, object value) { 
            return this.WithPublicSetting( key,  value) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IWithSettings.WithProtectedSetting(string key, object value) { 
            return this.WithProtectedSetting( key,  value) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>.Name
        {
            get
            {
                return this.Name() as string;
            }
        }
        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>.WithPublicSettings(IDictionary<string,object> settings) { 
            return this.WithPublicSettings( settings) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>.WithProtectedSettings(IDictionary<string,object> settings) { 
            return this.WithProtectedSettings( settings) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>.WithPublicSetting(string key, object value) { 
            return this.WithPublicSetting( key,  value) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>.WithProtectedSetting(string key, object value) { 
            return this.WithProtectedSetting( key,  value) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>.WithPublicSettings(IDictionary<string,object> settings) { 
            return this.WithPublicSettings( settings) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>.WithProtectedSettings(IDictionary<string,object> settings) { 
            return this.WithProtectedSettings( settings) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>.WithPublicSetting(string key, object value) { 
            return this.WithPublicSetting( key,  value) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>.WithProtectedSetting(string key, object value) { 
            return this.WithProtectedSetting( key,  value) as Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IWithApply>;
        }

    }
}