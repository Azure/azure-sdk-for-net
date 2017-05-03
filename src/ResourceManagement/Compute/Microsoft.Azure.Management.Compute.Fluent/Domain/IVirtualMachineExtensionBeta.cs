// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Members if IVirtualMachineExtension that are in Beta.
    /// </summary>
    public interface IVirtualMachineExtensionBeta :
        IBeta,
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension,Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>
    {
        /// <return>Observable that emits virtual machine extension instance view.</return>
        Task<Models.VirtualMachineExtensionInstanceView> GetInstanceViewAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}