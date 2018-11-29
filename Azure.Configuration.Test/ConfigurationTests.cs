using Azure.Core.Net;
using Azure.Core.Net.Pipeline;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Configuration.Tests
{
    public class ConfigurationServiceTests
    {
        static readonly KeyValue s_testKey = new KeyValue() {
            Key = "test",
            Label = "test",
            Value = "test_now",
            ETag = "c3c231fd-39a0-4cb6-3237-4614474b92c6",
            ContentType = "text",
            LastModified = new DateTimeOffset(2018, 11, 28, 9, 55, 0, 0, default),
            Locked = false
        };

        [Test]
        public async Task SetKeyValue()
        {
            string connectionString = "Endpoint=https://contoso.azconfig.io;Id=b1d9b31;Secret=aabbccdd";
            ConfigurationService.ParseConnectionString(connectionString, out var uri, out var credential, out var secret);

            var transport = new SetKeyValueMockTransport();
            transport.KeyValue = s_testKey;

            var pipeline = new ServicePipeline(transport, new RetryPolicy());

            var service = new ConfigurationService(uri, credential, secret, pipeline);
            Response<KeyValue> added = await service.SetKeyValueAsync(s_testKey, CancellationToken.None);

            Assert.AreEqual(s_testKey.Key, added.Result.Key);
            Assert.AreEqual(s_testKey.Label, added.Result.Label);
            Assert.AreEqual(s_testKey.ContentType, added.Result.ContentType);
            Assert.AreEqual(s_testKey.Locked, added.Result.Locked);
        }

        [Test]
        public async Task GetKeyValue()
        {
            string connectionString = "Endpoint=https://contoso.azconfig.io;Id=b1d9b31;Secret=aabbccdd";
            ConfigurationService.ParseConnectionString(connectionString, out var uri, out var credential, out var secret);

            var transport = new GetKeyValueMockTransport();
            transport.KeyValue = s_testKey;

            var pipeline = new ServicePipeline(transport, new RetryPolicy());

            var service = new ConfigurationService(uri, credential, secret, pipeline);
            Response<KeyValue> added = await service.GetKeyValueAsync("test", default, CancellationToken.None);

            Assert.AreEqual(s_testKey.Key, added.Result.Key);
            Assert.AreEqual(s_testKey.Label, added.Result.Label);
            Assert.AreEqual(s_testKey.ContentType, added.Result.ContentType);
            Assert.AreEqual(s_testKey.Locked, added.Result.Locked);
        }
    }

    class SetKeyValueMockTransport : HttpClientTransport
    {
        public KeyValue KeyValue;

        protected override Task<HttpResponseMessage> ProcessCoreAsync(CancellationToken cancellation, HttpRequestMessage request)
        {
            Assert.AreEqual(HttpMethod.Put, request.Method);

            HttpResponseMessage response = new HttpResponseMessage();
            if (request.RequestUri.AbsolutePath.StartsWith($"/kv/{KeyValue.Key}")) {
                response.StatusCode = HttpStatusCode.OK;
                string json = JsonConvert.SerializeObject(KeyValue).ToLowerInvariant();
                long jsonBytes = Encoding.UTF8.GetByteCount(json);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                response.Content.Headers.Add("Content-Length", jsonBytes.ToString());
            }

            return Task.FromResult(response);
        }
    }

    class GetKeyValueMockTransport : HttpClientTransport
    {
        public KeyValue KeyValue;

        protected override Task<HttpResponseMessage> ProcessCoreAsync(CancellationToken cancellation, HttpRequestMessage request)
        {
            Assert.AreEqual(HttpMethod.Get, request.Method);

            HttpResponseMessage response = new HttpResponseMessage();
            if (request.RequestUri.AbsolutePath.StartsWith($"/kv/{KeyValue.Key}")) {
                response.StatusCode = HttpStatusCode.OK;
                string json = JsonConvert.SerializeObject(KeyValue).ToLowerInvariant();
                long jsonBytes = Encoding.UTF8.GetByteCount(json);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                response.Content.Headers.Add("Content-Length", jsonBytes.ToString());
            }
            else {
                response.StatusCode = HttpStatusCode.NotFound;
            }

            return Task.FromResult(response);
        }
    }
}
