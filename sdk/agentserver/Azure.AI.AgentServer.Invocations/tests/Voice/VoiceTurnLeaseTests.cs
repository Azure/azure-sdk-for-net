// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.AI.AgentServer.Invocations.Voice;
using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceTurnLeaseTests
{
    [Test]
    public void ReleasingTextDropsChunkBackingCapacity()
    {
        var item = new VoiceTextItem(new StubResponse(), "it_test");
        for (var index = 0; index < VoiceProtocolConstants.MaxOutputItemChunks; index++)
        {
            item.CommitDelta(string.Empty, deltaBytes: 0, escapedDeltaBytes: 0);
        }

        item.ReleaseText();

        var chunksField = typeof(VoiceTextItem).GetField("_chunks", BindingFlags.Instance | BindingFlags.NonPublic)!;
        var chunks = (List<string>)chunksField.GetValue(item)!;
        Assert.Multiple(() =>
        {
            Assert.That(chunks.Count, Is.Zero);
            Assert.That(chunks.Capacity, Is.Zero);
        });
    }

    [Test]
    public void OnlyOneNonTerminalTurnCanBeActive()
    {
        var lease = new VoiceTurnLease();
        lease.Activate(new StubResponse(), "reactive", release: null, activity: null);

        Assert.Throws<InvalidOperationException>(() =>
            lease.Activate(new StubResponse(), "proactive", release: null, activity: null));
    }

    [Test]
    public void TerminalStateCanBeCapturedExactlyOnce()
    {
        var lease = new VoiceTurnLease();
        var response = new StubResponse();
        lease.Activate(response, "reactive", release: null, activity: null);

        var first = lease.TryTerminate(response, "done");
        var second = lease.TryTerminate(response, "done");

        Assert.Multiple(() =>
        {
            Assert.That(first.IsNewTerminal, Is.True);
            Assert.That(first.TerminalKind, Is.EqualTo("done"));
            Assert.That(second.IsNewTerminal, Is.False);
            Assert.That(lease.Current, Is.Null);
        });
    }

    [Test]
    public void StaleGenerationCannotMutateReplacementTurn()
    {
        var lease = new VoiceTurnLease();
        var firstResponse = new StubResponse();
        var first = lease.Activate(firstResponse, "reactive", release: null, activity: null);
        lease.TryTerminate(firstResponse, "done");

        var secondResponse = new StubResponse();
        var second = lease.Activate(secondResponse, "proactive", release: null, activity: null);

        Assert.Multiple(() =>
        {
            Assert.That(lease.TrySetCustomerTask(first.Token, Task.CompletedTask), Is.False);
            Assert.That(lease.IsCurrent(first.Token), Is.False);
            Assert.That(lease.IsCurrent(second.Token), Is.True);
            Assert.That(lease.Current?.Response, Is.SameAs(secondResponse));
        });
    }

    [TestCase("reactive")]
    [TestCase("proactive")]
    public void ReactiveAndProactiveUseTheSameSlot(string kind)
    {
        var lease = new VoiceTurnLease();
        var response = new StubResponse();

        var activation = lease.Activate(response, kind, release: null, activity: null);

        Assert.Multiple(() =>
        {
            Assert.That(lease.Current?.Kind, Is.EqualTo(kind));
            Assert.That(lease.Current?.Response, Is.SameAs(response));
            Assert.That(lease.IsCurrent(activation.Token), Is.True);
        });
    }

    private sealed class StubResponse : VoiceResponse
    {
    }
}
