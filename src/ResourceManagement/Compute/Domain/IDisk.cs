// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.Disk.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;

    /// <summary>
    /// An immutable client-side representation of an Azure managed disk.
    /// </summary>
    public interface IDisk  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Compute.Fluent.IComputeManager,Models.DiskInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Disk.Update.IUpdate>
    {
        /// <summary>
        /// Revokes access granted to the disk asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RevokeAccessAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the resource ID of the virtual machine this disk is attached to, or null
        /// if the disk is in a detached state.
        /// </summary>
        string VirtualMachineId { get; }

        /// <summary>
        /// Revokes access granted to the disk.
        /// </summary>
        void RevokeAccess();

        /// <summary>
        /// Gets disk size in GB.
        /// </summary>
        int SizeInGB { get; }

        /// <summary>
        /// Grants access to the disk.
        /// </summary>
        /// <param name="accessDurationInSeconds">The access duration in seconds.</param>
        /// <return>The read-only SAS URI to the disk.</return>
        string GrantAccess(int accessDurationInSeconds);

        /// <summary>
        /// Gets the type of the operating system on the disk.
        /// </summary>
        Models.OperatingSystemTypes? OSType { get; }

        /// <summary>
        /// Grants access to the disk asynchronously.
        /// </summary>
        /// <param name="accessDurationInSeconds">The access duration in seconds.</param>
        /// <return>A representation of the deferred computation of this call returning a read-only SAS URI to the disk.</return>
        Task<string> GrantAccessAsync(int accessDurationInSeconds, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the details of the source from which the disk is created.
        /// </summary>
        Models.CreationSource Source { get; }

        /// <summary>
        /// Gets the disk SKU.
        /// </summary>
        Models.DiskSkuTypes Sku { get; }

        /// <summary>
        /// Gets true if the disk is attached to a virtual machine, otherwise false.
        /// </summary>
        bool IsAttachedToVirtualMachine { get; }

        /// <summary>
        /// Gets the disk creation method.
        /// </summary>
        Models.DiskCreateOption CreationMethod { get; }
    }
}