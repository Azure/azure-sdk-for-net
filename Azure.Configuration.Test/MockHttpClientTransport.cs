// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Http;
using Azure.Core.Http.Pipeline;
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

namespace Azure.ApplicationModel.Configuration.Test
{
    // TODO (pri 3): Add and Set mocks are the same. Is that ok?
    class AddMockTransport : MockHttpClientTransport
    {
        public AddMockTransport(ConfigurationSetting responseContent)
        {
            _expectedUri = $"https://contoso.azconfig.io/kv/{responseContent.Key}{GetExtraUriParameters(responseContent)}";
            _expectedMethod = HttpMethod.Put;
            _expectedRequestContent = GenerateExpectedRequestContent(responseContent);

            string json = JsonConvert.SerializeObject(responseContent).ToLowerInvariant();
            json = json.Replace("contenttype", "content_type");
            _responseContent = json.Replace("lastmodified", "last_modified");
        }
    }

    class SetMockTransport : MockHttpClientTransport
    {
        public SetMockTransport(ConfigurationSetting responseContent)
        {
            _expectedUri = $"https://contoso.azconfig.io/kv/{responseContent.Key}{GetExtraUriParameters(responseContent)}";
            _expectedMethod = HttpMethod.Put;
            _expectedRequestContent = GenerateExpectedRequestContent(responseContent);

            string json = JsonConvert.SerializeObject(responseContent).ToLowerInvariant();
            json = json.Replace("contenttype", "content_type");
            _responseContent = json.Replace("lastmodified", "last_modified");
        }
    }

    class UpdateMockTransport : MockHttpClientTransport
    {
        public UpdateMockTransport(ConfigurationSetting responseContent)
        {
            _expectedUri = $"https://contoso.azconfig.io/kv/{responseContent.Key}{GetExtraUriParameters(responseContent)}";
            _expectedMethod = HttpMethod.Put;
            _expectedRequestContent = GenerateExpectedRequestContent(responseContent);

            string json = JsonConvert.SerializeObject(responseContent).ToLowerInvariant();
            json = json.Replace("contenttype", "content_type");
            _responseContent = json.Replace("lastmodified", "last_modified");
        }

        protected override void VerifyRequestCore(HttpRequestMessage request)
        {
            Assert.IsTrue(request.Headers.Contains("If-Match"));
        }
    }

    class DeleteMockTransport : MockHttpClientTransport
    {
        public DeleteMockTransport(string key, RequestOptions filter, ConfigurationSetting result)
        {
            _expectedUri = $"https://contoso.azconfig.io/kv/{key}{GetExtraUriParameters(filter)}";
            _expectedRequestContent = null;
            _expectedMethod = HttpMethod.Delete;

            string json = JsonConvert.SerializeObject(result).ToLowerInvariant();
            json = json.Replace("contenttype", "content_type");
            _responseContent = json.Replace("lastmodified", "last_modified");
        }

        public DeleteMockTransport(string key, RequestOptions filter, HttpStatusCode statusCode)
            : this(key, filter, result: null)
        {
            Responses.Clear();
            Responses.Add(statusCode);
        }
    }

    // TODO (pri 3): this should emit the etag response header
    class GetMockTransport : MockHttpClientTransport
    {
        public GetMockTransport(string queryKey, RequestOptions filter, ConfigurationSetting result)
        {
            _expectedMethod = HttpMethod.Get;
            _expectedUri = $"https://contoso.azconfig.io/kv/{queryKey}{GetExtraUriParameters(filter)}";
            _expectedRequestContent = null;

            string json = JsonConvert.SerializeObject(result).ToLowerInvariant();
            json = json.Replace("contenttype", "content_type");
            _responseContent = json.Replace("lastmodified", "last_modified");
        }

        public GetMockTransport(string queryKey, RequestOptions filter, params HttpStatusCode[] statusCodes)
            : this(queryKey, filter, result: null)
        {
            Responses.Clear();
            foreach (var statusCode in statusCodes) {
                Responses.Add(statusCode);
            }
        }
    }

    class LockingMockTransport : MockHttpClientTransport
    {
        public LockingMockTransport(ConfigurationSetting responseContent, bool lockOtherwiseUnlock)
        {
            _expectedUri = $"https://contoso.azconfig.io/locks/{responseContent.Key}{GetExtraUriParameters(responseContent)}";
            _expectedRequestContent = null;
            _expectedMethod = lockOtherwiseUnlock ? HttpMethod.Put : HttpMethod.Delete;

            string json = JsonConvert.SerializeObject(responseContent).ToLowerInvariant();
            json = json.Replace("contenttype", "content_type");
            _responseContent = json.Replace("lastmodified", "last_modified");
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
                var item = new ConfigurationSetting($"key{i}", "val")
                {
                    Label = "label",
                    ETag = "c3c231fd-39a0-4cb6-3237-4614474b92c1",
                    ContentType = "text"
                };
                KeyValues.Add(item);
            }
        }

