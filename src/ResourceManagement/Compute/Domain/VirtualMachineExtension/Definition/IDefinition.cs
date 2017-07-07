// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Compute.Fluent;

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to specify the tags.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTags<ParentT> 
    {
        /// <summary>
        /// Adds a tag to the virtual machine extension.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAttach<ParentT> WithTag(string key, string value);

        /// <summary>
        /// Specifies tags for the virtual machine extension.
        /// </summary>
        /// <param name="tags">The tags to associate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAttach<ParentT> WithTags(IDictionary<string,string> tags);
    }

    /// <summary>
    /// The final stage of the virtual machine extension definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAutoUpgradeMinorVersion<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithSettings<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithTags<ParentT>
    {
    }

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to specify the type of the virtual machine
    /// extension image this extension is based on.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithType<ParentT> 
    {
        /// <summary>
        /// Specifies the type of the virtual machine extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">The image type name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithVersion<ParentT> WithType(string extensionImageTypeName);
    }

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to specify extension image or specify name of
    /// the virtual machine extension publisher.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithImageOrPublisher<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithPublisher<ParentT>
    {
        /// <summary>
        /// Specifies the virtual machine extension image to use.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAttach<ParentT> WithImage(IVirtualMachineExtensionImage image);
    }

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to enable or disable auto upgrade of the
    /// extension when when a new minor version of virtual machine extension image gets published.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAutoUpgradeMinorVersion<ParentT> 
    {
        /// <summary>
        /// Enables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAttach<ParentT> WithMinorVersionAutoUpgrade();

        /// <summary>
        /// Disables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAttach<ParentT> WithoutMinorVersionAutoUpgrade();
    }

    /// <summary>
    /// The first stage of a virtual machine extension definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithImageOrPublisher<ParentT>
    {
    }

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to specify the type of the virtual machine
    /// extension version this extension is based on.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithVersion<ParentT> 
    {
        /// <summary>
        /// Specifies the version of the virtual machine image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">The version name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAttach<ParentT> WithVersion(string extensionImageVersionName);
    }

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to specify the publisher of the
    /// virtual machine extension image this extension is based on.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPublisher<ParentT> 
    {
        /// <summary>
        /// Specifies the name of the virtual machine extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">The publisher name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithType<ParentT> WithPublisher(string extensionImagePublisherName);
    }

    /// <summary>
    /// The entirety of a virtual machine extension definition as a part of parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithImageOrPublisher<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithPublisher<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithType<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithVersion<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the virtual machine extension definition allowing to specify the public and private settings.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSettings<ParentT> 
    {
        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">The key of a private settings entry.</param>
        /// <param name="value">The value of the private settings entry.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAttach<ParentT> WithProtectedSetting(string key, object value);

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">The key of a public settings entry.</param>
        /// <param name="value">The value of the public settings entry.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAttach<ParentT> WithPublicSetting(string key, object value);

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">The public settings.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAttach<ParentT> WithPublicSettings(IDictionary<string,object> settings);

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">The private settings.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition.IWithAttach<ParentT> WithProtectedSettings(IDictionary<string,object> settings);
    }
}