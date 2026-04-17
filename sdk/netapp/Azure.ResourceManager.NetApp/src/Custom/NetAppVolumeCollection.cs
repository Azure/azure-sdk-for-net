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
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// Backward-compatible wrapper for volume collection operations.
    /// This type is deprecated. Use <see cref="VolumeCollection"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppVolumeCollection : ArmCollection, IEnumerable<NetAppVolumeResource>, IAsyncEnumerable<NetAppVolumeResource>
    {
        /// <summary> Initializes a new instance of <see cref="NetAppVolumeCollection"/>. </summary>
        protected NetAppVolumeCollection()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetAppVolumeCollection"/>. </summary>
        internal NetAppVolumeCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Create or update a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetAppVolumeResource> CreateOrUpdate(WaitUntil waitUntil, string volumeName, NetAppVolumeData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeCollection type. Use VolumeCollection instead.");
        }

        /// <summary> Create or update a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetAppVolumeResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string volumeName, NetAppVolumeData data, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeCollection type. Use VolumeCollection instead.");
        }

        /// <summary> Get a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeResource> Get(string volumeName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeCollection type. Use VolumeCollection instead.");
        }

        /// <summary> Get a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppVolumeResource>> GetAsync(string volumeName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeCollection type. Use VolumeCollection instead.");
        }

        /// <summary> Get all volumes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppVolumeResource> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeCollection type. Use VolumeCollection instead.");
        }

        /// <summary> Get all volumes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppVolumeResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeCollection type. Use VolumeCollection instead.");
        }

        /// <summary> Check if a volume exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string volumeName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeCollection type. Use VolumeCollection instead.");
        }

        /// <summary> Check if a volume exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string volumeName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeCollection type. Use VolumeCollection instead.");
        }

        /// <summary> Get a volume if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<NetAppVolumeResource> GetIfExists(string volumeName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeCollection type. Use VolumeCollection instead.");
        }

        /// <summary> Get a volume if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<NetAppVolumeResource>> GetIfExistsAsync(string volumeName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeCollection type. Use VolumeCollection instead.");
        }

        IEnumerator<NetAppVolumeResource> IEnumerable<NetAppVolumeResource>.GetEnumerator() => throw new NotSupportedException("This type is deprecated. Use VolumeCollection instead.");
        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException("This type is deprecated. Use VolumeCollection instead.");
        IAsyncEnumerator<NetAppVolumeResource> IAsyncEnumerable<NetAppVolumeResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException("This type is deprecated. Use VolumeCollection instead.");
    }
}
