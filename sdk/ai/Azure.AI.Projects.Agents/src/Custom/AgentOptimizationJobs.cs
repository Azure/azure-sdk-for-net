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
[CodeGenSuppress("GetAll", typeof(FoundryFeaturesOptInKeys), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(JobStatus?), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAllAsync", typeof(FoundryFeaturesOptInKeys), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(JobStatus?), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAll", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAllAsync", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
public partial class AgentOptimizationJobs
{
    /// <summary> Create an optimization job. Returns 201 with the queued job. Honours `Operation-Id` for idempotent retry. </summary>
    /// <param name="inputs"> The optimization job inputs. </param>
    /// <param name="operationId"> Client-generated unique ID for idempotent retries. When absent, the server creates the job unconditionally. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<OptimizationJob> Create(OptimizationJobInputs inputs, string operationId = default, CancellationToken cancellationToken = default)
    {
        return Create(
            inputs: inputs,
            foundryFeatures: default,
            operationId: operationId,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Create an optimization job. Returns 201 with the queued job. Honours `Operation-Id` for idempotent retry. </summary>
    /// <param name="inputs"> The optimization job inputs. </param>
    /// <param name="operationId"> Client-generated unique ID for idempotent retries. When absent, the server creates the job unconditionally. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<OptimizationJob>> CreateAsync(OptimizationJobInputs inputs, string operationId = default, CancellationToken cancellationToken = default)
    {
        return await CreateAsync(
            inputs: inputs,
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
    public virtual CollectionResult<OptimizationJob> GetAll(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, JobStatus? status = default, string agentName = default, CancellationToken cancellationToken = default)
    {
        status ??= new JobStatus("undefined");
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
    public virtual AsyncCollectionResult<OptimizationJob> GetAllAsync(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, JobStatus? status = default, string agentName = default, CancellationToken cancellationToken = default)
    {
        status ??= new JobStatus("undefined");
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
    /// <param name="force"> When true, force-delete even if the job is in a non-terminal state. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult Delete(string jobId, bool? force = default, CancellationToken cancellationToken = default)
    {
        return Delete(jobId: jobId, foundryFeatures: default, force: force, cancellationToken: cancellationToken);
    }

    /// <summary> Delete the job and its candidate artifacts. Cancels first if non-terminal. </summary>
    /// <param name="jobId"> The ID of the job to delete. </param>
    /// <param name="force"> When true, force-delete even if the job is in a non-terminal state. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult> DeleteAsync(string jobId, bool? force = default, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync(jobId: jobId, foundryFeatures: default, force: force, cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    /// <summary> List candidates produced by a job. </summary>
    /// <param name="jobId"> The optimization job id. </param>
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
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentsPagedResultOptimizationCandidate> GetCandidates(string jobId, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return GetCandidates(
            jobId: jobId,
            foundryFeatures: default,
            limit: limit,
            order: order,
            after: after,
            before: before,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> List candidates produced by a job. </summary>
    /// <param name="jobId"> The optimization job id. </param>
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
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentsPagedResultOptimizationCandidate>> GetCandidatesAsync(string jobId, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return await GetCandidatesAsync(
            jobId: jobId,
            foundryFeatures: default,
            limit: limit,
            order: order,
            after: after,
            before: before,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Get a single candidate's metadata, manifest, and promotion info. </summary>
    /// <param name="jobId"> The optimization job id. </param>
    /// <param name="candidateId"> The candidate id. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<CandidateMetadata> GetCandidate(string jobId, string candidateId, CancellationToken cancellationToken = default)
    {
        return GetCandidate(
            jobId: jobId,
            candidateId: candidateId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }
    /// <summary> Get a single candidate's metadata, manifest, and promotion info. </summary>
    /// <param name="jobId"> The optimization job id. </param>
    /// <param name="candidateId"> The candidate id. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<CandidateMetadata>> GetCandidateAsync(string jobId, string candidateId, CancellationToken cancellationToken = default)
    {
        return await GetCandidateAsync(
            jobId: jobId,
            candidateId: candidateId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Get the candidate's deploy config JSON. Used to compose `agents.create_version(...)` from a candidate. </summary>
    /// <param name="jobId"> The optimization job id. </param>
    /// <param name="candidateId"> The candidate id. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<CandidateDeployConfig> GetCandidateConfig(string jobId, string candidateId, CancellationToken cancellationToken = default)
    {
        return GetCandidateConfig(
            jobId: jobId,
            candidateId: candidateId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Get the candidate's deploy config JSON. Used to compose `agents.create_version(...)` from a candidate. </summary>
    /// <param name="jobId"> The optimization job id. </param>
    /// <param name="candidateId"> The candidate id. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<CandidateDeployConfig>> GetCandidateConfigAsync(string jobId, string candidateId, CancellationToken cancellationToken = default)
    {
        return await GetCandidateConfigAsync(
            jobId: jobId,
            candidateId: candidateId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Get full per-task evaluation results for a candidate. </summary>
    /// <param name="jobId"> The optimization job id. </param>
    /// <param name="candidateId"> The candidate id. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<CandidateResults> GetCandidateResults(string jobId, string candidateId, CancellationToken cancellationToken = default)
    {
        return GetCandidateResults(
            jobId: jobId,
            candidateId: candidateId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Get full per-task evaluation results for a candidate. </summary>
    /// <param name="jobId"> The optimization job id. </param>
    /// <param name="candidateId"> The candidate id. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<CandidateResults>> GetCandidateResultsAsync(string jobId, string candidateId, CancellationToken cancellationToken = default)
    {
        return await GetCandidateResultsAsync(
            jobId: jobId,
            candidateId: candidateId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Stream a specific file from the candidate's blob directory. </summary>
    /// <param name="jobId"> The optimization job id. </param>
    /// <param name="candidateId"> The candidate id. </param>
    /// <param name="path"> Relative path of the file to download (e.g. 'files/examples.jsonl'). </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/>, <paramref name="candidateId"/> or <paramref name="path"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/>, <paramref name="candidateId"/> or <paramref name="path"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<BinaryData> GetCandidateFile(string jobId, string candidateId, string path, CancellationToken cancellationToken = default)
    {
        return GetCandidateFile(
            jobId: jobId,
            candidateId: candidateId,
            path: path,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }
    /// <summary> Stream a specific file from the candidate's blob directory. </summary>
    /// <param name="jobId"> The optimization job id. </param>
    /// <param name="candidateId"> The candidate id. </param>
    /// <param name="path"> Relative path of the file to download (e.g. 'files/examples.jsonl'). </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/>, <paramref name="candidateId"/> or <paramref name="path"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/>, <paramref name="candidateId"/> or <paramref name="path"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<BinaryData>> GetCandidateFileAsync(string jobId, string candidateId, string path, CancellationToken cancellationToken = default)
    {
        return await GetCandidateFileAsync(
            jobId: jobId,
            candidateId: candidateId,
            path: path,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Promotes a candidate, recording the deployment timestamp and target agent version. </summary>
    /// <param name="jobId"> The optimization job id. </param>
    /// <param name="candidateId"> The candidate id to promote. </param>
    /// <param name="candidateRequest"> Promotion details. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/>, <paramref name="candidateId"/> or <paramref name="candidateRequest"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<PromoteCandidateResponse> PromoteCandidate(string jobId, string candidateId, PromoteCandidateRequest candidateRequest, CancellationToken cancellationToken = default)
    {
        return PromoteCandidate(
            jobId: jobId,
            candidateId: candidateId,
            candidateRequest: candidateRequest,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Promotes a candidate, recording the deployment timestamp and target agent version. </summary>
    /// <param name="jobId"> The optimization job id. </param>
    /// <param name="candidateId"> The candidate id to promote. </param>
    /// <param name="candidateRequest"> Promotion details. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/>, <paramref name="candidateId"/> or <paramref name="candidateRequest"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="candidateId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<PromoteCandidateResponse>> PromoteCandidateAsync(string jobId, string candidateId, PromoteCandidateRequest candidateRequest, CancellationToken cancellationToken = default)
    {
        return await PromoteCandidateAsync(
            jobId: jobId,
            candidateId: candidateId,
            candidateRequest: candidateRequest,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }
}
