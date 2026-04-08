// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubRequestExtensionsTests
    {
        [Test]
        public async Task ReadWebPubSubRequestAsync_WhenValidationRequest_ReturnsPreflightTrue_WhenAllowed()
        {
            var access = new WebPubSubServiceAccess(new Uri("https://abc"), new KeyCredential("key"));
            var validator = new RequestValidator([access]);

            var request = TestHelpers.CreateHttpRequest("OPTIONS", "http://abc/api/test");

            var result = await request.ReadWebPubSubRequestAsync(validator);

            Assert.IsInstanceOf<PreflightRequest>(result);
            Assert.IsTrue(((PreflightRequest)result).IsValid);
        }

        [Test]
        public async Task ReadWebPubSubRequestAsync_WhenValidationRequest_ReturnsPreflightFalse_WhenNotAllowed()
        {
            var access = new WebPubSubServiceAccess(new Uri("https://abc"), new KeyCredential("key"));
            var validator = new RequestValidator([access]);

            var request = TestHelpers.CreateHttpRequest("OPTIONS", "http://zzz/api/test");

            var result = await request.ReadWebPubSubRequestAsync(validator);

            Assert.IsInstanceOf<PreflightRequest>(result);
            Assert.IsFalse(((PreflightRequest)result).IsValid);
        }

        [Test]
        public void ReadWebPubSubRequestAsync_WhenNotCloudEvents_ThrowsArgumentException()
        {
            var validator = new RequestValidator(null);
            var request = TestHelpers.CreateHttpRequest("POST", "http://localhost/api/test");

            Assert.ThrowsAsync<ArgumentException>(async () => await request.ReadWebPubSubRequestAsync(validator));
        }

        [Test]
        public void ReadWebPubSubRequestAsync_WhenSignatureInvalid_ThrowsUnauthorizedAccessException()
        {
            var accessKey = "test-access-key";
            var access = new WebPubSubServiceAccess(new Uri("https://localhost"), new KeyCredential(accessKey));
            var validator = new RequestValidator([access]);

            var headers = CreateCloudEventsHeaders(signature: "sha256=deadbeef");
            var request = TestHelpers.CreateHttpRequest("POST", "http://localhost/api/test", headers);

            Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await request.ReadWebPubSubRequestAsync(validator));
        }

        [Test]
        public async Task ReadWebPubSubRequestAsync_WhenSignatureValid_ReturnsConnectedEventRequest()
        {
            var accessKey = "test-access-key";
            var connectionId = "cid";
            var signature = ComputeSignature(accessKey, connectionId);

            var access = new WebPubSubServiceAccess(new Uri("https://localhost"), new KeyCredential(accessKey));
            var validator = new RequestValidator([access]);

            var headers = CreateCloudEventsHeaders(connectionId: connectionId, signature: signature, eventName: Constants.Events.ConnectedEvent);
            var request = TestHelpers.CreateHttpRequest("POST", "http://localhost/api/test", headers);

            var result = await request.ReadWebPubSubRequestAsync(validator);

            Assert.IsInstanceOf<ConnectedEventRequest>(result);
        }

        [Test]
        public async Task ReadWebPubSubRequestAsync_WhenIdentityCredential_SkipsSignatureValidation()
        {
            var config = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var tokenCredential = TestAzureComponentFactory.Instance.CreateTokenCredential(config);
            var access = new WebPubSubServiceAccess(new Uri("https://localhost"), new IdentityCredential(tokenCredential));
            var validator = new RequestValidator([access]);

            var headers = CreateCloudEventsHeaders(signature: "sha256=deadbeef", eventName: Constants.Events.ConnectedEvent);
            var request = TestHelpers.CreateHttpRequest("POST", "http://localhost/api/test", headers);

            var result = await request.ReadWebPubSubRequestAsync(validator);

            Assert.IsInstanceOf<ConnectedEventRequest>(result);
        }

        private static IHeaderDictionary CreateCloudEventsHeaders(
            string hub = "hub",
            string eventName = null,
            string connectionId = "cid",
            string signature = "sha256=sig")
        {
            eventName ??= Constants.Events.ConnectedEvent;

            return new HeaderDictionary
            {
                { Constants.Headers.CloudEvents.Hub, hub },
                { Constants.Headers.CloudEvents.Type, $"{Constants.Headers.CloudEvents.TypeSystemPrefix}{eventName}" },
                { Constants.Headers.CloudEvents.EventName, eventName },
                { Constants.Headers.CloudEvents.ConnectionId, connectionId },
                { Constants.Headers.CloudEvents.Signature, signature },
            };
        }

        [Test]
        public void DecodeConnectionStates_WhenNull_ReturnsNull()
        {
            string input = null;
            var result = input.DecodeConnectionStates();
            Assert.IsNull(result);
        }

        [Test]
        public void DecodeConnectionStates_WhenEmpty_ReturnsNull()
        {
            var result = "".DecodeConnectionStates();
            Assert.IsNull(result);
        }

        [Test]
        public void DecodeConnectionStates_WhenValidBase64Json_ReturnsDictionary()
        {
            // Use Encode to produce a valid base64 payload, then decode it
            var original = new Dictionary<string, object>
            {
                { "key1", BinaryData.FromString("value1") },
                { "key2", BinaryData.FromObjectAsJson(123) }
            };
            var base64 = original.EncodeConnectionStates();

            var result = base64.DecodeConnectionStates();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("value1", result["key1"].ToString());
            Assert.AreEqual(123, result["key2"].ToObjectFromJson<int>());
        }

        [Test]
        public void DecodeConnectionStates_WhenInvalidBase64_ReturnsEmptyDictionary()
        {
            var result = "not-valid-base64!!!".DecodeConnectionStates();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void DecodeConnectionStates_WhenBase64ButNotJson_ReturnsEmptyDictionary()
        {
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes("not json"));

            var result = base64.DecodeConnectionStates();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void DecodeConnectionStates_RoundTripsWithEncode()
        {
            var states = new Dictionary<string, object>
            {
                { "strKey", BinaryData.FromString("hello") },
                { "intKey", BinaryData.FromObjectAsJson(42) }
            };

            var encoded = states.EncodeConnectionStates();
            var decoded = encoded.DecodeConnectionStates();

            Assert.IsNotNull(decoded);
            Assert.AreEqual(2, decoded.Count);
            Assert.AreEqual("hello", decoded["strKey"].ToString());
            Assert.AreEqual(42, decoded["intKey"].ToObjectFromJson<int>());
        }

        private static string ComputeSignature(string accessKey, string connectionId)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(accessKey));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(connectionId));
            return "sha256=" + BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}
