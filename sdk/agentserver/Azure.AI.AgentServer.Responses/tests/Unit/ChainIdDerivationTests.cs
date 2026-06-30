// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Text;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="ChainIdDerivation"/> — deterministic conversation
/// chain ID derivation: first 32 lowercase hex characters of
/// <c>SHA-256("{agentName}:{sessionId}:{discriminator}:{partition}")</c>, where the partition is
/// extracted from the conversation ID, previous response ID, or response ID, and the discriminator
/// namespaces the partition by source type.
/// </summary>
public class ChainIdDerivationTests
{
    private const int ExpectedLength = 32;

    // A canonical response ID (caresp_ + 18-char partition key + 32-char entropy).
    private const string PartitionKey = "abcdef012345678900";
    private const string ParentId = "caresp_abcdef012345678900abcdefghijklmnopqrstuvwxyz012345";
    // A different response ID that shares the same partition key as ParentId.
    private const string SamePartitionId = "caresp_abcdef0123456789000123456789abcdefghijklmnopqrstuv";
    // A response ID with a different partition key.
    private const string OtherPartitionId = "caresp_fedcba987654321000abcdefghijklmnopqrstuvwxyz012345";

    // ── Format ──

    [Test]
    public void Derive_Returns32CharLowercaseHex()
    {
        var result = ChainIdDerivation.Derive(null, null, ParentId, new AgentReference("my-agent"), "sess-1");

        Assert.That(result, Has.Length.EqualTo(ExpectedLength));
        Assert.That(result, Does.Match("^[0-9a-f]+$"), "Should be lowercase hex");
    }

    // ── Determinism ──

    [Test]
    public void Derive_SameInputs_ReturnsSameChainId()
    {
        var agent = new AgentReference("my-agent") { Version = "1.0" };

        var result1 = ChainIdDerivation.Derive(null, ParentId, SamePartitionId, agent, "sess-1");
        var result2 = ChainIdDerivation.Derive(null, ParentId, SamePartitionId, agent, "sess-1");

        Assert.That(result1, Is.EqualTo(result2));
    }

    // ── Partition-key stability across a chain ──

    [Test]
    public void Derive_ResponsesSharingPartitionKey_ProduceSameChainId()
    {
        var agent = new AgentReference("my-agent");

        // previous_response_id is the source in one call; the same id appears as the
        // response_id (partition source of last resort) in the other. Both share the
        // same partition key, so the chain ID must match across the whole conversation.
        var fromPrevious = ChainIdDerivation.Derive(null, ParentId, SamePartitionId, agent, "sess-1");
        var fromResponse = ChainIdDerivation.Derive(null, null, ParentId, agent, "sess-1");

        Assert.That(fromPrevious, Is.EqualTo(fromResponse),
            "Every response in the same partition should share one chain ID");
    }

    [Test]
    public void Derive_DifferentPartitionKey_ProducesDifferentChainId()
    {
        var agent = new AgentReference("my-agent");

        var result1 = ChainIdDerivation.Derive(null, null, ParentId, agent, "sess-1");
        var result2 = ChainIdDerivation.Derive(null, null, OtherPartitionId, agent, "sess-1");

        Assert.That(result1, Is.Not.EqualTo(result2));
    }

    // ── Partition source priority: conversation_id → previous_response_id → response_id ──

    [Test]
    public void Derive_ConversationId_TakesPriorityOverPreviousAndResponse()
    {
        var agent = new AgentReference("my-agent");

        var withConvOnly = ChainIdDerivation.Derive("conv-abc", null, ParentId, agent, "sess-1");
        var withAll = ChainIdDerivation.Derive("conv-abc", OtherPartitionId, ParentId, agent, "sess-1");

        Assert.That(withConvOnly, Is.EqualTo(withAll),
            "conversation_id is the partition source when present; the others are ignored");
    }

    [Test]
    public void Derive_PreviousResponseId_UsedWhenNoConversationId()
    {
        var agent = new AgentReference("my-agent");

        var fromPrevious = ChainIdDerivation.Derive(null, ParentId, OtherPartitionId, agent, "sess-1");
        var fromResponseDirect = ChainIdDerivation.Derive(null, null, ParentId, agent, "sess-1");

        Assert.That(fromPrevious, Is.EqualTo(fromResponseDirect),
            "previous_response_id is the partition source when conversation_id is absent");
    }

