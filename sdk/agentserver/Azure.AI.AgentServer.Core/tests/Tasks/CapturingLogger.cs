// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// A minimal <see cref="ILogger"/> that captures formatted log messages for assertions.
/// Shared across tests that need to verify observability output (e.g. resilient-task
/// recovery markers). Thread-safe for the concurrent writes the durability loop produces.
/// </summary>
internal sealed class CapturingLogger : ILogger
{
    private readonly List<CapturedLog> _entries = new();
    private readonly object _gate = new();

    public IReadOnlyList<CapturedLog> Entries
    {
        get
        {
            lock (_gate)
            {
                return _entries.ToArray();
            }
        }
    }

    public IDisposable? BeginScope<TState>(TState state)
        where TState : notnull => null;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        lock (_gate)
        {
            _entries.Add(new CapturedLog(logLevel, eventId, formatter(state, exception)));
        }
    }
}

/// <summary>A single captured log line.</summary>
internal sealed record CapturedLog(LogLevel Level, EventId EventId, string Message);
