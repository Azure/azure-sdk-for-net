// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionManagedOrUnmanaged
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionShared;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition;

    /// <summary>
    /// The entirety of the virtual machine scale set definition.
    /// </summary>
    public interface IDefinitionManagedOrUnmanaged  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionShared.IDefinitionShared,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithUnmanagedCreate
    {
    }
}