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
        private static readonly Mock<WebPubSubServiceClient> _service = new();
        private static readonly WebPubSubAsyncCollector _collector = new(new WebPubSubService(_service.Object));

        [Test]
        public void NullServiceThrows()
        {
            Assert.Throws<ArgumentNullException>(() => new WebPubSubAsyncCollector(null));
        }

        [Test]
        public void NullWebPubSubActionThrows()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _collector.AddAsync(null));
        }

        [Test]
        public async Task SendWebPubSubAction()
        {
            await _collector.AddAsync(WebPubSubAction.CreateSendToAllAction("Hello World!"));
            _service.Verify(x => x.SendToAllAsync(It.IsAny<RequestContent>(), It.IsAny<ContentType>(), null, It.Is<RequestContext>(x => x.CancellationToken == default)), Times.Once);
        }

        [Test]
        public async Task TestWebPubSubActionUserCts()
        {
            using var cts = new CancellationTokenSource(1000);

            await _collector.AddAsync(WebPubSubAction.CreateSendToAllAction("Hello World!"), cts.Token);
            _service.Verify(x => x.SendToAllAsync(It.IsAny<RequestContent>(), It.IsAny<ContentType>(), null, It.Is<RequestContext>(x => x.CancellationToken == cts.Token)), Times.Once);
        }
    }
}
