// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    public class SignalRConnectionInfo
    {
        [JsonProperty("url")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1056:URI-like properties should not be strings", Justification = "Breaking change.")]
        public string Url { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}