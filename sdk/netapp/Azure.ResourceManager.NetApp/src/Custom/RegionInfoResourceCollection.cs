// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    // RegionInfoResourceCollection retained from the GA SDK. The new spec replaces this
    // subscription-region-scoped collection with a single RegionInfoResource (subscription-scoped
    // queryRegionInfo action). Members throw — callers should migrate.
    /// <summary> Legacy region-info collection (replaced by <see cref="RegionInfoResource"/>). </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class RegionInfoResourceCollection : ArmCollection, IEnumerable<RegionInfoResource>, IAsyncEnumerable<RegionInfoResource>
    {
        /// <summary> Initializes a new instance for mocking. </summary>
        protected RegionInfoResourceCollection()
        {
        }

        /// <summary> Gets a region info resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RegionInfoResource> Get(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated RegionInfoResourceCollection type.");
        }

        /// <summary> Gets a region info resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<RegionInfoResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated RegionInfoResourceCollection type.");
        }

        /// <summary> Gets all region info resources. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<RegionInfoResource> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated RegionInfoResourceCollection type.");
        }

        /// <summary> Gets all region info resources. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<RegionInfoResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated RegionInfoResourceCollection type.");
        }

        /// <summary> Checks if a region info resource exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated RegionInfoResourceCollection type.");
        }

        /// <summary> Checks if a region info resource exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated RegionInfoResourceCollection type.");
        }

        /// <summary> Gets a region info resource if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<RegionInfoResource> GetIfExists(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated RegionInfoResourceCollection type.");
        }

        /// <summary> Gets a region info resource if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<RegionInfoResource>> GetIfExistsAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated RegionInfoResourceCollection type.");
        }

        IEnumerator<RegionInfoResource> IEnumerable<RegionInfoResource>.GetEnumerator() => throw new NotSupportedException("Deprecated type.");
        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException("Deprecated type.");
        IAsyncEnumerator<RegionInfoResource> IAsyncEnumerable<RegionInfoResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException("Deprecated type.");
    }
}
