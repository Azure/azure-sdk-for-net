// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// AccessControlChanges contains batch and cumulative counts of operations that change Access Control Lists recursively.
    /// Additionally it exposes path entries that failed to update while these operations progress.
    /// </summary>
    public struct AccessControlChanges
    {
        /// <summary>
        /// An enumerable of path entries that failed to update Access Control List within single batch.
        /// </summary>
        public AccessControlChangeFailure[] BatchFailures { get; internal set; }

        /// <summary>
        /// A <see cref="AccessControlChangeCounters"/> that contains counts of paths changed within single batch.
        /// </summary>
        public AccessControlChangeCounters BatchCounters { get; internal set; }

        /// <summary>
        /// A <see cref="AccessControlChangeCounters"/> that contains counts of paths changed from start of the operation.
        /// </summary>
        public AccessControlChangeCounters AggregateCounters { get; internal set; }

        /// <summary>
        /// Optional continuation token. Value is present when operation is split into multiple batches and can be used to resume progress.
        /// </summary>
        public string ContinuationToken { get; internal set; }
    }
}
