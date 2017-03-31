// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Primitives;
    using Xunit;

    public class SenderReceiverTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object> TestPermutations => new object[]
        {
            new object[] { TestConstants.NonPartitionedQueueName },
            new object[] { TestConstants.PartitionedQueueName }
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task MessageReceiverAndMessageSenderCreationWorksAsExpected(string queueName, int messageCount = 10)
        {
            var connection = new ServiceBusNamespaceConnection(TestUtility.NamespaceConnectionString);
            var receiver = connection.CreateMessageReceiver(queueName, ReceiveMode.PeekLock);
            var sender = connection.CreateMessageSender(queueName);

            try
            {
                await this.PeekLockTestCase(sender, receiver, messageCount);
            }
            finally
            {
                await sender.CloseAsync().ConfigureAwait(false);
                await receiver.CloseAsync().ConfigureAwait(false);
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientPeekLockDeferTestCase(string queueName, int messageCount = 10)
        {
            var connection = new ServiceBusNamespaceConnection(TestUtility.NamespaceConnectionString);
            var receiver = connection.CreateMessageReceiver(queueName, ReceiveMode.PeekLock);
            var sender = connection.CreateMessageSender(queueName);

            try
            {
                await
                    this.PeekLockDeferTestCase(sender, receiver, messageCount);
            }
            finally
            {
                await sender.CloseAsync().ConfigureAwait(false);
                await receiver.CloseAsync().ConfigureAwait(false);
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task PeekAsyncTest(string queueName, int messageCount = 10)
        {
            var connection = new ServiceBusNamespaceConnection(TestUtility.NamespaceConnectionString);
            var receiver = connection.CreateMessageReceiver(queueName, ReceiveMode.ReceiveAndDelete);
            var sender = connection.CreateMessageSender(queueName);

            try
            {
                await this.PeekAsyncTestCase(sender, receiver, messageCount);
            }
            finally
            {
                await sender.CloseAsync().ConfigureAwait(false);
                await receiver.CloseAsync().ConfigureAwait(false);
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task ReceiveShouldReturnNoLaterThanServerWaitTimeTest(string queueName, int messageCount = 1)
        {
            var connection = new ServiceBusNamespaceConnection(TestUtility.NamespaceConnectionString);
            var receiver = connection.CreateMessageReceiver(queueName, ReceiveMode.ReceiveAndDelete);
            var sender = connection.CreateMessageSender(queueName);

            try
            {
                await this.ReceiveShouldReturnNoLaterThanServerWaitTimeTestCase(sender, receiver, messageCount);
            }
            finally
            {
                await sender.CloseAsync().ConfigureAwait(false);
                await receiver.CloseAsync().ConfigureAwait(false);
            }
        }
    }
}