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
    // Customization on DataFactoryTriggerResource restores upstream back-compat surfaces dropped by
    // MPG generation:
    //  1) `string ifNoneMatch` / `string ifMatch` overloads of Get/Update. The MPG generator types the
    //     ARM common-types v6 If-None-Match / If-Match headers as `Azure.ETag?`; these wrappers accept
    //     `string` and forward to the ETag overload so existing call sites compile unchanged. The
    //     on-the-wire request is identical.
    //  2) `Pageable<T>` / `AsyncPageable<T>` for trigger runs query operations (when present). The
    //     spec marks these operations as paged via `x-ms-pageable` in swagger but the TypeSpec
    //     migration loses that marker, so the MPG generator emits a single non-paged response.
    public partial class DataFactoryTriggerResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryTriggerResource>> GetAsync(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryTriggerResource> Get(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryTriggerResource>> UpdateAsync(WaitUntil waitUntil, DataFactoryTriggerData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryTriggerResource> Update(WaitUntil waitUntil, DataFactoryTriggerData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }
    }
}
