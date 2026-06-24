// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI.Telemetry;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

#pragma warning disable SCME0001

/// <summary> Provides response operations for an Azure AI project through the OpenAI responses API. </summary>
public partial class ProjectResponsesClient : ResponsesClient
{
    private readonly string _defaultModelName;
    private readonly string _defaultAgentName;
    private readonly string _defaultAgentVersion;
    private readonly string _defaultConversationId;

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/>.
    /// </summary>
    /// <remarks>
    /// This constructor automatically constructs the base URI for requests from the supplied <paramref name="projectEndpoint"/>
    /// value. To use a base URI directly, use the alternative constructor and set <see cref="OpenAIClientOptions.Endpoint"/> on the
    /// supplied options.
    /// </remarks>
    /// <param name="projectEndpoint"> The Azure AI project endpoint. </param>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    /// <param name="options"> The options used to configure the client. </param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProjectResponsesClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, ProjectResponsesClientOptions options = null)
        : this(projectEndpoint, tokenProvider, defaultAgent: null, defaultConversationId: null, options)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/> with default agent settings.
    /// </summary>
    /// <param name="projectEndpoint"> The Azure AI project endpoint. </param>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    /// <param name="defaultAgent"> The default agent used for response requests. </param>
    /// <param name="defaultConversationId"> The default conversation ID used for response requests. </param>
    /// <param name="options"> The options used to configure the client. </param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProjectResponsesClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, AgentReference defaultAgent, string defaultConversationId = null, ProjectResponsesClientOptions options = null)
        : this(
              pipeline: ProjectOpenAIClient.CreatePipeline(
                  ProjectOpenAIClient.CreateAuthenticationPolicy(
                      tokenProvider,
                      ProjectOpenAIClient.GetMergedOptions(projectEndpoint, tokenProvider, options)),
                  ProjectOpenAIClient.GetMergedOptions(projectEndpoint, tokenProvider, options)),
              options: ProjectOpenAIClient.GetMergedOptions(projectEndpoint, tokenProvider, options),
              defaultAgent: defaultAgent,
              defaultConversationId: defaultConversationId)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/>.
    /// </summary>
    /// <remarks>
    /// This constructor directly uses the supplied value from the provided <see cref="OpenAIClientOptions.Endpoint"/>
    /// and performs no additional automatic resolution.
    /// </remarks>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    /// <param name="options"> The options used to configure the client. </param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProjectResponsesClient(AuthenticationTokenProvider tokenProvider, ProjectResponsesClientOptions options)
        : this(projectEndpoint: null, tokenProvider, defaultAgent: null, defaultConversationId: null, options)
    { }

