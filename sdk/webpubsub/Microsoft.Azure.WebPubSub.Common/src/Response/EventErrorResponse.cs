// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Response for errors.
    /// </summary>
    public class EventErrorResponse : WebPubSubEventResponse
    {
        /// <summary>
        /// Error code. Required field to deserialize ErrorResponse.
        /// </summary>
        [JsonPropertyName("code"), JsonConverter(typeof(JsonStringEnumConverter))]
        public WebPubSubErrorCode Code { get; set; }

        /// <summary>
        /// Error messages.
        /// </summary>
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Create an instance of <see cref="EventErrorResponse"/>.
        /// </summary>
        /// <param name="code">Error code indicate error type.</param>
        /// <param name="message">Detail error message.</param>
        public EventErrorResponse(WebPubSubErrorCode code, string message = null)
        {
            Code = code;
            ErrorMessage = message;
        }

        /// <summary>
        /// Default constructor for JsonSerialize.
        /// </summary>
        public EventErrorResponse()
        { }
    }
}
