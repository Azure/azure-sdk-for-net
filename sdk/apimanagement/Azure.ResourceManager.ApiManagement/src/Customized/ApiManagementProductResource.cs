// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementProductResource
    {
        // Old SDK returned contextual wrapper types (ProductApiData, ProductGroupData) for
        // association operations where the wire shape is identical to ApiData/GroupData.
        // Not spec-fixable: TypeSpec has no concept of "same model, different name per context."

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
}
