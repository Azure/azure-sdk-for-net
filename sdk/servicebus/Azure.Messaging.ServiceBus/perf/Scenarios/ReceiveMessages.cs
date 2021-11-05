// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Messaging.ServiceBus.Perf.Scenarios
{
    public sealed class ReceiveMessages : ServiceBusPerfTestBase
    {
        private readonly SizeCountOptions _options;

        public ReceiveMessages(SizeCountOptions options) : base(options)
        {
            _options = options;
        }

        public override async Task SetupAsync()
        {
            await base.SeedMessagesAsync();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            int remaining = _options.Count;
            while (remaining > 0)
            {
                IReadOnlyList<ServiceBusReceivedMessage> messages = await Receiver.ReceiveMessagesAsync(
                    remaining,
                    cancellationToken: cancellationToken);
                remaining -= messages.Count;
            }
        }
    }
}
