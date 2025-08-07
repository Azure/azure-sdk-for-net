// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventGrid.SystemEvents;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using STJ = System.Text.Json;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    internal class HttpRequestProcessor
    {
        private readonly ILogger _logger;

        private const string EventTypeKey = "aeg-event-type";
        private const string ValidationCodeKey = "validationCode";
        private const string DataKey = "data";
        private const string SubscriptionValidationEvent = "SubscriptionValidation";
        private const string NotificationEvent = "Notification";
        private const string UnsubscribeEvent = "Unsubscribe";

        public HttpRequestProcessor(ILogger<HttpRequestProcessor> logger)
        {
            _logger = logger;
        }

        internal async Task<HttpResponseMessage> ProcessAsync(
            HttpRequestMessage req,
            string functionName,
            Func<JArray, string, CancellationToken, Task<HttpResponseMessage>> eventsFunc,
            BindingType bindingType,
            CancellationToken cancellationToken)
        {
            // CloudEvent subscription validation handshake
            if (req.Method == HttpMethod.Options)
            {
                if (bindingType == BindingType.EventGridEvent)
                {
                    return new HttpResponseMessage(HttpStatusCode.Conflict)
                    {
                        Content = new StringContent("CloudEvent schema cannot be used for a function that binds to EventGridEvent.")
                    };
                }
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Headers.Add("Webhook-Allowed-Origin", GetAllowedOriginResponseHeader(req));
                return response;
            }

            string eventTypeHeader = null;
            if (req.Headers.TryGetValues(EventTypeKey, out IEnumerable<string> eventTypeHeaders))
            {
                eventTypeHeader = eventTypeHeaders.First();
            }

            // EventGridEvent Subscription validation handshake
            if (string.Equals(eventTypeHeader, SubscriptionValidationEvent, StringComparison.OrdinalIgnoreCase))
            {
                if (bindingType == BindingType.CloudEvent)
                {
                    return new HttpResponseMessage(HttpStatusCode.Conflict)
                    {
                        Content = new StringContent("EventGridEvent schema cannot be used for a function that binds to CloudEvent.")
                    };
                }
                string validationCode;
                string json = await req.Content.ReadAsStringAsync().ConfigureAwait(false);
                JToken events = JToken.Parse(json);

                switch (events.Type)
                {
                    case JTokenType.Array:
                        validationCode = events[0][DataKey][ValidationCodeKey].ToString();
                        break;
                    case JTokenType.Object:
                    {
                        // The Data is double-encoded in the CloudEvent subscription event
                        var data = JToken.Parse(events[DataKey].ToString());
                        validationCode = data[ValidationCodeKey].ToString();
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException(
                            $"The request content should be parseable into a JSON object or array, but was {events.Type}.");
                }

                SubscriptionValidationResponse validationResponse = new SubscriptionValidationResponse{ ValidationResponse = validationCode };
                var returnMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    // use System.Text.Json to leverage the custom converter so that the casing is correct.
                    Content = new StringContent(STJ.JsonSerializer.Serialize(validationResponse))
                };
                _logger.LogInformation($"perform handshake with eventGrid for function: {functionName}");
                return returnMessage;
            }

            // Regular event processing
            if (string.Equals(eventTypeHeader, NotificationEvent, StringComparison.OrdinalIgnoreCase))
            {
                string requestContent = await req.Content.ReadAsStringAsync().ConfigureAwait(false);
                JToken token;
                using (JsonReader reader = new JsonTextReader(new StringReader(requestContent)) { DateParseHandling = DateParseHandling.None })
                {
                    token = JToken.Load(reader);
                }
                JArray events = token.Type switch
                {
                    JTokenType.Array => (JArray) token,
                    JTokenType.Object => new JArray {token},
                    _ => throw new ArgumentOutOfRangeException(
                        $"The request content should be parseable into a JSON object or array, but was {token.Type}.")
                };

                return await eventsFunc(events, functionName, cancellationToken).ConfigureAwait(false);
            }

            return string.Equals(eventTypeHeader, UnsubscribeEvent, StringComparison.OrdinalIgnoreCase) ?
                // TODO disable function?
                new HttpResponseMessage(HttpStatusCode.Accepted) :
                new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        private static string GetAllowedOriginResponseHeader(HttpRequestMessage req)
        {
            const string publicCloudOrigin = "eventgrid.azure.net";
            const string requestOriginHeader = "WebHook-Request-Origin";

            if (!req.Headers.Contains(requestOriginHeader))
            {
                return publicCloudOrigin;
            }

            string allowedOrigin = req.Headers.GetValues(requestOriginHeader).FirstOrDefault();
            switch (allowedOrigin)
            {
                case publicCloudOrigin:
                case "eventgrid.azure.us":
                case "eventgrid.azure.eaglex.ic.gov":
                case "eventgrid.azure.microsoft.scloud":
                case "eventgrid.azure.cn":
                    return allowedOrigin;
                default:
                    return publicCloudOrigin;
            }
        }
    }
}
