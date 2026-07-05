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
    /// <summary> Backward-compat alias for HciClusterUpdateCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateCollection : HciClusterUpdateCollection, IEnumerable<UpdateResource>, IAsyncEnumerable<UpdateResource>
    {
        /// <summary> Initializes a new instance of <see cref="UpdateCollection"/>. </summary>
        protected UpdateCollection()
        {
        }

        IEnumerator<UpdateResource> IEnumerable<UpdateResource>.GetEnumerator()
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateCollection instead.");
        }

        IAsyncEnumerator<UpdateResource> IAsyncEnumerable<UpdateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateCollection instead.");
        }

        /// <summary> Get specified Update. </summary>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Response<UpdateResource> Get(string updateName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateCollection instead.");
        }

        /// <summary> Get specified Update. </summary>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<Response<UpdateResource>> GetAsync(string updateName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateCollection instead.");
        }

        /// <summary> List all Updates. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Pageable<UpdateResource> GetAll(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateCollection instead.");
        }

        /// <summary> List all Updates. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new AsyncPageable<UpdateResource> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateCollection instead.");
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new NullableResponse<UpdateResource> GetIfExists(string updateName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateCollection instead.");
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<NullableResponse<UpdateResource>> GetIfExistsAsync(string updateName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateCollection instead.");
        }

        /// <summary> Put specified Update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="data"> The update data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<UpdateResource> CreateOrUpdate(WaitUntil waitUntil, string updateName, UpdateData data, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateCollection instead.");
        }

        /// <summary> Put specified Update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="data"> The update data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<UpdateResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string updateName, UpdateData data, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateCollection instead.");
        }
    }
}
