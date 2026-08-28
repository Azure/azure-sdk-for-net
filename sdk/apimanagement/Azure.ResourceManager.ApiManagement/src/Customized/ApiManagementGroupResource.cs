// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementGroupResource
    {
        // Old SDK returned ApiManagementGroupUserData (contextual wrapper around UserContractData)
        // for group user list operations. Not spec-fixable: TypeSpec has no concept of
        // "same model, different name per operation context."

        /// <summary> Gets the Group Users. </summary>
        public virtual AsyncPageable<ApiManagementGroupUserData> GetGroupUsersAsync(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<ApiManagementUserResource, ApiManagementGroupUserData>(
                GetAllAsync(filter, top, skip, cancellationToken),
                resource => resource is null ? null : new ApiManagementGroupUserData(resource.Data));

        /// <summary> Gets the Group Users. </summary>
        public virtual Pageable<ApiManagementGroupUserData> GetGroupUsers(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new PageableWrapper<ApiManagementUserResource, ApiManagementGroupUserData>(
                GetAll(filter, top, skip, cancellationToken),
                resource => resource is null ? null : new ApiManagementGroupUserData(resource.Data));

        /// <summary> Creates the Group User. </summary>
        public virtual async Task<Response<ApiManagementGroupUserData>> CreateGroupUserAsync(string userId, CancellationToken cancellationToken = default)
        {
            Response<ApiManagementUserResource> response = await CreateAsync(userId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value is null ? null : new ApiManagementGroupUserData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Creates the Group User. </summary>
        public virtual Response<ApiManagementGroupUserData> CreateGroupUser(string userId, CancellationToken cancellationToken = default)
        {
            Response<ApiManagementUserResource> response = Create(userId, cancellationToken);
            return Response.FromValue(response.Value is null ? null : new ApiManagementGroupUserData(response.Value.Data), response.GetRawResponse());
        }
    }
}
