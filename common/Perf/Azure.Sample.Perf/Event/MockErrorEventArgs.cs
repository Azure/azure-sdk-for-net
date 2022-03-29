// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Sample.Perf.Event
{
    public class MockErrorEventArgs
    {
        public int Partition { get; }
        public Exception Exception { get; }

        public MockErrorEventArgs(int partition, Exception exception)
        {
            Partition = partition;
            Exception = exception;
        }
    }
}
