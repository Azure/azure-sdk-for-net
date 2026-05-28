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
    public class GeoRedundantReadPolicyTests
    {
        private static readonly Uri MockPrimaryUri = new Uri("http://dummyaccount.blob.core.windows.net");
        private static readonly Uri MockSecondaryUri = new Uri("http://dummyaccount-secondary.blob.core.windows.net");

        [Test]
        public void OnSendingRequest_FirstTry_ShouldUsePrimary_ShouldSetAlternateToSecondary()
        {
            var message = new HttpMessage(
                CreateMockRequest(MockPrimaryUri),
                new StorageResponseClassifier()
                {
                    SecondaryStorageUri = MockSecondaryUri
                });

            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockPrimaryUri.Host, message.Request.Uri.Host);
            Assert.IsTrue(message.TryGetProperty(Constants.GeoRedundantRead.AlternateHostKey, out object val)
                && (string) val == MockSecondaryUri.Host);
        }

        [Test]
        public void OnSendingRequest_SecondTry_ShouldUseSecondary_ShouldSetAlternateToPrimary()
        {
            var message = new HttpMessage(
                CreateMockRequest(MockPrimaryUri),
                new StorageResponseClassifier()
                {
                    SecondaryStorageUri = MockSecondaryUri
                });

            message.SetProperty(Constants.GeoRedundantRead.AlternateHostKey, MockSecondaryUri.Host);
            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockSecondaryUri.Host, message.Request.Uri.Host);
            Assert.IsTrue(message.TryGetProperty(Constants.GeoRedundantRead.AlternateHostKey, out object val)
                && (string)val == MockPrimaryUri.Host);
        }

        [Test]
        public void OnSendingRequest_ThirdTry_ShouldUsePrimary_ShouldSetAlternateToSecondary()
        {
            var message = new HttpMessage(
                CreateMockRequest(MockSecondaryUri),
                new StorageResponseClassifier()
                {
                    SecondaryStorageUri = MockSecondaryUri
                });

            message.SetProperty(Constants.GeoRedundantRead.AlternateHostKey, MockPrimaryUri.Host);
            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockPrimaryUri.Host, message.Request.Uri.Host);
            Assert.IsTrue(message.TryGetProperty(Constants.GeoRedundantRead.AlternateHostKey, out object val)
                && (string)val == MockSecondaryUri.Host);
        }

        [Test]
        public void OnSendingRequest_404onSecondary_ShouldSetNotFoundFlag_ShouldUsePrimary()
        {
            var message = new HttpMessage(
                CreateMockRequest(MockSecondaryUri),
                new StorageResponseClassifier()
                {
                    SecondaryStorageUri = MockSecondaryUri
                })
                {
                    Response = new MockResponse(Constants.HttpStatusCode.NotFound)
                };
            message.SetProperty(Constants.GeoRedundantRead.AlternateHostKey, MockSecondaryUri.Host);
            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockSecondaryUri.Host, message.Request.Uri.Host);
            Assert.IsTrue(message.TryGetProperty(Constants.GeoRedundantRead.ResourceNotReplicated, out object val)
                && (bool) val);
        }

        [Test]
        public void OnSendingRequest_404FlagSet_ShouldUsePrimary()
        {
            var message = new HttpMessage(
                CreateMockRequest(MockPrimaryUri),
                new StorageResponseClassifier()
                {
                    SecondaryStorageUri = MockSecondaryUri
                });

            message.SetProperty(Constants.GeoRedundantRead.AlternateHostKey, MockSecondaryUri.Host);
            message.SetProperty(Constants.GeoRedundantRead.ResourceNotReplicated, true);
            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockPrimaryUri.Host, message.Request.Uri.Host);
        }

        [Test]
        public void OnSendingRequest_PutRequest_ShouldIgnore()
        {
            MockRequest request = CreateMockRequest(MockPrimaryUri);
            request.Method = RequestMethod.Put;
            var message = new HttpMessage(
                request,
                new StorageResponseClassifier()
                {
                    SecondaryStorageUri = MockSecondaryUri
                });

            var policy = new GeoRedundantReadPolicy(MockSecondaryUri);

            policy.OnSendingRequest(message);

            Assert.AreEqual(MockPrimaryUri.Host, message.Request.Uri.Host);
            Assert.IsFalse(message.TryGetProperty(Constants.GeoRedundantRead.AlternateHostKey, out object val)
                && (string)val == MockSecondaryUri.Host);
        }

        private MockRequest CreateMockRequest(Uri uri)
        {
            MockRequest mockRequest = new MockRequest();
            mockRequest.Uri.Reset(uri);
            mockRequest.Method = RequestMethod.Get;
            return mockRequest;
        }
    }
}
