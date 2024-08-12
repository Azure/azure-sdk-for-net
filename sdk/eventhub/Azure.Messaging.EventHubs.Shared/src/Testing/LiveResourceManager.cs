// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.EventHubs;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///  Provides common operations for managing resources used for Live tests.
    /// </summary>
    ///
    public sealed class LiveResourceManager
    {
        /// <summary>The maximum number of attempts to retry a management operation.</summary>
        public const int RetryMaximumAttempts = 20;

        /// <summary>The length of time to use as the basis for backing off on retry attempts.</summary>
        private readonly TimeSpan RetryExponentialBackoff = TimeSpan.FromSeconds(3);

        /// <summary>The maximum length of time allow for backing off on retry attempts.</summary>
        private readonly TimeSpan RetryMaximumBackoff = TimeSpan.FromMinutes(20);

        /// <summary>
        ///   The <see cref="ArmClient" /> instance to use for management operations.
        /// </summary>
        ///
        public ArmClient ArmClient { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="LiveResourceManager"/> class.
        /// </summary>
        ///
        public LiveResourceManager()
        {
            var options = new ArmClientOptions
            {
                Environment = new ArmEnvironment(
                    new Uri(EventHubsTestEnvironment.Instance.ResourceManagerUrl),
                    EventHubsTestEnvironment.Instance.ServiceManagementUrl),

                RetryPolicy = new EventHubsManagementRetryPolicy(
                    RetryMaximumAttempts,
                    DelayStrategy.CreateExponentialDelayStrategy(RetryExponentialBackoff, RetryMaximumBackoff))
            };

            ArmClient = new ArmClient(
                EventHubsTestEnvironment.Instance.Credential,
                EventHubsTestEnvironment.Instance.SubscriptionId,
                options);
        }

        /// <summary>
        ///   Gets the identifier for an existing Event Hub under the active namespace used for the test run.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub.</param>
        ///
        /// <returns>The resource identifier of the Event Hub.</returns>
        ///
        public ResourceIdentifier GetEventHubResourceIdentifier(string eventHubName) =>
            EventHubResource.CreateResourceIdentifier(
                EventHubsTestEnvironment.Instance.SubscriptionId,
                EventHubsTestEnvironment.Instance.ResourceGroup,
                EventHubsTestEnvironment.Instance.EventHubsNamespace,
                eventHubName);

        /// <summary>
        ///   Queries the consumer groups for an Event Hub under the active namespace used for the test run.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub to query.</param>
        ///
        /// <returns>A list containing the names of the consumer groups belonging to the Event Hub.</returns>
        ///
        public List<string> QueryEventHubConsumerGroupNames(string eventHubName) =>
            ArmClient
                .GetEventHubResource(GetEventHubResourceIdentifier(eventHubName))
                .GetEventHubsConsumerGroups()
                .Select(c => c.Data.Name)
                .ToList();

        /// <summary>
        ///   Creates a new Event Hub under the active namespace used for the test run.
        /// </summary>
        ///
        /// <param name="eventHubName">The name to assign the Event Hub.</param>
        /// <param name="partitionCount">The number of partitions that the Event Hub should have.</param>
        /// <param name="consumerGroups">The consumer groups to create for the Event Hub.  If not provided, only the default consumer group will exist.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        ///
        /// <returns>The newly created Event Hub.</returns>
        ///
        public async Task<EventHubResource> CreateEventHubAsync(string eventHubName,
                                                                int partitionCount,
                                                                IList<string> consumerGroups = default,
                                                                CancellationToken cancellationToken = default)
        {
            var ehNamespace = ArmClient.GetEventHubsNamespaceResource(
                EventHubsNamespaceResource.CreateResourceIdentifier(
                    EventHubsTestEnvironment.Instance.SubscriptionId,
                    EventHubsTestEnvironment.Instance.ResourceGroup,
                    EventHubsTestEnvironment.Instance.EventHubsNamespace));

            var eventHubConfig = new EventHubData { PartitionCount = partitionCount };
            var eventHub = await ehNamespace.GetEventHubs().CreateOrUpdateAsync(WaitUntil.Completed, eventHubName, eventHubConfig).ConfigureAwait(false);

            var groups = consumerGroups ?? new List<string>();
            var consumerGroupCollection = eventHub.Value.GetEventHubsConsumerGroups();

            if (groups?.Count > 0)
            {
                var groupData = new EventHubsConsumerGroupData();

                await Task.WhenAll
                (
                    groups.Select(groupName =>
                    {
                        return consumerGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, groupName, groupData);
                    })
                ).ConfigureAwait(false);
            }

            return eventHub.Value;
        }

        /// <summary>
        ///   Deletes an Event Hub under the active namespace used for the test run.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        ///
        public async Task DeleteEventHubAsync(string eventHubName,
                                              CancellationToken cancellationToken = default) =>
            await ArmClient.GetEventHubResource(GetEventHubResourceIdentifier(eventHubName)).DeleteAsync(WaitUntil.Completed, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   A retry policy that extends the common retry scenarios to include
        ///   additional response types specific to Event Hubs management operations.
        /// </summary>
        ///
        /// <seealso cref="Azure.Core.Pipeline.RetryPolicy" />
        ///
        private class EventHubsManagementRetryPolicy : RetryPolicy
        {
            /// <summary>The classifier to use when considering retries for management operations.</summary>
            private static readonly ResponseClassifier Classifier = new EventHubsManagementClassifier();

            /// <summary>
            ///   Initializes a new instance of the <see cref="EventHubsManagementRetryPolicy"/> class.
            /// </summary>
            ///
            /// <param name="maximumRetryAttempts">The maximum number of retry attempts for a single operation.</param>
            /// <param name="delayStrategy">The delay strategy.</param>
            ///
            public EventHubsManagementRetryPolicy(int maximumRetryAttempts, DelayStrategy delayStrategy) : base(maximumRetryAttempts, delayStrategy)
            {
            }

            /// <summary>
            ///   Determines whether a retry should be performed for the associated operation.
            /// </summary>
            ///
            /// <param name="message">The <see cref="HttpMessage" /> for the operation.</param>
            /// <param name="exception">The exception, if any, thrown by the operation.</param>
            ///
            /// <returns><c>true</c> if the operation should be retried; otherwise, <c>false</c>.</returns>
            ///
            protected override bool ShouldRetry(HttpMessage message, Exception exception)
            {
                message.ResponseClassifier = Classifier;
                return base.ShouldRetry(message, exception);
            }

            /// <summary>
            ///   Determines whether a retry should be performed for the associated operation.
            /// </summary>
            ///
            /// <param name="message">The <see cref="HttpMessage" /> for the operation.</param>
            /// <param name="exception">The exception, if any, thrown by the operation.</param>
            ///
            /// <returns><c>true</c> if the operation should be retried; otherwise, <c>false</c>.</returns>
            ///
            protected override ValueTask<bool> ShouldRetryAsync(HttpMessage message, Exception exception)
            {
                message.ResponseClassifier = Classifier;
                return base.ShouldRetryAsync(message, exception);
            }

            /// <summary>
            ///   A custom response classifier that extends the common retry scenarios to include
            ///   additional response types specific to Event Hubs management operations.
            /// </summary>
            ///
            /// <seealso cref="Azure.Core.ResponseClassifier" />
            ///
            private class EventHubsManagementClassifier : ResponseClassifier
            {
                /// <summary>
                ///   Determines whether the specified HTTP message is considered eligible to retry for
                ///   the associated operation.
                /// </summary>
                ///
                /// <param name="message">The <see cref="HttpMessage" /> to consider.</param>
                ///
                /// <returns><c>true</c> if the message is eligible for retries; otherwise, <c>false</c>.</returns>
                ///
                public override bool IsRetriableResponse(HttpMessage message)
                {
                    if (message == null)
                    {
                        return false;
                    }

                    return IsRetriableStatus(message.Response.Status);
                }

                /// <summary>
                ///   Determines whether the type of the specified exception is considered eligible to retry
                ///   the associated operation.
                /// </summary>
                ///
                /// <param name="exception">The exception to consider.</param>
                ///
                /// <returns><c>true</c> if the exception type is eligible for retries; otherwise, <c>false</c>.</returns>
                ///
                public override bool IsRetriableException(Exception exception)
                {
                    if (exception == null)
                    {
                        return false;
                    }

                    switch (exception)
                    {
                        case RequestFailedException erEx:
                            return IsRetriableStatus(erEx.Status);

                        case TimeoutException _:
                        case TaskCanceledException _:
                        case OperationCanceledException _:
                        case HttpRequestException _:
                        case WebException _:
                        case SocketException _:
                        case IOException _:
                            return true;

                        default:
                            return false;
                    };
                }

                /// <summary>
                ///   Determines whether the specified HTTP status code is considered eligible to retry for
                ///   the associated operation.
                /// </summary>
                ///
                /// <param name="message">The status code to consider.</param>
                ///
                /// <returns><c>true</c> if the message is eligible for retries; otherwise, <c>false</c>.</returns>
                ///
                private bool IsRetriableStatus(int statusCode) => statusCode switch
                {
                   (int)HttpStatusCode.Unauthorized => true,
                   (int)HttpStatusCode.Conflict => true,
                   (int)HttpStatusCode.InternalServerError => true,
                   (int)HttpStatusCode.ServiceUnavailable => true,
                   (int)HttpStatusCode.GatewayTimeout => true,
                   408 => true,
                   429 => true,
                   _ => false
                };
        };
        }
    }
}
