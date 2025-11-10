// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    public ProjectOpenAIConversationClient Conversations => GetProjectOpenAIConversationClient();
    public ProjectOpenAIResponseClient Responses => GetProjectOpenAIResponseClient();
    public ProjectOpenAIFileClient Files => GetProjectOpenAIFileClient();
    public ProjectOpenAIVectorStoreClient VectorStores => GetProjectOpenAIVectorStoreClient();

    private ProjectOpenAIConversationClient _cachedConversationClient;
    private ProjectOpenAIResponseClient _cachedResponseClient;
    private ProjectOpenAIFileClient _cachedFileClient;
    private ProjectOpenAIVectorStoreClient _cachedVectorStoreClient;

    private readonly ProjectOpenAIClientOptions _options;

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

    public virtual ProjectOpenAIVectorStoreClient GetProjectOpenAIVectorStoreClient()
    {
        return Volatile.Read(ref _cachedVectorStoreClient)
            ?? Interlocked.CompareExchange(ref _cachedVectorStoreClient, new ProjectOpenAIVectorStoreClient(Pipeline, _options), null)
            ?? _cachedVectorStoreClient;
    }

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

    private static ClientPipeline CreatePipeline(AuthenticationPolicy authenticationPolicy, ProjectOpenAIClientOptions options)
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
}
