// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

public partial class AgentAdministrationClient
{
    /// <summary>
    /// [Protocol Method] Generates and creates an agent from kind-specific high-level inputs.
    /// The generated definition remains fully editable through the standard agent versioning operations.
    /// <list type="bullet"><item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item></list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="System.ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult GenerateAgent(BinaryContent content, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline, () =>
        {
            Argument.AssertNotNull(content, nameof(content));
            return CreateGenerateAgentRequest(content, options);
        }, "AgentAdministrationClient.GenerateAgent", options);
    }

    /// <summary>
    /// [Protocol Method] Generates and creates an agent from kind-specific high-level inputs.
    /// The generated definition remains fully editable through the standard agent versioning operations.
    /// <list type="bullet"><item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item></list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="System.ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual Task<ClientResult> GenerateAgentAsync(BinaryContent content, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline, () =>
        {
            Argument.AssertNotNull(content, nameof(content));
            return CreateGenerateAgentRequest(content, options);
        }, "AgentAdministrationClient.GenerateAgent", options);
    }
}

public partial class BetaVoiceAgentsConversations
{
    /// <summary>
    /// [Protocol Method] Deletes a conversation and all of its stored data — responses, items, and any audio (cascade). This is
    /// the customer's explicit data-deletion control for voice conversations.
    /// <list type="bullet"><item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item></list>
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The conversation identifier. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="System.ArgumentNullException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="System.ArgumentException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult DeleteAgentConversation(string agentName, string conversationId, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline, () =>
        {
            Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
            Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
            return CreateDeleteAgentConversationRequest(agentName, conversationId, options);
        }, "BetaVoiceAgentsConversations.DeleteAgentConversation", options);
    }

    /// <summary>
    /// [Protocol Method] Deletes a conversation and all of its stored data — responses, items, and any audio (cascade). This is
    /// the customer's explicit data-deletion control for voice conversations.
    /// <list type="bullet"><item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item></list>
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The conversation identifier. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="System.ArgumentNullException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="System.ArgumentException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual Task<ClientResult> DeleteAgentConversationAsync(string agentName, string conversationId, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline, () =>
        {
            Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
            Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
            return CreateDeleteAgentConversationRequest(agentName, conversationId, options);
        }, "BetaVoiceAgentsConversations.DeleteAgentConversation", options);
    }
}

public partial class BetaVoiceAgentsTelephony
{
    internal virtual ClientResult CreateTelephonyBinding(string agentName, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateCreateTelephonyBindingRequest(agentName, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CreateTelephonyBinding", options);
    }

    internal virtual Task<ClientResult> CreateTelephonyBindingAsync(string agentName, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateCreateTelephonyBindingRequest(agentName, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CreateTelephonyBinding", options);
    }

    internal virtual ClientResult UpdateTelephonyBinding(string agentName, string bindingId, string ifMatch, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateUpdateTelephonyBindingRequest(agentName, bindingId, ifMatch, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.UpdateTelephonyBinding", options);
    }

    internal virtual Task<ClientResult> UpdateTelephonyBindingAsync(string agentName, string bindingId, string ifMatch, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateUpdateTelephonyBindingRequest(agentName, bindingId, ifMatch, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.UpdateTelephonyBinding", options);
    }

    internal virtual ClientResult DeleteTelephonyBinding(string agentName, string bindingId, string ifMatch, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateDeleteTelephonyBindingRequest(agentName, bindingId, ifMatch, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.DeleteTelephonyBinding", options);
    }

    internal virtual Task<ClientResult> DeleteTelephonyBindingAsync(string agentName, string bindingId, string ifMatch, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateDeleteTelephonyBindingRequest(agentName, bindingId, ifMatch, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.DeleteTelephonyBinding", options);
    }

    internal virtual ClientResult TransferTelephonyCall(string agentName, string callId, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateTransferTelephonyCallRequest(agentName, callId, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.TransferTelephonyCall", options);
    }

    internal virtual Task<ClientResult> TransferTelephonyCallAsync(string agentName, string callId, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateTransferTelephonyCallRequest(agentName, callId, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.TransferTelephonyCall", options);
    }

    internal virtual ClientResult EndTelephonyCall(string agentName, string callId, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateEndTelephonyCallRequest(agentName, callId, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.EndTelephonyCall", options);
    }

    internal virtual Task<ClientResult> EndTelephonyCallAsync(string agentName, string callId, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateEndTelephonyCallRequest(agentName, callId, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.EndTelephonyCall", options);
    }

    internal virtual ClientResult ReplaceTelephonyTransferTargets(string agentName, string ifMatch, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateReplaceTelephonyTransferTargetsRequest(agentName, ifMatch, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.ReplaceTelephonyTransferTargets", options);
    }

    internal virtual Task<ClientResult> ReplaceTelephonyTransferTargetsAsync(string agentName, string ifMatch, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateReplaceTelephonyTransferTargetsRequest(agentName, ifMatch, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.ReplaceTelephonyTransferTargets", options);
    }

    internal virtual ClientResult CreateTelephonyCallJob(string agentName, string idempotencyKey, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateCreateTelephonyCallJobRequest(agentName, idempotencyKey, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CreateTelephonyCallJob", options);
    }

    internal virtual Task<ClientResult> CreateTelephonyCallJobAsync(string agentName, string idempotencyKey, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateCreateTelephonyCallJobRequest(agentName, idempotencyKey, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CreateTelephonyCallJob", options);
    }

    internal virtual ClientResult CancelTelephonyCallJob(string agentName, string callJobId, string ifMatch, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateCancelTelephonyCallJobRequest(agentName, callJobId, ifMatch, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CancelTelephonyCallJob", options);
    }

    internal virtual Task<ClientResult> CancelTelephonyCallJobAsync(string agentName, string callJobId, string ifMatch, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateCancelTelephonyCallJobRequest(agentName, callJobId, ifMatch, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CancelTelephonyCallJob", options);
    }
}
