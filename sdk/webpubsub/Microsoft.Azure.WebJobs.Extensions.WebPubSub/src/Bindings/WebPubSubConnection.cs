// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Web;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Connection information for client to create WebSocket connection with service.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class WebPubSubConnection
    {
        /// <summary>
        /// Create an instance of the connection information.
        /// </summary>
        /// <param name="uri"></param>
        public WebPubSubConnection(Uri uri)
        {
            Uri = uri;

            BaseUri = new Uri($"{uri.Scheme}://{uri.Authority}{uri.AbsolutePath}");
            AccessToken = HttpUtility.ParseQueryString(uri.Query)["access_token"];
        }

        /// <summary>
        /// Base Uri of the websocket connection.
        /// </summary>
        [JsonProperty("baseUrl")]
        public Uri BaseUri { get;}

        /// <summary>
        /// Uri with accessToken of the websocket connection.
        /// </summary>
        [JsonProperty("url")]
        public Uri Uri { get;}

        /// <summary>
        /// Access token of the websocket connection.
        /// </summary>
        public string AccessToken { get;}
    }
}
