// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Web PubSub service request.
    /// </summary>
    public abstract class WebPubSubEventRequest
    {
        internal const string ConnectionContextProperty = "connectionContext";

        /// <summary>
        /// Connection context contains connection metadata following CloudEvents.
        /// </summary>
        [JsonPropertyName(ConnectionContextProperty)]
        public WebPubSubConnectionContext ConnectionContext { get; internal set; }

        /// <summary>
        /// Create instance of <see cref="WebPubSubEventRequest"/>
        /// </summary>
        /// <param name="context">Parameter connection context.</param>
        protected WebPubSubEventRequest(WebPubSubConnectionContext context)
        {
            ConnectionContext = context;
        }
    }
}
