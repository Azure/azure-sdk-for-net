using Azure.Core.Net;
using Azure.Core.Net.Pipeline;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Buffers.Text.Encodings;

namespace Azure.Configuration.Test
{
    // TODO (pri 3): Add and Set mocks are the same. Is that ok?
    class AddMockTransport : KeyValueMockTransport
    {
        public AddMockTransport(ConfigurationSetting responseContent)
            : base(HttpMethod.Put, responseContent)
        {
            _expectedUri = "https://contoso.azconfig.io/kv/test_key?label=test_label";
            _expectedRequestContent = "{\"key\":\"test_value\",\"content_type\":\"test_content_type\"}";
        }
    }

    class SetMockTransport : KeyValueMockTransport
    {
        public SetMockTransport(ConfigurationSetting responseContent)
            : base(HttpMethod.Put, responseContent)
        {
            _expectedUri = "https://contoso.azconfig.io/kv/test_key?label=test_label";
            _expectedRequestContent = "{\"key\":\"test_value\",\"content_type\":\"test_content_type\"}";
        }
    }

    class UpdateMockTransport : KeyValueMockTransport
    {
        public UpdateMockTransport(ConfigurationSetting responseContent)
            : base(HttpMethod.Put, responseContent)
        {
            _expectedUri = "https://contoso.azconfig.io/kv/test_key?label=test_label";
            _expectedRequestContent = "{\"key\":\"test_value\",\"content_type\":\"test_content_type\"}";
        }

        protected override void VerifyRequestCore(HttpRequestMessage request)
        {
            Assert.IsTrue(request.Headers.Contains("If-Match"));
        }
    }

    class DeleteMockTransport : KeyValueMockTransport
    {
        public ConfigurationSetting _responseContent;

        public DeleteMockTransport(ConfigurationSetting responseContent)
            : base(HttpMethod.Delete, responseContent)
        {
            _expectedUri = "https://contoso.azconfig.io/kv/test_key?label=test_label";
            _expectedRequestContent = null;
        }
    }

    class GetMockTransport : KeyValueMockTransport
    {
        public GetMockTransport(ConfigurationSetting responseContent)
            : base(HttpMethod.Get, responseContent)
        {
            _expectedMethod = HttpMethod.Get;
            _expectedUri = "https://contoso.azconfig.io/kv/test_key";
        }

        public GetMockTransport(params HttpStatusCode[] statusCodes)
            : base(HttpMethod.Get, null)
        {
            Responses.Clear();
            foreach (var statusCode in statusCodes) {
                Responses.Add(statusCode);
            }
            _expectedMethod = HttpMethod.Get;
            _expectedUri = "https://contoso.azconfig.io/kv/test_key_not_present";
        }
    }

    class LockingMockTransport : KeyValueMockTransport
    {
        public LockingMockTransport(ConfigurationSetting responseContent, bool lockOtherwiseUnlock)
            : base(lockOtherwiseUnlock ? HttpMethod.Put : HttpMethod.Delete, responseContent)
        {
            _expectedUri = "https://contoso.azconfig.io/locks/test_key?label=test_label";
            _expectedRequestContent = null;
        }
    }

    class GetBatchMockTransport : MockHttpClientTransport
    {
        public List<ConfigurationSetting> KeyValues = new List<ConfigurationSetting>();
        public List<(int index, int count)> Batches = new List<(int index, int count)>();
        int _currentBathIndex = 0;

        public GetBatchMockTransport(int numberOfItems)
        {
            _expectedMethod = HttpMethod.Get;
            _expectedUri = null;
            _expectedRequestContent = null;
            for (int i = 0; i < numberOfItems; i++)
            {
                var item = new ConfigurationSetting()
                {
                    Key = $"key{i}",
                    Label = "label",
                    Value = "val",
                    ETag = "c3c231fd-39a0-4cb6-3237-4614474b92c1",
                    ContentType = "text"
                };
                KeyValues.Add(item);
            }
        }

