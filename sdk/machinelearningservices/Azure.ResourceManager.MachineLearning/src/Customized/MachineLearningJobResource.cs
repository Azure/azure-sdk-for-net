// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningJobResource
    {
        /// <summary>
        /// Updates a Job.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Job definition object. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<MachineLearningJobResource>> UpdateAsync(WaitUntil waitUntil, MachineLearningJobData data)
            => UpdateAsync(waitUntil, data, CancellationToken.None);
    }
}
