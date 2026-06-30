// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

[Experimental("AAIP001")]
[CodeGenSuppress("GetAll", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(AgentsJobStatus?), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAllAsync", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(AgentsJobStatus?), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAll", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAllAsync", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
public partial class AgentOptimizationJobs
{
    /// <summary> Create an optimization job. Returns 201 with the queued job. Honours `Operation-Id` for idempotent retry. </summary>
    /// <param name="job"> The job to create. </param>
    /// <param name="operationId"> Client-generated unique ID for idempotent retries. When absent, the server creates the job unconditionally. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="job"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<OptimizationJob> Create(OptimizationJob job, string operationId = default, CancellationToken cancellationToken = default)
    {
        return Create(
            job: job,
            foundryFeatures: default,
            operationId: operationId,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Create an optimization job. Returns 201 with the queued job. Honours `Operation-Id` for idempotent retry. </summary>
    /// <param name="job"> The job to create. </param>
    /// <param name="operationId"> Client-generated unique ID for idempotent retries. When absent, the server creates the job unconditionally. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="job"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<OptimizationJob>> CreateAsync(OptimizationJob job, string operationId = default, CancellationToken cancellationToken = default)
    {
        return await CreateAsync(
            job: job,
            foundryFeatures: default,
            operationId: operationId,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Get an optimization job by id. Returns 202 while in progress, 200 when terminal. </summary>
    /// <param name="jobId"> The ID of the job. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<OptimizationJob> Get(string jobId, CancellationToken cancellationToken = default)
    {
        return Get(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Get an optimization job by id. Returns 202 while in progress, 200 when terminal. </summary>
    /// <param name="jobId"> The ID of the job. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<OptimizationJob>> GetAsync(string jobId, CancellationToken cancellationToken = default)
    {
        return await GetAsync(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
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
    public virtual CollectionResult<OptimizationJob> GetAll(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, AgentsJobStatus? status = default, string agentName = default, CancellationToken cancellationToken = default)
    {
        status ??= new AgentsJobStatus("undefined");
        return new InternalOpenAICollectionResultOfT<OptimizationJob>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAllRequest(
                    foundryFeatures: default,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    status: string.Equals(localCollectionOptions.Filters[0], "undefined") ? null : localCollectionOptions.Filters[0],
                    agentName: localCollectionOptions.Filters.Count > 1 ? localCollectionOptions.Filters[1] : null,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<OptimizationJob>(e, o),
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
    public virtual AsyncCollectionResult<OptimizationJob> GetAllAsync(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, AgentsJobStatus? status = default, string agentName = default, CancellationToken cancellationToken = default)
    {
        status ??= new AgentsJobStatus("undefined");
        return new InternalOpenAIAsyncCollectionResultOfT<OptimizationJob>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAllRequest(
                    foundryFeatures: default,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    status: string.Equals(localCollectionOptions.Filters[0], "undefined") ? null : localCollectionOptions.Filters[0],
                    agentName: localCollectionOptions.Filters.Count > 1 ? localCollectionOptions.Filters[1] : null,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<OptimizationJob>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [status.ToString(), agentName]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Request cancellation. Idempotent on terminal states. </summary>
    /// <param name="jobId"> The ID of the job to cancel. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<OptimizationJob> Cancel(string jobId, CancellationToken cancellationToken = default)
    {
        return Cancel(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Request cancellation. Idempotent on terminal states. </summary>
    /// <param name="jobId"> The ID of the job to cancel. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<OptimizationJob>> CancelAsync(string jobId, CancellationToken cancellationToken = default)
    {
        return await CancelAsync(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Delete the job and its candidate artifacts. Cancels first if non-terminal. </summary>
    /// <param name="jobId"> The ID of the job to delete. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult Delete(string jobId, CancellationToken cancellationToken = default)
    {
        return Delete(jobId: jobId, foundryFeatures: default, cancellationToken: cancellationToken);
    }

    /// <summary> Delete the job and its candidate artifacts. Cancels first if non-terminal. </summary>
    /// <param name="jobId"> The ID of the job to delete. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult> DeleteAsync(string jobId, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync(jobId: jobId, foundryFeatures: default, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}
