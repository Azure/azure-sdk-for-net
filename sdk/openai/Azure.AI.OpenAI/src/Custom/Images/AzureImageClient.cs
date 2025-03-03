// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Images;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Images;

/// <summary>
/// The scenario client used for image operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureImageClient : ImageClient
{
    private readonly string _deploymentName;
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureImageClient(ClientPipeline pipeline, string deploymentName, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, model: deploymentName, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        options ??= new();

        _deploymentName = deploymentName;
        _endpoint = endpoint;
        _apiVersion = options.GetRawServiceApiValueForClient(this);
    }

    protected AzureImageClient()
    {}
}
