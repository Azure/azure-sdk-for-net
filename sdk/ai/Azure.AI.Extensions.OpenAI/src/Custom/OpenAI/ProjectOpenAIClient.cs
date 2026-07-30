// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading;
using OpenAI;
using OpenAI.Conversations;
using OpenAI.Files;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Provides OpenAI clients scoped to an Azure AI project. </summary>
public partial class ProjectOpenAIClient : OpenAIClient
{
    private ProjectConversationsClient _cachedConversationClient;
    private ProjectResponsesClient _cachedResponseClient;
    private ProjectFilesClient _cachedFileClient;
    private ProjectVectorStoresClient _cachedVectorStoreClient;

    private readonly ProjectOpenAIClientOptions _options;

    private static string s_defaultAuthorizationScope = "https://ai.azure.com/.default";

    /// <summary> Initializes a new instance of ProjectOpenAIClient from a <see cref="ProjectOpenAIClientSettings"/>. </summary>
    /// <param name="settings"> The settings for ProjectOpenAIClient. </param>
    [System.Diagnostics.CodeAnalysis.Experimental("SCME0002")]
    public ProjectOpenAIClient(ProjectOpenAIClientSettings settings)
        : this(AuthenticationPolicy.Create(settings), GetMergedOptions(settings?.Endpoint, settings?.CredentialProvider, settings?.Options))
    {
    }