    // ── Empty strings treated as absent ──

    [Test]
    public void Derive_EmptyConversationId_FallsBackToPreviousResponseId()
    {
        var agent = new AgentReference("my-agent");

        var withEmpty = ChainIdDerivation.Derive("", ParentId, OtherPartitionId, agent, "sess-1");
        var withNull = ChainIdDerivation.Derive(null, ParentId, OtherPartitionId, agent, "sess-1");

        Assert.That(withEmpty, Is.EqualTo(withNull));
    }

    // ── Agent and session scoping ──

    [Test]
    public void Derive_DifferentAgentName_ProducesDifferentChainId()
    {
        var result1 = ChainIdDerivation.Derive("conv-abc", null, ParentId, new AgentReference("agent-a"), "sess-1");
        var result2 = ChainIdDerivation.Derive("conv-abc", null, ParentId, new AgentReference("agent-b"), "sess-1");

        Assert.That(result1, Is.Not.EqualTo(result2), "Different agents must not collide");
    }

    [Test]
    public void Derive_DifferentSessionId_ProducesDifferentChainId()
    {
        var agent = new AgentReference("my-agent");

        var result1 = ChainIdDerivation.Derive("conv-abc", null, ParentId, agent, "sess-1");
        var result2 = ChainIdDerivation.Derive("conv-abc", null, ParentId, agent, "sess-2");

        Assert.That(result1, Is.Not.EqualTo(result2), "Different sessions must not collide");
    }

    [Test]
    public void Derive_NullAgentReference_UsesDefaultName()
    {
        var withNull = ChainIdDerivation.Derive("conv-abc", null, ParentId, null, "sess-1");
        var withEmptyName = ChainIdDerivation.Derive("conv-abc", null, ParentId, new AgentReference(""), "sess-1");

        Assert.That(withNull, Is.EqualTo(withEmptyName),
            "A null or empty agent name both fall back to the default agent name");
    }

    // ── Cross-language seed contract ──

    [Test]
    public void Derive_MatchesSeedContract()
    {
        // No conversation ID + steerable => discriminator "chain", partition = extracted partition key.
        // The composite is "{agentName}:{sessionId}:{discriminator}:{partition}" hashed with SHA-256.
        var result = ChainIdDerivation.Derive(null, null, ParentId, new AgentReference("my-agent"), "sess-1");

        var composite = $"my-agent:sess-1:chain:{PartitionKey}";
        var expectedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(composite));
        var expected = Convert.ToHexString(expectedBytes).ToLowerInvariant()[..ExpectedLength];

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Derive_NullSessionId_TreatedAsEmpty()
    {
        var withNull = ChainIdDerivation.Derive(null, null, ParentId, new AgentReference("my-agent"), null);

        var composite = $"my-agent::chain:{PartitionKey}";
        var expectedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(composite));
        var expected = Convert.ToHexString(expectedBytes).ToLowerInvariant()[..ExpectedLength];

        Assert.That(withNull, Is.EqualTo(expected));
    }

    // ── Discriminator namespacing ──

    [Test]
    public void Derive_ConversationId_UsesConvDiscriminator()
    {
        // A raw conversation ID (not in canonical ID format) is used as-is for the partition,
        // namespaced by the "conv" discriminator.
        var result = ChainIdDerivation.Derive("my-partition", null, ParentId, new AgentReference("my-agent"), "sess-1");

        var composite = "my-agent:sess-1:conv:my-partition";
        var expectedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(composite));
        var expected = Convert.ToHexString(expectedBytes).ToLowerInvariant()[..ExpectedLength];

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Derive_DiscriminatorNamespacesIdenticalPartitionValues()
    {
        // Same raw partition value ("shared"), but one arrives as a conversation ID ("conv")
        // and the other as a chain source ("chain"). Neither value is in canonical ID format,
        // so the partition is the raw value in both cases; only the discriminator differs.
        var asConversation = ChainIdDerivation.Derive("shared", null, "ignored", new AgentReference("my-agent"), "sess-1");
        var asChain = ChainIdDerivation.Derive(null, "shared", "ignored", new AgentReference("my-agent"), "sess-1");

        Assert.That(asConversation, Is.Not.EqualTo(asChain),
            "Identical partition values from different sources must not collide");
    }
}
