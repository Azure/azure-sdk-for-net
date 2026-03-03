// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateResource. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateResource : HciClusterUpdateResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new ResourceType ResourceType => HciClusterUpdateResource.ResourceType;

        /// <summary> Gets the data representing this Feature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new UpdateData Data => (UpdateData)(object)base.Data;

        /// <summary> Initializes a new instance of <see cref="UpdateResource"/>. </summary>
        protected UpdateResource()
        {
        }

        /// <summary> Get Update resource details. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Response<UpdateResource> Get(CancellationToken cancellationToken)
        {
            var response = base.Get(cancellationToken);
            return Response.FromValue((UpdateResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Get Update resource details. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new async Task<Response<UpdateResource>> GetAsync(CancellationToken cancellationToken)
        {
            var response = await base.GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue((UpdateResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Put specified Update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="data"> The update data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ArmOperation<UpdateResource> Update(WaitUntil waitUntil, UpdateData data, CancellationToken cancellationToken)
        {
            var operation = base.Update(waitUntil, data, cancellationToken);
            return new ArmOperationWrapper<HciClusterUpdateResource, UpdateResource>(operation);
        }

        /// <summary> Put specified Update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="data"> The update data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<ArmOperation<UpdateResource>> UpdateAsync(WaitUntil waitUntil, UpdateData data, CancellationToken cancellationToken)
        {
            var operation = await base.UpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
            return new ArmOperationWrapper<HciClusterUpdateResource, UpdateResource>(operation);
        }

        /// <summary> Gets a collection of HciClusterUpdateRunResources in the HciClusterUpdate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UpdateRunCollection GetUpdateRuns()
        {
            return (UpdateRunCollection)(object)GetHciClusterUpdateRuns();
        }

        /// <summary> Gets a UpdateRun resource. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Response<UpdateRunResource> GetUpdateRun(string updateRunName, CancellationToken cancellationToken)
        {
            var response = GetHciClusterUpdateRun(updateRunName, cancellationToken);
            return Response.FromValue((UpdateRunResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Gets a UpdateRun resource. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<Response<UpdateRunResource>> GetUpdateRunAsync(string updateRunName, CancellationToken cancellationToken)
        {
            var response = await GetHciClusterUpdateRunAsync(updateRunName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue((UpdateRunResource)(object)response.Value, response.GetRawResponse());
        }
    }
}
