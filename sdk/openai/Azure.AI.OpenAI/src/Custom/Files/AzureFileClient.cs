// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Files;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Files;

/// <summary>
/// The scenario client used for Files operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureFileClient : FileClient
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureFileClient(
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, endpoint, options)
    {
        options ??= new();
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureFileClient()
    { }
}
