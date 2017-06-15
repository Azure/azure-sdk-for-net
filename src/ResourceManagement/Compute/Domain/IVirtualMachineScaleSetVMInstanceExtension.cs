// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an extension associated with virtual machine instance
    /// in a scale set.
    /// </summary>
    public interface IVirtualMachineScaleSetVMInstanceExtension  :
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVM>
    {
        /// <summary>
        /// Gets the instance view of the scale set virtual machine extension.
        /// </summary>
        Models.VirtualMachineExtensionInstanceView InstanceView { get; }
    }
}