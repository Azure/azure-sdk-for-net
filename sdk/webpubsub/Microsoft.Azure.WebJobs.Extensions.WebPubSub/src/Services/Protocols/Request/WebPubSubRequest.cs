// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Web PubSub service request.
    /// </summary>
    public abstract class WebPubSubRequest
    {
        internal const string ConnectionContextProperty = "connectionContext";
        internal const string NameProperty = "name";

        /// <summary>
        /// Connection context contains connection metadata following CloudEvents.
        /// </summary>
        [JsonPropertyName(ConnectionContextProperty)]
        public ConnectionContext ConnectionContext { get; internal set;}

        /// <summary>
        /// Create instance of <see cref="WebPubSubRequest"/>
        /// </summary>
        /// <param name="context">Parameter connection context.</param>
        public WebPubSubRequest(ConnectionContext context)
        {
            ConnectionContext = context;
        }
    }
}
