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
    public partial class DataFactoryManagedVirtualNetworkResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryManagedVirtualNetworkResource>> GetAsync(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryManagedVirtualNetworkResource> Get(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryManagedVirtualNetworkResource>> UpdateAsync(WaitUntil waitUntil, DataFactoryManagedVirtualNetworkData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryManagedVirtualNetworkResource> Update(WaitUntil waitUntil, DataFactoryManagedVirtualNetworkData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPrivateEndpointResource>> GetDataFactoryPrivateEndpointAsync(string managedPrivateEndpointName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryPrivateEndpointAsync(managedPrivateEndpointName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPrivateEndpointResource> GetDataFactoryPrivateEndpoint(string managedPrivateEndpointName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryPrivateEndpoint(managedPrivateEndpointName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
