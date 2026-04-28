// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateResource. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateResource : HciClusterUpdateResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new ResourceType ResourceType = HciClusterUpdateResource.ResourceType;

        /// <summary> Gets the data representing this Feature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new UpdateData Data => throw new NotSupportedException("This class is obsolete. Please use HciClusterUpdateResource instead.");

        /// <summary> Initializes a new instance of <see cref="UpdateResource"/>. </summary>
        protected UpdateResource()
        {
        }

        /// <summary> Get Update resource details. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Response<UpdateResource> Get(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateResource instead.");
        }

        /// <summary> Get Update resource details. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<Response<UpdateResource>> GetAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateResource instead.");
        }

        /// <summary> Put specified Update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="data"> The update data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<UpdateResource> Update(WaitUntil waitUntil, UpdateData data, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateResource instead.");
        }

        /// <summary> Put specified Update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="data"> The update data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<UpdateResource>> UpdateAsync(WaitUntil waitUntil, UpdateData data, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateResource instead.");
        }

        /// <summary> Gets a collection of HciClusterUpdateRunResources in the HciClusterUpdate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual UpdateRunCollection GetUpdateRuns()
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateResource instead.");
        }

        /// <summary> Gets a UpdateRun resource. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<UpdateRunResource> GetUpdateRun(string updateRunName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateResource instead.");
        }

        /// <summary> Gets a UpdateRun resource. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<UpdateRunResource>> GetUpdateRunAsync(string updateRunName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateResource instead.");
        }
    }
}
