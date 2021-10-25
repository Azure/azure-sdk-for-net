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
        /// <param name="url"></param>
        public WebPubSubConnection(Uri url)
        {
            Url = url.AbsoluteUri;
            BaseUrl = $"{url.Scheme}://{url.Authority}{url.AbsolutePath}";
            AccessToken = HttpUtility.ParseQueryString(url.Query)["access_token"];
        }

        /// <summary>
        /// Base url of the websocket connection.
        /// </summary>
        public string BaseUrl { get;}

        /// <summary>
        /// Url with accessToken of the websocket connection.
        /// </summary>
        public string Url { get;}

        /// <summary>
        /// Access token of the websocket connection.
        /// </summary>
        public string AccessToken { get;}
    }
}
