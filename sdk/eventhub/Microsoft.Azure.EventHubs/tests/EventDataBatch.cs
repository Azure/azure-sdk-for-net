using Xunit;
using Microsoft.Azure.EventHubs;

namespace Microsoft.Azure.EventHubs.Tests
{
    public class TestEventDataBatch
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public void TryAdd()
        {
            var eventBatch = new EventDataBatch(2_000);
            Assert.True(eventBatch.TryAdd(new EventData(new byte[1_000])));
            Assert.True(eventBatch.TryAdd(new EventData(new byte[900]))); // There is some overhead.
            Assert.False(eventBatch.TryAdd(new EventData(new byte[1_00])));
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public void TryAddExceedingMaxSize()
        {
            var eventBatch = new EventDataBatch(1_000);
            Assert.False(eventBatch.TryAdd(new EventData(new byte[2_000])));
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public void TryAddNoExplicitMaxSize()
        {
            var connStr = "Endpoint=sb://mynamespace.servicebus.windows.net/;SharedAccessKeyName=keyname;SharedAccessKey=key;EntityPath=test";
            var client = EventHubClient.CreateFromConnectionString(connStr);
            var batch = client.CreateBatch();
            // First event is always accepted when no explicit max size is given.
            Assert.True(batch.TryAdd(new EventData(new byte[1024 * 1024])));
            Assert.False(batch.TryAdd(new EventData(new byte[0])));
        }

    }
}