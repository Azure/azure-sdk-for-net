// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Net.WebSockets;
using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

public class WebSocketLoggerFailureTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(5);

    [TestCase(FailureTarget.PrimaryDiagnostic)]
    [TestCase(FailureTarget.CleanupDiagnostic)]
    [TestCase(FailureTarget.CloseDiagnostic)]
    [TestCase(FailureTarget.CloseEvent)]
    public async Task LoggerFailureDoesNotSuppressLaterDiagnosticsOrNextConnection(
        FailureTarget failureTarget)
    {
        var handler = new OutcomeReportingHandler();
        var logs = new FaultInjectingLoggerProvider(entry => failureTarget switch
        {
            FailureTarget.PrimaryDiagnostic => ReferenceEquals(entry.Exception, handler.PrimaryException),
            FailureTarget.CleanupDiagnostic => ReferenceEquals(entry.Exception, handler.CleanupException),
            FailureTarget.CloseDiagnostic => ReferenceEquals(entry.Exception, handler.CloseException),
            FailureTarget.CloseEvent => entry.State.ContainsKey(InvocationsWebSocketConstants.AttrSpanCloseCode),
            _ => throw new ArgumentOutOfRangeException(nameof(failureTarget)),
        });
        var completion = new RequestCompletionTracker();
        await using var app = BuildApp(handler, logs, completion);
        await app.StartAsync().WaitAsync(TestTimeout);

        var firstCloseCode = await ConnectAndReadCloseAsync(app);
        await completion.WaitForCountAsync(1, TestTimeout);
        AssertOutcomeObservations(handler, logs, completion, expectedCount: 1);

        var secondCloseCode = await ConnectAndReadCloseAsync(app);
        await completion.WaitForCountAsync(2, TestTimeout);
        AssertOutcomeObservations(handler, logs, completion, expectedCount: 2);

        Assert.Multiple(() =>
        {
            Assert.That(firstCloseCode, Is.EqualTo(1002));
            Assert.That(secondCloseCode, Is.EqualTo(1002));
            Assert.That(logs.InjectedFailureCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task RawBeginScopeFailurePreservesDirectPathAndNextConnectionRecovers()
    {
        var handler = new OutcomeReportingHandler();
        var logs = new FaultInjectingLoggerProvider(
            static _ => false,
            failBeginScope: true);
        var completion = new RequestCompletionTracker();
        await using var app = BuildApp(handler, logs, completion);
        await app.StartAsync().WaitAsync(TestTimeout);

        Assert.That(
            async () => await ConnectAndReadCloseAsync(app),
            Throws.Exception);
        await completion.WaitForCountAsync(1, TestTimeout);

        var secondCloseCode = await ConnectAndReadCloseAsync(app);
        await completion.WaitForCountAsync(2, TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(secondCloseCode, Is.EqualTo(1002));
            Assert.That(logs.InjectedFailureCount, Is.EqualTo(1));
            Assert.That(completion.Exceptions, Has.Count.EqualTo(1));
            Assert.That(logs.CloseEvents, Has.Count.EqualTo(1));
            Assert.That(logs.CountException(handler.PrimaryException), Is.EqualTo(1));
            Assert.That(logs.CountException(handler.CleanupException), Is.EqualTo(1));
            Assert.That(logs.CountException(handler.CloseException), Is.EqualTo(1));
        });
    }

    private static void AssertOutcomeObservations(
        OutcomeReportingHandler handler,
        FaultInjectingLoggerProvider logs,
        RequestCompletionTracker completion,
        int expectedCount)
    {
        var closeEvents = logs.CloseEvents;
        Assert.Multiple(() =>
        {
            Assert.That(completion.Exceptions, Is.Empty);
            Assert.That(closeEvents, Has.Count.EqualTo(expectedCount));
            Assert.That(
                closeEvents.Select(entry =>
                    entry.GetValue(InvocationsWebSocketConstants.AttrSpanCloseCode)),
                Is.All.EqualTo(1002));
            Assert.That(
                closeEvents.Select(entry =>
                    entry.GetValue(InvocationsWebSocketConstants.AttrSpanErrorCode)),
                Is.All.EqualTo("protocol_error"));
            Assert.That(logs.CountException(handler.PrimaryException), Is.EqualTo(expectedCount));
            Assert.That(logs.CountException(handler.CleanupException), Is.EqualTo(expectedCount));
            Assert.That(logs.CountException(handler.CloseException), Is.EqualTo(expectedCount));
        });
    }

    private static WebApplication BuildApp(
        InvocationHandler handler,
        ILoggerProvider loggerProvider,
        RequestCompletionTracker completion)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddSingleton(handler);
        builder.Logging.AddProvider(loggerProvider);
        var app = builder.Build();
        app.UseWebSockets();
        app.Use(async (context, next) =>
        {
            try
            {
                await next();
            }
            catch (Exception exception)
            {
                completion.RecordException(exception);
                throw;
            }
            finally
            {
                completion.RecordCompletion();
            }
        });
        app.MapInvocationsServer();
        return app;
    }

    private static async Task<int?> ConnectAndReadCloseAsync(WebApplication app)
    {
        var client = app.GetTestServer().CreateWebSocketClient();
        using var webSocket = await client.ConnectAsync(
            new Uri(app.GetTestServer().BaseAddress, "invocations_ws"),
            CancellationToken.None).WaitAsync(TestTimeout);
        var buffer = new byte[64];
        var close = await webSocket.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
        return (int?)webSocket.CloseStatus;
    }

    public enum FailureTarget
    {
        PrimaryDiagnostic,
        CleanupDiagnostic,
        CloseDiagnostic,
        CloseEvent,
    }

    private sealed class OutcomeReportingHandler : InvocationWebSocketHandler
    {
        public InvalidOperationException PrimaryException { get; } = new("primary");

        public InvalidOperationException CleanupException { get; } = new("cleanup");

        public WebSocketException CloseException { get; } = new("close");

        public override Task HandleWebSocketAsync(
            WebSocket webSocket,
            InvocationContext context,
            CancellationToken cancellationToken) =>
            throw new InvalidOperationException("The endpoint must use outcome-aware dispatch.");

        internal override async Task<InvocationsWebSocketCloseResult?> HandleWebSocketWithOutcomeAsync(
            WebSocket webSocket,
            InvocationContext context,
            CancellationToken cancellationToken)
        {
            await webSocket.CloseOutputAsync(
                (WebSocketCloseStatus)1002,
                "protocol error",
                cancellationToken);
            return new InvocationsWebSocketCloseResult(
                (WebSocketCloseStatus)1002,
                "protocol error",
                "protocol_error",
                PrimaryException,
                CleanupException,
                CloseException);
        }
    }

    private sealed class FaultInjectingLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentQueue<CapturedLogEntry> _entries = new();
        private readonly Func<CapturedLogEntry, bool> _shouldThrow;
        private readonly bool _failBeginScope;
        private int _injectedFailureCount;

        public FaultInjectingLoggerProvider(
            Func<CapturedLogEntry, bool> shouldThrow,
            bool failBeginScope = false)
        {
            _shouldThrow = shouldThrow;
            _failBeginScope = failBeginScope;
        }

        public int InjectedFailureCount => Volatile.Read(ref _injectedFailureCount);

        public IReadOnlyList<CapturedLogEntry> CloseEvents =>
            _entries.Where(entry =>
                entry.State.ContainsKey(InvocationsWebSocketConstants.AttrSpanCloseCode)).ToArray();

        public int CountException(Exception exception) =>
            _entries.Count(entry => ReferenceEquals(entry.Exception, exception));

        public ILogger CreateLogger(string categoryName) => new FaultInjectingLogger(
            this,
            categoryName == typeof(WebSocketEndpointHandler).FullName);

        public void Dispose()
        {
        }

        private void Record(CapturedLogEntry entry)
        {
            _entries.Enqueue(entry);
            if (_shouldThrow(entry))
            {
                ThrowOnce();
            }
        }

        private void ThrowOnce()
        {
            if (Interlocked.CompareExchange(ref _injectedFailureCount, 1, 0) == 0)
            {
                throw new InvalidOperationException("injected logger failure");
            }
        }

        private sealed class FaultInjectingLogger : ILogger
        {
            private readonly FaultInjectingLoggerProvider _owner;
            private readonly bool _isEndpointLogger;

            public FaultInjectingLogger(
                FaultInjectingLoggerProvider owner,
                bool isEndpointLogger)
            {
                _owner = owner;
                _isEndpointLogger = isEndpointLogger;
            }

            public IDisposable? BeginScope<TState>(TState state) where TState : notnull
            {
                if (!_isEndpointLogger)
                {
                    return null;
                }
                if (_owner._failBeginScope)
                {
                    _owner.ThrowOnce();
                }
                return null;
            }

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception?, string> formatter)
            {
                var fields = new Dictionary<string, object?>();
                if (state is IEnumerable<KeyValuePair<string, object?>> pairs)
                {
                    foreach (var pair in pairs)
                    {
                        fields[pair.Key] = pair.Value;
                    }
                }
                _owner.Record(new CapturedLogEntry(exception, fields));
            }
        }
    }

    private sealed record CapturedLogEntry(
        Exception? Exception,
        IReadOnlyDictionary<string, object?> State)
    {
        public object? GetValue(string key) => State.TryGetValue(key, out var value) ? value : null;
    }

    private sealed class RequestCompletionTracker
    {
        private readonly ConcurrentQueue<Exception> _exceptions = new();
        private readonly TaskCompletionSource _firstCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly TaskCompletionSource _secondCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private int _completionCount;

        public IReadOnlyList<Exception> Exceptions => _exceptions.ToArray();

        public void RecordException(Exception exception) => _exceptions.Enqueue(exception);

        public void RecordCompletion()
        {
            var count = Interlocked.Increment(ref _completionCount);
            if (count >= 1)
            {
                _firstCompletion.TrySetResult();
            }
            if (count >= 2)
            {
                _secondCompletion.TrySetResult();
            }
        }

        public Task WaitForCountAsync(int count, TimeSpan timeout) => count switch
        {
            1 => _firstCompletion.Task.WaitAsync(timeout),
            2 => _secondCompletion.Task.WaitAsync(timeout),
            _ => throw new ArgumentOutOfRangeException(nameof(count)),
        };
    }
}
