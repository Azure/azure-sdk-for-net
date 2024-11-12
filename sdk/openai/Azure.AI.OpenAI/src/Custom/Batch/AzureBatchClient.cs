// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;

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

    internal AzureBatchClient(ClientPipeline pipeline, string deploymentName, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        options ??= new();

        _deploymentName = deploymentName;
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureBatchClient()
    { }

    internal override CreateBatchOperation CreateCreateBatchOperation(string batchId, string status, PipelineResponse response)
    {
        return new AzureCreateBatchOperation(Pipeline, _endpoint, batchId, status, response, _deploymentName, _apiVersion);
    }
}

#endif