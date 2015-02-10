//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Net;
using System.Net.Http;
using System.Linq;
using Hyak.Common;
using Hyak.Common.Internals;
using Hyak.Common.TransientFaultHandling;
using Microsoft.Azure.Common.Test.Fakes;
using Xunit;
using Hyak.Common.Platform;

namespace Microsoft.Azure.Common.Test
{
    public class ServiceClientTest
    {
        [Fact]
        public void VerifyWebRequestHandlerCreation()
        {
            var someProvider = PortablePlatformAbstraction.Get<IHttpTransportHandlerProvider>(true);
            var webRequestHandler = someProvider.CreateHttpTransportHandler();
            Assert.IsType<WebRequestHandler>(webRequestHandler);
        }

        [Fact]
        public void ClientAddHandlerToPipelineAddsHandler()
        {
            var fakeClient = new FakeServiceClient(new WebRequestHandler());
            var result1 = fakeClient.DoStuff();
            Assert.Equal(HttpStatusCode.OK, result1.Result.StatusCode);

            fakeClient.AddHandlerToPipeline(new BadResponseDelegatingHandler());

            var result2 = fakeClient.DoStuff();
            Assert.Equal(HttpStatusCode.InternalServerError, result2.Result.StatusCode);
        }

        [Fact]
        public void ClientAddHandlersToPipelineAddSingleHandler()
        {
            var fakeClient = new FakeServiceClient(new WebRequestHandler());
            var result1 = fakeClient.DoStuff();
            Assert.Equal(HttpStatusCode.OK, result1.Result.StatusCode);

            fakeClient = fakeClient.WithHandlers(new[] {
                new BadResponseDelegatingHandler()
            });

            var result2 = fakeClient.DoStuff();
            Assert.Equal(HttpStatusCode.InternalServerError, result2.Result.StatusCode);
        }

        [Fact]
        public void ClientAddHandlersToPipelineAddMultipleHandler()
        {
            var fakeClient = new FakeServiceClient(new WebRequestHandler());
            var result1 = fakeClient.DoStuff();
            Assert.Equal(HttpStatusCode.OK, result1.Result.StatusCode);

            fakeClient = fakeClient.WithHandlers(new DelegatingHandler[] {
                new BadResponseDelegatingHandler(),
                new AddHeaderResponseDelegatingHandler("foo", "bar"),
            });

            var result2 = fakeClient.DoStuff();
            Assert.Equal(result2.Result.Headers.GetValues("foo").FirstOrDefault(), "bar");
            Assert.Equal(HttpStatusCode.InternalServerError, result2.Result.StatusCode);
        }

        [Fact]
        public void RetryHandlerRetriesWith500Errors()
        {
            var fakeClient = new FakeServiceClient(new FakeHttpHandler());
            int attemptsFailed = 0;

            fakeClient.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(2));
            var retryHandler = fakeClient.GetHttpPipeline().OfType<RetryHandler>().FirstOrDefault();
            retryHandler.Retrying += (sender, args) => { attemptsFailed++; };

            var result = fakeClient.DoStuff();
            Assert.Equal(HttpStatusCode.InternalServerError, result.Result.StatusCode);
            Assert.Equal(2, attemptsFailed);
        }

        [Fact]
        public void RetryHandlerRetriesWith500ErrorsAndSucceeds()
        {
            var fakeClient = new FakeServiceClient(new FakeHttpHandler() { NumberOfTimesToFail = 1 });
            int attemptsFailed = 0;

            fakeClient.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(2));
            var retryHandler = fakeClient.GetHttpPipeline().OfType<RetryHandler>().FirstOrDefault();
            retryHandler.Retrying += (sender, args) => { attemptsFailed++; };

            var result = fakeClient.DoStuff();
            Assert.Equal(HttpStatusCode.OK, result.Result.StatusCode);
            Assert.Equal(1, attemptsFailed);
        }

        [Fact]
        public void RetryHandlerDoesntRetryFor400Errors()
        {
            var fakeClient = new FakeServiceClient(new FakeHttpHandler() { StatusCodeToReturn = HttpStatusCode.Conflict });
            int attemptsFailed = 0;

            fakeClient.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(2));
            var retryHandler = fakeClient.GetHttpPipeline().OfType<RetryHandler>().FirstOrDefault();
            retryHandler.Retrying += (sender, args) => { attemptsFailed++; };

            var result = fakeClient.DoStuff();
            Assert.Equal(HttpStatusCode.Conflict, result.Result.StatusCode);
            Assert.Equal(0, attemptsFailed);
        }
    }
}
