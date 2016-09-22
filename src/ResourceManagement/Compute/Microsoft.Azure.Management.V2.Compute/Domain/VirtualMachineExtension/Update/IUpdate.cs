// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update
{

    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    using System.Collections.Generic;
    /// <summary>
    /// The stage of the virtual machine extension update allowing to enable or disable auto upgrade of the
    /// extension when when a new minor version of virtual machine extension image gets published.
    /// </summary>
    public interface IWithAutoUpgradeMinorVersion 
    {
        /// <summary>
        /// enables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate WithAutoUpgradeMinorVersionEnabled ();

        /// <summary>
        /// enables auto upgrade of the extension.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate WithAutoUpgradeMinorVersionDisabled ();

    }
    /// <summary>
    /// The entirety of virtual machine extension update as a part of parent virtual machine update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>,
        IWithAutoUpgradeMinorVersion,
        IWithSettings,
        IWithTags
    {
    }
    /// <summary>
    /// The stage of the virtual machine extension update allowing to add or update tags.
    /// </summary>
    public interface IWithTags 
    {
        /// <summary>
        /// Specifies tags for the virtual machine extension as a {@link Map}.
        /// </summary>
        /// <param name="tags">tags a {@link Map} of tags</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate WithTags (IDictionary<string,string> tags);

        /// <summary>
        /// Adds a tag to the virtual machine extension.
        /// </summary>
        /// <param name="key">key the key for the tag</param>
        /// <param name="value">value the value for the tag</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate WithTag (string key, string value);

        /// <summary>
        /// Removes a tag from the virtual machine extension.
        /// </summary>
        /// <param name="key">key the key of the tag to remove</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate WithoutTag (string key);

    }
    /// <summary>
    /// The stage of the virtual machine extension update allowing to add or update public and private settings.
    /// </summary>
    public interface IWithSettings 
    {
        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate WithPublicSetting (string key, object value);

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate WithProtectedSetting (string key, object value);

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate WithPublicSettings (IDictionary<string, object> settings);

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineExtension.Update.IUpdate WithProtectedSettings (IDictionary<string, object> settings);

    }
}