// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an extension associated with virtual machine.
    /// </summary>
    public interface IVirtualMachineExtensionBase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.VirtualMachineExtensionInner>
    {
        /// <summary>
        /// Gets the tags for this virtual machine extension.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Tags { get; }

        /// <summary>
        /// Gets the type name of the virtual machine extension image this extension is created from.
        /// </summary>
        string TypeName { get; }

        /// <summary>
        /// Gets the publisher name of the virtual machine extension image this extension is created from.
        /// </summary>
        string PublisherName { get; }

        /// <summary>
        /// Gets the public settings of the virtual machine extension as a JSON string.
        /// </summary>
        string PublicSettingsAsJsonString { get; }

        /// <summary>
        /// Gets the provisioning state of the virtual machine extension.
        /// </summary>
        string ProvisioningState { get; }

        /// <summary>
        /// Gets the version name of the virtual machine extension image this extension is created from.
        /// </summary>
        string VersionName { get; }

        /// <summary>
        /// Gets true if this extension is configured to upgrade automatically when a new minor version of the
        /// extension image that this extension based on is published.
        /// </summary>
        bool AutoUpgradeMinorVersionEnabled { get; }

        /// <summary>
        /// Gets the public settings of the virtual machine extension as key value pairs.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,object> PublicSettings { get; }
    }
}