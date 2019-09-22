﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Storage.Common.Tests
{
    public class GeoRedundantReadPolicyTests
    {
        private static readonly Uri MockPrimaryUri = new Uri("http://dummyaccount.blob.core.windows.net");
        private static readonly Uri MockSecondaryUri = new Uri("http://dummyaccount-secondary.blob.core.windows.net");

        [Test]
        public void OnSendingRequest_FirstTry_ShouldUsePrimary_ShouldSetAlternateToSecondary()
        {
            var message = new HttpPipelineMessage(
                CreateMockRequest(MockPrimaryUri),
                new StorageResponseClassifier(MockSecondaryUri));

            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockPrimaryUri.Host, message.Request.UriBuilder.Host);
            Assert.IsTrue(message.TryGetProperty(Constants.GeoRedundantRead.AlternateHostKey, out object val)
                && (string) val == MockSecondaryUri.Host);
        }

        [Test]
        public void OnSendingRequest_SecondTry_ShouldUseSecondary_ShouldSetAlternateToPrimary()
        {
            var message = new HttpPipelineMessage(
                CreateMockRequest(MockPrimaryUri),
                new StorageResponseClassifier(MockSecondaryUri));

            message.SetProperty(Constants.GeoRedundantRead.AlternateHostKey, MockSecondaryUri.Host);
            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockSecondaryUri.Host, message.Request.UriBuilder.Host);
            Assert.IsTrue(message.TryGetProperty(Constants.GeoRedundantRead.AlternateHostKey, out object val)
                && (string)val == MockPrimaryUri.Host);
        }

        [Test]
        public void OnSendingRequest_ThirdTry_ShouldUsePrimary_ShouldSetAlternateToSecondary()
        {
            var message = new HttpPipelineMessage(
                CreateMockRequest(MockSecondaryUri),
                new StorageResponseClassifier(MockSecondaryUri));

            message.SetProperty(Constants.GeoRedundantRead.AlternateHostKey, MockPrimaryUri.Host);
            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockPrimaryUri.Host, message.Request.UriBuilder.Host);
            Assert.IsTrue(message.TryGetProperty(Constants.GeoRedundantRead.AlternateHostKey, out object val)
                && (string)val == MockSecondaryUri.Host);
        }

        [Test]
        public void OnSendingRequest_404onSecondary_ShouldSetNotFoundFlag_ShouldUsePrimary()
        {
            var message = new HttpPipelineMessage(
                CreateMockRequest(MockSecondaryUri),
                new StorageResponseClassifier(MockSecondaryUri))

            {
                Response = new MockResponse(Constants.HttpStatusCode.NotFound)
            };
            message.SetProperty(Constants.GeoRedundantRead.AlternateHostKey, MockSecondaryUri.Host);
            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockSecondaryUri.Host, message.Request.UriBuilder.Host);
            Assert.IsTrue(message.TryGetProperty(Constants.GeoRedundantRead.ResourceNotReplicated, out object val)
                && (bool) val);
        }

        [Test]
        public void OnSendingRequest_404FlagSet_ShouldUsePrimary()
        {
            var message = new HttpPipelineMessage(
                CreateMockRequest(MockPrimaryUri),
                new StorageResponseClassifier(MockSecondaryUri));

            message.SetProperty(Constants.GeoRedundantRead.AlternateHostKey, MockSecondaryUri.Host);
            message.SetProperty(Constants.GeoRedundantRead.ResourceNotReplicated, true);
            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockPrimaryUri.Host, message.Request.UriBuilder.Host);
        }

        [Test]
        public void OnSendingRequest_PutRequest_ShouldIgnore()
        {
            MockRequest request = CreateMockRequest(MockPrimaryUri);
            request.Method = RequestMethod.Put;
            var message = new HttpPipelineMessage(
                request,
                new StorageResponseClassifier(MockSecondaryUri));

            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockPrimaryUri.Host, message.Request.UriBuilder.Host);
            Assert.IsFalse(message.TryGetProperty(Constants.GeoRedundantRead.AlternateHostKey, out object val)
                && (string)val == MockSecondaryUri.Host);
        }

        private MockRequest CreateMockRequest(Uri uri)
        {
            MockRequest mockRequest = new MockRequest();
            mockRequest.UriBuilder.Uri = uri;
            mockRequest.Method = RequestMethod.Get;
            return mockRequest;
        }

    }
}
