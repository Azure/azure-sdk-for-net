// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
#if NETFRAMEWORK
    public class HttpWebRequestTransportFunctionalTest : TransportFunctionalTests
    {
        public HttpWebRequestTransportFunctionalTest(bool isAsync) : base(isAsync)
        {
        }

        protected override HttpPipelineTransport GetTransport(bool https = false, HttpPipelineTransportOptions options = null) =>
            options == null ?
                https ?
                    new HttpWebRequestTransport(request => request.ServerCertificateValidationCallback += (_, _, _, _) => true) : new HttpWebRequestTransport()
                : new HttpWebRequestTransport(options);

        [Test]
        public async Task LimitsAreSetOnDefaultHttpWebRequest()
        {
            using TestServer testServer = new TestServer(
                context => {});

            var transport = new HttpWebRequestTransport();
            using Request request = transport.CreateRequest();
            request.Uri.Reset(testServer.Address);

            await ExecuteRequest(request, transport);

            var servicePoint = ServicePointManager.FindServicePoint(testServer.Address);

            Assert.GreaterOrEqual(servicePoint.ConnectionLimit, 50);
            Assert.AreEqual(300_000, servicePoint.ConnectionLeaseTimeout);
        }
    }
#endif
}
