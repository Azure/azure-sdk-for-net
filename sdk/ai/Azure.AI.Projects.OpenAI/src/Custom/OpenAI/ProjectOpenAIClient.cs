// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading;
using Azure.AI.Projects.OpenAI;
using OpenAI;
using OpenAI.Conversations;
using OpenAI.Files;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

public partial class ProjectOpenAIClient : OpenAIClient
{
    // For use in derived clients, including across library boundaries
    protected internal ProjectOpenAIClient(ClientPipeline pipeline, OpenAIClientOptions options)
        : base(pipeline, options)
    {
        _options = options;
    }

    // For use in the same library
    internal static ProjectOpenAIClient Create(ClientPipeline pipeline, OpenAIClientOptions options) => new(pipeline, options);

    private ProjectOpenAIConversationClient _cachedConversationClient;
    private ProjectOpenAIResponseClient _cachedResponseClient;
    private ProjectOpenAIFileClient _cachedFileClient;
    public ProjectOpenAIConversationClient Conversations => GetProjectOpenAIConversationClient() as ProjectOpenAIConversationClient;
    public ProjectOpenAIResponseClient Responses => GetProjectOpenAIResponseClient() as ProjectOpenAIResponseClient;
    public ProjectOpenAIFileClient Files => GetProjectOpenAIFileClient() as ProjectOpenAIFileClient;

    private OpenAIClientOptions _options;

    public ProjectOpenAIClient(AuthenticationPolicy authenticationPolicy, OpenAIClientOptions options)
        : base(authenticationPolicy, options)
    {
        Argument.AssertNotNull(authenticationPolicy, nameof(authenticationPolicy));
        Argument.AssertNotNull(options, nameof(options));
        Argument.AssertNotNull(options.Endpoint, nameof(options.Endpoint));

        _options = options;
    }

    protected ProjectOpenAIClient()
    { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ConversationClient GetConversationClient()
        => GetProjectOpenAIConversationClient();

    public virtual ProjectOpenAIConversationClient GetProjectOpenAIConversationClient()
    {
        return Volatile.Read(ref _cachedConversationClient)
            ?? Interlocked.CompareExchange(ref _cachedConversationClient, new ProjectOpenAIConversationClient(Pipeline, _options), null)
            ?? _cachedConversationClient;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override OpenAIResponseClient GetOpenAIResponseClient(string _)
        => throw new InvalidOperationException();

    public virtual ProjectOpenAIFileClient GetProjectOpenAIFileClient()
    {
        return Volatile.Read(ref _cachedFileClient)
            ?? Interlocked.CompareExchange(ref _cachedFileClient, new ProjectOpenAIFileClient(Pipeline, _options), null)
            ?? _cachedFileClient;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override OpenAIFileClient GetOpenAIFileClient() => GetProjectOpenAIFileClient();

    public virtual ProjectOpenAIResponseClient GetProjectOpenAIResponseClient()
    {
        return Volatile.Read(ref _cachedResponseClient)
            ?? Interlocked.CompareExchange(ref _cachedResponseClient, new ProjectOpenAIResponseClient(Pipeline, _options, agentName: null, agentVersion: null, model: null), null)
            ?? _cachedResponseClient;
    }

    public virtual ProjectOpenAIResponseClient GetProjectOpenAIResponseClientForAgent(string agentName, string agentVersion = null)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        return new ProjectOpenAIResponseClient(Pipeline, _options, agentName, agentVersion, null);
    }

    public virtual ProjectOpenAIResponseClient GetProjectOpenAIResponseClientForModel(string model)
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));
        return new ProjectOpenAIResponseClient(Pipeline, _options, agentName: null, agentVersion: null, model);
    }
}
