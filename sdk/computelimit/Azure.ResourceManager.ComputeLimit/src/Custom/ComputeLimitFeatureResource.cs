// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ComputeLimit
{
    public partial class ComputeLimitFeatureResource
    {
        // an optional parameter is added into Enable before cancellationToken in 1.1.0 version. this overload mitigates that breaking change.
        /// <summary>
        /// Enables a compute limit feature for the subscription at the specified location.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<OperationStatusResult> Enable(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Enable(waitUntil, null, cancellationToken);

        // an optional parameter is added into Enable before cancellationToken in 1.1.0 version. this overload mitigates that breaking change.
        /// <summary>
        /// Enables a compute limit feature for the subscription at the specified location.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<OperationStatusResult>> EnableAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => EnableAsync(waitUntil, null, cancellationToken);
    }
}
