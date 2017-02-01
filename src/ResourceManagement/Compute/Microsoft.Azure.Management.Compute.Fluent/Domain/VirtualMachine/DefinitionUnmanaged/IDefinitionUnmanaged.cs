// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionUnmanaged
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition;

    /// <summary>
    /// The entirety of the unmanaged disk based virtual machine definition.
    /// </summary>
    public interface IDefinitionUnmanaged  :
        IBlank,
        IWithGroup,
        IWithNetwork,
        IWithSubnet,
        IWithPrivateIp,
        IWithPublicIpAddress,
        IWithPrimaryNetworkInterface,
        IWithOS,
        IWithLinuxRootUsernameUnmanaged,
        IWithLinuxRootPasswordOrPublicKeyUnmanaged,
        IWithWindowsAdminUsernameUnmanaged,
        IWithWindowsAdminPasswordUnmanaged,
        IWithFromImageCreateOptionsUnmanaged,
        IWithLinuxCreateUnmanaged,
        IWithWindowsCreateUnmanaged,
        IWithUnmanagedCreate
    {
    }
}