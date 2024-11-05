﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

global using OpenAI;
global using OpenAI.Assistants;
global using OpenAI.Audio;
global using OpenAI.Batch;
global using OpenAI.Chat;
global using OpenAI.Embeddings;
global using OpenAI.Files;
global using OpenAI.FineTuning;
global using OpenAI.Images;
global using OpenAI.Models;
global using OpenAI.Moderations;
global using OpenAI.RealtimeConversation;
global using OpenAI.VectorStores;

using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Audio;
using Azure.AI.OpenAI.Chat;
using Azure.AI.OpenAI.Embeddings;
using Azure.AI.OpenAI.Images;
using Azure.Core;

#if !AZURE_OPENAI_GA
using Azure.AI.OpenAI.Assistants;
using Azure.AI.OpenAI.Batch;
using Azure.AI.OpenAI.Files;
using Azure.AI.OpenAI.FineTuning;
using Azure.AI.OpenAI.RealtimeConversation;
using Azure.AI.OpenAI.VectorStores;
#endif

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
    private readonly Uri _endpoint;
    private readonly AzureOpenAIClientOptions _options;
    private readonly ApiKeyCredential _keyCredential;
    private readonly TokenCredential _tokenCredential;

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
    /// <param name="endpoint"> The Azure OpenAI resource endpoint to use. This should not include model deployment or operation information. For example: <c>https://my-resource.openai.azure.com</c>. </param>
    /// <param name="credential"> The API key to authenticate with the service. </param>
    public AzureOpenAIClient(Uri endpoint, ApiKeyCredential credential) : this(endpoint, credential, new AzureOpenAIClientOptions())
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="AzureOpenAIClient"/> that will connect to an Azure OpenAI service resource
    /// using token authentication, including for tokens issued via managed identity.
    /// </summary>
    /// <remarks>
    /// For API-key-based authentication, please use the alternate constructor:
    /// <see cref="AzureOpenAIClient(Uri,ApiKeyCredential,AzureOpenAIClientOptions)"/>
    /// </remarks>
    /// <param name="endpoint"> The Azure OpenAI resource endpoint to use. This should not include model deployment or operation information. For example: <c>https://my-resource.openai.azure.com</c>. </param>
    /// <param name="credential"> The token credential to authenticate with the service. </param>
    public AzureOpenAIClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new AzureOpenAIClientOptions())
    {
    }

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
    /// <param name="endpoint"> The Azure OpenAI resource endpoint to use. This should not include model deployment or operation information. For example: <c>https://my-resource.openai.azure.com</c>. </param>
    /// <param name="credential"> The API key to authenticate with the service. </param>
    /// <param name="options"> The options to configure the client. </param>
    public AzureOpenAIClient(Uri endpoint, ApiKeyCredential credential, AzureOpenAIClientOptions options)
        : this(CreatePipeline(credential, options), endpoint, options)
    {
        _keyCredential = credential;
    }

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
    /// <param name="credential"> The API key to use when authenticating with the provided endpoint. </param>
    /// <param name="options"> The scenario-independent options to use. </param>
    public AzureOpenAIClient(Uri endpoint, TokenCredential credential, AzureOpenAIClientOptions options)
        : this(CreatePipeline(credential, options), endpoint, options)
    {
        _tokenCredential = credential;
    }

    /// <summary>
    /// Creates a new instance of <see cref="AzureOpenAIClient"/>.
    /// </summary>
    /// <param name="pipeline"> The client pipeline to use. </param>
    /// <param name="endpoint"> The endpoint to use. </param>
    /// <param name="options"> The additional client options to use. </param>
    protected AzureOpenAIClient(ClientPipeline pipeline, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        options ??= new();

        _endpoint = endpoint;
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
#if AZURE_OPENAI_GA
    [EditorBrowsable(EditorBrowsableState.Never)]
#endif
    [Experimental("OPENAI001")]
    public override AssistantClient GetAssistantClient()
#if !AZURE_OPENAI_GA
        => new AzureAssistantClient(Pipeline, _endpoint, _options);
#else
        => throw new InvalidOperationException($"The preview Assistants feature area is not available in this GA release of the Azure OpenAI Service. To use this capability, please use a preview version of the library.");
#endif

    /// <summary>
    /// Gets a new <see cref="AudioClient"/> instance configured for audio operation use with the Azure OpenAI service.
    /// </summary>
    /// <param name="deploymentName"> The model deployment name to use for the new client's audio operations. </param>
    /// <returns> A new <see cref="AudioClient"/> instance. </returns>
    public override AudioClient GetAudioClient(string deploymentName)
        => new AzureAudioClient(Pipeline, deploymentName, _endpoint, _options);

    /// <summary>
    /// Gets a new <see cref="BatchClient"/> instance configured for batch operation use with the Azure OpenAI service.
    /// </summary>
    /// <param name="deploymentName"> The model deployment name to use for the new client's audio operations. </param>
    /// <returns> A new <see cref="BatchClient"/> instance. </returns>
#if AZURE_OPENAI_GA
    [EditorBrowsable(EditorBrowsableState.Never)]
#endif
    [Experimental("OPENAI001")]
    public BatchClient GetBatchClient(string deploymentName)
#if !AZURE_OPENAI_GA
        => new AzureBatchClient(Pipeline, deploymentName, _endpoint, _options);
#else
        => throw new InvalidOperationException($"The preview Batch feature area is not available in this GA release of the Azure OpenAI Service. To use this capability, please use a preview version of the library.");
#endif

    /// <remarks>
    /// This method is unsupported for Azure OpenAI. Please use the alternate <see cref="GetBatchClient(string)"/>
    /// method that accepts a model deployment name, instead.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Experimental("OPENAI001")]
    public override BatchClient GetBatchClient() => GetBatchClient(deploymentName: null);

    /// <summary>
    /// Gets a new <see cref="ChatClient"/> instance configured for chat completion operation use with the Azure OpenAI service.
    /// </summary>
    /// <param name="deploymentName"> The model deployment name to use for the new client's chat completion operations. </param>
    /// <returns> A new <see cref="ChatClient"/> instance. </returns>
    public override ChatClient GetChatClient(string deploymentName)
        => new AzureChatClient(Pipeline, deploymentName, _endpoint, _options);

    /// <summary>
    /// Gets a new <see cref="EmbeddingClient"/> instance configured for embedding operation use with the Azure OpenAI service.
    /// </summary>
    /// <param name="deploymentName"> The model deployment name to use for the new client's embedding operations. </param>
    /// <returns> A new <see cref="EmbeddingClient"/> instance. </returns>
    public override EmbeddingClient GetEmbeddingClient(string deploymentName)
        => new AzureEmbeddingClient(Pipeline, deploymentName, _endpoint, _options);

    /// <summary>
    /// Gets a new <see cref="OpenAIFileClient"/> instance configured for file operation use with the Azure OpenAI service.
    /// </summary>
    /// <returns> A new <see cref="OpenAIFileClient"/> instance. </returns>
#if AZURE_OPENAI_GA
    [EditorBrowsable(EditorBrowsableState.Never)]
#endif
    public override OpenAIFileClient GetOpenAIFileClient()
#if !AZURE_OPENAI_GA
        => new AzureFileClient(Pipeline, _endpoint, _options);
#else
        => throw new InvalidOperationException($"FileClient is not supported in this GA version of the library. To use Files and related capabilities, please use a preview version of the library.");
#endif

    /// <summary>
    /// Gets a new <see cref="FineTuningClient"/> instance configured for fine-tuning operation use with the Azure OpenAI service.
    /// </summary>
    /// <returns> A new <see cref="FineTuningClient"/> instance. </returns>
#if AZURE_OPENAI_GA
    [EditorBrowsable(EditorBrowsableState.Never)]
#endif
    [Experimental("OPENAI001")]
    public override FineTuningClient GetFineTuningClient()
#if !AZURE_OPENAI_GA
        => new AzureFineTuningClient(Pipeline, _endpoint, _options);
#else
        => throw new InvalidOperationException($"Fine-tuning is not yet supported in the GA version of the library. Please use a preview version.");
#endif

    /// <summary>
    /// Gets a new <see cref="ImageClient"/> instance configured for image operation use with the Azure OpenAI service.
    /// </summary>
    /// <param name="deploymentName"> The model deployment name to use for the new client's image operations. </param>
    /// <returns> A new <see cref="ImageClient"/> instance. </returns>
    public override ImageClient GetImageClient(string deploymentName)
        => new AzureImageClient(Pipeline, deploymentName, _endpoint, _options);

    /// <remarks>
    /// Model management operations are not supported with Azure OpenAI.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override OpenAIModelClient GetOpenAIModelClient()
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
#if AZURE_OPENAI_GA
    [EditorBrowsable(EditorBrowsableState.Never)]
#endif
    [Experimental("OPENAI001")]
    public override VectorStoreClient GetVectorStoreClient()
#if !AZURE_OPENAI_GA
    => new AzureVectorStoreClient(Pipeline, _endpoint, _options);
#else
        => throw new InvalidOperationException($"VectorStoreClient is not supported with this GA version of the library. Please use a preview version of the library for this functionality.");
#endif

#if AZURE_OPENAI_GA
    [EditorBrowsable(EditorBrowsableState.Never)]
#endif
    [Experimental("OPENAI002")]
    public override RealtimeConversationClient GetRealtimeConversationClient(string deploymentName)
    {
#if !AZURE_OPENAI_GA
        if (_tokenCredential is not null)
        {
            return new AzureRealtimeConversationClient(_endpoint, deploymentName, _tokenCredential, _options);
        }
        else
        {
            return new AzureRealtimeConversationClient(_endpoint, deploymentName, _keyCredential, _options);
        }
#else
        throw new InvalidOperationException($"{nameof(RealtimeConversationClient)} is not supported with this GA version of the library. Please use a preview version of the library for this functionality.");
#endif
    }

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

    private static PipelinePolicy CreateAddUserAgentHeaderPolicy(AzureOpenAIClientOptions options = null)
    {
        Core.TelemetryDetails telemetryDetails = new(typeof(AzureOpenAIClient).Assembly, options?.UserAgentApplicationId);
        return new GenericActionPipelinePolicy(
            requestAction: request =>
            {
                if (request?.Headers?.TryGetValue(s_userAgentHeaderKey, out string _) == false)
                {
                    request.Headers.Set(s_userAgentHeaderKey, telemetryDetails.ToString());
                }
            });
    }

    private static PipelinePolicy CreateAddClientRequestIdHeaderPolicy()
    {
        return new GenericActionPipelinePolicy(request =>
        {
            if (request?.Headers is not null)
            {
                string requestId = request.Headers.TryGetValue(s_clientRequestIdHeaderKey, out string existingHeader) == true
                    ? existingHeader
                    : Guid.NewGuid().ToString().ToLowerInvariant();
                request.Headers.Set(s_clientRequestIdHeaderKey, requestId);
            }
        });
    }

    private static readonly string s_userAgentHeaderKey = "User-Agent";
    private static readonly string s_clientRequestIdHeaderKey = "x-ms-client-request-id";
    private static PipelineMessageClassifier s_pipelineMessageClassifier;
    internal static PipelineMessageClassifier PipelineMessageClassifier
        => s_pipelineMessageClassifier ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 201 });
}
