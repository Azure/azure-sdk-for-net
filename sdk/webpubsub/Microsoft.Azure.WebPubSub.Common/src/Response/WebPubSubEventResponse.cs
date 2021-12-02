﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// A general type of Web PubSub service response to send to service.
    /// </summary>
    public abstract class WebPubSubEventResponse
    {
        /// <summary>
        /// Reserved code for json deserilize to correct derived response.
        /// Default to <see cref="WebPubSubStatusCode.Success"/>.
        /// </summary>
        internal virtual WebPubSubStatusCode StatusCode { get; set; }
    }
}
