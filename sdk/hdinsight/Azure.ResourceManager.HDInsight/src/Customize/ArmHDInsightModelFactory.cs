// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;

namespace Azure.ResourceManager.HDInsight.Models
{
    // The HDInsightAsyncOperationResult factory method was removed during TypeSpec migration
    // because the model itself was suppressed. It is re-added here for backward compatibility.
    public static partial class ArmHDInsightModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.HDInsightAsyncOperationResult"/>. </summary>
        /// <param name="status"> The async operation state. </param>
        /// <param name="error"> The operation error information. </param>
        /// <returns> A new <see cref="Models.HDInsightAsyncOperationResult"/> instance for mocking. </returns>
        public static HDInsightAsyncOperationResult HDInsightAsyncOperationResult(HDInsightAsyncOperationState? status = default, ResponseError error = default)
        {
            return new HDInsightAsyncOperationResult(status, error);
        }
    }
}
