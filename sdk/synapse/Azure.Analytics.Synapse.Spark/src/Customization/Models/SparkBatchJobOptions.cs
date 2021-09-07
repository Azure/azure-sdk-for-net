// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Analytics.Synapse.Spark.Models
{
    public partial class SparkBatchJobOptions
    {
        /// <summary> Initializes a new instance of SparkBatchJobOptions. </summary>
        /// <param name="name"></param>
        /// <param name="file"></param>
        /// <param name="creationCompletionType"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="file"/> is null. </exception>
        public SparkBatchJobOptions(string name, string file, SparkBatchOperationCompletionType creationCompletionType) : this(name, file)
        {
            CreationCompletionType = creationCompletionType;
        }

        public SparkBatchOperationCompletionType CreationCompletionType { get; set; } = SparkBatchOperationCompletionType.JobSubmission;
    }
}
