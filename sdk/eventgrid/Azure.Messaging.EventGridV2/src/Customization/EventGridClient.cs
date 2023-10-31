// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    /// <summary>
    ///
    /// </summary>
#pragma warning disable AZC0007
    public partial class EventGridClient
#pragma warning restore AZC0007
    {
        /// <summary> Publish Single Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="event"> Single Cloud Event being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="event"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<PublishResult> PublishCloudEvent(string topicName, Azure.Messaging.CloudEvent @event,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(@event, nameof(@event));

            RequestContext context = FromCancellationToken(cancellationToken);

            Response response = PublishCloudEvent(topicName, RequestContent.Create(@event), context);
            return Response.FromValue<PublishResult>(null, response);
        }

        /// <summary> Publish Single Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="event"> Single Cloud Event being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="event"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<PublishResult>> PublishCloudEventAsync(string topicName, Azure.Messaging.CloudEvent @event,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(@event, nameof(@event));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await PublishCloudEventAsync(topicName, RequestContent.Create(@event), context).ConfigureAwait(false);
            return Response.FromValue<PublishResult>(null, response);
        }

        /// <summary> Publish Batch Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="events"> Array of Cloud Events being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="events"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<PublishResult>> PublishCloudEventsAsync(string topicName, IEnumerable<Azure.Messaging.CloudEvent> events,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(events, nameof(events));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await PublishCloudEventsAsync(topicName, RequestContent.Create(events), context).ConfigureAwait(false);
            return Response.FromValue(PublishResult.FromResponse(response), response);
        }

        /// <summary> Publish Batch Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="events"> Array of Cloud Events being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="events"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<PublishResult> PublishCloudEvents(string topicName, IEnumerable<Azure.Messaging.CloudEvent> events,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(events, nameof(events));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = PublishCloudEvents(topicName, RequestContent.Create(events), context);
            return Response.FromValue(PublishResult.FromResponse(response), response);
        }

        /// <summary> Receive Batch of Cloud Events from the Event Subscription. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="eventSubscriptionName"> Event Subscription Name. </param>
        /// <param name="maxEvents"> Max Events count to be received. Minimum value is 1, while maximum value is 100 events. If not specified, the default value is 1. </param>
        /// <param name="maxWaitTime"> Max wait time value for receive operation in Seconds. It is the time in seconds that the server approximately waits for the availability of an event and responds to the request. If an event is available, the broker responds immediately to the client. Minimum value is 10 seconds, while maximum value is 120 seconds. If not specified, the default value is 60 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ReceiveResult>> ReceiveCloudEventsAsync(string topicName, string eventSubscriptionName, int? maxEvents = null, TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ReceiveCloudEventsAsync(topicName, eventSubscriptionName, maxEvents, maxWaitTime, context).ConfigureAwait(false);
            return Response.FromValue(ReceiveResult.FromResponse(response), response);
        }

        /// <summary> Receive Batch of Cloud Events from the Event Subscription. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="eventSubscriptionName"> Event Subscription Name. </param>
        /// <param name="maxEvents"> Max Events count to be received. Minimum value is 1, while maximum value is 100 events. If not specified, the default value is 1. </param>
        /// <param name="maxWaitTime"> Max wait time value for receive operation in Seconds. It is the time in seconds that the server approximately waits for the availability of an event and responds to the request. If an event is available, the broker responds immediately to the client. Minimum value is 10 seconds, while maximum value is 120 seconds. If not specified, the default value is 60 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ReceiveResult> ReceiveCloudEvents(string topicName, string eventSubscriptionName, int? maxEvents = null, TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = ReceiveCloudEvents(topicName, eventSubscriptionName, maxEvents, maxWaitTime, context);
            return Response.FromValue(ReceiveResult.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Receive Batch of Cloud Events from the Event Subscription.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ReceiveCloudEventsAsync(string,string,int?,TimeSpan?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="eventSubscriptionName"> Event Subscription Name. </param>
        /// <param name="maxEvents"> Max Events count to be received. Minimum value is 1, while maximum value is 100 events. If not specified, the default value is 1. </param>
        /// <param name="maxWaitTime"> Max wait time value for receive operation in Seconds. It is the time in seconds that the server approximately waits for the availability of an event and responds to the request. If an event is available, the broker responds immediately to the client. Minimum value is 10 seconds, while maximum value is 120 seconds. If not specified, the default value is 60 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> ReceiveCloudEventsAsync(string topicName, string eventSubscriptionName, int? maxEvents, TimeSpan? maxWaitTime, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));

            using var scope = ClientDiagnostics.CreateScope("EventGridClient.ReceiveCloudEvents");
            scope.Start();
            try
            {
                using HttpMessage message = CreateReceiveCloudEventsRequest(topicName, eventSubscriptionName, maxEvents, maxWaitTime, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Receive Batch of Cloud Events from the Event Subscription.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ReceiveCloudEvents(string,string,int?,TimeSpan?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="eventSubscriptionName"> Event Subscription Name. </param>
        /// <param name="maxEvents"> Max Events count to be received. Minimum value is 1, while maximum value is 100 events. If not specified, the default value is 1. </param>
        /// <param name="maxWaitTime"> Max wait time value for receive operation in Seconds. It is the time in seconds that the server approximately waits for the availability of an event and responds to the request. If an event is available, the broker responds immediately to the client. Minimum value is 10 seconds, while maximum value is 120 seconds. If not specified, the default value is 60 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response ReceiveCloudEvents(string topicName, string eventSubscriptionName, int? maxEvents, TimeSpan? maxWaitTime, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));

            using var scope = ClientDiagnostics.CreateScope("EventGridClient.ReceiveCloudEvents");
            scope.Start();
            try
            {
                using HttpMessage message = CreateReceiveCloudEventsRequest(topicName, eventSubscriptionName, maxEvents, maxWaitTime, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}