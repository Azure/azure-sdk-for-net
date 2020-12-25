// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
namespace Azure.AI.FormRecognizer
{
    [CodeGenModel("OperationStatus")]
    internal enum OperationStatus
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
