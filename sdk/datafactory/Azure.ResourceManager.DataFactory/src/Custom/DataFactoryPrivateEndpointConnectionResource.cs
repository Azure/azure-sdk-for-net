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
    public partial class DataFactoryPrivateEndpointConnectionResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPrivateEndpointConnectionResource>> GetAsync(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPrivateEndpointConnectionResource> Get(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryPrivateEndpointConnectionResource>> UpdateAsync(WaitUntil waitUntil, DataFactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, content, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryPrivateEndpointConnectionResource> Update(WaitUntil waitUntil, DataFactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, content, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }
    }
}
