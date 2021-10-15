// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf.Batch
{
    public class MockReceiverTest : BatchPerfTest<MockReceiverTest.MockReceiverOptions>
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

        public class MockReceiverOptions : PerfOptions
        {
            [Option("max-message-count", Default = 10)]
            public int MaxMessageCount { get; set; }

            [Option("min-message-count", Default = 0)]
            public int MinMessageCount { get; set; }
        }

        private class MockReceiver
        {
            public Task<IEnumerable<int>> ReceiveAsync(int minMessageCount, int maxMessageCount)
            {
                return Task.FromResult(Receive(minMessageCount, maxMessageCount));
            }

            public IEnumerable<int> Receive(int minMessageCount, int maxMessageCount)
            {
                var returnedMessages = ThreadsafeRandom.Next(minMessageCount, maxMessageCount + 1);

                for (var i = 0; i < returnedMessages; i++)
                {
                    yield return i;
                }
            }
        }
    }
}
