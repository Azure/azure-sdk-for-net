// Copyright (c) Microsoft Corporation. All rights reserved.
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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using Xunit;
using static Xunit.CustomXunitAttributes;

using AzureLogForwarder = Microsoft.Extensions.Azure.AzureEventSourceLogForwarder;
using InternalLogForwarder = Azure.Monitor.OpenTelemetry.AspNetCore.Internals.AzureSdkCompat.AzureEventSourceLogForwarder;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    public class AzureSdkLoggingTests
    {
        private readonly MockTransport _mockTransport = new MockTransport(_ => new MockResponse(200).SetContent("ok"));

#if NET6_0
        [ConditionallySkipOSTheory(platformToSkip: "macos", reason: "This test consistently exceeds 1 hour runtime limit when running on MacOS & Net60")]
#else
        [Theory]
#endif
        [InlineData(false, LogLevel.Debug, null)]
        [InlineData(false, LogLevel.Information, null)]
        [InlineData(false, LogLevel.Warning, "TestWarningEvent: hello")]
        [InlineData(true, LogLevel.Information, "TestInfoEvent: hello")]
        [InlineData(true, LogLevel.Warning, "TestWarningEvent: hello")]
        [InlineData(true, LogLevel.Debug, "TestVerboseEvent: hello")]
        public async Task DistroLogForwarderIsAdded(bool addLoggingFilter, LogLevel eventLevel, string expectedMessage)
        {
            var serviceCollection = new ServiceCollection();
            //var builder = WebApplication.CreateBuilder();
            using TestEventSource source = new TestEventSource(addLoggingFilter ? "Azure-LoggingFilter" : "Azure-Test");

            //if (addLoggingFilter)
            //{
            //    builder.Logging.AddFilter(source.Name.Replace('-', '.'), eventLevel);
            //}

            var transport = new MockTransport(_ => new MockResponse(200).SetContent("ok"));
            SetUpOTelAndLogging(serviceCollection, transport, LogLevel.Information, (loggingBuilder) => {
                if (addLoggingFilter)
                {
                    loggingBuilder.AddFilter(source.Name.Replace('-', '.'), eventLevel);
                }
                });

            //using var app = builder.Build();
            //await app.StartAsync();
            using var serviceProvider = serviceCollection.BuildServiceProvider();

            // We must manually start any IHostedServices. This includes the AzureLogForwarder.
            // In a normal app, Microsoft.Extensions.Hosting would handle this.
            var hostedServices = serviceProvider.GetServices<IHostedService>();
            foreach (var hostedService in hostedServices)
            {
                await hostedService.StartAsync(CancellationToken.None);
            }

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

#if NET6_0
        [ConditionallySkipOSTheory(platformToSkip: "macos", reason: "This test consistently exceeds 1 hour runtime limit when running on MacOS & Net60")]
#else
        [Theory]
#endif
        [InlineData(LogLevel.Information, "TestInfoEvent: hello")]
        [InlineData(LogLevel.Warning, "TestWarningEvent: hello")]
        [InlineData(LogLevel.Debug, null)]
        public async Task PublicLogForwarderIsAdded(LogLevel eventLevel, string expectedMessage)
        {
            var serviceCollection = new ServiceCollection();
            var transport = new MockTransport(_ => new MockResponse(200).SetContent("ok"));
            SetUpOTelAndLogging(serviceCollection, transport, LogLevel.Information);

            serviceCollection.TryAddSingleton<AzureLogForwarder>();

            using var serviceProvider = serviceCollection.BuildServiceProvider();

            var logForwarder = serviceProvider.GetRequiredService<AzureLogForwarder>();

            Assert.NotNull(logForwarder);
            logForwarder.Start();

            using TestEventSource source = new TestEventSource("Azure-Test");
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

#if NET6_0
        [ConditionallySkipOSFact(platformToSkip: "macos", reason: "This test consistently exceeds 1 hour runtime limit when running on MacOS & Net60")]
#else
        [Fact]
#endif
        public void SelfDiagnosticsIsDisabled()
        {
            bool logAzureFilterCalled = false;
            var enableLevel = LogLevel.Debug;

            var serviceCollection = new ServiceCollection();
            //var builder = WebApplication.CreateBuilder();

            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddFilter((name, level) =>
                {
                    if (name != null && name.StartsWith("Azure"))
                    {
                        logAzureFilterCalled = true;
                        return level >= enableLevel;
                    }
                    return false;
                });
            });

            var transport = new MockTransport(_ => new MockResponse(200).SetContent("ok"));
            serviceCollection.AddOpenTelemetry().UseAzureMonitor(config =>
            {
                config.Transport = transport;
                config.ConnectionString = $"InstrumentationKey={Guid.NewGuid()}";
                config.EnableLiveMetrics = true;
                Assert.False(config.Diagnostics.IsLoggingEnabled);
                Assert.False(config.Diagnostics.IsDistributedTracingEnabled);
            });

            //using var app = builder.Build();
            //await app.StartAsync();
            using var serviceProvider = serviceCollection.BuildServiceProvider();

            // let's get some live metric requests first to check that no logs were recorded for them
            WaitForRequest(transport, r => r.Uri.Host == "rt.services.visualstudio.com"); // TODO: WHY IS THIS NECESSARY? THERE ARE NO ASSERTS HERE.

            // now let's wait for track requests
            var trackRequests = WaitForRequest(transport, r => r.Uri.Host == "dc.services.visualstudio.com");
            Assert.Empty(trackRequests);

            // since LiveMetrics logging is disabled, we shouldn't even have logging policy trying to log anything.
            Assert.False(logAzureFilterCalled);
        }

#if NET6_0
        [ConditionallySkipOSFact(platformToSkip: "macos", reason: "This test consistently exceeds 1 hour runtime limit when running on MacOS & Net60")]
#else
        [Fact]
#endif
        public async Task DistroLogForwarderAppliesWildCardFilter()
        {
            var serviceCollection = new ServiceCollection();
            //var builder = WebApplication.CreateBuilder();
            //builder.Logging.AddFilter("Azure.*", LogLevel.Warning);

            var transport = new MockTransport(_ => new MockResponse(200).SetContent("ok"));
            SetUpOTelAndLogging(serviceCollection, transport, LogLevel.Information, (loggingBuilder) => loggingBuilder.AddFilter("Azure.*", LogLevel.Warning));

            //using var app = builder.Build();
            //await app.StartAsync();
            using var serviceProvider = serviceCollection.BuildServiceProvider();

            // We must manually start any IHostedServices. This includes the AzureLogForwarder.
            // In a normal app, Microsoft.Extensions.Hosting would handle this.
            var hostedServices = serviceProvider.GetServices<IHostedService>();
            foreach (var hostedService in hostedServices)
            {
                await hostedService.StartAsync(CancellationToken.None);
            }

            using TestEventSource source = new TestEventSource("Azure-Test");
            Assert.True(source.IsEnabled());
            source.LogMessage("hello", LogLevel.Warning);
            WaitForRequest(transport);

            Assert.Single(transport.Requests);
            await AssertContentContains(transport.Requests.Single(), "TestWarningEvent: hello", LogLevel.Warning);
        }

#if NET6_0
        [ConditionallySkipOSFact(platformToSkip: "macos", reason: "This test consistently exceeds 1 hour runtime limit when running on MacOS & Net60")]
#else
        [Fact]
#endif
        public async Task SettingCustomLoggingFilterResetsDefaultWarningLevel()
        {
            var serviceCollection = new ServiceCollection();
            //var builder = WebApplication.CreateBuilder();
            // Even when a single custom filter is set, it should reset the default warning level.
            //builder.Logging.AddFilter("Azure.One", LogLevel.Information);

            var transport = new MockTransport(_ => new MockResponse(200).SetContent("ok"));
            SetUpOTelAndLogging(serviceCollection, transport, LogLevel.Information, (loggingBuilder) => loggingBuilder.AddFilter("Azure.One", LogLevel.Information));

            //using var app = builder.Build();
            //await app.StartAsync();
            using var serviceProvider = serviceCollection.BuildServiceProvider();

            // We must manually start any IHostedServices. This includes the AzureLogForwarder.
            // In a normal app, Microsoft.Extensions.Hosting would handle this.
            var hostedServices = serviceProvider.GetServices<IHostedService>();
            foreach (var hostedService in hostedServices)
            {
                await hostedService.StartAsync(CancellationToken.None);
            }

            // Azure-One is added as a logging filter, the default warning level is reset.
            // Informational-level logs from Azure-One sources are collected.
            using TestEventSource source1 = new TestEventSource("Azure-One");
            Assert.True(source1.IsEnabled());

            source1.LogMessage("hello one", LogLevel.Information);
            WaitForRequest(transport);
            Assert.Single(transport.Requests);
            await AssertContentContains(transport.Requests.Single(), "TestInfoEvent: hello one", LogLevel.Information);
            transport.Requests.Clear();

            // Azure-Two is not part of the logging filter.
            // Since the logging filter is customized for the Azure SDK, the default warning level is reset.
            // Informational-level logs from Azure-Two sources are collected.
            using TestEventSource source2 = new TestEventSource("Azure-Two");
            Assert.True(source2.IsEnabled());

            source2.LogMessage("hello two", LogLevel.Information);
            WaitForRequest(transport);
            Assert.Single(transport.Requests);
            await AssertContentContains(transport.Requests.Single(), "TestInfoEvent: hello two", LogLevel.Information);
        }

#if NET6_0
        [ConditionallySkipOSFact(platformToSkip: "macos", reason: "This test consistently exceeds 1 hour runtime limit when running on MacOS & Net60")]
#else
        [Fact]
#endif
        public async Task CustomLoggingFilterOverridesDefaultWarningAndCapturesErrorLogs()
        {
            var serviceCollection = new ServiceCollection();
            //var builder = WebApplication.CreateBuilder();
            // Even when a single custom filter is set, it should reset the default warning level.
            //builder.Logging.AddFilter("Azure.One", LogLevel.Error);

            var transport = new MockTransport(_ => new MockResponse(200).SetContent("ok"));
            SetUpOTelAndLogging(serviceCollection, transport, LogLevel.Information, (loggingBuilder) => loggingBuilder.AddFilter("Azure.One", LogLevel.Error));

            //using var app = builder.Build();
            //await app.StartAsync();
            using var serviceProvider = serviceCollection.BuildServiceProvider();

            // We must manually start any IHostedServices. This includes the AzureLogForwarder.
            // In a normal app, Microsoft.Extensions.Hosting would handle this.
            var hostedServices = serviceProvider.GetServices<IHostedService>();
            foreach (var hostedService in hostedServices)
            {
                await hostedService.StartAsync(CancellationToken.None);
            }

            using TestEventSource source1 = new TestEventSource("Azure-One");
            Assert.True(source1.IsEnabled());

            // Only log level with errors should be captured as it is set in the logging filter.
            source1.LogMessage("Hello Information", LogLevel.Information);
            source1.LogMessage("Hello Debug", LogLevel.Debug);
            source1.LogMessage("Hello Warning", LogLevel.Warning);
            source1.LogMessage("Hello Error", LogLevel.Error);
            WaitForRequest(transport);
            Assert.Single(transport.Requests);
            await AssertContentContains(transport.Requests.Single(), "TestErrorEvent: Hello Error", LogLevel.Error);

            // Azure-Two is not part of the logging filter, it should capture all logs.
            using TestEventSource source2 = new TestEventSource("Azure-Two");
            Assert.True(source2.IsEnabled());
            transport.Requests.Clear();

            source2.LogMessage("hello two", LogLevel.Information);
            WaitForRequest(transport);
            Assert.Single(transport.Requests);
            await AssertContentContains(transport.Requests.Single(), "TestInfoEvent: hello two", LogLevel.Information);
        }

        [Fact]
        public async Task DistroLogForwarderAppliesWildCardFilter2()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Logging.AddFilter("Azure.*", LogLevel.Warning);

            var transport = new MockTransport(_ => new MockResponse(200).SetContent("ok"));
            SetUpOTelAndLogging(builder, transport, LogLevel.Information);

            using var app = builder.Build();
            await app.StartAsync();

            using TestEventSource source = new TestEventSource("Azure-Test");
            Assert.True(source.IsEnabled());
            source.LogMessage("hello", LogLevel.Warning);
            WaitForRequest(transport);

            Assert.Single(transport.Requests);
            await AssertContentContains(transport.Requests.Single(), "TestWarningEvent: hello", LogLevel.Warning);
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
            var level = expectedLevel == LogLevel.Debug ? "Verbose" : expectedLevel.ToString();
            var jsonLevel = $"\"severityLevel\":\"{level}\"";
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

        private static void SetUpOTelAndLogging(ServiceCollection serviceCollection, MockTransport transport, LogLevel enableLevel, Action<ILoggingBuilder>? extraLoggingConfig = null)
        {
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddFilter((name, level) =>
                {
                    if (name != null && name.StartsWith("Azure"))
                    {
                        return level >= enableLevel;
                    }
                    return false;
                });

                extraLoggingConfig?.Invoke(loggingBuilder);
            });

            serviceCollection.AddOpenTelemetry().UseAzureMonitor(config =>
            {
                config.Transport = transport;
                config.ConnectionString = $"InstrumentationKey={Guid.NewGuid()}";
                config.EnableLiveMetrics = false;
            });
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
            private readonly string EventSourceName;

            public TestEventSource(string eventSourceName) : base(eventSourceName)
            {
                EventSourceName = eventSourceName;
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

            [Event(4, Level = EventLevel.Error, Message = "TestErrorEvent: {0}")]
            public void LogTestErrorEvent(string message)
            {
                WriteEvent(4, message);
            }

            public void LogMessage(string message, LogLevel level)
            {
                switch (level)
                {
                    case LogLevel.Error:
                        LogTestErrorEvent(message);
                        break;
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
