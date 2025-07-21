// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class StorageResponseClassifierTests
    {
        private static readonly Uri MockPrimaryUri = new Uri("http://dummyaccount.blob.core.windows.net");
        private static readonly Uri MockSecondaryUri = new Uri("http://dummyaccount-secondary.blob.core.windows.net");
        private static readonly StorageResponseClassifier classifier = new StorageResponseClassifier() { SecondaryStorageUri = MockSecondaryUri };

        [Test]
        public void IsRetriableResponse_404OnSecondary_ShouldBeTrue()
        {
            HttpMessage message = BuildMessage(new MockResponse(Constants.HttpStatusCode.NotFound), MockSecondaryUri);
            message.Request.Uri.Host = MockSecondaryUri.Host;

            Assert.IsTrue(classifier.IsRetriableResponse(message));
        }

        [Test]
        [TestCase(500)]
        [TestCase(429)]
        [TestCase(503)]
        public void IsRetriableResponse_OtherStatusCodeOnSecondary_ShouldMatchBase(int statusCode)
        {
            HttpMessage message = BuildMessage(new MockResponse(statusCode), MockSecondaryUri);
            message.Request.Uri.Host = MockSecondaryUri.Host;

            Assert.AreEqual(new ResponseClassifier().IsRetriableResponse(message), classifier.IsRetriableResponse(message));
        }

        [Test]
        public void IsRetriableResponse_404OnPrimary_ShouldBeFalse()
        {
            HttpMessage message = BuildMessage(new MockResponse(Constants.HttpStatusCode.NotFound), MockSecondaryUri);
            message.Request.Uri.Host = MockPrimaryUri.Host;

            Assert.IsFalse(classifier.IsRetriableResponse(message));
        }

        [Test]
        [TestCase(Constants.ErrorCodes.ServerBusy)]
        [TestCase(Constants.ErrorCodes.InternalError)]
        [TestCase(Constants.ErrorCodes.OperationTimedOut)]
        public void IsRetriableResponse_StorageErrors(string errorCode)
        {
            var response = new MockResponse(Constants.HttpStatusCode.NotFound);
            response.AddHeader(new HttpHeader(Constants.HeaderNames.ErrorCode, errorCode));
            HttpMessage message = BuildMessage(response);
            Assert.IsTrue(classifier.IsRetriableResponse(message));
        }

        [Test]
        [TestCase(Constants.ErrorCodes.ServerBusy)]
        [TestCase(Constants.ErrorCodes.InternalError)]
        [TestCase(Constants.ErrorCodes.OperationTimedOut)]
        public void IsRetriableResponse_StorageErrors_SecondaryUri(string errorCode)
        {
            var response = new MockResponse(Constants.HttpStatusCode.NotFound);
            response.AddHeader(new HttpHeader(Constants.HeaderNames.ErrorCode, errorCode));
            HttpMessage message = BuildMessage(response, MockSecondaryUri);
            Assert.IsTrue(classifier.IsRetriableResponse(message));
        }

        [Test]
        [TestCase(Constants.ErrorCodes.ServerBusy)]
        [TestCase(Constants.ErrorCodes.InternalError)]
        [TestCase(Constants.ErrorCodes.OperationTimedOut)]
        public void IsRetriableResponse_CopySourceErrors(string errorCode)
        {
            var response = new MockResponse(Constants.HttpStatusCode.NotFound);
            response.AddHeader(new HttpHeader(Constants.HeaderNames.CopySourceErrorCode, errorCode));
            HttpMessage message = BuildMessage(response);
            Assert.IsTrue(classifier.IsRetriableResponse(message));
        }

        [Test]
        [TestCase(Constants.ErrorCodes.ServerBusy)]
        [TestCase(Constants.ErrorCodes.InternalError)]
        [TestCase(Constants.ErrorCodes.OperationTimedOut)]
        public void IsRetriableResponse_CopySourceErrors_SecondaryUri(string errorCode)
        {
            var response = new MockResponse(Constants.HttpStatusCode.NotFound);
            response.AddHeader(new HttpHeader(Constants.HeaderNames.CopySourceErrorCode, errorCode));
            HttpMessage message = BuildMessage(response, MockSecondaryUri);
            Assert.IsTrue(classifier.IsRetriableResponse(message));
        }

        [TestCase("ContainerAlreadyExists", "If-Match", false)]
        [TestCase("ContainerAlreadyExists","If-None-Match", false)]
        [TestCase("ContainerAlreadyExists","If-Unmodified-Since", false)]
        [TestCase("ContainerAlreadyExists","If-Modified-Since", false)]
        [TestCase("BlobAlreadyExists", "If-Match", false)]
        [TestCase("BlobAlreadyExists", "If-None-Match", false)]
        [TestCase("BlobAlreadyExists", "If-Unmodified-Since", false)]
        [TestCase("BlobAlreadyExists", "If-Modified-Since", false)]
        [TestCase("InternalError", "If-Match", true)]
        [TestCase("BlobAlreadyExists", "Non-Conditional-Header", true)]
        public void IsError_409_ConditionalResponse(string code, string header, bool isError)
        {
            var mockRequest = new MockRequest();
            mockRequest.Headers.Add(header, "value");
            var httpMessage = new HttpMessage(mockRequest, new ResponseClassifier());

            var mockResponse = new MockResponse(409);
            mockResponse.AddHeader("x-ms-error-code", code);
            httpMessage.Response = mockResponse;

            Assert.AreEqual(isError, classifier.IsErrorResponse(httpMessage));
        }

        private HttpMessage BuildMessage(Response response, Uri secondaryUri = default)
        {
            return new HttpMessage(
                new MockRequest()
                {
                    Method = RequestMethod.Get
                },
                new StorageResponseClassifier()
                {
                    SecondaryStorageUri = secondaryUri
                })
            {
                Response = response
            };
        }
    }
}
