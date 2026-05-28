// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
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

            Response response = await SendGetRequest(transport, policy);

            Assert.False(transport.Requests[0].Headers.TryGetValue(headerName, out _));
            Assert.True(response.Headers.TryGetValue(headerName, out string responseValue));
            Assert.AreEqual(headerValue, responseValue);

            await SendGetRequest(transport, policy);

            Assert.True(transport.Requests[1].Headers.TryGetValue(headerName, out string requestValue));
            Assert.AreEqual(idTokenValue, requestValue);
        }

        [Test]
        public async Task CachesMultipleTokens()
        {
            string headerName = "Sync-Token";
            string header1Value = "syncToken1=val1";
            string header2Value = "syncToken2=val2";

            var syncTokenReponse = new MockResponse(200);
            syncTokenReponse.AddHeader(new HttpHeader(headerName, $"{header1Value};sn=6"));
            syncTokenReponse.AddHeader(new HttpHeader(headerName, $"{header2Value};sn=10"));

            MockTransport transport = CreateMockTransport(syncTokenReponse, new MockResponse(200));
            var policy = new SyncTokenPolicy();

            await SendGetRequest(transport, policy);
            await SendGetRequest(transport, policy);

            Assert.True(transport.Requests[1].Headers.TryGetValue(headerName, out string reqValue));

            Assert.True($"{header1Value},{header2Value}".Equals(reqValue) ||
                        $"{header2Value},{header1Value}".Equals(reqValue));
        }

        [Test]
        public async Task CachesMultipleTokensFromSingleHeader()
        {
            string headerName = "Sync-Token";
            string header1Value = "syncToken1=val1";
            string header2Value = "syncToken2=val2";

            var syncTokenReponse = new MockResponse(200);
            syncTokenReponse.AddHeader(new HttpHeader(headerName, $"{header1Value};sn=6,{header2Value};sn=10"));

            MockTransport transport = CreateMockTransport(syncTokenReponse, new MockResponse(200));
            var policy = new SyncTokenPolicy();

            await SendGetRequest(transport, policy);
            await SendGetRequest(transport, policy);

            Assert.True(transport.Requests[1].Headers.TryGetValue(headerName, out string reqValue));

            Assert.True($"{header1Value},{header2Value}".Equals(reqValue) ||
                        $"{header2Value},{header1Value}".Equals(reqValue));
        }

        [Test]
        public async Task UpdatesCachedValue()
        {
            string headerName = "Sync-Token";
            string header1Value = "testSyncToken=A";
            string header2Value = "testSyncToken=B";

            var response1 = new MockResponse(200);
            response1.AddHeader(new HttpHeader(headerName, header1Value + ";sn=1"));

            var response2 = new MockResponse(200);
            response2.AddHeader(new HttpHeader(headerName, header2Value + ";sn=2"));

            MockTransport transport = CreateMockTransport(response1, response2, new MockResponse(200));
            var policy = new SyncTokenPolicy();

            await SendGetRequest(transport, policy);
            await SendGetRequest(transport, policy);
            await SendGetRequest(transport, policy);

            Assert.True(transport.Requests[1].Headers.TryGetValue(headerName, out string req1Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue(headerName, out string req2Value));

            Assert.AreEqual(header1Value, req1Value);
            Assert.AreEqual(header2Value, req2Value);
        }

        [Test]
        public async Task DoesNotUpdateCachedValue()
        {
            string headerName = "Sync-Token";
            string header1Value = "testSyncToken=A";
            string header2Value = "testSyncToken=B";

            var response1 = new MockResponse(200);
            response1.AddHeader(new HttpHeader(headerName, header1Value + ";sn=2"));

            var response2 = new MockResponse(200);
            response2.AddHeader(new HttpHeader(headerName, header2Value + ";sn=1"));

            MockTransport transport = CreateMockTransport(response1, response2, new MockResponse(200));
            var policy = new SyncTokenPolicy();

            await SendGetRequest(transport, policy);
            await SendGetRequest(transport, policy);
            await SendGetRequest(transport, policy);

            Assert.True(transport.Requests[1].Headers.TryGetValue(headerName, out string req1Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue(headerName, out string req2Value));

            Assert.AreEqual(header1Value, req1Value);
            Assert.AreEqual(header1Value, req2Value);
        }

        [Test]
        public void ParsesValidSyncToken()
        {
            string id = "jtqGc1I4";
            string value = "MDoyOA==";
            long seqNo = 28;
            string headerValue = $"{id}={value};sn={seqNo}";

            Assert.IsTrue(SyncTokenUtils.TryParse(headerValue, out SyncToken syncToken));
            Assert.AreEqual(id, syncToken.Id);
            Assert.AreEqual(value, syncToken.Value);
            Assert.AreEqual(seqNo, syncToken.SequenceNumber);
        }
    }
}
