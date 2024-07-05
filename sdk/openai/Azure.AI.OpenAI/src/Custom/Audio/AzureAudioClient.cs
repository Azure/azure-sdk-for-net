﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Audio;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Audio;

/// <summary>
/// The scenario client used for audio operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureAudioClient : AudioClient
{
    private readonly string _deploymentName;
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureAudioClient(
        ClientPipeline pipeline,
        string deploymentName,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, model: deploymentName, endpoint, options)
    {
        options ??= new();
        _deploymentName = deploymentName;
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureAudioClient()
    { }
}
