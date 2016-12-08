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
    public interface IVirtualMachineScaleSetExtension :
        IWrapper<Models.VirtualMachineScaleSetExtensionInner>,
        IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>
    {
        /// <return>The publisher name of the virtual machine scale set extension image this extension is created from.</return>
        string PublisherName { get; }

        /// <return>The public settings of the virtual machine scale set extension as key value pairs.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, object> PublicSettings { get; }

        /// <return>The type name of the virtual machine scale set extension image this extension is created from.</return>
        string TypeName { get; }

        /// <return>The public settings of the virtual machine extension as a JSON string.</return>
        string PublicSettingsAsJsonString { get; }

        /// <return>
        /// True if this extension is configured to upgrade automatically when a new minor version of
        /// the extension image that this extension based on is published.
        /// </return>
        bool AutoUpgradeMinorVersionEnabled { get; }

        /// <return>The provisioning state of this virtual machine scale set extension.</return>
        string ProvisioningState { get; }

        /// <return>The version name of the virtual machine scale set extension image this extension is created from.</return>
        string VersionName { get; }
    }
}