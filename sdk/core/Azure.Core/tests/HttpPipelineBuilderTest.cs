// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
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

            Assert.True(request.Headers.TryGetValue("User-Agent", out string value));
            StringAssert.StartsWith($"azsdk-net-Core.Tests/{informationalVersion} ", value);
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
