// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly string _hostName;

        /// <summary>Initalizes an instance of EventGridClient</summary>
        protected EventGridClient()
        {
        }

        /// <summary>Initalizes an instance of EventGridClient</summary>
        /// <param name="endpoint">topic endpoint</param>
        /// <param name="credential">used to connect to Azure</param>
        public EventGridClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new EventGridClientOptions())
        {
        }

        /// <summary>Initalizes an instance of EventGridClient</summary>
        /// <param name="endpoint">topic endpoint</param>
        /// <param name="credential">used to connect to Azure</param>
        /// <param name="options">configuring options</param>
        public EventGridClient(Uri endpoint, AzureKeyCredential credential, EventGridClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridClientOptions();
            _hostName = endpoint.Host;
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.SasKeyName));
            _serviceRestClient = new ServiceRestClient(new ClientDiagnostics(options), pipeline, options.GetVersionString());
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary> Publishes a batch of EventGridEvents to an Azure Event Grid topic. </summary>
        /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PublishEventsAsync(IEnumerable<EventGridEvent> events, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridClient)}.{nameof(PublishEvents)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.PublishEventsAsync(_hostName, events, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Publishes a batch of EventGridEvents to an Azure Event Grid topic. </summary>
        /// /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PublishEvents(IEnumerable<EventGridEvent> events, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridClient)}.{nameof(PublishEvents)}");
            scope.Start();

            try
            {
                return _serviceRestClient.PublishEvents(_hostName, events, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Publishes a batch of CloudEvents to an Azure Event Grid topic. </summary>
        /// /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PublishCloudEventsAsync(IEnumerable<CloudEvent> events, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridClient)}.{nameof(PublishCloudEvents)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.PublishCloudEventEventsAsync(_hostName, events, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Publishes a batch of CloudEvents to an Azure Event Grid topic. </summary>
        /// /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PublishCloudEvents(IEnumerable<CloudEvent> events, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridClient)}.{nameof(PublishCloudEvents)}");
            scope.Start();

            try
            {
                return _serviceRestClient.PublishCloudEventEvents(_hostName, events, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }


        /// <summary> Publishes a batch of custom events to an Azure Event Grid topic. </summary>
        /// /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PublishCustomEventsAsync(IEnumerable<object> events, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridClient)}.{nameof(PublishCustomEvents)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.PublishCustomEventEventsAsync(_hostName, events, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Publishes a batch of custom events to an Azure Event Grid topic. </summary>
        /// /// <param name="events"> An array of events to be published to Event Grid. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PublishCustomEvents(IEnumerable<object> events, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EventGridClient)}.{nameof(PublishCustomEvents)}");
            scope.Start();

            try
            {
                return _serviceRestClient.PublishCustomEventEvents(_hostName, events, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
