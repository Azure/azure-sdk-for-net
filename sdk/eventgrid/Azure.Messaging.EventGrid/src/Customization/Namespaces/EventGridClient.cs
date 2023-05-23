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
    public partial class EventGridClient
    {
        /// <summary> Publish Single Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="event"> Single Cloud Event being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="event"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<PublishResult> PublishCloudEvent(string topicName, CloudEvent @event,
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
        public virtual async Task<Response<PublishResult>> PublishCloudEventAsync(string topicName, CloudEvent @event,
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
        public virtual async Task<Response<PublishResult>> PublishCloudEventsAsync(string topicName, IEnumerable<CloudEvent> events,
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
        public virtual Response<PublishResult> PublishCloudEvents(string topicName, IEnumerable<CloudEvent> events,
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
        public virtual Response<ReceiveResult> ReceiveCloudEvents(string topicName, string eventSubscriptionName, int? maxEvents = null,
            TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));

            using var scope = ClientDiagnostics.CreateScope("EventGridClient.ReceiveCloudEvents");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                int? maxWait = maxWaitTime.HasValue ? Convert.ToInt32(maxWaitTime.Value.TotalSeconds) : null;
                Response response = ReceiveCloudEvents(topicName, eventSubscriptionName, maxEvents, maxWait, context);
                return Response.FromValue(ReceiveResult.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Receive Batch of Cloud Events from the Event Subscription. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="eventSubscriptionName"> Event Subscription Name. </param>
        /// <param name="maxEvents"> Max Events count to be received. Minimum value is 1, while maximum value is 100 events. If not specified, the default value is 1. </param>
        /// <param name="maxWaitTime"> Max wait time value for receive operation in Seconds. It is the time in seconds that the server approximately waits for the availability of an event and responds to the request. If an event is available, the broker responds immediately to the client. Minimum value is 10 seconds, while maximum value is 120 seconds. If not specified, the default value is 60 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ReceiveResult>> ReceiveCloudEventsAsync(string topicName, string eventSubscriptionName,
            int? maxEvents = null, TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));

            using var scope = ClientDiagnostics.CreateScope("EventGridClient.ReceiveCloudEvents");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                int? maxWait = maxWaitTime.HasValue ? Convert.ToInt32(maxWaitTime.Value.TotalSeconds) : null;

                Response response = await ReceiveCloudEventsAsync(topicName, eventSubscriptionName, maxEvents, maxWait, context)
                    .ConfigureAwait(false);
                return Response.FromValue(ReceiveResult.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Acknowledge batch of Cloud Events. The server responds with an HTTP 200 status code if at least one event is successfully acknowledged. The response body will include the set of successfully acknowledged lockTokens, along with other failed lockTokens with their corresponding error information. Successfully acknowledged events will no longer be available to any consumer. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="eventSubscriptionName"> Event Subscription Name. </param>
        /// <param name="lockTokens"> AcknowledgeOptions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/>, <paramref name="eventSubscriptionName"/> or <paramref name="lockTokens"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<AcknowledgeResult>> AcknowledgeCloudEventsAsync(string topicName, string eventSubscriptionName,
            IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));
            Argument.AssertNotNull(lockTokens, nameof(lockTokens));

            RequestContext context = FromCancellationToken(cancellationToken);
            var ackOptions = new AcknowledgeOptions(lockTokens);
            Response response = await AcknowledgeCloudEventsAsync(topicName, eventSubscriptionName, ackOptions.ToRequestContent(), context)
                .ConfigureAwait(false);
            return Response.FromValue(AcknowledgeResult.FromResponse(response), response);
        }

        /// <summary> Acknowledge batch of Cloud Events. The server responds with an HTTP 200 status code if at least one event is successfully acknowledged. The response body will include the set of successfully acknowledged lockTokens, along with other failed lockTokens with their corresponding error information. Successfully acknowledged events will no longer be available to any consumer. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="eventSubscriptionName"> Event Subscription Name. </param>
        /// <param name="lockTokens"> AcknowledgeOptions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/>, <paramref name="eventSubscriptionName"/> or <paramref name="lockTokens"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<AcknowledgeResult> AcknowledgeCloudEvents(string topicName, string eventSubscriptionName,
            IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));
            Argument.AssertNotNull(lockTokens, nameof(lockTokens));

            RequestContext context = FromCancellationToken(cancellationToken);
            var ackOptions = new AcknowledgeOptions(lockTokens);
            Response response = AcknowledgeCloudEvents(topicName, eventSubscriptionName, ackOptions.ToRequestContent(), context);
            return Response.FromValue(AcknowledgeResult.FromResponse(response), response);
        }

        /// <summary> Release batch of Cloud Events. The server responds with an HTTP 200 status code if at least one event is successfully released. The response body will include the set of successfully released lockTokens, along with other failed lockTokens with their corresponding error information. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="eventSubscriptionName"> Event Subscription Name. </param>
        /// <param name="lockTokens"> ReleaseOptions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/>, <paramref name="eventSubscriptionName"/> or <paramref name="lockTokens"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ReleaseResult>> ReleaseCloudEventsAsync(string topicName, string eventSubscriptionName, IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));
            Argument.AssertNotNull(lockTokens, nameof(lockTokens));

            RequestContext context = FromCancellationToken(cancellationToken);
            var releaseOptions = new ReleaseOptions(lockTokens);
            Response response = await ReleaseCloudEventsAsync(topicName, eventSubscriptionName, releaseOptions.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(ReleaseResult.FromResponse(response), response);
        }

        /// <summary> Release batch of Cloud Events. The server responds with an HTTP 200 status code if at least one event is successfully released. The response body will include the set of successfully released lockTokens, along with other failed lockTokens with their corresponding error information. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="eventSubscriptionName"> Event Subscription Name. </param>
        /// <param name="lockTokens"> ReleaseOptions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/>, <paramref name="eventSubscriptionName"/> or <paramref name="lockTokens"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ReleaseResult> ReleaseCloudEvents(string topicName, string eventSubscriptionName, IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));
            Argument.AssertNotNull(lockTokens, nameof(lockTokens));

            RequestContext context = FromCancellationToken(cancellationToken);
            var releaseOptions = new ReleaseOptions(lockTokens);
            Response response = ReleaseCloudEvents(topicName, eventSubscriptionName, releaseOptions.ToRequestContent(), context);
            return Response.FromValue(ReleaseResult.FromResponse(response), response);
        }

        /// <summary> Reject batch of Cloud Events. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="eventSubscriptionName"> Event Subscription Name. </param>
        /// <param name="lockTokens"> RejectOptions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/>, <paramref name="eventSubscriptionName"/> or <paramref name="lockTokens"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<RejectResult>> RejectCloudEventsAsync(string topicName, string eventSubscriptionName, IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));
            Argument.AssertNotNull(lockTokens, nameof(lockTokens));

            RequestContext context = FromCancellationToken(cancellationToken);
            var rejectOptions = new RejectOptions(lockTokens);
            Response response = await RejectCloudEventsAsync(topicName, eventSubscriptionName, rejectOptions.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(RejectResult.FromResponse(response), response);
        }

        /// <summary> Reject batch of Cloud Events. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="eventSubscriptionName"> Event Subscription Name. </param>
        /// <param name="lockTokens"> RejectOptions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/>, <paramref name="eventSubscriptionName"/> or <paramref name="lockTokens"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> or <paramref name="eventSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<RejectResult> RejectCloudEvents(string topicName, string eventSubscriptionName, IEnumerable<string> lockTokens, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNullOrEmpty(eventSubscriptionName, nameof(eventSubscriptionName));
            Argument.AssertNotNull(lockTokens, nameof(lockTokens));

            RequestContext context = FromCancellationToken(cancellationToken);
            var rejectOptions = new RejectOptions(lockTokens);
            Response response = RejectCloudEvents(topicName, eventSubscriptionName, rejectOptions.ToRequestContent(), context);
            return Response.FromValue(RejectResult.FromResponse(response), response);
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