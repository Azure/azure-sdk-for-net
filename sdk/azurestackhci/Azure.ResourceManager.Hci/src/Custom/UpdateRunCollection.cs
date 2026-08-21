// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateRunCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateRunCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateRunCollection : HciClusterUpdateRunCollection, IEnumerable<UpdateRunResource>, IAsyncEnumerable<UpdateRunResource>
    {
        /// <summary> Initializes a new instance of <see cref="UpdateRunCollection"/>. </summary>
        protected UpdateRunCollection()
        {
        }

        IEnumerator<UpdateRunResource> IEnumerable<UpdateRunResource>.GetEnumerator()
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateRunCollection instead.");
        }

        IAsyncEnumerator<UpdateRunResource> IAsyncEnumerable<UpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateRunCollection instead.");
        }

        /// <summary> Get the Update run for a specified update. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Response<UpdateRunResource> Get(string updateRunName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateRunCollection instead.");
        }

        /// <summary> Get the Update run for a specified update. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<Response<UpdateRunResource>> GetAsync(string updateRunName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateRunCollection instead.");
        }

        /// <summary> List all Update runs. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Pageable<UpdateRunResource> GetAll(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateRunCollection instead.");
        }

        /// <summary> List all Update runs. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new AsyncPageable<UpdateRunResource> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateRunCollection instead.");
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new NullableResponse<UpdateRunResource> GetIfExists(string updateRunName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateRunCollection instead.");
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<NullableResponse<UpdateRunResource>> GetIfExistsAsync(string updateRunName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateRunCollection instead.");
        }

        /// <summary> Put Update runs for a specified update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="data"> The update run data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<UpdateRunResource> CreateOrUpdate(WaitUntil waitUntil, string updateRunName, UpdateRunData data, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateRunCollection instead.");
        }

        /// <summary> Put Update runs for a specified update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="data"> The update run data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<UpdateRunResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string updateRunName, UpdateRunData data, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateRunCollection instead.");
        }
    }
}
