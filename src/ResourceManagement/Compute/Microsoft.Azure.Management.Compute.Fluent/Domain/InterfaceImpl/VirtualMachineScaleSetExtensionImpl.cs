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

    internal partial class VirtualMachineScaleSetExtensionImpl
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <summary>
        /// Specifies the type of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">The image type name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.Definition.IWithVersion<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSetExtension.Definition.IWithType<VirtualMachineScaleSet.Definition.IWithCreate>.WithType(string extensionImageTypeName)
        {
            return this.WithType(extensionImageTypeName) as VirtualMachineScaleSetExtension.Definition.IWithVersion<VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the type of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">An image type name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IWithVersion<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetExtension.UpdateDefinition.IWithType<VirtualMachineScaleSet.Update.IWithApply>.WithType(string extensionImageTypeName)
        {
            return this.WithType(extensionImageTypeName) as VirtualMachineScaleSetExtension.UpdateDefinition.IWithVersion<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies the name of the publisher of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImagePublisherName">A publisher name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.Definition.IWithType<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSetExtension.Definition.IWithPublisher<VirtualMachineScaleSet.Definition.IWithCreate>.WithPublisher(string extensionImagePublisherName)
        {
            return this.WithPublisher(extensionImagePublisherName) as VirtualMachineScaleSetExtension.Definition.IWithType<VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the name of the virtual machine scale set extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">The publisher name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IWithType<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetExtension.UpdateDefinition.IWithPublisher<VirtualMachineScaleSet.Update.IWithApply>.WithPublisher(string extensionImagePublisherName)
        {
            return this.WithPublisher(extensionImagePublisherName) as VirtualMachineScaleSetExtension.UpdateDefinition.IWithType<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <return>The public settings of the virtual machine scale set extension as key value pairs.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, object> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.PublicSettings
        {
            get
            {
                return this.PublicSettings() as System.Collections.Generic.IReadOnlyDictionary<string, object>;
            }
        }

        /// <return>The version name of the virtual machine scale set extension image this extension is created from.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.VersionName
        {
            get
            {
                return this.VersionName() as string;
            }
        }

        /// <return>The type name of the virtual machine scale set extension image this extension is created from.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.TypeName
        {
            get
            {
                return this.TypeName() as string;
            }
        }

        /// <return>The provisioning state of this virtual machine scale set extension.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.ProvisioningState
        {
            get
            {
                return this.ProvisioningState() as string;
            }
        }

        /// <return>The publisher name of the virtual machine scale set extension image this extension is created from.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.PublisherName
        {
            get
            {
                return this.PublisherName() as string;
            }
        }

        /// <return>The public settings of the virtual machine extension as a JSON string.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension.PublicSettingsAsJsonString
        {
            get
            {
                return this.PublicSettingsAsJsonString() as string;
            }
        }

        /// <return>
        /// True if this extension is configured to upgrade automatically when a new minor version of
        /// the extension image that this extension based on is published.
        /// </return>
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
        /// <param name="image">An extension image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSetExtension.Definition.IWithImageOrPublisher<VirtualMachineScaleSet.Definition.IWithCreate>.WithImage(IVirtualMachineExtensionImage image)
        {
            return this.WithImage(image) as VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the virtual machine scale set extension image to use.
        /// </summary>
        /// <param name="image">An extension image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetExtension.UpdateDefinition.IWithImageOrPublisher<VirtualMachineScaleSet.Update.IWithApply>.WithImage(IVirtualMachineExtensionImage image)
        {
            return this.WithImage(image) as VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies the version of the virtual machine scale set image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">The version name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSetExtension.Definition.IWithVersion<VirtualMachineScaleSet.Definition.IWithCreate>.WithVersion(string extensionImageVersionName)
        {
            return this.WithVersion(extensionImageVersionName) as VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the version of the virtual machine scale set image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">A version name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetExtension.UpdateDefinition.IWithVersion<VirtualMachineScaleSet.Update.IWithApply>.WithVersion(string extensionImageVersionName)
        {
            return this.WithVersion(extensionImageVersionName) as VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Disables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSetExtension.Update.IUpdate VirtualMachineScaleSetExtension.Update.IWithAutoUpgradeMinorVersion.WithoutMinorVersionAutoUpgrade()
        {
            return this.WithoutMinorVersionAutoUpgrade() as VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Enables auto-upgrading of the extension with minor versions.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSetExtension.Update.IUpdate VirtualMachineScaleSetExtension.Update.IWithAutoUpgradeMinorVersion.WithMinorVersionAutoUpgrade()
        {
            return this.WithMinorVersionAutoUpgrade() as VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Disables auto upgrading the extension with minor versions.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSetExtension.Definition.IWithAutoUpgradeMinorVersion<VirtualMachineScaleSet.Definition.IWithCreate>.WithoutMinorVersionAutoUpgrade()
        {
            return this.WithoutMinorVersionAutoUpgrade() as VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Enables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSetExtension.Definition.IWithAutoUpgradeMinorVersion<VirtualMachineScaleSet.Definition.IWithCreate>.WithMinorVersionAutoUpgrade()
        {
            return this.WithMinorVersionAutoUpgrade() as VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Disables auto upgrade of the extension with minor versions.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetExtension.UpdateDefinition.IWithAutoUpgradeMinorVersion<VirtualMachineScaleSet.Update.IWithApply>.WithoutMinorVersionAutoUpgrade()
        {
            return this.WithoutMinorVersionAutoUpgrade() as VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Enables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetExtension.UpdateDefinition.IWithAutoUpgradeMinorVersion<VirtualMachineScaleSet.Update.IWithApply>.WithMinorVersionAutoUpgrade()
        {
            return this.WithMinorVersionAutoUpgrade() as VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualMachineScaleSet.Update.IWithApply Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<VirtualMachineScaleSet.Update.IWithApply>.Attach()
        {
            return this.Attach() as VirtualMachineScaleSet.Update.IWithApply;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">The public settings.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSetExtension.Update.IUpdate VirtualMachineScaleSetExtension.Update.IWithSettings.WithPublicSettings(IDictionary<string, object> settings)
        {
            return this.WithPublicSettings(settings) as VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">The private settings.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSetExtension.Update.IUpdate VirtualMachineScaleSetExtension.Update.IWithSettings.WithProtectedSettings(IDictionary<string, object> settings)
        {
            return this.WithProtectedSettings(settings) as VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">The key of a public settings entry.</param>
        /// <param name="value">The value of the public settings entry.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSetExtension.Update.IUpdate VirtualMachineScaleSetExtension.Update.IWithSettings.WithPublicSetting(string key, object value)
        {
            return this.WithPublicSetting(key, value) as VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">The key of a private settings entry.</param>
        /// <param name="value">The value of the private settings entry.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineScaleSetExtension.Update.IUpdate VirtualMachineScaleSetExtension.Update.IWithSettings.WithProtectedSetting(string key, object value)
        {
            return this.WithProtectedSetting(key, value) as VirtualMachineScaleSetExtension.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualMachineScaleSet.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<VirtualMachineScaleSet.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as VirtualMachineScaleSet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">The public settings.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSetExtension.Definition.IWithSettings<VirtualMachineScaleSet.Definition.IWithCreate>.WithPublicSettings(IDictionary<string, object> settings)
        {
            return this.WithPublicSettings(settings) as VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">The private settings.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSetExtension.Definition.IWithSettings<VirtualMachineScaleSet.Definition.IWithCreate>.WithProtectedSettings(IDictionary<string, object> settings)
        {
            return this.WithProtectedSettings(settings) as VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">The key of a public settings entry.</param>
        /// <param name="value">The value of the public settings entry.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSetExtension.Definition.IWithSettings<VirtualMachineScaleSet.Definition.IWithCreate>.WithPublicSetting(string key, object value)
        {
            return this.WithPublicSetting(key, value) as VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">The key of a private settings entry.</param>
        /// <param name="value">The value of the private settings entry.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate> VirtualMachineScaleSetExtension.Definition.IWithSettings<VirtualMachineScaleSet.Definition.IWithCreate>.WithProtectedSetting(string key, object value)
        {
            return this.WithProtectedSetting(key, value) as VirtualMachineScaleSetExtension.Definition.IWithAttach<VirtualMachineScaleSet.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">The public settings.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<VirtualMachineScaleSet.Update.IWithApply>.WithPublicSettings(IDictionary<string, object> settings)
        {
            return this.WithPublicSettings(settings) as VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">The private settings.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<VirtualMachineScaleSet.Update.IWithApply>.WithProtectedSettings(IDictionary<string, object> settings)
        {
            return this.WithProtectedSettings(settings) as VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">The key of a public settings entry.</param>
        /// <param name="value">The value of the public settings entry.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<VirtualMachineScaleSet.Update.IWithApply>.WithPublicSetting(string key, object value)
        {
            return this.WithPublicSetting(key, value) as VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply>;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">The key of a private settings entry.</param>
        /// <param name="value">The value of the private settings entry.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply> VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<VirtualMachineScaleSet.Update.IWithApply>.WithProtectedSetting(string key, object value)
        {
            return this.WithProtectedSetting(key, value) as VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<VirtualMachineScaleSet.Update.IWithApply>;
        }
    }
}