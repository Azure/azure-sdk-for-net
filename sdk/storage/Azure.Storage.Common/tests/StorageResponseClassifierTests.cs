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
