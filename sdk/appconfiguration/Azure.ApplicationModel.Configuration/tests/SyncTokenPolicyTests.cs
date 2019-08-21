// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Moq;
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
            syncTokenReponse.AddHeader(new Core.Http.HttpHeader(headerName, headerValue));

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
    }
}
