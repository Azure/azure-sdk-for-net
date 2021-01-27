// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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
        private string _hostName => _endpoint.Host;
        private readonly Uri _endpoint;
        private readonly AzureKeyCredential _key;
        private readonly HttpPipeline _pipeline;
        private readonly string _apiVersion;
        private readonly ObjectSerializer _dataSerializer;

        private const string TraceParentHeaderName = "traceparent";
        private const string TraceStateHeaderName = "tracestate";

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
        /// <param name="credential">The Shared Access Signature credential used to authenticate with the service.This signature
        /// can be constructed using <see cref="BuildSharedAccessSignature"/>.</param>
        public EventGridPublisherClient(Uri endpoint, AzureSasCredential credential)
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
            _dataSerializer = options.Serializer ?? new JsonObjectSerializer();
            _endpoint = endpoint;
            _key = credential;
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.SasKeyName));
            _serviceRestClient = new EventGridRestClient(new ClientDiagnostics(options), _pipeline, options.Version.GetVersionString());
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
                Request request = message.Request;
                request.Method = RequestMethod.Post;
                var uri = new RawRequestUriBuilder();
                uri.AppendRaw("https://", false);
                uri.AppendRaw(_hostName, false);
                uri.AppendPath("/api/events", false);
                uri.AppendQuery("api-version", _apiVersion, true);
                request.Uri = uri;
                request.Headers.Add("Content-Type", "application/cloudevents-batch+json; charset=utf-8");
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

        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridPublisherClient"/> class.
        /// </summary>
        /// <param name="endpoint">The topic endpoint. For example, "https://TOPIC-NAME.REGION-NAME-1.eventgrid.azure.net/api/events".</param>
        /// <param name="credential">The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using <see cref="BuildSharedAccessSignature"/>.</param>
        /// <param name="options">The set of options to use for configuring the client.</param>
        public EventGridPublisherClient(Uri endpoint, AzureSasCredential credential, EventGridPublisherClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridPublisherClientOptions();
            _dataSerializer = options.Serializer ?? new JsonObjectSerializer();
            _endpoint = endpoint;
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new EventGridSharedAccessSignatureCredentialPolicy(credential));
            _serviceRestClient = new EventGridRestClient(new ClientDiagnostics(options), pipeline, options.Version.GetVersionString());
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary> Publishes a set of EventGridEvents to an Event Grid topic. </summary>
        /// <param name="events"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual async Task<Response> SendEventsAsync(IEnumerable<EventGridEvent> events, CancellationToken cancellationToken = default)
            => await SendEventsInternal(events, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of EventGridEvents to an Event Grid topic. </summary>
        /// <param name="events"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual Response SendEvents(IEnumerable<EventGridEvent> events, CancellationToken cancellationToken = default)
            => SendEventsInternal(events, false /*async*/, cancellationToken).EnsureCompleted();

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

                    JsonDocument data = SerializeObjectToJsonDocument(egEvent.Data, egEvent.DataSerializationType, cancellationToken);

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

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="events"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual async Task<Response> SendEventsAsync(IEnumerable<CloudEvent> events, CancellationToken cancellationToken = default)
            => await SendCloudEventsInternal(events, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of CloudEvents to an Event Grid topic. </summary>
        /// <param name="events"> The set of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual Response SendEvents(IEnumerable<CloudEvent> events, CancellationToken cancellationToken = default)
            => SendCloudEventsInternal(events, false /*async*/, cancellationToken).EnsureCompleted();

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

                string activityId = null;
                string traceState = null;
                Activity currentActivity = Activity.Current;
                if (currentActivity != null && currentActivity.IsW3CFormat())
                {
                    activityId = currentActivity.Id;
                    currentActivity.TryGetTraceState(out traceState);
                }

                List<CloudEventInternal> eventsWithSerializedPayloads = new List<CloudEventInternal>();
                foreach (CloudEvent cloudEvent in events)
                {
                    // Individual events cannot be null
                    Argument.AssertNotNull(cloudEvent, nameof(cloudEvent));

                    CloudEventInternal newCloudEvent = new CloudEventInternal(
                        cloudEvent.Id,
                        cloudEvent.Source,
                        cloudEvent.Type,
                        "1.0")
                    {
                        Time = cloudEvent.Time,
                        DataBase64 = cloudEvent.DataBase64,
                        Datacontenttype = cloudEvent.DataContentType,
                        Dataschema = cloudEvent.DataSchema,
                        Subject = cloudEvent.Subject
                    };

                    foreach (KeyValuePair<string, object> kvp in cloudEvent.ExtensionAttributes)
                    {
                        newCloudEvent.Add(kvp.Key, new CustomModelSerializer(kvp.Value, _dataSerializer, cancellationToken));
                    }

                    if (activityId != null &&
                        !cloudEvent.ExtensionAttributes.ContainsKey(TraceParentHeaderName) &&
                        !cloudEvent.ExtensionAttributes.ContainsKey(TraceStateHeaderName))
                    {
                        newCloudEvent.Add(TraceParentHeaderName, activityId);
                        if (traceState != null)
                        {
                            newCloudEvent.Add(TraceStateHeaderName, traceState);
                        }
                    }

                    // The 'Data' property is optional for CloudEvents
                    // Additionally, if the type of data is binary, 'Data' will not be populated (data will be stored in 'DataBase64' instead)
                    if (cloudEvent.Data != null)
                    {
                        JsonDocument data = SerializeObjectToJsonDocument(cloudEvent.Data, cloudEvent.DataSerializationType, cancellationToken);
                        newCloudEvent.Data = data.RootElement;
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

        /// <summary> Publishes a set of custom events to an Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual async Task<Response> SendEventsAsync(IEnumerable<object> events, CancellationToken cancellationToken = default)
            => await PublishCustomEventsInternal(events, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a set of custom events to an Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> An optional cancellation token instance to signal the request to cancel the operation.</param>
        public virtual Response SendEvents(IEnumerable<object> events, CancellationToken cancellationToken = default)
            => PublishCustomEventsInternal(events, false /*async*/, cancellationToken).EnsureCompleted();

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
                            _dataSerializer,
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
        /// Creates a SAS token for use with the Event Grid service.
        /// </summary>
        /// <param name="endpoint">The path for the event grid topic to which you're sending events. For example, "https://TOPIC-NAME.REGION-NAME.eventgrid.azure.net/eventGrid/api/events".</param>
        /// <param name="expirationUtc">Time at which the SAS token becomes invalid for authentication.</param>
        /// <param name="key">The key credential used to generate the token.</param>
        /// <param name="apiVersion">The service version to use when handling requests made with the SAS token.</param>
        /// <returns>The generated SAS token string.</returns>
        public static string BuildSharedAccessSignature(Uri endpoint, DateTimeOffset expirationUtc, AzureKeyCredential key, EventGridPublisherClientOptions.ServiceVersion apiVersion = EventGridPublisherClientOptions.LatestVersion)
        {
            const char Resource = 'r';
            const char Expiration = 'e';
            const char Signature = 's';

            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(endpoint);
            uriBuilder.AppendQuery("api-version", apiVersion.GetVersionString(), true);
            string encodedResource = HttpUtility.UrlEncode(uriBuilder.ToString());
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

        private JsonDocument SerializeObjectToJsonDocument(object data, Type type, CancellationToken cancellationToken)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                _dataSerializer.Serialize(stream, data, type, cancellationToken);
                stream.Position = 0;
                return JsonDocument.Parse(stream);
            }
        }
    }
}
