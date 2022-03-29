// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Sample.Perf.Event
{
    public class MockEventArgs
    {
        public int Partition { get; }
        public string Data { get; }

        public MockEventArgs(int partition, string data)
        {
            Partition = partition;
            Data = data;
        }
    }
}
