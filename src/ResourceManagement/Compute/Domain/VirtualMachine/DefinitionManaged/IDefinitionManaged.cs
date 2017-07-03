// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionManaged
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionShared;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition;

    /// <summary>
    /// The entirety of the managed disk based virtual machine definition.
    /// </summary>
    public interface IDefinitionManaged  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionShared.IDefinitionShared,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminPasswordManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate
    {
    }
}