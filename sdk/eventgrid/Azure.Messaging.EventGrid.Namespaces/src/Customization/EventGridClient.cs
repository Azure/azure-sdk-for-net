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
    [CodeGenSuppress("PublishCloudEvent", typeof(string), typeof(CloudEventInternal), typeof(CancellationToken))]
    [CodeGenSuppress("PublishCloudEventAsync", typeof(string), typeof(CloudEventInternal), typeof(CancellationToken))]
    [CodeGenSuppress("PublishCloudEvents", typeof(string), typeof(IEnumerable<CloudEventInternal>), typeof(CancellationToken))]
    [CodeGenSuppress("PublishCloudEventsAsync", typeof(string), typeof(IEnumerable<CloudEventInternal>), typeof(CancellationToken))]
#pragma warning disable AZC0007
    public partial class EventGridClient
#pragma warning restore AZC0007
    {
        // we have to duplicate the protocol method here because it has incorrect reference in its xml doc
        /// <summary>
        /// [Protocol Method] Publish Single Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> PublishCloudEventAsync(string topicName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("EventGridClient.PublishCloudEvent");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePublishCloudEventRequest(topicName, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Publish Single Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response PublishCloudEvent(string topicName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("EventGridClient.PublishCloudEvent");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePublishCloudEventRequest(topicName, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // we have to duplicate the protocol method here because it has incorrect reference in its xml doc
        /// <summary>
        /// [Protocol Method] Publish Batch Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> PublishCloudEventsAsync(string topicName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("EventGridClient.PublishCloudEvents");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePublishCloudEventsRequest(topicName, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Publish Batch Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response PublishCloudEvents(string topicName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("EventGridClient.PublishCloudEvents");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePublishCloudEventsRequest(topicName, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Publish Single Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="cloudEvent"> Single Cloud Event being published. </param>
        /// <param name="binaryMode"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="cloudEvent"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response PublishCloudEvent(string topicName, CloudEvent cloudEvent, bool binaryMode = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(cloudEvent, nameof(cloudEvent));

            RequestContext context = FromCancellationToken(cancellationToken);

            Response response;
            if (binaryMode)
            {
                response = PublishBinaryModeCloudEventAsync(topicName, cloudEvent, context, false).EnsureCompleted();
            }
            else
            {
                response = PublishCloudEvent(topicName, RequestContent.Create(cloudEvent), context);
            }

            return response;
        }

        /// <summary> Publish Single Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="cloudEvent"> Single Cloud Event being published. </param>
        /// <param name="binaryMode"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="cloudEvent"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response> PublishCloudEventAsync(
            string topicName,
            CloudEvent cloudEvent,
            bool binaryMode = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(cloudEvent, nameof(cloudEvent));

            RequestContext context = FromCancellationToken(cancellationToken);

            Response response;
            if (binaryMode)
            {
                response = await PublishBinaryModeCloudEventAsync(topicName, cloudEvent, context, true).ConfigureAwait(false);
            }
            else
            {
                response = await PublishCloudEventAsync(topicName, RequestContent.Create(cloudEvent), context).ConfigureAwait(false);
            }

            return response;
        }

        private async Task<Response> PublishBinaryModeCloudEventAsync(string topicName, CloudEvent cloudEvent, RequestContext context, bool async)
        {
            using var scope = ClientDiagnostics.CreateScope("EventGridClient.PublishCloudEvent");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePublishBinaryModeCloudEventRequest(topicName, cloudEvent, context);
                if (async)
                {
                    return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                }
                else
                {
                    return _pipeline.ProcessMessage(message, context);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private HttpMessage CreatePublishBinaryModeCloudEventRequest(string topicName, CloudEvent cloudEvent,
            RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/topics/", false);
            uri.AppendPath(topicName, true);
            uri.AppendPath(":publish", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (cloudEvent.DataContentType != null)
            {
                request.Headers.Add("content-type", cloudEvent.DataContentType);
            }

            request.Headers.Add("ce-id", cloudEvent.Id);
            request.Headers.Add("ce-specversion", "1.0");
            request.Headers.Add("ce-time", cloudEvent.Time.Value.ToString("o"));
            request.Headers.Add("ce-source", cloudEvent.Source);
            if (cloudEvent.Subject != null)
            {
                request.Headers.Add("ce-subject", cloudEvent.Subject);
            }

            request.Headers.Add("ce-type", cloudEvent.Type);
            if (cloudEvent.DataSchema != null)
            {
                request.Headers.Add("ce-dataschema", cloudEvent.DataSchema);
            }

            foreach (KeyValuePair<string, object> kvp in cloudEvent.ExtensionAttributes)
            {
                // https://github.com/cloudevents/spec/blob/main/cloudevents/spec.md#type-system
                switch (kvp.Value)
                {
                    case string stringVal:
                        request.Headers.Add($"ce-{kvp.Key}", stringVal);
                        break;
                    case byte[] bytes:
                        request.Headers.Add($"ce-{kvp.Key}", Convert.ToBase64String(bytes));
                        break;
                    case ReadOnlyMemory<byte> bytes:
                        request.Headers.Add($"ce-{kvp.Key}", Convert.ToBase64String(bytes.ToArray()));
                        break;
                    case int intVal:
                        request.Headers.Add($"ce-{kvp.Key}", intVal);
                        break;
                    case bool boolVal:
                        request.Headers.Add($"ce-{kvp.Key}", boolVal.ToString().ToLower());
                        break;
                    case Uri uriVal:
                        request.Headers.Add($"ce-{kvp.Key}", uriVal.AbsoluteUri);
                        break;
                    case DateTime dateTimeVal:
                        request.Headers.Add($"ce-{kvp.Key}", dateTimeVal.ToString("o"));
                        break;
                    case DateTimeOffset dateTimeOffsetVal:
                        request.Headers.Add($"ce-{kvp.Key}", dateTimeOffsetVal.ToString("o"));
                        break;
                }
            }

            request.Content = cloudEvent.Data;
            return message;
        }

        /// <summary> Publish Batch Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="events"> Array of Cloud Events being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="events"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response> PublishCloudEventsAsync(string topicName, IEnumerable<Azure.Messaging.CloudEvent> events,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(events, nameof(events));

            RequestContext context = FromCancellationToken(cancellationToken);
            return await PublishCloudEventsAsync(topicName, RequestContent.Create(events), context).ConfigureAwait(false);
        }

        /// <summary> Publish Batch Cloud Event to namespace topic. In case of success, the server responds with an HTTP 200 status code with an empty JSON object in response. Otherwise, the server can return various error codes. For example, 401: which indicates authorization failure, 403: which indicates quota exceeded or message is too large, 410: which indicates that specific topic is not found, 400: for bad request, and 500: for internal server error. </summary>
        /// <param name="topicName"> Topic Name. </param>
        /// <param name="events"> Array of Cloud Events being published. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="events"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response PublishCloudEvents(string topicName, IEnumerable<Azure.Messaging.CloudEvent> events,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(events, nameof(events));

            RequestContext context = FromCancellationToken(cancellationToken);
            return PublishCloudEvents(topicName, RequestContent.Create(events), context);
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
