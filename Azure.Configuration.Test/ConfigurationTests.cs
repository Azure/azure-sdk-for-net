using Azure.Core.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Configuration.Test;

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

            var service = new ConfigurationService(uri, credential, secret);
            service.Pipeline.Transport = transport;

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

            var service = new ConfigurationService(uri, credential, secret);
            service.Pipeline.Transport = transport;

            Response<KeyValue> added = await service.GetKeyValueAsync("test", default, CancellationToken.None);

            Assert.AreEqual(s_testKey.Key, added.Result.Key);
            Assert.AreEqual(s_testKey.Label, added.Result.Label);
            Assert.AreEqual(s_testKey.ContentType, added.Result.ContentType);
            Assert.AreEqual(s_testKey.Locked, added.Result.Locked);
        }
    }

    class SetKeyValueMockTransport : MockHttpClientTransport
    {
        public KeyValue KeyValue;

        public SetKeyValueMockTransport()
        {
            _expectedMethod = HttpMethod.Put;
            _expectedUri = "https://contoso.azconfig.io/kv/test?label=test";
            _expectedContent = "{\"key\":\"test_now\",\"content_type\":\"text\"}";
            _responseCode = HttpStatusCode.OK;
        }

        protected override void WriteResponseCore(HttpResponseMessage response)
        {
            string json = JsonConvert.SerializeObject(KeyValue).ToLowerInvariant();
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            long jsonByteCount = Encoding.UTF8.GetByteCount(json);
            response.Content.Headers.Add("Content-Length", jsonByteCount.ToString());
        }
    }

    class GetKeyValueMockTransport : MockHttpClientTransport
    {
        public KeyValue KeyValue;

        public GetKeyValueMockTransport()
        {
            _expectedMethod = HttpMethod.Get;
            _expectedUri = "https://contoso.azconfig.io/kv/test";
            _expectedContent = null;
            _responseCode = HttpStatusCode.OK;
        }

        protected override void WriteResponseCore(HttpResponseMessage response)
        {
            string json = JsonConvert.SerializeObject(KeyValue).ToLowerInvariant();
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            long jsonByteCount = Encoding.UTF8.GetByteCount(json);
            response.Content.Headers.Add("Content-Length", jsonByteCount.ToString());
        }
    }
}
