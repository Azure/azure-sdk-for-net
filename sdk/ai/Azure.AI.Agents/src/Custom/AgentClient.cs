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
[CodeGenType("AgentClient")]
public partial class AgentClient
{
    private OpenAIClient _cachedOpenAIClient;
    private ConversationClient _cachedConversations;
    private MemoryStoreClient _cachedMemoryStores;
    private readonly TelemetryDetails _telemetryDetails;
    private readonly AuthenticationTokenProvider _tokenProvider;

    /// <summary> Initializes a new instance of AgentClient. </summary>
    /// <param name="endpoint"> Service endpoint. </param>
    /// <param name="tokenProvider"> A credential provider used to authenticate to the service. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="tokenProvider"/> is null. </exception>
    public AgentClient(Uri endpoint, AuthenticationTokenProvider tokenProvider) : this(endpoint, tokenProvider, new AgentClientOptions())
    {
    }

    /// <summary> Initializes a new instance of AgentClient. </summary>
    /// <param name="endpoint"> Service endpoint. </param>
    /// <param name="tokenProvider"> A credential provider used to authenticate to the service. </param>
    /// <param name="options"> The options for configuring the client. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="tokenProvider"/> is null. </exception>
    public AgentClient(Uri endpoint, AuthenticationTokenProvider tokenProvider, AgentClientOptions options)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(tokenProvider, nameof(tokenProvider));

        options ??= new();

        _endpoint = endpoint;
        _tokenProvider = tokenProvider;
        _telemetryDetails = new(typeof(AgentClient).Assembly, options?.UserAgentApplicationId);
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

    /// <summary> Create a new agent version. </summary>
    /// <param name="agentName"> The name of the agent for which a new version should be created. </param>
    /// <param name="options"> Options, including the definition, for the new agent version to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="options"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentVersion> CreateAgentVersion(string agentName, AgentVersionCreationOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult result = CreateAgentVersion(agentName, options, cancellationToken.ToRequestOptions());
        return result.ToAgentClientResult<AgentVersion>();
    }

    /// <summary> Create a new agent version. </summary>
    /// <param name="agentName"> The name of the agent for which a new version should be created. </param>
    /// <param name="options"> Options, including the definition, for the new agent version to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="options"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentVersion>> CreateAgentVersionAsync(string agentName, AgentVersionCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult result = await CreateAgentVersionAsync(agentName, options, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return result.ToAgentClientResult<AgentVersion>();
    }

    public virtual ClientResult<AgentVersion> CreateAgentVersionFromManifest(string agentName, string manifestId, AgentManifestOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(manifestId, nameof(manifestId));
        Argument.AssertNotNull(options, nameof(options));

        options ??= new();

        ClientResult result = CreateAgentVersionFromManifest(agentName, options, cancellationToken.ToRequestOptions());
        return result.ToAgentClientResult<AgentVersion>();
    }

    public virtual async Task<ClientResult<AgentVersion>> CreateAgentVersionFromManifestAsync(string agentName, string manifestId, AgentManifestOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(manifestId, nameof(manifestId));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult result = await CreateAgentVersionFromManifestAsync(agentName, options, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return result.ToAgentClientResult<AgentVersion>();
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
    public virtual CollectionResult<AgentRecord> GetAgents(AgentKind? kind = default, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
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
    public virtual AsyncCollectionResult<AgentRecord> GetAgentsAsync(AgentKind? kind = default, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
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
    public virtual CollectionResult<AgentVersion> GetAgentVersions(string agentName, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
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
    public virtual AsyncCollectionResult<AgentVersion> GetAgentVersionsAsync(string agentName, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
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

    /// <summary> Deletes an agent. </summary>
    /// <param name="agentName"> The name of the agent to delete. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult DeleteAgent(string agentName, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        ClientResult result = DeleteAgent(agentName, cancellationToken.ToRequestOptions());
        return result;
    }

    /// <summary> Deletes an agent. </summary>
    /// <param name="agentName"> The name of the agent to delete. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult> DeleteAgentAsync(string agentName, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        ClientResult result = await DeleteAgentAsync(agentName, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return result;
    }

    /// <summary> Deletes a specific version of an agent. </summary>
    /// <param name="agentName"> The name of the agent to delete. </param>
    /// <param name="agentVersion"> The version of the agent to delete. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="agentVersion"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="agentVersion"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult DeleteAgentVersion(string agentName, string agentVersion, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(agentVersion, nameof(agentVersion));

        ClientResult result = DeleteAgentVersion(agentName, agentVersion, cancellationToken.ToRequestOptions());
        return result;
    }

    /// <summary> Deletes a specific version of an agent. </summary>
    /// <param name="agentName"> The name of the agent to delete. </param>
    /// <param name="agentVersion"> The version of the agent to delete. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="agentVersion"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="agentVersion"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult> DeleteAgentVersionAsync(string agentName, string agentVersion, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(agentVersion, nameof(agentVersion));

        ClientResult result = await DeleteAgentVersionAsync(agentName, agentVersion, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return result;
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
}
