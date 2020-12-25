// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
    /// Client used to interact with the Event Grid service.
    /// </summary>
    public class EventGridPublisherClient
    {
        private readonly EventGridRestClient _serviceRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private string _hostName => _endpoint.Host;
        private readonly Uri _endpoint;
        private readonly AzureKeyCredential _key;
        private readonly string _apiVersion;
        private readonly ObjectSerializer _dataSerializer;

        private const string TraceParentHeaderName = "traceparent";
        private const string TraceStateHeaderName = "tracestate";

        /// <summary>Initalizes an instance of EventGridClient.</summary>
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
            _apiVersion = options.Version.GetVersionString();
            _dataSerializer = options.Serializer ?? new JsonObjectSerializer();
            _endpoint = endpoint;
            _key = credential;
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.SasKeyName));
            _serviceRestClient = new EventGridRestClient(new ClientDiagnostics(options), pipeline, options.Version.GetVersionString());
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
            _dataSerializer = options.Serializer ?? new JsonObjectSerializer();
            _endpoint = endpoint;
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new EventGridSharedAccessSignatureCredentialPolicy(credential));
            _serviceRestClient = new EventGridRestClient(new ClientDiagnostics(options), pipeline, options.Version.GetVersionString());
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary> Publishes a batch of EventGridEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SendEventsAsync(IEnumerable<EventGridEvent> events, CancellationToken cancellationToken = default)
            => await SendEventsInternal(events, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a batch of EventGridEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SendEvents(IEnumerable<EventGridEvent> events, CancellationToken cancellationToken = default)
            => SendEventsInternal(events, false /*async*/, cancellationToken).EnsureCompleted();

        /// <summary> Publishes a batch of EventGridEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="async">Whether to invoke the operation asynchronously.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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

                    JsonDocument data;
                    if (egEvent.Data is BinaryData binaryEventData)
                    {
                        try
                        {
                            data = JsonDocument.Parse(binaryEventData);
                        }
                        catch (JsonException)
                        {
                            data = SerializeObjectToJsonDocument(binaryEventData.ToString(), typeof(string), cancellationToken);
                        }
                    }
                    else
                    {
                        data = SerializeObjectToJsonDocument(egEvent.Data, egEvent.Data.GetType(), cancellationToken);
                    }

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

        /// <summary> Publishes a batch of CloudEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SendEventsAsync(IEnumerable<CloudEvent> events, CancellationToken cancellationToken = default)
            => await SendCloudEventsInternal(events, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a batch of CloudEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SendEvents(IEnumerable<CloudEvent> events, CancellationToken cancellationToken = default)
            => SendCloudEventsInternal(events, false /*async*/, cancellationToken).EnsureCompleted();

        /// <summary> Publishes a batch of CloudEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
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
                        JsonDocument data = SerializeObjectToJsonDocument(cloudEvent.Data, cloudEvent.Data.GetType(), cancellationToken);
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

        /// <summary> Publishes a batch of custom events to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SendEventsAsync(IEnumerable<object> events, CancellationToken cancellationToken = default)
            => await PublishCustomEventsInternal(events, true /*async*/, cancellationToken).ConfigureAwait(false);

        /// <summary> Publishes a batch of custom events to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// Creates a SAS token for use with Event Grid service.
        /// </summary>
        /// <param name="endpoint">The path for the event grid topic to which you're sending events. For example, "https://TOPIC-NAME.REGION-NAME.eventgrid.azure.net/eventGrid/api/events".</param>
        /// <param name="expirationUtc">Time at which the SAS token becomes invalid for authentication.</param>
        /// <param name="key">Key credential used to generate the token.</param>
        /// <param name="apiVersion">Service version to use when handling requests made with the SAS token.</param>
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
