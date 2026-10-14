// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias RemovedV2Preview;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using global::Azure.Core;
using global::Azure.Core.Pipeline;
using NUnit.Framework;
using RemovedV2Preview::Versioning.Removed;

namespace TestProjects.Spector.Tests.Http.Versioning.Removed.V2Preview
{
    public class VersioningRemovedV2PreviewTests : SpectorTestBase
    {
        [SpectorTest]
        public async Task SubClientPreservesSelectedApiVersion()
        {
            using var handler = new ApiVersionHandler();
            using var httpClient = new HttpClient(handler);
            var options = new RemovedClientOptions(RemovedClientOptions.ServiceVersion.V1)
            {
                Transport = new HttpClientTransport(httpClient)
            };
            var client = new RemovedClient(new Uri("https://localhost"), options);

            await client.GetInterfaceV1Client().V1InInterfaceAsync(RequestContent.Create(new { }));

            StringAssert.Contains("api-version:v1", handler.RequestUri!.AbsolutePath);
        }

        private class ApiVersionHandler : HttpMessageHandler
        {
            public Uri? RequestUri { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestUri = request.RequestUri;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
            }
        }

        [SpectorTest]
        public Task Versioning_Removed_V3Model() => Test(async (host) =>
        {
            var model = new ModelV3("123");
            var response = await new RemovedClient(host).ModelV3Async(model);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("123", response.Value.Id);
        });
    }
}
