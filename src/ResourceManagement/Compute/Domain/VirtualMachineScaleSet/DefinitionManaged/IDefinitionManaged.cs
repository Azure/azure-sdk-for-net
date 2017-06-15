// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionManaged
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionShared;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition;

    /// <summary>
    /// The entirety of the managed disk based virtual machine scale set definition.
    /// </summary>
    public interface IDefinitionManaged  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionShared.IDefinitionShared,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootUsernameManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxRootPasswordOrPublicKeyManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminUsernameManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsAdminPasswordManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithLinuxCreateManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithWindowsCreateManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithManagedCreate
    {
    }
}