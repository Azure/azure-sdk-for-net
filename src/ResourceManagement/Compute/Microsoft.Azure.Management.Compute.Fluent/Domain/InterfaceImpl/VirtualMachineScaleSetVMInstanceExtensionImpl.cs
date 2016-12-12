// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Collections.Generic;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class VirtualMachineScaleSetVMInstanceExtensionImpl
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>The version name of the virtual machine extension image this extension is created from.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.VersionName
        {
            get
            {
                return this.VersionName() as string;
            }
        }

        /// <return>The provisioning state of the virtual machine extension.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.ProvisioningState
        {
            get
            {
                return this.ProvisioningState() as string;
            }
        }

        /// <return>
        /// True if this extension is configured to upgrade automatically when a new minor version of the
        /// extension image that this extension based on is published.
        /// </return>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.AutoUpgradeMinorVersionEnabled
        {
            get
            {
                return this.AutoUpgradeMinorVersionEnabled();
            }
        }

        /// <return>The instance view of the virtual machine extension.</return>
        Models.VirtualMachineExtensionInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.InstanceView
        {
            get
            {
                return this.InstanceView() as Models.VirtualMachineExtensionInstanceView;
            }
        }

        /// <return>The public settings of the virtual machine extension as a JSON string.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.PublicSettingsAsJsonString
        {
            get
            {
                return this.PublicSettingsAsJsonString() as string;
            }
        }

        /// <return>The publisher name of the virtual machine extension image this extension is created from.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.PublisherName
        {
            get
            {
                return this.PublisherName() as string;
            }
        }

        /// <return>The type name of the virtual machine extension image this extension is created from.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.TypeName
        {
            get
            {
                return this.TypeName() as string;
            }
        }

        /// <return>The tags for this virtual machine extension.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.Tags
        {
            get
            {
                return this.Tags() as System.Collections.Generic.IReadOnlyDictionary<string, string>;
            }
        }

        /// <return>The public settings of the virtual machine extension as key value pairs.</return>
        System.Collections.Generic.IReadOnlyDictionary<string, object> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.PublicSettings
        {
            get
            {
                return this.PublicSettings() as System.Collections.Generic.IReadOnlyDictionary<string, object>;
            }
        }
    }
}