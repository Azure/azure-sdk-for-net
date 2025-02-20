// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary> Operation status. </summary>
    internal enum AnalyzeResultOperationStatus
    {
        /// <summary> notStarted. </summary>
        NotStarted,
        /// <summary> running. </summary>
        Running,
        /// <summary> failed. </summary>
        Failed,
        /// <summary> succeeded. </summary>
        Succeeded
    }
}
