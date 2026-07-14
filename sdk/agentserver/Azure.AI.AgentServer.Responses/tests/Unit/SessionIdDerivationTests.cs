// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Text;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="SessionIdDerivation"/> — deterministic session ID
/// derivation per B39 specification. The partition source is the conversation ID, the
/// previous_response_id, or (on the first turn) the response's own ID — never random —
/// so the session ID is stable across every turn of a chain.
/// </summary>
public class SessionIdDerivationTests
{
    private const int ExpectedLength = 63;

    // Valid response IDs (caresp_ + 18-char partition key + 32-char entropy).
    private const string ResponseId = "caresp_abcdef012345678900abcdefghijklmnopqrstuvwxyz012345";
    private const string OtherResponseId = "caresp_fedcba987654321000abcdefghijklmnopqrstuvwxyz012345";

    // ── Format tests ──

    [Test]
    public void Derive_ResponseIdFallback_Returns63CharHex()
    {
        var result = SessionIdDerivation.Derive(null, null, ResponseId, null);

        Assert.That(result, Has.Length.EqualTo(ExpectedLength));
        Assert.That(result, Does.Match("^[0-9a-f]+$"), "Should be lowercase hex");
    }

    [Test]
    public void Derive_WithConversationId_Returns63CharHex()
    {
        var result = SessionIdDerivation.Derive("conv-123", null, ResponseId, null);

        Assert.That(result, Has.Length.EqualTo(ExpectedLength));
        Assert.That(result, Does.Match("^[0-9a-f]+$"));
    }

    // ── Determinism tests ──

    [Test]
    public void Derive_SameInputs_ReturnsSameSessionId()
    {
        var agentRef = new AgentReference("my-agent") { Version = "1.0.0" };

        var result1 = SessionIdDerivation.Derive("conv-abc", null, ResponseId, agentRef);
        var result2 = SessionIdDerivation.Derive("conv-abc", null, ResponseId, agentRef);

        Assert.That(result1, Is.EqualTo(result2), "Same inputs should produce same session ID");
    }

    [Test]
    public void Derive_DifferentConversationId_ReturnsDifferentSessionId()
    {
        var result1 = SessionIdDerivation.Derive("conv-aaa", null, ResponseId, null);
        var result2 = SessionIdDerivation.Derive("conv-bbb", null, ResponseId, null);

        Assert.That(result1, Is.Not.EqualTo(result2));
    }

    [Test]
    public void Derive_DifferentAgentVersion_ReturnsDifferentSessionId()
    {
        var agentV1 = new AgentReference("my-agent") { Version = "1.0.0" };
        var agentV2 = new AgentReference("my-agent") { Version = "2.0.0" };

        var result1 = SessionIdDerivation.Derive("conv-abc", null, ResponseId, agentV1);
        var result2 = SessionIdDerivation.Derive("conv-abc", null, ResponseId, agentV2);

        Assert.That(result1, Is.Not.EqualTo(result2),
            "Different agent versions should produce different session IDs");
    }

    // ── Priority tests: conversation_id → previous_response_id → response_id ──

    [Test]
    public void Derive_ConversationId_TakesPriorityOverPreviousResponseId()
    {
        var withConvOnly = SessionIdDerivation.Derive("conv-abc", null, ResponseId, null);
        var withBoth = SessionIdDerivation.Derive("conv-abc", OtherResponseId, ResponseId, null);

        Assert.That(withConvOnly, Is.EqualTo(withBoth),
            "conversation_id should take priority; previous_response_id is ignored when conversation_id is present");
    }

    [Test]
    public void Derive_PreviousResponseId_TakesPriorityOverResponseId()
    {
        // previous_response_id is the source when conversation_id is absent; the response_id
        // fallback is ignored. Deriving with OtherResponseId as the previous id must match
        // deriving with it as the response_id fallback — both resolve to its partition.
        var fromPrevious = SessionIdDerivation.Derive(null, OtherResponseId, ResponseId, null);
        var fromResponseFallback = SessionIdDerivation.Derive(null, null, OtherResponseId, null);

        Assert.That(fromPrevious, Is.EqualTo(fromResponseFallback),
            "previous_response_id takes priority over the response_id fallback");
    }

