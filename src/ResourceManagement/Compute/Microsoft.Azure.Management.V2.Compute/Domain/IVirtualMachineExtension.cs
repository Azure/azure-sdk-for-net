// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension.
    /// An extension associated with a virtual machine will be created from a {@link VirtualMachineExtensionImage }.
    /// </summary>
    public interface IVirtualMachineExtension :
        IExternalChildResource<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtension, Microsoft.Azure.Management.V2.Compute.IVirtualMachine>,
        IWrapper<Microsoft.Azure.Management.Compute.Models.VirtualMachineExtensionInner>
    {
        /// <returns>the publisher name of the virtual machine extension image this extension is created from</returns>
        string PublisherName { get; }

        /// <returns>the type name of the virtual machine extension image this extension is created from</returns>
        string TypeName { get; }

        /// <returns>the version name of the virtual machine extension image this extension is created from</returns>
        string VersionName { get; }

        /// <returns>true if this extension is configured to upgrade automatically when a new minor version of</returns>
        /// <returns>virtual machine extension image that this extension based on is published</returns>
        bool? AutoUpgradeMinorVersionEnabled { get; }

        /// <returns>the public settings of the virtual machine extension as key value pairs</returns>
        IDictionary<string, object> PublicSettings { get; }

        /// <returns>the public settings of the virtual machine extension as a json string</returns>
        string PublicSettingsAsJsonString { get; }

        /// <returns>the instance view of this virtual machine extension</returns>
        VirtualMachineExtensionInstanceView InstanceView { get; }

        /// <returns>the tags for this virtual machine extension</returns>
        IDictionary<string, string> Tags { get; }

        /// <returns>the provisioning state of this virtual machine extension</returns>
        string ProvisioningState { get; }

    }
}