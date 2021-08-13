// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf.Batch
{
    public class MockReceiverTest : BatchPerfTest<MockReceiverOptions>
    {
        private readonly MockReceiver _mockReceiver;

        public MockReceiverTest(MockReceiverOptions options) : base(options)
        {
            _mockReceiver = new MockReceiver();
        }

        public override int RunBatch(CancellationToken cancellationToken)
        {
            var messages = _mockReceiver.Receive(Options.MinMessageCount, Options.MaxMessageCount);
            return messages.Count();
        }

        public override async Task<int> RunBatchAsync(CancellationToken cancellationToken)
        {
            var messages = await _mockReceiver.ReceiveAsync(Options.MinMessageCount, Options.MaxMessageCount);
            return messages.Count();
        }
    }
}
