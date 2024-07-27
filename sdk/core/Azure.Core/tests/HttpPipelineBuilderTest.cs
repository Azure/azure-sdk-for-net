// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Azure;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineBuilderTest : PolicyTestBase
    {
        [Theory]
        [TestCase(HttpPipelinePosition.PerCall, 1)]
        [TestCase(HttpPipelinePosition.PerRetry, 2)]
        [TestCase(HttpPipelinePosition.BeforeTransport, 2)]
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
        public async Task CustomPolicyOrdering()
        {
            bool perCallRan = false;
            bool perRetryRan = false;
            bool beforeTransportRan = false;

            var transport = new MockTransport(new MockResponse(200));
            var options = new TestOptions();

            options.AddPolicy(new CallbackPolicy(m =>
            {
                perCallRan = true;
                Assert.False(perRetryRan);
                Assert.False(beforeTransportRan);
            }), HttpPipelinePosition.PerCall);

            options.AddPolicy(new CallbackPolicy(m =>
            {
                perRetryRan = true;
                Assert.True(perCallRan);
                Assert.False(beforeTransportRan);
            }), HttpPipelinePosition.PerRetry);

            // Intentionally add some null policies to ensure it does not break indexing
            options.AddPolicy(null, HttpPipelinePosition.PerCall);
            options.AddPolicy(null, HttpPipelinePosition.PerRetry);
            options.AddPolicy(null, HttpPipelinePosition.BeforeTransport);

            options.AddPolicy(new CallbackPolicy(m =>
            {
                beforeTransportRan = true;
                Assert.True(perRetryRan);
                Assert.True(perCallRan);
            }), HttpPipelinePosition.BeforeTransport);

            options.Transport = transport;

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options);

            using Request request = transport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("http://example.com"));

            await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.True(perRetryRan);
            Assert.True(perCallRan);
            Assert.True(beforeTransportRan);
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
            var i = informationalVersion.IndexOf('+');
            if (i > 0)
            {
                informationalVersion = informationalVersion.Substring(0, i);
            }

            Assert.True(request.Headers.TryGetValue("User-Agent", out string value));
            StringAssert.StartsWith($"azsdk-net-Core.Tests/{informationalVersion} ", value);
        }

        [Test]
        public async Task UsesAssemblyNameAndInformationalVersionForTelemetryPolicySettingsWithSetTelemetryPackageInfo()
        {
            var transport = new MockTransport(new MockResponse(503), new MockResponse(200));
            var options = new TestOptions
            {
                Transport = transport
            };

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options);

            var message = pipeline.CreateMessage();
            var userAgent = new TelemetryDetails(typeof(string).Assembly, default);
            userAgent.Apply(message);
            using Request request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("http://example.com"));

            await pipeline.SendAsync(message, CancellationToken.None);

            var informationalVersion = typeof(string).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            var i = informationalVersion.IndexOf('+');
            if (i > 0)
            {
                informationalVersion = informationalVersion.Substring(0, i);
            }

            Assert.True(request.Headers.TryGetValue("User-Agent", out string value));
#if NETFRAMEWORK
            StringAssert.StartsWith($"azsdk-net-mscorlib/{informationalVersion} ", value);
#else
            StringAssert.StartsWith($"azsdk-net-System.Private.CoreLib/{informationalVersion} ", value);
#endif
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
                    Assert.AreEqual("ExternalClientId", message.Request.ClientRequestId);
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

        [Test]
        public void SetTransportOptions([Values(true, false)] bool isCustomTransportSet)
        {
            using var testListener = new TestEventListener();
            testListener.EnableEvents(AzureCoreEventSource.Singleton, EventLevel.Verbose);

            var transport = new MockTransport(new MockResponse(503), new MockResponse(200));
            var options = new TestOptions();
            if (isCustomTransportSet)
            {
                options.Transport = transport;
            }

            List<EventWrittenEventArgs> events = new();

            using var listener = new AzureEventSourceListener(
                events.Add,
                EventLevel.Verbose);

            var pipeline = HttpPipelineBuilder.Build(
                options,
                Array.Empty<HttpPipelinePolicy>(),
                Array.Empty<HttpPipelinePolicy>(),
                new HttpPipelineTransportOptions(),
                ResponseClassifier.Shared);

            HttpPipelineTransport transportField = pipeline.GetType().GetField("_transport", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField).GetValue(pipeline) as HttpPipelineTransport;
            if (isCustomTransportSet)
            {
                Assert.That(transportField, Is.TypeOf<MockTransport>());
                events.Any(
                    e => e.EventId == 23 &&
                         e.EventName == "PipelineTransportOptionsNotApplied" &&
                         e.GetProperty<string>("optionsType") == options.GetType().FullName);
            }
            else
            {
                Assert.That(transportField, Is.Not.TypeOf<MockTransport>());
            }
        }

        [Test]
        public async Task TransportOptionsIsClientRedirectEnabledIsOverriddenByClientOptions(
            [Values(true, false, null)] bool? transportOptionsIsClientRedirectEnabled)
        {
            using var testListener = new TestEventListener();
            testListener.EnableEvents(AzureCoreEventSource.Singleton, EventLevel.Verbose);

            var transport = new MockTransport(
                new MockResponse(300).AddHeader("Location", "https://new.host/"),
                new MockResponse(200));

            var options = new TestOptions
            {
                Transport = transport
            };

            var pipeline = HttpPipelineBuilder.Build(new HttpPipelineOptions(options)
            {
                ResponseClassifier = ResponseClassifier.Shared
            }, transportOptionsIsClientRedirectEnabled.HasValue ?
                new HttpPipelineTransportOptions() { IsClientRedirectEnabled = transportOptionsIsClientRedirectEnabled.Value } :
                new HttpPipelineTransportOptions());

            using (Request request = pipeline.CreateRequest())
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://example.com"));
                var response = await pipeline.SendRequestAsync(request, CancellationToken.None);

                if (transportOptionsIsClientRedirectEnabled ?? false)
                {
                    Assert.AreEqual(200, response.Status);
                    Assert.AreEqual(2, transport.Requests.Count);
                }
                else
                {
                    Assert.AreEqual(300, response.Status);
                    Assert.AreEqual(1, transport.Requests.Count);
                }
            }
        }

        [Test]
        public void CanPassNullPolicies([Values(true, false)] bool isCustomTransportSet)
        {
            var pipeline = HttpPipelineBuilder.Build(
                new TestOptions(),
                new HttpPipelinePolicy[] { null },
                new HttpPipelinePolicy[] { null },
                null);

            var message = pipeline.CreateMessage();
            pipeline.SendAsync(message, message.CancellationToken);
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

        private class CallbackPolicy : HttpPipelineSynchronousPolicy
        {
            private readonly Action<HttpMessage> _message;

            public CallbackPolicy(Action<HttpMessage> message)
            {
                _message = message;
            }

            public override void OnSendingRequest(HttpMessage message)
            {
                _message(message);
            }
        }
    }
}
