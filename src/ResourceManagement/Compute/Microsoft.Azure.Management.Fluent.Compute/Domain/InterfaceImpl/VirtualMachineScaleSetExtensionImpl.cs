// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition;
    using Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition;
    internal partial class VirtualMachineScaleSetExtensionImpl
    {
        /// <summary>
        /// Specifies the type of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">extensionImageTypeName the image type name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithVersion<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithType<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithType(string extensionImageTypeName)
        {
            return this.WithType(extensionImageTypeName) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithVersion<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the type of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">extensionImageTypeName an image type name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithVersion<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithType<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>.WithType(string extensionImageTypeName)
        {
            return this.WithType(extensionImageTypeName) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithVersion<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies the name of the publisher of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImagePublisherName">extensionImagePublisherName a publisher name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithType<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithPublisher<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithPublisher(string extensionImagePublisherName)
        {
            return this.WithPublisher(extensionImagePublisherName) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithType<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the name of the virtual machine scale set extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">extensionImagePublisherName the publisher name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithType<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithPublisher<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>.WithPublisher(string extensionImagePublisherName)
        {
            return this.WithPublisher(extensionImagePublisherName) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithType<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <returns>the public settings of the virtual machine scale set extension as key value pairs</returns>
        System.Collections.Generic.IDictionary<string, object> Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSetExtension.PublicSettings
        {
            get
            {
                return this.PublicSettings as System.Collections.Generic.IDictionary<string, object>;
            }
        }
        /// <returns>the version name of the virtual machine scale set extension image this extension is created from</returns>
        string Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSetExtension.VersionName
        {
            get
            {
                return this.VersionName as string;
            }
        }
        /// <returns>the type name of the virtual machine scale set extension image this extension is created from</returns>
        string Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSetExtension.TypeName
        {
            get
            {
                return this.TypeName as string;
            }
        }
        /// <returns>the provisioning state of this virtual machine scale set extension</returns>
        string Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSetExtension.ProvisioningState
        {
            get
            {
                return this.ProvisioningState as string;
            }
        }
        /// <returns>the publisher name of the virtual machine scale set extension image this extension is created from</returns>
        string Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSetExtension.PublisherName
        {
            get
            {
                return this.PublisherName as string;
            }
        }
        /// <returns>the public settings of the virtual machine extension as a JSON string</returns>
        string Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSetExtension.PublicSettingsAsJsonString
        {
            get
            {
                return this.PublicSettingsAsJsonString as string;
            }
        }
        /// <returns>true if this extension is configured to upgrade automatically when a new minor version of</returns>
        /// <returns>the extension image that this extension based on is published</returns>
        bool? Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSetExtension.AutoUpgradeMinorVersionEnabled
        {
            get
            {
                return this.AutoUpgradeMinorVersionEnabled;
            }
        }
        /// <summary>
        /// Specifies the virtual machine scale set extension image to use.
        /// </summary>
        /// <param name="image">image an extension image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithImageOrPublisher<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithImage(IVirtualMachineExtensionImage image)
        {
            return this.WithImage(image) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the virtual machine scale set extension image to use.
        /// </summary>
        /// <param name="image">image an extension image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithImageOrPublisher<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>.WithImage(IVirtualMachineExtensionImage image)
        {
            return this.WithImage(image) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies the version of the virtual machine scale set image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">extensionImageVersionName the version name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithVersion<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithVersion(string extensionImageVersionName)
        {
            return this.WithVersion(extensionImageVersionName) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the version of the virtual machine scale set image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">extensionImageVersionName a version name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithVersion<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>.WithVersion(string extensionImageVersionName)
        {
            return this.WithVersion(extensionImageVersionName) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Disables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IWithAutoUpgradeMinorVersion.WithoutMinorVersionAutoUpgrade()
        {
            return this.WithoutMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Enables auto-upgrading of the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IWithAutoUpgradeMinorVersion.WithMinorVersionAutoUpgrade()
        {
            return this.WithMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Disables auto upgrading the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithoutMinorVersionAutoUpgrade()
        {
            return this.WithoutMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Enables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithMinorVersionAutoUpgrade()
        {
            return this.WithMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Disables auto upgrade of the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>.WithoutMinorVersionAutoUpgrade()
        {
            return this.WithoutMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Enables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>.WithMinorVersionAutoUpgrade()
        {
            return this.WithMinorVersionAutoUpgrade() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>.Attach()
        {
            return this.Attach() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings.WithPublicSettings(IDictionary<string, object> settings)
        {
            return this.WithPublicSettings(settings) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings.WithProtectedSettings(IDictionary<string, object> settings)
        {
            return this.WithProtectedSettings(settings) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings.WithPublicSetting(string key, object value)
        {
            return this.WithPublicSetting(key, value) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IWithSettings.WithProtectedSetting(string key, object value)
        {
            return this.WithProtectedSetting(key, value) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Fluent.Resource.Core.IChildResource<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineScaleSet>.Name
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
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithPublicSettings(IDictionary<string, object> settings)
        {
            return this.WithPublicSettings(settings) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithProtectedSettings(IDictionary<string, object> settings)
        {
            return this.WithProtectedSettings(settings) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithPublicSetting(string key, object value)
        {
            return this.WithPublicSetting(key, value) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithSettings<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>.WithProtectedSetting(string key, object value)
        {
            return this.WithProtectedSetting(key, value) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>.WithPublicSettings(IDictionary<string, object> settings)
        {
            return this.WithPublicSettings(settings) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>.WithProtectedSettings(IDictionary<string, object> settings)
        {
            return this.WithProtectedSettings(settings) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>.WithPublicSetting(string key, object value)
        {
            return this.WithPublicSetting(key, value) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply> Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>.WithProtectedSetting(string key, object value)
        {
            return this.WithProtectedSetting(key, value) as Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Compute.VirtualMachineScaleSet.Update.IWithApply>;
        }

    }
}