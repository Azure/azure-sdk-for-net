// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiGatewayCollection
    {
        // Old SDK had GetAll(CancellationToken); new generator adds top/skipToken params.
        // Not spec-fixable: C# convenience overload.

        /// <summary> Gets all the API gateways in the collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ApiGatewayResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(default, default, cancellationToken);

        /// <summary> Gets all the API gateways in the collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ApiGatewayResource> GetAll(CancellationToken cancellationToken)
            => GetAll(default, default, cancellationToken);
    }
}
