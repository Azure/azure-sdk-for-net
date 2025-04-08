// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class MockProcessor : IProcessor<Func<Task>>
    {
        public int MaxConcurrentProcessing { get; set; }
        ProcessAsync<Func<Task>> IProcessor<Func<Task>>.Process { get; set; }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public Task ProcessAsync(Func<Task> item, CancellationToken cancellationToken)
        {
            return item();
        }

        public ValueTask QueueAsync(Func<Task> item, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public bool TryComplete()
        {
            throw new NotImplementedException();
        }
    }
}
