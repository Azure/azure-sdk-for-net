// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// AccessControlChangeResult contains result of operations that change Access Control Lists recursively.
    /// </summary>
    public struct AccessControlChangeResult
    {
        /// <summary>
        /// A <see cref="AccessControlChangeCounters"/> that contains counts of paths changed from start of the operation.
        /// </summary>
        public AccessControlChangeCounters Counters { get; internal set; }

        /// <summary>
        /// Optional continuation token. Value is present when operation is split into multiple batches and can be used to resume progress.
        /// </summary>
        public string ContinuationToken { get; internal set; }

        /// <summary>
        /// Optional Batch Failures when <see cref="AccessControlChangeOptions.RetrieveBatchFailures"/> is set to true.
        /// An enumerable of path entries that failed to update Access Control List within single batch.
        /// If <see cref="AccessControlChangeOptions.ContinueOnFailure"/> is set to true,
        /// then the value will contain the first batch of failures seen.
        /// Otherwise the last batch of failures seen will be set.
        /// </summary>
        public AccessControlChangeFailure[] BatchFailures { get; internal set; }
    }
}
