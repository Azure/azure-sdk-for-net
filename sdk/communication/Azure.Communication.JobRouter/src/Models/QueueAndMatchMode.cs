// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Used to specify default behavior of greedy matching of jobs and worker.
    /// </summary>
    public class QueueAndMatchMode : JobMatchingMode
    {
        /// <inheritdoc />
        public override string Kind => nameof(QueueAndMatchMode);
    }
}
