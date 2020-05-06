// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineBuilderTest : PolicyTestBase
    {
        [Theory]
        [TestCase(HttpPipelinePosition.PerCall, 1)]
        [TestCase(HttpPipelinePosition.PerRetry, 2)]
        public async Task CanAddCustomPolicy(HttpPipelinePosition position, int expectedCount)
        {
            var policy = new CounterPolicy();
            var transport = new MockTransport(new MockResponse(503), new MockResponse(200));

            var options = new TestOptions();
            options.AddPolicy(policy, position);
            options.Transport = transport;

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options);

            using Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("http://example.com"));

            Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(expectedCount, policy.ExecutionCount);
        }

        [Test]
        public async Task UsesAssemblyNameAndInformationalVersionForTelemetryPolicySettings()
        {
            var transport = new MockTransport(new MockResponse(503), new MockResponse(200));
            var options = new TestOptions
            {
                Transport = transport
            };

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options);

            using Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("http://example.com"));

            await pipeline.SendRequestAsync(request, CancellationToken.None);

            var informationalVersion = typeof(TestOptions).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            informationalVersion = informationalVersion.Substring(0, informationalVersion.IndexOf('+'));

            Assert.True(request.Headers.TryGetValue("User-Agent", out string value));
            StringAssert.StartsWith($"azsdk-net-Core.Tests/{informationalVersion} ", value);
        }

        [Test]
        public async Task VersionDoesntHaveCommitHash()
        {
            var transport = new MockTransport(new MockResponse(200));
            var telemetryPolicy = HttpPipelineBuilder.CreateTelemetryPolicy(new TestOptions());

            await SendGetRequest(transport, telemetryPolicy);

            Assert.True(transport.SingleRequest.TryGetHeader("User-Agent", out var userAgent));
            StringAssert.IsMatch(Regex.Escape("azsdk-net-Core.Tests/") +
                                 "[.\\-0-9a-z]+" +
                                 Regex.Escape($" ({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})"), userAgent);
        }

        [Test]
        public async Task CustomClientRequestIdAvailableInPerCallPolicies()
        {
            var policy = new Mock<HttpPipelineSynchronousPolicy>();
            policy.CallBase = true;
            policy.Setup(p => p.OnSendingRequest(It.IsAny<HttpMessage>()))
                .Callback<HttpMessage>(message =>
                {
                    Assert.AreEqual("ExternalClientId",message.Request.ClientRequestId);
                    Assert.True(message.Request.TryGetHeader("x-ms-client-request-id", out string requestId));
                    Assert.AreEqual("ExternalClientId", requestId);
                }).Verifiable();

            var options = new TestOptions();
            options.Transport = new MockTransport(new MockResponse(200));
            options.AddPolicy(policy.Object, HttpPipelinePosition.PerCall);

            var pipeline = HttpPipelineBuilder.Build(options);
            using (Request request = pipeline.CreateRequest())
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://example.com"));
                request.Headers.Add("x-ms-client-request-id", "ExternalClientId");
                await pipeline.SendRequestAsync(request, CancellationToken.None);
            }

            policy.Verify();
        }

        [Test]
        public async Task CustomClientRequestIdSetInPerCallPolicyAppliedAsAHeader()
        {
            var policy = new Mock<HttpPipelineSynchronousPolicy>();
            policy.CallBase = true;
            policy.Setup(p => p.OnSendingRequest(It.IsAny<HttpMessage>()))
                .Callback<HttpMessage>(message =>
                {
                    message.Request.ClientRequestId = "MyPolicyClientId";
                }).Verifiable();

            var options = new TestOptions();
            var transport = new MockTransport(new MockResponse(200));
            options.Transport = transport;
            options.AddPolicy(policy.Object, HttpPipelinePosition.PerCall);

            var pipeline = HttpPipelineBuilder.Build(options);
            using (Request request = pipeline.CreateRequest())
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://example.com"));
                request.Headers.Add("x-ms-client-request-id", "ExternalClientId");
                await pipeline.SendRequestAsync(request, CancellationToken.None);
            }

            policy.Verify();

            Assert.True(transport.SingleRequest.Headers.TryGetValue("x-ms-client-request-id", out var value));
            Assert.AreEqual("MyPolicyClientId", value);
        }

        private class TestOptions : ClientOptions
        {
            public TestOptions()
            {
                Retry.Delay = TimeSpan.Zero;
            }
        }

        private class CounterPolicy : HttpPipelineSynchronousPolicy
        {
            public override void OnSendingRequest(HttpMessage message)
            {
                ExecutionCount++;
            }

            public int ExecutionCount { get; set; }
        }
    }
}
