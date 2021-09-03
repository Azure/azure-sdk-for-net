// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Message data type.
    /// </summary>
    public enum MessageDataType
    {
        /// <summary>
        /// binary of application/octet-stream.
        /// </summary>
        Binary,
        /// <summary>
        /// json of application/json.
        /// </summary>
        Json,
        /// <summary>
        /// text of text/plain.
        /// </summary>
        Text
    }
}
