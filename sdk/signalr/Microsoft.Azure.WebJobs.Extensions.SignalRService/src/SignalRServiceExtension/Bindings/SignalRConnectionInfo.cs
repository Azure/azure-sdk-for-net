// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    public class SignalRConnectionInfo
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}