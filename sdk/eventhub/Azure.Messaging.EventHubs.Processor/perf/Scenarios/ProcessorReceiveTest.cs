// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor.Perf.Infrastructure;

namespace Azure.Messaging.EventHubs.Processor.Perf.Scenarios
{
    public class ProcessorReceiveTest : ProcessorTest<ProcessorOptions>
    {
        public ProcessorReceiveTest(ProcessorOptions options) : base(options)
        {
            EventProcessorClient.ProcessEventAsync += ProcessEventAsync;
            EventProcessorClient.ProcessErrorAsync += ProcessErrorAsync;
        }

        private async Task ProcessEventAsync(ProcessEventArgs arg)
        {
            if (arg.HasEvent)
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
                foreach (var property in arg.Data.Properties)
                {
                    var key = property.Key;
                    var value = property.Value;
                }

                // Consume body
                await arg.Data.EventBody.ToStream().CopyToAsync(Stream.Null);

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
