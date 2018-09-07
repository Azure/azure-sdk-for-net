// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    public class FileUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public FileUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task GetFilePropertiesFromTaskDoesNotThrowOutOfMemoryException()
        {
            using (BatchClient client = CreateBatchClientWithHandler())
            {
                NodeFile file = await client.JobOperations.GetNodeFileAsync("Foo", "Bar", "Baz");
                Assert.Equal(StreamUnitTests.StreamLengthInBytes, file.Properties.ContentLength);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task GetFilePropertiesFromNodeDoesNotThrowOutOfMemoryException()
        {
            using (BatchClient client = CreateBatchClientWithHandler())
            {
                NodeFile file = await client.PoolOperations.GetNodeFileAsync("Foo", "Bar", "Baz");
                Assert.Equal(StreamUnitTests.StreamLengthInBytes, file.Properties.ContentLength);
            }
        }

        private static BatchClient CreateBatchClientWithHandler()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Empty)
            };
            responseMessage.Content.Headers.ContentLength = StreamUnitTests.StreamLengthInBytes;
            ReplayDelegatingHandler handler = new ReplayDelegatingHandler(responseMessage);

            return BatchClient.Open(new Protocol.BatchServiceClient(new TokenCredentials("xyz"), handler));
        }

        private class ReplayDelegatingHandler : DelegatingHandler
        {
            public HttpResponseMessage Response { get; private set; }

            public ReplayDelegatingHandler(HttpResponseMessage response)
            {
                this.Response = response;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                return Task.FromResult(this.Response);
            }
        }
    }
}
