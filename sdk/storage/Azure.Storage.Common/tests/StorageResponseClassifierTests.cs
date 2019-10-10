﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Storage.Common.Tests
{
    public class StorageResponseClassifierTests
    {
        private static readonly Uri MockPrimaryUri = new Uri("http://dummyaccount.blob.core.windows.net");
        private static readonly Uri MockSecondaryUri = new Uri("http://dummyaccount-secondary.blob.core.windows.net");
        private static readonly StorageResponseClassifier classifier = new StorageResponseClassifier(MockSecondaryUri);

        [Test]
        public void IsRetriableResponse_404OnSecondary_ShouldBeTrue()
        {
            HttpPipelineMessage message = BuildMessage(new MockResponse(Constants.HttpStatusCode.NotFound));
            message.Request.Uri.Host = MockSecondaryUri.Host;

            Assert.IsTrue(classifier.IsRetriableResponse(message));
        }

        [Test]
        [TestCase(500)]
        [TestCase(429)]
        [TestCase(503)]
        public void IsRetriableResponse_OtherStatusCodeOnSecondary_ShouldMatchBase(int statusCode)
        {
            HttpPipelineMessage message = BuildMessage(new MockResponse(statusCode));
            message.Request.Uri.Host = MockSecondaryUri.Host;

            Assert.AreEqual(new ResponseClassifier().IsRetriableResponse(message), classifier.IsRetriableResponse(message));
        }

        [Test]
        public void IsRetriableResponse_404OnPrimary_ShouldBeFalse()
        {
            HttpPipelineMessage message = BuildMessage(new MockResponse(Constants.HttpStatusCode.NotFound));
            message.Request.Uri.Host = MockPrimaryUri.Host;

            Assert.IsFalse(classifier.IsRetriableResponse(message));
        }

        private HttpPipelineMessage BuildMessage(Response response)
        {
            return new HttpPipelineMessage(
                new MockRequest()
                {
                    Method = RequestMethod.Get
                },
                new StorageResponseClassifier(MockSecondaryUri))
            {
                Response = response
            };
        }
    }
}
