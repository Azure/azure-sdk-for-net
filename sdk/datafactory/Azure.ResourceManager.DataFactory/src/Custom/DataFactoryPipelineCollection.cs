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
    public partial class DataFactoryPipelineCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryPipelineResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string pipelineName, DataFactoryPipelineData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, pipelineName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryPipelineResource> CreateOrUpdate(WaitUntil waitUntil, string pipelineName, DataFactoryPipelineData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, pipelineName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPipelineResource>> GetAsync(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPipelineResource> Get(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Exists(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DataFactoryPipelineResource>> GetIfExistsAsync(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DataFactoryPipelineResource> GetIfExists(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetIfExists(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
