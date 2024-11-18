// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Response for errors.
    /// </summary>
    [DataContract]
    public class EventErrorResponse : WebPubSubEventResponse
    {
        [DataMember(Name = "code")]
        internal override WebPubSubStatusCode StatusCode { get; set; }

        /// <summary>
        /// Error code.
        /// </summary>
        [IgnoreDataMember]
        [JsonIgnore]
        public WebPubSubErrorCode Code
        {
            get
            {
                return FromStatusCode(StatusCode);
            }
            set
            {
                StatusCode = ToStatusCode(value);
            }
        }

        /// <summary>
        /// Error messages.
        /// </summary>
        [DataMember(Name = "errorMessage")]
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

        private static WebPubSubErrorCode FromStatusCode(WebPubSubStatusCode statusCode) =>
            statusCode switch
            {
                WebPubSubStatusCode.Unauthorized => WebPubSubErrorCode.Unauthorized,
                WebPubSubStatusCode.UserError => WebPubSubErrorCode.UserError,
                // Turn server error as default in EventErrorResponse.
                _ => WebPubSubErrorCode.ServerError,
            };

        private static WebPubSubStatusCode ToStatusCode(WebPubSubErrorCode statusCode) =>
            statusCode switch
            {
                WebPubSubErrorCode.Unauthorized => WebPubSubStatusCode.Unauthorized,
                WebPubSubErrorCode.UserError => WebPubSubStatusCode.UserError,
                // return server error as default in EventErrorResponse regarding status code.
                _ => WebPubSubStatusCode.ServerError,
            };
    }
}
