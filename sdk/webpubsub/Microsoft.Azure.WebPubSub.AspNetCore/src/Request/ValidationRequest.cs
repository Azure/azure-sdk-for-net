// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Validation request for abuse protection.
    /// </summary>
    public sealed class ValidationRequest : ServiceRequest
    {
        /// <summary>
        /// Flag to indicate whether is a valid request.
        /// </summary>
        [JsonPropertyName("valid")]
        public bool Valid { get; }

        /// <summary>
        /// Request hosts from headers.
        /// </summary>
        [JsonPropertyName("requestHosts")]
        internal List<string> RequestHosts { get; }

        internal ValidationRequest(bool valid, List<string> requestHosts)
            :base(null)
        {
            Valid = valid;
            RequestHosts = requestHosts;
        }
    }
}
