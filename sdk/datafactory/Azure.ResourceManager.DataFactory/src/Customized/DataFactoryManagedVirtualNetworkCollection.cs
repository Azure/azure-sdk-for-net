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
    // Customization restores back-compat overloads on DataFactoryManagedVirtualNetworkCollection where the MPG generator changed the
    // If-Match/If-None-Match header parameter type from `string` to `ETag?` (ARM common-types v6 models them
    // as `Azure.ETag`). Wrappers convert `string` -> `ETag?` for CreateOrUpdate/Get/Exists so existing call
    // sites compile unchanged; the on-the-wire request is identical. Marked [EditorBrowsable(Never)] to
    // discourage new usage of the legacy signatures.
    public partial class DataFactoryManagedVirtualNetworkCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryManagedVirtualNetworkResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string managedVirtualNetworkName, DataFactoryManagedVirtualNetworkData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, managedVirtualNetworkName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryManagedVirtualNetworkResource> CreateOrUpdate(WaitUntil waitUntil, string managedVirtualNetworkName, DataFactoryManagedVirtualNetworkData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, managedVirtualNetworkName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryManagedVirtualNetworkResource>> GetAsync(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryManagedVirtualNetworkResource> Get(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Exists(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DataFactoryManagedVirtualNetworkResource>> GetIfExistsAsync(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DataFactoryManagedVirtualNetworkResource> GetIfExists(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetIfExists(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
