// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// Represent the type of the data.
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
        Text,
        /// <summary>
        /// protobuf of content type application/x-protobuf.
        /// </summary>
        Protobuf,
    }
}
