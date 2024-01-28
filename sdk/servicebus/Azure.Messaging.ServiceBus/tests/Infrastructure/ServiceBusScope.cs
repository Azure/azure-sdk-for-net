// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Administration;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///  Provides access to dynamically created instances of Service Bus resources which exists only in the context
    ///  of their scope.
    /// </summary>
    ///
    public static class ServiceBusScope
    {
        /// <summary>
        /// The domain to use when forming the fully qualified namespace.
        /// </summary>
        private static readonly string s_hostDomain =
            ServiceBusTestEnvironment.Instance.AzureEnvironment == "AzureUSGovernment" ? "servicebus.usgovcloudapi.net"
            : "servicebus.windows.net";

        /// <summary> The client used to create and delete resources on the Service Bus namespace. </summary>
        private static ServiceBusAdministrationClient CreateClient(string namespaceName)
        {
            return new ServiceBusAdministrationClient(
                $"{namespaceName}.{s_hostDomain}",
                ServiceBusTestEnvironment.Instance.Credential,
                // disable tracing so as not to impact any tracing tests
                new ServiceBusAdministrationClientOptions { Diagnostics = { IsDistributedTracingEnabled = false } });
        }

        /// <summary>
        ///   Creates a Service Bus scope associated with a queue instance, intended to be used in the context
        ///   of a single test and disposed when the test has completed.
        /// </summary>
        ///
        /// <param name="enablePartitioning">When <c>true</c>, partitioning will be enabled on the queue that is created.</param>
        /// <param name="enableSession">When <c>true</c>, a session will be enabled on the queue that is created.</param>
        /// <param name="forceQueueCreation">When <c>true</c>, forces creation of a new queue even if an environmental override was specified to use an existing one.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        /// <param name="lockDuration">The lock duration for the queue.</param>
        /// <param name="overrideNamespace">The namespace to use for the queue.</param>
        /// <param name="defaultMessageTimeToLive">The default message time to live for the queue.</param>
        /// <returns>The requested Service Bus <see cref="QueueScope" />.</returns>
        ///
        /// <remarks>
        ///   If an environmental override was set to use an existing Service Bus queue resource and the <paramref name="forceQueueCreation" /> flag
        ///   was not set, the existing queue will be assumed with no validation.  In this case the <paramref name="enablePartitioning" /> and
        ///   <paramref name="enableSession" /> parameters are also ignored.
        /// </remarks>
        ///
        public static async Task<QueueScope> CreateWithQueue(bool enablePartitioning,
                                                             bool enableSession,
                                                             bool forceQueueCreation = false,
                                                             TimeSpan? lockDuration = default,
                                                             string overrideNamespace = default,
                                                             TimeSpan? defaultMessageTimeToLive = default,
                                                             [CallerMemberName] string caller = "")
        {
            // Create a new queue specific to the scope being created.

            caller = (caller.Length < 16) ? caller : caller.Substring(0, 15);

            var serviceBusNamespace = overrideNamespace ?? ServiceBusTestEnvironment.Instance.ServiceBusNamespace;

            var queueName = $"{ Guid.NewGuid().ToString("D").Substring(0, 13) }-{ caller }";

            var queueOptions = new CreateQueueOptions(queueName)
            {
                EnablePartitioning = enablePartitioning,
                RequiresSession = enableSession,
            };
            if (lockDuration.HasValue)
            {
                queueOptions.LockDuration = lockDuration.Value;
            }

            if (defaultMessageTimeToLive.HasValue)
            {
                queueOptions.DefaultMessageTimeToLive = defaultMessageTimeToLive.Value;
            }

            var client = CreateClient(serviceBusNamespace);

            QueueProperties queueProperties = await client.CreateQueueAsync(queueOptions);
            return new QueueScope(serviceBusNamespace, queueProperties.Name, true);
        }

        /// <summary>
        ///   Creates a Service Bus scope associated with a topic instance, intended to be used in the context
        ///   of a single test and disposed when the test has completed.
        /// </summary>
        ///
        /// <param name="enablePartitioning">When <c>true</c>, partitioning will be enabled on the topic that is created.</param>
        /// <param name="enableSession">When <c>true</c>, a session will be enabled on the topic that is created.</param>
        /// <param name="topicSubscriptions">The set of subscriptions to create for the topic.  If <c>null</c>, a default subscription will be assumed.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The requested Service Bus <see cref="TopicScope" />.</returns>
        ///
        public static async Task<TopicScope> CreateWithTopic(bool enablePartitioning,
                                                             bool enableSession,
                                                             IEnumerable<string> topicSubscriptions = null,
                                                             [CallerMemberName] string caller = "")
        {
            caller = (caller.Length < 16) ? caller : caller.Substring(0, 15);
            topicSubscriptions ??= new[] { "default-subscription" };

            var serviceBusNamespace = ServiceBusTestEnvironment.Instance.ServiceBusNamespace;
            var topicName = $"{ Guid.NewGuid().ToString("D").Substring(0, 13) }-{ caller }";

            var topicOptions = new CreateTopicOptions(topicName)
            {
                EnablePartitioning = enablePartitioning
            };

            var client = CreateClient(serviceBusNamespace);
            TopicProperties topicProperties = await client.CreateTopicAsync(topicOptions);

            var activeSubscriptions = new List<string>();

            foreach (var subscription in topicSubscriptions)
            {
                var subscriptionOptions = new CreateSubscriptionOptions(topicName, subscription)
                {
                    RequiresSession = enableSession
                };
                SubscriptionProperties subscriptionProperties = await client.CreateSubscriptionAsync(subscriptionOptions);
                activeSubscriptions.Add(subscriptionProperties.SubscriptionName);
            }

            return new TopicScope(serviceBusNamespace, topicProperties.Name, activeSubscriptions, true);
        }

        /// <summary>
        ///   Provides access to dynamically created Service Bus Queue instance which exists only in the context
        ///   of the scope; disposal removes the resource from Azure.
        /// </summary>
        ///
        /// <seealso cref="IAsyncDisposable" />
        ///
        public sealed class QueueScope : IAsyncDisposable
        {
            /// <summary>Serves as a sentinel flag to denote when the instance has been disposed.</summary>
            private bool _disposed = false;

            /// <summary>
            ///   The name of the Service Bus namespace associated with the queue.
            /// </summary>
            ///
            public string NamespaceName { get; }

            /// <summary>
            ///  The name of the queue.
            /// </summary>
            ///
            public string QueueName { get; }

            /// <summary>
            ///   A flag indicating if the queue should be removed when the scope is complete.
            /// </summary>
            ///
            /// <value><c>true</c> if the queue was should be removed at scope completion; otherwise, <c>false</c>.</value>
            ///
            private bool ShouldRemoveAtScopeCompletion { get; }

            /// <summary>
            ///   Initializes a new instance of the <see cref="QueueScope"/> class.
            /// </summary>
            ///
            /// <param name="serviceBusNamespaceName">The name of the Service Bus namespace to which the queue is associated.</param>
            /// <param name="queueName">The name of the queue.</param>
            /// <param name="shouldRemoveAtScopeCompletion">A flag indicating whether the queue should be removed when the scope is complete.</param>
            ///
            public QueueScope(string serviceBusNamespaceName,
                              string queueName,
                              bool shouldRemoveAtScopeCompletion)
            {
                NamespaceName = serviceBusNamespaceName;
                QueueName = queueName;
                ShouldRemoveAtScopeCompletion = shouldRemoveAtScopeCompletion;
            }

            /// <summary>
            ///   Performs the tasks needed to remove the dynamically created Service Bus Queue.
            /// </summary>
            ///
            public async ValueTask DisposeAsync()
            {
                if (!ShouldRemoveAtScopeCompletion)
                {
                    _disposed = true;
                }

                if (_disposed)
                {
                    return;
                }

                try
                {
                    var client = CreateClient(NamespaceName);
                    await client.DeleteQueueAsync(QueueName);
                }
                catch
                {
                    // This should not be considered a critical failure that results in a test failure.  Due
                    // to ARM being temperamental, some management operations may be rejected.  Throwing here
                    // does not help to ensure resource cleanup only flags the test itself as a failure.
                    //
                    // If a queue fails to be deleted, removing of the associated namespace at the end of the
                    // test run will also remove the orphan.
                }

                _disposed = true;
            }
        }

        /// <summary>
        ///   Provides access to dynamically created Service Bus Topic instance which exists only in the context
        ///   of the scope; disposal removes the resource from Azure.
        /// </summary>
        ///
        /// <seealso cref="IAsyncDisposable" />
        ///
        public sealed class TopicScope : IAsyncDisposable
        {
            /// <summary>Serves as a sentinel flag to denote when the instance has been disposed.</summary>
            private bool _disposed = false;

            /// <summary>
            ///   The name of the Service Bus namespace associated with the queue.
            /// </summary>
            ///
            public string NamespaceName { get; }

            /// <summary>
            ///  The name of the topic.
            /// </summary>
            ///
            public string TopicName { get; }

            /// <summary>
            ///   The set of names for the subscriptions associated with the topic.
            /// </summary>
            ///
            public IReadOnlyList<string> SubscriptionNames { get; }

            /// <summary>
            ///   A flag indicating if the topic should be removed when the scope is complete.
            /// </summary>
            ///
            /// <value><c>true</c> if the queue was should be removed at scope completion; otherwise, <c>false</c>.</value>
            ///
            private bool ShouldRemoveAtScopeCompletion { get; }

            /// <summary>
            ///   Initializes a new instance of the <see cref="TopicScope"/> class.
            /// </summary>
            ///
            /// <param name="serviceBusNamespaceName">The name of the Service Bus namespace to which the queue is associated.</param>
            /// <param name="topicName">The name of the topic.</param>
            /// <param name="subscriptionNames">The set of names for the subscriptions </param>
            /// <param name="shouldRemoveAtScopeCompletion">A flag indicating whether the topic should be removed when the scope is complete.</param>
            ///
            public TopicScope(string serviceBusNamespaceName,
                              string topicName,
                              IReadOnlyList<string> subscriptionNames,
                              bool shouldRemoveAtScopeCompletion)
            {
                NamespaceName = serviceBusNamespaceName;
                TopicName = topicName;
                SubscriptionNames = subscriptionNames;
                ShouldRemoveAtScopeCompletion = shouldRemoveAtScopeCompletion;
            }

            /// <summary>
            ///   Performs the tasks needed to remove the dynamically created Service Bus Topic.
            /// </summary>
            ///
            public async ValueTask DisposeAsync()
            {
                if (!ShouldRemoveAtScopeCompletion)
                {
                    _disposed = true;
                }

                if (_disposed)
                {
                    return;
                }

                try
                {
                    var client = CreateClient(NamespaceName);
                    await client.DeleteTopicAsync(TopicName);
                }
                catch
                {
                    // This should not be considered a critical failure that results in a test failure.  Due
                    // to ARM being temperamental, some management operations may be rejected.  Throwing here
                    // does not help to ensure resource cleanup only flags the test itself as a failure.
                    //
                    // If a topic fails to be deleted, removing of the associated namespace at the end of the
                    // test run will also remove the orphan.
                }

                _disposed = true;
            }
        }
    }
}
