// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Messaging.ServiceBus.Perf.Scenarios
{
    public sealed class SendMessages : ServiceBusPerfTestBase
    {
        private readonly SizeCountOptions _options;

        public SendMessages(SizeCountOptions options) : base(options)
        {
            _options = options;
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            IEnumerable<ServiceBusMessage> messages = Enumerable.Repeat(
                new ServiceBusMessage(MessageBody),
                _options.Count);
            await Sender.SendMessagesAsync(messages, cancellationToken);
        }
    }
}
