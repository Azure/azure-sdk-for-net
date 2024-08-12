// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Assistants;
using Azure.AI.OpenAI.Audio;
using Azure.AI.OpenAI.Batch;
using Azure.AI.OpenAI.Chat;
using Azure.AI.OpenAI.Embeddings;
using Azure.AI.OpenAI.Files;
using Azure.AI.OpenAI.FineTuning;
using Azure.AI.OpenAI.Images;
using Azure.AI.OpenAI.VectorStores;
using Azure.Core;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Images;
using OpenAI.Models;
using OpenAI.Moderations;
using OpenAI.VectorStores;

#pragma warning disable AZC0007

namespace Azure.AI.OpenAI;

/// <summary>
/// The top-level client for the Azure OpenAI service.
/// </summary>
/// <remarks>
/// For scenario-specific operations, create a corresponding client using the matching method on this type, e.g. <see cref="GetChatClient(string)"/>.
/// </remarks>
public partial class AzureOpenAIClient : OpenAIClient
{
    private readonly AzureOpenAIClientOptions _options;

    /// <summary>
    /// Creates a new instance of <see cref="AzureOpenAIClient"/> that will connect to a specified Azure OpenAI
    /// service resource endpoint using an API key.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For token-based authentication, including the use of managed identity, please use the alternate constructor:
    /// <see cref="AzureOpenAIClient(Uri,TokenCredential,AzureOpenAIClientOptions)"/>
    /// </para>
    /// </remarks>
    /// <param name="endpoint">
    /// <para>
    /// The Azure OpenAI resource endpoint to use. This should not include model deployment or operation information.
    /// </para>
    /// <para>
    /// Example: <c>https://my-resource.openai.azure.com</c>
    /// </para>
    /// </param>
    /// <param name="credential"> The API key to use when authenticating with the specified endpoint. </param>
    /// <param name="options"> Additional options for the client. </param>
    public AzureOpenAIClient(Uri endpoint, ApiKeyCredential credential, AzureOpenAIClientOptions options = null)
        : this(
            CreatePipeline(GetApiKey(credential, requireExplicitCredential: true), options),
            GetEndpoint(endpoint, requireExplicitEndpoint: true),
            options)
    {}

    /// <inheritdoc cref="AzureOpenAIClient(Uri,ApiKeyCredential,AzureOpenAIClientOptions)"/>
    public AzureOpenAIClient(Uri endpoint, AzureKeyCredential credential, AzureOpenAIClientOptions options = null)
        : this(
              CreatePipeline(GetApiKey(new ApiKeyCredential(credential?.Key), requireExplicitCredential: true), options),
              GetEndpoint(endpoint, requireExplicitEndpoint: true),
              options)
    {}

    /// <summary>
    /// Creates a new instance of <see cref="AzureOpenAIClient"/> that will connect to an Azure OpenAI service resource
    /// using endpoint and authentication settings from available configuration information.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For token-based authentication, including the use of managed identity, please use the alternate constructor:
    /// <see cref="AzureOpenAIClient(Uri,TokenCredential,AzureOpenAIClientOptions)"/>
    /// </para>
    /// <para>
    /// The client selects its resource endpoint in the following order of precedence:
    /// <list type="number">
    /// <item> The <see cref="OpenAIClientOptions.Endpoint"/> property on <paramref name="options"/>, if available </item>
    /// <item> The setting in an applicable IConfiguration instance, if available </item>
    /// <item> The value of the <c>AZURE_OPENAI_ENDPOINT</c> environment variable, if present </item>
    /// </list>
    /// </para>
    /// The client selects its API key credential in the following order of precedence:
    /// <list type="number">
    /// <item> The setting in an applicable IConfiguration instance, if available </item>
    /// <item> The value of the <c>AZURE_OPENAI_API_KEY</c> environment variable, if present </item>
    /// </list>
    /// <para>
    /// Note: resource endpoints should not include model deployment or operation information.
    /// </para>
    /// <para>
    /// Example: <c>https://my-resource.openai.azure.com</c>
    /// </para>
    /// </remarks>
    /// <param name="options"> Additional options for the client. </param>
    public AzureOpenAIClient(AzureOpenAIClientOptions options = null)
        : this(CreatePipeline(GetApiKey(), options), GetEndpoint(), options)
    {}

