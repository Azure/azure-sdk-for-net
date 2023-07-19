// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor.Perf.Infrastructure;

namespace Azure.Messaging.EventHubs.Processor.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario focused on basic processing of events
    ///   using the <see cref=""/>
    /// </summary>
    ///
    /// <seealso cref="EventPublishPerfTest" />
    ///
    public class ProcessEventTest : ProcessorTest<ProcessorOptions>
    {
        /// <summary>The set of events processed for each partition.</summary>
        private readonly ConcurrentDictionary<string, int> _partitionEventCount;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ProcessEventTest"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public ProcessEventTest(ProcessorOptions options) : base(options)
        {
            if (options.CheckpointInterval.HasValue)
            {
                _partitionEventCount = new ConcurrentDictionary<string, int>();
            }
        }

        /// <summary>
        ///   Performs the tasks needed to simulate the processing of events.
        /// </summary>
        ///
        /// <param name="args">The <see cref="ProcessEventArgs"/> instance containing the event information..</param>
        ///
        private async Task ProcessEventAsync(ProcessEventArgs args)
        {
            if (args.HasEvent)
            {
                if (Options.ProcessingDelayMs.HasValue)
                {
                    if (Options.ProcessingDelayStrategy == ProcessingDelayStrategy.Sleep)
                    {
                        Thread.Sleep(Options.ProcessingDelayMs.Value);
                    }
                    else if (Options.ProcessingDelayStrategy == ProcessingDelayStrategy.Spin)
                    {
                        var sw = Stopwatch.StartNew();
                        while (sw.ElapsedMilliseconds < Options.ProcessingDelayMs.Value)
                        {
                        }
                    }
                }

                // Consume properties

                foreach (var property in args.Data.Properties)
                {
                    var key = property.Key;
                    var value = property.Value;
                }

                // Consume body

                await args.Data.EventBody.ToStream().CopyToAsync(Stream.Null);

                if (Options.CheckpointInterval.HasValue)
                {
                    var partition = args.Partition.PartitionId;
                    var eventsSinceLastCheckpoint = _partitionEventCount.AddOrUpdate(
                        key: partition,
                        addValue: 1,
                        updateValueFactory: (_, currentCount) => currentCount + 1);

                    if (eventsSinceLastCheckpoint >= Options.CheckpointInterval.Value)
                    {
                        await args.UpdateCheckpointAsync();
                        _partitionEventCount[partition] = 0;
                    }
                }

                // EventPerfTest.EventRaised() should never throw either, but add a guard in case this changes

                try
                {
                    EventRaised();
                }
                catch (Exception e)
                {
                    ErrorRaised(e);
                }
            }
        }

        /// <summary>
        ///  Performs the tasks needed to report an error observed as part of the
        ///  processor's operation.
        /// </summary>
        ///
        /// <param name="arg">The <see cref="ProcessErrorEventArgs"/> instance containing the error information.</param>
        ///
        private Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            ErrorRaised(arg.Exception);
            return Task.CompletedTask;
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

            EventProcessorClient.ProcessEventAsync += ProcessEventAsync;
            EventProcessorClient.ProcessErrorAsync += ProcessErrorAsync;

            await EventProcessorClient.StartProcessingAsync();
        }

        /// <summary>
        ///   Performs the tasks needed to initialize and set up the environment for the test scenario.
        ///   This setup will take place once for each instance, running before the global cleanup is
        ///   run.
        /// </summary>
        ///
        public override async Task CleanupAsync()
        {
            await EventProcessorClient.StopProcessingAsync();

            EventProcessorClient.ProcessEventAsync -= ProcessEventAsync;
            EventProcessorClient.ProcessErrorAsync -= ProcessErrorAsync;

            await base.CleanupAsync();
        }
    }
}
