// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="ChainIdDerivation"/> — native conversation chain id derivation.
/// The id follows the <c>IdGenerator</c> convention: <c>cchain_{partition}{scope}</c> when a
/// conversation ID is present, otherwise <c>rchain_{partition}{scope}</c> for the response-linkage
/// chain, where <c>scope</c> is a deterministic 32-char alphanumeric digest of
/// <c>{agentName}\x1f{sessionId}</c>. Golden literals lock the cross-language wire format.
/// </summary>
public class ChainIdDerivationTests
{
    // A canonical response ID (caresp_ + 18-char partition key + 32-char entropy).
    private const string PartitionKey = "abcdef012345678900";
    private const string OtherPartitionKey = "fedcba987654321000";
    private const string ParentId = "caresp_abcdef012345678900abcdefghijklmnopqrstuvwxyz012345";
    // A different response ID that shares the same partition key as ParentId.
    private const string SamePartitionId = "caresp_abcdef0123456789000123456789abcdefghijklmnopqrstuv";
    // A response ID with a different partition key.
    private const string OtherPartitionId = "caresp_fedcba987654321000abcdefghijklmnopqrstuvwxyz012345";

    // Golden values (agentName="my-agent", sessionId="sess-1" unless noted). These are computed
    // independently and MUST match across language ports.
    private const string ScopeAgentSess = "itZLgvC1ZRyRQ39TX835yeESu0dzXz2w";
    private const string ScopeAgentEmptySession = "jlUPUZjxTUByQqHvZqGfeQ7ovQW0JEKB";
    private const string CchainNative = "cchain_" + PartitionKey + ScopeAgentSess;
    private const string RchainNative = "rchain_" + PartitionKey + ScopeAgentSess;
    private const string RchainOther = "rchain_" + OtherPartitionKey + ScopeAgentSess;
    // A raw (non-ID-format) conversation ID falls back to a deterministic partition key.
    private const string RawConvFallbackPartition = "12239fe74bac784300";
    private const string CchainRawConv = "cchain_" + RawConvFallbackPartition + ScopeAgentSess;

    private static AgentReference Agent(string name = "my-agent") => new(name);

    // ── Format ──

    [Test]
    public void Derive_ConversationId_ProducesNativeCchainId()
    {
        var result = ChainIdDerivation.Derive(ParentId, null, OtherPartitionId, Agent(), "sess-1");

        Assert.That(result, Does.StartWith("cchain_"));
        Assert.That(result, Has.Length.EqualTo("cchain_".Length + 18 + 32));
        Assert.That(result, Does.Match("^[A-Za-z0-9_-]{1,128}$"), "Must be a valid native/Task-API id");
    }

    [Test]
    public void Derive_NoConversationId_ProducesNativeRchainId()
    {
        var result = ChainIdDerivation.Derive(null, null, ParentId, Agent(), "sess-1");

        Assert.That(result, Does.StartWith("rchain_"));
        Assert.That(result, Has.Length.EqualTo("rchain_".Length + 18 + 32));
        Assert.That(result, Does.Match("^[A-Za-z0-9_-]{1,128}$"), "Must be a valid native/Task-API id");
    }

    // ── Cross-language golden contract ──

    [Test]
    public void Derive_ConversationIdInIdFormat_MatchesGoldenCchain()
    {
        // conversation_id is in canonical ID format → its embedded partition key is extracted.
        var result = ChainIdDerivation.Derive(ParentId, null, OtherPartitionId, Agent(), "sess-1");

        Assert.That(result, Is.EqualTo(CchainNative));
    }

    [Test]
    public void Derive_ResponseLinkage_MatchesGoldenRchain()
    {
        var result = ChainIdDerivation.Derive(null, null, ParentId, Agent(), "sess-1");

        Assert.That(result, Is.EqualTo(RchainNative));
    }

    [Test]
    public void Derive_LegacyFormatId_NormalizesPartitionKeyToMatchNewFormat()
    {
        // Legacy-format IDs embed a 16-char partition key at the end (48-char body). It must be
        // padded to the 18-char form ("00" suffix) so a chain mixing legacy and new-format IDs
        // resolves to the same partition key. This legacy id's embedded key is "abcdef0123456789",
        // which normalizes to ParentId's partition key "abcdef012345678900".
        const string legacyId = "caresp_0123456789abcdefghijklmnopqrstuvabcdef0123456789";
        var fromLegacy = ChainIdDerivation.Derive(null, null, legacyId, Agent(), "sess-1");

        Assert.That(fromLegacy, Is.EqualTo(RchainNative),
            "A legacy 16-char partition key must be padded to 18 chars to match the new format");
    }

    [Test]
    public void Derive_RawConversationId_UsesDeterministicFallbackPartition()
    {
        // A raw conversation ID (not in canonical ID format) has no embedded partition key,
        // so the partition is derived deterministically from (agent, session, source).
        var result = ChainIdDerivation.Derive("my-partition", null, ParentId, Agent(), "sess-1");

        Assert.That(result, Is.EqualTo(CchainRawConv));
    }

    [Test]
    public void Derive_NullSessionId_TreatedAsEmpty()
    {
        var result = ChainIdDerivation.Derive(null, null, ParentId, Agent(), null);

        Assert.That(result, Is.EqualTo("rchain_" + PartitionKey + ScopeAgentEmptySession));
    }

    // ── Determinism ──

