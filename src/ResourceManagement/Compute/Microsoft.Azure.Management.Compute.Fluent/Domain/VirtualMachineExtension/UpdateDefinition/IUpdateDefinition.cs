// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent;

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to specify the type of the virtual machine
    /// extension version this extension is based on.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithVersion<ParentT> 
    {
        /// <summary>
        /// Specifies the version of the virtual machine image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">The version name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithAttach<ParentT> WithVersion(string extensionImageVersionName);
    }

    /// <summary>
    /// The final stage of the virtual machine extension definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the virtual machine extension definition
    /// can be attached to the parent virtual machine definition using VirtualMachineExtension.UpdateDefinitionStages.WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of VirtualMachineExtension.UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        IWithAutoUpgradeMinorVersion<ParentT>,
        IWithSettings<ParentT>,
        IWithTags<ParentT>
    {
    }

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to specify the type of the virtual machine
    /// extension image this extension is based on.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithType<ParentT> 
    {
        /// <summary>
        /// Specifies the type of the virtual machine extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">The image type name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithVersion<ParentT> WithType(string extensionImageTypeName);
    }

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to specify the tags.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithTags<ParentT> 
    {
        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the resource definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithAttach<ParentT> WithTag(string key, string value);

        /// <summary>
        /// Specifies tags for the resource as a Map.
        /// </summary>
        /// <param name="tags">A Map of tags.</param>
        /// <return>The next stage of the resource definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithAttach<ParentT> WithTags(IDictionary<string,string> tags);
    }

    /// <summary>
    /// The first stage of a virtual machine extension definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        IWithImageOrPublisher<ParentT>
    {
    }

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to enable or disable auto upgrade of the
    /// extension when when a new minor version of virtual machine extension image gets published.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAutoUpgradeMinorVersion<ParentT> 
    {
        /// <summary>
        /// Enables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithAttach<ParentT> WithMinorVersionAutoUpgrade();

        /// <summary>
        /// Disables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithAttach<ParentT> WithoutMinorVersionAutoUpgrade();
    }

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to specify the publisher of the
    /// virtual machine extension image this extension is based on.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithPublisher<ParentT> 
    {
        /// <summary>
        /// Specifies the name of the virtual machine extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">The publisher name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithType<ParentT> WithPublisher(string extensionImagePublisherName);
    }

    /// <summary>
    /// The entirety of a virtual machine extension definition as a part of parent update.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithImageOrPublisher<ParentT>,
        IWithPublisher<ParentT>,
        IWithType<ParentT>,
        IWithVersion<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to specify the public and private settings.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithSettings<ParentT> 
    {
        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">The key of a private settings entry.</param>
        /// <param name="value">The value of the private settings entry.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithAttach<ParentT> WithProtectedSetting(string key, object value);

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">The key of a public settings entry.</param>
        /// <param name="value">The value of the public settings entry.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithAttach<ParentT> WithPublicSetting(string key, object value);

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">The public settings.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithAttach<ParentT> WithPublicSettings(IDictionary<string,object> settings);

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">The private settings.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithAttach<ParentT> WithProtectedSettings(IDictionary<string,object> settings);
    }

    /// <summary>
    /// The stage of the virtual machine extension allowing to specify extension image or specify name of the
    /// virtual machine extension publisher.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithImageOrPublisher<ParentT>  :
        IWithPublisher<ParentT>
    {
        /// <summary>
        /// Specifies the virtual machine extension image to use.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition.IWithAttach<ParentT> WithImage(IVirtualMachineExtensionImage image);
    }
}