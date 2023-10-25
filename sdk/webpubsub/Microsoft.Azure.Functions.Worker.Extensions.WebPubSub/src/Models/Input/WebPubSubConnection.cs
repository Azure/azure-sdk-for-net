// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Contains necessary information for a Web PubSub client to connect to Web PubSub Service.
    /// </summary>
    public sealed class WebPubSubConnection
    {
        /// <summary>
        /// Base Uri of the websocket connection.
        /// </summary>
        [JsonPropertyName("baseUrl")]
        public Uri BaseUri { get; set; }

        /// <summary>
        /// Uri with accessToken of the websocket connection.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Uri { get; set; }

        /// <summary>
        /// Access token of the websocket connection.
        /// </summary>
        public string AccessToken { get; set; }
    }
}
