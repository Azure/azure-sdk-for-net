﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventGrid.Models;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// Client used to interact with the Event Grid service
    /// </summary>
    public class EventGridPublisherClient
    {
        private readonly ServiceRestClient _serviceRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private string _hostName => _endpoint.Host;
        private readonly Uri _endpoint;
        private readonly AzureKeyCredential _key;
        private string _apiVersion;
        private ObjectSerializer _serializer;

        /// <summary>Initalizes an instance of EventGridClient</summary>
        protected EventGridPublisherClient()
        {
        }

        /// <summary>Initalizes an instance of EventGridClient.</summary>
        /// <param name="endpoint">Topic endpoint. For example, "https://TOPIC-NAME.REGION-NAME-1.eventgrid.azure.net/api/events".</param>
        /// <param name="credential">Credential used to connect to Azure.</param>
        public EventGridPublisherClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new EventGridPublisherClientOptions())
        {
        }

        /// <summary>Initalizes an instance of EventGridClient.</summary>
        /// <param name="endpoint">Topic endpoint. For example, "https://TOPIC-NAME.REGION-NAME-1.eventgrid.azure.net/api/events".</param>
        /// <param name="credential">Credential used to connect to Azure.</param>
        public EventGridPublisherClient(Uri endpoint, EventGridSharedAccessSignatureCredential credential)
            : this(endpoint, credential, new EventGridPublisherClientOptions())
        {
        }

        /// <summary>Initalizes an instance of the<see cref="EventGridPublisherClient"/> class.</summary>
        /// <param name="endpoint">Topic endpoint. For example, "https://TOPIC-NAME.REGION-NAME-1.eventgrid.azure.net/api/events".</param>
        /// <param name="credential">Credential used to connect to Azure.</param>
        /// <param name="options">Configuring options.</param>
        public EventGridPublisherClient(Uri endpoint, AzureKeyCredential credential, EventGridPublisherClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridPublisherClientOptions();
            _serializer = options.Serializer ?? new JsonObjectSerializer();
            _apiVersion = options.GetVersionString();
            _endpoint = endpoint;
            _key = credential;
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.SasKeyName));
            _serviceRestClient = new ServiceRestClient(new ClientDiagnostics(options), pipeline, options.GetVersionString());
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridPublisherClient"/> class.
        /// </summary>
        /// <param name="endpoint">Topic endpoint. For example, "https://TOPIC-NAME.REGION-NAME-1.eventgrid.azure.net/api/events".</param>
        /// <param name="credential">Credential used to connect to Azure.</param>
        /// <param name="options">Configuring options.</param>
        public EventGridPublisherClient(Uri endpoint, EventGridSharedAccessSignatureCredential credential, EventGridPublisherClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridPublisherClientOptions();
            _serializer = options.Serializer ?? new JsonObjectSerializer();
            _endpoint = endpoint;
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new EventGridSharedAccessSignatureCredentialPolicy(credential));
            _serviceRestClient = new ServiceRestClient(new ClientDiagnostics(options), pipeline, options.GetVersionString());
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary> Publishes a batch of EventGridEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PublishEventsAsync(IEnumerable<EventGridEvent> events, CancellationToken cancellationToken = default)
            => await PublishEventsInternal(events, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a batch of EventGridEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PublishEvents(IEnumerable<EventGridEvent> events, CancellationToken cancellationToken = default)
            => PublishEventsInternal(events, false /*async*/, cancellationToken).EnsureCompleted();

        /// <summary> Publishes a batch of EventGridEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="async">Whether to invoke the operation asynchronously</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private async Task<Response> PublishEventsInternal(IEnumerable<EventGridEvent> events, bool async, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridPublisherClient)}.{nameof(PublishEvents)}");
            scope.Start();

            try
            {
                // List of events cannot be null
                Argument.AssertNotNull(events, nameof(events));

                List<EventGridEventInternal> eventsWithSerializedPayloads = new List<EventGridEventInternal>();
                foreach (EventGridEvent egEvent in events)
                {
                    // Individual events cannot be null
                    Argument.AssertNotNull(egEvent, nameof(egEvent));

                    EventGridEventInternal newEGEvent = new EventGridEventInternal(
                            egEvent.Id,
                            egEvent.Subject,
                            new EventGridSerializer(
                                egEvent.Data,
                                _serializer,
                                cancellationToken),
                            egEvent.EventType,
                            egEvent.EventTime,
                            egEvent.DataVersion)
                    {
                        Topic = egEvent.Topic
                    };

                    eventsWithSerializedPayloads.Add(newEGEvent);
                }
                if (async)
                {
                    // Publish asynchronously if called via an async path
                    return await _serviceRestClient.PublishEventsAsync(
                        _hostName,
                        eventsWithSerializedPayloads,
                        cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    return _serviceRestClient.PublishEvents(
                        _hostName,
                        eventsWithSerializedPayloads,
                        cancellationToken);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Publishes a batch of CloudEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PublishCloudEventsAsync(IEnumerable<CloudEvent> events, CancellationToken cancellationToken = default)
            => await PublishCloudEventsInternal(events, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a batch of CloudEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PublishCloudEvents(IEnumerable<CloudEvent> events, CancellationToken cancellationToken = default)
            => PublishCloudEventsInternal(events, false /*async*/, cancellationToken).EnsureCompleted();

        /// <summary> Publishes a batch of CloudEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="async">Whether to invoke the operation asynchronously</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private async Task<Response> PublishCloudEventsInternal(IEnumerable<CloudEvent> events, bool async, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridPublisherClient)}.{nameof(PublishCloudEvents)}");
            scope.Start();

            try
            {
                // List of events cannot be null
                Argument.AssertNotNull(events, nameof(events));

                List<CloudEventInternal> eventsWithSerializedPayloads = new List<CloudEventInternal>();
                foreach (CloudEvent cloudEvent in events)
                {
                    // Individual events cannot be null
                    Argument.AssertNotNull(cloudEvent, nameof(cloudEvent));

                    CloudEventInternal newCloudEvent = new CloudEventInternal(
                        cloudEvent.Id,
                        cloudEvent.Source,
                        cloudEvent.Type,
                        cloudEvent.SpecVersion)
                    {
                        Time = cloudEvent.Time,
                        Datacontenttype = cloudEvent.DataContentType,
                        Dataschema = cloudEvent.DataSchema,
                        Subject = cloudEvent.Subject
                    };

                    foreach (KeyValuePair<string, object> kvp in cloudEvent.ExtensionAttributes)
                    {
                        newCloudEvent.Add(kvp.Key, new EventGridSerializer(kvp.Value, _serializer, cancellationToken));
                    }

                    // The 'Data' property is optional for CloudEvents
                    if (cloudEvent.Data != null)
                    {
                        if (cloudEvent.Data is IEnumerable<byte> enumerable)
                        {
                            newCloudEvent.DataBase64 = Convert.ToBase64String(enumerable.ToArray());
                        }
                        else if (cloudEvent.Data is ReadOnlyMemory<byte> memory)
                        {
                            newCloudEvent.DataBase64 = Convert.ToBase64String(memory.ToArray());
                        }
                        else
                        {
                            newCloudEvent.Data = new EventGridSerializer(
                                cloudEvent.Data,
                                _serializer,
                                cancellationToken);
                        }
                    }
                    eventsWithSerializedPayloads.Add(newCloudEvent);
                }
                if (async)
                {
                    // Publish asynchronously if called via an async path
                    return await _serviceRestClient.PublishCloudEventEventsAsync(
                        _hostName,
                        eventsWithSerializedPayloads,
                        cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    return _serviceRestClient.PublishCloudEventEvents(
                        _hostName,
                        eventsWithSerializedPayloads,
                        cancellationToken);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Publishes a batch of custom events to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PublishCustomEventsAsync(IEnumerable<object> events, CancellationToken cancellationToken = default)
            => await PublishCustomEventsInternal(events, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a batch of custom events to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PublishCustomEvents(IEnumerable<object> events, CancellationToken cancellationToken = default)
            => PublishCustomEventsInternal(events, false /*async*/, cancellationToken).EnsureCompleted();

        private async Task<Response> PublishCustomEventsInternal(IEnumerable<object> events, bool async, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridPublisherClient)}.{nameof(PublishCustomEvents)}");
            scope.Start();

            try
            {
                List<EventGridSerializer> serializedEvents = new List<EventGridSerializer>();
                foreach (object customEvent in events)
                {
                    serializedEvents.Add(
                        new EventGridSerializer(
                            customEvent,
                            _serializer,
                            cancellationToken));
                }
                if (async)
                {
                    return await _serviceRestClient.PublishCustomEventEventsAsync(
                    _hostName,
                    serializedEvents,
                    cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    return _serviceRestClient.PublishCustomEventEvents(
                    _hostName,
                    serializedEvents,
                    cancellationToken);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a SAS token for use with Event Grid service.
        /// </summary>
        /// <param name="endpoint">The path for the event grid topic to which you're sending events. For example, "https://TOPIC-NAME.REGION-NAME.eventgrid.azure.net/eventGrid/api/events".</param>
        /// <param name="expirationUtc">Time at which the SAS token becomes invalid for authentication.</param>
        /// <param name="key">Key credential used to generate the token.</param>
        /// <param name="apiVersion">Service version to use when handling requests made with the SAS token.</param>
        /// <returns>Returns the generated SAS token string.</returns>
        public static string BuildSharedAccessSignature(Uri endpoint, DateTimeOffset expirationUtc, AzureKeyCredential key, string apiVersion = "2018-01-01")
        {
            const char Resource = 'r';
            const char Expiration = 'e';
            const char Signature = 's';

            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(endpoint);
            uriBuilder.AppendQuery("api-version", apiVersion, true);
            string encodedResource = HttpUtility.UrlEncode(endpoint.ToString());
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            var encodedExpirationUtc = HttpUtility.UrlEncode(expirationUtc.ToString(culture));

            string unsignedSas = $"{Resource}={encodedResource}&{Expiration}={encodedExpirationUtc}";
            using (var hmac = new HMACSHA256(Convert.FromBase64String(key.Key)))
            {
                string signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(unsignedSas)));
                string encodedSignature = HttpUtility.UrlEncode(signature);
                string signedSas = $"{unsignedSas}&{Signature}={encodedSignature}";

                return signedSas;
            }
        }
    }
}
