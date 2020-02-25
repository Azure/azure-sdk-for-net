// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Status of the queued operation. </summary>
    public enum OperationStatus
    {
        /// <summary> notStarted. </summary>
        NotStarted,
        /// <summary> running. </summary>
        Running,
        /// <summary> succeeded. </summary>
        Succeeded,
        /// <summary> failed. </summary>
        Failed
    }
}
