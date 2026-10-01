// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Realtime;

namespace Azure.AI.Projects.Agents;

// The generated convenience overloads cast ClientResult directly to RealtimeItem. Deserialize
// the protocol response instead, as RealtimeItem is defined by the OpenAI client library.
[CodeGenSuppress("GetAgentConversationItem", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgentConversationItemAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
public partial class AgentEndpointConversations
{
    /// <summary> Retrieves a single item from the specified conversation by its id, including its transcript. </summary>
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

    /// <summary> Retrieves a single item from the specified conversation by its id, including its transcript. </summary>
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
