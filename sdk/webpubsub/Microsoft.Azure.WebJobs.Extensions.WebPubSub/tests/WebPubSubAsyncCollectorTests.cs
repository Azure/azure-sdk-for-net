// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Messaging.WebPubSub;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubAsyncCollectorTests
    {
        [TestCase]
        public async Task AddAsync_WebPubSubEvent_SendAll()
        {
            var mockClient = new Mock<WebPubSubServiceClient>();
            var service = new WebPubSubService(mockClient.Object);
            var collector = new WebPubSubAsyncCollector(service);

            var message = "new message";
            await collector.AddAsync(new SendToAll
            {
                Message = BinaryData.FromString(message),
                DataType = MessageDataType.Text
            });

            mockClient.Verify(c => c.SendToAllAsync(It.IsAny<RequestContent>(), It.IsAny<string>(), null, It.IsAny<CancellationToken>()), Times.Once);
            mockClient.VerifyNoOtherCalls();

            mockClient.VerifyAll();
        }
    }
}
