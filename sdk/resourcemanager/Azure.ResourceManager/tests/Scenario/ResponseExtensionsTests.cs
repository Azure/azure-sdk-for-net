using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ResponseExtensionsTests : ResourceManagerTestBase
    {
        public ResponseExtensionsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetCorrelationId()
        {
            var correlationId = "0a98bb8b-ec3e-4f68-a8c1-a7705554a980";
            var pipeline = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).Pipeline;
            var endpoint = new Uri("https://management.azure.com");
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(TestEnvironment.SubscriptionId, true);
            uri.AppendQuery("api-version", "2019-11-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("x-ms-correlation-request-id", correlationId);

            await pipeline.SendAsync(message, default).ConfigureAwait(false);
            var response = message.Response;
            Assert.AreEqual(correlationId, response.GetCorrelationId());
        }
    }
}
