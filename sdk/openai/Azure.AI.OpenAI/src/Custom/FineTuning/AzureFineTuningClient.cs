// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.FineTuning;

/// <summary>
/// The scenario client used for fine-tuning operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureFineTuningClient : FineTuningClient
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureFineTuningClient(ClientPipeline pipeline, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        options ??= new();

        _endpoint = endpoint;
        _apiVersion = options.GetRawServiceApiValueForClient(this);
    }

    protected AzureFineTuningClient()
    { }

    internal override FineTuningJobOperation CreateCreateJobOperation(string jobId, string status, PipelineResponse response)
    {
        return new AzureFineTuningJobOperation(Pipeline, _endpoint, jobId, status, response, _apiVersion);
    }
}

#endif