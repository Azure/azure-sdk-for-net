// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Web PubSub service auto generate simple response for input binding.
    /// </summary>
    public sealed class WebPubSubSimpleResponse
    {
        /// <summary>
        /// Response body including error message.
        /// </summary>
        [JsonPropertyName("body")]
        public string Body { get; set; }

        /// <summary>
        /// Response status code
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// Response headers.
        /// </summary>
        [JsonPropertyName("headers")]
        public Dictionary<string, string[]> Headers { get; set; }
    }
}
