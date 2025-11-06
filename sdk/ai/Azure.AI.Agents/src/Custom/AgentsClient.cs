// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;

namespace Azure.AI.Agents;

[CodeGenSuppress("CreateAgent", typeof(string), typeof(AgentDefinition), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("CreateAgentAsync", typeof(string), typeof(AgentDefinition), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("CreateAgentFromManifest", typeof(string), typeof(string), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("CreateAgentFromManifestAsync", typeof(string), typeof(string), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("CreateAgentVersionFromManifest", typeof(string), typeof(string), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("CreateAgentVersionFromManifestAsync", typeof(string), typeof(string), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgents", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAgentsAsync", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAgentVersions", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAgentVersionsAsync", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetInternalAgentResponsesClient")]
[CodeGenSuppress("CreateAgentVersion", typeof(string), typeof(AgentDefinition), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("CreateAgentVersionAsync", typeof(string), typeof(AgentDefinition), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("UpdateAgent", typeof(string), typeof(AgentDefinition), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("UpdateAgentAsync", typeof(string), typeof(AgentDefinition), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("UpdateAgentFromManifest", typeof(string), typeof(string), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("UpdateAgentFromManifestAsync", typeof(string), typeof(string), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, string>), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("_cachedInternalAgentResponses")]
[CodeGenType("Agents")]
public partial class AgentsClient
{
    private OpenAIClient _cachedOpenAIClient;
    private ConversationClient _cachedConversations;
    private MemoryStoreClient _cachedMemoryStores;
    private readonly TelemetryDetails _telemetryDetails;
    private readonly AuthenticationTokenProvider _tokenProvider;

    /// <summary> Initializes a new instance of AgentsClient. </summary>
    /// <param name="endpoint"> Service endpoint. </param>
    /// <param name="tokenProvider"> A credential provider used to authenticate to the service. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="tokenProvider"/> is null. </exception>
    public AgentsClient(Uri endpoint, AuthenticationTokenProvider tokenProvider) : this(endpoint, tokenProvider, new AgentsClientOptions())
    {
    }

    /// <summary> Initializes a new instance of AgentsClient. </summary>
    /// <param name="endpoint"> Service endpoint. </param>
    /// <param name="tokenProvider"> A credential provider used to authenticate to the service. </param>
    /// <param name="options"> The options for configuring the client. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="tokenProvider"/> is null. </exception>
    public AgentsClient(Uri endpoint, AuthenticationTokenProvider tokenProvider, AgentsClientOptions options)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(tokenProvider, nameof(tokenProvider));

        options ??= new();

        _endpoint = endpoint;
        _tokenProvider = tokenProvider;
        _telemetryDetails = new(typeof(AgentsClient).Assembly, options?.UserAgentApplicationId);
        _apiVersion = options.Version;

        PipelinePolicyHelpers.AddQueryParameterPolicy(options, "api-version", _apiVersion);
        PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "User-Agent", _telemetryDetails.UserAgent.ToString());
        PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "x-ms-client-request-id", () => Guid.NewGuid().ToString().ToLowerInvariant());

        // TODO: Use of generated _flows results in authentication failure; hard-coded here for single scope
        Pipeline = ClientPipeline.Create(
            options,
            perCallPolicies: [],
            perTryPolicies: [new BearerTokenPolicy(tokenProvider, "https://ai.azure.com/.default")],
            beforeTransportPolicies: []);
    }

    /// <summary> Creates the agent. </summary>
    /// <param name="name"> The unique name that identifies the agent. Name can be used to retrieve/update/delete the agent. </param>
    /// <param name="definition"> The agent definition. This can be a workflow, hosted agent, or a simple agent definition. </param>
    /// <param name="options"> Additional options to use for the creation of the agent. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="definition"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentRecord> CreateAgent(string name, AgentDefinition definition, AgentCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(definition, nameof(definition));

        options = CreatePerCallOptions(options, name, definition);

        ClientResult result = CreateAgent(options, cancellationToken.ToRequestOptions());
        return result.ToAgentsClientResult<AgentRecord>();
    }

    /// <summary> Creates the agent. </summary>
    /// <param name="name"> The unique name that identifies the agent. Name can be used to retrieve/update/delete the agent. </param>
    /// <param name="definition"> The agent definition. This can be a workflow, hosted agent, or a simple agent definition. </param>
    /// <param name="options"> Additional options to use for the creation of the agent. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="definition"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentRecord>> CreateAgentAsync(string name, AgentDefinition definition, AgentCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(definition, nameof(definition));

        options = CreatePerCallOptions(options, name, definition);

        ClientResult result = await CreateAgentAsync(options, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((AgentRecord)result, result.GetRawResponse());
    }

    /// <summary> Create a new agent version. </summary>
    /// <param name="agentName"> The name of the agent for which a new version should be created. </param>
    /// <param name="definition"> The agent definition. This can be a workflow, hosted agent, or a simple agent definition. </param>
    /// <param name="options"> Additional options for the new agent version to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="definition"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentVersion> CreateAgentVersion(string agentName, AgentDefinition definition, AgentVersionCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(definition, nameof(definition));

        options = CreatePerCallOptions(options, definition);

        ClientResult result = CreateAgentVersion(agentName, options, cancellationToken.ToRequestOptions());
        return result.ToAgentsClientResult<AgentVersion>();
    }

    /// <summary> Create a new agent version. </summary>
    /// <param name="agentName"> The name of the agent for which a new version should be created. </param>
    /// <param name="definition"> The agent definition. This can be a workflow, hosted agent, or a simple agent definition. </param>
    /// <param name="options"> Additional options for the new agent version to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="definition"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentVersion>> CreateAgentVersionAsync(string agentName, AgentDefinition definition, AgentVersionCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(definition, nameof(definition));

        options = CreatePerCallOptions(options, definition);

        ClientResult result = await CreateAgentVersionAsync(agentName, options, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return result.ToAgentsClientResult<AgentVersion>();
    }

    public virtual ClientResult<AgentVersion> CreateAgentVersionFromManifest(string agentName, string manifestId, AgentManifestOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(manifestId, nameof(manifestId));
        Argument.AssertNotNull(options, nameof(options));

        options ??= new();

        ClientResult result = CreateAgentVersionFromManifest(agentName, options, cancellationToken.ToRequestOptions());
        return result.ToAgentsClientResult<AgentVersion>();
    }

    public virtual async Task<ClientResult<AgentVersion>> CreateAgentVersionFromManifestAsync(string agentName, string manifestId, AgentManifestOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(manifestId, nameof(manifestId));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult result = await CreateAgentVersionFromManifestAsync(agentName, options, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return result.ToAgentsClientResult<AgentVersion>();
    }

    /// <summary> Creates an agent from a manifest. </summary>
    /// <param name="agentName"> The unique name that identifies the agent. Name can be used to retrieve/update/delete the agent. </param>
    /// <param name="manifestId"> The manifest ID to import the agent version from. </param>
    /// <param name="options"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="manifestId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="manifestId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentRecord> CreateAgentFromManifest(string agentName, string manifestId, AgentManifestOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(manifestId, nameof(manifestId));

        options ??= new();

        CreateAgentFromManifestRequest1 spreadModel = new(
            name: agentName,
            description: options?.Description,
            metadata: options?.Metadata ?? new ChangeTrackingDictionary<string, string>(),
            manifestId: manifestId,
            parameterValues: options?.ParameterValues ?? new ChangeTrackingDictionary<string, BinaryData>(),
            additionalBinaryDataProperties: default);
        ClientResult result = CreateAgentFromManifest(spreadModel, cancellationToken.ToRequestOptions());
        return result.ToAgentsClientResult<AgentRecord>();
    }

    /// <summary> Creates an agent from a manifest. </summary>
    /// <param name="agentName"> The unique name that identifies the agent. Name can be used to retrieve/update/delete the agent. </param>
    /// <param name="manifestId"> The manifest ID to import the agent version from. </param>
    /// <param name="options"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="manifestId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="manifestId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentRecord>> CreateAgentFromManifestAsync(string agentName, string manifestId, AgentManifestOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(manifestId, nameof(manifestId));

        CreateAgentFromManifestRequest1 spreadModel = new(
            name: agentName,
            description: options?.Description,
            metadata: options?.Metadata ?? new ChangeTrackingDictionary<string, string>(),
            manifestId: manifestId,
            parameterValues: options?.ParameterValues ?? new ChangeTrackingDictionary<string, BinaryData>(),
            additionalBinaryDataProperties: default);
        ClientResult result = await CreateAgentFromManifestAsync(spreadModel, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return result.ToAgentsClientResult<AgentRecord>();
    }

    /// <summary>
    /// Updates the agent by adding a new version if there are any changes to the agent definition.
    /// If no changes, returns the existing agent version.
    /// </summary>
    /// <param name="agentName"> The name of the agent to retrieve. </param>
    /// <param name="options"> The options describing the updates to make for the new agent version. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="options"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentRecord> UpdateAgent(string agentName, AgentUpdateOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult result = UpdateAgent(agentName, options, cancellationToken.CanBeCanceled ? new RequestOptions { CancellationToken = cancellationToken } : null);
        return ClientResult.FromValue((AgentRecord)result, result.GetRawResponse());
    }

    /// <summary>
    /// Updates the agent by adding a new version if there are any changes to the agent definition.
    /// If no changes, returns the existing agent version.
    /// </summary>
    /// <param name="agentName"> The name of the agent to retrieve. </param>
    /// <param name="options"> The options describing the updates to make for the new agent version. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="options"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentRecord>> UpdateAgentAsync(string agentName, AgentUpdateOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult result = await UpdateAgentAsync(agentName, options, cancellationToken.CanBeCanceled ? new RequestOptions { CancellationToken = cancellationToken } : null).ConfigureAwait(false);
        return ClientResult.FromValue((AgentRecord)result, result.GetRawResponse());
    }

    /// <summary>
    /// Updates the agent from a manifest by adding a new version if there are any changes to the agent definition.
    /// If no changes, returns the existing agent version.
    /// </summary>
    /// <param name="agentName"> The name of the agent to update. </param>
    /// <param name="manifestId"> The manifest ID to import the agent version from. </param>
    /// <param name="options"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="manifestId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="manifestId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentRecord> UpdateAgentFromManifest(string agentName, string manifestId, AgentManifestOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(manifestId, nameof(manifestId));

        UpdateAgentFromManifestRequest1 spreadModel = new UpdateAgentFromManifestRequest1(
            description: options?.Description,
            metadata: options?.Metadata ?? new ChangeTrackingDictionary<string, string>(),
            manifestId: manifestId,
            parameterValues: options?.ParameterValues ?? new ChangeTrackingDictionary<string, BinaryData>(),
            additionalBinaryDataProperties: default);
        ClientResult result = UpdateAgentFromManifest(agentName, spreadModel, cancellationToken.ToRequestOptions());
        return result.ToAgentsClientResult<AgentRecord>();
    }

    /// <summary>
    /// Updates the agent from a manifest by adding a new version if there are any changes to the agent definition.
    /// If no changes, returns the existing agent version.
    /// </summary>
    /// <param name="agentName"> The name of the agent to update. </param>
    /// <param name="manifestId"> The manifest ID to import the agent version from. </param>
    /// <param name="options"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="manifestId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="manifestId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentRecord>> UpdateAgentFromManifestAsync(string agentName, string manifestId, AgentManifestOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(manifestId, nameof(manifestId));

        UpdateAgentFromManifestRequest1 spreadModel = new UpdateAgentFromManifestRequest1(
            description: options?.Description,
            metadata: options?.Metadata ?? new ChangeTrackingDictionary<string, string>(),
            manifestId: manifestId,
            parameterValues: options?.ParameterValues ?? new ChangeTrackingDictionary<string, BinaryData>(),
            additionalBinaryDataProperties: default);
        ClientResult result = await UpdateAgentFromManifestAsync(agentName, spreadModel, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return result.ToAgentsClientResult<AgentRecord>();
    }

    /// <summary> Returns the list of all agents. </summary>
    /// <param name="kind"> Filter agents by kind. If not provided, all agents are returned. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<AgentRecord> GetAgents(AgentKind? kind = default, int? limit = default, AgentsListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<AgentRecord>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentsRequest(
                    localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: AgentRecord.DeserializeAgentRecord,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [kind?.ToString()]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns the list of all agents. </summary>
    /// <param name="kind"> Filter agents by kind. If not provided, all agents are returned. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<AgentRecord> GetAgentsAsync(AgentKind? kind = default, int? limit = default, AgentsListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<AgentRecord>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentsRequest(
                    localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: AgentRecord.DeserializeAgentRecord,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [kind?.ToString()]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns the list of versions of an agent. </summary>
    /// <param name="agentName"> The name of the agent to retrieve versions for. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<AgentVersion> GetAgentVersions(string agentName, int? limit = default, AgentsListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        return new InternalOpenAICollectionResultOfT<AgentVersion>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentVersionsRequest(
                    localCollectionOptions.ParentResourceId,
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: AgentVersion.DeserializeAgentVersion,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before)
            {
                ParentResourceId = agentName,
            },
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns the list of versions of an agent. </summary>
    /// <param name="agentName"> The name of the agent to retrieve versions for. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<AgentVersion> GetAgentVersionsAsync(string agentName, int? limit = default, AgentsListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        return new InternalOpenAIAsyncCollectionResultOfT<AgentVersion>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentVersionsRequest(
                    localCollectionOptions.ParentResourceId,
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: AgentVersion.DeserializeAgentVersion,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before)
            {
                ParentResourceId = agentName,
            },
            cancellationToken.ToRequestOptions());
    }

    public virtual OpenAIClient GetOpenAIClient(OpenAIClientOptions options = null)
    {
        OpenAIClient CreateClient()
        {
            string rawProjectEndpoint = _endpoint.AbsoluteUri;
            if (rawProjectEndpoint.Length > 0 && rawProjectEndpoint[rawProjectEndpoint.Length - 1] == '/')
            {
                rawProjectEndpoint = rawProjectEndpoint.Substring(0, rawProjectEndpoint.Length - 1);
            }
            Uri azureOpenAIEndpoint = new($"{rawProjectEndpoint}/openai");

            OpenAIClientOptions clientOptions = options ??= new();
            options.UserAgentApplicationId = _telemetryDetails.UserAgent.AssemblyName; // _telemetryDetails.UserAgent.ToString(includePlatformInformation: false);
            options.Endpoint = azureOpenAIEndpoint;

            PipelinePolicyHelpers.AddQueryParameterPolicy(clientOptions, "api-version", _apiVersion);
            PipelinePolicyHelpers.AddRequestHeaderPolicy(clientOptions, "x-ms-client-request-id", () => Guid.NewGuid().ToString().ToLowerInvariant());
            PipelinePolicyHelpers.OpenAI.AddResponseItemInputTransformPolicy(clientOptions);
            PipelinePolicyHelpers.OpenAI.AddErrorTransformPolicy(clientOptions);
            PipelinePolicyHelpers.OpenAI.AddAzureFinetuningParityPolicy(clientOptions);

            if (_tokenProvider is not null)
            {
                return new OpenAIClient(new BearerTokenPolicy(_tokenProvider, "https://ai.azure.com/.default"), clientOptions);
            }
            throw new NotImplementedException();
        }
        return Volatile.Read(ref _cachedOpenAIClient)
            ?? Interlocked.CompareExchange(ref _cachedOpenAIClient, CreateClient(), null)
                ?? _cachedOpenAIClient;
    }

    /// <summary> Initializes a new instance of Conversations. </summary>
    public virtual ConversationClient GetConversationClient()
    {
        return Volatile.Read(ref _cachedConversations) ?? Interlocked.CompareExchange(ref _cachedConversations, new ConversationClient(Pipeline, _endpoint, _apiVersion), null) ?? _cachedConversations;
    }

    /// <summary> Initializes a new instance of MemoryStores. </summary>
    public virtual MemoryStoreClient GetMemoryStoreClient()
    {
        return Volatile.Read(ref _cachedMemoryStores) ?? Interlocked.CompareExchange(ref _cachedMemoryStores, new MemoryStoreClient(Pipeline, _endpoint, _apiVersion), null) ?? _cachedMemoryStores;
    }

    internal virtual AgentVersionCreationOptions CreatePerCallOptions(AgentVersionCreationOptions userOptions, AgentDefinition definition)
    {
        AgentVersionCreationOptions copiedOptions = userOptions is null ? new() : userOptions.GetClone();
        copiedOptions.Definition = definition;

        return copiedOptions;
    }

    internal virtual AgentCreationOptions CreatePerCallOptions(AgentCreationOptions userOptions, string name, AgentDefinition definition)
    {
        AgentCreationOptions copiedOptions = userOptions is null ? new() : userOptions.GetClone();
        copiedOptions.Name = name;
        copiedOptions.Definition = definition;

        return copiedOptions;
    }
}
