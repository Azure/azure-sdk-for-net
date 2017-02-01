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
        IDefinitionShared,
        IWithLinuxRootUsernameManaged,
        IWithLinuxRootPasswordOrPublicKeyManaged,
        IWithWindowsAdminUsernameManaged,
        IWithWindowsAdminPasswordManaged,
        IWithLinuxCreateManaged,
        IWithWindowsCreateManaged,
        IWithManagedCreate
    {
    }
}