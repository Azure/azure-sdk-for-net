// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Email
{
    /// <summary> Status of the long running operation. </summary>
    public partial class EmailSendResult
    {
        /// <summary> The unique id of the operation. Use a UUID. </summary>
        internal string Id { get; }
    }
}