        // this is just so the mock serialization works as desired, i.e. so that the payload has items property
        class MockBatch
        {
            public List<ConfigurationSetting> Items = new List<ConfigurationSetting>();
        }
        protected override void WriteResponseCore(HttpResponseMessage response)
        {
            var batch = Batches[_currentBathIndex++];
            var bathItems = new MockBatch();
            int itemIndex = batch.index;
            int count = batch.count;
            while (count-- > 0)
            {
                bathItems.Items.Add(KeyValues[itemIndex++]);
            }
            string json = JsonConvert.SerializeObject(bathItems).ToLowerInvariant();
            json = json.Replace("contenttype", "content_type");
            json = json.Replace("lastmodified", "last_modified");
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            long jsonByteCount = Encoding.UTF8.GetByteCount(json);
            response.Content.Headers.Add("Content-Length", jsonByteCount.ToString());
            if (itemIndex < KeyValues.Count)
            {
                response.Headers.Add("Link", $"</kv?after={itemIndex}>;rel=\"next\"");
            }
        }
    }
    
    abstract class MockHttpClientTransport : HttpPipelineTransport
    {
        protected string _responseContent;
        protected HttpMethod _expectedMethod;
        protected StringCheck _expectedUri;
        protected StringCheck? _expectedRequestContent;
        public Dictionary<string, StringCheck> _expectedRequestHeaders = new Dictionary<string, StringCheck>();

        public List<Response> Responses = new List<Response>();
        int _nextResponse;

        protected sealed override Task<HttpResponseMessage> ProcessCoreAsync(CancellationToken cancellation, HttpRequestMessage request)
        {
            if (Responses.Count == 0)
            { // TODO (pri 3): this should not be hardcoded here
                Responses.Add(HttpStatusCode.GatewayTimeout);
                Responses.Add(HttpStatusCode.OK);
            }

            VerifyRequest(request);

            HttpResponseMessage response = new HttpResponseMessage();
            if (WriteResponse(response))
            {
                WriteResponseCore(response);
            }
            return Task.FromResult(response);
        }

        void VerifyRequest(HttpRequestMessage request)
        {
            VerifyRequestLine(request);
            VerifyRequestHeaders(request);
            VerifyRequestContent(request);
            VerifyUserAgentHeader(request); // TODO (pri 3): why is it not part of the _expectedHeaders collection?
            VerifyRequestCore(request);
        }

        protected virtual void VerifyRequestCore(HttpRequestMessage request) { }
        
        protected virtual void WriteResponseCore(HttpResponseMessage response)
        {
            response.Content = new StringContent(_responseContent, Encoding.UTF8, "application/json");

            long jsonByteCount = Encoding.UTF8.GetByteCount(_responseContent);
            response.Content.Headers.Add("Content-Length", jsonByteCount.ToString()); // TODO (pri 3): the service actually responds with chunked encoding

            response.Content.Headers.TryAddWithoutValidation("Last-Modified", "Tue, 05 Dec 2017 02:41:26 GMT");
            response.Content.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.microsoft.appconfig.kv+json; charset=utf-8;");
        }

        protected string GetExtraUriParameters(RequestOptions filter)
        {
            if (filter != null && filter.Label != null)
            {
                return $"?label={filter.Label}";
            }
            return string.Empty;
        }

        protected string GetExtraUriParameters(ConfigurationSetting setting)
        {
            if (setting.Label != null)
            {
                return $"?label={setting.Label}";
            }
            return string.Empty;
        }
      
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
            var expected = Utf8.ToString(HttpHeader.Common.CreateUserAgent("Azure.Configuration", "1.0.0").Value);

            Assert.True(request.Headers.Contains("User-Agent"));
            var userAgentValues = request.Headers.GetValues("User-Agent");

            foreach (var value in userAgentValues)
            {
                if (expected.StartsWith(value)) return;
            }
            Assert.Fail("could not find User-Agent header value " + expected);
        }

        void VerifyRequestHeaders(HttpRequestMessage request)
        {
            foreach(var check in _expectedRequestHeaders) {
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

        protected string GenerateExpectedRequestContent(ConfigurationSetting content)
        {
            StringBuilder requestContent = new StringBuilder();
            requestContent.AppendFormat("{{\"value\":\"{0}\",\"content_type\":\"{1}\",\"tags\":{{", content.Value, content.ContentType);

            bool first = true;
            foreach (var tag in content.Tags)
            {
                if (first)
                {
                    requestContent.AppendFormat("\"{0}\":\"{1}\"", tag.Key, tag.Value);
                    first = false;
                }
                else
                {
                    requestContent.AppendFormat(",\"{0}\":\"{1}\"", tag.Key, tag.Value);
                }
            }
            requestContent.Append("}}");
            return requestContent.ToString();
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
