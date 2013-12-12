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
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Common.Test.Fakes;
using Microsoft.WindowsAzure.Common.TransientFaultHandling;
using Xunit;

namespace Microsoft.WindowsAzure.Common.Test
{
    public class ServiceClientTest
    {
        [Fact]
        public void ClientAddHandlerToPipelineAddsHandler()
        {
            var fakeClient = new FakeServiceClient(new FakeCertificateCloudCredentials());
            var result1 = fakeClient.DoStuff();
            Assert.Equal(200, (int)result1.Result.StatusCode);

            fakeClient.AddHandlerToPipeline(new BadResponseDelegatingHandler());

            var result2 = fakeClient.DoStuff();
            Assert.Equal(500, (int)result2.Result.StatusCode);
        }

        [Fact]
        public void RetryHandlerRetriesWith500Errors()
        {
            var fakeClient = new FakeServiceClient(new FakeCertificateCloudCredentials());
            int counter = 0;

            //fakeClient.AddHandlerToPipeline(new BadResponseDelegatingHandler());
            var retryHandler = new RetryHandler(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(2));
            retryHandler.Retrying += (sender, args) => { counter++; };
            fakeClient.AddHandlerToPipeline(retryHandler);

            var result = fakeClient.DoStuff();
            Assert.Equal(HttpStatusCode.InternalServerError, result.Result.StatusCode);
            Assert.Equal(2, counter);
        }

        [Fact]
        public void RetryHandlerRetriesWith500ErrorsAndSucceeds()
        {
            var fakeClient = new FakeServiceClient(new FakeCertificateCloudCredentials());
            int counter = 0;

            //fakeClient = fakeClient.WithHandler(new BadResponseDelegatingHandler() { NumberOfTimesToFail = 1 });
            //var retryHandler = new RetryHandler(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(2));
            //retryHandler.Retrying += (sender, args) => { counter++; };
            //fakeClient.AddHandlerToPipeline(retryHandler);

            var result = fakeClient.DoStuff();
            Assert.Equal(HttpStatusCode.OK, result.Result.StatusCode);
            Assert.Equal(1, counter);
        }

        [Fact]
        public void RetryHandlerDoesntRetryFor400Errors()
        {
            var fakeClient = new FakeServiceClient(new FakeCertificateCloudCredentials());
            int counter = 0;

            //fakeClient.AddHandlerToPipeline(new BadResponseDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Conflict });
            var retryHandler = new RetryHandler(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(2));
            retryHandler.Retrying += (sender, args) => { counter++; };
            fakeClient.AddHandlerToPipeline(retryHandler);

            var result = fakeClient.DoStuff();
            Assert.Equal(HttpStatusCode.Conflict, result.Result.StatusCode);
            Assert.Equal(0, counter);
        }
    }
}
