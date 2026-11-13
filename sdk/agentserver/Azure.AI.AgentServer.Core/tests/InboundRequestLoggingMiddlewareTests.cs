// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class InboundRequestLoggingMiddlewareTests
{
    private TestLoggerProvider _loggerProvider = null!;
    private InboundRequestLoggingMiddleware _middleware = null!;

    [SetUp]
    public void SetUp()
    {
        _loggerProvider = new TestLoggerProvider();
        var loggerFactory = LoggerFactory.Create(b => b.AddProvider(_loggerProvider).SetMinimumLevel(LogLevel.Trace));
        var logger = loggerFactory.CreateLogger<InboundRequestLoggingMiddleware>();
        _middleware = new InboundRequestLoggingMiddleware(logger);
    }

    [Test]
    public async Task InvokeAsync_LogsInfoOnStart()
    {
        var context = CreateContext("GET", "/responses");

        await _middleware.InvokeAsync(context, _ => Task.CompletedTask);

        var infoEntries = _loggerProvider.Entries.Where(e => e.Level == LogLevel.Information).ToList();
        Assert.That(infoEntries.Any(e => e.Message.Contains("Inbound GET /responses starting")), Is.True);
    }

    [Test]
    public async Task InvokeAsync_LogsInfoForSuccessStatusCode()
    {
        var context = CreateContext("POST", "/responses");

        await _middleware.InvokeAsync(context, ctx =>
        {
            ctx.Response.StatusCode = 200;
            return Task.CompletedTask;
        });

        var infoEntries = _loggerProvider.Entries.Where(e => e.Level == LogLevel.Information).ToList();
        Assert.That(infoEntries, Has.Count.EqualTo(2));
        Assert.That(infoEntries[0].Message, Does.Contain("Inbound POST /responses starting"));
        Assert.That(infoEntries[1].Message, Does.Contain("Inbound POST /responses completed HTTP 200"));
        Assert.That(infoEntries[1].Message, Does.Contain("ms"));
    }

    [Test]
    public async Task InvokeAsync_LogsWarningForErrorStatusCode()
    {
        var context = CreateContext("GET", "/responses/abc123");

        await _middleware.InvokeAsync(context, ctx =>
        {
            ctx.Response.StatusCode = 404;
            return Task.CompletedTask;
        });

        var warnEntries = _loggerProvider.Entries.Where(e => e.Level == LogLevel.Warning).ToList();
        Assert.That(warnEntries, Has.Count.EqualTo(1));
        Assert.That(warnEntries[0].Message, Does.Contain("failed HTTP 404"));
    }

    [Test]
    public async Task InvokeAsync_LogsWarningForServerError()
    {
        var context = CreateContext("POST", "/responses");

        await _middleware.InvokeAsync(context, ctx =>
        {
            ctx.Response.StatusCode = 500;
            return Task.CompletedTask;
        });

        var warnEntries = _loggerProvider.Entries.Where(e => e.Level == LogLevel.Warning).ToList();
        Assert.That(warnEntries, Has.Count.EqualTo(1));
        Assert.That(warnEntries[0].Message, Does.Contain("failed HTTP 500"));
    }

    [Test]
    public async Task InvokeAsync_CapturesCorrelationHeaders()
    {
        var context = CreateContext("GET", "/readiness");
        context.Request.Headers["x-request-id"] = "req-abc";
        context.Request.Headers["x-ms-client-request-id"] = "client-xyz";

        await _middleware.InvokeAsync(context, _ => Task.CompletedTask);

        var allMessages = string.Join(" ", _loggerProvider.Entries.Select(e => e.Message));
        Assert.That(allMessages, Does.Contain("x-request-id: req-abc"));
        Assert.That(allMessages, Does.Contain("x-ms-client-request-id: client-xyz"));
    }

    [Test]
    public async Task InvokeAsync_CapturesTraceId()
    {
        var context = CreateContext("GET", "/readiness");

        using var activity = new Activity("test-op").Start();
        var expectedTraceId = activity.TraceId.ToString();

        await _middleware.InvokeAsync(context, _ => Task.CompletedTask);

        var allMessages = string.Join(" ", _loggerProvider.Entries.Select(e => e.Message));
        Assert.That(allMessages, Does.Contain($"trace-id: {expectedTraceId}"));
    }

    [Test]
    public async Task InvokeAsync_DoesNotLogQueryString()
    {
        var context = CreateContext("GET", "/responses");
        context.Request.QueryString = new QueryString("?api-version=1.0&token=secret123");

        await _middleware.InvokeAsync(context, _ => Task.CompletedTask);

        var allMessages = string.Join(" ", _loggerProvider.Entries.Select(e => e.Message));
        Assert.That(allMessages, Does.Not.Contain("token=secret123"));
        Assert.That(allMessages, Does.Not.Contain("api-version"));
    }

    [Test]
    public async Task InvokeAsync_CallsNext()
    {
        var context = CreateContext("GET", "/test");
        var nextCalled = false;

        await _middleware.InvokeAsync(context, _ =>
        {
            nextCalled = true;
            return Task.CompletedTask;
        });

        Assert.That(nextCalled, Is.True);
    }

    [Test]
    public async Task InvokeAsync_LogsEvenWhenNextThrows()
    {
        var context = CreateContext("POST", "/responses");

        Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await _middleware.InvokeAsync(context, _ => throw new InvalidOperationException("boom"));
        });

        // Start log should still exist
        var startEntries = _loggerProvider.Entries.Where(e => e.Level == LogLevel.Information && e.Message.Contains("starting")).ToList();
        Assert.That(startEntries, Has.Count.EqualTo(1));

        // Completion log should also exist (logged in finally block; status defaults to 200)
        var completionEntries = _loggerProvider.Entries
            .Where(e => e.Message.Contains("completed") || e.Message.Contains("failed"))
            .ToList();
        Assert.That(completionEntries, Has.Count.EqualTo(1));
    }

    private static DefaultHttpContext CreateContext(string method, string path)
    {
        var context = new DefaultHttpContext();
        context.Request.Method = method;
        context.Request.Path = path;
        return context;
    }

    /// <summary>
    /// Simple logger provider that captures log entries for test assertions.
    /// </summary>
    private sealed class TestLoggerProvider : ILoggerProvider
    {
        private readonly List<LogEntry> _entries = new();

        public IReadOnlyList<LogEntry> Entries => _entries;

        public ILogger CreateLogger(string categoryName) => new TestLogger(_entries);

        public void Dispose() { }

        private sealed class TestLogger(List<LogEntry> entries) : ILogger
        {
            public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
            {
                entries.Add(new LogEntry(logLevel, formatter(state, exception)));
            }
        }
    }

    internal sealed record LogEntry(LogLevel Level, string Message);
}
