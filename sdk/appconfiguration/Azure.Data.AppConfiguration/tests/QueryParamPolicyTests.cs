// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.Data.AppConfiguration.Tests
{
    public class QueryParamPolicyTests : SyncAsyncPolicyTestBase
    {
        public QueryParamPolicyTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task LowercasesParameterNames()
        {
            string originalUrl = "https://example.azconfig.io/kv?API-VERSION=1.0&LABEL=test&KEY=mykey";
            string expectedUrl = "https://example.azconfig.io/kv?api-version=1.0&key=mykey&label=test";

            MockTransport transport = CreateMockTransport(new MockResponse(200));
            QueryParamPolicy policy = new QueryParamPolicy();

            Response response = await SendRequestAsync(transport, message =>
            {
                message.Request.Uri.Reset(new System.Uri(originalUrl));
            }, policy);

            MockRequest request = transport.SingleRequest;
            Assert.AreEqual(expectedUrl, request.Uri.ToString());
        }

        [Test]
        public async Task SortsByLowercaseName()
        {
            string originalUrl = "https://example.azconfig.io/kv?zebra=1&alpha=2&beta=3";
            string expectedUrl = "https://example.azconfig.io/kv?alpha=2&beta=3&zebra=1";

            MockTransport transport = CreateMockTransport(new MockResponse(200));
            QueryParamPolicy policy = new QueryParamPolicy();

            Response response = await SendRequestAsync(transport, message =>
            {
                message.Request.Uri.Reset(new System.Uri(originalUrl));
            }, policy);

            MockRequest request = transport.SingleRequest;
            Assert.AreEqual(expectedUrl, request.Uri.ToString());
        }

        [Test]
        public async Task PreservesRelativeOrderOfDuplicates()
        {
            string originalUrl = "https://example.azconfig.io/kv?tags=tag3=value3&other=value&tags=tag2=value2&tags=tag1=value1";
            string expectedUrl = "https://example.azconfig.io/kv?other=value&tags=tag3=value3&tags=tag2=value2&tags=tag1=value1";

            MockTransport transport = CreateMockTransport(new MockResponse(200));
            QueryParamPolicy policy = new QueryParamPolicy();

            Response response = await SendRequestAsync(transport, message =>
            {
                message.Request.Uri.Reset(new System.Uri(originalUrl));
            }, policy);

            MockRequest request = transport.SingleRequest;
            Assert.AreEqual(expectedUrl, request.Uri.ToString());
        }

        [Test]
        public async Task PreservesOriginalValues()
        {
            string originalUrl = "https://example.azconfig.io/kv?tags=tag3%3Dvalue3&Label=DEV&key=My%20Key";
            string expectedUrl = "https://example.azconfig.io/kv?key=My%20Key&label=DEV&tags=tag3%3Dvalue3";

            MockTransport transport = CreateMockTransport(new MockResponse(200));
            QueryParamPolicy policy = new QueryParamPolicy();

            Response response = await SendRequestAsync(transport, message =>
            {
                message.Request.Uri.Reset(new System.Uri(originalUrl));
            }, policy);

            MockRequest request = transport.SingleRequest;
            Assert.AreEqual(expectedUrl, request.Uri.ToString());
        }
    }
}
