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
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Protocol;
    using Microsoft.Rest;
    using Xunit;

    public class BatchClientUnitTest
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestBatchClientThrowsAfterDispose()
        {
            BatchClient batchCli;

            // test dispose calls close
            using (batchCli = ClientUnitTestCommon.CreateDummyClient())
            {
            }

            TestBatchClientIsClosed(batchCli);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BatchAuthTokenIsSentToTheService_ClientCreatedWithFuncToken()
        {
            var tokenCredentials = new TokenCredentials(new BatchTokenProvider(() => Task.FromResult("foo")));

            HttpRequestMessage capturedRequest = null;

            var fakeHttpClientHandler = new FakeHttpClientHandler(req =>
            {
                capturedRequest = req;
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            });

            using (var restClient = new BatchServiceClient(tokenCredentials, fakeHttpClientHandler))
            {
                using (var client = BatchClient.Open(restClient))
                {
                    await client.PoolOperations.DeletePoolAsync("bar", new List<BatchClientBehavior>());
                }
            }

            Assert.Equal(capturedRequest.Headers.Authorization.Parameter, "foo");
            Assert.Equal(capturedRequest.Headers.Authorization.Scheme, "Bearer");
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task AuthTokenIsBeingSentOnEveryCallToTheService()
        {
            int count = 0;
            var tokenCredentials = new TokenCredentials(new BatchTokenProvider(() =>
            {
                count++;
                return Task.FromResult("foo");
            }));

            using (var restClient = new BatchServiceClient(tokenCredentials, new FakeHttpClientHandler(req => new HttpResponseMessage(HttpStatusCode.Accepted))))
            {
                var client = BatchClient.Open(restClient);

                await client.PoolOperations.DeletePoolAsync("bar", new List<BatchClientBehavior>());
                Assert.Equal(count, 1);
                await client.PoolOperations.DeletePoolAsync("bar", new List<BatchClientBehavior>());
                Assert.Equal(count, 2);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BatchAuthTokenIsSentToTheService_ClientCreatedWithToken()
        {
            var tokenCredentials = new TokenCredentials("foo");
            HttpRequestMessage capturedRequest = null;

            var fakeHttpClientHandler = new FakeHttpClientHandler(req => 
            {
                capturedRequest = req;
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            });

            using (var restClient = new BatchServiceClient(tokenCredentials, fakeHttpClientHandler))
            {
                using (var client = BatchClient.Open(restClient))
                {
                    await client.PoolOperations.DeletePoolAsync("bar");
                }
            }

            Assert.Equal(capturedRequest.Headers.Authorization.Parameter, "foo");
            Assert.Equal(capturedRequest.Headers.Authorization.Scheme, "Bearer");
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestBatchClientThrowsAfterClose()
        {
            // test explicit close
            BatchClient batchCli = ClientUnitTestCommon.CreateDummyClient();

            // close client and test
            batchCli.Close();

            TestBatchClientIsClosed(batchCli);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void BatchClientVersionIsNot9999()
        {
            const string badVersion = "9999-09-09.99.99";
            var serviceClient = new Microsoft.Azure.Batch.Protocol.BatchServiceClient(
                new Microsoft.Azure.Batch.Protocol.BatchSharedKeyCredential(
                    ClientUnitTestCommon.DummyAccountName,
                    ClientUnitTestCommon.DummyAccountKey));

            Assert.NotEqual(badVersion, serviceClient.ApiVersion);
        }

        private static void TestBatchClientIsClosed(BatchClient batchCli)
        {
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.CustomBehaviors; });
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.CertificateOperations; });
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.JobOperations; });
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.JobScheduleOperations; });
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.PoolOperations; });
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.Utilities; });
        }
    }
}
