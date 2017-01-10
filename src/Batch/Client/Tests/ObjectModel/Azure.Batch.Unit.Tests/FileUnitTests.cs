// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
            using (BatchClient client = await CreateBatchClientWithHandlerAsync())
            {
                NodeFile file = await client.JobOperations.GetNodeFileAsync("Foo", "Bar", "Baz");
                Assert.Equal(StreamUnitTests.StreamLengthInBytes, file.Properties.ContentLength);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task GetFilePropertiesFromNodeDoesNotThrowOutOfMemoryException()
        {
            using (BatchClient client = await CreateBatchClientWithHandlerAsync())
            {
                NodeFile file = await client.PoolOperations.GetNodeFileAsync("Foo", "Bar", "Baz");
                Assert.Equal(StreamUnitTests.StreamLengthInBytes, file.Properties.ContentLength);
            }
        }

        private static Task<BatchClient> CreateBatchClientWithHandlerAsync()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Empty)
            };
            responseMessage.Content.Headers.ContentLength = StreamUnitTests.StreamLengthInBytes;
            ReplayDelegatingHandler handler = new ReplayDelegatingHandler(responseMessage);

            return BatchClient.OpenAsync(new Protocol.BatchServiceClient(new TokenCredentials("xyz"), handler));
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
