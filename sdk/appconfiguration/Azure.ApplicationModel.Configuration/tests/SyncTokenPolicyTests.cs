// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.ApplicationModel.Configuration.Tests
{
    public class SyncTokenPolicyTests : SyncAsyncPolicyTestBase
    {
        public SyncTokenPolicyTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task CachesHeaderValue()
        {
            string headerName = "Sync-Token";
            string idTokenValue = "jtqGc1I4=MDoyOA==";
            string seqNoValue = ";sn=28";
            string headerValue = idTokenValue + seqNoValue;
            
            var syncTokenReponse = new MockResponse(200);
            syncTokenReponse.AddHeader(new HttpHeader(headerName, headerValue));

            MockTransport transport = CreateMockTransport(syncTokenReponse, new MockResponse(200));
            var policy = new SyncTokenPolicy();

            var response = await SendGetRequest(transport, policy);
            
            Assert.False(transport.Requests[0].Headers.TryGetValue("Sync-Token", out _));
            Assert.True(response.Headers.TryGetValue("Sync-Token", out string responseValue));
            Assert.AreEqual(headerValue, responseValue);

            await SendGetRequest(transport, policy);

            Assert.True(transport.Requests[1].Headers.TryGetValue("Sync-Token", out string requestValue));
            Assert.AreEqual(idTokenValue, requestValue);
        }

        [Test]
        public async Task UpdatesCachedValue()
        {
            string headerName = "Sync-Token";
            string header1Value = "id=A";
            string header2Value = "id=B";

            var response1 = new MockResponse(200);
            response1.AddHeader(new HttpHeader(headerName, header1Value + ";sn=1"));

            var response2 = new MockResponse(200);
            response2.AddHeader(new HttpHeader(headerName, header2Value + ";sn=2"));
            
            MockTransport transport = CreateMockTransport(response1, response2, new MockResponse(200));
            var policy = new SyncTokenPolicy();

            await SendGetRequest(transport, policy);
            await SendGetRequest(transport, policy);
            await SendGetRequest(transport, policy);
            
            Assert.True(transport.Requests[1].Headers.TryGetValue(headerName, out string res1Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue(headerName, out string res2Value));

            Assert.AreEqual(header1Value, res1Value);
            Assert.AreEqual(header2Value, res2Value);
        }

        [Test]
        public async Task DoesNotUpdateCachedValue()
        {
            string headerName = "Sync-Token";
            string header1Value = "id=A";
            string header2Value = "id=B";

            var response1 = new MockResponse(200);
            response1.AddHeader(new HttpHeader(headerName, header1Value + ";sn=2"));

            var response2 = new MockResponse(200);
            response2.AddHeader(new HttpHeader(headerName, header2Value + ";sn=1"));

            MockTransport transport = CreateMockTransport(response1, response2, new MockResponse(200));
            var policy = new SyncTokenPolicy();

            await SendGetRequest(transport, policy);
            await SendGetRequest(transport, policy);
            await SendGetRequest(transport, policy);

            Assert.True(transport.Requests[1].Headers.TryGetValue(headerName, out string res1Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue(headerName, out string res2Value));

            Assert.AreEqual(header1Value, res1Value);
            Assert.AreEqual(header1Value, res2Value);
        }
    }
}
