// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Sample.Perf.Batch
{
    public class MockReceiver
    {
        private readonly Random _random = new Random();

        public Task<IEnumerable<int>> ReceiveAsync(int minMessageCount, int maxMessageCount)
        {
            return Task.FromResult(Receive(minMessageCount, maxMessageCount));
        }

        public IEnumerable<int> Receive(int minMessageCount, int maxMessageCount)
        {
            var returnedMessages = _random.Next(minMessageCount, maxMessageCount + 1);

            var messages = new string[returnedMessages];
            for (var i = 0; i < returnedMessages; i++)
            {
                yield return i;
            }
        }
    }
}
