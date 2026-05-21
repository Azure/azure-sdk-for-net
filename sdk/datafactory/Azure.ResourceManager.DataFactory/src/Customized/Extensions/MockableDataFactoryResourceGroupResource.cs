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

namespace Azure.ResourceManager.DataFactory.Mocking
{
    // Customization restores back-compat overloads on MockableDataFactoryResourceGroupResource where
    // the MPG generator changed the If-None-Match header parameter type on GetDataFactory/GetDataFactoryAsync
    // from `string` to `ETag?` (ARM common-types v6 models it as `Azure.ETag`). These wrappers convert
    // `string` -> `ETag?` so existing mocking call sites compile unchanged. The on-the-wire request is
    // identical. Marked [EditorBrowsable(Never)] to discourage new usage of the legacy signatures.
    public partial class MockableDataFactoryResourceGroupResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryResource>> GetDataFactoryAsync(string factoryName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryAsync(factoryName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryResource> GetDataFactory(string factoryName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactory(factoryName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
