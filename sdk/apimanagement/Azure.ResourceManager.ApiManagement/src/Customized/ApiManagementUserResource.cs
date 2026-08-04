// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementUserResource
    {
        // Old SDK returned Pageable<ApiManagementGroupResource>; new generator returns
        // Pageable<ApiManagementGroupData>. These wrappers convert Data -> Resource for
        // binary compat. Not spec-fixable: generator always emits Pageable<Data> for
        // cross-resource navigation list operations.

        /// <summary> Gets the User Groups. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ApiManagementGroupResource> GetUserGroupsAsync(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<ApiManagementGroupData, ApiManagementGroupResource>(
                GetAllAsync(filter, top, skip, cancellationToken),
                data => data is null ? null : new ApiManagementGroupResource(Client, data));

        /// <summary> Gets the User Groups. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ApiManagementGroupResource> GetUserGroups(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new PageableWrapper<ApiManagementGroupData, ApiManagementGroupResource>(
                GetAll(filter, top, skip, cancellationToken),
                data => data is null ? null : new ApiManagementGroupResource(Client, data));
    }
}
