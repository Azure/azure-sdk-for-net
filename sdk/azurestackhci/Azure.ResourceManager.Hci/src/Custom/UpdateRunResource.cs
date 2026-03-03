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
    /// <summary> Backward-compat alias for HciClusterUpdateRunResource. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateRunResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateRunResource : HciClusterUpdateRunResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new ResourceType ResourceType = HciClusterUpdateRunResource.ResourceType;

        /// <summary> Gets the data representing this Feature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new UpdateRunData Data => (UpdateRunData)(object)base.Data;

        /// <summary> Initializes a new instance of <see cref="UpdateRunResource"/>. </summary>
        protected UpdateRunResource()
        {
        }

        /// <summary> Get the Update run for a specified update. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Response<UpdateRunResource> Get(CancellationToken cancellationToken)
        {
            var response = base.Get(cancellationToken);
            return Response.FromValue((UpdateRunResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Get the Update run for a specified update. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<Response<UpdateRunResource>> GetAsync(CancellationToken cancellationToken)
        {
            var response = await base.GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue((UpdateRunResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Put Update runs for a specified update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="data"> The update run data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<UpdateRunResource> Update(WaitUntil waitUntil, UpdateRunData data, CancellationToken cancellationToken)
        {
            var operation = base.Update(waitUntil, data, cancellationToken);
            return new ArmOperationWrapper<HciClusterUpdateRunResource, UpdateRunResource>(operation);
        }

        /// <summary> Put Update runs for a specified update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="data"> The update run data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<UpdateRunResource>> UpdateAsync(WaitUntil waitUntil, UpdateRunData data, CancellationToken cancellationToken)
        {
            var operation = await base.UpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
            return new ArmOperationWrapper<HciClusterUpdateRunResource, UpdateRunResource>(operation);
        }
    }
}
