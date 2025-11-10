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
    [CodeGenSuppress("EventGridReceiverClient", typeof(Uri), typeof(AzureKeyCredential))]
    [CodeGenSuppress("EventGridReceiverClient", typeof(Uri), typeof(TokenCredential))]
    [CodeGenSuppress("EventGridReceiverClient", typeof(Uri), typeof(AzureKeyCredential), typeof(EventGridNamespacesClientOptions))]
    [CodeGenSuppress("EventGridReceiverClient", typeof(Uri), typeof(TokenCredential), typeof(EventGridNamespacesClientOptions))]
    public partial class EventGridReceiverClient
    {
        private readonly string _topicName;
        private readonly string _subscriptionName;

        /// <summary> Initializes a new instance of EventGridReceiverClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName"> The topic to receive from.</param>
        /// <param name="subscriptionName"> The subscription to receive from within the topic. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridReceiverClient(Uri endpoint,
            string topicName,
            string subscriptionName,
            AzureKeyCredential credential) : this(endpoint, topicName, subscriptionName, credential, new EventGridReceiverClientOptions())
        {
        }

        /// <summary> Initializes a new instance of EventGridReceiverClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName"> The topic to receive from.</param>
        /// <param name="subscriptionName"> The subscription to receive from within the topic. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridReceiverClient(Uri endpoint,
            string topicName,
            string subscriptionName,
            TokenCredential credential) : this(endpoint, topicName, subscriptionName, credential, new EventGridReceiverClientOptions())
        {
        }

        /// <summary> Initializes a new instance of EventGridReceiverClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName"> The topic to receive from.</param>
        /// <param name="subscriptionName"> The subscription to receive from within the topic. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridReceiverClient(Uri endpoint,
            string topicName,
            string subscriptionName,
            AzureKeyCredential credential,
            EventGridReceiverClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(subscriptionName, nameof(subscriptionName));
            options ??= new EventGridReceiverClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
            _topicName = topicName;
            _subscriptionName = subscriptionName;
        }

        /// <summary> Initializes a new instance of EventGridReceiverClient. </summary>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName"> The topic to receive from.</param>
        /// <param name="subscriptionName"> The subscription to receive from within the topic. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public EventGridReceiverClient(Uri endpoint,
            string topicName,
            string subscriptionName,
            TokenCredential credential,
            EventGridReceiverClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(subscriptionName, nameof(subscriptionName));
            options ??= new EventGridReceiverClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
            _topicName = topicName;
            _subscriptionName = subscriptionName;
        }

        /// <summary> Receive a batch of Cloud Events from a subscription. </summary>
        /// <param name="maxEvents"> Max Events count to be received. Minimum value is 1, while maximum value is 100 events. If not specified, the default value is 1. </param>
        /// <param name="maxWaitTime"> Max wait time value for receive operation in Seconds. It is the time in seconds that the server approximately waits for the availability of an event and responds to the request. If an event is available, the broker responds immediately to the client. Minimum value is 10 seconds, while maximum value is 120 seconds. If not specified, the default value is 60 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ReceiveResult>> ReceiveAsync(int? maxEvents = null, TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default)
        {
            return await ReceiveAsync(_topicName, _subscriptionName, maxEvents, maxWaitTime, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Receive a batch of Cloud Events from a subscription. </summary>
        /// <param name="maxEvents"> Max Events count to be received. Minimum value is 1, while maximum value is 100 events. If not specified, the default value is 1. </param>
        /// <param name="maxWaitTime"> Max wait time value for receive operation in Seconds. It is the time in seconds that the server approximately waits for the availability of an event and responds to the request. If an event is available, the broker responds immediately to the client. Minimum value is 10 seconds, while maximum value is 120 seconds. If not specified, the default value is 60 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ReceiveResult> Receive(int? maxEvents = null, TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default)
        {
            return Receive(_topicName, _subscriptionName, maxEvents, maxWaitTime, cancellationToken);
        }

        /// <summary>
        /// [Protocol Method] Receive a batch of Cloud Events from a subscription.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ReceiveAsync(string,string,int?,TimeSpan?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxEvents"> Max Events count to be received. Minimum value is 1, while maximum value is 100 events. If not specified, the default value is 1. </param>
        /// <param name="maxWaitTime"> Max wait time value for receive operation in Seconds. It is the time in seconds that the server approximately waits for the availability of an event and responds to the request. If an event is available, the broker responds immediately to the client. Minimum value is 10 seconds, while maximum value is 120 seconds. If not specified, the default value is 60 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> ReceiveAsync(int? maxEvents, TimeSpan? maxWaitTime, RequestContext context)
        {
            return await ReceiveAsync(_topicName, _subscriptionName, maxEvents, maxWaitTime, context).ConfigureAwait(false);
        }

        /// <summary>
        /// [Protocol Method] Receive a batch of Cloud Events from a subscription.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Receive(string,string,int?,TimeSpan?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxEvents"> Max Events count to be received. Minimum value is 1, while maximum value is 100 events. If not specified, the default value is 1. </param>
        /// <param name="maxWaitTime"> Max wait time value for receive operation in Seconds. It is the time in seconds that the server approximately waits for the availability of an event and responds to the request. If an event is available, the broker responds immediately to the client. Minimum value is 10 seconds, while maximum value is 120 seconds. If not specified, the default value is 60 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Receive(int? maxEvents, TimeSpan? maxWaitTime, RequestContext context)
        {
            return Receive(_topicName, _subscriptionName, maxEvents, maxWaitTime, context);
        }

        /// <summary> Acknowledge a batch of Cloud Events. The response will include the set of successfully acknowledged lock tokens, along with other failed lock tokens with their corresponding error information. Successfully acknowledged events will no longer be available to be received by any consumer. </summary>
        /// <param name="lockTokens"> Array of lock tokens. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockTokens"/> is null. </exception>
        public virtual async Task<Response<AcknowledgeResult>> AcknowledgeAsync(IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            return await AcknowledgeAsync(_topicName, _subscriptionName, lockTokens, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Acknowledge a batch of Cloud Events. The response will include the set of successfully acknowledged lock tokens, along with other failed lock tokens with their corresponding error information. Successfully acknowledged events will no longer be available to be received by any consumer. </summary>
        /// <param name="lockTokens"> Array of lock tokens. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockTokens"/> is null. </exception>
        public virtual Response<AcknowledgeResult> Acknowledge(IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            return Acknowledge(_topicName, _subscriptionName, lockTokens, cancellationToken);
        }

        /// <summary>
        /// [Protocol Method] Acknowledge a batch of Cloud Events. The response will include the set of successfully acknowledged lock tokens, along with other failed lock tokens with their corresponding error information. Successfully acknowledged events will no longer be available to be received by any consumer.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AcknowledgeAsync(string,string,IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
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
        public virtual async Task<Response> AcknowledgeAsync(RequestContent content, RequestContext context = null)
        {
            return await AcknowledgeAsync(_topicName, _subscriptionName, content, context).ConfigureAwait(false);
        }

        /// <summary>
        /// [Protocol Method] Acknowledge a batch of Cloud Events. The response will include the set of successfully acknowledged lock tokens, along with other failed lock tokens with their corresponding error information. Successfully acknowledged events will no longer be available to be received by any consumer.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Acknowledge(string,string,IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
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
        public virtual Response Acknowledge(RequestContent content, RequestContext context = null)
        {
            return Acknowledge(_topicName, _subscriptionName, content, context);
        }

        /// <summary> Release a batch of Cloud Events. The response will include the set of successfully released lock tokens, along with other failed lock tokens with their corresponding error information. Successfully released events can be received by consumers. </summary>
        /// <param name="lockTokens"> Array of lock tokens. </param>
        /// <param name="delay"> Release cloud events with the specified delay in seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockTokens"/> is null. </exception>
        public virtual async Task<Response<ReleaseResult>> ReleaseAsync(IEnumerable<string> lockTokens, ReleaseDelay? delay = null, CancellationToken cancellationToken = default)
        {
            return await ReleaseAsync(_topicName, _subscriptionName, lockTokens, delay, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Release a batch of Cloud Events. The response will include the set of successfully released lock tokens, along with other failed lock tokens with their corresponding error information. Successfully released events can be received by consumers. </summary>
        /// <param name="lockTokens"> Array of lock tokens. </param>
        /// <param name="delay"> Release cloud events with the specified delay in seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockTokens"/> is null. </exception>
        public virtual Response<ReleaseResult> Release(IEnumerable<string> lockTokens, ReleaseDelay? delay = null, CancellationToken cancellationToken = default)
        {
            return Release(_topicName, _subscriptionName, lockTokens, delay, cancellationToken);
        }

        /// <summary>
        /// [Protocol Method] Release a batch of Cloud Events. The response will include the set of successfully released lock tokens, along with other failed lock tokens with their corresponding error information. Successfully released events can be received by consumers.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ReleaseAsync(string,string,IEnumerable{string},ReleaseDelay?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="releaseDelayInSeconds"> Release cloud events with the specified delay in seconds. Allowed values: "0" | "10" | "60" | "600" | "3600". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> ReleaseAsync(RequestContent content, string releaseDelayInSeconds = null, RequestContext context = null)
        {
            return await ReleaseAsync(_topicName, _subscriptionName, content, releaseDelayInSeconds, context).ConfigureAwait(false);
        }

        /// <summary>
        /// [Protocol Method] Release a batch of Cloud Events. The response will include the set of successfully released lock tokens, along with other failed lock tokens with their corresponding error information. Successfully released events can be received by consumers.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Release(string,string,IEnumerable{string},ReleaseDelay?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="releaseDelayInSeconds"> Release cloud events with the specified delay in seconds. Allowed values: "0" | "10" | "60" | "600" | "3600". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Release(RequestContent content, string releaseDelayInSeconds = null, RequestContext context = null)
        {
            return Release(_topicName, _subscriptionName, content, releaseDelayInSeconds, context);
        }

        /// <summary> Reject a batch of Cloud Events. The response will include the set of successfully rejected lock tokens, along with other failed lock tokens with their corresponding error information. Successfully rejected events will be dead-lettered and can no longer be received by a consumer. </summary>
        /// <param name="lockTokens"> Array of lock tokens. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockTokens"/> is null. </exception>
        public virtual async Task<Response<RejectResult>> RejectAsync(IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            return await RejectAsync(_topicName, _subscriptionName, lockTokens, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Reject a batch of Cloud Events. The response will include the set of successfully rejected lock tokens, along with other failed lock tokens with their corresponding error information. Successfully rejected events will be dead-lettered and can no longer be received by a consumer. </summary>
        /// <param name="lockTokens"> Array of lock tokens. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockTokens"/> is null. </exception>
        public virtual Response<RejectResult> Reject(IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            return Reject(_topicName, _subscriptionName, lockTokens, cancellationToken);
        }

        /// <summary>
        /// [Protocol Method] Reject a batch of Cloud Events. The response will include the set of successfully rejected lock tokens, along with other failed lock tokens with their corresponding error information. Successfully rejected events will be dead-lettered and can no longer be received by a consumer.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RejectAsync(string,string,IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
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
        public virtual async Task<Response> RejectAsync(RequestContent content, RequestContext context = null)
        {
            return await RejectAsync(_topicName, _subscriptionName, content, context).ConfigureAwait(false);
        }

        /// <summary>
        /// [Protocol Method] Reject a batch of Cloud Events. The response will include the set of successfully rejected lock tokens, along with other failed lock tokens with their corresponding error information. Successfully rejected events will be dead-lettered and can no longer be received by a consumer.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Reject(string,string,IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
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
        public virtual Response Reject(RequestContent content, RequestContext context = null)
        {
            return Reject(_topicName, _subscriptionName, content, context);
        }

        /// <summary> Renew locks for a batch of Cloud Events. The response will include the set of successfully renewed lock tokens, along with other failed lock tokens with their corresponding error information. Successfully renewed locks will ensure that the associated event is only available to the consumer that holds the renewed lock. </summary>
        /// <param name="lockTokens"> Array of lock tokens. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockTokens"/> is null. </exception>
        public virtual async Task<Response<RenewLocksResult>> RenewLocksAsync(IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            return await RenewLocksAsync(_topicName, _subscriptionName, lockTokens, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Renew locks for a batch of Cloud Events. The response will include the set of successfully renewed lock tokens, along with other failed lock tokens with their corresponding error information. Successfully renewed locks will ensure that the associated event is only available to the consumer that holds the renewed lock. </summary>
        /// <param name="lockTokens"> Array of lock tokens. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="lockTokens"/> is null. </exception>
        public virtual Response<RenewLocksResult> RenewLocks(IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            return RenewLocks(_topicName, _subscriptionName, lockTokens, cancellationToken);
        }

        /// <summary>
        /// [Protocol Method] Renew locks for a batch of Cloud Events. The response will include the set of successfully renewed lock tokens, along with other failed lock tokens with their corresponding error information. Successfully renewed locks will ensure that the associated event is only available to the consumer that holds the renewed lock.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RenewLocksAsync(string,string,IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
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
        public virtual async Task<Response> RenewLocksAsync(RequestContent content, RequestContext context = null)
        {
            return await RenewLocksAsync(_topicName, _subscriptionName, content, context).ConfigureAwait(false);
        }

        /// <summary>
        /// [Protocol Method] Renew locks for a batch of Cloud Events. The response will include the set of successfully renewed lock tokens, along with other failed lock tokens with their corresponding error information. Successfully renewed locks will ensure that the associated event is only available to the consumer that holds the renewed lock.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RenewLocks(string,string,IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
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
        public virtual Response RenewLocks(RequestContent content, RequestContext context = null)
        {
            return RenewLocks(_topicName, _subscriptionName, content, context);
        }
    }
}
