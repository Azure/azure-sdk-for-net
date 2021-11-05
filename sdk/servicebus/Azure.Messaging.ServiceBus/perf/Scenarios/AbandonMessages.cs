// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Messaging.ServiceBus.Perf.Scenarios
{
    public sealed class AbandonMessages : SettleMessagesBase
    {
        public AbandonMessages(SizeCountOptions options) : base(options)
        {
        }

        protected override async Task SettleAsync(ServiceBusReceivedMessage message, CancellationToken cancellationToken)
        {
            await Receiver.AbandonMessageAsync(message, cancellationToken: cancellationToken);
        }
    }
}
