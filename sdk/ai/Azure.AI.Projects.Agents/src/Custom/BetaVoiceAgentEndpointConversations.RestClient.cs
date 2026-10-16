// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

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
