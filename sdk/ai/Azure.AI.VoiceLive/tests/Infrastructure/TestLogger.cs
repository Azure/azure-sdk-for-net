// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402 // File may only contain a single type

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// A non-generic test logger capturing log entries in-memory. All instances created from a <see cref="TestLoggerFactory"/>
    /// share the same underlying sink so that tests can assert against a consolidated log history.
    /// </summary>
    public sealed class TestLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly List<LogEntry> _sink;
        private readonly object _syncRoot;
        private readonly LogLevel _minimumLevel;

        internal TestLogger(string categoryName, List<LogEntry> sink, object syncRoot, LogLevel minimumLevel)
        {
            _categoryName = categoryName;
            _sink = sink;
            _syncRoot = syncRoot;
            _minimumLevel = minimumLevel;
        }

        /// <summary>
        /// Returns a snapshot list of the current log entries. The returned list will not update after enumeration.
        /// </summary>
        public IReadOnlyList<LogEntry> Entries
        {
            get
            {
                lock (_syncRoot)
                {
                    return _sink.Count == 0 ? Array.Empty<LogEntry>() : new List<LogEntry>(_sink);
                }
            }
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull => NullScope.Instance;

        public bool IsEnabled(LogLevel logLevel) => logLevel >= _minimumLevel;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            string? message = null;
            try
            {
                if (formatter != null)
                {
                    message = formatter(state, exception);
                }
                else if (state != null)
                {
                    message = state.ToString();
                }
            }
            catch
            {
                // Swallow any formatter exceptions so tests don't fail due to logging errors.
            }

            var entry = new LogEntry(logLevel, eventId, message, exception, state);
            lock (_syncRoot)
            {
                _sink.Add(entry);
            }
        }

        /// <summary>
        /// Simple disposable used for BeginScope which performs no action.
        /// </summary>
        internal sealed class NullScope : IDisposable
        {
            public static readonly NullScope Instance = new NullScope();
            private NullScope() { }
            public void Dispose() { }
        }
    }

    /// <summary>
    /// Generic variant that supplies the category name based on <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The category type.</typeparam>
    public sealed class TestLogger<T> : ILogger<T>
    {
        private readonly TestLogger _inner;

        internal TestLogger(TestLogger inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Exposes the captured log entries (same shared sink as other loggers from the factory).
        /// </summary>
        public IReadOnlyList<LogEntry> Entries => _inner.Entries;

        public IDisposable BeginScope<TState>(TState state) where TState : notnull => _inner.BeginScope(state);
        public bool IsEnabled(LogLevel logLevel) => _inner.IsEnabled(logLevel);
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
            => _inner.Log(logLevel, eventId, state, exception, formatter);
    }

    /// <summary>
    /// Represents a single captured log entry for assertions in tests.
    /// </summary>
    /// <param name="Level">The <see cref="LogLevel"/> of the log entry.</param>
    /// <param name="EventId">The <see cref="Microsoft.Extensions.Logging.EventId"/> associated with the entry.</param>
    /// <param name="Message">The formatted message text (may be null).</param>
    /// <param name="Exception">The exception captured with the log entry (may be null).</param>
    /// <param name="State">The original state object supplied to the logger (may be null).</param>
    public record LogEntry(LogLevel Level, EventId EventId, string? Message, Exception? Exception, object? State);

    /// <summary>
    /// Factory for creating <see cref="ILoggerFactory"/> instances that produce <see cref="TestLogger"/> and <see cref="TestLogger{T}"/> loggers
    /// writing into a shared in-memory sink. Intended for use in unit tests.
    /// </summary>
    public static class TestLoggerFactory
    {
        /// <summary>
        /// Creates an <see cref="ILoggerFactory"/> that supplies test loggers which write into a shared sink.
        /// </summary>
        /// <param name="sink">Outputs the shared list capturing all log entries produced by loggers from the returned factory.</param>
        /// <param name="minimumLevel">Optional minimum <see cref="LogLevel"/>; entries below this level are ignored. Defaults to <see cref="LogLevel.Trace"/>.</param>
        /// <returns>The configured <see cref="ILoggerFactory"/>.</returns>
        public static ILoggerFactory Create(out List<LogEntry> sink, LogLevel minimumLevel = LogLevel.Trace)
        {
            sink = new List<LogEntry>();
            return new InMemoryLoggerFactory(sink, minimumLevel);
        }

        private sealed class InMemoryLoggerFactory : ILoggerFactory
        {
            private readonly List<LogEntry> _sink;
            private readonly object _syncRoot = new object();
            private readonly LogLevel _minimumLevel;
            private bool _disposed;

            public InMemoryLoggerFactory(List<LogEntry> sink, LogLevel minimumLevel)
            {
                _sink = sink ?? throw new ArgumentNullException(nameof(sink));
                _minimumLevel = minimumLevel;
            }

            public ILogger CreateLogger(string categoryName)
            {
                EnsureNotDisposed();
                var core = new TestLogger(categoryName, _sink, _syncRoot, _minimumLevel);
                return core;
            }

            public void AddProvider(ILoggerProvider provider)
            {
                // External providers are not supported; ignoring keeps behavior simple for tests.
            }

            public void Dispose()
            {
                _disposed = true;
            }

            private void EnsureNotDisposed()
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(InMemoryLoggerFactory));
                }
            }
        }
    }
}
#pragma warning restore SA1402 // File may only contain a single type