        protected override void WriteResponseCore(HttpResponseMessage response)
        {
            var batch = Batches[_currentBathIndex++];
            var bathItems = new List<ConfigurationSetting>(batch.count);
            int itemIndex = batch.index;
            int count = batch.count;
            while (count-- > 0)
            {
                bathItems.Add(KeyValues[itemIndex++]);
            }
            string json = JsonConvert.SerializeObject(bathItems).ToLowerInvariant();
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            long jsonByteCount = Encoding.UTF8.GetByteCount(json);
            response.Content.Headers.Add("Content-Length", jsonByteCount.ToString());
            if (itemIndex < KeyValues.Count)
            {
                response.Headers.Add("Link", $"</kv?after={itemIndex}>;rel=\"next\"");
            }
        }
    }

    class KeyValueMockTransport : MockHttpClientTransport
    {
        ConfigurationSetting _responseContent;

        public KeyValueMockTransport(HttpMethod expectedMethod, ConfigurationSetting responseContent)
        {
            _expectedMethod = expectedMethod;
            _responseContent = responseContent;
        }

        protected sealed override void WriteResponseCore(HttpResponseMessage response)
        {
            string json = JsonConvert.SerializeObject(_responseContent).ToLowerInvariant();
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            long jsonByteCount = Encoding.UTF8.GetByteCount(json);
            response.Content.Headers.Add("Content-Length", jsonByteCount.ToString());
        }

        protected static ConfigurationSetting CloneKey(ConfigurationSetting original)
        {
            var cloned = new ConfigurationSetting();
            cloned.Key = original.Key;
            cloned.Label = original.Label;
            cloned.Value = original.Value;
            cloned.ETag = original.ETag;
            cloned.ContentType = original.ContentType;
            cloned.LastModified = original.LastModified;
            cloned.Locked = original.Locked;
            foreach (var kvp in original.Tags) {
                cloned.Tags.Add(kvp);
            }
            return cloned;
        }
    }

    abstract class MockHttpClientTransport : HttpClientTransport
    {
        protected HttpMethod _expectedMethod;
        protected string _expectedUri;
        protected string _expectedRequestContent;
        int _nextResponse;

        public List<Response> Responses = new List<Response>();

        protected override Task<HttpResponseMessage> ProcessCoreAsync(CancellationToken cancellation, HttpRequestMessage request)
        {
            VerifyRequestLine(request);
            VerifyRequestContent(request);
            VerifyUserAgentHeader(request);
            VerifyRequestCore(request);
            HttpResponseMessage response = new HttpResponseMessage();
            if (WriteResponse(response))
            {
                WriteResponseCore(response);
            }
            return Task.FromResult(response);
        }

        protected virtual void VerifyRequestCore(HttpRequestMessage request) { }
        protected abstract void WriteResponseCore(HttpResponseMessage response);

        void VerifyRequestLine(HttpRequestMessage request)
        {
            Assert.AreEqual(_expectedMethod, request.Method);
            if(_expectedUri != null) Assert.AreEqual(_expectedUri, request.RequestUri.OriginalString);
            Assert.AreEqual(new Version(2, 0), request.Version);
        }

        void VerifyRequestContent(HttpRequestMessage request)
        {
            if (_expectedRequestContent == null)
            {
                Assert.IsNull(request.Content);
            }
            else
            {
                Assert.NotNull(request.Content);
                var contentString = request.Content.ReadAsStringAsync().Result;
                Assert.AreEqual(_expectedRequestContent, contentString);
            }
        }

        void VerifyUserAgentHeader(HttpRequestMessage request)
        {
            var expected = Utf8.ToString(Header.Common.CreateUserAgent("Azure.Configuration", "1.0.0").Value);

            Assert.True(request.Headers.Contains("User-Agent"));
            var userAgentValues = request.Headers.GetValues("User-Agent");

            foreach (var value in userAgentValues)
            {
                if (expected.StartsWith(value)) return;
            }
            Assert.Fail("could not find User-Agent header value " + expected);
        }

        bool WriteResponse(HttpResponseMessage response)
        {
            if (_nextResponse >= Responses.Count) _nextResponse = 0;
            var mockResponse = Responses[_nextResponse++];
            response.StatusCode = mockResponse.ResponseCode;
            return response.StatusCode == HttpStatusCode.OK;
        }

        public class Response
        {
            public HttpStatusCode ResponseCode;

            public static implicit operator Response(HttpStatusCode status) => new Response() {  ResponseCode = status };
        }
    }
}
