// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Snapshot.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure managed snapshot.
    /// </summary>
    public interface ISnapshot  :
        IGroupableResource<IComputeManager>,
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>,
        IWrapper<Models.SnapshotInner>,
        IUpdatable<Snapshot.Update.IUpdate>
    {
        /// <summary>
        /// Revoke access granted to the snapshot.
        /// </summary>
        void RevokeAccess();

        /// <summary>
        /// Gets disk size in GB.
        /// </summary>
        int SizeInGB { get; }

        /// <summary>
        /// Grants access to the snapshot.
        /// </summary>
        /// <param name="accessDurationInSeconds">The access duration in seconds.</param>
        /// <return>The readonly SAS uri to the snapshot.</return>
        string GrantAccess(int accessDurationInSeconds);

        /// <summary>
        /// Gets the type of operating system in the snapshot.
        /// </summary>
        Models.OperatingSystemTypes? OsType { get; }

        /// <summary>
        /// Gets the details of the source from which snapshot is created.
        /// </summary>
        CreationSource Source { get; }

        /// <summary>
        /// Gets the snapshot sku type.
        /// </summary>
        Models.DiskSkuTypes Sku { get; }

        /// <summary>
        /// Gets the snapshot creation method.
        /// </summary>
        Models.DiskCreateOption CreationMethod { get; }
    }
}