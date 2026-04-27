// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Text;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="SessionIdDerivation"/> — deterministic session ID
/// derivation per B39 specification.
/// </summary>
public class SessionIdDerivationTests
{
    private const int ExpectedLength = 63;

    // ── Format tests ──

    [Test]
    public void Derive_NoContext_Returns63CharHex()
    {
        var result = SessionIdDerivation.Derive(null, null, null);

        Assert.That(result, Has.Length.EqualTo(ExpectedLength));
        Assert.That(result, Does.Match("^[0-9a-f]+$"), "Should be lowercase hex");
    }

    [Test]
    public void Derive_WithConversationId_Returns63CharHex()
    {
        var result = SessionIdDerivation.Derive("conv-123", null, null);

        Assert.That(result, Has.Length.EqualTo(ExpectedLength));
        Assert.That(result, Does.Match("^[0-9a-f]+$"));
    }

    // ── Determinism tests ──

    [Test]
    public void Derive_SameInputs_ReturnsSameSessionId()
    {
        var agentRef = new AgentReference("my-agent") { Version = "1.0.0" };

        var result1 = SessionIdDerivation.Derive("conv-abc", null, agentRef);
        var result2 = SessionIdDerivation.Derive("conv-abc", null, agentRef);

        Assert.That(result1, Is.EqualTo(result2), "Same inputs should produce same session ID");
    }

    [Test]
    public void Derive_DifferentConversationId_ReturnsDifferentSessionId()
    {
        var result1 = SessionIdDerivation.Derive("conv-aaa", null, null);
        var result2 = SessionIdDerivation.Derive("conv-bbb", null, null);

        Assert.That(result1, Is.Not.EqualTo(result2));
    }

    [Test]
    public void Derive_DifferentAgentVersion_ReturnsDifferentSessionId()
    {
        var agentV1 = new AgentReference("my-agent") { Version = "1.0.0" };
        var agentV2 = new AgentReference("my-agent") { Version = "2.0.0" };

        var result1 = SessionIdDerivation.Derive("conv-abc", null, agentV1);
        var result2 = SessionIdDerivation.Derive("conv-abc", null, agentV2);

        Assert.That(result1, Is.Not.EqualTo(result2),
            "Different agent versions should produce different session IDs");
    }

    // ── Priority tests ──

    [Test]
    public void Derive_ConversationId_TakesPriorityOverPreviousResponseId()
    {
        var withConvOnly = SessionIdDerivation.Derive("conv-abc", null, null);
        var withBoth = SessionIdDerivation.Derive("conv-abc", "caresp_abcdef0123456789001234567890123456789012345678901234", null);

        Assert.That(withConvOnly, Is.EqualTo(withBoth),
            "conversation_id should take priority; previous_response_id is ignored when conversation_id is present");
    }

    [Test]
    public void Derive_PreviousResponseId_UsedWhenNoConversationId()
    {
        var prevId = "caresp_abcdef0123456789001234567890123456789012345678901234";
        var result1 = SessionIdDerivation.Derive(null, prevId, null);

        Assert.That(result1, Has.Length.EqualTo(ExpectedLength));
        Assert.That(result1, Does.Match("^[0-9a-f]+$"));

        // Should be deterministic with same input
        var result2 = SessionIdDerivation.Derive(null, prevId, null);
        Assert.That(result1, Is.EqualTo(result2));
    }

    // ── No context → random tests ──

    [Test]
    public void Derive_NoContext_ProducesUniqueValues()
    {
        var result1 = SessionIdDerivation.Derive(null, null, null);
        var result2 = SessionIdDerivation.Derive(null, null, null);

        Assert.That(result1, Is.Not.EqualTo(result2),
            "Without conversational context, each derivation should be random/unique");
    }

    // ── Null/empty agent reference fallback ──

    [Test]
    public void Derive_NullAgentReference_UsesDefaultName()
    {
        var withNull = SessionIdDerivation.Derive("conv-abc", null, null);
        var withEmptyName = SessionIdDerivation.Derive("conv-abc", null,
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
        var result = SessionIdDerivation.Derive("partition_hint", null, agentRef);

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
        var responseId = IdGenerator.NewResponseId("some-hint");

        // Deriving with the full ID should use the extracted partition key
        var result1 = SessionIdDerivation.Derive(null, responseId, null);

        // The result should be deterministic
        var result2 = SessionIdDerivation.Derive(null, responseId, null);
        Assert.That(result1, Is.EqualTo(result2));
    }
}
