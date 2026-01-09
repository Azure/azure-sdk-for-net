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

            Assert.Multiple(() =>
            {
                Assert.That(transport.Requests[0].Headers.TryGetValue(headerName, out _), Is.False);
                Assert.That(response.Headers.TryGetValue(headerName, out string responseValue), Is.True);
                Assert.That(responseValue, Is.EqualTo(headerValue));
            });

            await SendGetRequest(transport, policy);

            Assert.Multiple(() =>
            {
                Assert.That(transport.Requests[1].Headers.TryGetValue(headerName, out string requestValue), Is.True);
                Assert.That(requestValue, Is.EqualTo(idTokenValue));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(transport.Requests[1].Headers.TryGetValue(headerName, out string reqValue), Is.True);

                Assert.That($"{header1Value},{header2Value}".Equals(reqValue) ||
                            $"{header2Value},{header1Value}".Equals(reqValue), Is.True);
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(transport.Requests[1].Headers.TryGetValue(headerName, out string reqValue), Is.True);

                Assert.That($"{header1Value},{header2Value}".Equals(reqValue) ||
                            $"{header2Value},{header1Value}".Equals(reqValue), Is.True);
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(transport.Requests[1].Headers.TryGetValue(headerName, out string req1Value), Is.True);
                Assert.That(transport.Requests[2].Headers.TryGetValue(headerName, out string req2Value), Is.True);

                Assert.That(req1Value, Is.EqualTo(header1Value));
                Assert.That(req2Value, Is.EqualTo(header2Value));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(transport.Requests[1].Headers.TryGetValue(headerName, out string req1Value), Is.True);
                Assert.That(transport.Requests[2].Headers.TryGetValue(headerName, out string req2Value), Is.True);

                Assert.That(req1Value, Is.EqualTo(header1Value));
                Assert.That(req2Value, Is.EqualTo(header1Value));
            });
        }

        [Test]
        public void ParsesValidSyncToken()
        {
            string id = "jtqGc1I4";
            string value = "MDoyOA==";
            long seqNo = 28;
            string headerValue = $"{id}={value};sn={seqNo}";

            Assert.Multiple(() =>
            {
                Assert.That(SyncTokenUtils.TryParse(headerValue, out SyncToken syncToken), Is.True);
                Assert.That(syncToken.Id, Is.EqualTo(id));
                Assert.That(syncToken.Value, Is.EqualTo(value));
                Assert.That(syncToken.SequenceNumber, Is.EqualTo(seqNo));
            });
        }
    }
}
