using Moq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubAsyncCollectorTests
    {
        [Fact]
        public async Task AddAsync_WebPubSubEvent_SendAll()
        {
            var serviceMock = new Mock<IWebPubSubService>();
            var collector = new WebPubSubAsyncCollector(serviceMock.Object);

            var message = "new message";
            await collector.AddAsync(new WebPubSubEvent
            {
                Operation = WebPubSubOperation.SendToAll,
                Message = new WebPubSubMessage(message),
                DataType = MessageDataType.Text
            });

            serviceMock.Verify(c => c.SendToAll(It.IsAny<WebPubSubEvent>()), Times.Once);
            serviceMock.VerifyNoOtherCalls();

            var actualData = (WebPubSubEvent)serviceMock.Invocations[0].Arguments[0];
            Assert.Equal(MessageDataType.Text, actualData.DataType);
            Assert.Equal(message, actualData.Message.ToString());
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
