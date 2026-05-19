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
    public partial class DataFactoryPrivateEndpointCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryPrivateEndpointResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string managedPrivateEndpointName, DataFactoryPrivateEndpointData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, managedPrivateEndpointName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryPrivateEndpointResource> CreateOrUpdate(WaitUntil waitUntil, string managedPrivateEndpointName, DataFactoryPrivateEndpointData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, managedPrivateEndpointName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPrivateEndpointResource>> GetAsync(string managedPrivateEndpointName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(managedPrivateEndpointName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPrivateEndpointResource> Get(string managedPrivateEndpointName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(managedPrivateEndpointName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string managedPrivateEndpointName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(managedPrivateEndpointName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string managedPrivateEndpointName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Exists(managedPrivateEndpointName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DataFactoryPrivateEndpointResource>> GetIfExistsAsync(string managedPrivateEndpointName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(managedPrivateEndpointName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DataFactoryPrivateEndpointResource> GetIfExists(string managedPrivateEndpointName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetIfExists(managedPrivateEndpointName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