    /// <summary> Initializes a new instance of <see cref="ProjectResponsesClient"/>. </summary>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    /// <param name="options"> The options used to configure the client. </param>
    /// <param name="defaultAgent"> The default agent used for response requests. </param>
    /// <param name="defaultConversationId"> The default conversation ID used for response requests. </param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProjectResponsesClient(AuthenticationTokenProvider tokenProvider, ProjectResponsesClientOptions options = null, AgentReference defaultAgent = null, string defaultConversationId = null)
        : this(projectEndpoint: null, tokenProvider, defaultAgent, defaultConversationId, options)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/>.
    /// </summary>
    /// <remarks>
    /// This constructor automatically constructs the base URI for requests from the supplied <paramref name="projectEndpoint"/>
    /// value. To use a base URI directly, use the alternative constructor and set
    /// <see cref="ResponsesClientOptions.Endpoint"/> on the supplied options.
    /// </remarks>
    /// <param name="projectEndpoint"> The Azure AI project endpoint. </param>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    /// <param name="options"> The options used to configure the client. </param>
    public ProjectResponsesClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, ProjectOAIResponsesClientOptions options)
        : this(projectEndpoint, tokenProvider, defaultAgent: null, defaultConversationId: null, options)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/> with default agent settings.
    /// </summary>
    /// <param name="projectEndpoint"> The Azure AI project endpoint. </param>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    /// <param name="defaultAgent"> The default agent used for response requests. </param>
    /// <param name="defaultConversationId"> The default conversation ID used for response requests. </param>
    /// <param name="options"> The options used to configure the client. </param>
    public ProjectResponsesClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, AgentReference defaultAgent, string defaultConversationId, ProjectOAIResponsesClientOptions options)
        : this(
              pipeline: CreatePipeline(
                  CreateAuthenticationPolicy(
                      tokenProvider,
                      GetMergedOptions(projectEndpoint, tokenProvider, options)),
                  GetMergedOptions(projectEndpoint, tokenProvider, options)),
              options: GetMergedOptions(projectEndpoint, tokenProvider, options),
              defaultAgent: defaultAgent,
              defaultConversationId: defaultConversationId)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/>.
    /// </summary>
    /// <remarks>
    /// This constructor directly uses the supplied value from the provided
    /// <see cref="ResponsesClientOptions.Endpoint"/> and performs no additional automatic resolution.
    /// </remarks>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    /// <param name="options"> The options used to configure the client. </param>
    public ProjectResponsesClient(AuthenticationTokenProvider tokenProvider, ProjectOAIResponsesClientOptions options)
        : this(projectEndpoint: null, tokenProvider, defaultAgent: null, defaultConversationId: null, options)
    { }

    /// <summary> Initializes a new instance of <see cref="ProjectResponsesClient"/>. </summary>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    /// <param name="options"> The options used to configure the client. </param>
    /// <param name="defaultAgent"> The default agent used for response requests. </param>
    /// <param name="defaultConversationId"> The default conversation ID used for response requests. </param>
    public ProjectResponsesClient(AuthenticationTokenProvider tokenProvider, ProjectOAIResponsesClientOptions options, AgentReference defaultAgent = null, string defaultConversationId = null)
        : this(projectEndpoint: null, tokenProvider, defaultAgent, defaultConversationId, options)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/> with default options.
    /// </summary>
    /// <remarks>
    /// This constructor automatically constructs the base URI for requests from the supplied
    /// <paramref name="projectEndpoint"/> value.
    /// </remarks>
    /// <param name="projectEndpoint"> The Azure AI project endpoint. </param>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    public ProjectResponsesClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider)
        : this(projectEndpoint, tokenProvider, (ProjectOAIResponsesClientOptions)null)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/> with default agent settings
    /// and default options.
    /// </summary>
    /// <param name="projectEndpoint"> The Azure AI project endpoint. </param>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    /// <param name="defaultAgent"> The default agent used for response requests. </param>
    /// <param name="defaultConversationId"> The default conversation ID used for response requests. </param>
    public ProjectResponsesClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, AgentReference defaultAgent, string defaultConversationId = null)
        : this(projectEndpoint, tokenProvider, defaultAgent, defaultConversationId, (ProjectOAIResponsesClientOptions)null)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/> with default options.
    /// </summary>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    public ProjectResponsesClient(AuthenticationTokenProvider tokenProvider)
        : this(tokenProvider, (ProjectOAIResponsesClientOptions)null)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ProjectResponsesClient"/> with default options.
    /// </summary>
    /// <param name="tokenProvider"> The token provider used to authenticate requests. </param>
    /// <param name="defaultAgent"> The default agent used for response requests. </param>
    /// <param name="defaultConversationId"> The default conversation ID used for response requests. </param>
    public ProjectResponsesClient(AuthenticationTokenProvider tokenProvider, AgentReference defaultAgent, string defaultConversationId = null)
        : this(tokenProvider, (ProjectOAIResponsesClientOptions)null, defaultAgent, defaultConversationId)
    { }

    internal ProjectResponsesClient(ClientPipeline pipeline, ProjectOAIResponsesClientOptions options, AgentReference defaultAgent, string defaultConversationId)
        : base(pipeline, options)
    {
        if (defaultAgent?.Name?.ToLowerInvariant()?.StartsWith("model:") == true)
        {
            _defaultModelName = defaultAgent.Name.Substring("model:".Length);
        }
        else if (defaultAgent is not null)
        {
            _defaultAgentName = defaultAgent.Name;
            _defaultAgentVersion = defaultAgent.Version;
        }
        _defaultConversationId = defaultConversationId;
    }

    /// <summary> Initializes a new instance of <see cref="ProjectResponsesClient"/> for mocking. </summary>
    protected ProjectResponsesClient()
    { }

    /// <summary> Creates a response using the supplied response options. </summary>
    /// <param name="options"> The options used to create the response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    public override ClientResult<ResponseResult> CreateResponse(CreateResponseOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(options, nameof(options));
        ApplyClientDefaults(options);
        using var scope = OpenTelemetryResponseScope.Start(options, Endpoint, _defaultModelName);
        try
        {
            var result = base.CreateResponse(options, cancellationToken);
            scope?.RecordResponse(result.Value);
            return result;
        }
        catch (Exception ex)
        {
            scope?.RecordError(ex);
            throw;
        }
    }

    /// <summary> Creates a response from the supplied input items. </summary>
    /// <param name="inputItems"> The input items used to create the response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    public virtual ClientResult<ResponseResult> CreateResponse(IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        return CreateResponse(null, inputItems, previousResponseId, cancellationToken);
    }

    /// <summary> Creates a response for the specified model from the supplied input items. </summary>
    /// <param name="model"> The model used to create the response. </param>
    /// <param name="inputItems"> The input items used to create the response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    public override ClientResult<ResponseResult> CreateResponse(string model, IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(inputItems, nameof(inputItems));
        CreateResponseOptions options = new()
        {
            PreviousResponseId = previousResponseId,
            Model = model,
        };
        foreach (ResponseItem inputItem in inputItems)
        {
            options.InputItems.Add(inputItem);
        }
        ApplyClientDefaults(options);
        return base.CreateResponse(options, cancellationToken);
    }

    /// <summary> Creates a response from user input text. </summary>
    /// <param name="userInputText"> The user input text used to create the response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    public virtual ClientResult<ResponseResult> CreateResponse(string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        return CreateResponse(null, userInputText, previousResponseId, cancellationToken);
    }

    /// <summary> Creates a response for the specified model from user input text. </summary>
    /// <param name="model"> The model used to create the response. </param>
    /// <param name="userInputText"> The user input text used to create the response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    public override ClientResult<ResponseResult> CreateResponse(string model, string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));
        CreateResponseOptions options = new()
        {
            PreviousResponseId = previousResponseId,
            InputItems = { ResponseItem.CreateUserMessageItem(userInputText) },
            Model = model,
        };
        ApplyClientDefaults(options);
        using var scope = OpenTelemetryResponseScope.Start(options, Endpoint, _defaultModelName);
        try
        {
            var result = base.CreateResponse(options, cancellationToken);
            scope?.RecordResponse(result.Value);
            return result;
        }
        catch (Exception ex)
        {
            scope?.RecordError(ex);
            throw;
        }
    }

    /// <summary> Asynchronously creates a response using the supplied response options. </summary>
    /// <param name="options"> The options used to create the response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    public override async Task<ClientResult<ResponseResult>> CreateResponseAsync(CreateResponseOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(options, nameof(options));
        ApplyClientDefaults(options);
        using var scope = OpenTelemetryResponseScope.Start(options, Endpoint, _defaultModelName);
        try
        {
            var result = await base.CreateResponseAsync(options, cancellationToken).ConfigureAwait(false);
            scope?.RecordResponse(result.Value);
            return result;
        }
        catch (Exception ex)
        {
            scope?.RecordError(ex);
            throw;
        }
    }

    /// <summary> Asynchronously creates a response from the supplied input items. </summary>
    /// <param name="inputItems"> The input items used to create the response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    public virtual async Task<ClientResult<ResponseResult>> CreateResponseAsync(IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        return await CreateResponseAsync(null, inputItems, previousResponseId, cancellationToken).ConfigureAwait(false);
    }

    /// <summary> Asynchronously creates a response for the specified model from the supplied input items. </summary>
    /// <param name="model"> The model used to create the response. </param>
    /// <param name="inputItems"> The input items used to create the response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    public override async Task<ClientResult<ResponseResult>> CreateResponseAsync(string model, IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(inputItems, nameof(inputItems));
        CreateResponseOptions options = new()
        {
            PreviousResponseId = previousResponseId,
            Model = model
        };
        foreach (ResponseItem inputItem in inputItems)
        {
            options.InputItems.Add(inputItem);
        }
        ApplyClientDefaults(options);

        using var scope = OpenTelemetryResponseScope.Start(options, Endpoint, _defaultModelName);
        try
        {
            var result = await base.CreateResponseAsync(options, cancellationToken).ConfigureAwait(false);
            scope?.RecordResponse(result.Value);
            return result;
        }
        catch (Exception ex)
        {
            scope?.RecordError(ex);
            throw;
        }
    }

    /// <summary> Asynchronously creates a response from user input text. </summary>
    /// <param name="userInputText"> The user input text used to create the response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    public async virtual Task<ClientResult<ResponseResult>> CreateResponseAsync(string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        return await CreateResponseAsync(null, userInputText, previousResponseId, cancellationToken).ConfigureAwait(false);
    }
    /// <summary> Asynchronously creates a response for the specified model from user input text. </summary>
    /// <param name="model"> The model used to create the response. </param>
    /// <param name="userInputText"> The user input text used to create the response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    public async override Task<ClientResult<ResponseResult>> CreateResponseAsync(string model, string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));
        CreateResponseOptions options = new()
        {
            PreviousResponseId = previousResponseId,
            InputItems = { ResponseItem.CreateUserMessageItem(userInputText) },
            Model = model,
        };
        ApplyClientDefaults(options);
        using var scope = OpenTelemetryResponseScope.Start(options, Endpoint, _defaultModelName);
        try
        {
            var result = await base.CreateResponseAsync(options, cancellationToken).ConfigureAwait(false);
            scope?.RecordResponse(result.Value);
            return result;
        }
        catch (Exception ex)
        {
            scope?.RecordError(ex);
            throw;
        }
    }

    /// <summary> Creates a streaming response using the supplied response options. </summary>
    /// <param name="options"> The options used to create the streaming response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The streaming response updates. </returns>
    public override CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(CreateResponseOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(options, nameof(options));
        options.StreamingEnabled = true;
        ApplyClientDefaults(options);
        if (!OpenTelemetryResponseScope.IsEnabled)
        {
            return base.CreateResponseStreaming(options, cancellationToken);
        }

        var telemetryContext = StreamingTelemetryContext.Create(options, Endpoint, _defaultModelName);

        try
        {
            var innerResult = base.CreateResponseStreaming(options, cancellationToken);
            return new TelemetryStreamingCollectionResult(innerResult, telemetryContext);
        }
        catch (Exception ex)
        {
            var scope = telemetryContext.CreateScope();
            scope?.RecordError(ex);
            scope?.Dispose();
            throw;
        }
    }

    /// <summary> Creates a streaming response from the supplied input items. </summary>
    /// <param name="inputItems"> The input items used to create the streaming response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The streaming response updates. </returns>
    public virtual CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        return CreateResponseStreaming(null, inputItems, previousResponseId, cancellationToken);
    }

    /// <summary> Creates a streaming response for the specified model from the supplied input items. </summary>
    /// <param name="model"> The model used to create the streaming response. </param>
    /// <param name="inputItems"> The input items used to create the streaming response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The streaming response updates. </returns>
    public override CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(string model, IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(inputItems, nameof(inputItems));
        CreateResponseOptions options = new()
        {
            StreamingEnabled = true,
            PreviousResponseId = previousResponseId,
            Model = model,
        };
        foreach (ResponseItem inputItem in inputItems)
        {
            options.InputItems.Add(inputItem);
        }
        ApplyClientDefaults(options);
        return CreateResponseStreaming(options, cancellationToken);
    }

    /// <summary> Creates a streaming response from user input text. </summary>
    /// <param name="userInputText"> The user input text used to create the streaming response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The streaming response updates. </returns>
    public virtual CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        return CreateResponseStreaming(null, userInputText, previousResponseId, cancellationToken);
    }

    /// <summary> Creates a streaming response for the specified model from user input text. </summary>
    /// <param name="model"> The model used to create the streaming response. </param>
    /// <param name="userInputText"> The user input text used to create the streaming response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The streaming response updates. </returns>
    public override CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(string model, string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));
        CreateResponseOptions options = new()
        {
            StreamingEnabled = true,
            PreviousResponseId = previousResponseId,
            InputItems = { ResponseItem.CreateUserMessageItem(userInputText) },
            Model = model,
        };
        ApplyClientDefaults(options);
        return CreateResponseStreaming(options, cancellationToken);
    }

    /// <summary> Asynchronously creates a streaming response using the supplied response options. </summary>
    /// <param name="options"> The options used to create the streaming response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The streaming response updates. </returns>
    public override AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(CreateResponseOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(options, nameof(options));
        options.StreamingEnabled = true;
        ApplyClientDefaults(options);
        if (!OpenTelemetryResponseScope.IsEnabled)
        {
            return base.CreateResponseStreamingAsync(options, cancellationToken);
        }

        var telemetryContext = StreamingTelemetryContext.Create(options, Endpoint, _defaultModelName);

        try
        {
            var innerResult = base.CreateResponseStreamingAsync(options, cancellationToken);
            return new TelemetryAsyncStreamingCollectionResult(innerResult, telemetryContext);
        }
        catch (Exception ex)
        {
            var scope = telemetryContext.CreateScope();
            scope?.RecordError(ex);
            scope?.Dispose();
            throw;
        }
    }

    /// <summary> Asynchronously creates a streaming response from the supplied input items. </summary>
    /// <param name="inputItems"> The input items used to create the streaming response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The streaming response updates. </returns>
    public virtual AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        return CreateResponseStreamingAsync(null, inputItems, previousResponseId, cancellationToken);
    }

    /// <summary> Asynchronously creates a streaming response for the specified model from the supplied input items. </summary>
    /// <param name="model"> The model used to create the streaming response. </param>
    /// <param name="inputItems"> The input items used to create the streaming response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The streaming response updates. </returns>
    public override AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(string model, IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(inputItems, nameof(inputItems));
        CreateResponseOptions options = new()
        {
            StreamingEnabled = true,
            PreviousResponseId = previousResponseId,
            Model = model,
        };
        foreach (ResponseItem inputItem in inputItems)
        {
            options.InputItems.Add(inputItem);
        }
        ApplyClientDefaults(options);
        return CreateResponseStreamingAsync(options, cancellationToken);
    }

    /// <summary> Asynchronously creates a streaming response from user input text. </summary>
    /// <param name="userInputText"> The user input text used to create the streaming response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The streaming response updates. </returns>
    public virtual AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        return CreateResponseStreamingAsync(null, userInputText, previousResponseId, cancellationToken);
    }
    /// <summary> Asynchronously creates a streaming response for the specified model from user input text. </summary>
    /// <param name="model"> The model used to create the streaming response. </param>
    /// <param name="userInputText"> The user input text used to create the streaming response. </param>
    /// <param name="previousResponseId"> The ID of the previous response to continue. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The streaming response updates. </returns>
    public override AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(string model, string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));
        CreateResponseOptions options = new()
        {
            StreamingEnabled = true,
            PreviousResponseId = previousResponseId,
            InputItems = { ResponseItem.CreateUserMessageItem(userInputText) },
            Model = model,
        };
        ApplyClientDefaults(options);
        return CreateResponseStreamingAsync(options, cancellationToken);
    }

    /// <summary> Gets project responses, optionally filtered by agent or conversation. </summary>
    /// <param name="agent"> The agent used to filter the returned responses. </param>
    /// <param name="conversationId"> The conversation ID used to filter the returned responses. </param>
    /// <param name="limit"> The maximum number of responses to return. </param>
    /// <param name="order"> The order used to sort returned responses. </param>
    /// <param name="after"> The response ID after which results should be returned. </param>
    /// <param name="before"> The response ID before which results should be returned. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The project responses. </returns>
    public virtual CollectionResult<ResponseResult> GetProjectResponses(AgentReference agent = null, string conversationId = null, int? limit = default, string order = null, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> extraQueryForProtocol = new()
        {
            ["agent_name"] = string.IsNullOrEmpty(agent?.Version) ? agent?.Name : null,
            ["agent_id"] = string.IsNullOrEmpty(agent?.Version) ? null : $"{agent?.Name}:{agent?.Version}",
            ["conversation_id"] = conversationId,
        };

        return new InternalOpenAICollectionResultOfT<ResponseResult>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetProjectResponsesRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    agentName: localCollectionOptions.ExtraQueryMap["agent_name"],
                    agentId: localCollectionOptions.ExtraQueryMap["agent_id"],
                    conversationId: localCollectionOptions.ExtraQueryMap["conversation_id"],
                    localRequestOptions),
            dataItemDeserializer: DeserializeResponseResult,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, extraQueryMap: extraQueryForProtocol),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Asynchronously gets project responses, optionally filtered by agent or conversation. </summary>
    /// <param name="agent"> The agent used to filter the returned responses. </param>
    /// <param name="conversationId"> The conversation ID used to filter the returned responses. </param>
    /// <param name="limit"> The maximum number of responses to return. </param>
    /// <param name="order"> The order used to sort returned responses. </param>
    /// <param name="after"> The response ID after which results should be returned. </param>
    /// <param name="before"> The response ID before which results should be returned. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The project responses. </returns>
    public virtual AsyncCollectionResult<ResponseResult> GetProjectResponsesAsync(AgentReference agent = null, string conversationId = null, int? limit = default, string order = null, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> extraQueryForProtocol = new()
        {
            ["agent_name"] = string.IsNullOrEmpty(agent?.Version) ? agent?.Name : null,
            ["agent_id"] = string.IsNullOrEmpty(agent?.Version) ? null : $"{agent?.Name}:{agent?.Version}",
            ["conversation_id"] = conversationId,
        };

        return new InternalOpenAIAsyncCollectionResultOfT<ResponseResult>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetProjectResponsesRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    agentName: localCollectionOptions.ExtraQueryMap["agent_name"],
                    agentId: localCollectionOptions.ExtraQueryMap["agent_id"],
                    conversationId: localCollectionOptions.ExtraQueryMap["conversation_id"],
                    localRequestOptions),
            dataItemDeserializer: DeserializeResponseResult,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, extraQueryMap: extraQueryForProtocol),
            cancellationToken.ToRequestOptions());
    }

    private void ApplyClientDefaults(CreateResponseOptions options)
    {
        if (options.Agent is null && !string.IsNullOrEmpty(_defaultAgentName))
        {
            options.Agent = new AgentReference(_defaultAgentName, _defaultAgentVersion);
        }
        options.AgentConversationId ??= _defaultConversationId;
        if (options.Model is null)
        {
            if (!string.IsNullOrEmpty(_defaultModelName))
            {
                options.Patch.Set("$.model"u8, _defaultModelName);
            }
            else
            {
                options.Patch.Remove("$.model"u8);
            }
        }
    }

    private static ResponseResult DeserializeResponseResult(JsonElement element, ModelReaderWriterOptions options)
    {
        return ModelReaderWriter.Read<ResponseResult>(
            BinaryData.FromString(element.GetRawText()),
            options,
            OpenAIContext.Default);
    }

    internal static ClientPipeline CreatePipeline(AuthenticationPolicy authenticationPolicy, ProjectOAIResponsesClientOptions options)
    {
        options ??= new ProjectOAIResponsesClientOptions();

        TelemetryDetails telemetryDetails = new(typeof(OpenAIClient).Assembly, default);
        string prefix = "AIProjectClient";
        if (!string.IsNullOrEmpty(options.UserAgentApplicationId))
        {
            prefix = $"{options.UserAgentApplicationId}-AIProjectClient";
        }
        if (!string.IsNullOrEmpty(options.AgentName))
        {
            PipelinePolicyHelpers.AddQueryParameterPolicy(options, "api-version", options.ApiVersion);
        }
        PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "User-Agent", $"{prefix} {telemetryDetails.UserAgent}");
        PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "x-ms-client-request-id", () => Guid.NewGuid().ToString().ToLowerInvariant());
        PipelinePolicyHelpers.OpenAI.AddResponseItemInputTransformPolicy(options);
        PipelinePolicyHelpers.OpenAI.AddErrorTransformPolicy(options);
        PipelinePolicyHelpers.OpenAI.AddAzureFinetuningParityPolicy(options);

        return ClientPipeline.Create(options: options, perCallPolicies: [], perTryPolicies: [authenticationPolicy], beforeTransportPolicies: []);
    }

    internal static AuthenticationPolicy CreateAuthenticationPolicy(AuthenticationTokenProvider tokenProvider, ProjectOAIResponsesClientOptions options = null)
        => ProjectOpenAIClient.CreateAuthenticationPolicy(tokenProvider);

    internal static ProjectOAIResponsesClientOptions GetMergedOptions(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, ProjectOAIResponsesClientOptions options = null)
    {
        if (projectEndpoint is null)
        {
            return options;
        }
        string path = string.IsNullOrEmpty(options?.AgentName) ? "/openai/v1" : $"/agents/{options.AgentName}/endpoint/protocols/openai";
        string rawTargetOpenAIEndpoint = projectEndpoint.AbsoluteUri.TrimEnd('/') + path;
        if (options?.Endpoint is not null && options?.Endpoint?.AbsoluteUri != rawTargetOpenAIEndpoint)
        {
            throw new InvalidOperationException(
                $"Cannot supply both a constructor '{nameof(projectEndpoint)}' and {nameof(options)}.{nameof(options.Endpoint)}.");
        }
        options ??= new();
        options.Endpoint ??= new Uri(rawTargetOpenAIEndpoint);
        options.TokenProvider = tokenProvider;
        return options;
    }
}