    /// <summary>
    /// Creates a new instance of <see cref="AzureOpenAIClient"/> that will connect to an Azure OpenAI service resource
    /// using token authentication, including for tokens issued via managed identity.
    /// </summary>
    /// <remarks>
    /// For API-key-based authentication, please use the alternate constructor:
    /// <see cref="AzureOpenAIClient(Uri,ApiKeyCredential,AzureOpenAIClientOptions)"/>
    /// </remarks>
    /// <param name="endpoint">
    /// <para>
    /// The Azure OpenAI resource endpoint to use. This should not include model deployment or operation information.
    /// </para>
    /// <para>
    /// Example: <c>https://my-resource.openai.azure.com</c>
    /// </para>
    /// </param>
    /// <param name="credential">
    /// <para>
    /// The API key to use when authenticating with the provided endpoint.
    /// </para>
    /// </param>
    /// <param name="options"> The scenario-independent options to use. </param>
    public AzureOpenAIClient(Uri endpoint, TokenCredential credential, AzureOpenAIClientOptions options = null)
        : this(CreatePipeline(credential, options), GetEndpoint(endpoint, requireExplicitEndpoint: true), options)
    {}

    /// <summary>
    /// Creates a new instance of <see cref="AzureOpenAIClient"/>.
    /// </summary>
    /// <param name="pipeline"> The client pipeline to use. </param>
    /// <param name="endpoint"> The endpoint to use. </param>
    /// <param name="options"> The additional client options to use. </param>
    protected AzureOpenAIClient(ClientPipeline pipeline, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, endpoint, null)
    {
        _options = options;
    }

    /// <summary>
    /// Creates a new instance of <see cref="AzureOpenAIClient"/> for mocking.
    /// </summary>
    protected AzureOpenAIClient()
    { }

    /// <summary>
    /// Gets a new <see cref="AssistantClient"/> instance configured for assistant operation use with the Azure OpenAI service.
    /// </summary>
    /// <returns> A new <see cref="AssistantClient"/> instance. </returns>
    [Experimental("OPENAI001")]
    public override AssistantClient GetAssistantClient()
        => new AzureAssistantClient(Pipeline, Endpoint, _options);

    /// <summary>
    /// Gets a new <see cref="AudioClient"/> instance configured for audio operation use with the Azure OpenAI service.
    /// </summary>
    /// <param name="deploymentName"> The model deployment name to use for the new client's audio operations. </param>
    /// <returns> A new <see cref="AudioClient"/> instance. </returns>
    public override AudioClient GetAudioClient(string deploymentName)
        => new AzureAudioClient(Pipeline, deploymentName, Endpoint, _options);

    /// <summary>
    /// Gets a new <see cref="BatchClient"/> instance configured for batch operation use with the Azure OpenAI service.
    /// </summary>
    /// <param name="deploymentName"> The model deployment name to use for the new client's audio operations. </param>
    /// <returns> A new <see cref="BatchClient"/> instance. </returns>
    public BatchClient GetBatchClient(string deploymentName)
        => new AzureBatchClient(Pipeline, deploymentName, Endpoint, _options);

    /// <remarks>
    /// This method is unsupported for Azure OpenAI. Please use the alternate <see cref="GetBatchClient(string)"/>
    /// method that accepts a model deployment name, instead.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override BatchClient GetBatchClient() => GetBatchClient(deploymentName: null);

