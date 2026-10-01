// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Conversations;
using OpenAI.Responses;

#pragma warning disable OPENAI001

namespace Azure.AI.Extensions.OpenAI;

public partial class ProjectConversationsClient
{
    /// <summary> Creates a conversation using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult<ProjectConversation> CreateProjectConversation(ProjectConversationCreationOptions options = null, CancellationToken cancellationToken = default)
        => CreateProjectConversationResource(ToNative<ConversationCreationOptions>(options), cancellationToken).ToAgentClientResult<ProjectConversation>();

    /// <summary> Creates a conversation using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult<ProjectConversation>> CreateProjectConversationAsync(ProjectConversationCreationOptions options = null, CancellationToken cancellationToken = default)
        => (await CreateProjectConversationResourceAsync(ToNative<ConversationCreationOptions>(options), cancellationToken).ConfigureAwait(false)).ToAgentClientResult<ProjectConversation>();

    /// <summary> Gets a conversation using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult<ProjectConversation> GetProjectConversation(string conversationId, CancellationToken cancellationToken = default)
        => GetProjectConversationResource(conversationId, cancellationToken).ToAgentClientResult<ProjectConversation>();

    /// <summary> Gets a conversation using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult<ProjectConversation>> GetProjectConversationAsync(string conversationId, CancellationToken cancellationToken = default)
        => (await GetProjectConversationResourceAsync(conversationId, cancellationToken).ConfigureAwait(false)).ToAgentClientResult<ProjectConversation>();

    /// <summary> Updates a conversation using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult<ProjectConversation> UpdateProjectConversation(string conversationId, ProjectConversationUpdateOptions options, CancellationToken cancellationToken = default)
        => UpdateProjectConversationResource(conversationId, ToNative<ConversationUpdateOptions>(options), cancellationToken).ToAgentClientResult<ProjectConversation>();

    /// <summary> Updates a conversation using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult<ProjectConversation>> UpdateProjectConversationAsync(string conversationId, ProjectConversationUpdateOptions options, CancellationToken cancellationToken = default)
        => (await UpdateProjectConversationResourceAsync(conversationId, ToNative<ConversationUpdateOptions>(options), cancellationToken).ConfigureAwait(false)).ToAgentClientResult<ProjectConversation>();

    /// <summary> Gets a conversation item using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult<AgentResponseItem> GetProjectConversationItem(string conversationId, string itemId, IEnumerable<IncludedConversationItemProperty> include = null, CancellationToken cancellationToken = default)
        => GetProjectResponseItem(conversationId, itemId, include, cancellationToken).ToAgentClientResult<AgentResponseItem>();

    /// <summary> Gets a conversation item using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult<AgentResponseItem>> GetProjectConversationItemAsync(string conversationId, string itemId, IEnumerable<IncludedConversationItemProperty> include = null, CancellationToken cancellationToken = default)
        => (await GetProjectResponseItemAsync(conversationId, itemId, include, cancellationToken).ConfigureAwait(false)).ToAgentClientResult<AgentResponseItem>();

    /// <summary> Lists conversations using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual CollectionResult<ProjectConversation> GetProjectConversations(AgentReference agent = null, int? limit = null, string order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        => new LegacyCollectionResult<ProjectConversation>(GetProjectConversationResources(agent, limit, order, after, before, cancellationToken));

    /// <summary> Lists conversations using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual AsyncCollectionResult<ProjectConversation> GetProjectConversationsAsync(AgentReference agent = null, int? limit = null, string order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        => new LegacyAsyncCollectionResult<ProjectConversation>(GetProjectConversationResourcesAsync(agent, limit, order, after, before, cancellationToken));

    /// <summary> Lists conversation items using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual CollectionResult<AgentResponseItem> GetProjectConversationItems(string conversationId, AgentResponseItemKind? itemKind = null, int? limit = null, string order = null, string after = null, string before = null, IEnumerable<IncludedConversationItemProperty> include = null, CancellationToken cancellationToken = default)
        => new LegacyCollectionResult<AgentResponseItem>(GetProjectResponseItems(conversationId, ToNativeKind(itemKind), limit, order, after, before, include, cancellationToken));

    /// <summary> Lists conversation items using the legacy model contract. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual AsyncCollectionResult<AgentResponseItem> GetProjectConversationItemsAsync(string conversationId, AgentResponseItemKind? itemKind = null, int? limit = null, string order = null, string after = null, string before = null, IEnumerable<IncludedConversationItemProperty> include = null, CancellationToken cancellationToken = default)
        => new LegacyAsyncCollectionResult<AgentResponseItem>(GetProjectResponseItemsAsync(conversationId, ToNativeKind(itemKind), limit, order, after, before, include, cancellationToken));

    private static ResponseItemKind? ToNativeKind(AgentResponseItemKind? kind) => kind.HasValue ? (ResponseItemKind)kind.Value : null;

    private static T ToNative<T>(object model) where T : class
        => model == null ? null : ModelReaderWriter.Read<T>(
            ModelReaderWriter.Write(model, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default),
            ModelSerializationExtensions.WireOptions, OpenAIContext.Default);
}
