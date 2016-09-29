// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update;
    /// <summary>
    /// The stage of a virtual machine scale set extension update allowing to add or update public and private settings.
    /// </summary>
    public interface IWithSettings 
    {
        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">key the key of a public settings entry</param>
        /// <param name="value">value the value of the public settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate WithPublicSetting (string key, object value);

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">key the key of a private settings entry</param>
        /// <param name="value">value the value of the private settings entry</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate WithProtectedSetting (string key, object value);

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">settings the public settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate WithPublicSettings (IDictionary<string,object> settings);

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">settings the private settings</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate WithProtectedSettings (IDictionary<string,object> settings);

    }
    /// <summary>
    /// The entirety of virtual machine scale set extension update as a part of parent virtual machine scale set update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSet.Update.IUpdate>,
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
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate WithMinorVersionAutoUpgrade ();

        /// <summary>
        /// Disables auto upgrading of the extension with minor versions.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineScaleSetExtension.Update.IUpdate WithoutMinorVersionAutoUpgrade ();

    }
}