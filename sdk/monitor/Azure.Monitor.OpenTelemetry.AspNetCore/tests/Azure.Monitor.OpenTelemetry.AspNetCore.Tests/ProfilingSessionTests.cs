// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.AspNetCore.Internals.Profiling;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    /// <summary>
    /// Tests for <see cref="ProfilingSessionEventSource"/> and related classes.
    /// </summary>
    public class ProfilingSessionTests : IDisposable
    {
        private readonly Profiler _profiler = new();

        /// <inheritdoc/>
        public void Dispose()
        {
            _profiler.Dispose();
        }

        /// <summary>
        /// Tests that the session ID is recorded when the EventSource
        /// is enabled by a profiler.
        /// </summary>
        [Fact]
        public void SessionIdIsSetWhenEventSourceIsEnabled()
        {
            ProfilingSessionEventSource profilingSession = ProfilingSessionEventSource.Current;

            Assert.Null(profilingSession.SessionId);

            using (IDisposable _ = _profiler.StartProfiling())
            {
                Assert.Equal(_profiler.SessionId, profilingSession.SessionId);
            }

            Assert.Null(profilingSession.SessionId);
        }

        /// <summary>
        /// Tests that the profiling session ID is added to an
        /// <see cref="Activity"/>.
        /// </summary>
        [Fact]
        public void SessionIdIsAddedToActivityTags()
        {
            using IDisposable _ = _profiler.StartProfiling();

            using Activity activity = new("Test");

            using ProfilingSessionTraceProcessor traceProcessor = new();
            traceProcessor.OnEnd(activity);

            Assert.Equal(_profiler.SessionId, activity.GetTagItem(ProfilingSessionTraceProcessor.TagName));
        }

        [Fact]
        public void TraceProcessorIsAddedViaUseAzureMonitor()
        {
            // Configure DI services
            ServiceCollection serviceCollection = new();
            serviceCollection.AddOpenTelemetry().UseAzureMonitor(config =>
            {
                config.Transport = new MockTransport(new MockResponse(200).SetContent("ok"));
                config.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
                config.EnableLiveMetrics = false;
            });

            using ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            // Instantiate the OpenTelemetry "pipeline".
            _ = serviceProvider.GetRequiredService<TracerProvider>();

            // The ActivitySource name must begin with "Azure."
            ActivitySource activitySource = new("Azure.Monitor.TestSource");

            // Simulate a profiler session starting
            using IDisposable profilerSession = _profiler.StartProfiling();

            // Start and stop an activity.
            using Activity? activity = activitySource.StartActivity("Test");
            Assert.NotNull(activity);
            activity.Stop();

            // The profiling session ID tag should be set.
            Assert.Equal(_profiler.SessionId, activity.GetTagItem(ProfilingSessionTraceProcessor.TagName));
        }

        [Theory]
        [InlineData(false, 0)]
        [InlineData(false, 2)]
        [InlineData(true, 0)]
        [InlineData(true, 2)]
        public void ResourceAttributesWrittenExactlyOnce(bool startProfilerBeforeApp, int numActivities)
        {
            bool resourceAttributesWritten = false;
            Exception? eventWrittenException = null;

            void EventWrittenHandler(object? sender, EventWrittenEventArgs args)
            {
                try
                {
                    if (args.EventSource.Name == ProfilingSessionEventSource.EventSourceName)
                    {
                        Assert.Equal(ProfilingSessionEventSource.EventIds.ResourceAttributes, args.EventId);
                        Assert.False(resourceAttributesWritten, $"Expect only one {nameof(ProfilingSessionEventSource.EventIds.ResourceAttributes)} event.");
                        Assert.NotNull(args.PayloadNames);
                        Assert.Single(args.PayloadNames);
                        Assert.Equal("attributes", args.PayloadNames.First());
                        resourceAttributesWritten = true;
                    }
                }
                catch (Exception ex)
                {
                    eventWrittenException = ex;
                }
            }

            IDisposable? profilerSession = null;

            if (startProfilerBeforeApp)
            {
                profilerSession = _profiler.StartProfiling(ProfilingSessionEventSource.Keywords.ResourceAttributes);
                _profiler.EventWritten += EventWrittenHandler;
            }

            try
            {
                using (TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
                    .AddProcessor(new ProfilingSessionTraceProcessor())
                    .AddSource("Azure.Monitor.TestSource")
                    .ConfigureResource(resource =>
                    {
                        resource.AddAttributes(new KeyValuePair<string, object>[]
                        {
                            new("test.attribute", "test-value"),
                            new("test.attribute2", "test-value2"),
                        });
                    })
                    .Build())
                {
                    if (!startProfilerBeforeApp)
                    {
                        Assert.Null(profilerSession);
                        profilerSession = _profiler.StartProfiling(ProfilingSessionEventSource.Keywords.ResourceAttributes);
                        _profiler.EventWritten += EventWrittenHandler;
                    }

                    // The ActivitySource name must begin with "Azure."
                    ActivitySource activitySource = new("Azure.Monitor.TestSource");

                    // Start multiple activities.
                    for (int i = 0; i < numActivities; i++)
                    {
                        using (Activity? activity = activitySource.StartActivity($"Test{i}"))
                        {
                        }
                    }
                }

                Assert.Null(eventWrittenException);
                Assert.True(resourceAttributesWritten);
            }
            finally
            {
                profilerSession?.Dispose();
                _profiler.EventWritten -= EventWrittenHandler;
            }
        }

        /// <summary>
        /// Simulation of a profiler that can start and stop profiling sessions
        /// and communicate the session ID to the <see cref="ProfilingSessionEventSource"/>.
        /// </summary>
        private sealed class Profiler : EventListener
        {
            /// <summary>
            /// Gets or sets the current session ID. The value is null if profiling is not active.
            /// </summary>
            public string? SessionId { get; private set; }

            /// <summary>
            /// Keywords enabled in the current session.
            /// </summary>
            private EventKeywords _eventKeywords;

            /// <summary>
            /// Gets a Boolean value indicating whether profiling is active.
            /// </summary>
            public bool IsProfiling => SessionId != default;

            private readonly List<EventSource> _eventSources = new();
            private readonly List<EventSource> _enabledEventSources = new();

            /// <summary>
            /// Simulate the profiler starting. A new, random session ID will be
            /// generated.
            /// </summary>
            /// <returns>A disposable object the will stop profiling when disposed.</returns>
            public IDisposable StartProfiling(EventKeywords keywords = EventKeywords.All) => StartProfiling(Guid.NewGuid().ToString("N"), keywords);

            /// <summary>
            /// Simulate the profiler starting.
            /// </summary>
            /// <param name="sessionId">The new session ID.</param>
            /// <param name="keywords">Set of keywords to enable.</param>
            /// <returns>A disposable object the will stop profiling when disposed.</returns>
            /// <exception cref="ArgumentException"><paramref name="sessionId"/> is null or empty.</exception>
            /// <exception cref="InvalidOperationException">A profiling session is already active.</exception>
            public IDisposable StartProfiling(string sessionId, EventKeywords keywords = EventKeywords.All)
            {
                if (string.IsNullOrEmpty(sessionId))
                {
                    throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or empty.", nameof(sessionId));
                }

                if (IsProfiling)
                {
                    throw new InvalidOperationException("A profiling session is already active.");
                }

                SessionId = sessionId;
                _eventKeywords = keywords;
                foreach (EventSource eventSource in _eventSources)
                {
                    EnableEvents(eventSource, EventLevel.Informational, _eventKeywords, new Dictionary<string, string?>
                    {
                        ["SessionId"] = sessionId
                    });

                    _enabledEventSources.Add(eventSource);
                }

                _eventSources.Clear();
                return new ProfilerSession(this);
            }

            /// <summary>
            /// Stop profiling.
            /// </summary>
            /// <remarks>
            /// Safe to call (a no-op) more than once.
            /// </remarks>
            public void StopProfiling()
            {
                SessionId = default;
                foreach (EventSource eventSource in _enabledEventSources)
                {
                    DisableEvents(eventSource);
                    _eventSources.Add(eventSource);
                }

                _enabledEventSources.Clear();
            }

            /// <inheritdoc/>
            protected override void OnEventSourceCreated(EventSource eventSource)
            {
                if (eventSource.Name == ProfilingSessionEventSource.EventSourceName)
                {
                    if (IsProfiling)
                    {
                        EnableEvents(eventSource, EventLevel.Informational, _eventKeywords, new Dictionary<string, string?>
                        {
                            ["SessionId"] = SessionId
                        });

                        _enabledEventSources.Add(eventSource);
                    }
                    else
                    {
                        _eventSources.Add(eventSource);
                    }
                }
            }

            /// <inheritdoc/>
            public override void Dispose()
            {
                try
                {
                    foreach (EventSource eventSource in _eventSources)
                    {
                        DisableEvents(eventSource);
                    }

                    _eventSources.Clear();
                }
                finally
                {
                    base.Dispose();
                }
            }

            /// <summary>
            /// A disposable object that will automatically stop profiling when disposed.
            /// </summary>
            private sealed class ProfilerSession : IDisposable
            {
                private readonly Profiler _profiler;

                /// <summary>
                /// Constructs a new instance.
                /// </summary>
                /// <param name="profiler">The profiler instance.</param>
                public ProfilerSession(Profiler profiler)
                {
                    _profiler = profiler;
                }

                /// <inheritdoc/>
                public void Dispose()
                {
                    _profiler.StopProfiling();
                }
            }
        }
    }
}
