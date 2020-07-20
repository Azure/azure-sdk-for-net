// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class EventGridClient
    {
        private readonly ServiceRestClient _serviceRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private string _hostName => _endpoint.Host;
        private readonly Uri _endpoint;
        private readonly AzureKeyCredential _key;
        private string _apiVersion;
        private ObjectSerializer _serializer;

        /// <summary>Initalizes an instance of EventGridClient</summary>
        protected EventGridClient()
        {
        }

        /// <summary>Initalizes an instance of EventGridClient</summary>
        /// <param name="endpoint">Topic endpoint</param>
        /// <param name="credential">Credential used to connect to Azure</param>
        public EventGridClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new EventGridClientOptions())
        {
        }

        /// <summary>Initalizes an instance of EventGridClient</summary>
        /// <param name="endpoint">Topic endpoint</param>
        /// <param name="credential">Credential used to connect to Azure</param>
        public EventGridClient(Uri endpoint, SharedAccessSignatureCredential credential)
            : this(endpoint, credential, new EventGridClientOptions())
        {
        }

        /// <summary>Initalizes an instance of the<see cref="EventGridClient"/> class</summary>
        /// <param name="endpoint">Topic endpoint</param>
        /// <param name="credential">Credential used to connect to Azure</param>
        /// <param name="options">Configuring options</param>
        public EventGridClient(Uri endpoint, AzureKeyCredential credential, EventGridClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridClientOptions();
            _serializer = options.Serializer ?? new JsonObjectSerializer();
            _apiVersion = options.GetVersionString();
            _endpoint = endpoint;
            _key = credential;
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.SasKeyName));
            _serviceRestClient = new ServiceRestClient(new ClientDiagnostics(options), pipeline, options.GetVersionString());
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridClient"/> class.
        /// </summary>
        /// <param name="endpoint">Topic endpoint</param>
        /// <param name="credential">Credential used to connect to Azure</param>
        /// <param name="options">Configuring options</param>
        public EventGridClient(Uri endpoint, SharedAccessSignatureCredential credential, EventGridClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridClientOptions();
            _serializer = options.Serializer ?? new JsonObjectSerializer();
            _endpoint = endpoint;
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new SharedAccessSignatureCredentialPolicy(credential));
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridClient)}.{nameof(PublishEvents)}");
            scope.Start();

            try
            {
                List<EventGridEvent> eventsWithSerializedPayloads = new List<EventGridEvent>();
                foreach (EventGridEvent egEvent in events)
                {
                    EventGridEvent newEGEvent = new EventGridEvent(
                            egEvent.Id,
                            egEvent.Subject,
                            new EventGridSerializer(
                                egEvent.Data,
                                _serializer,
                                cancellationToken),
                            egEvent.EventType,
                            egEvent.EventTime,
                            egEvent.DataVersion);
                    newEGEvent.Topic = egEvent.Topic;

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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridClient)}.{nameof(PublishCloudEvents)}");
            scope.Start();

            try
            {
                List<CloudEvent> eventsWithSerializedPayloads = new List<CloudEvent>();
                foreach (CloudEvent cloudEvent in events)
                {
                    // The 'Data' field is optional for the CloudEvent spec
                    if (cloudEvent.Data != null)
                    {
                        eventsWithSerializedPayloads.Add(
                            new CloudEvent(
                                cloudEvent.Id,
                                cloudEvent.Source,
                                cloudEvent.Type,
                                cloudEvent.Specversion)
                            {
                                Data = new EventGridSerializer(
                                    cloudEvent.Data,
                                    _serializer,
                                    cancellationToken),
                                Time = cloudEvent.Time,
                                Datacontenttype = cloudEvent.Datacontenttype,
                                Dataschema = cloudEvent.Dataschema,
                                Subject = cloudEvent.Subject
                            });
                    }
                    else
                    {
                        eventsWithSerializedPayloads.Add(cloudEvent);
                    }
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridClient)}.{nameof(PublishCustomEvents)}");
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
        /// Creates a SAS token for use with Event Grid service
        /// </summary>
        /// <param name="expirationUtc">Time at which the SAS token becomes invalid for authentication</param>
        /// <returns>Returns the generated SAS token string</returns>
        public string BuildSharedAccessSignature(DateTimeOffset expirationUtc)
        {
            const char Resource = 'r';
            const char Expiration = 'e';
            const char Signature = 's';

            if (_key == null)
            {
                throw new NotSupportedException("Can only create a SAS token when using an EventGridClient created using AzureKeyCredential.");
            }

            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(_endpoint);
            uriBuilder.AppendQuery("api-version", _apiVersion, true);
            string encodedResource = HttpUtility.UrlEncode(_endpoint.ToString());
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            var encodedExpirationUtc = HttpUtility.UrlEncode(expirationUtc.ToString(culture));

            string unsignedSas = $"{Resource}={encodedResource}&{Expiration}={encodedExpirationUtc}";
            using (var hmac = new HMACSHA256(Convert.FromBase64String(_key.Key)))
            {
                string signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(unsignedSas)));
                string encodedSignature = HttpUtility.UrlEncode(signature);
                string signedSas = $"{unsignedSas}&{Signature}={encodedSignature}";

                return signedSas;
            }
        }
    }
}
