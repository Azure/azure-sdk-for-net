// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using OpenAI.Realtime;

namespace Azure.AI.Projects.Agents._Beta.VoiceAgents;

// The generated convenience overloads of GetAgentConversationItem(Async) attempt an invalid
// direct cast from ClientResult to RealtimeItem (CS0030). Suppress the broken generated
// overloads and provide correct implementations that deserialize the raw response instead,
// following the same pattern used elsewhere for OpenAI-defined response types.
[CodeGenSuppress("GetAgentConversationItem", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgentConversationItemAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
public partial class BetaVoiceAgentsConversations
{
    /// <summary>
    /// Retrieves a single item from the specified conversation by its id, including its transcript.
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The id of the conversation that contains the item. </param>
    /// <param name="itemId"> The id of the conversation item to retrieve. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    [Experimental("AAIP002")]
    public virtual ClientResult<RealtimeItem> GetAgentConversationItem(string agentName, string conversationId, string itemId, CancellationToken cancellationToken = default)
    {
        ClientResult result = GetAgentConversationItem(agentName, conversationId, itemId, cancellationToken.ToRequestOptions());
        PipelineResponse response = result.GetRawResponse();
        using JsonDocument document = JsonDocument.Parse(response.Content);
        RealtimeItem value = CustomSerializationHelpers.DeserializeProjectOpenAIType<RealtimeItem>(document.RootElement, ModelSerializationExtensions.WireOptions);
        return ClientResult.FromValue(value, response);
    }

    /// <summary>
    /// Retrieves a single item from the specified conversation by its id, including its transcript.
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The id of the conversation that contains the item. </param>
    /// <param name="itemId"> The id of the conversation item to retrieve. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    [Experimental("AAIP002")]
    public virtual async Task<ClientResult<RealtimeItem>> GetAgentConversationItemAsync(string agentName, string conversationId, string itemId, CancellationToken cancellationToken = default)
    {
        ClientResult result = await GetAgentConversationItemAsync(agentName, conversationId, itemId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();
        using JsonDocument document = JsonDocument.Parse(response.Content);
        RealtimeItem value = CustomSerializationHelpers.DeserializeProjectOpenAIType<RealtimeItem>(document.RootElement, ModelSerializationExtensions.WireOptions);
        return ClientResult.FromValue(value, response);
    }
}
