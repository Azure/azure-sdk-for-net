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
    public class ProcessEventTest : ProcessorTest<ProcessorOptions>
    {
        private readonly ConcurrentDictionary<string, int> _partitionEventCount;

        public ProcessEventTest(ProcessorOptions options) : base(options)
        {
            EventProcessorClient.ProcessEventAsync += ProcessEventAsync;
            EventProcessorClient.ProcessErrorAsync += ProcessErrorAsync;

            if (options.CheckpointInterval.HasValue)
            {
                _partitionEventCount = new ConcurrentDictionary<string, int>();
            }
        }

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

        private Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            ErrorRaised(arg.Exception);
            return Task.CompletedTask;
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            await EventProcessorClient.StartProcessingAsync();
        }

        public override async Task CleanupAsync()
        {
            await EventProcessorClient.StopProcessingAsync();
            await base.CleanupAsync();
        }
    }
}
