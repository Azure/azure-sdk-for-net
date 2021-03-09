// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;
using Azure.Messaging.EventGrid.Models;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// The <see cref="EventGridPublisherClient"/> is used to publish events to Event Grid topics.
    /// </summary>
    public class EventGridPublisherClient
    {
        private readonly EventGridRestClient _serviceRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private string _hostName => _endpoint.Authority;
        private readonly Uri _endpoint;
        private readonly AzureKeyCredential _key;
        private readonly HttpPipeline _pipeline;
        private readonly string _apiVersion;

        private static readonly JsonObjectSerializer s_jsonSerializer = new JsonObjectSerializer();

        /// <summary>Initalizes a new instance of the <see cref="EventGridPublisherClient"/> class for mocking.</summary>
        protected EventGridPublisherClient()
        {
        }

        /// <summary>Initalizes a new instance of the <see cref="EventGridPublisherClient"/> class.</summary>
        /// <param name="endpoint">The topic endpoint. For example, "https://TOPIC-NAME.REGION-NAME-1.eventgrid.azure.net/api/events".</param>
        /// <param name="credential">The key credential used to authenticate with the service.</param>
        public EventGridPublisherClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new EventGridPublisherClientOptions())
        {
        }

        /// <summary>Initalizes a new instance of the <see cref="EventGridPublisherClient"/> class.</summary>
        /// <param name="endpoint">The topic endpoint. For example, "https://TOPIC-NAME.REGION-NAME-1.eventgrid.azure.net/api/events".</param>
        /// <param name="credential">The key credential used to authenticate with the service.</param>
        /// <param name="options">The set of options to use for configuring the client.</param>
        public EventGridPublisherClient(Uri endpoint, AzureKeyCredential credential, EventGridPublisherClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridPublisherClientOptions();
            _apiVersion = options.Version.GetVersionString();
            _endpoint = endpoint;
            _key = credential;
            _pipeline = HttpPipelineBuilder.Build(options, new EventGridKeyCredentialPolicy(credential, Constants.SasKeyName));
            _serviceRestClient = new EventGridRestClient(new ClientDiagnostics(options), _pipeline, options.Version.GetVersionString());
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridPublisherClient"/> class.
        /// </summary>
        /// <param name="endpoint">The topic endpoint. For example, "https://TOPIC-NAME.REGION-NAME-1.eventgrid.azure.net/api/events".</param>
        /// <param name="credential">The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="EventGridSasBuilder"/>.</param>
        /// <param name="options">The set of options to use for configuring the client.</param>
        public EventGridPublisherClient(Uri endpoint, AzureSasCredential credential, EventGridPublisherClientOptions options = default)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridPublisherClientOptions();
            _endpoint = endpoint;
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new EventGridSharedAccessSignatureCredentialPolicy(credential));
            _serviceRestClient = new EventGridRestClient(new ClientDiagnostics(options), pipeline, options.Version.GetVersionString());
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary> Publishes a set of encoded cloud events to an Event Grid topic. </summary>
        /// <param name="cloudEvents"> The set of encoded cloud events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> SendEncodedCloudEventsAsync(ReadOnlyMemory<byte> cloudEvents, CancellationToken cancellationToken = default)
            => await SendCloudNativeCloudEventsInternalAsync(cloudEvents, true, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of encoded cloud events to an Event Grid topic. </summary>
        /// <param name="cloudEvents"> The set of encoded cloud events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response SendEncodedCloudEvents(ReadOnlyMemory<byte> cloudEvents, CancellationToken cancellationToken = default)
            => SendCloudNativeCloudEventsInternalAsync(cloudEvents, false, cancellationToken).EnsureCompleted();

        private async Task<Response> SendCloudNativeCloudEventsInternalAsync(ReadOnlyMemory<byte> cloudEvents, bool async, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridPublisherClient)}.{nameof(SendEncodedCloudEvents)}");
            scope.Start();

            try
            {
                using HttpMessage message = _pipeline.CreateMessage();
                Request request = CreateEventRequest(message, "application/cloudevents-batch+json; charset=utf-8");
                RequestContent content = RequestContent.Create(cloudEvents);
                request.Content = content;
                if (async)
                {
                    await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _pipeline.Send(message, cancellationToken);
                }
                return message.Response.Status switch
                {
                    200 => message.Response,
                    _ => async ?
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false) :
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Request CreateEventRequest(HttpMessage message, string contentType)
        {
            Request request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(_hostName, false);
            uri.AppendPath("/api/events", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", contentType);
            return request;
        }

        /// <summary> Publishes a set of EventGridEvents to an Event Grid topic. </summary>
        /// <param name="eventGridEvent"> The event to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        [ForwardsClientCalls]
        public virtual async Task<Response> SendEventAsync(EventGridEvent eventGridEvent, CancellationToken cancellationToken = default)
            => await SendEventsAsync(new EventGridEvent[] { eventGridEvent }, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of EventGridEvents to an Event Grid topic. </summary>
        /// <param name="eventGridEvent"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        [ForwardsClientCalls]
        public virtual Response SendEvent(EventGridEvent eventGridEvent, CancellationToken cancellationToken = default)
            => SendEvents(new EventGridEvent[] { eventGridEvent }, cancellationToken);

        /// <summary> Publishes a set of EventGridEvents to an Event Grid topic. </summary>
        /// <param name="eventGridEvents"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual async Task<Response> SendEventsAsync(IEnumerable<EventGridEvent> eventGridEvents, CancellationToken cancellationToken = default)
            => await SendEventsInternal(eventGridEvents, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of EventGridEvents to an Event Grid topic. </summary>
        /// <param name="eventGridEvents"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual Response SendEvents(IEnumerable<EventGridEvent> eventGridEvents, CancellationToken cancellationToken = default)
            => SendEventsInternal(eventGridEvents, false /*async*/, cancellationToken).EnsureCompleted();

        /// <summary> Publishes a set of EventGridEvents to an Event Grid topic. </summary>
        /// <param name="events"> The set of events to be published to Event Grid. </param>
        /// <param name="async">Whether to invoke the operation asynchronously.</param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        private async Task<Response> SendEventsInternal(IEnumerable<EventGridEvent> events, bool async, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridPublisherClient)}.{nameof(SendEvents)}");
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
                    JsonDocument data = JsonDocument.Parse(egEvent.Data.ToStream());

                    EventGridEventInternal newEGEvent = new EventGridEventInternal(
                        egEvent.Id,
                        egEvent.Subject,
                        data.RootElement,
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

        /// <summary> Publishes a CloudEvent to an Event Grid topic. </summary>
        /// <param name="cloudEvent"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        [ForwardsClientCalls]
        public virtual async Task<Response> SendEventAsync(CloudEvent cloudEvent, CancellationToken cancellationToken = default)
            => await SendEventsAsync(new CloudEvent[] { cloudEvent }, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a CloudEvent to an Event Grid topic. </summary>
        /// <param name="cloudEvent"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        [ForwardsClientCalls]
        public virtual Response SendEvent(CloudEvent cloudEvent, CancellationToken cancellationToken = default)
            => SendEvents(new CloudEvent[] { cloudEvent }, cancellationToken);

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="cloudEvents"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual async Task<Response> SendEventsAsync(IEnumerable<CloudEvent> cloudEvents, CancellationToken cancellationToken = default)
            => await SendCloudEventsInternal(cloudEvents, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="cloudEvents"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual Response SendEvents(IEnumerable<CloudEvent> cloudEvents, CancellationToken cancellationToken = default)
            => SendCloudEventsInternal(cloudEvents, false /*async*/, cancellationToken).EnsureCompleted();

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="events"> The set of events to be published to Event Grid. </param>
        /// <param name="async">Whether to invoke the operation asynchronously.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private async Task<Response> SendCloudEventsInternal(IEnumerable<CloudEvent> events, bool async, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridPublisherClient)}.{nameof(SendEvents)}");
            scope.Start();

            try
            {
                // List of events cannot be null
                Argument.AssertNotNull(events, nameof(events));
                using HttpMessage message = _pipeline.CreateMessage();
                Request request = CreateEventRequest(message, "application/cloudevents-batch+json; charset=utf-8");
                CloudEventRequestContent content = new CloudEventRequestContent(events);
                request.Content = content;

                if (async)
                {
                    await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _pipeline.Send(message, cancellationToken);
                }
                return message.Response.Status switch
                {
                    200 => message.Response,
                    _ => async ?
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false) :
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Publishes a set of custom schema events to an Event Grid topic. </summary>
        /// <param name="customEvent"> A custom schema event to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        [ForwardsClientCalls]
        public virtual async Task<Response> SendEventAsync(BinaryData customEvent, CancellationToken cancellationToken = default)
            => await SendEventsAsync(new BinaryData[] { customEvent }, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of custom schema events to an Event Grid topic.</summary>
        /// <param name="customEvent">A custom schema event to be published to Event Grid.</param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        [ForwardsClientCalls]
        public virtual Response SendEvent(BinaryData customEvent, CancellationToken cancellationToken = default)
            => SendEvents(new BinaryData[] { customEvent }, cancellationToken);

        /// <summary> Publishes a set of custom schema events to an Event Grid topic. </summary>
        /// <param name="customEvents">The set of custom schema events to be published to Event Grid.</param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual async Task<Response> SendEventsAsync(IEnumerable<BinaryData> customEvents, CancellationToken cancellationToken = default)
            => await PublishCustomEventsInternal(customEvents, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of custom schema events to an Event Grid topic. </summary>
        /// <param name="customEvents">The set of custom schema events to be published to Event Grid.</param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual Response SendEvents(IEnumerable<BinaryData> customEvents, CancellationToken cancellationToken = default)
            => PublishCustomEventsInternal(customEvents, false /*async*/, cancellationToken).EnsureCompleted();

        private async Task<Response> PublishCustomEventsInternal(IEnumerable<object> events, bool async, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridPublisherClient)}.{nameof(SendEvents)}");
            scope.Start();

            try
            {
                List<CustomModelSerializer> serializedEvents = new List<CustomModelSerializer>();
                foreach (object customEvent in events)
                {
                    serializedEvents.Add(
                        new CustomModelSerializer(
                            customEvent,
                            s_jsonSerializer,
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

        private async Task<Response> PublishCustomEventsInternal(IEnumerable<BinaryData> events, bool async, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridPublisherClient)}.{nameof(SendEvents)}");
            scope.Start();

            try
            {
                using HttpMessage message = _pipeline.CreateMessage();
                Request request = CreateEventRequest(message, "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartArray();
                foreach (BinaryData evt in events)
                {
                    using (JsonDocument doc = JsonDocument.Parse(evt.ToStream()))
                    {
                        doc.RootElement.WriteTo(content.JsonWriter);
                    }
                }
                content.JsonWriter.WriteEndArray();
                request.Content = content;

                if (async)
                {
                    await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _pipeline.Send(message, cancellationToken);
                }
                return message.Response.Status switch
                {
                    200 => message.Response,
                    _ => async ?
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false) :
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
