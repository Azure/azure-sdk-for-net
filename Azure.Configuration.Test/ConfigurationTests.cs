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
using System.Linq;
using static System.Buffers.Text.Encodings;

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

    abstract class MockHttpClientTransport: HttpClientTransport
    {
        protected static void VerifyUserAgentHeader(HttpRequestMessage request)
        {
            var expected = Utf8.ToString(Header.Common.CreateUserAgent("Azure-Configuration", "1.0.0").Value);

            Assert.True(request.Headers.Contains("User-Agent"));
            var userAgentValues = request.Headers.GetValues("User-Agent");

            foreach(var value in userAgentValues)
            {
                if (expected.StartsWith(value)) return;
            }
            Assert.Fail("could not find User-Agent header value " + expected);
        }
    }

    class SetKeyValueMockTransport : MockHttpClientTransport
    {
        public KeyValue KeyValue;

        protected override Task<HttpResponseMessage> ProcessCoreAsync(CancellationToken cancellation, HttpRequestMessage request)
        {
            Assert.AreEqual(HttpMethod.Put, request.Method);
            VerifyUserAgentHeader(request);

            HttpResponseMessage response = new HttpResponseMessage();
            if (request.RequestUri.AbsolutePath.StartsWith($"/kv/{KeyValue.Key}"))
            {
                response.StatusCode = HttpStatusCode.OK;
                string json = JsonConvert.SerializeObject(KeyValue).ToLowerInvariant();
                long jsonBytes = Encoding.UTF8.GetByteCount(json);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                response.Content.Headers.Add("Content-Length", jsonBytes.ToString());
            }

            return Task.FromResult(response);
        }
    }

    class GetKeyValueMockTransport : MockHttpClientTransport
    {
        public KeyValue KeyValue;

        protected override Task<HttpResponseMessage> ProcessCoreAsync(CancellationToken cancellation, HttpRequestMessage request)
        {
            Assert.AreEqual(HttpMethod.Get, request.Method);
            VerifyUserAgentHeader(request);

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
