// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Assistants;
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

    internal AzureAssistantClient(
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, endpoint, null)
    {
        options ??= new();
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureAssistantClient()
    { }
}
