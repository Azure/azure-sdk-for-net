// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests.Shared;
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
            MockTransport transport = new(new(202), new(errorStatusCode), new(202));
            HttpPipeline pipeline = new(transport, new HttpPipelinePolicy[] { policy });
            ResponseClassifier classifier = new StorageResponseClassifier();

            MockRequest MakeRequest() => new()
            {
                Content = RequestContent.Create(RequestContent.Create("foo"))
            };

            // message1 doesn't get expect header
            HttpMessage message1 = new(MakeRequest(), classifier);
            pipeline.Send(message1, default);
            Assert.That(message1.Request.Headers.Contains("Expect"), Is.False);

            // message2 doesn't get expect header but will trigger future messages
            HttpMessage message2 = new(MakeRequest(), classifier);
            pipeline.Send(message2, default);
            Assert.That(message2.Request.Headers.Contains("Expect"), Is.False);

            // message3 gets expect header
            HttpMessage message3 = new(MakeRequest(), classifier);
            pipeline.Send(message3, default);
            Assert.That(message3.Request.Headers.TryGetValue("Expect", out string value), Is.True);
            Assert.That(value, Is.EqualTo("100-continue"));
        }

        [Test]
        public void ThrottlePolicyAddsHeader_RST()
        {
            // Mocked requsest/response
            MockResponse responseOk = new(202);

            MockRequest MakeRequest() => new()
            {
                Content = RequestContent.Create("foo")
            };
            MockRequest MakeRequest_RST() => new()
            {
                Content = RequestContent.Create(new FaultyStream(
                    new RepeatingStream(17, 5000, true),
                    500,
                    1,
                    new SocketException((int)SocketError.ConnectionReset),
                    onFault: () => { })),
            };
            MockResponse MakeResponse(MockRequest request)
            {
                request.Content.WriteTo(Stream.Null, default);
                return responseOk;
            };

            MockTransport transport = new MockTransport(MakeResponse);

            ExpectContinueOnThrottlePolicy policy = new();
            ResponseClassifier classifier = new StorageResponseClassifier();
            HttpPipeline pipeline = new(transport, new HttpPipelinePolicy[] { policy });

            HttpMessage message1 = new(MakeRequest_RST(), classifier);
            Assert.That(() => pipeline.Send(message1, default), Throws.TypeOf<SocketException>());
            Assert.That(message1.Request.Headers.Contains("Expect"), Is.False);

            HttpMessage message2 = new(MakeRequest(), classifier);
            pipeline.Send(message2, default);

            Assert.That(message2.Request.Headers.Contains("Expect"), Is.True);
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
            MockTransport transport = new(req => new MockResponse(429));
            HttpPipeline pipeline = new(transport, new HttpPipelinePolicy[] { policy });
            ResponseClassifier classifier = new StorageResponseClassifier();

            MockRequest MakeRequest() => new()
            {
                Content = RequestContent.Create(r.NextMemoryInline(bodyLength))
            };

            // message1 doesn't get expect header but will trigger future messages
            HttpMessage message1 = new(MakeRequest(), classifier);
            pipeline.Send(message1, default);
            Assert.That(message1.Request.Headers.Contains("Expect"), Is.False);

            // message2 gets expect header if body meets threshold
            HttpMessage message2 = new(MakeRequest(), classifier);
            pipeline.Send(message2, default);
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
        public async Task ThrottlePolicyRevertsAfterBackoff()
        {
            TimeSpan backoff = TimeSpan.FromMilliseconds(10);
            ExpectContinueOnThrottlePolicy policy = new()
            {
                ThrottleInterval = backoff,
            };
            MockTransport transport = new(new(429), new(202), new(202));
            HttpPipeline pipeline = new(transport, new HttpPipelinePolicy[] { policy });
            ResponseClassifier classifier = new StorageResponseClassifier();

            MockRequest MakeRequest() => new()
            {
                Content = RequestContent.Create(RequestContent.Create("foo"))
            };
            MockResponse responseOk = new(202);
            MockResponse responseError = new(429);

            // message1 doesn't get expect header but will trigger future messages
            HttpMessage message1 = new(MakeRequest(), classifier);
            pipeline.Send(message1, default);
            Assert.That(message1.Request.Headers.Contains("Expect"), Is.False);

            // message2 gets expect header
            HttpMessage message2 = new(MakeRequest(), classifier);
            pipeline.Send(message2, default);
            Assert.That(message2.Request.Headers.TryGetValue("Expect", out string value), Is.True);
            Assert.That(value, Is.EqualTo("100-continue"));

            // wait out policy backoff
            await Task.Delay(backoff);

            // message3 doesn't get expect header
            HttpMessage message3 = new(MakeRequest(), classifier);
            pipeline.Send(message3, default);
            Assert.That(message3.Request.Headers.Contains("Expect"), Is.False);
        }
    }
}
