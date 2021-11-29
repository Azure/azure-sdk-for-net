// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Message data type.
    /// </summary>
    public enum WebPubSubDataType
    {
        /// <summary>
        /// binary of content type application/octet-stream.
        /// </summary>
        Binary,
        /// <summary>
        /// json of content type application/json.
        /// </summary>
        Json,
        /// <summary>
        /// text of content type text/plain.
        /// </summary>
        Text
    }
}
