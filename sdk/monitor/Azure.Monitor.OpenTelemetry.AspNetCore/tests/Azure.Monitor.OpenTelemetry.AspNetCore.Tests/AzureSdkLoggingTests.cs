// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System;
using System.Diagnostics.Tracing;
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
        [Fact]
        public async Task LogForwarderIsAddedLevelEnabled()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Logging.ClearProviders();
            builder.Logging.AddFilter((name, level) =>
            {
                if (name != null && name.StartsWith("Azure"))
                {
                    return level >= LogLevel.Information;
                }
                return false;
            });

            MockTransport transport = new MockTransport(new MockResponse(200).SetContent("ok"));
            builder.Services.AddOpenTelemetry().UseAzureMonitor(config =>
            {
                config.Transport = transport;
                config.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            });

            using var app = builder.Build();
            await app.StartAsync();

            using TestEventSource source = new TestEventSource();
            try
            {
                Assert.True(source.IsEnabled());
                source.LogTestInfoEvent("hello");

                WaitForRequest(transport);
            }
            finally
            {
                await app.StopAsync();
            }

            Assert.True(transport.Requests.Count > 0);
        }

        [Fact]
        public async Task PublicLogForwarderIsAdded()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Logging.ClearProviders();
            builder.Logging.AddFilter((name, level) =>
            {
                if (name != null && name.StartsWith("Azure"))
                {
                    return level >= LogLevel.Information;
                }
                return false;
            });

            builder.Services.TryAddSingleton<Microsoft.Extensions.Azure.AzureEventSourceLogForwarder>();
            MockTransport transport = new MockTransport(new MockResponse(200).SetContent("ok"));
            builder.Services.AddOpenTelemetry().UseAzureMonitor(config =>
            {
                config.Transport = transport;
                config.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            });

            using var app = builder.Build();
            Microsoft.Extensions.Azure.AzureEventSourceLogForwarder publicLogForwarder =
                app.Services.GetRequiredService<Microsoft.Extensions.Azure.AzureEventSourceLogForwarder>();
            Assert.NotNull(publicLogForwarder);
            publicLogForwarder.Start();
            await app.StartAsync();

            using TestEventSource source = new TestEventSource();
            try
            {
                Assert.True(source.IsEnabled());
                source.LogTestInfoEvent("hello");

                WaitForRequest(transport);
            }
            finally
            {
                await app.StopAsync();
            }

            Assert.True(transport.Requests.Count > 0);
        }

        private void WaitForRequest(MockTransport transport)
        {
            SpinWait.SpinUntil(
                condition: () =>
                {
                    Thread.Sleep(10);
                    return transport.Requests.Count > 0;
                },
                timeout: TimeSpan.FromSeconds(10));
        }

        internal class TestEventSource : AzureEventSource
        {
            private const string EventSourceName = "Azure-Test";
            internal const int TestInfoEvent = 1;
            internal const int TestTraceEvent = 2;
            public TestEventSource() : base(EventSourceName)
            {
            }

            [Event(TestInfoEvent, Level = EventLevel.Informational, Message = "TestInfoEvent: = {0}")]
            public void LogTestInfoEvent(string message)
            {
                WriteEvent(TestInfoEvent, message);
            }

            [Event(TestTraceEvent, Level = EventLevel.Informational, Message = "TestTraceEvent: = {0}")]
            public void LogTestTraceEvent(string message)
            {
                WriteEvent(TestTraceEvent, message);
            }
        }
    }
}
#endif
