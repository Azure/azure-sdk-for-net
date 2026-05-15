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
    public partial class DataFactoryLinkedServiceCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryLinkedServiceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string linkedServiceName, DataFactoryLinkedServiceData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, linkedServiceName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryLinkedServiceResource> CreateOrUpdate(WaitUntil waitUntil, string linkedServiceName, DataFactoryLinkedServiceData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, linkedServiceName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryLinkedServiceResource>> GetAsync(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryLinkedServiceResource> Get(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Exists(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DataFactoryLinkedServiceResource>> GetIfExistsAsync(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DataFactoryLinkedServiceResource> GetIfExists(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetIfExists(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
