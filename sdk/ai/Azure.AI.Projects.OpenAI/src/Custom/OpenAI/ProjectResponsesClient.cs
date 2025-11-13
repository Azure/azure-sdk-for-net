// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

public partial class ProjectResponsesClient : OpenAIResponseClient
{
    private readonly string _defaultModelName;
    private readonly string _defaultAgentName;
    private readonly string _defaultAgentVersion;
    private readonly string _defaultConversationId;

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/>.
    /// </summary>
    /// <remarks>
    /// This constructor will automatically construct the base URI for requests from the supplied <paramref name="projectEndpoint"/>
    /// value. To use a base URI directly, use the alternative constructor and set <see cref="OpenAIClientOptions.Endpoint"/> on the
    /// options supplied.
    /// </remarks>
    /// <param name="projectEndpoint"></param>
    /// <param name="tokenProvider"></param>
    /// <param name="options"></param>
    public ProjectResponsesClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, ProjectResponsesClientOptions options = null)
        : this(projectEndpoint, tokenProvider, defaultAgent: null, defaultConversationId: null, options)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="projectEndpoint"></param>
    /// <param name="tokenProvider"></param>
    /// <param name="defaultAgent"></param>
    /// <param name="defaultConversationId"></param>
    /// <param name="options"></param>
    public ProjectResponsesClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, AgentReference defaultAgent, string defaultConversationId, ProjectResponsesClientOptions options = null)
        : this(
              pipeline: ProjectOpenAIClient.CreatePipeline(
                  ProjectOpenAIClient.CreateAuthenticationPolicy(
                      tokenProvider,
                      ProjectOpenAIClient.GetMergedOptions(projectEndpoint, options)),
                  ProjectOpenAIClient.GetMergedOptions(projectEndpoint, options)),
              options: ProjectOpenAIClient.GetMergedOptions(projectEndpoint, options),
              defaultAgent: defaultAgent,
              defaultConversationId: defaultConversationId)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/>.
    /// </summary>
    /// <remarks>
    /// This constructor will directly use the supplied value from the provided <see cref="OpenAIClientOptions.Endpoint"/>
    /// and will perform no additional automatic resolution.
    /// </remarks>
    /// <param name="tokenProvider"></param>
    /// <param name="options"></param>
    public ProjectResponsesClient(AuthenticationTokenProvider tokenProvider, ProjectResponsesClientOptions options)
        : this(projectEndpoint: null, tokenProvider, defaultAgent: null, defaultConversationId: null, options)
    { }

    public ProjectResponsesClient(AuthenticationTokenProvider tokenProvider, ProjectResponsesClientOptions options = null, AgentReference defaultAgent = null, string defaultConversationId = null)
        : this(projectEndpoint: null, tokenProvider, defaultAgent, defaultConversationId, options)
    { }

    internal ProjectResponsesClient(ClientPipeline pipeline, OpenAIClientOptions options, AgentReference defaultAgent, string defaultConversationId)
        : base(pipeline, model: "placeholder", options)
    {
        if (defaultAgent?.Name?.ToLowerInvariant()?.StartsWith("model:") == true)
        {
            _defaultModelName = defaultAgent.Name.Substring("model:".Length);
        }
        else if (defaultAgent is not null)
        {
            _defaultAgentName = defaultAgent.Name;
            _defaultAgentVersion = defaultAgent.Version;
        }
        _defaultConversationId = defaultConversationId;
    }

    public override ClientResult<OpenAIResponse> CreateResponse(string userInputText, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ApplyClientDefaults(options);
        return base.CreateResponse(userInputText, options, cancellationToken);
    }

    public override ClientResult<OpenAIResponse> CreateResponse(IEnumerable<ResponseItem> inputItems, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ApplyClientDefaults(options);
        return base.CreateResponse(inputItems, options, cancellationToken);
    }

    public override Task<ClientResult<OpenAIResponse>> CreateResponseAsync(IEnumerable<ResponseItem> inputItems, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ApplyClientDefaults(options);
        return base.CreateResponseAsync(inputItems, options, cancellationToken);
    }

    public override Task<ClientResult<OpenAIResponse>> CreateResponseAsync(string userInputText, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ApplyClientDefaults(options);
        return base.CreateResponseAsync(userInputText, options, cancellationToken);
    }

    public override CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(IEnumerable<ResponseItem> inputItems, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ApplyClientDefaults(options);
        return base.CreateResponseStreaming(inputItems, options, cancellationToken);
    }

    public override CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(string userInputText, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ApplyClientDefaults(options);
        return base.CreateResponseStreaming(userInputText, options, cancellationToken);
    }

    public override AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(IEnumerable<ResponseItem> inputItems, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ApplyClientDefaults(options);
        return base.CreateResponseStreamingAsync(inputItems, options, cancellationToken);
    }

    public override AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(string userInputText, ResponseCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ApplyClientDefaults(options);
        return base.CreateResponseStreamingAsync(userInputText, options, cancellationToken);
    }

    protected ProjectResponsesClient()
    { }

    private void ApplyClientDefaults(ResponseCreationOptions options)
    {
        if (options.Agent is null && !string.IsNullOrEmpty(_defaultAgentName))
        {
            options.Agent = new AgentReference(_defaultAgentName, _defaultAgentVersion);
        }
        options.AgentConversationId ??= _defaultConversationId;
        if (options.Model is null)
        {
            options.Model = _defaultModelName ?? null;
        }
    }
}
