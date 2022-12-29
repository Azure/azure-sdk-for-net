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
        /// The data content is json.
        /// </summary>
        Json = 0,
        /// <summary>
        /// The data content is plain text.
        /// </summary>
        Text = 1,
        /// <summary>
        /// The data content is binary.
        /// </summary>
        Binary = 2,
        /// <summary>
        /// The data content is protobuf.
        /// </summary>
        Protobuf = 3,
    }
}
