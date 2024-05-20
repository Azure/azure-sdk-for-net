﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    public class AzureSdkLoggingTests
    {
        [Theory]
        [InlineData(LogLevel.Information, "TestInfoEvent: hello")]
        [InlineData(LogLevel.Warning, "TestWarningEvent: hello")]
        [InlineData(LogLevel.Debug, null)]
        public async Task DistroLogForwarderIsAdded(LogLevel eventLevel, string expectedMessage)
        {
            var builder = WebApplication.CreateBuilder();
            var transport = new MockTransport(_ => new MockResponse(200).SetContent("ok"));
            SetUpOTelAndLogging(builder, transport, LogLevel.Information);

            using var app = builder.Build();
            await app.StartAsync();

            using TestEventSource source = new TestEventSource();
            Assert.True(source.IsEnabled());
            source.LogMessage("hello", eventLevel);
            WaitForRequest(transport);
            if (expectedMessage != null)
            {
                Assert.Single(transport.Requests);
                await AssertContentContains(transport.Requests.Single(), expectedMessage, eventLevel);
            }
            else
            {
                await AssertContentDoesNotContain(transport.Requests, "hello");
            }
        }

        [Theory]
        [InlineData(LogLevel.Information, "TestInfoEvent: hello")]
        [InlineData(LogLevel.Warning, "TestWarningEvent: hello")]
        [InlineData(LogLevel.Debug, null)]
        public async Task PublicLogForwarderIsAdded(LogLevel eventLevel, string expectedMessage)
        {
            var builder = WebApplication.CreateBuilder();
            var transport = new MockTransport(_ => new MockResponse(200).SetContent("ok"));
            SetUpOTelAndLogging(builder, transport, LogLevel.Information);

            builder.Services.TryAddSingleton<Microsoft.Extensions.Azure.AzureEventSourceLogForwarder>();
            using var app = builder.Build();

            Microsoft.Extensions.Azure.AzureEventSourceLogForwarder publicLogForwarder =
                app.Services.GetRequiredService<Microsoft.Extensions.Azure.AzureEventSourceLogForwarder>();

            Assert.NotNull(publicLogForwarder);
            publicLogForwarder.Start();

            await app.StartAsync();

            using TestEventSource source = new TestEventSource();
            Assert.True(source.IsEnabled());
            source.LogMessage("hello", eventLevel);

            WaitForRequest(transport);
            if (expectedMessage != null)
            {
                Assert.Single(transport.Requests);
                await AssertContentContains(transport.Requests.Single(), expectedMessage, eventLevel);
            }
            else
            {
                await AssertContentDoesNotContain(transport.Requests, "hello");
            }
        }

        [Fact]
        public async Task SelfDiagnosticsIsDisabled()
        {
            var enableLevel = LogLevel.Debug;

            var builder = WebApplication.CreateBuilder();
            var transport = new MockTransport(_ => new MockResponse(200).SetContent("ok"));
            builder.Logging.ClearProviders();
            bool logAzureFilterCalled = false;
            builder.Logging.AddFilter((name, level) =>
            {
                if (name != null && name.StartsWith("Azure"))
                {
                    logAzureFilterCalled = true;
                    return level >= enableLevel;
                }
                return false;
            });
            builder.Services.AddOpenTelemetry().UseAzureMonitor(config =>
            {
                config.Transport = transport;
                config.ConnectionString = $"InstrumentationKey={Guid.NewGuid()}";
                config.EnableLiveMetrics = true;
                Assert.False(config.Diagnostics.IsLoggingEnabled);
                Assert.False(config.Diagnostics.IsDistributedTracingEnabled);
            });

            using var app = builder.Build();
            await app.StartAsync();

            // let's get some live metric requests first to check that no logs were recorded for them
            WaitForRequest(transport, r => r.Uri.Host == "rt.services.visualstudio.com");

            // now let's wait for track requests
            var trackRequests = WaitForRequest(transport, r => r.Uri.Host == "dc.services.visualstudio.com");
            Assert.Empty(trackRequests);

            // since LiveMetrics logging is disabled, we shouldn't even have logging policy trying to log anything.
            Assert.False(logAzureFilterCalled);
        }

        private IEnumerable<MockRequest> WaitForRequest(MockTransport transport, Func<MockRequest, bool>? filter = null)
        {
            filter = filter ?? (_ => true);
            SpinWait.SpinUntil(
                condition: () =>
                {
                    Thread.Sleep(10);
                    return transport.Requests.Where(filter).Any();
                },
                timeout: TimeSpan.FromSeconds(10));

            return transport.Requests.Where(filter);
        }

        private static async Task<string> AssertContentContains(MockRequest request, string expectedMessage, LogLevel expectedLevel)
        {
            using var contentStream = new MemoryStream();
            await request.Content.WriteToAsync(contentStream, default);
            contentStream.Position = 0;
            var content = BinaryData.FromStream(contentStream).ToString();
            var jsonMessage = $"\"message\":\"{expectedMessage}\"";
            var jsonLevel = $"\"severityLevel\":\"{expectedLevel}\"";
            Assert.Contains(jsonMessage, content);
            Assert.Contains(jsonLevel, content);

            // also check that message appears just once
            Assert.Equal(content.IndexOf(jsonMessage), content.LastIndexOf(jsonMessage));
            return content;
        }

        private static async Task AssertContentDoesNotContain(List<MockRequest> requests, string expectedMessage)
        {
            foreach (var request in requests)
            {
                using var contentStream = new MemoryStream();
                await request.Content.WriteToAsync(contentStream, default);
                contentStream.Position = 0;
                var content = BinaryData.FromStream(contentStream).ToString();
                Console.WriteLine(content);

                Assert.DoesNotContain(expectedMessage, content);
            }
        }

        private static void SetUpOTelAndLogging(WebApplicationBuilder builder, MockTransport transport, LogLevel enableLevel)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddFilter((name, level) =>
            {
                if (name != null && name.StartsWith("Azure"))
                {
                    return level >= enableLevel;
                }
                return false;
            });

            builder.Services.AddOpenTelemetry().UseAzureMonitor(config =>
            {
                config.Transport = transport;
                config.ConnectionString = $"InstrumentationKey={Guid.NewGuid()}";
                config.EnableLiveMetrics = false;
            });
        }

        internal class TestEventSource : AzureEventSource
        {
            private const string EventSourceName = "Azure-Test";
            public TestEventSource() : base(EventSourceName)
            {
            }

            [Event(1, Level = EventLevel.Informational, Message = "TestInfoEvent: {0}")]
            public void LogTestInfoEvent(string message)
            {
                WriteEvent(1, message);
            }

            [Event(2, Level = EventLevel.Verbose, Message = "TestVerboseEvent: {0}")]
            public void LogTestVerboseEvent(string message)
            {
                WriteEvent(2, message);
            }

            [Event(3, Level = EventLevel.Warning, Message = "TestWarningEvent: {0}")]
            public void LogTestWarningEvent(string message)
            {
                WriteEvent(3, message);
            }

            public void LogMessage(string message, LogLevel level)
            {
                switch (level)
                {
                    case LogLevel.Warning:
                        LogTestWarningEvent(message);
                        break;
                    case LogLevel.Information:
                        LogTestInfoEvent(message);
                        break;
                    case LogLevel.Debug:
                        LogTestVerboseEvent(message);
                        break;
                    default:
                        Assert.Fail("Log level is not supported");
                        break;
                }
            }
        }
    }
}
#endif
