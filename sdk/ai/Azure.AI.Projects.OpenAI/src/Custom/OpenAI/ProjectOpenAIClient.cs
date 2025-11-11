// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading;
using OpenAI;
using OpenAI.Conversations;
using OpenAI.Files;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

public partial class ProjectOpenAIClient : OpenAIClient
{
    public virtual ProjectOpenAIConversationClient Conversations => GetProjectOpenAIConversationClient();
    public virtual ProjectOpenAIResponseClient Responses => GetProjectOpenAIResponseClient();
    public virtual ProjectOpenAIFileClient Files => GetProjectOpenAIFileClient();
    public virtual ProjectOpenAIVectorStoreClient VectorStores => GetProjectOpenAIVectorStoreClient();

    private ProjectOpenAIConversationClient _cachedConversationClient;
    private ProjectOpenAIResponseClient _cachedResponseClient;
    private ProjectOpenAIFileClient _cachedFileClient;
    private ProjectOpenAIVectorStoreClient _cachedVectorStoreClient;

    private readonly ProjectOpenAIClientOptions _options;

    private static string s_defaultAuthorizationScope = "https://ai.azure.com/.default";

    public ProjectOpenAIClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, ProjectOpenAIClientOptions options = null)
        : base(
            pipeline: CreatePipeline(CreateAuthenticationPolicy(tokenProvider, options), options),
            options: CreateMergedOptions(projectEndpoint, options))
    {
        Argument.AssertNotNull(projectEndpoint, nameof(projectEndpoint));
        Argument.AssertNotNull(tokenProvider, nameof(tokenProvider));

        _options = options;
    }

    public ProjectOpenAIClient(AuthenticationPolicy authenticationPolicy, ProjectOpenAIClientOptions options)
        : base(
            pipeline: CreatePipeline(authenticationPolicy, options),
            options: options)
    {
        Argument.AssertNotNull(authenticationPolicy, nameof(authenticationPolicy));
        Argument.AssertNotNull(options, nameof(options));
        Argument.AssertNotNull(options.Endpoint, nameof(options.Endpoint));

        _options = options;
    }

    protected internal ProjectOpenAIClient(ClientPipeline pipeline, ProjectOpenAIClientOptions options)
        : base(pipeline, options)
    {
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
    public override OpenAIResponseClient GetOpenAIResponseClient(string model)
        => GetProjectOpenAIResponseClientForModel(model);

    public virtual ProjectOpenAIFileClient GetProjectOpenAIFileClient()
    {
        return Volatile.Read(ref _cachedFileClient)
            ?? Interlocked.CompareExchange(ref _cachedFileClient, new ProjectOpenAIFileClient(Pipeline, _options), null)
            ?? _cachedFileClient;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override OpenAIFileClient GetOpenAIFileClient() => GetProjectOpenAIFileClient();

    public virtual ProjectOpenAIVectorStoreClient GetProjectOpenAIVectorStoreClient()
    {
        return Volatile.Read(ref _cachedVectorStoreClient)
            ?? Interlocked.CompareExchange(ref _cachedVectorStoreClient, new ProjectOpenAIVectorStoreClient(Pipeline, _options), null)
            ?? _cachedVectorStoreClient;
    }

    public virtual ProjectOpenAIResponseClient GetProjectOpenAIResponseClient()
    {
        return Volatile.Read(ref _cachedResponseClient)
            ?? Interlocked.CompareExchange(ref _cachedResponseClient, new ProjectOpenAIResponseClient(Pipeline, _options, agentName: null, agentVersion: null, model: null, agentConversationId: null), null)
            ?? _cachedResponseClient;
    }

    public virtual ProjectOpenAIResponseClient GetProjectOpenAIResponseClientForAgent(AgentReference agent, string agentConversationId = null)
    {
        Argument.AssertNotNull(agent, nameof(agent));
        return new ProjectOpenAIResponseClient(Pipeline, _options, agent.Name, agent.Version, model: null, agentConversationId);
    }

    public virtual ProjectOpenAIResponseClient GetProjectOpenAIResponseClientForModel(string model)
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));
        return new ProjectOpenAIResponseClient(Pipeline, _options, agentName: null, agentVersion: null, model, agentConversationId: null);
    }

    internal static ClientPipeline CreatePipeline(AuthenticationPolicy authenticationPolicy, ProjectOpenAIClientOptions options)
    {
        options ??= new ProjectOpenAIClientOptions();

        TelemetryDetails telemetryDetails = new(typeof(ProjectOpenAIClient).Assembly, options?.UserAgentApplicationId);

        PipelinePolicyHelpers.AddQueryParameterPolicy(options, "api-version", options.ApiVersion);
        PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "User-Agent", telemetryDetails.UserAgent.ToString());
        PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "x-ms-client-request-id", () => Guid.NewGuid().ToString().ToLowerInvariant());
        PipelinePolicyHelpers.OpenAI.AddResponseItemInputTransformPolicy(options);
        PipelinePolicyHelpers.OpenAI.AddErrorTransformPolicy(options);
        PipelinePolicyHelpers.OpenAI.AddAzureFinetuningParityPolicy(options);

        return ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), new PipelinePolicy[] { authenticationPolicy }, Array.Empty<PipelinePolicy>());
    }

    internal static AuthenticationPolicy CreateAuthenticationPolicy(AuthenticationTokenProvider tokenProvider, ProjectOpenAIClientOptions options = null)
    {
        // Future: allow custom scope/audience via options in this path

        return new BearerTokenPolicy(tokenProvider, s_defaultAuthorizationScope);
    }

    internal static ProjectOpenAIClientOptions CreateMergedOptions(Uri projectEndpoint, ProjectOpenAIClientOptions options = null)
    {
        options = options?.GetClone() ?? new();

        string rawTargetOpenAIEndpoint = projectEndpoint.AbsoluteUri.TrimEnd('/') + "/openai";

        if (options.Endpoint is not null && options.Endpoint.AbsoluteUri != rawTargetOpenAIEndpoint)
        {
            throw new InvalidOperationException(
                $"Cannot supply both a constructor '{nameof(projectEndpoint)}' and {nameof(options)}.{nameof(options.Endpoint)}.");
        }

        options.Endpoint ??= new(rawTargetOpenAIEndpoint);

        return options;
    }
}
