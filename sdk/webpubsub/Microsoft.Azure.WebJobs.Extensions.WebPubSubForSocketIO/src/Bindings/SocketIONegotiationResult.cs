// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Web;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Connection information for client to create WebSocket connection with service.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SocketIONegotiationResult
    {
        /// <summary>
        /// Create an instance of the connection information.
        /// </summary>
        /// <param name="uri"></param>
        public SocketIONegotiationResult(Uri uri)
        {
            Endpoint = new Uri($"{uri.Scheme}://{uri.Authority}");
            Path = uri.AbsolutePath;
            Token = HttpUtility.ParseQueryString(uri.Query)["access_token"];
        }

        /// <summary>
        /// The endpoint for socket.io clients.
        /// </summary>
        [JsonProperty("endpoint")]
        public Uri Endpoint { get;}

        /// <summary>
        /// The path for socket.io clients.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get;}

        /// <summary>
        /// The access token for socket.io clients.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get;}
    }
}
