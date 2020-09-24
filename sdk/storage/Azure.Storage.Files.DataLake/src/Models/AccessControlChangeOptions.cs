// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// AccessControlChangeOptions contain knobs used to customize recursive Access Control operations.
    /// </summary>
    public class AccessControlChangeOptions
    {
        /// <summary>
        /// Optional. If data set size exceeds batch size then operation will be split into multiple requests so that progress can be tracked.
        /// Batch size should be between 1 and 2000. The default when unspecified is 2000.
        /// </summary>
        public int? BatchSize { get; set; }

        /// <summary>
        /// Optional. Defines maximum number of batches that single change Access Control operation can execute.
        /// If maximum is reached before all subpaths are processed then continuation token can be used to resume operation.
        /// Empty value indicates that maximum number of batches in unbound and operation continues till end.
        /// </summary>
        public int? MaxBatches { get; set; }

        /// <summary>
        /// Optional. If set to false, the operation will terminate quickly on encountering user failures. If true, the operation will ignore
        /// user failures and proceed with the operation on other sub-entities of the directory.
        /// </summary>
        public bool? ContinueOnFailure { get; set; }

        /// <summary>
        /// Optional. <see cref="Progress{AccessControlChanges}"/> callback where caller can track progress of the operation
        /// as well as collect paths that failed to change Access Control.
        /// </summary>
        public IProgress<Response<AccessControlChanges>> ProgressHandler { get; set; }
    }
}
