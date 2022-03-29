// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests
{
    public class MessageActionsTests
    {
        [Test]
        public async Task CanCompleteMessagesConcurrently()
        {
            var mockReceiver = new Mock<ServiceBusReceiver>();
            mockReceiver.Setup(r => r.CompleteMessageAsync(It.IsAny<ServiceBusReceivedMessage>(), It.IsAny<CancellationToken>()))
                // simulate completing the message
                .Returns(async() => await Task.Delay(20));
            var actions = new ServiceBusMessageActions(mockReceiver.Object);
            var tasks = new List<Task>();
            for (int i = 0; i < 1000; i++)
            {
                tasks.Add(actions.CompleteMessageAsync(ServiceBusModelFactory.ServiceBusReceivedMessage()));
            }

            await Task.WhenAll(tasks);
        }
    }
}