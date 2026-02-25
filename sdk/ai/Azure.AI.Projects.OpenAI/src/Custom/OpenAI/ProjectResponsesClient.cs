// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

#pragma warning disable SCME0001

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
    /// This constructor will automatically construct the base URI for requests from the supplied <paramref name="projectEndpoint"/>
    /// value. To use a base URI directly, use the alternative constructor and set <see cref="OpenAIClientOptions.Endpoint"/> on the
    /// options supplied.
    /// </remarks>
    /// <param name="projectEndpoint"></param>
    /// <param name="tokenProvider"></param>
    /// <param name="options"></param>
    public ProjectResponsesClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, ProjectResponsesClientOptions options = null)
        : this(projectEndpoint, tokenProvider, defaultAgent: null, defaultConversationId: null, options)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="projectEndpoint"></param>
    /// <param name="tokenProvider"></param>
    /// <param name="defaultAgent"></param>
    /// <param name="defaultConversationId"></param>
    /// <param name="options"></param>
    public ProjectResponsesClient(Uri projectEndpoint, AuthenticationTokenProvider tokenProvider, AgentReference defaultAgent, string defaultConversationId = null, ProjectResponsesClientOptions options = null)
        : this(
              pipeline: ProjectOpenAIClient.CreatePipeline(
                  ProjectOpenAIClient.CreateAuthenticationPolicy(
                      tokenProvider,
                      ProjectOpenAIClient.GetMergedOptions(projectEndpoint, options)),
                  ProjectOpenAIClient.GetMergedOptions(projectEndpoint, options)),
              options: ProjectOpenAIClient.GetMergedOptions(projectEndpoint, options),
              defaultAgent: defaultAgent,
              defaultConversationId: defaultConversationId)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ProjectResponsesClient"/>.
    /// </summary>
    /// <remarks>
    /// This constructor will directly use the supplied value from the provided <see cref="OpenAIClientOptions.Endpoint"/>
    /// and will perform no additional automatic resolution.
    /// </remarks>
    /// <param name="tokenProvider"></param>
    /// <param name="options"></param>
    public ProjectResponsesClient(AuthenticationTokenProvider tokenProvider, ProjectResponsesClientOptions options)
        : this(projectEndpoint: null, tokenProvider, defaultAgent: null, defaultConversationId: null, options)
    { }

    public ProjectResponsesClient(AuthenticationTokenProvider tokenProvider, ProjectResponsesClientOptions options = null, AgentReference defaultAgent = null, string defaultConversationId = null)
        : this(projectEndpoint: null, tokenProvider, defaultAgent, defaultConversationId, options)
    { }

    internal ProjectResponsesClient(ClientPipeline pipeline, OpenAIClientOptions options, AgentReference defaultAgent, string defaultConversationId)
        : base(pipeline, "placeholder", options)
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

    protected ProjectResponsesClient()
    { }

    public override ClientResult<ResponseResult> CreateResponse(CreateResponseOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(options, nameof(options));
        ApplyClientDefaults(options);
        return base.CreateResponse(options, cancellationToken);
    }

    public override ClientResult<ResponseResult> CreateResponse(IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(inputItems, nameof(inputItems));
        CreateResponseOptions options = new()
        {
            PreviousResponseId = previousResponseId,
        };
        foreach (ResponseItem inputItem in inputItems)
        {
            options.InputItems.Add(inputItem);
        }
        ApplyClientDefaults(options);
        return base.CreateResponse(inputItems, previousResponseId, cancellationToken);
    }

    public override ClientResult<ResponseResult> CreateResponse(string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));
        CreateResponseOptions options = new()
        {
            PreviousResponseId = previousResponseId,
            InputItems = { ResponseItem.CreateUserMessageItem(userInputText) },
        };
        ApplyClientDefaults(options);
        return base.CreateResponse(options, cancellationToken);
    }

    public override Task<ClientResult<ResponseResult>> CreateResponseAsync(CreateResponseOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(options, nameof(options));
        ApplyClientDefaults(options);
        return base.CreateResponseAsync(options, cancellationToken);
    }

    public override Task<ClientResult<ResponseResult>> CreateResponseAsync(IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(inputItems, nameof(inputItems));
        CreateResponseOptions options = new()
        {
            PreviousResponseId = previousResponseId,
        };
        foreach (ResponseItem inputItem in inputItems)
        {
            options.InputItems.Add(inputItem);
        }
        ApplyClientDefaults(options);

        return base.CreateResponseAsync(options, cancellationToken);
    }

    public override Task<ClientResult<ResponseResult>> CreateResponseAsync(string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));
        CreateResponseOptions options = new()
        {
            PreviousResponseId = previousResponseId,
            InputItems = { ResponseItem.CreateUserMessageItem(userInputText) },
        };
        ApplyClientDefaults(options);
        return base.CreateResponseAsync(options, cancellationToken);
    }

    public override CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(CreateResponseOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(options, nameof(options));
        ApplyClientDefaults(options);
        return base.CreateResponseStreaming(options, cancellationToken);
    }

    public override CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(inputItems, nameof(inputItems));
        CreateResponseOptions options = new()
        {
            StreamingEnabled = true,
            PreviousResponseId = previousResponseId,
        };
        foreach (ResponseItem inputItem in inputItems)
        {
            options.InputItems.Add(inputItem);
        }
        ApplyClientDefaults(options);
        return base.CreateResponseStreaming(options, cancellationToken);
    }

    public override CollectionResult<StreamingResponseUpdate> CreateResponseStreaming(string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));
        CreateResponseOptions options = new()
        {
            StreamingEnabled = true,
            PreviousResponseId = previousResponseId,
            InputItems = { ResponseItem.CreateUserMessageItem(userInputText) },
        };
        ApplyClientDefaults(options);
        return base.CreateResponseStreaming(options, cancellationToken);
    }

    public override AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(CreateResponseOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(options, nameof(options));
        ApplyClientDefaults(options);
        return base.CreateResponseStreamingAsync(options, cancellationToken);
    }

    public override AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(IEnumerable<ResponseItem> inputItems, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(inputItems, nameof(inputItems));
        CreateResponseOptions options = new()
        {
            StreamingEnabled = true,
            PreviousResponseId = previousResponseId,
        };
        foreach (ResponseItem inputItem in inputItems)
        {
            options.InputItems.Add(inputItem);
        }
        ApplyClientDefaults(options);
        return base.CreateResponseStreamingAsync(options, cancellationToken);
    }

    public override AsyncCollectionResult<StreamingResponseUpdate> CreateResponseStreamingAsync(string userInputText, string previousResponseId = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(userInputText, nameof(userInputText));
        CreateResponseOptions options = new()
        {
            StreamingEnabled = true,
            PreviousResponseId = previousResponseId,
            InputItems = { ResponseItem.CreateUserMessageItem(userInputText) },
        };
        ApplyClientDefaults(options);
        return base.CreateResponseStreamingAsync(options, cancellationToken);
    }

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
}
