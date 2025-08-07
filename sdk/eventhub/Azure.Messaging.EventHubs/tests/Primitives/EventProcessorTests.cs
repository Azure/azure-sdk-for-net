// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventProcessor{TPartition}" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   This segment of the partial class defines types and members for use throughout the
    ///   <see cref="EventProcessor{TPartition}" /> test suite, which are referenced by the
    ///   other partial classes defined in the <c>EventProcessorTests.[[ CATEGORY ]].cs</c> files.
    /// </remarks>
    ///
    [TestFixture]
    public partial class EventProcessorTests
    {
        /// <summary>An empty event batch to use for mocking.</summary>
        private static readonly IReadOnlyList<EventData> EmptyBatch = new List<EventData>(0);

        /// <summary>
        ///   Retrieves the load balancer for an event processor instance, using its private accessor.
        /// </summary>
        ///
        /// <typeparam name="T">The partition type to which the processor is bound.</typeparam>
        ///
        /// <param name="processor">The processor instance to operate on.</param>
        ///
        /// <returns>The load balancer used by the processor.</returns>
        ///
        private static PartitionLoadBalancer GetLoadBalancer<T>(EventProcessor<T> processor) where T : EventProcessorPartition, new() =>
            (PartitionLoadBalancer)
                typeof(EventProcessor<T>)
                    .GetProperty("LoadBalancer", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(processor);

        /// <summary>
        ///   Creates a connection using a processor client's ConnectionFactory and returns its ConnectionOptions.
        /// </summary>
        ///
        /// <typeparam name="T">The partition type to which the processor is bound.</typeparam>
        ///
        /// <param name="processor">The processor instance to operate on.</param>
        ///
        /// <returns>The set of options used by the connection.</returns>
        ///
        private static EventHubConnectionOptions GetConnectionOptions<T>(EventProcessor<T> processor) where T : EventProcessorPartition, new() =>
            (EventHubConnectionOptions)
                typeof(EventHubConnection)
                    .GetProperty("Options", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(processor.CreateConnection());

        /// <summary>
        ///   Retrieves the task used to track the processor's activity when running, using its private accessor.
        /// </summary>
        ///
        /// <typeparam name="T">The partition type to which the processor is bound.</typeparam>
        ///
        /// <param name="processor">The processor instance to operate on.</param>
        ///
        /// <returns>The task for tracking the processor's activity when running.</returns>
        ///
        private static Task GetRunningProcessorTask<T>(EventProcessor<T> processor) where T : EventProcessorPartition, new() =>
            (Task)
                typeof(EventProcessor<T>)
                    .GetField("_runningProcessorTask", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(processor);

        /// <summary>
        ///   Retrieves the cancellation source used for the processor's activity when running, using its private accessor.
        /// </summary>
        ///
        /// <typeparam name="T">The partition type to which the processor is bound.</typeparam>
        ///
        /// <param name="processor">The processor instance to operate on.</param>
        ///
        /// <returns>The cancellation source associated with the processor's activity when running.</returns>
        ///
        private static CancellationTokenSource GetRunningProcessorCancellationSource<T>(EventProcessor<T> processor) where T : EventProcessorPartition, new() =>
            (CancellationTokenSource)
                typeof(EventProcessor<T>)
                    .GetField("_runningProcessorCancellationSource", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(processor);

        /// <summary>
        ///   Retrieves the active set of partition processors for an event processor, using its private accessor.
        /// </summary>
        ///
        /// <typeparam name="T">The partition type to which the processor is bound.</typeparam>
        ///
        /// <param name="processor">The processor instance to operate on.</param>
        ///
        /// <returns>The set of active partition processors.</returns>
        ///
        private static ConcurrentDictionary<string, EventProcessor<T>.PartitionProcessor> GetActivePartitionProcessors<T>(EventProcessor<T> processor) where T : EventProcessorPartition, new() =>
            (ConcurrentDictionary<string, EventProcessor<T>.PartitionProcessor>)
                typeof(EventProcessor<T>)
                    .GetProperty("ActivePartitionProcessors", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(processor);

        /// <summary>
        ///   Invokes the processor infrastructure method responsible for starting a partition
        ///   processing task, using its private accessor.
        /// </summary>
        ///
        /// <typeparam name="T">The partition type to which the processor is bound.</typeparam>
        ///
        /// <param name="processor">The processor instance to operate on.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing should be started.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><c>true</c> if the <paramref name="partitionId"/> was started; otherwise, <c>false</c>.</returns>
        ///
        private static bool InvokeTryStartProcessingPartition<T>(EventProcessor<T> processor,
                                                                 string partitionId,
                                                                 CancellationToken cancellationToken) where T : EventProcessorPartition, new() =>
            (bool)
                typeof(EventProcessor<T>)
                    .GetMethod("TryStartProcessingPartition", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(processor, new object[] { partitionId, cancellationToken });

        /// <summary>
        ///   Invokes the processor infrastructure method responsible for stopping a partition
        ///   processing task, using its private accessor.
        /// </summary>
        ///
        /// <typeparam name="T">The partition type to which the processor is bound.</typeparam>
        ///
        /// <param name="processor">The processor instance to operate on.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing should be stopped.</param>
        /// <param name="reason">The reason why the processing is being stopped.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><c>true</c> if the <paramref name="partitionId"/> was owned and was being processed; otherwise, <c>false</c>.</returns>
        ///
        private static Task InvokeStopProcessingPartitionAsync<T>(EventProcessor<T> processor,
                                                                  string partitionId,
                                                                  ProcessingStoppedReason reason,
                                                                  CancellationToken cancellationToken) where T : EventProcessorPartition, new() =>
            (Task)
                typeof(EventProcessor<T>)
                    .GetMethod("StopProcessingPartitionAsync", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(processor, new object[] { partitionId, reason, cancellationToken });

        /// <summary>
        ///   A basic custom partition type, allowing for testing or processor functionality.
        /// </summary>
        ///
        public class CustomPartition : EventProcessorPartition
        {
            public string Description { get; set; }
        }

        /// <summary>
        ///   A basic mock of the event processor, allowing for testing of specific base class
        ///   functionality.
        /// </summary>
        ///
        public class MinimalProcessorMock : EventProcessor<EventProcessorPartition>
        {
            public MinimalProcessorMock(int eventBatchMaximumCount,
                                        string consumerGroup,
                                        string connectionString,
                                        EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, connectionString, options) { }

            public MinimalProcessorMock(int eventBatchMaximumCount,
                                        string consumerGroup,
                                        string connectionString,
                                        string eventHubName,
                                        EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, connectionString, eventHubName, options) { }

            public MinimalProcessorMock(int eventBatchMaximumCount,
                                        string consumerGroup,
                                        string fullyQualifiedNamespace,
                                        string eventHubName,
                                        AzureNamedKeyCredential credential,
                                        EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options) { }

            public MinimalProcessorMock(int eventBatchMaximumCount,
                                        string consumerGroup,
                                        string fullyQualifiedNamespace,
                                        string eventHubName,
                                        AzureSasCredential credential,
                                        EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options) { }

            public MinimalProcessorMock(int eventBatchMaximumCount,
                                        string consumerGroup,
                                        string fullyQualifiedNamespace,
                                        string eventHubName,
                                        TokenCredential credential,
                                        EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options) { }

            internal MinimalProcessorMock(int eventBatchMaximumCount,
                                          string consumerGroup,
                                          string fullyQualifiedNamespace,
                                          string eventHubName,
                                          TokenCredential credential,
                                          EventProcessorOptions options,
                                          PartitionLoadBalancer loadBalancer) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options, loadBalancer) { }

            public LastEnqueuedEventProperties InvokeReadLastEnqueuedEventProperties(string partitionId) => ReadLastEnqueuedEventProperties(partitionId);
            protected internal override Task ValidateProcessingPreconditions(CancellationToken cancellationToken = default) => Task.CompletedTask;
            protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken) => Task.FromResult(Enumerable.Empty<EventProcessorPartitionOwnership>());
            protected override Task<EventProcessorCheckpoint> GetCheckpointAsync(string partitionId, CancellationToken cancellationToken) => Task.FromResult(default(EventProcessorCheckpoint));
            protected override Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken = default) => Task.FromResult(Enumerable.Empty<EventProcessorCheckpoint>());
            protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken) => Task.FromResult(Enumerable.Empty<EventProcessorPartitionOwnership>());
            protected override Task OnProcessingErrorAsync(Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken) => throw new NotImplementedException();
            protected override Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken) => throw new NotImplementedException();
        }

        /// <summary>
        ///   A shim for the transport consumer, allowing setting of base class
        ///   protected properties.
        /// </summary>
        ///
        internal class SettableTransportConsumer : TransportConsumer
        {
            public void SetLastEvent(EventData lastEvent) => LastReceivedEvent = lastEvent;
            public override Task CloseAsync(CancellationToken cancellationToken) => Task.CompletedTask;
            public override Task<IReadOnlyList<EventData>> ReceiveAsync(int maximumMessageCount, TimeSpan? maximumWaitTime, CancellationToken cancellationToken) => Task.FromResult<IReadOnlyList<EventData>>(new List<EventData>(0));
        }
    }
}
