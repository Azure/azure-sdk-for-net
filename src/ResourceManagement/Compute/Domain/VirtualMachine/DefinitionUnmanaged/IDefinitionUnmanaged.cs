// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionUnmanaged
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition;

    /// <summary>
    /// The entirety of the unmanaged disk based virtual machine definition.
    /// </summary>
    public interface IDefinitionUnmanaged  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithGroup,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithNetwork,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithSubnet,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPrivateIP,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPublicIPAddress,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPrimaryNetworkInterface,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithOS,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminPasswordUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate
    {
    }
}