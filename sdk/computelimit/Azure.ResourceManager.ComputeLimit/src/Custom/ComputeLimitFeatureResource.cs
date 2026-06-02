// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ComputeLimit
{
    public partial class ComputeLimitFeatureResource
    {
        /// <summary> Backward-compatible overload that preserves the 1.0.0 API surface. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<OperationStatusResult> Enable(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Enable(waitUntil, null, cancellationToken);

        /// <summary> Backward-compatible overload that preserves the 1.0.0 API surface. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation<OperationStatusResult>> EnableAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => EnableAsync(waitUntil, null, cancellationToken);
    }
}
