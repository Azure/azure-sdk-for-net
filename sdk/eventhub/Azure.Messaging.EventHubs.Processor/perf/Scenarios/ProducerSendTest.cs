// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor.Perf.Infrastructure;

namespace Azure.Messaging.EventHubs.Processor.Perf.Scenarios
{
    public class ProducerSendTest : ProducerTest<ProducerOptions>
    {
        public ProducerSendTest(ProducerOptions options) : base(options)
        {
        }

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            return EventHubProducerClient.SendAsync(CreateEvents());
        }
    }
}
