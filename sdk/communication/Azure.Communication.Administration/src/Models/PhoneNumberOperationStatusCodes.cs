// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Administration.Models
{
    /// <summary> Status code of the operation. </summary>
    [CodeGenModel("PhoneNumberOperationStatusCodes")]
    internal enum PhoneNumberOperationStatusCodes
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
