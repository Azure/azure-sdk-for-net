// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    internal partial class VirtualMachineScaleSetVMInstanceExtensionImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the version name of the virtual machine extension image this extension is created from.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.VersionName
        {
            get
            {
                return this.VersionName();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the virtual machine extension.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets true if this extension is configured to upgrade automatically when a new minor version of the
        /// extension image that this extension based on is published.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.AutoUpgradeMinorVersionEnabled
        {
            get
            {
                return this.AutoUpgradeMinorVersionEnabled();
            }
        }

        /// <summary>
        /// Gets the instance view of the virtual machine extension.
        /// </summary>
        Models.VirtualMachineExtensionInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMInstanceExtension.InstanceView
        {
            get
            {
                return this.InstanceView() as Models.VirtualMachineExtensionInstanceView;
            }
        }

        /// <summary>
        /// Gets the public settings of the virtual machine extension as a JSON string.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.PublicSettingsAsJsonString
        {
            get
            {
                return this.PublicSettingsAsJsonString();
            }
        }

        /// <summary>
        /// Gets the publisher name of the virtual machine extension image this extension is created from.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.PublisherName
        {
            get
            {
                return this.PublisherName();
            }
        }

        /// <summary>
        /// Gets the type name of the virtual machine extension image this extension is created from.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.TypeName
        {
            get
            {
                return this.TypeName();
            }
        }

        /// <summary>
        /// Gets the tags for this virtual machine extension.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.Tags
        {
            get
            {
                return this.Tags() as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// Gets the public settings of the virtual machine extension as key value pairs.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,object> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.PublicSettings
        {
            get
            {
                return this.PublicSettings() as System.Collections.Generic.IReadOnlyDictionary<string,object>;
            }
        }
    }
}