/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    public partial class VirtualMachineExtensionImpl 
    {
        /// <summary>
        /// Adds a tag to the virtual machine extension.
        /// </summary>
        /// <param name="key">key the key for the tag</param>
        /// <param name="value">value the value for the tag</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithTags<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithTag (string key, string value) {
            return this.WithTag( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies tags for the virtual machine extension as a {@link Map}.
        /// </summary>
        /// <param name="tags">tags a {@link Map} of tags</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithTags<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithTags (IDictionary<string,string> tags) {
            return this.WithTags( tags) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">key the key for the tag</param>
        /// <param name="value">value the value for the tag</param>
        /// <returns>the next stage of the resource definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithTags<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithTag (string key, string value) {
            return this.WithTag( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies tags for the resource as a {@link Map}.
        /// </summary>
        /// <param name="tags">tags a {@link Map} of tags</param>
        /// <returns>the next stage of the resource definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithTags<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithTags (IDictionary<string,string> tags) {
            return this.WithTags( tags) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the type of the virtual machine extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">extensionImageTypeName the image type name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithType (string extensionImageTypeName) {
            return this.WithType( extensionImageTypeName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the type of the virtual machine extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">extensionImageTypeName the image type name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithType (string extensionImageTypeName) {
            return this.WithType( extensionImageTypeName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the name of the virtual machine extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">extensionImagePublisherName the publisher name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithPublisher<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithPublisher (string extensionImagePublisherName) {
            return this.WithPublisher( extensionImagePublisherName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the name of the virtual machine extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">extensionImagePublisherName the publisher name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithPublisher<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithPublisher (string extensionImagePublisherName) {
            return this.WithPublisher( extensionImagePublisherName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithType<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the virtual machine extension image to use.
        /// </summary>
        /// <param name="image">image the image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithImageOrPublisher<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithImage (IVirtualMachineExtensionImage image) {
            return this.WithImage( image) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the virtual machine extension image to use.
        /// </summary>
        /// <param name="image">image the image</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithImageOrPublisher<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithImage (IVirtualMachineExtensionImage image) {
            return this.WithImage( image) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the version of the virtual machine image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">extensionImageVersionName the version name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithVersion (string extensionImageVersionName) {
            return this.WithVersion( extensionImageVersionName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the version of the virtual machine image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">extensionImageVersionName the version name</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithVersion (string extensionImageVersionName) {
            return this.WithVersion( extensionImageVersionName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// enables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IWithAutoUpgradeMinorVersion.WithAutoUpgradeMinorVersionEnabled () {
            return this.WithAutoUpgradeMinorVersionEnabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate;
        }

        /// <summary>
        /// enables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IWithAutoUpgradeMinorVersion.WithAutoUpgradeMinorVersionDisabled () {
            return this.WithAutoUpgradeMinorVersionDisabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate;
        }

        /// <summary>
        /// enables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithAutoUpgradeMinorVersionEnabled () {
            return this.WithAutoUpgradeMinorVersionEnabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// disables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithAutoUpgradeMinorVersionDisabled () {
            return this.WithAutoUpgradeMinorVersionDisabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// enables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithAutoUpgradeMinorVersionEnabled () {
            return this.WithAutoUpgradeMinorVersionEnabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// disables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAutoUpgradeMinorVersion<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithAutoUpgradeMinorVersionDisabled () {
            return this.WithAutoUpgradeMinorVersionDisabled() as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IWithSettings.WithPublicSettings (IDictionary<string, object> settings) {
            return this.WithPublicSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IWithSettings.WithProtectedSettings (IDictionary<string, object> settings) {
            return this.WithProtectedSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IWithSettings.WithPublicSetting (string key, object value) {
            return this.WithPublicSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IWithSettings.WithProtectedSetting (string key, object value) {
            return this.WithProtectedSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins an update for a child resource.
        /// <p>
        /// This is the beginning of the builder pattern used to update child resources
        /// The final method completing the update and continue
        /// the actual parent resource update process in Azure is {@link Settable#parent()}.
        /// </summary>
        /// <returns>the stage of  parent resource update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.Parent () {
            return this.Parent as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <returns>the id of the external child resource</returns>
        string Microsoft.Azure.Management.V2.Resource.Core.IExternalChildResource<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension, IVirtualMachine>.Id
        {
            get
            {
                return this.Id as string;
            }
        }
        /// <returns>the public settings of the virtual machine extension as key value pairs</returns>
        System.Collections.Generic.IDictionary<string,object> Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension.PublicSettings
        {
            get
            {
                return this.PublicSettings as System.Collections.Generic.IDictionary<string,object>;
            }
        }
        /// <returns>the version name of the virtual machine extension image this extension is created from</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension.VersionName
        {
            get
            {
                return this.VersionName as string;
            }
        }
        /// <returns>the type name of the virtual machine extension image this extension is created from</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension.TypeName
        {
            get
            {
                return this.TypeName as string;
            }
        }

        /// TODO: Report bug - the return type was originally generated as
        /// Microsoft.Azure.Management.V2.Compute.VirtualMachineExtensionInstanceView
        /// <returns>the instance view of this virtual machine extension</returns>
        Microsoft.Azure.Management.Compute.Models.VirtualMachineExtensionInstanceView Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension.InstanceView
        {
            get
            {
                return this.InstanceView as Microsoft.Azure.Management.Compute.Models.VirtualMachineExtensionInstanceView;
            }
        }
        /// <returns>the provisioning state of this virtual machine extension</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension.ProvisioningState
        {
            get
            {
                return this.ProvisioningState as string;
            }
        }
        /// <returns>the tags for this virtual machine extension</returns>
        System.Collections.Generic.IDictionary<string,string> Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension.Tags
        {
            get
            {
                return this.Tags as System.Collections.Generic.IDictionary<string,string>;
            }
        }
        /// <returns>the publisher name of the virtual machine extension image this extension is created from</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension.PublisherName
        {
            get
            {
                return this.PublisherName as string;
            }
        }
        /// <returns>the public settings of the virtual machine extension as a json string</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension.PublicSettingsAsJsonString
        {
            get
            {
                return this.PublicSettingsAsJsonString as string;
            }
        }
        /// <returns>true if this extension is configured to upgrade automatically when a new minor version of</returns>
        /// <returns>virtual machine extension image that this extension based on is published</returns>
        bool? Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension.AutoUpgradeMinorVersionEnabled
        {
            get
            {
                return this.AutoUpgradeMinorVersionEnabled;
            }
        }
        /// <summary>
        /// Adds a tag to the virtual machine extension.
        /// </summary>
        /// <param name="key">key the key for the tag</param>
        /// <param name="value">value the value for the tag</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IWithTags.WithTag (string key, string value) {
            return this.WithTag( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate;
        }

        /// <summary>
        /// Removes a tag from the virtual machine extension.
        /// </summary>
        /// <param name="key">key the key of the tag to remove</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IWithTags.WithoutTag (string key) {
            return this.WithoutTag( key) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate;
        }

        /// <summary>
        /// Specifies tags for the virtual machine extension as a {@link Map}.
        /// </summary>
        /// <param name="tags">tags a {@link Map} of tags</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IWithTags.WithTags (IDictionary<string,string> tags) {
            return this.WithTags( tags) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate;
        }

        /**
         * TODO: Report bug - below Parent() method won't compile
        /// <returns>the parent of this child object</returns>
        ParentT Microsoft.Azure.Management.V2.Resource.Core.IChildResource<ParentT>.Parent () {
            return this.Parent() as ParentT;
        }
        **/

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension>.Refresh () {
            return this.Refresh() as Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithPublicSettings (IDictionary<string, object> settings) {
            return this.WithPublicSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithProtectedSettings (IDictionary<string, object> settings) {
            return this.WithProtectedSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithPublicSetting (string key, object value) {
            return this.WithPublicSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithProtectedSetting (string key, object value) {
            return this.WithProtectedSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithPublicSettings (IDictionary<string, object> settings) {
            return this.WithPublicSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithProtectedSettings (IDictionary<string, object> settings) {
            return this.WithProtectedSettings( settings) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithPublicSetting (string key, object value) {
            return this.WithPublicSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithSettings<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithProtectedSetting (string key, object value) {
            return this.WithProtectedSetting( key,  value) as Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

    }
}