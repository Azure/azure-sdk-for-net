// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Snapshot.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Resource.Fluent.Core;

    /// <summary>
    /// Entry point to managed snapshot management API in Azure.
    /// </summary>
    public interface ISnapshots  :
        ISupportsCreating<Snapshot.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>,
        ISupportsGettingById<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>,
        IHasManager<IComputeManager>,
        IHasInner<ISnapshotsOperations>
    {
        /// <summary>
        /// Revoke access granted to a snapshot.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="snapName">The snapshot name.</param>
        void RevokeAccess(string resourceGroupName, string snapName);

        /// <summary>
        /// Grants access to a snapshot.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="snapshotName">The snapshot name.</param>
        /// <param name="accessLevel">Access level.</param>
        /// <param name="accessDuration">Access duration.</param>
        /// <return>The readonly SAS uri to the snapshot.</return>
        string GrantAccess(string resourceGroupName, string snapshotName, AccessLevel accessLevel, int accessDuration);
    }
}