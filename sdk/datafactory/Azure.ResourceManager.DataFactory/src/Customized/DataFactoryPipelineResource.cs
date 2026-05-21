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
    // Customization restores back-compat overloads on DataFactoryPipelineResource where the MPG generator
    // changed the If-None-Match/If-Match header parameter type from `string` to `ETag?` (ARM common-types v6
    // models them as `Azure.ETag`). These wrappers convert `string` -> `ETag?` so existing call sites compile
    // unchanged and the on-the-wire request is identical. Marked [EditorBrowsable(Never)] to discourage
    // new usage of the legacy signatures.
    public partial class DataFactoryPipelineResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPipelineResource>> GetAsync(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPipelineResource> Get(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryPipelineResource>> UpdateAsync(WaitUntil waitUntil, DataFactoryPipelineData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryPipelineResource> Update(WaitUntil waitUntil, DataFactoryPipelineData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }
    }
}
