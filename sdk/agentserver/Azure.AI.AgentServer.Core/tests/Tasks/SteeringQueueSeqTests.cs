// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// Guards the atomic <c>next_input_seq</c> allocation in <see cref="SteeringQueue{TOutput}"/>.
/// Concurrent oversized steering appends on the same chain must each receive a distinct seq so
/// their <c>_steering_input_&lt;seq&gt;</c> attachment keys never collide and silently overwrite one
/// another.
/// </summary>
[TestFixture]
public sealed class SteeringQueueSeqTests
{
    [Test]
    public void PromoteInputAdvancesSeqOnlyWhenAttachmentProduced()
    {
        var queue = new SteeringQueue<string>();

        // A small input (no attachment) must not burn a seq.
        (JsonNode? Slot, JsonObject? Attachments) small = queue.PromoteInput(_ => (JsonValue.Create("x"), null));
        Assert.That(small.Attachments, Is.Null);

        // Two oversized inputs (attachment produced) must get seq 0 then 1.
        int firstSeq = -1;
        int secondSeq = -1;
        queue.PromoteInput(seq => { firstSeq = seq; return (JsonValue.Create("ref"), new JsonObject()); });
        queue.PromoteInput(seq => { secondSeq = seq; return (JsonValue.Create("ref"), new JsonObject()); });

        Assert.That(firstSeq, Is.EqualTo(0));
        Assert.That(secondSeq, Is.EqualTo(1));
    }

    [Test]
    public async Task ConcurrentAttachmentPromotionsGetDistinctSeqs()
    {
        var queue = new SteeringQueue<string>();
        var observed = new ConcurrentBag<int>();
        const int count = 64;

        Task[] workers = Enumerable.Range(0, count).Select(_ => Task.Run(() =>
            queue.PromoteInput(seq =>
            {
                observed.Add(seq);
                // Every worker produces an attachment, so every call must consume a distinct seq.
                return ((JsonNode?)JsonValue.Create("ref"), new JsonObject());
            }))).ToArray();

        await Task.WhenAll(workers).ConfigureAwait(false);

        int[] seqs = observed.OrderBy(s => s).ToArray();
        Assert.That(seqs, Is.EquivalentTo(Enumerable.Range(0, count)),
            "each concurrent attachment promotion must reserve a unique, gap-free seq");
    }
}
