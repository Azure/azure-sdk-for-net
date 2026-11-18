// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Microsoft.Extensions.Azure.Tests
{
    public class LogForwarderTests
    {
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(30);

        // The IDs of the events that are written by both TestSource and LateSource
        private const int CriticalId = 2;
        private const int InformationalId = 4;
        private const int VerboseId = 5;
        private const int WarningId = 6;

        [TestCase(EventLevel.LogAlways, LogLevel.Information)]
        [TestCase(EventLevel.Critical, LogLevel.Critical)]
        [TestCase(EventLevel.Error, LogLevel.Error)]
        [TestCase(EventLevel.Informational, LogLevel.Information)]
        [TestCase(EventLevel.Verbose, LogLevel.Debug)]
        [TestCase(EventLevel.Warning, LogLevel.Warning)]
        public void MapsLevelsCorrectly(EventLevel eventLevel, LogLevel logLevel)
        {
            var loggerFactory = new MockLoggerFactory();
            using (var forwarder = new AzureEventSourceLogForwarder(loggerFactory))
            {
                forwarder.Start();
                typeof(TestSource).GetMethod(eventLevel.ToString(), BindingFlags.Instance | BindingFlags.Public).Invoke(TestSource.Log, Array.Empty<object>());
            }

            var logs = loggerFactory.Loggers["Test.source"].Logs;
            Assert.That(logs.Count, Is.EqualTo(1));
            Assert.That(logs[0].Level, Is.EqualTo(logLevel));
        }

        // The IDs of the events in TestSource, by the level that they are written at.
        [TestCase(EventLevel.Verbose, new[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(EventLevel.Informational, new[] { 1, 2, 3, 4, 6 })]
        [TestCase(EventLevel.Warning, new[] { 1, 2, 3, 6 })]
        [TestCase(EventLevel.Error, new[] { 1, 2, 3 })]
        [TestCase(EventLevel.Critical, new[] { 1, 2 })]
        [TestCase(null, new int[0])]
        public void ListenerOnlyEnablesEventSourceAtRequestedLevel(EventLevel? level, int[] expectedEventIds)
        {
            var recorder = new EventRecorder();

            // Ensure the event source exists before the listener is created
            var source = TestSource.Log;

            // Events are filtered for each listener, so events that other listeners enabled are not received
            using (var listener = new LogForwarderEventListener(recorder.Record, _ => level))
            {
                WriteAllEvents(source);
            }

            Assert.That(recorder.GetEventIds("Test-source"), Is.EquivalentTo(expectedEventIds));
        }

        [Test]
        public void ListenerNarrowsLevelOfEventSourcesCreatedAfterItWasStarted()
        {
            var name = "Test-late-" + Guid.NewGuid().ToString("N");
            var recorder = new EventRecorder();

            using var listener = new LogForwarderEventListener(recorder.Record, n => n == name ? EventLevel.Warning : null);
            using var source = new LateSource(name);

            // Initially enabled at the most verbose level, which is then narrowed to Warning. Events are lost while
            // an event source is being re-enabled, so only accept the narrowed level once a warning is received
            // when an informational event written just before it was not.
            Assert.That(
                SpinWait.SpinUntil(
                    () =>
                    {
                        var informational = recorder.Count(name, InformationalId);
                        var warnings = recorder.Count(name, WarningId);

                        source.Informational();
                        source.Warning();

                        return recorder.Count(name, WarningId) > warnings && recorder.Count(name, InformationalId) == informational;
                    },
                    Timeout),
                Is.True,
                "The event source was not narrowed to the requested level.");
        }

        [Test]
        public void ListenerReevaluatesLevelsWhenRequested()
        {
            var name = "Test-reevaluate-" + Guid.NewGuid().ToString("N");
            var recorder = new EventRecorder();
            var level = new LevelHolder { Value = EventLevel.Warning };

            using var listener = new LogForwarderEventListener(recorder.Record, n => n == name ? level.Value : null);
            using var source = new LateSource(name);

            WaitForEvent(recorder, name, WarningId, source.Warning, "The event source was not enabled at Warning.");

            level.Value = EventLevel.Informational;
            listener.RequestRefresh();

            WaitForEvent(recorder, name, InformationalId, source.Informational, "The event source was not enabled at a more verbose level.");

            level.Value = null;
            listener.RequestRefresh();

            // Events are only still received until the event source is disabled
            Assert.That(
                SpinWait.SpinUntil(
                    () =>
                    {
                        var count = recorder.Count(name, CriticalId);
                        source.Critical();
                        return recorder.Count(name, CriticalId) == count;
                    },
                    Timeout),
                Is.True,
                "The event source was not disabled.");
        }

        [Test]
        public void ForwardsEventsEnabledByFilterRules()
        {
            using var harness = new Harness(LogLevel.Information, new LoggerFilterRule(null, "Test", LogLevel.Warning, null));
            using var forwarder = new AzureEventSourceLogForwarder(harness.Factory, harness.Monitor);
            forwarder.Start();

            Assert.That(forwarder.GetEventLevel("Test-source"), Is.EqualTo(EventLevel.Warning));
            Assert.That(forwarder.GetEventLevel("Azure-Core"), Is.EqualTo(EventLevel.Informational));

            WaitForEvent(harness.Provider, "Test.source", WarningId, TestSource.Log.Warning, "A warning was not forwarded.");

            TestSource.Log.Informational();
            Assert.That(harness.Provider.Count("Test.source", InformationalId), Is.Zero);
        }

        [Test]
        public void ForwardsNewlyEnabledLevelsWhenFilterRulesAreReloaded()
        {
            using var harness = new Harness(LogLevel.Warning);
            using var forwarder = new AzureEventSourceLogForwarder(harness.Factory, harness.Monitor);
            forwarder.Start();

            Assert.That(forwarder.GetEventLevel("Test-source"), Is.EqualTo(EventLevel.Warning));

            harness.Monitor.Set(CreateOptions(LogLevel.Information));

            WaitForEvent(harness.Provider, "Test.source", InformationalId, TestSource.Log.Informational, "The event source was not enabled at a more verbose level.");
            Assert.That(forwarder.GetEventLevel("Test-source"), Is.EqualTo(EventLevel.Informational));

            harness.Monitor.Set(CreateOptions(LogLevel.None));

            Assert.That(
                SpinWait.SpinUntil(
                    () =>
                    {
                        var count = harness.Provider.Count("Test.source", CriticalId);
                        TestSource.Log.Critical();
                        return harness.Provider.Count("Test.source", CriticalId) == count;
                    },
                    Timeout),
                Is.True,
                "The event source was not disabled.");
            Assert.That(forwarder.GetEventLevel("Test-source"), Is.Null);
        }

        [Test]
        public void ForwardsEventsWhenFilterRulesAreReloadedUsingPublicConstructor()
        {
            // Without a notification that the filter rules changed the event sources are always enabled at the most
            // verbose level, so that events that are enabled by a configuration reload are not missed.
            using var harness = new Harness(LogLevel.Warning);
            using var forwarder = new AzureEventSourceLogForwarder(harness.Factory);
            forwarder.Start();

            Assert.That(forwarder.GetEventLevel("Test-source"), Is.EqualTo(EventLevel.Verbose));

            harness.Monitor.Set(CreateOptions(LogLevel.Information));

            WaitForEvent(harness.Provider, "Test.source", InformationalId, TestSource.Log.Informational, "The event was not forwarded after the configuration changed.");
        }

        [Test]
        public void ForwardsEventsToProvidersAddedAfterStart()
        {
            using var harness = new Harness(LogLevel.Information, addProvider: false);
            using var forwarder = new AzureEventSourceLogForwarder(harness.Factory, harness.Monitor);
            forwarder.Start();

            harness.Factory.AddProvider(harness.Provider);

            WaitForEvent(harness.Provider, "Test.source", InformationalId, TestSource.Log.Informational, "The event was not forwarded to the provider that was added.");
        }

        [Test]
        public void DoesNotMissFilterRulesChangingWhileStarting()
        {
            // Ensure the event source exists before the forwarder is started, so that its level is evaluated while it is starting
            var source = TestSource.Log;

            using var harness = new Harness(LogLevel.Warning);
            using var forwarder = new AzureEventSourceLogForwarder(harness.Factory, harness.Monitor);

            // Change the rules after the levels were evaluated when the listener was created, but before the
            // forwarder is subscribed to changes, so it is not notified that the rules were changed.
            harness.Monitor.Registering = () =>
            {
                harness.Monitor.Registering = null;
                harness.Monitor.Set(CreateOptions(LogLevel.Information));
            };

            forwarder.Start();

            WaitForEvent(harness.Provider, "Test.source", InformationalId, source.Informational, "The event source was not enabled at the level of the changed rules.");
            Assert.That(forwarder.GetEventLevel("Test-source"), Is.EqualTo(EventLevel.Informational));
        }

        [Test]
        public void ForwardsAllEventsForOtherLoggerFactories()
        {
            // The loggers of other factories do not necessarily use the filter rules, so everything is forwarded
            var loggerFactory = new ConfigurableLoggerFactory { MinimumLevel = LogLevel.Warning };
            var monitor = new TestOptionsMonitor(CreateOptions(LogLevel.Warning));

            using var forwarder = new AzureEventSourceLogForwarder(loggerFactory, monitor);
            forwarder.Start();

            Assert.That(forwarder.GetEventLevel("Test-source"), Is.EqualTo(EventLevel.Verbose));

            WriteAllEvents(TestSource.Log);

            Assert.That(loggerFactory.GetEventIds("Test.source"), Is.EquivalentTo(new[] { 1, 2, 3, 4, 5, 6 }));
        }

        [Test]
        public void ForwardsEventsAtLevelsOfFilterRulesOfServiceProvider()
        {
            var monitor = new TestOptionsMonitor(CreateOptions(LogLevel.Warning));
            var provider = new RecordingProvider();

            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton<IOptionsMonitor<LoggerFilterOptions>>(monitor);
            services.AddSingleton<ILoggerProvider>(provider);
            services.AddAzureClientsCore();

            using var serviceProvider = services.BuildServiceProvider();
            using var forwarder = serviceProvider.GetRequiredService<AzureEventSourceLogForwarder>();
            forwarder.Start();

            Assert.That(forwarder.GetEventLevel("Test-source"), Is.EqualTo(EventLevel.Warning));

            WaitForEvent(provider, "Test.source", WarningId, TestSource.Log.Warning, "A warning was not forwarded.");

            monitor.Set(CreateOptions(LogLevel.Debug));

            WaitForEvent(provider, "Test.source", VerboseId, TestSource.Log.Verbose, "The event source was not enabled at a more verbose level.");
            Assert.That(forwarder.GetEventLevel("Test-source"), Is.EqualTo(EventLevel.Verbose));
        }

        [Test]
        public void WorksWithNullLoggerFactory()
        {
            using var forwarder = new AzureEventSourceLogForwarder( null);
            forwarder.Start();
            TestSource.Log.Informational();
        }

        [Test]
        public void CanDisposeNonStarted()
        {
            var forwarder = new AzureEventSourceLogForwarder( null);
            forwarder.Dispose();
        }

        public class MockLogger : ILogger
        {
            public string CategoryName { get; }

            public List<(LogLevel Level, EventId EventId, string Message)> Logs { get; } =
                new List<(LogLevel Level, EventId EventId, string Message)>();

            public MockLogger(string categoryName)
            {
                CategoryName = categoryName;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                lock (Logs)
                {
                    Logs.Add((logLevel, eventId, formatter(state, exception)));
                }
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }

        public class MockLoggerFactory : ILoggerFactory
        {
            public Dictionary<string, MockLogger> Loggers = new Dictionary<string, MockLogger>();

            public void Dispose()
            {
            }

            public ILogger CreateLogger(string categoryName)
            {
                lock (Loggers)
                {
                    if (!Loggers.TryGetValue(categoryName, out var logger))
                    {
                        logger = Loggers[categoryName] = new MockLogger(categoryName);
                    }

                    return logger;
                }
            }

            public void AddProvider(ILoggerProvider provider)
            {
            }
        }

        private static void WriteAllEvents(TestSource source)
        {
            source.LogAlways();
            source.Critical();
            source.Error();
            source.Informational();
            source.Verbose();
            source.Warning();
        }

        private static LoggerFilterOptions CreateOptions(LogLevel minimumLevel, params LoggerFilterRule[] rules)
        {
            var options = new LoggerFilterOptions { MinLevel = minimumLevel };

            foreach (var rule in rules)
            {
                options.Rules.Add(rule);
            }

            return options;
        }

        // Event sources can lose events at the moment that their level is changed, so write the event
        // until it is received to know that the event source is enabled at the level of the event.
        private static void WaitForEvent(IEventCounter counter, string category, int eventId, Action write, string message)
        {
            Assert.That(
                SpinWait.SpinUntil(
                    () =>
                    {
                        write();
                        return counter.Count(category, eventId) > 0;
                    },
                    Timeout),
                Is.True,
                message);
        }

        private interface IEventCounter
        {
            int Count(string category, int eventId);
        }

        private sealed class LevelHolder
        {
            private readonly object _gate = new object();
            private EventLevel? _value;

            public EventLevel? Value
            {
                get
                {
                    lock (_gate)
                    {
                        return _value;
                    }
                }
                set
                {
                    lock (_gate)
                    {
                        _value = value;
                    }
                }
            }
        }

        // A logger factory, with a logging provider that has its levels configured by the filter rules
        private sealed class Harness : IDisposable
        {
            public Harness(LogLevel minimumLevel, LoggerFilterRule rule = null, bool addProvider = true)
            {
                Provider = new RecordingProvider();
                Monitor = new TestOptionsMonitor(rule is null ? CreateOptions(minimumLevel) : CreateOptions(minimumLevel, rule));
                Factory = new LoggerFactory(addProvider ? new ILoggerProvider[] { Provider } : Array.Empty<ILoggerProvider>(), Monitor);
            }

            public LoggerFactory Factory { get; }

            public RecordingProvider Provider { get; }

            public TestOptionsMonitor Monitor { get; }

            public void Dispose() => Factory.Dispose();
        }

        private sealed class EventRecorder : IEventCounter
        {
            private readonly List<(string Source, int EventId)> _events = new List<(string Source, int EventId)>();

            public void Record(EventWrittenEventArgs eventData)
            {
                lock (_events)
                {
                    _events.Add((eventData.EventSource.Name, eventData.EventId));
                }
            }

            public int Count(string source, int eventId)
            {
                lock (_events)
                {
                    return _events.Count((p) => p.Source == source && p.EventId == eventId);
                }
            }

            public IReadOnlyList<int> GetEventIds(string source)
            {
                lock (_events)
                {
                    return _events.Where((p) => p.Source == source).Select((p) => p.EventId).ToArray();
                }
            }
        }

        // Records the events that the logger factory forwards to the provider, which excludes those disabled by its filter rules
        private sealed class RecordingProvider : ILoggerProvider, IEventCounter
        {
            private readonly List<(string Category, int EventId)> _events = new List<(string Category, int EventId)>();

            public ILogger CreateLogger(string categoryName) => new RecordingLogger(this, categoryName);

            public void Dispose()
            {
            }

            public int Count(string category, int eventId)
            {
                lock (_events)
                {
                    return _events.Count((p) => p.Category == category && p.EventId == eventId);
                }
            }

            private void Add(string category, int eventId)
            {
                lock (_events)
                {
                    _events.Add((category, eventId));
                }
            }

            private sealed class RecordingLogger : ILogger
            {
                private readonly RecordingProvider _provider;
                private readonly string _category;

                public RecordingLogger(RecordingProvider provider, string category)
                {
                    _provider = provider;
                    _category = category;
                }

                public IDisposable BeginScope<TState>(TState state) => null;

                public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

                public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
                    => _provider.Add(_category, eventId.Id);
            }
        }

        public class ConfigurableLoggerFactory : ILoggerFactory
        {
            private readonly Dictionary<string, List<int>> _events = new Dictionary<string, List<int>>();

            public volatile LogLevel MinimumLevel = LogLevel.Trace;

            public IReadOnlyList<int> GetEventIds(string categoryName)
            {
                lock (_events)
                {
                    return _events.TryGetValue(categoryName, out var ids) ? ids.ToArray() : Array.Empty<int>();
                }
            }

            public void Dispose()
            {
            }

            public ILogger CreateLogger(string categoryName) => new ConfigurableLogger(this, categoryName);

            public void AddProvider(ILoggerProvider provider)
            {
            }

            private void Add(string categoryName, int eventId)
            {
                lock (_events)
                {
                    if (!_events.TryGetValue(categoryName, out var ids))
                    {
                        ids = _events[categoryName] = new List<int>();
                    }

                    ids.Add(eventId);
                }
            }

            private sealed class ConfigurableLogger : ILogger
            {
                private readonly ConfigurableLoggerFactory _factory;
                private readonly string _categoryName;

                public ConfigurableLogger(ConfigurableLoggerFactory factory, string categoryName)
                {
                    _factory = factory;
                    _categoryName = categoryName;
                }

                public IDisposable BeginScope<TState>(TState state) => null;

                public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None && logLevel >= _factory.MinimumLevel;

                // Record every event that is received, regardless of the level, so that
                // the tests can verify which events the event source actually produced.
                public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
                {
                    _factory.Add(_categoryName, eventId.Id);
                }
            }
        }

        public class TestOptionsMonitor : IOptionsMonitor<LoggerFilterOptions>
        {
            private readonly object _gate = new object();
            private readonly List<Action<LoggerFilterOptions, string>> _listeners = new List<Action<LoggerFilterOptions, string>>();
            private LoggerFilterOptions _options;

            public TestOptionsMonitor(LoggerFilterOptions options)
            {
                _options = options;
            }

            // Invoked when a listener registers, before it is added, to simulate the options changing in that window.
            public Action Registering { get; set; }

            public LoggerFilterOptions CurrentValue
            {
                get
                {
                    lock (_gate)
                    {
                        return _options;
                    }
                }
            }

            public LoggerFilterOptions Get(string name) => CurrentValue;

            public IDisposable OnChange(Action<LoggerFilterOptions, string> listener)
            {
                Registering?.Invoke();

                lock (_gate)
                {
                    _listeners.Add(listener);
                }

                return new Registration(this, listener);
            }

            public void Set(LoggerFilterOptions options)
            {
                Action<LoggerFilterOptions, string>[] listeners;

                lock (_gate)
                {
                    _options = options;
                    listeners = _listeners.ToArray();
                }

                foreach (var listener in listeners)
                {
                    listener(options, null);
                }
            }

            private sealed class Registration : IDisposable
            {
                private readonly TestOptionsMonitor _monitor;
                private readonly Action<LoggerFilterOptions, string> _listener;

                public Registration(TestOptionsMonitor monitor, Action<LoggerFilterOptions, string> listener)
                {
                    _monitor = monitor;
                    _listener = listener;
                }

                public void Dispose()
                {
                    lock (_monitor._gate)
                    {
                        _monitor._listeners.Remove(_listener);
                    }
                }
            }
        }

        private class LateSource : EventSource
        {
            public LateSource(string name) : base(name, EventSourceSettings.Default, "AzureEventSource", "true")
            {
            }

            [Event(CriticalId, Message = "Critical", Level = EventLevel.Critical)]
            public void Critical()
            {
                WriteEvent(CriticalId);
            }

            [Event(InformationalId, Message = "Informational", Level = EventLevel.Informational)]
            public void Informational()
            {
                WriteEvent(InformationalId);
            }

            [Event(WarningId, Message = "Warning", Level = EventLevel.Warning)]
            public void Warning()
            {
                WriteEvent(WarningId);
            }
        }

        private class TestSource : EventSource
        {
            internal static TestSource Log { get; } = new TestSource();

            private TestSource() : base("Test-source", EventSourceSettings.Default, "AzureEventSource", "true")
            {
            }

            [Event(1, Message = "LogAlways", Level = EventLevel.LogAlways)]
            public void LogAlways()
            {
                WriteEvent(1);
            }

            [Event(CriticalId, Message = "Critical", Level = EventLevel.Critical)]
            public void Critical()
            {
                WriteEvent(CriticalId);
            }

            [Event(3, Message = "Error", Level = EventLevel.Error)]
            public void Error()
            {
                WriteEvent(3);
            }

            [Event(InformationalId, Message = "Informational", Level = EventLevel.Informational)]
            public void Informational()
            {
                WriteEvent(InformationalId);
            }

            [Event(VerboseId, Message = "Verbose", Level = EventLevel.Verbose)]
            public void Verbose()
            {
                WriteEvent(VerboseId);
            }

            [Event(WarningId, Message = "Warning", Level = EventLevel.Warning)]
            public void Warning()
            {
                WriteEvent(WarningId);
            }
        }
    }
}
