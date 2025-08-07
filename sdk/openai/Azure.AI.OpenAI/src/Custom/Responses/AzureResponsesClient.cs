// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Responses;

/// <summary>
/// The scenario client used for Files operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureOpenAIResponseClient : OpenAIResponseClient
{
    private readonly Uri _aoaiEndpoint;
    private readonly string _deploymentName;
    private readonly string _apiVersion;

    internal AzureOpenAIResponseClient(ClientPipeline pipeline, string deploymentName, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, model: deploymentName, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        options ??= new();

        _aoaiEndpoint = endpoint;
        _deploymentName = deploymentName;
        _apiVersion = options.GetRawServiceApiValueForClient(this);
    }
}

#endif
