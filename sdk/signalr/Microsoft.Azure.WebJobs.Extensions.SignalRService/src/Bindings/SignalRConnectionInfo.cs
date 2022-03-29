// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// A POJO class contains necessary information for a SignalR client to connect to Azure SignalR Service.
    /// </summary>
    public class SignalRConnectionInfo
    {
        /// <summary>
        /// Gets or sets the URL that the SignalR client connects to.
        /// </summary>
        [JsonProperty("url")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1056:URI-like properties should not be strings", Justification = "Breaking change.")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}