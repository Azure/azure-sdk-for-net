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

public partial class ProjectOpenAIResponseClient : OpenAIResponseClient
{
    private readonly string _agentName;
    private readonly string _agentVersion;
    private readonly string _agentConversationId;

    public ProjectOpenAIResponseClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, ProjectOpenAIClientOptions options = null)
        : this(
              pipeline: ProjectOpenAIClient.CreatePipeline(ProjectOpenAIClient.CreateAuthenticationPolicy(tokenProvider, options), options),
              options: ProjectOpenAIClient.CreateMergedOptions(projectEndpoint, options),
              agentName: null,
              agentVersion: null,
              model: null,
              agentConversationId: null)
    {
    }

    public ProjectOpenAIResponseClient(AuthenticationTokenProvider tokenProvider, ProjectOpenAIClientOptions options)
        : this(
              pipeline: ProjectOpenAIClient.CreatePipeline(ProjectOpenAIClient.CreateAuthenticationPolicy(tokenProvider, options), options),
              options,
              agentName: null,
              agentVersion: null,
              model: null,
              agentConversationId: null)
    { }

    internal ProjectOpenAIResponseClient(ClientPipeline pipeline, OpenAIClientOptions options, string agentName, string agentVersion, string model, string agentConversationId)
        : base(pipeline, model, options)
    {
        _agentName = agentName;
        _agentVersion = agentVersion;
        _agentConversationId = agentConversationId;
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

    protected ProjectOpenAIResponseClient()
    { }

    private void ApplyClientDefaults(ResponseCreationOptions options)
    {
        AgentReference defaultAgent = string.IsNullOrEmpty(_agentName) ? null : new(_agentName, _agentVersion);
        options.Agent ??= defaultAgent;
        options.AgentConversationId ??= _agentConversationId;
    }
}
