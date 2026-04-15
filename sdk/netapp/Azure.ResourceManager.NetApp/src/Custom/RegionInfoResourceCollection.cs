// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A backward-compat stub for the removed RegionInfoResourceCollection type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class RegionInfoResourceCollection : ArmCollection
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
    }
}
