// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Specialized;

namespace Azure.Storage.Queues.Tests
{
    internal class MockMissingClientSideEncryptionKeyListener : IMissingClientSideEncryptionKeyListener
    {
        public int TimesInvoked { get; private set; } = 0;

        public void OnMissingKey(QueueMessage message)
        {
            TimesInvoked++;
        }

        public void OnMissingKey(PeekedMessage message)
        {
            TimesInvoked++;
        }

        public Task OnMissingKeyAsync(QueueMessage message)
        {
            TimesInvoked++;
            return Task.CompletedTask;
        }

        public Task OnMissingKeyAsync(PeekedMessage message)
        {
            TimesInvoked++;
            return Task.CompletedTask;
        }
    }
}
