// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal.Resilience;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol parity tests for <see cref="ConversationChainIdDerivation"/> — the stable
/// conversation chain identity. Verifies the three per-case id shapes, stability across turns
/// and recovery, and cross-language digest parity with the Python
/// <c>derive_conversation_chain_id</c> reference.
/// </summary>
public class ConversationChainIdentityTests
{
    // Cross-language reference values computed from the chain-id derivation algorithm.
    private const string ScopeAgentXSess1 = "RBLFeBVUOcoVFCqzbF9tBNC15n6Sf4yV";
    private const string PkConvAbc = "c3b410bb8f04c7d100";

    [Test]
    public void ConversationId_ProducesCchainWithConvPartitionAndScope()
    {
        // conv_abc is not a native id → deterministic fallback partition key.
        var id = ConversationChainIdDerivation.Derive(
            conversationId: "conv_abc",
            previousResponseId: null,
            responseId: "caresp_x",
            agentName: "agent-x",
            sessionId: "sess_1",
            steerable: true);

        Assert.That(id, Is.EqualTo($"cchain_{PkConvAbc}{ScopeAgentXSess1}"));
    }

    [Test]
    public void Steerable_NoConversationId_ProducesRchain()
    {
        var id = ConversationChainIdDerivation.Derive(
            conversationId: null,
            previousResponseId: "caresp_prev",
            responseId: "caresp_x",
            agentName: "agent-x",
            sessionId: "sess_1",
            steerable: true);

        Assert.That(id, Does.StartWith("rchain_"));
        Assert.That(id, Does.EndWith(ScopeAgentXSess1));
    }

    [Test]
    public void Steerable_NoPrevious_UsesResponseIdAsPartitionSource()
    {
        var withResp = ConversationChainIdDerivation.Derive(
            null, null, "caresp_x", "agent-x", "sess_1", steerable: true);
        var withPrevEqualsResp = ConversationChainIdDerivation.Derive(
            null, "caresp_x", "caresp_x", "agent-x", "sess_1", steerable: true);

        Assert.That(withResp, Is.EqualTo(withPrevEqualsResp));
    }

    [Test]
    public void NonSteerable_OneShot_ReturnsResponseIdVerbatim()
    {
        var id = ConversationChainIdDerivation.Derive(
            conversationId: null,
            previousResponseId: null,
            responseId: "caresp_unique",
            agentName: "agent-x",
            sessionId: "sess_1",
            steerable: false);

        Assert.That(id, Is.EqualTo("caresp_unique"));
    }

    [Test]
    public void ConversationId_TakesPriorityOverPreviousAndSteerable()
    {
        var id = ConversationChainIdDerivation.Derive(
            conversationId: "conv_abc",
            previousResponseId: "caresp_prev",
            responseId: "caresp_x",
            agentName: "agent-x",
            sessionId: "sess_1",
            steerable: true);

        Assert.That(id, Does.StartWith("cchain_"));
    }

    [Test]
    public void Derivation_IsStableAcrossRepeatedCalls()
    {
        string Derive() => ConversationChainIdDerivation.Derive(
            "conv_abc", "caresp_prev", "caresp_x", "agent-x", "sess_1", true);

        Assert.That(Derive(), Is.EqualTo(Derive()));
    }

    [Test]
    public void SameConversation_DifferentResponseIds_ShareChainId()
    {
        var turn1 = ConversationChainIdDerivation.Derive(
            "conv_abc", null, "caresp_1", "agent-x", "sess_1", true);
        var turn2 = ConversationChainIdDerivation.Derive(
            "conv_abc", "caresp_1", "caresp_2", "agent-x", "sess_1", true);

        Assert.That(turn1, Is.EqualTo(turn2), "All turns of one conversation share the chain id");
    }

    [Test]
    public void DifferentAgents_ProduceDifferentScopes()
    {
        var a = ConversationChainIdDerivation.Derive("conv_abc", null, "caresp_x", "agent-a", "sess_1", true);
        var b = ConversationChainIdDerivation.Derive("conv_abc", null, "caresp_x", "agent-b", "sess_1", true);

        Assert.That(a, Is.Not.EqualTo(b));
    }
}
