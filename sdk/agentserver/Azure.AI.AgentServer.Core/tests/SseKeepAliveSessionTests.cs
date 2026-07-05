// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

/// <summary>
/// Unit tests for <see cref="SseKeepAliveSession"/>, the shared keep-alive helper
/// hoisted into Core so that <c>Azure.AI.AgentServer.Responses</c> and
/// <c>Azure.AI.AgentServer.Invocations</c> deliver symmetric keep-alive behavior.
/// </summary>
[TestFixture]
public class SseKeepAliveSessionTests
{
    [Test]
    public async Task Start_WithInfiniteInterval_DoesNotEmitKeepAlives()
    {
        using var stream = new MemoryStream();
        await using var session = SseKeepAliveSession.Start(
            stream, Timeout.InfiniteTimeSpan, NullLogger.Instance, "test");

        Assert.That(session.IsKeepAliveActive, Is.False);

        // Wait a bit and confirm nothing was written.
        await Task.Delay(150);
        Assert.That(stream.Length, Is.EqualTo(0));
    }

    [Test]
    public async Task Start_WithZeroOrNegativeInterval_DoesNotEmitKeepAlives()
    {
        using var stream = new MemoryStream();
        await using var session = SseKeepAliveSession.Start(
            stream, TimeSpan.Zero, NullLogger.Instance, "test");

        Assert.That(session.IsKeepAliveActive, Is.False);
        await Task.Delay(150);
        Assert.That(stream.Length, Is.EqualTo(0));
    }

    [Test]
    public async Task Start_WithPositiveInterval_EmitsKeepAlives()
    {
        using var stream = new MemoryStream();
        await using var session = SseKeepAliveSession.Start(
            stream, TimeSpan.FromMilliseconds(50), NullLogger.Instance, "test");

        Assert.That(session.IsKeepAliveActive, Is.True);

        // Poll for the comment to appear instead of using a fixed delay.
        var deadline = DateTime.UtcNow.AddSeconds(5);
        while (DateTime.UtcNow < deadline && stream.Length == 0)
        {
            await Task.Delay(25);
        }

        var output = Encoding.UTF8.GetString(stream.ToArray());
        Assert.That(output, Does.Contain(": keep-alive\n\n"));
    }

    [Test]
    public async Task EnableKeepAlive_AfterStart_ActivatesTimer()
    {
        using var stream = new MemoryStream();
        await using var session = SseKeepAliveSession.Start(
            stream, Timeout.InfiniteTimeSpan, NullLogger.Instance, "test");
        Assert.That(session.IsKeepAliveActive, Is.False);

        session.EnableKeepAlive(TimeSpan.FromMilliseconds(50));
        Assert.That(session.IsKeepAliveActive, Is.True);

        var deadline = DateTime.UtcNow.AddSeconds(5);
        while (DateTime.UtcNow < deadline && stream.Length == 0)
        {
            await Task.Delay(25);
        }
        Assert.That(stream.Length, Is.GreaterThan(0));
    }

    [Test]
    public async Task Stream_WriteAsync_SynchronizesWithKeepAliveTimer()
    {
        using var stream = new MemoryStream();
        await using var session = SseKeepAliveSession.Start(
            stream, TimeSpan.FromMilliseconds(20), NullLogger.Instance, "test");

        // Concurrently write 50 application frames while the timer emits keep-alives.
        var payload = "event: data\ndata: x\n\n"u8.ToArray();
        var tasks = new List<Task>();
        for (int i = 0; i < 50; i++)
        {
            tasks.Add(session.Stream.WriteAsync(payload, 0, payload.Length));
        }
        await Task.WhenAll(tasks);
        // Give the timer a chance to fire at least once.
        await Task.Delay(100);

        var output = Encoding.UTF8.GetString(stream.ToArray());
        // Each frame must be a fully formed "block" — never split by a keep-alive line.
        var blocks = output.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        foreach (var block in blocks)
        {
            Assert.That(
                block == ": keep-alive" || block == "event: data\ndata: x",
                Is.True,
                $"unexpected block: <{block}>");
        }
    }

    [Test]
    public async Task Stream_DisallowsRead()
    {
        using var stream = new MemoryStream();
        await using var session = SseKeepAliveSession.Start(
            stream, Timeout.InfiniteTimeSpan, NullLogger.Instance, "test");

        Assert.That(session.Stream.CanWrite, Is.True);
        Assert.That(session.Stream.CanRead, Is.False);
        Assert.That(session.Stream.CanSeek, Is.False);
        Assert.Throws<NotSupportedException>(() => session.Stream.Seek(0, SeekOrigin.Begin));
    }

    [Test]
    public async Task DisposeAsync_StopsTimer()
    {
        using var stream = new MemoryStream();
        var session = SseKeepAliveSession.Start(
            stream, TimeSpan.FromMilliseconds(20), NullLogger.Instance, "test");

        // Wait for one keep-alive to land.
        var deadline = DateTime.UtcNow.AddSeconds(5);
        while (DateTime.UtcNow < deadline && stream.Length == 0)
        {
            await Task.Delay(10);
        }

        await session.DisposeAsync();
        var lengthAfterDispose = stream.Length;
        await Task.Delay(150);

        // After dispose the timer must not have fired again.
        Assert.That(stream.Length, Is.EqualTo(lengthAfterDispose));
    }

    [Test]
    public async Task EnableKeepAlive_AfterDispose_Throws()
    {
        using var stream = new MemoryStream();
        var session = SseKeepAliveSession.Start(
            stream, Timeout.InfiniteTimeSpan, NullLogger.Instance, "test");
        await session.DisposeAsync();

        Assert.Throws<ObjectDisposedException>(() => session.EnableKeepAlive(TimeSpan.FromSeconds(1)));
    }

    [Test]
    public void Start_NullArgs_Throws()
    {
        using var stream = new MemoryStream();
        Assert.Throws<ArgumentNullException>(
            () => SseKeepAliveSession.Start(null!, Timeout.InfiniteTimeSpan, NullLogger.Instance, "test"));
        Assert.Throws<ArgumentNullException>(
            () => SseKeepAliveSession.Start(stream, Timeout.InfiniteTimeSpan, null!, "test"));
        Assert.Throws<ArgumentNullException>(
            () => SseKeepAliveSession.Start(stream, Timeout.InfiniteTimeSpan, NullLogger.Instance, null!));
    }
}
