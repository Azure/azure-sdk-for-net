// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net.Http;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonConverter(typeof(WebPubSubContextJsonConverter))]
    public class WebPubSubContext
    {
        /// <summary>
        /// Request body.
        /// </summary>
        [JsonProperty("request")]
        public WebPubSubEventRequest Request { get; }

        /// <summary>
        /// System build response for easy return, works for AbuseProtection and Errors.
        /// </summary>
        [JsonProperty("response"), JsonConverter(typeof(HttpResponseMessageJsonConverter))]
        public HttpResponseMessage Response { get; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; }

        [JsonProperty("isValidationRequest")]
        public bool IsValidationRequest => Request is ValidationRequest;

        // Invalid Request
        internal WebPubSubContext(string errorMessage, WebPubSubErrorCode errorCode)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode.ToString();
            Response = Utilities.BuildErrorResponse(new EventErrorResponse(errorCode, errorMessage));
        }

        internal WebPubSubContext(WebPubSubEventRequest request, HttpResponseMessage response = null)
        {
            Request = request;
            Response = response ?? new HttpResponseMessage();
        }
    }
}
