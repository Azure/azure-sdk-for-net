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
    // Customization restores back-compat overloads on DataFactoryIntegrationRuntimeCollection where the MPG generator changed the
    // If-Match/If-None-Match header parameter type from `string` to `ETag?` (ARM common-types v6 models them
    // as `Azure.ETag`). Wrappers convert `string` -> `ETag?` for CreateOrUpdate/Get/Exists so existing call
    // sites compile unchanged; the on-the-wire request is identical. Marked [EditorBrowsable(Never)] to
    // discourage new usage of the legacy signatures.
    public partial class DataFactoryIntegrationRuntimeCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryIntegrationRuntimeResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string integrationRuntimeName, DataFactoryIntegrationRuntimeData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, integrationRuntimeName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryIntegrationRuntimeResource> CreateOrUpdate(WaitUntil waitUntil, string integrationRuntimeName, DataFactoryIntegrationRuntimeData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, integrationRuntimeName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryIntegrationRuntimeResource>> GetAsync(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryIntegrationRuntimeResource> Get(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Exists(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DataFactoryIntegrationRuntimeResource>> GetIfExistsAsync(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DataFactoryIntegrationRuntimeResource> GetIfExists(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetIfExists(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
