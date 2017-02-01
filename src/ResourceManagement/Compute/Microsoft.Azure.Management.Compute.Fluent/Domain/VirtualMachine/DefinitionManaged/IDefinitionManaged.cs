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
        IDefinitionShared,
        IWithLinuxRootUsernameManaged,
        IWithLinuxRootPasswordOrPublicKeyManaged,
        IWithWindowsAdminUsernameManaged,
        IWithWindowsAdminPasswordManaged,
        IWithFromImageCreateOptionsManaged,
        IWithLinuxCreateManaged,
        IWithWindowsCreateManaged,
        IWithManagedCreate
    {
    }
}