// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Validation request for abuse protection.
    /// </summary>
    public sealed class ValidationRequest : WebPubSubRequest
    {
        /// <summary>
        /// Flag to indicate whether is a valid request.
        /// </summary>
        [JsonPropertyName("isValid")]
        public bool IsValid { get; }

        internal ValidationRequest(bool isValid)
            :base(null)
        {
            IsValid = isValid;
        }
    }
}
