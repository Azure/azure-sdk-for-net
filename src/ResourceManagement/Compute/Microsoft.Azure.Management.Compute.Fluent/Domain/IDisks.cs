// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Disk.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to managed disk management API in Azure.
    /// </summary>
    public interface IDisks  :
        ISupportsCreating<Disk.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        ISupportsGettingById<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Compute.Fluent.IDisk>,
        IHasInner<IDisksOperations>,
        IHasManager<IComputeManager>
    {
        /// <summary>
        /// Revoke access granted to a disk.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        void RevokeAccess(string resourceGroupName, string diskName);

        /// <summary>
        /// Revoke access granted to a disk.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        Task RevokeAccessAsync(string resourceGroupName, string diskName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Grants access to a disk.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        /// <param name="accessLevel">Access level.</param>
        /// <param name="accessDuration">Access duration.</param>
        /// <return>The readonly SAS uri to the disk.</return>
        string GrantAccess(string resourceGroupName, string diskName, AccessLevel accessLevel, int accessDuration);

        /// <summary>
        /// Grants access to a disk.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        /// <param name="accessLevel">Access level.</param>
        /// <param name="accessDuration">Access duration.</param>
        /// <return>The readonly SAS uri to the disk.</return>
        Task<string> GrantAccessAsync(
            string resourceGroupName, 
            string diskName, 
            AccessLevel accessLevel, 
            int accessDuration, 
            CancellationToken cancellationToken = default(CancellationToken));
    }
}