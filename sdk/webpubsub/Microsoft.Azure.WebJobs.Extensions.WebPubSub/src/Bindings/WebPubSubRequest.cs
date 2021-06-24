// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net;
using System.Net.Http;
using Azure.Messaging.WebPubSub;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class WebPubSubRequest
    {
        /// <summary>
        /// Common request information from headers.
        /// </summary>
        public ConnectionContext ConnectionContext { get; }

        /// <summary>
        /// Request body.
        /// </summary>
        public ServiceRequest Request { get; internal set; }

        /// <summary>
        /// Flag to indicate whether it's an <see href="https://github.com/cloudevents/spec/blob/v1.0/http-webhook.md#4-abuse-protection">Abuse Protection</see> request.
        /// </summary>
        public bool IsAbuseRequest { get; internal set; }

        /// <summary>
        /// Flag to reflect pre-check status of the upstream requests.
        /// </summary>
        public WebPubSubRequestStatus RequestStatus { get; }

        /// <summary>
        /// System build response for easy return, works for AbuseProtection and Errors.
        /// </summary>
        [JsonConverter(typeof(HttpResponseMessageJsonConverter))]
        public HttpResponseMessage Response { get; }

        internal WebPubSubRequest(ConnectionContext context, WebPubSubRequestStatus status, HttpStatusCode httpStatus, string message = null)
        {
            ConnectionContext = context;
            RequestStatus = status;
            Response = new HttpResponseMessage(httpStatus);
            if (!string.IsNullOrEmpty(message))
            {
                Response.Content = new StringContent(message);
            }
        }

        internal WebPubSubRequest(ConnectionContext context, WebPubSubRequestStatus status, HttpResponseMessage response = null)
        {
            ConnectionContext = context;
            RequestStatus = status;
            Response = response ?? new HttpResponseMessage();
        }
    }
}
