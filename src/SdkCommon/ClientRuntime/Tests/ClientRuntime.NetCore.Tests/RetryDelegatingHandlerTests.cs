// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ClientRuntime.Tests.Common.Fakes;
using Microsoft.Rest;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;

namespace ClientRuntime.NetCore.Tests
{
    public class RetryDelegatingHandlerTests
    {
        /// <summary>
        /// Ensure that when the request is canceled due to a timeout from the HttpClient, the last error response is returned
        /// and a TaskCanceledException is not surfaced to the caller.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task HttpClientTimeoutReturnsErrorResponse(string content)
        {
            // Setup the RetryDelegatingHandler to retry very quickly.
            var retryStrategy = new FixedIntervalRetryStrategy(Int32.MaxValue, TimeSpan.FromTicks(1));
            var retryPolicy = new RetryPolicy(new HttpStatusCodeErrorDetectionStrategy(), retryStrategy);

            var fakeHttpHandler = new FakeHttpHandler
            {
                TweakResponse = (response) =>
                {
                    response.Content = content == null ? null : new StringContent(String.Empty);
                }
            };

            var retryHandler = new RetryDelegatingHandler(retryPolicy, fakeHttpHandler);

            // Setup HttpClient to timeout after 500 milliseconds.
            var httpClient = new HttpClient(retryHandler, false)
            {
                Timeout = TimeSpan.FromMilliseconds(500)
            };

            // Make a request using the HttpClient.
            var fakeClient = new FakeServiceClient(httpClient);
            var responseMessage = fakeClient.DoStuffSync();

            Assert.NotNull(responseMessage);
            Assert.True(fakeHttpHandler.NumberOfTimesFailedSoFar > 1);
            Assert.Equal(HttpStatusCode.InternalServerError, responseMessage.StatusCode);
        }
    }
}
