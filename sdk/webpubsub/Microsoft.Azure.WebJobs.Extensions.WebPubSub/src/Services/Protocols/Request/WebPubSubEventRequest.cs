// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Web PubSub service request.
    /// </summary>
    public abstract class WebPubSubEventRequest
    {
        internal const string ConnectionContextProperty = "connectionContext";
        internal const string NameProperty = "name";

        /// <summary>
        /// Connection context contains connection metadata following CloudEvents.
        /// </summary>
        [JsonPropertyName(ConnectionContextProperty)]
        public WebPubSubConnectionContext ConnectionContext { get; internal set;}

        /// <summary>
        /// Create instance of <see cref="WebPubSubEventRequest"/>
        /// </summary>
        /// <param name="context">Parameter connection context.</param>
        public WebPubSubEventRequest(WebPubSubConnectionContext context)
        {
            ConnectionContext = context;
        }
    }
}
