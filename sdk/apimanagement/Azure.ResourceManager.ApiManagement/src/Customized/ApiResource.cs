// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiResource
    {
        // Old SDK returned Pageable<ApiManagementProductResource>; new generator returns
        // Pageable<ApiManagementProductData>. These wrappers convert Data -> Resource for
        // binary compat. Not spec-fixable: generator always emits Pageable<Data> for
        // cross-resource navigation list operations.

        /// <summary> Gets the API Products. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ApiManagementProductResource> GetApiProductsAsync(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<ApiManagementProductData, ApiManagementProductResource>(
                GetApiProductsRawAsync(filter, top, skip, cancellationToken),
                data => data is null ? null : new ApiManagementProductResource(Client, data));

        /// <summary> Gets the API Products. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ApiManagementProductResource> GetApiProducts(string filter = default, int? top = default, int? skip = default, CancellationToken cancellationToken = default)
            => new PageableWrapper<ApiManagementProductData, ApiManagementProductResource>(
                GetApiProductsRaw(filter, top, skip, cancellationToken),
                data => data is null ? null : new ApiManagementProductResource(Client, data));
    }
}
