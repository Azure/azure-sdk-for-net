// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionShared
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition;

    /// <summary>
    /// The virtual machine scale set stages shared between managed and unmanaged based
    /// virtual machine definitions.
    /// </summary>
    public interface IDefinitionShared  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithGroup,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithNetwork,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithSubnet,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPrivateIP,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPublicIPAddress,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithPrimaryNetworkInterface,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithOS,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithCreate
    {
    }
}