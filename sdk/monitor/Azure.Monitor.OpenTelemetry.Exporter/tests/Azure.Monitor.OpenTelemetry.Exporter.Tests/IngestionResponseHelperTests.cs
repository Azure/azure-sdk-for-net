// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class IngestionResponseHelperTests
    {
        public const string ExampleInvalidInstrumentationKey = "{\"itemsReceived\":1,\"itemsAccepted\":0,\"errors\":[{\"index\":0,\"statusCode\":400,\"message\":\"Invalid instrumentation key\"}]}";

        public const string ExampleFieldIsTooLong = "{\"itemsReceived\":2,\"itemsAccepted\":0,\"errors\":[{\"index\":0,\"statusCode\":400,\"message\":\"100: Field 'message' on type 'MessageData' is too long. Expected: 32768 characters\"},{\"index\":1,\"statusCode\":400,\"message\":\"100: Field 'message' on type 'MessageData' is too long. Expected: 32768 characters\"}]}";

        public const string ExampleSuccess = "{\"itemsReceived\":5,\"itemsAccepted\":5,\"errors\":[]}";

        [Fact]
        public void VerifyCanParseErrorMessage()
        {
            var mockResponse = new MockResponse(400).SetContent(ExampleInvalidInstrumentationKey);
            var result = IngestionResponseHelper.GetErrorsFromResponse(mockResponse);

            Assert.Single(result);
            Assert.Equal("Invalid instrumentation key", result[0]);
        }

        [Fact]
        public void VerifyCanParseMultipleErrorMessages()
        {
            var mockResponse = new MockResponse(400).SetContent(ExampleFieldIsTooLong);
            var result = IngestionResponseHelper.GetErrorsFromResponse(mockResponse);

            Assert.Equal(2, result.Length);
            Assert.Equal("100: Field 'message' on type 'MessageData' is too long. Expected: 32768 characters", result[0]);
            Assert.Equal("100: Field 'message' on type 'MessageData' is too long. Expected: 32768 characters", result[1]);
        }

        [Fact]
        public void VerifyHandlesNoError()
        {
            var mockResponse = new MockResponse(400).SetContent(ExampleSuccess);
            var result = IngestionResponseHelper.GetErrorsFromResponse(mockResponse);

            Assert.Empty(result);
        }

        [Fact]
        public void VerifyHandlesNoContent()
        {
            var mockResponse = new MockResponse(400);
            var result = IngestionResponseHelper.GetErrorsFromResponse(mockResponse);

            Assert.Empty(result);
        }

        [Fact]
        public void VerifyHandlesEmptyContent()
        {
            var mockResponse = new MockResponse(400).SetContent(string.Empty);
            var result = IngestionResponseHelper.GetErrorsFromResponse(mockResponse);

            Assert.Empty(result);
        }

        [Fact]
        public void VerifyHandlesNullResponse()
        {
            var result = IngestionResponseHelper.GetErrorsFromResponse(null);

            Assert.Empty(result);
        }
    }
}
