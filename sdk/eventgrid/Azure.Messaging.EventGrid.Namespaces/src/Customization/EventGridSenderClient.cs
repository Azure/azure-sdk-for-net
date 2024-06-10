// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.EventGrid.Namespaces
{
    [CodeGenSuppress("EventGridSenderClient", typeof(Uri), typeof(AzureKeyCredential))]
    [CodeGenSuppress("EventGridSenderClient", typeof(Uri), typeof(TokenCredential))]
    [CodeGenSuppress("EventGridSenderClient", typeof(Uri), typeof(AzureKeyCredential), typeof(AzureMessagingEventGridNamespacesClientOptions))]
    [CodeGenSuppress("EventGridSenderClient", typeof(Uri), typeof(TokenCredential), typeof(AzureMessagingEventGridNamespacesClientOptions))]
    public partial class EventGridSenderClient
    {
        /// <summary> Initializes a new instance of EventGridSenderClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridSenderClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new EventGridSenderClientOptions())
        {
        }

        /// <summary> Initializes a new instance of EventGridSenderClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridSenderClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new EventGridSenderClientOptions())
        {
        }

        /// <summary> Initializes a new instance of EventGridSenderClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridSenderClient(Uri endpoint, AzureKeyCredential credential, EventGridSenderClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridSenderClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of EventGridSenderClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridSenderClient(Uri endpoint, TokenCredential credential, EventGridSenderClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new EventGridSenderClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Publish Single Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="cloudEvent"> Single Cloud Event being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="cloudEvent"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response Send(string topicName, CloudEvent cloudEvent, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(cloudEvent, nameof(cloudEvent));

            RequestContext context = FromCancellationToken(cancellationToken);
            return Send(topicName, RequestContent.Create(cloudEvent), context);
        }

        /// <summary> Publish Single Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="cloudEvent"> Single Cloud Event being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="cloudEvent"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response> SendAsync(
            string topicName,
            CloudEvent cloudEvent,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(cloudEvent, nameof(cloudEvent));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await SendAsync(topicName, RequestContent.Create(cloudEvent), context).ConfigureAwait(false);
        }

        /// <summary> Publish Batch Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="cloudEvents"> Array of Cloud Events being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="cloudEvents"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response> SendAsync(string topicName, IEnumerable<CloudEvent> cloudEvents, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(cloudEvents, nameof(cloudEvents));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await SendEventsAsync(topicName, RequestContent.Create(cloudEvents), context).ConfigureAwait(false);
        }

        /// <summary> Publish Batch Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="cloudEvents"> Array of Cloud Events being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="cloudEvents"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response Send(string topicName, IEnumerable<CloudEvent> cloudEvents, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(cloudEvents, nameof(cloudEvents));

            RequestContext context = FromCancellationToken(cancellationToken);
            return SendEvents(topicName, RequestContent.Create(cloudEvents), context);
        }
    }
}
