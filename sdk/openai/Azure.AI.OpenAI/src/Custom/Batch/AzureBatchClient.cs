// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI.Batch;

namespace Azure.AI.OpenAI.Batch;

/// <summary>
/// The scenario client used for Files operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureBatchClient : BatchClient
{
    private readonly Uri _endpoint;
    private readonly string _deploymentName;
    private readonly string _apiVersion;

    internal AzureBatchClient(
        ClientPipeline pipeline,
        string deploymentName,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, endpoint, null)
    {
        options ??= new();
        Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
        _deploymentName = deploymentName;
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureBatchClient()
    { }
}
