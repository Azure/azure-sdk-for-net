// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Web PubSub service request context.
    /// </summary>
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

        /// <summary>
        /// Error detail message.
        /// </summary>
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; }

        /// <summary>
        /// Flag to indicate whether the request has error.
        /// </summary>
        [JsonProperty("hasError")]
        public bool HasError { get; }

        /// <summary>
        /// Flag to indicate if it's a validation request.
        /// </summary>
        [JsonProperty("isValidationRequest")]
        public bool IsValidationRequest => Request is ValidationRequest;

        // Invalid Request
        internal WebPubSubContext(string errorMessage, WebPubSubErrorCode errorCode)
        {
            ErrorMessage = errorMessage;
            HasError = true;
            Response = Utilities.BuildErrorResponse(new EventErrorResponse(errorCode, errorMessage));
        }

        internal WebPubSubContext(WebPubSubEventRequest request, HttpResponseMessage response = null)
        {
            Request = request;
            Response = response ?? new HttpResponseMessage();
        }
    }
}
