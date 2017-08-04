// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.Disk.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// Entry point to managed disk management API in Azure.
    /// </summary>
    public interface IDisksBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Revoke access granted to the snapshot asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RevokeAccessAsync(string resourceGroupName, string diskName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Revoke access granted to a disk.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        void RevokeAccess(string resourceGroupName, string diskName);

        /// <summary>
        /// Grants access to a disk.
        /// </summary>
        /// <param name="resourceGroupName">A resource group name.</param>
        /// <param name="diskName">A disk name.</param>
        /// <param name="accessLevel">Access level.</param>
        /// <param name="accessDuration">Access duration.</param>
        /// <return>The read-only SAS URI to the disk.</return>
        string GrantAccess(string resourceGroupName, string diskName, AccessLevel accessLevel, int accessDuration);

        /// <summary>
        /// Grants access to the disk asynchronously.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        /// <param name="accessLevel">Access level.</param>
        /// <param name="accessDuration">Access duration.</param>
        /// <returna>Representation of the deferred computation of this call returning a read-only SAS URI to the disk.</returna>
        Task<string> GrantAccessAsync(string resourceGroupName, string diskName, AccessLevel accessLevel, int accessDuration, CancellationToken cancellationToken = default(CancellationToken));

    }
}