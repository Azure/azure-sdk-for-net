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
    public partial class DataFactoryChangeDataCaptureCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryChangeDataCaptureResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string changeDataCaptureName, DataFactoryChangeDataCaptureData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, changeDataCaptureName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryChangeDataCaptureResource> CreateOrUpdate(WaitUntil waitUntil, string changeDataCaptureName, DataFactoryChangeDataCaptureData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, changeDataCaptureName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryChangeDataCaptureResource>> GetAsync(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryChangeDataCaptureResource> Get(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Exists(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DataFactoryChangeDataCaptureResource>> GetIfExistsAsync(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DataFactoryChangeDataCaptureResource> GetIfExists(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetIfExists(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
