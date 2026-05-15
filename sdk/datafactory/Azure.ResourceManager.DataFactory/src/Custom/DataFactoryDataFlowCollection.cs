// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;
using Azure.ResourceManager.DataFactory.Models;

#pragma warning disable CS1591

namespace Azure.ResourceManager.DataFactory
{
    public partial class DataFactoryDataFlowCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryDataFlowResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string dataFlowName, DataFactoryDataFlowData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, dataFlowName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryDataFlowResource> CreateOrUpdate(WaitUntil waitUntil, string dataFlowName, DataFactoryDataFlowData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, dataFlowName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryDataFlowResource>> GetAsync(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryDataFlowResource> Get(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Exists(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DataFactoryDataFlowResource>> GetIfExistsAsync(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DataFactoryDataFlowResource> GetIfExists(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetIfExists(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