    /// <summary> Initializes a new instance of <see cref="ProjectOpenAIClient"/>. </summary>
    /// <param name="projectEndpoint"> The Azure AI project endpoint. </param>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    /// <param name="options"> The options used to configure the client. </param>
    public ProjectOpenAIClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, ProjectOpenAIClientOptions options = null)
        : base(
            pipeline: CreatePipeline(
                CreateAuthenticationPolicy(tokenProvider, options),
                GetMergedOptions(projectEndpoint, tokenProvider, options)),
            options: GetMergedOptions(projectEndpoint, tokenProvider, options))
    {
        Argument.AssertNotNull(projectEndpoint, nameof(projectEndpoint));
        Argument.AssertNotNull(tokenProvider, nameof(tokenProvider));

        _options = GetMergedOptions(projectEndpoint, tokenProvider, options);
    }

    /// <summary> Initializes a new instance of <see cref="ProjectOpenAIClient"/>. </summary>
    /// <param name="authenticationPolicy"> The authentication policy used by the client pipeline. </param>
    /// <param name="options"> The options used to configure the client. </param>
    public ProjectOpenAIClient(AuthenticationPolicy authenticationPolicy, ProjectOpenAIClientOptions options)
        : base(
            pipeline: CreatePipeline(authenticationPolicy, options),
            options: options)
    {
        Argument.AssertNotNull(authenticationPolicy, nameof(authenticationPolicy));
        Argument.AssertNotNull(options, nameof(options));
        Argument.AssertNotNull(options.Endpoint, $"{nameof(options)}.{nameof(options.Endpoint)}");

        _options = options;
    }

    /// <summary> Initializes a new instance of <see cref="ProjectOpenAIClient"/>. </summary>
    /// <param name="pipeline"> The client pipeline used to send requests. </param>
    /// <param name="options"> The options used to configure the client. </param>
    protected internal ProjectOpenAIClient(ClientPipeline pipeline, ProjectOpenAIClientOptions options)
        : base(pipeline, options)
    {
        _options = options;
    }

    /// <summary> Initializes a new instance of <see cref="ProjectOpenAIClient"/> for mocking. </summary>
    protected ProjectOpenAIClient()
    { }

    /// <summary> Gets the project conversations client as the default conversation client. </summary>
    /// <returns> The project conversations client. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ConversationClient GetConversationClient()
        => GetProjectConversationsClient();

    /// <summary> Gets a client for project conversation operations. </summary>
    /// <returns> The project conversations client. </returns>
    public virtual ProjectConversationsClient GetProjectConversationsClient()
    {
        return Volatile.Read(ref _cachedConversationClient)
            ?? Interlocked.CompareExchange(ref _cachedConversationClient, new ProjectConversationsClient(Pipeline, _options), null)
            ?? _cachedConversationClient;
    }

    /// <summary> Gets a client for project file operations. </summary>
    /// <returns> The project files client. </returns>
    public virtual ProjectFilesClient GetProjectFilesClient()
    {
        return Volatile.Read(ref _cachedFileClient)
            ?? Interlocked.CompareExchange(ref _cachedFileClient, new ProjectFilesClient(Pipeline, _options), null)
            ?? _cachedFileClient;
    }

    /// <summary> Gets the project files client as the default OpenAI file client. </summary>
    /// <returns> The project files client. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override OpenAIFileClient GetOpenAIFileClient() => GetProjectFilesClient();

    /// <summary> Gets a client for project vector store operations. </summary>
    /// <returns> The project vector stores client. </returns>
    public virtual ProjectVectorStoresClient GetProjectVectorStoresClient()
    {
        return Volatile.Read(ref _cachedVectorStoreClient)
            ?? Interlocked.CompareExchange(ref _cachedVectorStoreClient, new ProjectVectorStoresClient(Pipeline, _options), null)
            ?? _cachedVectorStoreClient;
    }

    /// <summary> Gets a client for project response operations. </summary>
    /// <returns> The project responses client. </returns>
    public virtual ProjectResponsesClient GetProjectResponsesClient()
    {
        return Volatile.Read(ref _cachedResponseClient)
            ?? Interlocked.CompareExchange(ref _cachedResponseClient, new ProjectResponsesClient(Pipeline, _options, defaultAgent: null, defaultConversationId: null), null)
            ?? _cachedResponseClient;
    }

    /// <summary> Gets a project responses client that uses a default agent. </summary>
    /// <param name="defaultAgent"> The default agent used for response requests. </param>
    /// <param name="defaultConversationId"> The default conversation ID used for response requests. </param>
    /// <returns> The project responses client configured with the default agent. </returns>
    public virtual ProjectResponsesClient GetProjectResponsesClientForAgent(AgentReference defaultAgent, string defaultConversationId = null)
    {
        Argument.AssertNotNull(defaultAgent, nameof(defaultAgent));
        return new ProjectResponsesClient(
            Pipeline,
            _options,
            defaultAgent,
            defaultConversationId);
    }

    /// <summary> Gets a project responses client that sends requests to the specified agent endpoint. </summary>
    /// <param name="agentName"> The name of the agent endpoint to use. </param>
    /// <param name="defaultConversationId"> The default conversation ID used for response requests. </param>
    /// <param name="options"> The options used to configure the project responses client. </param>
    /// <returns> The project responses client configured for the agent endpoint. </returns>
    public virtual ProjectResponsesClient GetProjectResponsesClientForAgentEndpoint(string agentName, string defaultConversationId = null, ProjectOpenAIClientOptions options = null)
    {
        Argument.AssertNotNull(agentName, nameof(agentName));
        options ??= new();
        options.AgentName = agentName;
        options.TokenProvider = _options.TokenProvider;
        options.Endpoint = null;
        Match match = new Regex(@"(?<=/projects/)([^/]+)(?=[/?]|$)").Match(_options.Endpoint.LocalPath);
        string project = string.IsNullOrEmpty(match.Value) ? "_default" : match.Value;
        Uri projectEndpoint = new($"{_options.Endpoint.Scheme}://{_options.Endpoint.Host}/api/projects/{project}");
        options = GetMergedOptions(projectEndpoint, _options.TokenProvider, options);
        ClientPipeline endpointPipeline = CreatePipeline(CreateAuthenticationPolicy(options.TokenProvider, options), options);
        return new ProjectResponsesClient(
            pipeline: endpointPipeline,
            options: options,
            defaultAgent: null,
            defaultConversationId: defaultConversationId
        );
    }

    /// <summary> Gets a project responses client that uses a default model. </summary>
    /// <param name="defaultModel"> The default model used for response requests. </param>
    /// <param name="defaultConversationId"> The default conversation ID used for response requests. </param>
    /// <returns> The project responses client configured with the default model. </returns>
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

        TelemetryDetails telemetryDetails = new(typeof(OpenAIClient).Assembly, default);
        string prefix = "AIProjectClient";
        if (!string.IsNullOrEmpty(options.UserAgentApplicationId))
        {
            prefix = $"{options.UserAgentApplicationId}-AIProjectClient";
        }
        if (!string.IsNullOrEmpty(options.AgentName))
        {
            PipelinePolicyHelpers.AddQueryParameterPolicy(options, "api-version", options.ApiVersion);
        }
        PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "User-Agent", $"{prefix} {telemetryDetails.UserAgent}");
        PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "x-ms-client-request-id", () => Guid.NewGuid().ToString().ToLowerInvariant());
        PipelinePolicyHelpers.OpenAI.AddResponseItemInputTransformPolicy(options);
        PipelinePolicyHelpers.OpenAI.AddErrorTransformPolicy(options);
        PipelinePolicyHelpers.OpenAI.AddAzureFinetuningParityPolicy(options);

        return ClientPipeline.Create(options: options, perCallPolicies: [], perTryPolicies: [authenticationPolicy], beforeTransportPolicies: []);
    }

    internal static AuthenticationPolicy CreateAuthenticationPolicy(AuthenticationTokenProvider tokenProvider, ProjectOpenAIClientOptions options = null)
    {
        // Future: allow custom scope/audience via options in this path

        return new BearerTokenPolicy(tokenProvider, s_defaultAuthorizationScope);
    }

    internal static ProjectOpenAIClientOptions GetMergedOptions(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, ProjectOpenAIClientOptions options = null)
    {
        if (projectEndpoint is null)
        {
            return options;
        }
        string path = string.IsNullOrEmpty(options?.AgentName) ? "/openai/v1" : $"/agents/{options.AgentName}/endpoint/protocols/openai";
        string rawTargetOpenAIEndpoint = projectEndpoint.AbsoluteUri.TrimEnd('/') + path;
        if (options?.Endpoint is not null && options?.Endpoint?.AbsoluteUri != rawTargetOpenAIEndpoint)
        {
            throw new InvalidOperationException(
                $"Cannot supply both a constructor '{nameof(projectEndpoint)}' and {nameof(options)}.{nameof(options.Endpoint)}.");
        }
        options ??= new();
        options?.Endpoint ??= new Uri(rawTargetOpenAIEndpoint);
        options?.TokenProvider = tokenProvider;
        return options;
    }
}
