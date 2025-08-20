// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Management;
    using Polly;

    internal static class ServiceBusScope
    {
        private static int randomSeed = Environment.TickCount;

        private static readonly ThreadLocal<Random> Rng = new ThreadLocal<Random>( () => new Random(Interlocked.Increment(ref randomSeed)), false);
        private static readonly ManagementClient ManagementClient = new ManagementClient(TestUtility.NamespaceConnectionString);

        /// <summary>
        ///   Creates a temporary Service Bus queue to be used within a given scope and then removed.
        /// </summary>
        ///
        /// <param name="partitioned">If <c>true</c>, a partitioned queue will be used.</param>
        /// <param name="sessionEnabled">If <c>true</c>, a session will be enabled on the queue.</param>
        /// <param name="configureQueue">If provided, an action that can override the default properties used for queue creation.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The queue scope that was created.</returns>
        ///
        public static async Task<QueueScope> CreateQueueAsync(bool partitioned,
                                                              bool sessionEnabled,
                                                              Action<QueueDescription> configureQueue = null,
                                                              [CallerMemberName] string caller = "")
        {
            var name = $"{ caller }-{ Guid.NewGuid().ToString("D").Substring(0, 8) }";
            var queueDescription = BuildQueueDescription(name, partitioned, sessionEnabled);

            configureQueue?.Invoke(queueDescription);
            await CreateRetryPolicy<QueueDescription>().ExecuteAsync( () => ManagementClient.CreateQueueAsync(queueDescription));

            return new QueueScope(name, async () =>
            {
                try
                {
                    await CreateRetryPolicy().ExecuteAsync( () => ManagementClient.DeleteQueueAsync(name));
                }
                catch (Exception ex)
                {
                    TestUtility.Log($"There was an issue removing the queue: [{ name }].  This is considered non-fatal, but you should remove this manually from the Service Bus namespace. Exception: [{ ex.Message }]");
                }
            });
        }

        /// <summary>
        ///   Creates a temporary Service Bus topic, with subscription to be used within a given scope and then removed.
        /// </summary>
        ///
        /// <param name="partitioned">If <c>true</c>, a partitioned topic will be used.</param>
        /// <param name="sessionEnabled">If <c>true</c>, a session will be enabled  on the subscription.</param>
        /// <param name="configureTopic">If provided, an action that can override the default properties used for topic creation.</param>
        /// <param name="configureSubscription">If provided, an action that can override the default properties used for topic creation.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The topic scope that was created.</returns>
        ///
        public static async Task<TopicScope> CreateTopicAsync(bool partitioned,
                                                              bool sessionEnabled,
                                                              Action<TopicDescription> configureTopic = null,
                                                              Action<SubscriptionDescription> configureSubscription = null,
                                                              [CallerMemberName] string caller = "")
        {
            var topicName = $"{ caller }-{ Guid.NewGuid().ToString("D").Substring(0, 8) }";
            var subscripionName = (sessionEnabled) ? TestConstants.SessionSubscriptionName : TestConstants.SubscriptionName;
            var topicDescription = BuildTopicDescription(topicName, partitioned);
            var subscriptionDescription = BuildSubscriptionDescription(subscripionName, topicName, sessionEnabled);

            configureTopic?.Invoke(topicDescription);
            configureSubscription?.Invoke(subscriptionDescription);

            await CreateRetryPolicy<TopicDescription>().ExecuteAsync( () => ManagementClient.CreateTopicAsync(topicDescription));
            await CreateRetryPolicy<SubscriptionDescription>().ExecuteAsync( () => ManagementClient.CreateSubscriptionAsync(subscriptionDescription));

            return new TopicScope(topicName, subscripionName, async () =>
            {
                try
                {
                    await CreateRetryPolicy().ExecuteAsync( () => ManagementClient.DeleteTopicAsync(topicName));
                }
                catch (Exception ex)
                {
                    TestUtility.Log($"There was an issue removing the topic: [{ topicName }].  This is considered non-fatal, but you should remove this manually from the Service Bus namespace. Exception: [{ ex.Message }]");
                }
            });
        }

        /// <summary>
        ///   Performs an operation within the scope of a temporary Service Bus queue.
        /// </summary>
        ///
        /// <param name="partitioned">If <c>true</c>, a partitioned queue will be used.</param>
        /// <param name="sessionEnabled">If <c>true</c>, a session will be required on the queue.</param>
        /// <param name="scopedOperationAsync">The asynchronous operation to be performed; the name of the queue will be passed to the operation.</param>
        /// <param name="configureQueue">If provided, an action that can override the default properties used for queue creation.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The task representing the operation being performed</returns>
        ///
        public static async Task UsingQueueAsync(bool partitioned,
                                                 bool sessionEnabled,
                                                 Func<string, Task> scopedOperationAsync,
                                                 Action<QueueDescription> configureQueue = null,
                                                 [CallerMemberName] string caller = "")
        {
            if (scopedOperationAsync == null)
            {
                throw new ArgumentNullException(nameof(scopedOperationAsync));
            }

            var scope = default(QueueScope);

            try
            {
                 scope = await CreateQueueAsync(partitioned, sessionEnabled, configureQueue, caller);
                 await scopedOperationAsync(scope.Name);
            }
            finally
            {
                try
                {
                    await scope?.CleanupAsync();
                }
                catch
                {
                    // This should not be considered a critical failure that results in a test failure.  Some management
                    // operations may be temperamental.  Throwing here does not help to ensure resource cleanup, rather
                    // only accomplishes flagging the test itself as a failure.
                    //
                    // If a queue fails to be deleted, removing of the associated namespace at the end of the
                    // test run will also remove the orphan.
                }
            }
        }

        /// <summary>
        ///   Performs an operation within the scope of a temporary Service Bus topic, with subscription.
        /// </summary>
        ///
        /// <param name="partitioned">If <c>true</c>, a partitioned topic will be used.</param>
        /// <param name="sessionEnabled">If <c>true</c>, a session will be required on the subscription.</param>
        /// <param name="scopedOperationAsync">The asynchronous operation to be performed; the name of the topic and subscription will be passed to the operation.</param>
        /// <param name="configureTopic">If provided, an action that can override the default properties used for topic creation.</param>
        /// <param name="configureTSubscription">If provided, an action that can override the default properties used for topic creation.</param>
        /// <param name="caller">The name of the calling method; this is intended to be populated by the runtime.</param>
        ///
        /// <returns>The task representing the operation being performed</returns>
        ///
        public static async Task UsingTopicAsync(bool partitioned,
                                                 bool sessionEnabled,
                                                 Func<string, string, Task> scopedOperationAsync,
                                                 Action<TopicDescription> configureTopic = null,
                                                 Action<SubscriptionDescription> configureSubscription = null,
                                                 [CallerMemberName] string caller = "")
        {
            if (scopedOperationAsync == null)
            {
                throw new ArgumentNullException(nameof(scopedOperationAsync));
            }

            var scope = default(TopicScope);

            try
            {
                 scope = await CreateTopicAsync(partitioned, sessionEnabled, configureTopic, configureSubscription, caller);
                 await scopedOperationAsync(scope.TopicName, scope.SubscriptionName);
            }
            finally
            {
                try
                {
                    await scope?.CleanupAsync();
                }
                catch
                {
                    // This should not be considered a critical failure that results in a test failure.  Some management
                    // operations may be temperamental.  Throwing here does not help to ensure resource cleanup, rather
                    // only accomplishes flagging the test itself as a failure.
                    //
                    // If a topic fails to be deleted, removing of the associated namespace at the end of the
                    // test run will also remove the orphan.
                }
            }
        }

        private static IAsyncPolicy<T> CreateRetryPolicy<T>(int maxRetryAttempts = TestConstants.RetryMaxAttempts, double exponentialBackoffSeconds = TestConstants.RetryExponentialBackoffSeconds, double baseJitterSeconds = TestConstants.RetryBaseJitterSeconds) =>
            Policy<T>
                .Handle<ServiceBusCommunicationException>()
                .Or<ServiceBusTimeoutException>()
                .WaitAndRetryAsync(maxRetryAttempts, attempt => CalculateRetryDelay(attempt, exponentialBackoffSeconds, baseJitterSeconds));

        private static IAsyncPolicy CreateRetryPolicy(int maxRetryAttempts = TestConstants.RetryMaxAttempts, double exponentialBackoffSeconds = TestConstants.RetryExponentialBackoffSeconds, double baseJitterSeconds = TestConstants.RetryBaseJitterSeconds) =>
            Policy
                .Handle<ServiceBusCommunicationException>()
                .Or<ServiceBusTimeoutException>()
                .WaitAndRetryAsync(maxRetryAttempts, attempt => CalculateRetryDelay(attempt, exponentialBackoffSeconds, baseJitterSeconds));

        private static TimeSpan CalculateRetryDelay(int attempt, double exponentialBackoffSeconds, double baseJitterSeconds) =>
            TimeSpan.FromSeconds((Math.Pow(2, attempt) * exponentialBackoffSeconds) + (Rng.Value.NextDouble() * baseJitterSeconds));

        private static QueueDescription BuildQueueDescription(string name, bool partitioned, bool sessionEnabled) =>
            new QueueDescription(name)
            {
                DefaultMessageTimeToLive = TestConstants.QueueDefaultMessageTimeToLive,
                LockDuration = TestConstants.QueueDefaultLockDuration,
                DuplicateDetectionHistoryTimeWindow = TestConstants.QueueDefaultDuplicateDetectionHistory,
                MaxSizeInMB = TestConstants.QueueDefaultMaxSizeMegabytes,
                EnablePartitioning = partitioned,
                RequiresSession = sessionEnabled
            };

        private static TopicDescription BuildTopicDescription(string name, bool partitioned) =>
            new TopicDescription(name)
            {
                DefaultMessageTimeToLive = TestConstants.TopicDefaultMessageTimeToLive,
                DuplicateDetectionHistoryTimeWindow = TestConstants.TopicDefaultDuplicateDetectionHistory,
                MaxSizeInMB = TestConstants.TopicDefaultMaxSizeMegabytes,
                EnablePartitioning = partitioned
            };

        private static SubscriptionDescription BuildSubscriptionDescription(string subscriptionName, string topicName, bool sessionEnabled) =>
            new SubscriptionDescription(topicName, subscriptionName)
            {
                DefaultMessageTimeToLive = TestConstants.SubscriptionDefaultMessageTimeToLive,
                LockDuration = TestConstants.SubscriptionDefaultLockDuration,
                MaxDeliveryCount = TestConstants.SubscriptionMaximumDeliveryCount,
                EnableDeadLetteringOnMessageExpiration = TestConstants.SubscriptionDefaultDeadLetterOnExpire,
                EnableDeadLetteringOnFilterEvaluationExceptions = TestConstants.SubscriptionDefaultDeadLetterOnException,
                RequiresSession = sessionEnabled
            };

        internal sealed class QueueScope
        {
            public readonly string Name;
            private readonly Func<Task> CleanupAction;

            public QueueScope(string name, Func<Task> cleanupAction)
            {
                Name = name;
                CleanupAction = cleanupAction;
            }

            public Task CleanupAsync() => CleanupAction?.Invoke() ?? Task.CompletedTask;
        }

        internal sealed class TopicScope
        {
            public readonly string TopicName;
            public readonly string SubscriptionName;
            private readonly Func<Task> CleanupAction;

            public TopicScope(string topicName, string subscriptionName, Func<Task> cleanupAction)
            {
                TopicName = topicName;
                SubscriptionName = subscriptionName;
                CleanupAction = cleanupAction;
            }

            public Task CleanupAsync() => CleanupAction?.Invoke() ?? Task.CompletedTask;
        }
    }
}
