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
    /// <summary> Backward-compat alias for HciClusterUpdateSummaryResource. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateSummaryResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateSummaryResource : HciClusterUpdateSummaryResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new ResourceType ResourceType = HciClusterUpdateSummaryResource.ResourceType;

        /// <summary> Gets the data representing this Feature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new UpdateSummaryData Data => throw new NotSupportedException("This class is obsolete. Please use HciClusterUpdateSummaryResource instead.");

        /// <summary> Initializes a new instance of <see cref="UpdateSummaryResource"/>. </summary>
        protected UpdateSummaryResource()
        {
        }

        /// <summary> Get the update summary. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Response<UpdateSummaryResource> Get(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateSummaryResource instead.");
        }

        /// <summary> Get the update summary. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<Response<UpdateSummaryResource>> GetAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateSummaryResource instead.");
        }

        /// <summary> Put Update summaries. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="data"> The update summary data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<UpdateSummaryResource> CreateOrUpdate(WaitUntil waitUntil, UpdateSummaryData data, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateSummaryResource instead.");
        }

        /// <summary> Put Update summaries. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="data"> The update summary data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<UpdateSummaryResource>> CreateOrUpdateAsync(WaitUntil waitUntil, UpdateSummaryData data, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdateSummaryResource instead.");
        }
    }
}
