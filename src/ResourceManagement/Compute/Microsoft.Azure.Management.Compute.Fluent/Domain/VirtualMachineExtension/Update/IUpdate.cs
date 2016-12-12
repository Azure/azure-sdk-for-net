// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of the virtual machine extension update allowing to enable or disable auto upgrade of the
    /// extension when when a new minor version of virtual machine extension image gets published.
    /// </summary>
    public interface IWithAutoUpgradeMinorVersion 
    {
        /// <summary>
        /// Enables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate WithMinorVersionAutoUpgrade();

        /// <summary>
        /// Enables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate WithoutMinorVersionAutoUpgrade();
    }

    /// <summary>
    /// The stage of the virtual machine extension update allowing to add or update public and private settings.
    /// </summary>
    public interface IWithSettings 
    {
        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">The key of a private settings entry.</param>
        /// <param name="value">The value of the private settings entry.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate WithProtectedSetting(string key, object value);

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">The key of a public settings entry.</param>
        /// <param name="value">The value of the public settings entry.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate WithPublicSetting(string key, object value);

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">The public settings.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate WithPublicSettings(IDictionary<string,object> settings);

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">The private settings.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate WithProtectedSettings(IDictionary<string,object> settings);
    }

    /// <summary>
    /// The stage of the virtual machine extension update allowing to add or update tags.
    /// </summary>
    public interface IWithTags 
    {
        /// <summary>
        /// Adds a tag to the virtual machine extension.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate WithTag(string key, string value);

        /// <summary>
        /// Specifies tags for the virtual machine extension as a Map.
        /// </summary>
        /// <param name="tags">A Map of tags.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate WithTags(IDictionary<string,string> tags);

        /// <summary>
        /// Removes a tag from the virtual machine extension.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update.IUpdate WithoutTag(string key);
    }

    /// <summary>
    /// The entirety of virtual machine extension update as a part of parent virtual machine update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate>,
        IWithAutoUpgradeMinorVersion,
        IWithSettings,
        IWithTags
    {
    }
}