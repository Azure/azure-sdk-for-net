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

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// The <see cref="EventGridPublisherClient"/> is used to publish events to Event Grid topics.
    /// </summary>
    public class EventGridPublisherClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly RequestUriBuilder _uriBuilder;
        private readonly HttpPipeline _pipeline;

        /// <summary>Initializes a new instance of the <see cref="EventGridPublisherClient"/> class for mocking.</summary>
        protected EventGridPublisherClient()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="EventGridPublisherClient"/> class.</summary>
        /// <param name="endpoint">The topic endpoint. For example, "https://TOPIC-NAME.REGION-NAME-1.eventgrid.azure.net/api/events".</param>
        /// <param name="credential">The key credential used to authenticate with the service.</param>
        public EventGridPublisherClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new EventGridPublisherClientOptions())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="EventGridPublisherClient"/> class.</summary>
        /// <param name="endpoint">The topic endpoint. For example, "https://TOPIC-NAME.REGION-NAME-1.eventgrid.azure.net/api/events".</param>
        /// <param name="credential">The key credential used to authenticate with the service.</param>
        /// <param name="options">The set of options to use for configuring the client.</param>
        public EventGridPublisherClient(Uri endpoint, AzureKeyCredential credential, EventGridPublisherClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridPublisherClientOptions();
            _uriBuilder = new RequestUriBuilder();
            _uriBuilder.Reset(endpoint);
            _uriBuilder.AppendQuery("api-version", options.Version.GetVersionString(), true);
            _pipeline = HttpPipelineBuilder.Build(options, new EventGridKeyCredentialPolicy(credential));
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary>Initializes a new instance of the <see cref="EventGridPublisherClient"/> class.</summary>
        /// <param name="endpoint">The topic endpoint. For example, "https://TOPIC-NAME.REGION-NAME-1.eventgrid.azure.net/api/events".</param>
        /// <param name="credential">The token credential used to authenticate with the service.</param>
        /// <param name="options">The set of options to use for configuring the client.</param>
        public EventGridPublisherClient(Uri endpoint, TokenCredential credential, EventGridPublisherClientOptions options = default)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridPublisherClientOptions();
            _uriBuilder = new RequestUriBuilder();
            _uriBuilder.Reset(endpoint);
            _uriBuilder.AppendQuery("api-version", options.Version.GetVersionString(), true);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://eventgrid.azure.net/.default"));
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
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridPublisherClientOptions();
            _uriBuilder = new RequestUriBuilder();
            _uriBuilder.Reset(endpoint);
            _uriBuilder.AppendQuery("api-version", options.Version.GetVersionString(), true);
            _pipeline = HttpPipelineBuilder.Build(options, new EventGridSharedAccessSignatureCredentialPolicy(credential));
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
                    _ => throw new RequestFailedException(message.Response)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

                using HttpMessage message = _pipeline.CreateMessage();
                Request request = CreateEventRequest(message, "application/json");

                // leverage custom converter for EventGridEvent
                request.Content = RequestContent.Create(JsonSerializer.Serialize(events));

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
                    _ => throw new RequestFailedException(message.Response)
                };
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
            => await SendCloudEventsInternal(cloudEvents, null, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="cloudEvents"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual Response SendEvents(IEnumerable<CloudEvent> cloudEvents, CancellationToken cancellationToken = default)
            => SendCloudEventsInternal(cloudEvents, null, false /*async*/, cancellationToken).EnsureCompleted();

        /// <summary> Publishes a CloudEvent to an Event Grid topic. </summary>
        /// <param name="cloudEvent"> The set of events to be published to Event Grid.</param>
        /// <param name="channelName">The partner topic channel to publish the event to.</param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        [ForwardsClientCalls]
        public virtual async Task<Response> SendEventAsync(CloudEvent cloudEvent, string channelName, CancellationToken cancellationToken = default)
            => await SendEventsAsync(new CloudEvent[] { cloudEvent }, channelName, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a CloudEvent to an Event Grid topic. </summary>
        /// <param name="cloudEvent"> The set of events to be published to Event Grid.</param>
        /// <param name="channelName">The partner topic channel to publish the event to.</param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        [ForwardsClientCalls]
        public virtual Response SendEvent(CloudEvent cloudEvent, string channelName, CancellationToken cancellationToken = default)
            => SendEvents(new CloudEvent[] { cloudEvent }, channelName, cancellationToken);

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic.</summary>
        /// <param name="cloudEvents"> The set of events to be published to Event Grid.</param>
        /// <param name="channelName">The partner topic channel to publish the event to.</param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual async Task<Response> SendEventsAsync(IEnumerable<CloudEvent> cloudEvents, string channelName, CancellationToken cancellationToken = default)
            => await SendCloudEventsInternal(cloudEvents, channelName, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="cloudEvents"> The set of events to be published to Event Grid. </param>
        /// <param name="channelName">The partner topic channel to publish the event to.</param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual Response SendEvents(IEnumerable<CloudEvent> cloudEvents, string channelName, CancellationToken cancellationToken = default)
            => SendCloudEventsInternal(cloudEvents, channelName, false /*async*/, cancellationToken).EnsureCompleted();

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="events"> The set of events to be published to Event Grid. </param>
        /// <param name="channelName">The partner topic channel to publish the event to.</param>
        /// <param name="async">Whether to invoke the operation asynchronously.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private async Task<Response> SendCloudEventsInternal(IEnumerable<CloudEvent> events, string channelName, bool async, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridPublisherClient)}.{nameof(SendEvents)}");
            scope.Start();

            try
            {
                // List of events cannot be null
                Argument.AssertNotNull(events, nameof(events));
                using HttpMessage message = _pipeline.CreateMessage();
                Request request = CreateEventRequest(message, "application/cloudevents-batch+json; charset=utf-8");

                if (channelName != null)
                {
                    request.Headers.Add("aeg-channel-name", channelName);
                }

                CloudEventsRequestContent content = new CloudEventsRequestContent(events, _clientDiagnostics.IsActivityEnabled);
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
                    _ => throw new RequestFailedException(message.Response)
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
                    _ => throw new RequestFailedException(message.Response)
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
            request.Uri = _uriBuilder;
            request.Headers.Add("Content-Type", contentType);
            return request;
        }
    }
}
