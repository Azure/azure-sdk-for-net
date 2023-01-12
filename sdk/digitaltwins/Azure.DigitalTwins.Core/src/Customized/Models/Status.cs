// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    [CodeGenModel("Status")]
    internal enum Status
    {
        /// <summary> notstarted. </summary>
        Notstarted,
        /// <summary> running. </summary>
        Running,
        /// <summary> failed. </summary>
        Failed,
        /// <summary> succeeded. </summary>
        Succeeded,
        /// <summary> cancelling. </summary>
        Cancelling,
        /// <summary> cancelled. </summary>
        Cancelled
    }
}
