// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedInstanceOperationCollection
    {
        public virtual Task<NullableResponse<ManagedInstanceOperationResource>> GetIfExistsAsync(Guid operationId, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(operationId.ToString(), cancellationToken);

        public virtual NullableResponse<ManagedInstanceOperationResource> GetIfExists(Guid operationId, CancellationToken cancellationToken = default)
            => GetIfExists(operationId.ToString(), cancellationToken);
    }
}
