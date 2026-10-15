// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public class FileCloseRetryRegressionTests
{
    [TestCase("before-write")]
    [TestCase("partial-write")]
    [TestCase("after-flush")]
    public async Task FileCloseRetryPreservesValidReplay(string failure)
    {
        string directory = Path.Combine(Path.GetTempPath(), "agentserver-close-retry-" + Guid.NewGuid().ToString("N"));
        try
        {
            using (var stream = new FileBackedReplayEventStream("input", directory, TimeSpan.FromMinutes(5), () => { }, "task"))
            {
                await stream.EmitAsync(new SseItem<string>("before") { EventId = "1" });
                InstallFaultingWriter(stream, Path.Combine(directory, "input.jsonl"), failure);
                Assert.ThrowsAsync<AgentEventStreamException>(async () => await stream.CloseAsync());
                await stream.CloseAsync();
            }

            using var reopened = new FileBackedReplayEventStream("input", directory, TimeSpan.FromMinutes(5), () => { }, "task");
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            var events = new List<SseItem<string>>();
            await foreach (SseItem<string> item in reopened.Subscribe(cancellationToken: timeout.Token))
            {
                events.Add(item);
            }

            Assert.That(events.Count, Is.EqualTo(1));
            Assert.That(events[0].Data, Is.EqualTo("before"));
        }
        finally
        {
            if (Directory.Exists(directory))
            { Directory.Delete(directory, recursive: true); }
        }
    }

    [TestCase("partial-write", false)]
    [TestCase("after-flush", false)]
    [TestCase("partial-write", true)]
    [TestCase("after-flush", true)]
    public async Task FailedEmitThenRetryDoesNotDuplicateOrCorruptHistory(string failure, bool compactBeforeRetry)
    {
        string directory = Path.Combine(Path.GetTempPath(), "agentserver-emit-retry-" + Guid.NewGuid().ToString("N"));
        try
        {
            using (var stream = new FileBackedReplayEventStream("input", directory, TimeSpan.FromMinutes(5), () => { }, "task"))
            {
                await stream.EmitAsync(new SseItem<string>("before") { EventId = "1" });
                InstallFaultingWriter(stream, Path.Combine(directory, "input.jsonl"), failure);
                var evt = new SseItem<string>("after") { EventId = "2" };
                Assert.ThrowsAsync<AgentEventStreamException>(async () => await stream.EmitAsync(evt));
                if (compactBeforeRetry)
                {
                    typeof(FileBackedReplayEventStream).GetMethod("Compact", BindingFlags.Instance | BindingFlags.NonPublic)!.Invoke(stream, null);
                }
                await stream.EmitAsync(evt);
                await stream.CloseAsync();
            }

            using var reopened = new FileBackedReplayEventStream("input", directory, TimeSpan.FromMinutes(5), () => { }, "task");
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            var events = new List<string>();
            await foreach (SseItem<string> item in reopened.Subscribe(cancellationToken: timeout.Token))
            { events.Add(item.Data); }
            Assert.That(events, Is.EqualTo(new[] { "before", "after" }));
        }
        finally
        {
            if (Directory.Exists(directory))
            { Directory.Delete(directory, recursive: true); }
        }
    }

    [Test]
    public async Task AFailedTailRepairIsNotTreatedAsSuccessfulClose()
    {
        string directory = Path.Combine(Path.GetTempPath(), "agentserver-close-repair-" + Guid.NewGuid().ToString("N"));
        try
        {
            using (var stream = new FileBackedReplayEventStream("input", directory, TimeSpan.FromMinutes(5), () => { }, "task"))
            {
                await stream.EmitAsync(new SseItem<string>("before") { EventId = "1" });
                InstallFaultingWriter(stream, Path.Combine(directory, "input.jsonl"), "partial-write", failRepair: true);
                Assert.ThrowsAsync<AgentEventStreamException>(async () => await stream.CloseAsync());
                Assert.ThrowsAsync<AgentEventStreamException>(async () => await stream.CloseAsync());
                await stream.CloseAsync();
            }

            using var reopened = new FileBackedReplayEventStream("input", directory, TimeSpan.FromMinutes(5), () => { }, "task");
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            int count = 0;
            await foreach (SseItem<string> item in reopened.Subscribe(cancellationToken: timeout.Token))
            {
                Assert.That(item.Data, Is.EqualTo("before"));
                count++;
            }
            Assert.That(count, Is.EqualTo(1));
        }
        finally
        {
            if (Directory.Exists(directory))
            { Directory.Delete(directory, recursive: true); }
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public void ExistingOnlyOpenDoesNotCreateReplayData(bool directoryExists)
    {
        string directory = Path.Combine(Path.GetTempPath(), "agentserver-existing-only-" + Guid.NewGuid().ToString("N"));
        try
        {
            if (directoryExists)
            { Directory.CreateDirectory(directory); }
            using FileBackedReplayEventStream? stream = FileBackedReplayEventStream.OpenExisting(
                "input", directory, TimeSpan.FromMinutes(5), () => { }, "task");
            Assert.That(stream, Is.Null);
            Assert.That(Directory.Exists(directory), Is.EqualTo(directoryExists));
            if (directoryExists)
            { Assert.That(Directory.GetFiles(directory), Is.Empty); }
        }
        finally
        {
            if (Directory.Exists(directory))
            { Directory.Delete(directory, recursive: true); }
        }
    }

    [Test]
    public async Task ExistingOnlyOpenCannotClaimAnotherTasksBacking()
    {
        string directory = Path.Combine(Path.GetTempPath(), "agentserver-existing-owner-" + Guid.NewGuid().ToString("N"));
        try
        {
            using (var stream = new FileBackedReplayEventStream("input", directory, TimeSpan.FromMinutes(5), () => { }, "original"))
            {
                await stream.EmitAsync(new SseItem<string>("before") { EventId = "1" });
            }
            Assert.That(
                () => FileBackedReplayEventStream.OpenExisting("input", directory, TimeSpan.FromMinutes(5), () => { }, "other"),
                Throws.TypeOf<AgentEventStreamException>());
            Assert.That(File.ReadAllText(Path.Combine(directory, "input.owner")).Trim(), Is.EqualTo("original"));
            File.Delete(Path.Combine(directory, "input.jsonl"));
            using FileBackedReplayEventStream? missing = FileBackedReplayEventStream.OpenExisting(
                "input", directory, TimeSpan.FromMinutes(5), () => { }, "original");
            Assert.That(missing, Is.Null);
            Assert.That(File.Exists(Path.Combine(directory, "input.jsonl")), Is.False);
        }
        finally
        {
            if (Directory.Exists(directory))
            { Directory.Delete(directory, recursive: true); }
        }
    }

    private static void InstallFaultingWriter(FileBackedReplayEventStream backing, string path, string failure, bool failRepair = false)
    {
        FieldInfo field = typeof(FileBackedReplayEventStream).GetField("_data", BindingFlags.Instance | BindingFlags.NonPublic)!;
        ((FileStream)field.GetValue(backing)!).Dispose();
        field.SetValue(backing, new FailingFileStream(path, failure, failRepair));
    }

    private sealed class FailingFileStream : FileStream
    {
        private readonly string _failure;
        private bool _failed;
        private bool _failRepair;

        public FailingFileStream(string path, string failure, bool failRepair) : base(path, FileMode.Open, FileAccess.Write, FileShare.Read)
        {
            _failure = failure;
            _failRepair = failRepair;
            Seek(0, SeekOrigin.End);
        }

        public override void SetLength(long value)
        {
            if (_failRepair)
            {
                _failRepair = false;
                throw new IOException("Injected tail-repair failure.");
            }
            base.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (!_failed && _failure != "after-flush")
            {
                _failed = true;
                if (_failure == "partial-write")
                { base.Write(buffer, offset, count / 2); }
                throw new IOException("Injected write failure.");
            }
            base.Write(buffer, offset, count);
        }

        public override void Flush(bool flushToDisk)
        {
            base.Flush(flushToDisk);
            if (!_failed && _failure == "after-flush")
            {
                _failed = true;
                throw new IOException("Injected acknowledgement failure after flush.");
            }
        }
    }
}
