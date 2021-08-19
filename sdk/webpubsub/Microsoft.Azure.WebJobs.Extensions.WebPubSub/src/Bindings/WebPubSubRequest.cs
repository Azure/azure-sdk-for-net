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
        public ServiceRequest Request { get; }

        /// <summary>
        /// System build response for easy return, works for AbuseProtection and Errors.
        /// </summary>
        [JsonConverter(typeof(HttpResponseMessageJsonConverter))]
        public HttpResponseMessage Response { get; }

        internal WebPubSubRequest(ConnectionContext context, ServiceRequest request, HttpStatusCode httpStatus, string message = null)
        {
            ConnectionContext = context;
            Request = request;
            Response = new HttpResponseMessage(httpStatus);
            if (!string.IsNullOrEmpty(message))
            {
                Response.Content = new StringContent(message);
            }
        }

        internal WebPubSubRequest(ConnectionContext context, ServiceRequest request, HttpResponseMessage response = null)
        {
            ConnectionContext = context;
            Request = request;
            Response = response ?? new HttpResponseMessage();
        }
    }
}
