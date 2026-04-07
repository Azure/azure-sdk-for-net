// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Spark.Models
{
    /// <summary>
    /// Describes the different ways of Spark batch job operation could complete.
    /// If <see cref="JobSubmission"/> is used, the operation will be considered as complete when Livy state is starting/running/error/dead/success/killed.
    /// If <see cref="JobExecution"/> is used, the operation will be considered as complete when Livy state is error/dead/success/killed.
    /// </summary>
    public enum SparkBatchOperationCompletionType
    {
        JobSubmission,
        JobExecution
    }
}
