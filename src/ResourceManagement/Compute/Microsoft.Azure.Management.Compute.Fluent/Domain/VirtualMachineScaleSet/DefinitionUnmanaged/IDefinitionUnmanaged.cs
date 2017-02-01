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
        IDefinitionShared,
        IWithLinuxRootUsernameUnmanaged,
        IWithLinuxRootPasswordOrPublicKeyUnmanaged,
        IWithWindowsAdminUsernameUnmanaged,
        IWithWindowsAdminPasswordUnmanaged,
        IWithLinuxCreateUnmanaged,
        IWithWindowsCreateUnmanaged,
        IWithUnmanagedCreate
    {
    }
}