// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Web PubSub service request.
    /// </summary>
    public abstract class WebPubSubEventRequest
    {
        /// <summary>
        /// Connection context contains connection metadata following CloudEvents.
        /// </summary>
        [JsonPropertyName("connectionContext")]
        public WebPubSubConnectionContext ConnectionContext { get; set; }
    }
}
