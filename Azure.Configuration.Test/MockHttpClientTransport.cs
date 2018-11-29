using Azure.Core.Net;
using Azure.Core.Net.Pipeline;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Buffers.Text.Encodings;

namespace Azure.Configuration.Test
{
    abstract class MockHttpClientTransport : HttpClientTransport
    {
        protected HttpMethod _expectedMethod;
        protected string _expectedUri;
        protected string _expectedContent;
        int _nextResponse;

        public List<Response> Responses = new List<Response>();

        protected override Task<HttpResponseMessage> ProcessCoreAsync(CancellationToken cancellation, HttpRequestMessage request)
        {
            VerifyRequestLine(request);
            VerifyRequestContent(request);
            VerifyUserAgentHeader(request);
            VerifyRequestCore(request);
            HttpResponseMessage response = new HttpResponseMessage();
            WriteResponse(response);
            WriteResponseCore(response);
            return Task.FromResult(response);
        }

        protected virtual void VerifyRequestCore(HttpRequestMessage request) { }
        protected abstract void WriteResponseCore(HttpResponseMessage response);

        void VerifyRequestLine(HttpRequestMessage request)
        {
            Assert.AreEqual(_expectedMethod, request.Method);
            Assert.AreEqual(_expectedUri, request.RequestUri.OriginalString);
            Assert.AreEqual(new Version(2, 0), request.Version);
        }

        void VerifyRequestContent(HttpRequestMessage request)
        {
            if (_expectedContent == null)
            {
                Assert.IsNull(request.Content);
            }
            else
            {
                Assert.NotNull(request.Content);
                var contentString = request.Content.ReadAsStringAsync().Result;
                Assert.AreEqual(_expectedContent, contentString);
            }
        }

        void VerifyUserAgentHeader(HttpRequestMessage request)
        {
            var expected = Utf8.ToString(Header.Common.CreateUserAgent("Azure-Configuration", "1.0.0").Value);

            Assert.True(request.Headers.Contains("User-Agent"));
            var userAgentValues = request.Headers.GetValues("User-Agent");

            foreach (var value in userAgentValues)
            {
                if (expected.StartsWith(value)) return;
            }
            Assert.Fail("could not find User-Agent header value " + expected);
        }

        void WriteResponse(HttpResponseMessage response)
        {
            if (_nextResponse >= Responses.Count) _nextResponse = 0;
            var mockResponse = Responses[_nextResponse++];
            response.StatusCode = mockResponse.ResponseCode;
        }

        public class Response
        {
            public HttpStatusCode ResponseCode;

            public static implicit operator Response(HttpStatusCode status) => new Response() {  ResponseCode = status };
        }
    }
}
