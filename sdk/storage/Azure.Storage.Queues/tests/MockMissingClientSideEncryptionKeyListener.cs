// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Queues.Tests
{
    internal class MockMissingClientSideEncryptionKeyListener : IClientSideDecryptionFailureListener
    {
        public int TimesInvoked { get; private set; } = 0;

        public void OnFailure(QueueMessage message, Exception e)
        {
            Assert.IsNotNull(e);
            TimesInvoked++;
        }

        public void OnFailure(PeekedMessage message, Exception e)
        {
            Assert.IsNotNull(e);
            TimesInvoked++;
        }

        public Task OnFailureAsync(QueueMessage message, Exception e)
        {
            Assert.IsNotNull(e);
            TimesInvoked++;
            return Task.CompletedTask;
        }

        public Task OnFailureAsync(PeekedMessage message, Exception e)
        {
            Assert.IsNotNull(e);
            TimesInvoked++;
            return Task.CompletedTask;
        }
    }
}
