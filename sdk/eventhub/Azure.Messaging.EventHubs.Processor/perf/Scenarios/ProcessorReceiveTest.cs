// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        private Task ProcessEventAsync(ProcessEventArgs arg)
        {
            try
            {
                EventRaised();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
            return Task.CompletedTask;
        }

        private Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            throw arg.Exception;
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
