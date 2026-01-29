// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Assistants;

/// <summary>
/// The scenario client used for assistant operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureAssistantClient : AssistantClient
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureAssistantClient(ClientPipeline pipeline, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        options ??= new();

        _endpoint = endpoint;
        _apiVersion = options.GetRawServiceApiValueForClient(this);
    }

    protected AzureAssistantClient()
    { }

    public override async Task<ClientResult<ThreadRun>> GetRunAsync(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = await GetRunAsync(threadId, runId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(ModelReaderWriter.Read<ThreadRun>(protocolResult.GetRawResponse().Content, ModelReaderWriterOptions.Json, OpenAIContext.Default), protocolResult.GetRawResponse());
    }

    public override ClientResult<ThreadRun> GetRun(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = GetRun(threadId, runId, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(ModelReaderWriter.Read<ThreadRun>(protocolResult.GetRawResponse().Content, ModelReaderWriterOptions.Json, OpenAIContext.Default), protocolResult.GetRawResponse());
    }

    public override async Task<ClientResult<RunStep>> GetRunStepAsync(string threadId, string runId, string stepId, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = await GetRunStepAsync(threadId, runId, stepId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(ModelReaderWriter.Read<RunStep>(protocolResult.GetRawResponse().Content, ModelReaderWriterOptions.Json, OpenAIContext.Default), protocolResult.GetRawResponse());
    }

    public override ClientResult<RunStep> GetRunStep(string threadId, string runId, string stepId, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = GetRunStep(threadId, runId, stepId, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(ModelReaderWriter.Read<RunStep>(protocolResult.GetRawResponse().Content, ModelReaderWriterOptions.Json, OpenAIContext.Default), protocolResult.GetRawResponse());
    }
}

#endif
