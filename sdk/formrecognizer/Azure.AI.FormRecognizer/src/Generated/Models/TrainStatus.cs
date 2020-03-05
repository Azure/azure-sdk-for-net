// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Status of the training operation. </summary>
    public enum TrainStatus
    {
        /// <summary> succeeded. </summary>
        Succeeded,
        /// <summary> partiallySucceeded. </summary>
        PartiallySucceeded,
        /// <summary> failed. </summary>
        Failed
    }
}
