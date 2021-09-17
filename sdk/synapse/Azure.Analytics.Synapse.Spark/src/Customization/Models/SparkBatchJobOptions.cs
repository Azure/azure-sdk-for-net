// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Analytics.Synapse.Spark.Models
{
    /// <summary> The SparkBatchJobOptions. </summary>
    public partial class SparkBatchJobOptions
    {
        /// <summary> Initializes a new instance of SparkBatchJobOptions. </summary>
        /// <param name="name"></param>
        /// <param name="file"></param>
        /// <param name="creationCompletionType"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="file"/> is null. </exception>
        public SparkBatchJobOptions(string name, string file, SparkBatchOperationCompletionType creationCompletionType = SparkBatchOperationCompletionType.JobSubmission) : this(name, file)
        {
            CreationCompletionType = creationCompletionType;
        }

        /// <summary>
        /// Describes the different ways of Spark batch job operation could complete.
        /// If <see cref="SparkBatchOperationCompletionType.JobSubmission"/> is used, the operation will be considered as complete when Livy state is starting/running/error/dead/success/killed.
        /// If <see cref="SparkBatchOperationCompletionType.JobExecution"/> is used, the operation will be considered as complete when Livy state is error/dead/success/killed.
        /// </summary>
        public SparkBatchOperationCompletionType CreationCompletionType { get; set; }
    }
}