    [Test]
    public void Derive_SameInputs_ReturnsSameChainId()
    {
        var result1 = ChainIdDerivation.Derive(null, ParentId, SamePartitionId, Agent(), "sess-1");
        var result2 = ChainIdDerivation.Derive(null, ParentId, SamePartitionId, Agent(), "sess-1");

        Assert.That(result1, Is.EqualTo(result2));
    }

    // ── Partition-key stability across a chain ──

    [Test]
    public void Derive_ResponsesSharingPartitionKey_ProduceSameChainId()
    {
        // previous_response_id is the source in one call; the same id appears as the
        // response_id (partition source of last resort) in the other. Both resolve to the
        // same partition key, so the chain ID must match across the whole conversation.
        var fromPrevious = ChainIdDerivation.Derive(null, ParentId, SamePartitionId, Agent(), "sess-1");
        var fromResponse = ChainIdDerivation.Derive(null, null, ParentId, Agent(), "sess-1");

        Assert.That(fromPrevious, Is.EqualTo(fromResponse),
            "Every response in the same partition should share one chain ID");
    }

    [Test]
    public void Derive_DifferentPartitionKey_ProducesDifferentChainId()
    {
        var result1 = ChainIdDerivation.Derive(null, null, ParentId, Agent(), "sess-1");
        var result2 = ChainIdDerivation.Derive(null, null, OtherPartitionId, Agent(), "sess-1");

        Assert.That(result1, Is.EqualTo(RchainNative));
        Assert.That(result2, Is.EqualTo(RchainOther));
        Assert.That(result1, Is.Not.EqualTo(result2));
    }

    // ── Partition source priority: conversation_id → previous_response_id → response_id ──

    [Test]
    public void Derive_ConversationId_TakesPriorityOverPreviousAndResponse()
    {
        var withConvOnly = ChainIdDerivation.Derive("conv-abc", null, ParentId, Agent(), "sess-1");
        var withAll = ChainIdDerivation.Derive("conv-abc", OtherPartitionId, ParentId, Agent(), "sess-1");

        Assert.That(withConvOnly, Is.EqualTo(withAll),
            "conversation_id is the partition source when present; the others are ignored");
    }

    [Test]
    public void Derive_PreviousResponseId_UsedWhenNoConversationId()
    {
        var fromPrevious = ChainIdDerivation.Derive(null, ParentId, OtherPartitionId, Agent(), "sess-1");
        var fromResponseDirect = ChainIdDerivation.Derive(null, null, ParentId, Agent(), "sess-1");

        Assert.That(fromPrevious, Is.EqualTo(fromResponseDirect),
            "previous_response_id is the partition source when conversation_id is absent");
    }

    // ── Empty strings treated as absent ──

    [Test]
    public void Derive_EmptyConversationId_FallsBackToPreviousResponseId()
    {
        var withEmpty = ChainIdDerivation.Derive("", ParentId, OtherPartitionId, Agent(), "sess-1");
        var withNull = ChainIdDerivation.Derive(null, ParentId, OtherPartitionId, Agent(), "sess-1");

        Assert.That(withEmpty, Is.EqualTo(withNull));
    }

    // ── Agent and session scoping ──

    [Test]
    public void Derive_DifferentAgentName_ProducesDifferentChainId()
    {
        var result1 = ChainIdDerivation.Derive("conv-abc", null, ParentId, Agent("agent-a"), "sess-1");
        var result2 = ChainIdDerivation.Derive("conv-abc", null, ParentId, Agent("agent-b"), "sess-1");

        Assert.That(result1, Is.Not.EqualTo(result2), "Different agents must not collide");
    }

    [Test]
    public void Derive_DifferentSessionId_ProducesDifferentChainId()
    {
        var result1 = ChainIdDerivation.Derive("conv-abc", null, ParentId, Agent(), "sess-1");
        var result2 = ChainIdDerivation.Derive("conv-abc", null, ParentId, Agent(), "sess-2");

        Assert.That(result1, Is.Not.EqualTo(result2), "Different sessions must not collide");
    }

    [Test]
    public void Derive_NullAgentReference_UsesDefaultName()
    {
        var withNull = ChainIdDerivation.Derive("conv-abc", null, ParentId, null, "sess-1");
        var withEmptyName = ChainIdDerivation.Derive("conv-abc", null, ParentId, Agent(""), "sess-1");

        Assert.That(withNull, Is.EqualTo(withEmptyName),
            "A null or empty agent name both fall back to the default agent name");
    }

    // ── Prefix namespacing: conversation-scope vs response-linkage never collide ──

    [Test]
    public void Derive_ConversationAndResponseLinkage_ShareScopeButDifferByPrefix()
    {
        // Addressing the same partition via conversation_id (cchain_) versus previous_response_id
        // (rchain_) is deliberately treated as two distinct chains — the prefix keeps them apart
        // even when the partition and scope are identical.
        var asConversation = ChainIdDerivation.Derive(ParentId, null, OtherPartitionId, Agent(), "sess-1");
        var asResponseLinkage = ChainIdDerivation.Derive(null, ParentId, SamePartitionId, Agent(), "sess-1");

        Assert.That(asConversation, Is.EqualTo(CchainNative));
        Assert.That(asResponseLinkage, Is.EqualTo(RchainNative));
        Assert.That(asConversation, Is.Not.EqualTo(asResponseLinkage),
            "cchain_ and rchain_ are non-colliding namespaces");
        // Same 18-char partition + 32-char scope suffix; only the prefix differs.
        Assert.That(asConversation[7..], Is.EqualTo(asResponseLinkage[7..]));
    }
}
