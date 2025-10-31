// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.EventGrid.Namespaces
{
    [CodeGenSuppress("EventGridSenderClient", typeof(Uri), typeof(AzureKeyCredential))]
    [CodeGenSuppress("EventGridSenderClient", typeof(Uri), typeof(TokenCredential))]
    [CodeGenSuppress("EventGridSenderClient", typeof(Uri), typeof(AzureKeyCredential), typeof(EventGridReceiverClientOptions))]
    [CodeGenSuppress("EventGridSenderClient", typeof(Uri), typeof(TokenCredential), typeof(EventGridReceiverClientOptions))]
    public partial class EventGridSenderClient
    {
        private readonly string _topicName;
        private readonly bool _isDistributedTracingEnabled;

        /// <summary> Initializes a new instance of EventGridSenderClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName">The topic to send events to.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public EventGridSenderClient(Uri endpoint, string topicName, AzureKeyCredential credential) : this(endpoint, topicName, credential, new EventGridSenderClientOptions())
        {
        }

        /// <summary> Initializes a new instance of EventGridSenderClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName">The topic to send events to.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public EventGridSenderClient(Uri endpoint, string topicName, TokenCredential credential) : this(endpoint, topicName, credential, new EventGridSenderClientOptions())
        {
        }

        /// <summary> Initializes a new instance of EventGridSenderClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName">The topic to send events to.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// ///
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public EventGridSenderClient(Uri endpoint,
            string topicName,
            AzureKeyCredential credential,
            EventGridSenderClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            options ??= new EventGridSenderClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
            _topicName = topicName;
            _isDistributedTracingEnabled = options.Diagnostics.IsDistributedTracingEnabled;
        }

        /// <summary> Initializes a new instance of EventGridSenderClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName">The topic to send events to.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// ///
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public EventGridSenderClient(Uri endpoint,
            string topicName,
            TokenCredential credential,
            EventGridSenderClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            options ??= new EventGridSenderClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
            _topicName = topicName;
            _isDistributedTracingEnabled = options.Diagnostics.IsDistributedTracingEnabled;
        }

        /// <summary> Publish Single Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="cloudEvent"> Single Cloud Event being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cloudEvent"/> is null. </exception>
        public virtual Response Send(CloudEvent cloudEvent, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(cloudEvent, nameof(cloudEvent));

            RequestContext context = FromCancellationToken(cancellationToken);
            return Send(_topicName, new CloudEventRequestContent(cloudEvent, _isDistributedTracingEnabled), context);
        }

        /// <summary> Publish Single Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="cloudEvent"> Single Cloud Event being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cloudEvent"/> is null. </exception>
        public virtual async Task<Response> SendAsync(
            CloudEvent cloudEvent,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(cloudEvent, nameof(cloudEvent));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await SendAsync(_topicName, new CloudEventRequestContent(cloudEvent, _isDistributedTracingEnabled), context).ConfigureAwait(false);
        }

        /// <summary> Publish Batch Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="cloudEvents"> Array of Cloud Events being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cloudEvents"/> is null. </exception>
        public virtual async Task<Response> SendAsync(IEnumerable<CloudEvent> cloudEvents, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(cloudEvents, nameof(cloudEvents));

            RequestContext context = FromCancellationToken(cancellationToken);

            // Create the scope here so that we can match the method name.
            using var scope = ClientDiagnostics.CreateScope("EventGridSenderClient.Send");
            scope.Start();
            try
            {
                return await SendEventsAsync(_topicName, new CloudEventsRequestContent(cloudEvents, _isDistributedTracingEnabled), context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Publish Batch Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="cloudEvents"> Array of Cloud Events being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cloudEvents"/> is null. </exception>
        public virtual Response Send(IEnumerable<CloudEvent> cloudEvents, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(cloudEvents, nameof(cloudEvents));

            RequestContext context = FromCancellationToken(cancellationToken);

            // Create the scope here so that we can match the method name.
            using var scope = ClientDiagnostics.CreateScope("EventGridSenderClient.Send");
            scope.Start();
            try
            {
                return SendEvents(_topicName, new CloudEventsRequestContent(cloudEvents, _isDistributedTracingEnabled), context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Publish a single Cloud Event to a namespace topic.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SendAsync(string,CloudEventInternal,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> SendEventAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            // Create the scope here so that we can match the method name.
            using var scope = ClientDiagnostics.CreateScope("EventGridSenderClient.SendEvent");
            scope.Start();
            try
            {
                return await SendAsync(_topicName, content, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Publish a single Cloud Event to a namespace topic.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Send(string,CloudEventInternal,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response SendEvent(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            // Create the scope here so that we can match the method name.
            using var scope = ClientDiagnostics.CreateScope("EventGridSenderClient.SendEvent");
            scope.Start();
            try
            {
                return Send(_topicName, content, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Publish a batch of Cloud Events to a namespace topic.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SendEventsAsync(string,IEnumerable{CloudEventInternal},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> SendEventsAsync(RequestContent content, RequestContext context = null)
        {
            return await SendEventsAsync(_topicName, content, context).ConfigureAwait(false);
        }

        /// <summary>
        /// [Protocol Method] Publish a batch of Cloud Events to a namespace topic.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SendEvents(string,IEnumerable{CloudEventInternal},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response SendEvents(RequestContent content, RequestContext context = null)
        {
            return SendEvents(_topicName, content, context);
        }

        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }
    }
}
