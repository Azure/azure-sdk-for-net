// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        private static string ComputeSignature(string accessKey, string connectionId)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(accessKey));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(connectionId));
            return "sha256=" + BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}
