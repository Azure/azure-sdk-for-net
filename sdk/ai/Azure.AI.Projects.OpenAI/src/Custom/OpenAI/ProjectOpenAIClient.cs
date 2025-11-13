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
    public virtual ProjectConversationsClient Conversations => GetProjectConversationsClient();
    public virtual ProjectResponsesClient Responses => GetProjectResponsesClient();
    public virtual ProjectFilesClient Files => GetProjectFilesClient();
    public virtual ProjectVectorStoresClient VectorStores => GetProjectVectorStoresClient();

    private ProjectConversationsClient _cachedConversationClient;
    private ProjectResponsesClient _cachedResponseClient;
    private ProjectFilesClient _cachedFileClient;
    private ProjectVectorStoresClient _cachedVectorStoreClient;

    private readonly ProjectOpenAIClientOptions _options;

    private static string s_defaultAuthorizationScope = "https://ai.azure.com/.default";

    public ProjectOpenAIClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, ProjectOpenAIClientOptions options = null)
        : base(
            pipeline: CreatePipeline(
                CreateAuthenticationPolicy(tokenProvider, options),
                GetMergedOptions(projectEndpoint, options)),
            options: GetMergedOptions(projectEndpoint, options))
    {
        Argument.AssertNotNull(projectEndpoint, nameof(projectEndpoint));
        Argument.AssertNotNull(tokenProvider, nameof(tokenProvider));

        _options = GetMergedOptions(projectEndpoint, options);
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
        => GetProjectConversationsClient();

    public virtual ProjectConversationsClient GetProjectConversationsClient()
    {
        return Volatile.Read(ref _cachedConversationClient)
            ?? Interlocked.CompareExchange(ref _cachedConversationClient, new ProjectConversationsClient(Pipeline, _options), null)
            ?? _cachedConversationClient;
    }

    public virtual ProjectFilesClient GetProjectFilesClient()
    {
        return Volatile.Read(ref _cachedFileClient)
            ?? Interlocked.CompareExchange(ref _cachedFileClient, new ProjectFilesClient(Pipeline, _options), null)
            ?? _cachedFileClient;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override OpenAIFileClient GetOpenAIFileClient() => GetProjectFilesClient();

    public virtual ProjectVectorStoresClient GetProjectVectorStoresClient()
    {
        return Volatile.Read(ref _cachedVectorStoreClient)
            ?? Interlocked.CompareExchange(ref _cachedVectorStoreClient, new ProjectVectorStoresClient(Pipeline, _options), null)
            ?? _cachedVectorStoreClient;
    }

    public virtual ProjectResponsesClient GetProjectResponsesClient()
    {
        return Volatile.Read(ref _cachedResponseClient)
            ?? Interlocked.CompareExchange(ref _cachedResponseClient, new ProjectResponsesClient(Pipeline, _options, defaultAgent: null, defaultConversationId: null), null)
            ?? _cachedResponseClient;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override OpenAIResponseClient GetOpenAIResponseClient(string defaultModel)
        => GetProjectResponsesClientForModel(defaultModel);

    public virtual ProjectResponsesClient GetProjectResponsesClientForAgent(AgentReference defaultAgent, string defaultConversationId = null)
    {
        Argument.AssertNotNull(defaultAgent, nameof(defaultAgent));
        return new ProjectResponsesClient(
            Pipeline,
            _options,
            defaultAgent,
            defaultConversationId);
    }

    public virtual ProjectResponsesClient GetProjectResponsesClientForModel(string defaultModel, string defaultConversationId = null)
    {
        Argument.AssertNotNullOrEmpty(defaultModel, nameof(defaultModel));
        return new ProjectResponsesClient(
            Pipeline,
            _options,
            new AgentReference($"model:{defaultModel}"),
            defaultConversationId);
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

    internal static ProjectOpenAIClientOptions GetMergedOptions(Uri projectEndpoint, ProjectOpenAIClientOptions options = null)
    {
        if (projectEndpoint is null)
        {
            return options;
        }
        string rawTargetOpenAIEndpoint = projectEndpoint.AbsoluteUri.TrimEnd('/') + "/openai";
        if (options?.Endpoint is not null && options?.Endpoint?.AbsoluteUri != rawTargetOpenAIEndpoint)
        {
            throw new InvalidOperationException(
                $"Cannot supply both a constructor '{nameof(projectEndpoint)}' and {nameof(options)}.{nameof(options.Endpoint)}.");
        }
        options?.Endpoint ??= new Uri(rawTargetOpenAIEndpoint);
        return options;
    }
}
