// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update;

    /// <summary>
    /// The stage of a virtual machine scale set extension update allowing to add or update public and private settings.
    /// </summary>
    public interface IWithSettings 
    {
        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">The key of a private settings entry.</param>
        /// <param name="value">The value of the private settings entry.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate WithProtectedSetting(string key, object value);

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">The key of a public settings entry.</param>
        /// <param name="value">The value of the public settings entry.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate WithPublicSetting(string key, object value);

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">The public settings.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate WithPublicSettings(IDictionary<string,object> settings);

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">The private settings.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate WithProtectedSettings(IDictionary<string,object> settings);
    }

    /// <summary>
    /// The entirety of virtual machine scale set extension update as a part of parent virtual machine scale set update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IUpdate>,
        IWithAutoUpgradeMinorVersion,
        IWithSettings
    {
    }

    /// <summary>
    /// The stage of a virtual machine scale set extension update allowing to enable or disable auto upgrade of the
    /// extension when when a new minor version of virtual machine scale set extension image gets published.
    /// </summary>
    public interface IWithAutoUpgradeMinorVersion 
    {
        /// <summary>
        /// Enables auto-upgrading of the extension with minor versions.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate WithMinorVersionAutoUpgrade();

        /// <summary>
        /// Disables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetExtension.Update.IUpdate WithoutMinorVersionAutoUpgrade();
    }
}