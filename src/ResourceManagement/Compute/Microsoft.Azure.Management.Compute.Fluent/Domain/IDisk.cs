// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Disk.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure managed disk.
    /// </summary>
    public interface IDisk  :
        IGroupableResource<IComputeManager, DiskInner>,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        IUpdatable<Disk.Update.IUpdate>
    {
        /// <summary>
        /// Gets resource id of the virtual machine this disk is attached to, null
        /// if the disk is in detached state.
        /// </summary>
        string VirtualMachineId { get; }

        /// <summary>
        /// Revoke access granted to the disk.
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
        /// <return>The readonly SAS uri to the disk.</return>
        string GrantAccess(int accessDurationInSeconds);

        /// <summary>
        /// Gets the type of operating system in the disk.
        /// </summary>
        Models.OperatingSystemTypes? OsType { get; }

        /// <summary>
        /// Gets the details of the source from which disk is created.
        /// </summary>
        CreationSource Source { get; }

        /// <summary>
        /// Gets the disk sku.
        /// </summary>
        Models.DiskSkuTypes Sku { get; }

        /// <summary>
        /// Gets true if the disk is attached to a virtual machine, false if is
        /// in detached state.
        /// </summary>
        bool IsAttachedToVirtualMachine { get; }

        /// <summary>
        /// Gets the disk creation method.
        /// </summary>
        Models.DiskCreateOption CreationMethod { get; }
    }
}