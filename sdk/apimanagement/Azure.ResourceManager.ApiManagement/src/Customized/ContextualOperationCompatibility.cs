// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    // AutoRest exposed contextual data model names for association operations where the wire
    // shape is the same as the primary resource data. MPG currently emits the primary data type.
    // These wrappers preserve the old public return types.
    public partial class ApiManagementGatewayResource
    {
        /// <summary> Gets the Gateway APIs By Service. </summary>
        public virtual AsyncPageable<GatewayApiData> GetGatewayApisByServiceAsync(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<ApiData, GatewayApiData>(
                GetByServiceAsync(filter, top, skip, cancellationToken),
                data => data is null ? null : new GatewayApiData(data));

        /// <summary> Gets the Gateway APIs By Service. </summary>
        public virtual Pageable<GatewayApiData> GetGatewayApisByService(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new PageableWrapper<ApiData, GatewayApiData>(
                GetByService(filter, top, skip, cancellationToken),
                data => data is null ? null : new GatewayApiData(data));

        /// <summary> Creates or updates the Gateway API. </summary>
        public virtual async Task<Response<GatewayApiData>> CreateOrUpdateGatewayApiAsync(string apiId, AssociationContract associationContract, CancellationToken cancellationToken = default)
        {
            Response<ApiData> response = await CreateOrUpdateAsync(apiId, associationContract, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value is null ? null : new GatewayApiData(response.Value), response.GetRawResponse());
        }

        /// <summary> Creates or updates the Gateway API. </summary>
        public virtual Response<GatewayApiData> CreateOrUpdateGatewayApi(string apiId, AssociationContract associationContract, CancellationToken cancellationToken = default)
        {
            Response<ApiData> response = CreateOrUpdate(apiId, associationContract, cancellationToken);
            return Response.FromValue(response.Value is null ? null : new GatewayApiData(response.Value), response.GetRawResponse());
        }
    }

    public partial class ApiManagementProductResource
    {
        /// <summary> Gets the Product APIs. </summary>
        public virtual AsyncPageable<ProductApiData> GetProductApisAsync(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<ApiData, ProductApiData>(
                GetProductApisRawAsync(filter, top, skip, cancellationToken),
                data => data is null ? null : new ProductApiData(data));

        /// <summary> Gets the Product APIs. </summary>
        public virtual Pageable<ProductApiData> GetProductApis(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new PageableWrapper<ApiData, ProductApiData>(
                GetProductApisRaw(filter, top, skip, cancellationToken),
                data => data is null ? null : new ProductApiData(data));

        /// <summary> Creates or updates the Product API. </summary>
        public virtual async Task<Response<ProductApiData>> CreateOrUpdateProductApiAsync(string apiId, CancellationToken cancellationToken = default)
        {
            Response<ApiData> response = await CreateOrUpdateProductApiRawAsync(apiId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value is null ? null : new ProductApiData(response.Value), response.GetRawResponse());
        }

        /// <summary> Creates or updates the Product API. </summary>
        public virtual Response<ProductApiData> CreateOrUpdateProductApi(string apiId, CancellationToken cancellationToken = default)
        {
            Response<ApiData> response = CreateOrUpdateProductApiRaw(apiId, cancellationToken);
            return Response.FromValue(response.Value is null ? null : new ProductApiData(response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the Product Groups. </summary>
        public virtual AsyncPageable<ProductGroupData> GetProductGroupsAsync(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<ApiManagementGroupData, ProductGroupData>(
                GetProductGroupsRawAsync(filter, top, skip, cancellationToken),
                data => data is null ? null : new ProductGroupData(data));

        /// <summary> Gets the Product Groups. </summary>
        public virtual Pageable<ProductGroupData> GetProductGroups(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new PageableWrapper<ApiManagementGroupData, ProductGroupData>(
                GetProductGroupsRaw(filter, top, skip, cancellationToken),
                data => data is null ? null : new ProductGroupData(data));

        /// <summary> Creates or updates the Product Group. </summary>
        public virtual async Task<Response<ProductGroupData>> CreateOrUpdateProductGroupAsync(string groupId, CancellationToken cancellationToken = default)
        {
            Response<ApiManagementGroupData> response = await CreateOrUpdateProductGroupRawAsync(groupId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value is null ? null : new ProductGroupData(response.Value), response.GetRawResponse());
        }

        /// <summary> Creates or updates the Product Group. </summary>
        public virtual Response<ProductGroupData> CreateOrUpdateProductGroup(string groupId, CancellationToken cancellationToken = default)
        {
            Response<ApiManagementGroupData> response = CreateOrUpdateProductGroupRaw(groupId, cancellationToken);
            return Response.FromValue(response.Value is null ? null : new ProductGroupData(response.Value), response.GetRawResponse());
        }
    }

    public partial class ApiManagementGroupResource
    {
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
