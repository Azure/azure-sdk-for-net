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

    [Test]
    public void SessionInstanceIdScopesPhysicalTaskIdWithoutChangingPublicChainId()
    {
        const string sessionId = "same-public-name";
        Guid sessionInstanceId =
            Guid.ParseExact("11111111111111111111111111111111", "N");

        string publicChainId = ConversationChainIdDerivation.Derive(
            "conv_abc", null, "caresp_x", "agent-x", sessionId, true);
        string taskScope =
            TaskIdDerivation.DeriveSessionScope(sessionId, sessionInstanceId);
        string physicalTaskId = TaskIdDerivation.Derive(
            "conv_abc", null, "caresp_x", "agent-x", sessionId, taskScope, true);

        Assert.That(physicalTaskId, Is.Not.EqualTo(publicChainId));
    }

    [Test]
    public void DifferentSessionInstanceIdsProduceDifferentPhysicalTaskIds()
    {
        string first = TaskIdDerivation.Derive(
            "conv_abc",
            null,
            "caresp_x",
            "agent-x",
            "same-public-name",
            TaskIdDerivation.DeriveSessionScope(
                "same-public-name",
                Guid.ParseExact("11111111111111111111111111111111", "N")),
            true);
        string recreated = TaskIdDerivation.Derive(
            "conv_abc",
            null,
            "caresp_x",
            "agent-x",
            "same-public-name",
            TaskIdDerivation.DeriveSessionScope(
                "same-public-name",
                Guid.ParseExact("22222222222222222222222222222222", "N")),
            true);

        Assert.That(first, Is.Not.EqualTo(recreated));
    }

    [Test]
    public void MissingSessionInstanceIdPreservesLegacyTaskId()
    {
        const string sessionId = "public-session";
        string legacy = ConversationChainIdDerivation.Derive(
            "conv_abc", null, "caresp_x", "agent-x", sessionId, true);
        string physical = TaskIdDerivation.Derive(
            "conv_abc",
            null,
            "caresp_x",
            "agent-x",
            sessionId,
            TaskIdDerivation.DeriveSessionScope(sessionId, null),
            true);

        Assert.That(physical, Is.EqualTo(legacy));
    }

    [Test]
    public void SessionScopeIncludesPublicSessionId()
    {
        Guid sessionInstanceId =
            Guid.ParseExact("11111111111111111111111111111111", "N");

        Assert.That(
            TaskIdDerivation.DeriveSessionScope("session-a", sessionInstanceId),
            Is.Not.EqualTo(
                TaskIdDerivation.DeriveSessionScope("session-b", sessionInstanceId)));
    }

    [Test]
    public void SessionScopeUsesLowercaseNFormatting()
    {
        Guid sessionInstanceId =
            Guid.ParseExact("ABCDEFABCDEFABCDEFABCDEFABCDEFAB", "N");

        Assert.That(
            TaskIdDerivation.DeriveSessionScope("session-a", sessionInstanceId),
            Is.EqualTo("abcdefabcdefabcdefabcdefabcdefab\u001fsession-a"));
    }

    [Test]
    public void SessionInstanceIdDoesNotChangeOneShotTaskId()
    {
        string taskId = TaskIdDerivation.Derive(
            conversationId: null,
            previousResponseId: null,
            responseId: "caresp_one_shot",
            agentName: "agent-x",
            sessionId: "public-session",
            taskSessionId: TaskIdDerivation.DeriveSessionScope(
                "public-session",
                Guid.ParseExact("11111111111111111111111111111111", "N")),
            steerable: false);

        Assert.That(taskId, Is.EqualTo("caresp_one_shot"));
    }
}
