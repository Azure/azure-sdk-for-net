// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// Operation status.
    /// </summary>
    [CodeGenModel("OperationInfoStatus")]
    public enum DocumentOperationStatus
    {
        /// <summary> notStarted. </summary>
        NotStarted,
        /// <summary> running. </summary>
        Running,
        /// <summary> failed. </summary>
        Failed,
        /// <summary> succeeded. </summary>
        Succeeded,
        /// <summary> canceled. </summary>
        Canceled
    }
}
