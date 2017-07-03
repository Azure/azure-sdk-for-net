// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage of a virtual machine scale set extension definition allowing to specify the type of the virtual machine
    /// scale set extension version this extension is based on.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IWithVersion<ParentT> 
    {
        /// <summary>
        /// Specifies the version of the virtual machine scale set image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">A version name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<ParentT> WithVersion(string extensionImageVersionName);
    }

    /// <summary>
    /// The stage of a virtual machine scale set extension allowing to specify an extension image or the name of the
    /// virtual machine extension publisher.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IWithImageOrPublisher<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithPublisher<ParentT>
    {
        /// <summary>
        /// Specifies the virtual machine scale set extension image to use.
        /// </summary>
        /// <param name="image">An extension image.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<ParentT> WithImage(IVirtualMachineExtensionImage image);
    }

    /// <summary>
    /// The stage of a virtual machine scale set extension definition allowing to specify the public and private settings.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IWithSettings<ParentT> 
    {
        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">The private settings.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<ParentT> WithProtectedSettings(IDictionary<string,object> settings);

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">The public settings.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<ParentT> WithPublicSettings(IDictionary<string,object> settings);

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">The key of a private settings entry.</param>
        /// <param name="value">The value of the private settings entry.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<ParentT> WithProtectedSetting(string key, object value);

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">The key of a public settings entry.</param>
        /// <param name="value">The value of the public settings entry.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<ParentT> WithPublicSetting(string key, object value);
    }

    /// <summary>
    /// The stage of a virtual machine scale set extension definition allowing to specify the publisher of the
    /// virtual machine scale set extension image this extension is based on.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IWithPublisher<ParentT> 
    {
        /// <summary>
        /// Specifies the name of the virtual machine scale set extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">The publisher name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithType<ParentT> WithPublisher(string extensionImagePublisherName);
    }

    /// <summary>
    /// The final stage of the virtual machine scale set extension definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAutoUpgradeMinorVersion<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithSettings<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a virtual machine scale set extension definition as a part of parent update.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithImageOrPublisher<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithPublisher<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithType<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithVersion<ParentT>,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a virtual machine scale set extension definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithImageOrPublisher<ParentT>
    {
    }

    /// <summary>
    /// The stage of a virtual machine scale set extension definition allowing to enable or disable auto upgrade of the
    /// extension when when a new minor version of virtual machine scale set extension image gets published.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IWithAutoUpgradeMinorVersion<ParentT> 
    {
        /// <summary>
        /// Enables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<ParentT> WithMinorVersionAutoUpgrade();

        /// <summary>
        /// Disables auto upgrade of the extension with minor versions.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithAttach<ParentT> WithoutMinorVersionAutoUpgrade();
    }

    /// <summary>
    /// The stage of a virtual machine scale set extension definition allowing to specify the type of the virtual machine
    /// scale set extension image this extension is based on.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this definition.</typeparam>
    public interface IWithType<ParentT> 
    {
        /// <summary>
        /// Specifies the type of the virtual machine scale set extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">An image type name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.UpdateDefinition.IWithVersion<ParentT> WithType(string extensionImageTypeName);
    }
}