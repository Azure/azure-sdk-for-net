// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class ExpectContinueTests
    {
        [Test]
        public void PolicyAddsHeaderOnContentBody([Values(true, false)] bool hasBody)
        {
            ExpectContinuePolicy policy = new();
            MockRequest request = new()
            {
                Content = hasBody ? RequestContent.Create("foo") : null
            };
            HttpMessage message = new(request, default);

            policy.OnSendingRequest(message);

            if (hasBody)
            {
                Assert.That(request.Headers.TryGetValue("Expect", out string value), Is.True);
                Assert.That(value, Is.EqualTo("100-continue"));
            }
            else
            {
                Assert.That(request.Headers.Contains("Expect"), Is.False);
            }
        }

        [TestCase(1024, 2048, true)]
        [TestCase(2048, 1024, false)]
        [TestCase(1024, 1024, true)]
        public void PolicyRespectsThreshold(int threshold, int bodyLength, bool expectHeader)
        {
            ExpectContinuePolicy policy = new()
            {
                ContentLengthThreshold = threshold
            };
            MockRequest request = new()
            {
                Content = RequestContent.Create(new Random().NextMemoryInline(bodyLength))
            };
            HttpMessage message = new(request, default);

            policy.OnSendingRequest(message);

            if (expectHeader)
            {
                Assert.That(request.Headers.TryGetValue("Expect", out string value), Is.True);
                Assert.That(value, Is.EqualTo("100-continue"));
            }
            else
            {
                Assert.That(request.Headers.Contains("Expect"), Is.False);
            }
        }

        [Test]
        public void ThrottlePolicyAddsHeaderOnlyAfterError([Values(429, 500, 503)] int errorStatusCode)
        {
            ExpectContinueOnThrottlePolicy policy = new();
            MockRequest MakeRequest() => new()
            {
                Content = RequestContent.Create(RequestContent.Create("foo"))
            };
            MockResponse responseOk = new(202);
            MockResponse responseError = new(errorStatusCode);

            // message1 doesn't get expect header
            HttpMessage message1 = new(MakeRequest(), null);
            policy.OnSendingRequest(message1);
            Assert.That(message1.Request.Headers.Contains("Expect"), Is.False);
            message1.Response = responseOk;
            policy.OnReceivedResponse(message1);

            // message2 doesn't get expect header but will trigger future messages
            HttpMessage message2 = new(MakeRequest(), null);
            policy.OnSendingRequest(message2);
            Assert.That(message2.Request.Headers.Contains("Expect"), Is.False);
            message2.Response = responseError;
            policy.OnReceivedResponse(message2);

            // message3 gets expect header
            HttpMessage message3 = new(MakeRequest(), null);
            policy.OnSendingRequest(message3);
            Assert.That(message3.Request.Headers.TryGetValue("Expect", out string value), Is.True);
            Assert.That(value, Is.EqualTo("100-continue"));
        }

        [TestCase(1024, 2048, true)]
        [TestCase(2048, 1024, false)]
        [TestCase(1024, 1024, true)]
        public void ThrottlePolicyRespectsThreshold(int threshold, int bodyLength, bool expectHeader)
        {
            Random r = new();
            ExpectContinueOnThrottlePolicy policy = new()
            {
                ContentLengthThreshold = threshold,
            };
            MockRequest MakeRequest() => new()
            {
                Content = RequestContent.Create(r.NextMemoryInline(bodyLength))
            };
            MockResponse responseError = new(429);

            // message1 doesn't get expect header but will trigger future messages
            HttpMessage message1 = new(MakeRequest(), null);
            policy.OnSendingRequest(message1);
            Assert.That(message1.Request.Headers.Contains("Expect"), Is.False);
            message1.Response = responseError;
            policy.OnReceivedResponse(message1);

            // message2 gets expect header
            HttpMessage message2 = new(MakeRequest(), null);
            policy.OnSendingRequest(message2);
            if (expectHeader)
            {
                Assert.That(message2.Request.Headers.TryGetValue("Expect", out string value), Is.True);
                Assert.That(value, Is.EqualTo("100-continue"));
            }
            else
            {
                Assert.That(message2.Request.Headers.Contains("Expect"), Is.False);
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/41368")]
        public async Task ThrottlePolicyRevertsAfterBackoff()
        {
            TimeSpan backoff = TimeSpan.FromMilliseconds(10);
            ExpectContinueOnThrottlePolicy policy = new()
            {
                ThrottleInterval = backoff,
            };
            MockRequest MakeRequest() => new()
            {
                Content = RequestContent.Create(RequestContent.Create("foo"))
            };
            MockResponse responseOk = new(202);
            MockResponse responseError = new(429);

            // message1 doesn't get expect header but will trigger future messages
            HttpMessage message1 = new(MakeRequest(), null);
            policy.OnSendingRequest(message1);
            Assert.That(message1.Request.Headers.Contains("Expect"), Is.False);
            message1.Response = responseError;
            policy.OnReceivedResponse(message1);

            // message2 gets expect header
            HttpMessage message2 = new(MakeRequest(), null);
            policy.OnSendingRequest(message2);
            Assert.That(message2.Request.Headers.TryGetValue("Expect", out string value), Is.True);
            Assert.That(value, Is.EqualTo("100-continue"));
            message1.Response = responseOk;
            policy.OnReceivedResponse(message2);

            // wait out policy backoff
            await Task.Delay(backoff);

            // message3 doesn't get expect header
            HttpMessage message3 = new(MakeRequest(), null);
            policy.OnSendingRequest(message3);
            Assert.That(message3.Request.Headers.Contains("Expect"), Is.False);
        }
    }
}
