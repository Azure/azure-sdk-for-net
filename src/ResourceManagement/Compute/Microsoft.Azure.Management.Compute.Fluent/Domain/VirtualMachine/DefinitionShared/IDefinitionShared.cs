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
        IBlank,
        IWithGroup,
        IWithNetwork,
        IWithSubnet,
        IWithPrivateIP,
        IWithPublicIPAddress,
        IWithPrimaryNetworkInterface,
        IWithOS,
        IWithCreate
    {
    }
}