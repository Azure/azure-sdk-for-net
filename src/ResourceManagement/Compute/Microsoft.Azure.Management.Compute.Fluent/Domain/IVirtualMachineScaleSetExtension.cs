// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an extension associated with virtual machines in a scale set.
    /// An extension associated with a virtual machine scale set will be created from a VirtualMachineExtensionImage.
    /// </summary>
    public interface IVirtualMachineScaleSetExtension  :
        IWrapper<Models.VirtualMachineScaleSetExtensionInner>,
        IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>
    {
        /// <summary>
        /// Gets the publisher name of the virtual machine scale set extension image this extension is created from.
        /// </summary>
        string PublisherName { get; }

        /// <summary>
        /// Gets the public settings of the virtual machine scale set extension as key value pairs.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,object> PublicSettings { get; }

        /// <summary>
        /// Gets the type name of the virtual machine scale set extension image this extension is created from.
        /// </summary>
        string TypeName { get; }

        /// <summary>
        /// Gets the public settings of the virtual machine extension as a JSON string.
        /// </summary>
        string PublicSettingsAsJsonString { get; }

        /// <summary>
        /// Gets true if this extension is configured to upgrade automatically when a new minor version of
        /// the extension image that this extension based on is published.
        /// </summary>
        bool AutoUpgradeMinorVersionEnabled { get; }

        /// <summary>
        /// Gets the provisioning state of this virtual machine scale set extension.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// Gets the version name of the virtual machine scale set extension image this extension is created from.
        /// </summary>
        string VersionName { get; }
    }
}