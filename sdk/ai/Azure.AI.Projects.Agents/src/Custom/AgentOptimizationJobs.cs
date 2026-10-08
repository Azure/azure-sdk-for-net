// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Azure.AI.Projects.Agents;

[Experimental("AAIP001")]
[CodeGenSuppress("GetAll", typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(AgentsJobStatus?), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAllAsync", typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(AgentsJobStatus?), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAll", typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAllAsync", typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
public partial class AgentOptimizationJobs
{
    /// <summary> List optimization jobs. Supports cursor pagination and optional status / agent_name filters. </summary>
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
    /// <param name="status"> Filter to jobs in this lifecycle state. </param>
    /// <param name="agentName"> Filter to jobs targeting this agent name. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<AgentOptimizationJob> GetAll(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, AgentsJobStatus? status = default, string agentName = default, CancellationToken cancellationToken = default)
    {
        status ??= new AgentsJobStatus("undefined");
        return new InternalOpenAICollectionResultOfT<AgentOptimizationJob>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAllRequest(
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    status: string.Equals(localCollectionOptions.Filters[0], "undefined") ? null : localCollectionOptions.Filters[0],
                    agentName: localCollectionOptions.Filters.Count > 1 ? localCollectionOptions.Filters[1] : null,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<AgentOptimizationJob>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [status.ToString(), agentName]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> List optimization jobs. Supports cursor pagination and optional status / agent_name filters. </summary>
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
    /// <param name="status"> Filter to jobs in this lifecycle state. </param>
    /// <param name="agentName"> Filter to jobs targeting this agent name. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<AgentOptimizationJob> GetAllAsync(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, AgentsJobStatus? status = default, string agentName = default, CancellationToken cancellationToken = default)
    {
        status ??= new AgentsJobStatus("undefined");
        return new InternalOpenAIAsyncCollectionResultOfT<AgentOptimizationJob>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAllRequest(
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    status: string.Equals(localCollectionOptions.Filters[0], "undefined") ? null : localCollectionOptions.Filters[0],
                    agentName: localCollectionOptions.Filters.Count > 1 ? localCollectionOptions.Filters[1] : null,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<AgentOptimizationJob>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [status.ToString(), agentName]),
            cancellationToken.ToRequestOptions());
    }
}
