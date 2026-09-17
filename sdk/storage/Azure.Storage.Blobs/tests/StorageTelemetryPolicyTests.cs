// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    [TestFixture]
    public class StorageTelemetryPolicyTests
    {
        private static HttpMessage CreateMessage(MockTransport transport = null)
        {
            transport ??= new MockTransport(new MockResponse(200));
            HttpPipeline pipeline = new HttpPipeline(transport);
            return pipeline.CreateMessage();
        }

        [Test]
        public void OnSendingRequest_NoEncryptionProperty_DoesNotModifyUserAgent()
        {
            HttpMessage message = CreateMessage();
            string originalUserAgent = "azsdk-net-Storage.Blobs/12.0.0";
            message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, originalUserAgent);

            StorageTelemetryPolicy.Shared.OnSendingRequest(message);

            Assert.IsTrue(message.Request.Headers.TryGetValue(HttpHeader.Names.UserAgent, out string result));
            Assert.AreEqual(originalUserAgent, result);
        }

        [Test]
        public void OnSendingRequest_CseV2Property_PrependsV2Identifier()
        {
            HttpMessage message = CreateMessage();
            string originalUserAgent = "azsdk-net-Storage.Blobs/12.0.0";
            message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, originalUserAgent);
            message.SetProperty(Constants.ClientSideEncryption.HttpMessagePropertyKeyV2, true);

            StorageTelemetryPolicy.Shared.OnSendingRequest(message);

            Assert.IsTrue(message.Request.Headers.TryGetValue(HttpHeader.Names.UserAgent, out string result));
            Assert.AreEqual("azstorage-clientsideencryption/2.0 azsdk-net-Storage.Blobs/12.0.0", result);
        }

        [Test]
        public void OnSendingRequest_CseV1Property_PrependsV1Identifier()
        {
            HttpMessage message = CreateMessage();
            string originalUserAgent = "azsdk-net-Storage.Blobs/12.0.0";
            message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, originalUserAgent);
            message.SetProperty(Constants.ClientSideEncryption.HttpMessagePropertyKeyV1, true);

            StorageTelemetryPolicy.Shared.OnSendingRequest(message);

            Assert.IsTrue(message.Request.Headers.TryGetValue(HttpHeader.Names.UserAgent, out string result));
            Assert.AreEqual("azstorage-clientsideencryption/1.0 azsdk-net-Storage.Blobs/12.0.0", result);
        }

        [Test]
        public void OnSendingRequest_BothCseProperties_PrefersV2()
        {
            HttpMessage message = CreateMessage();
            string originalUserAgent = "azsdk-net-Storage.Blobs/12.0.0";
            message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, originalUserAgent);
            message.SetProperty(Constants.ClientSideEncryption.HttpMessagePropertyKeyV1, true);
            message.SetProperty(Constants.ClientSideEncryption.HttpMessagePropertyKeyV2, true);

            StorageTelemetryPolicy.Shared.OnSendingRequest(message);

            Assert.IsTrue(message.Request.Headers.TryGetValue(HttpHeader.Names.UserAgent, out string result));
            Assert.AreEqual("azstorage-clientsideencryption/2.0 azsdk-net-Storage.Blobs/12.0.0", result);
        }

        [Test]
        public void OnSendingRequest_CseV2Property_NoExistingUserAgent_SetsFeatureStringOnly()
        {
            HttpMessage message = CreateMessage();
            message.SetProperty(Constants.ClientSideEncryption.HttpMessagePropertyKeyV2, true);

            StorageTelemetryPolicy.Shared.OnSendingRequest(message);

            Assert.IsTrue(message.Request.Headers.TryGetValue(HttpHeader.Names.UserAgent, out string result));
            Assert.AreEqual("azstorage-clientsideencryption/2.0", result);
        }

        [Test]
        public void OnSendingRequest_CseV2Property_AlreadyContainsIdentifier_DoesNotDuplicate()
        {
            HttpMessage message = CreateMessage();
            string userAgent = "azstorage-clientsideencryption/2.0 azsdk-net-Storage.Blobs/12.0.0";
            message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, userAgent);
            message.SetProperty(Constants.ClientSideEncryption.HttpMessagePropertyKeyV2, true);

            StorageTelemetryPolicy.Shared.OnSendingRequest(message);

            Assert.IsTrue(message.Request.Headers.TryGetValue(HttpHeader.Names.UserAgent, out string result));
            Assert.AreEqual(userAgent, result);
        }

        [Test]
        public void Shared_ReturnsSameInstance()
        {
            StorageTelemetryPolicy instance1 = StorageTelemetryPolicy.Shared;
            StorageTelemetryPolicy instance2 = StorageTelemetryPolicy.Shared;

            Assert.AreSame(instance1, instance2);
        }
    }
}