    /// <summary>
    /// Gets a new <see cref="ChatClient"/> instance configured for chat completion operation use with the Azure OpenAI service.
    /// </summary>
    /// <param name="deploymentName"> The model deployment name to use for the new client's chat completion operations. </param>
    /// <returns> A new <see cref="ChatClient"/> instance. </returns>
    public override ChatClient GetChatClient(string deploymentName)
        => new AzureChatClient(Pipeline, deploymentName, Endpoint, _options);

    /// <summary>
    /// Gets a new <see cref="EmbeddingClient"/> instance configured for embedding operation use with the Azure OpenAI service.
    /// </summary>
    /// <param name="deploymentName"> The model deployment name to use for the new client's embedding operations. </param>
    /// <returns> A new <see cref="EmbeddingClient"/> instance. </returns>
    public override EmbeddingClient GetEmbeddingClient(string deploymentName)
        => new AzureEmbeddingClient(Pipeline, deploymentName, Endpoint, _options);

    /// <summary>
    /// Gets a new <see cref="FileClient"/> instance configured for file operation use with the Azure OpenAI service.
    /// </summary>
    /// <returns> A new <see cref="FileClient"/> instance. </returns>
    public override FileClient GetFileClient()
        => new AzureFileClient(Pipeline, Endpoint, _options);

    /// <summary>
    /// Gets a new <see cref="FineTuningClient"/> instance configured for fine-tuning operation use with the Azure OpenAI service.
    /// </summary>
    /// <returns> A new <see cref="FineTuningClient"/> instance. </returns>
    public override FineTuningClient GetFineTuningClient()
        => new AzureFineTuningClient(Pipeline, Endpoint, _options);

    /// <summary>
    /// Gets a new <see cref="ImageClient"/> instance configured for image operation use with the Azure OpenAI service.
    /// </summary>
    /// <param name="deploymentName"> The model deployment name to use for the new client's image operations. </param>
    /// <returns> A new <see cref="ImageClient"/> instance. </returns>
    public override ImageClient GetImageClient(string deploymentName)
        => new AzureImageClient(Pipeline, deploymentName, Endpoint, _options);

    /// <remarks>
    /// Model management operations are not supported with Azure OpenAI.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ModelClient GetModelClient()
        => throw new NotSupportedException($"Azure OpenAI does not support the OpenAI model management API. Please "
            + "use the Azure AI Services Account Management API to interact with Azure OpenAI model deployments.");

    /// <remarks>
    /// Moderation operations are not supported with Azure OpenAI.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ModerationClient GetModerationClient(string _)
        => throw new NotSupportedException($"Azure OpenAI does not support the OpenAI moderations API. Please refer "
            + "to the documentation on Microsoft's Responsible AI embedded content filters to learn more about Azure "
            + "OpenAI's content filter policies and content filter annotations.");

    /// <summary>
    /// Gets a new <see cref="VectorStoreClient"/> instance configured for vector store operation use with the
    /// Azure OpenAI service.
    /// </summary>
    /// <returns> A new <see cref="VectorStoreClient"/> instance. </returns>
    [Experimental("OPENAI001")]
    public override VectorStoreClient GetVectorStoreClient()
        => new AzureVectorStoreClient(Pipeline, Endpoint, _options);

    private static ClientPipeline CreatePipeline(PipelinePolicy authenticationPolicy, AzureOpenAIClientOptions options)
        => ClientPipeline.Create(
            options ?? new(),
            perCallPolicies:
            [
                CreateAddUserAgentHeaderPolicy(options),
                CreateAddClientRequestIdHeaderPolicy(),
            ],
            perTryPolicies:
            [
                authenticationPolicy,
            ],
            beforeTransportPolicies: []);

