// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System.Threading;
using Azure;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiResource
    {
        /// <summary> Gets the API Products. </summary>
        public virtual AsyncPageable<ApiManagementProductResource> GetApiProductsAsync(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<ApiManagementProductData, ApiManagementProductResource>(
                GetApiProductsRawAsync(filter, top, skip, cancellationToken),
                data => data is null ? null : new ApiManagementProductResource(Client, data));

        /// <summary> Gets the API Products. </summary>
        public virtual Pageable<ApiManagementProductResource> GetApiProducts(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new PageableWrapper<ApiManagementProductData, ApiManagementProductResource>(
                GetApiProductsRaw(filter, top, skip, cancellationToken),
                data => data is null ? null : new ApiManagementProductResource(Client, data));
    }

    public partial class ApiManagementUserResource
    {
        /// <summary> Gets the User Groups. </summary>
        public virtual AsyncPageable<ApiManagementGroupResource> GetUserGroupsAsync(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<ApiManagementGroupData, ApiManagementGroupResource>(
                GetAllAsync(filter, top, skip, cancellationToken),
                data => data is null ? null : new ApiManagementGroupResource(Client, data));

        /// <summary> Gets the User Groups. </summary>
        public virtual Pageable<ApiManagementGroupResource> GetUserGroups(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new PageableWrapper<ApiManagementGroupData, ApiManagementGroupResource>(
                GetAll(filter, top, skip, cancellationToken),
                data => data is null ? null : new ApiManagementGroupResource(Client, data));
    }
}
