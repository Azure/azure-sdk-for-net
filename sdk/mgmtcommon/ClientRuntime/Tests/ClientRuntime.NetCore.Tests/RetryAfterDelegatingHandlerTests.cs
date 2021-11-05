using ClientRuntime.Tests.Common.Fakes;
using Microsoft.Rest;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ClientRuntime.NetCore.Tests
{
    public class RetryAfterDelegatingHandlerTests
    {
        /// <summary>
        /// Ensure that when the request is canceled due to a timeout from the HttpClient, the last error response is returned
        /// and a TaskCanceledException is not surfaced to the caller.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void HttpClientTimeoutReturnsErrorResponse(string content)
        {
            // Setup to always return 429.
            var fakeHttpHandler = new FakeHttpHandler
            {
                StatusCodeToReturn = (HttpStatusCode)429,
                TweakResponse = (response) =>
                {
                    response.Content = content == null ? null : new StringContent(String.Empty);
                    response.Headers.Add("Retry-After", "1");
                }
            };

            var retryHandler = new RetryAfterDelegatingHandler(fakeHttpHandler);

            // Setup HttpClient to timeout after 5 seconds.
            var httpClient = new HttpClient(retryHandler, false)
            {
                Timeout = TimeSpan.FromSeconds(5)
            };

            // Make a request using the HttpClient.
            var fakeClient = new FakeServiceClient(httpClient);
            var responseMessage = fakeClient.DoStuffSync();

            Assert.NotNull(responseMessage);
            Assert.True(fakeHttpHandler.NumberOfTimesFailedSoFar > 1);
            Assert.Equal((HttpStatusCode)429, responseMessage.StatusCode);
        }

        /// <summary>
        /// Ensure that when a TaskCanceledException occurs while calling down stream DelegatingHandlers, the last error response is returned
        /// and a TaskCanceledException is not surfaced to the caller.
        /// </summary>
        [Fact]
        public void TaskCanceledCallingBaseSendAsyncCausesErrorResponse()
        {
            // Setup to always return 429.
            var fakeHttpHandler = new FakeHttpHandler();
            fakeHttpHandler.StatusCodeToReturn = (HttpStatusCode) 429;

            int callCount = 0;
            fakeHttpHandler.TweakResponse = (response) =>
            {
                // After 3 calls returning 429, cause TaskCanceledException to be thrown.
                if (callCount++ > 3)
                {
                    throw new TaskCanceledException();
                }

                response.Content = new StringContent(String.Empty);
                response.Headers.Add("Retry-After", "1");
            };

            var retryHandler = new RetryAfterDelegatingHandler(fakeHttpHandler);

            // Setup HttpClient to timeout after 5 seconds.
            var httpClient = new HttpClient(retryHandler, false)
            {
                Timeout = TimeSpan.FromSeconds(5)
            };

            // Make a request using the HttpClient.
            var fakeClient = new FakeServiceClient(httpClient);
            var responseMessage = fakeClient.DoStuffSync();

            Assert.NotNull(responseMessage);
            Assert.True(fakeHttpHandler.NumberOfTimesFailedSoFar > 1);
            Assert.Equal((HttpStatusCode)429, responseMessage.StatusCode);
        }

        [Fact]
        public void LimitsRetryCount()
        {
            // Setup to always return 429.
            var fakeHttpHandler = new FakeHttpHandler
            {
                StatusCodeToReturn = (HttpStatusCode)429,
                TweakResponse = (response) =>
                {
                    response.Headers.Add("Retry-After", "1");
                }
            };

            var retryHandler = new RetryAfterDelegatingHandler(fakeHttpHandler)
            {
                MaxRetries = 3
            };

            var httpClient = new HttpClient(retryHandler, false);

            // Make a request using the HttpClient.
            var fakeClient = new FakeServiceClient(httpClient);
            var responseMessage = fakeClient.DoStuffSync();

            Assert.NotNull(responseMessage);
            Assert.Equal(3, fakeHttpHandler.NumberOfTimesFailedSoFar);
            Assert.Equal((HttpStatusCode)429, responseMessage.StatusCode);
        }
    }
}
