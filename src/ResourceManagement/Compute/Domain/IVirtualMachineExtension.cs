// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension.
    /// </summary>
    public interface IVirtualMachineExtension  :
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>
    {
        /// <return>A representation of the deferred computation of this call returning the virtual machine extension instance view.</return>
        Task<Models.VirtualMachineExtensionInstanceView> GetInstanceViewAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The instance view of the virtual machine extension.</return>
        Models.VirtualMachineExtensionInstanceView GetInstanceView();
    }
}