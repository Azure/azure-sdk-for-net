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
        public GetMockTransport(string queryKey, SettingFilter filter, ConfigurationSetting result)
            : base(HttpMethod.Get, result)
        {
            _expectedMethod = HttpMethod.Get;
            if (filter== null || filter.Label == null) {
                _expectedUri = $"https://contoso.azconfig.io/kv/{queryKey}";
            }
            else {
                _expectedUri = $"https://contoso.azconfig.io/kv/{queryKey}?label={filter.Label}";
            }
        }

        public GetMockTransport(string queryKey, SettingFilter filter, params HttpStatusCode[] statusCodes)
            : this(queryKey, filter, result: null)
        {
            Responses.Clear();
            foreach (var statusCode in statusCodes) {
                Responses.Add(statusCode);
            }
        }

        protected override void WriteResponseCore(HttpResponseMessage response)
        {
            base.WriteResponseCore(response);
            response.Content.Headers.TryAddWithoutValidation("Last-Modified", "Tue, 05 Dec 2017 02:41:26 GMT");
            response.Content.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.microsoft.appconfig.kv+json; charset=utf-8;");
            var etag = _responseContent.ETag.ToString();
            response.Headers.TryAddWithoutValidation("ETag", etag);
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
            _expectedUri = new StringCheck("https://contoso.azconfig.io/kv/?", StringCheck.CheckKind.StartsWith);
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
        protected ConfigurationSetting _responseContent;

        public KeyValueMockTransport(HttpMethod expectedMethod, ConfigurationSetting responseContent)
        {
            _expectedMethod = expectedMethod;
            _responseContent = responseContent;
        }

        protected override void WriteResponseCore(HttpResponseMessage response)
        {
            string json = JsonConvert.SerializeObject(_responseContent).ToLowerInvariant();
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            long jsonByteCount = Encoding.UTF8.GetByteCount(json);
            response.Content.Headers.Add("Content-Length", jsonByteCount.ToString()); // TODO (pri 3): is this actually present?
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

    abstract class MockHttpClientTransport : HttpPipelineTransport
    {
        protected HttpMethod _expectedMethod;
        protected StringCheck _expectedUri;
        protected StringCheck? _expectedRequestContent;
        int _nextResponse;

        public Dictionary<string, StringCheck> Headers = new Dictionary<string, StringCheck>();
        public List<Response> Responses = new List<Response>();

        protected override Task<HttpResponseMessage> ProcessCoreAsync(CancellationToken cancellation, HttpRequestMessage request)
        {
            if (Responses.Count == 0) {
                Responses.Add(HttpStatusCode.NotFound);
                Responses.Add(HttpStatusCode.OK);
            }

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
            _expectedUri.Verify(request.RequestUri.ToString());
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
                _expectedRequestContent.Value.Verify(contentString);
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

        void VerifyHeaders(HttpRequestMessage request)
        {
            foreach(var check in Headers) {
                if(!request.Headers.TryGetValues(check.Key, out var values)){
                    Assert.Fail("header {0} not found", check.Key);
                }
                var list = new List<string>(values);
                if (list.Count > 1) throw new NotImplementedException();

                check.Value.Verify(list[0]);
            }
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

        public struct StringCheck
        {
            CheckKind Kind;
            string Expected;
            Func<string, bool> Custom;

            public StringCheck(string expected, CheckKind check = CheckKind.Equals)
            {
                Expected = expected;
                Kind = check;
                Custom = null;
            }

            public static implicit operator StringCheck(string expected) => new StringCheck(expected);

            public void Verify(string actual)
            {
                switch (Kind) {
                    case CheckKind.Equals:
                        Assert.AreEqual(Expected, actual);
                        break;
                    case CheckKind.StartsWith:
                        Assert.True(actual.StartsWith(Expected));
                        break;
                    case CheckKind.Custom:
                        Assert.True(Custom(actual));
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            public enum CheckKind
            {
                Equals,
                StartsWith,
                Custom
            }
        }
    }
}
