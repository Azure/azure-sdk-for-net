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