    internal static ClientPipeline CreatePipeline(ApiKeyCredential credential, AzureOpenAIClientOptions options = null)
    {
        Argument.AssertNotNull(credential, nameof(credential));
        return CreatePipeline(ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, "api-key"), options);
    }

    internal static ClientPipeline CreatePipeline(TokenCredential credential, AzureOpenAIClientOptions options = null)
    {
        Argument.AssertNotNull(credential, nameof(credential));
        string authorizationScope = options?.Audience?.ToString()
            ?? AzureOpenAIAudience.AzurePublicCloud.ToString();
        return CreatePipeline(new AzureTokenAuthenticationPolicy(credential, [authorizationScope]), options);
    }

    internal static new ApiKeyCredential GetApiKey(ApiKeyCredential explicitCredential = null, bool requireExplicitCredential = false)
    {
        if (explicitCredential is not null)
        {
            return explicitCredential;
        }
        // To do: IConfiguration support
        else if (requireExplicitCredential)
        {
            throw new ArgumentNullException(nameof(explicitCredential), $"A non-null credential value is required.");
        }
        else
        {
            string environmentApiKey = Environment.GetEnvironmentVariable(s_aoaiApiKeyEnvironmentVariable);
            if (string.IsNullOrEmpty(environmentApiKey))
            {
                throw new InvalidOperationException(
                    $"No environment variable value was found for AZURE_OPENAI_API_KEY. "
                    + "Please either populate this environment variable or provide authentication information directly "
                    + "to the client constructor.");
            }
            return new(environmentApiKey);
        }
    }

    internal static Uri GetEndpoint(Uri explicitEndpoint = null, bool requireExplicitEndpoint = false, AzureOpenAIClientOptions options = null)
    {
        if (explicitEndpoint is not null)
        {
            return explicitEndpoint;
        }
        // To do: IConfiguration support
        else if (requireExplicitEndpoint)
        {
            throw new ArgumentNullException(nameof(explicitEndpoint), $"A non-null endpoint value is required.");
        }
        else
        {
            string environmentApiKey = Environment.GetEnvironmentVariable(s_aoaiEndpointEnvironmentVariable);
            if (string.IsNullOrEmpty(environmentApiKey))
            {
                throw new InvalidOperationException(
                    $"No environment variable value was found for AZURE_OPENAI_ENDPOINT. "
                    + "Please either populate this environment variable or provide endpoint information directly "
                    + "to the client constructor.");
            }
            return new(environmentApiKey);
        }
    }

    private static PipelinePolicy CreateAddUserAgentHeaderPolicy(AzureOpenAIClientOptions options = null)
    {
        Core.TelemetryDetails telemetryDetails = new(typeof(AzureOpenAIClient).Assembly, options?.ApplicationId);
        return new GenericActionPipelinePolicy(message =>
        {
            if (message?.Request?.Headers?.TryGetValue(s_userAgentHeaderKey, out string _) == false)
            {
                message.Request.Headers.Set(s_userAgentHeaderKey, telemetryDetails.ToString());
            }
        });
    }

    private static PipelinePolicy CreateAddClientRequestIdHeaderPolicy()
    {
        return new GenericActionPipelinePolicy(message =>
        {
            if (message?.Request?.Headers is not null)
            {
                string requestId = message.Request.Headers.TryGetValue(s_clientRequestIdHeaderKey, out string existingHeader) == true
                    ? existingHeader
                    : Guid.NewGuid().ToString().ToLowerInvariant();
                message.Request.Headers.Set(s_clientRequestIdHeaderKey, requestId);
            }
        });
    }

    private static readonly string s_aoaiEndpointEnvironmentVariable = "AZURE_OPENAI_ENDPOINT";
    private static readonly string s_aoaiApiKeyEnvironmentVariable = "AZURE_OPENAI_API_KEY";
    private static readonly string s_userAgentHeaderKey = "User-Agent";
    private static readonly string s_clientRequestIdHeaderKey = "x-ms-client-request-id";
    private static PipelineMessageClassifier s_pipelineMessageClassifier;
    internal static PipelineMessageClassifier PipelineMessageClassifier
        => s_pipelineMessageClassifier ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 201 });
}
