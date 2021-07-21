// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubAsyncCollectorTests
    {
        [TestCase]
        public async Task AddAsync_WebPubSubEvent_SendAll()
        {
            var serviceMock = new Mock<IWebPubSubService>();
            var collector = new WebPubSubAsyncCollector(serviceMock.Object);

            var message = "new message";
            await collector.AddAsync(new SendToAll
            {
                Message = BinaryData.FromString(message),
                DataType = MessageDataType.Text
            });

            serviceMock.Verify(c => c.SendToAll(It.IsAny<SendToAll>()), Times.Once);
            serviceMock.VerifyNoOtherCalls();

            var actualData = (SendToAll)serviceMock.Invocations[0].Arguments[0];
            Assert.AreEqual(MessageDataType.Text, actualData.DataType);
            Assert.AreEqual(message, actualData.Message.ToString());
        }

        //[Fact]
        //public async Task AddAsync_WebPubSubEvent_SendAll()
        //{
        //    var serviceMock = new Mock<IWebPubSubService>();
        //    var collector = new WebPubSubAsyncCollector(serviceMock.Object, "testhub");
        //
        //    var payload = Encoding.UTF8.GetBytes("new message");
        //    await collector.AddAsync(new WebPubSubEvent
        //    {
        //        Operation = WebPubSubOperation.SendToAll,
        //        Message = new MemoryStream(payload),
        //        DataType = MessageDataType.Text
        //    });
        //
        //    serviceMock.Verify(c => c.SendToAll(It.IsAny<WebPubSubEvent>()), Times.Once);
        //    serviceMock.VerifyNoOtherCalls();
        //
        //    var actualData = (WebPubSubEvent)serviceMock.Invocations[0].Arguments[0];
        //    Assert.Equal(MessageDataType.Text, actualData.DataType);
        //    byte[] message = null;
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        actualData.Message.CopyTo(memoryStream);
        //        message = memoryStream.ToArray();
        //    }
        //    Assert.Equal(payload, message);
        //}
    }
}
