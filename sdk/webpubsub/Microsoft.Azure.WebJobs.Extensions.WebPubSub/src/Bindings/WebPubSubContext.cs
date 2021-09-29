// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net.Http;
using System.Text.Json.Serialization;
using Microsoft.Azure.WebPubSub.AspNetCore;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    public class WebPubSubContext
    {
        /// <summary>
        /// Request body.
        /// </summary>
        [JsonPropertyName("request")]
        public WebPubSubRequest Request { get; }

        /// <summary>
        /// System build response for easy return, works for AbuseProtection and Errors.
        /// </summary>
        [JsonConverter(typeof(HttpResponseMessageJsonConverter))]
        [JsonPropertyName("response")]
        public HttpResponseMessage Response { get; }

        public string ErrorMessage { get; }

        public WebPubSubErrorCode ErrorCode { get; }

        public bool IsValidationRequest => Request is ValidationRequest;

        // Invalid Request
        internal WebPubSubContext(string errorMessage, WebPubSubErrorCode errorCode)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        internal WebPubSubContext(WebPubSubRequest request, HttpResponseMessage response = null)
        {
            Request = request;
            Response = response ?? new HttpResponseMessage();
        }
    }
}