    [Test]
    public void Derive_PreviousResponseId_UsedWhenNoConversationId()
    {
        var result1 = SessionIdDerivation.Derive(null, ResponseId, OtherResponseId, null);

        Assert.That(result1, Has.Length.EqualTo(ExpectedLength));
        Assert.That(result1, Does.Match("^[0-9a-f]+$"));

        // Should be deterministic with same input
        var result2 = SessionIdDerivation.Derive(null, ResponseId, OtherResponseId, null);
        Assert.That(result1, Is.EqualTo(result2));
    }

    // ── First-turn stability: the one-shot session salts the chain from turn 1 ──

    [Test]
    public void Derive_FirstTurnOneShot_AndSteeredSecondTurn_ShareSessionId()
    {
        var agent = new AgentReference("my-agent");

        // Turn 1 is a one-shot (no conversation_id, no previous_response_id): the session is
        // derived from the response's own partition key.
        var firstResponseId = IdGenerator.NewResponseId("");
        var firstTurn = SessionIdDerivation.Derive(null, null, firstResponseId, agent);

        // Turn 2 chains off turn 1. Its response inherits turn 1's partition key, and it points
        // back via previous_response_id — so it resolves to the SAME session ID.
        var secondResponseId = IdGenerator.NewResponseId(firstResponseId);
        var secondTurn = SessionIdDerivation.Derive(null, firstResponseId, secondResponseId, agent);

        Assert.That(secondTurn, Is.EqualTo(firstTurn),
            "The one-shot session must be stable from the first turn into the steered second turn");
    }

    [Test]
    public void Derive_NoConversationalContext_IsDeterministicFromResponseId()
    {
        var result1 = SessionIdDerivation.Derive(null, null, ResponseId, null);
        var result2 = SessionIdDerivation.Derive(null, null, ResponseId, null);

        Assert.That(result1, Is.EqualTo(result2),
            "Falling back to the response_id must be deterministic, not random");

        var other = SessionIdDerivation.Derive(null, null, OtherResponseId, null);
        Assert.That(result1, Is.Not.EqualTo(other),
            "Different response partitions should produce different session IDs");
    }

    // ── Null/empty agent reference fallback ──

    [Test]
    public void Derive_NullAgentReference_UsesDefaultName()
    {
        var withNull = SessionIdDerivation.Derive("conv-abc", null, ResponseId, null);
        var withEmptyName = SessionIdDerivation.Derive("conv-abc", null, ResponseId,
            new AgentReference("") { Version = "" });

        // Both should use the default agent name, producing the same result
        Assert.That(withNull, Is.EqualTo(withEmptyName));
    }

    // ── Cross-language compatibility ──

    [Test]
    public void Derive_MatchesCrossLanguageOutput()
    {
        // Verify the hash matches the cross-language contract for the same seed.
        // SHA-256("my-agent:1.0:partition_hint") truncated to 63 hex chars
        var agentRef = new AgentReference("my-agent") { Version = "1.0" };

        // Use a raw conversation_id that will be used as-is (not a valid ID for partition extraction)
        var result = SessionIdDerivation.Derive("partition_hint", null, ResponseId, agentRef);

        // Compute expected value independently
        var seed = "my-agent:1.0:partition_hint";
        var expectedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(seed));
        var expected = Convert.ToHexString(expectedBytes).ToLowerInvariant()[..63];

        Assert.That(result, Is.EqualTo(expected),
            "Should match cross-language SHA-256 derivation for the same seed");
    }

    // ── Partition key extraction from valid IDs ──

    [Test]
    public void Derive_ValidResponseId_ExtractsPartitionKey()
    {
        // Create a valid response ID with a known partition key
        var previousResponseId = IdGenerator.NewResponseId("some-hint");

        // Deriving with the full ID as previous_response_id should use the extracted partition key
        var result1 = SessionIdDerivation.Derive(null, previousResponseId, ResponseId, null);

        // The result should be deterministic
        var result2 = SessionIdDerivation.Derive(null, previousResponseId, ResponseId, null);
        Assert.That(result1, Is.EqualTo(result2));
    }
}
