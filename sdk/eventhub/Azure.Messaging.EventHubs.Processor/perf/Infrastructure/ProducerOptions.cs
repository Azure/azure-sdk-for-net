// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Messaging.EventHubs.Processor.Perf.Infrastructure
{
    public class ProducerOptions : SizeOptions
    {
        [Option("delayMilliseconds", HelpText = "Adds delay after each message sent (for debugging)")]
        public int DelayMilliseconds { get; set; }

        [Option("messagesPerBatch", Default = 1)]
        public int MessagesPerBatch { get; set; }

        [Option("propertyCount", Default = 5, HelpText = "Number of properties")]
        public int PropertyCount { get; set; }

        [Option("propertySize", Default = 50, HelpText = "Size of each property (in characters)")]
        public int PropertySize { get; set; }
    }
}
