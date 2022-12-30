// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Authorization.Models;

namespace Azure.ResourceManager.Authorization
{
    /// <summary>
    /// A class representing a collection of <see cref="RoleAssignmentResource" /> and their operations.
    /// Each <see cref="RoleAssignmentResource" /> in the collection will belong to the same instance of <see cref="ArmResource" />.
    /// To get a <see cref="RoleAssignmentCollection" /> instance call the GetRoleAssignments method from an instance of <see cref="ArmResource" />.
    /// </summary>
    public partial class RoleAssignmentCollection : ArmCollection, IEnumerable<RoleAssignmentResource>, IAsyncEnumerable<RoleAssignmentResource>
    {
        /// <summary>
        /// List all role assignments that apply to a scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/roleAssignments
        /// Operation Id: RoleAssignments_ListForScope
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Use $filter=atScope() to return all role assignments at or above the scope. Use $filter=principalId eq {id} to return all role assignments at, above or below the scope for the specified principal. </param>
        /// <param name="tenantId"> Tenant ID for cross-tenant request. </param>
        /// <param name="skipToken"> The skipToken to apply on the operation. Use $skipToken={skiptoken} to return paged role assignments following the skipToken passed. Only supported on provider level calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RoleAssignmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RoleAssignmentResource> GetAllAsync(string filter = null, string tenantId = null, string skipToken = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new RoleAssignmentCollectionGetAllOptions
            {
                Filter = filter,
                TenantId = tenantId,
                SkipToken = skipToken
            }, cancellationToken);

        /// <summary>
        /// List all role assignments that apply to a scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/roleAssignments
        /// Operation Id: RoleAssignments_ListForScope
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Use $filter=atScope() to return all role assignments at or above the scope. Use $filter=principalId eq {id} to return all role assignments at, above or below the scope for the specified principal. </param>
        /// <param name="tenantId"> Tenant ID for cross-tenant request. </param>
        /// <param name="skipToken"> The skipToken to apply on the operation. Use $skipToken={skiptoken} to return paged role assignments following the skipToken passed. Only supported on provider level calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RoleAssignmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RoleAssignmentResource> GetAll(string filter = null, string tenantId = null, string skipToken = null, CancellationToken cancellationToken = default) =>
            GetAll(new RoleAssignmentCollectionGetAllOptions
            {
                Filter = filter,
                TenantId = tenantId,
                SkipToken = skipToken
            }, cancellationToken);
    }
}
