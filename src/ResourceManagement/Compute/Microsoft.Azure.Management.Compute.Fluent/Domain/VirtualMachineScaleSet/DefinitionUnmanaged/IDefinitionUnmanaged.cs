// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionUnmanaged
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionShared;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition;

    /// <summary>
    /// The entirety of the unmanaged disk based virtual machine scale set definition.
    /// </summary>
    public interface IDefinitionUnmanaged  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionShared.IDefinitionShared,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithUnmanagedCreate
    {
    }
}