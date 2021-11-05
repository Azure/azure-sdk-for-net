// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Messaging.ServiceBus.Perf.Scenarios
{
    public sealed class AcceptNextSession : ServiceBusPerfTestBase
    {
        public AcceptNextSession(SizeCountOptions options) : base(options, useSessions: true)
        {
        }

        public override async Task SetupAsync()
        {
            await SeedMessagesAsync();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Client.AcceptNextSessionAsync(QueueScope.QueueName, cancellationToken: cancellationToken);
        }
    }
}
