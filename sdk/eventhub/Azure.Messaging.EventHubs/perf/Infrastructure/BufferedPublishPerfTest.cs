// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Azure.Test.Perf;

namespace Azure.Messaging.EventHubs.Perf
{
    /// <summary>
    ///   The performance test scenario focused on publishing sets of events
    ///   without a batch.
    /// </summary>
    ///
    /// <seealso cref="EventHubsPerfTest" />
    ///
    public abstract class BufferedPublishPerfTest<TOptions> : EventPerfTest<TOptions> where TOptions : EventHubsBufferedOptions
    {
        /// <summary>The buffered producer instance for publishing events.</summary>
        private EventHubBufferedProducerClient _producer;

        /// <summary>The cancellation source that can be used to control background tasks.</summary>
        private CancellationTokenSource _backgroundCancellationSource;

        /// <summary>The background task responsible for enqueuing events into the buffer.</summary>
        private Task _backgroundBufferingTask;

        /// <summary>
        ///   The active <see cref="EventHubsTestEnvironment" /> instance for the
        ///   performance test scenarios.
        /// </summary>
        ///
        protected EventHubsTestEnvironment TestEnvironment => EventHubsTestEnvironment.Instance;

        /// <summary>
        ///   The Event Hub to publish events to for this test instance.
        /// </summary>
        ///
        protected EventHubScope Scope { get; private set; }

        /// <summary>
        ///   The set of available partitions for the Event Hub.
        /// </summary>
        ///
        protected string[] Partitions { get; private set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BufferedPublishPerfTest"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public BufferedPublishPerfTest(TOptions options) : base(options)
        {
        }

        /// <summary>
        ///   Performs the tasks needed to initialize and set up the environment for the test scenario.
        ///   This setup will take place once for each instance, running after the global setup has
        ///   completed.
        /// </summary>
        ///
        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            Scope = await EventHubScope.CreateAsync(Options.PartitionCount).ConfigureAwait(false);

            var producerOptions = new EventHubBufferedProducerClientOptions
            {
                MaximumWaitTime = (Options.MaximumWaitTimeMilliseconds.HasValue) ? TimeSpan.FromMilliseconds(Options.MaximumWaitTimeMilliseconds.Value) : null,
                MaximumEventBufferLengthPerPartition = Options.MaximumBufferLength,
                MaximumConcurrentSendsPerPartition = Options.MaximumConcurrentSendsPerPartition
            };

            if (Options.MaximumConcurrentSends.HasValue)
            {
                producerOptions.MaximumConcurrentSends = Options.MaximumConcurrentSends.Value;
            }

            _producer = new EventHubBufferedProducerClient(TestEnvironment.EventHubsConnectionString, Scope.EventHubName, producerOptions);

            // Create the handlers that call into the performance test infrastructure to
            // report when errors and events are observed.

            _producer.SendEventBatchFailedAsync += args =>
            {
                // Do not flag cancellation as a failure; it is expected for in-flight batches when
                // the test run is cleaning up.

                if (!typeof(OperationCanceledException).IsAssignableFrom(args.Exception.GetType()))
                {
                    ErrorRaised(args.Exception);
                }

                return Task.CompletedTask;
            };

            _producer.SendEventBatchSucceededAsync += args =>
            {
                for (var index = 0; index < args.EventBatch.Count; ++index)
                {
                    EventRaised();
                }

                return Task.CompletedTask;
            };

            // Initialize the set of available partitions and start the background publishing task.

            Partitions = await _producer.GetPartitionIdsAsync().ConfigureAwait(false);

            _backgroundCancellationSource = new CancellationTokenSource();
            _backgroundBufferingTask = EnqueueEvents(_backgroundCancellationSource.Token);
        }

        /// <summary>
        ///   Performs the tasks needed to initialize and set up the environment for the test scenario.
        ///   This setup will take place once for each instance, running before the global cleanup is
        ///   run.
        /// </summary>
        ///

        public override async Task CleanupAsync()
        {
            // Close without flushing; by this point all expected events were sent.

            _backgroundCancellationSource?.Cancel();

            try
            {
                if (_backgroundBufferingTask != null)
                {
                    try
                    {
                        await _backgroundBufferingTask.ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        // Expected
                    }
                }

                if (_producer != null)
                {
                    try
                    {
                        await _producer.CloseAsync(false).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        // Expected
                    }
                }
            }
            finally
            {
                if (Scope != null)
                {
                    await Scope.DisposeAsync().ConfigureAwait(false);
                }
            }

            await base.CleanupAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///   Releases unmanaged resources and, optionally, managed resources.
        /// </summary>
        ///
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        ///
        public override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _backgroundCancellationSource.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        ///   Enqueues events into the buffer to be published.
        /// </summary>
        ///
        /// <param name="testOptions">The set of options governing test execution.</param>
        ///
        private async Task EnqueueEvents(CancellationToken cancellationToken)
        {
            var eventBody = EventGenerator.CreateRandomBody(Options.BodySize);

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var enqueueOptions = CreateEnqueueOptions();

                    // Generate events using the same body.  This will result in publishing a set of events
                    // of equal size. The events will only differ by the id property that is assigned to them.

                    if (Options.BatchSize > 1)
                    {
                        await _producer.EnqueueEventsAsync(EventGenerator.CreateEventsFromBody(Options.BatchSize, eventBody), enqueueOptions, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        await _producer.EnqueueEventAsync(EventGenerator.CreateEventFromBody(eventBody), enqueueOptions, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Expected
            }
            catch (EventHubsException ex) when ((cancellationToken.IsCancellationRequested) && (ex.IsTransient))
            {
                // If the enqueue is canceled during a retry loop, the most recent exception is thrown.
                // If the exception is transient, it should be ignored.
            }
            catch (Exception ex)
            {
                ErrorRaised(ex);
            }
        }

        /// <summary>
        ///   Determines the set of <see cref="EnqueueEventOptions"/> needed for this test scenario.
        /// </summary>
        ///
        /// <returns>The set of options to use when enqueuing events to be published.</returns>
        ///
        /// <remarks>
        ///     This method is expected to be called each time that a set of events
        ///     is to be enqueued; it should be kept light and fast.
        /// </remarks>
        ///
        protected abstract EnqueueEventOptions CreateEnqueueOptions();
    }
}
