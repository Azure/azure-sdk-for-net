// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Memory;

namespace Azure.AI.Projects;

[Experimental("AAIP001")]
[CodeGenSuppress("GetGenerationJobs", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(string), typeof(DataGenerationJobScenario?), typeof(IEnumerable<DataGenerationJobKind>), typeof(CancellationToken))]
[CodeGenSuppress("GetGenerationJobsAsync", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(string), typeof(DataGenerationJobScenario?), typeof(IEnumerable<DataGenerationJobKind>), typeof(CancellationToken))]
[CodeGenSuppress("GetGenerationJobs", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<DataGenerationJobKind>), typeof(RequestOptions))]
[CodeGenSuppress("GetGenerationJobsAsync", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<DataGenerationJobKind>), typeof(RequestOptions))]
public partial class DataGenerationJobs
{
    /// <summary> Gets the details of a data generation job by its ID. </summary>
    /// <param name="jobId"> The ID of the job. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<DataGenerationJob> GetGenerationJob(string jobId, CancellationToken cancellationToken = default)
    {
        return GetGenerationJob(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken);
    }

    /// <summary> Gets the details of a data generation job by its ID. </summary>
    /// <param name="jobId"> The ID of the job. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<DataGenerationJob>> GetGenerationJobAsync(string jobId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

        return await GetGenerationJobAsync(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    /// <summary> Returns a list of data generation jobs. </summary>
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
    /// <param name="scenario"> Filter data generation jobs by their scenario. </param>
    /// <param name="kind"> Filter data generation jobs by their type. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<DataGenerationJob> GetGenerationJobs(int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, DataGenerationJobScenario? scenario = default, IEnumerable<DataGenerationJobKind> kind = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<DataGenerationJob>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetGenerationJobsRequest(
                    foundryFeatures: default,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    scenario: localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    type: kind,
                    options: localRequestOptions),
            dataItemDeserializer: DataGenerationJob.DeserializeDataGenerationJob,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [scenario?.ToString(), kind.ToString()]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns a list of data generation jobs. </summary>
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
    /// <param name="scenario"> Filter data generation jobs by their scenario. </param>
    /// <param name="kind"> Filter data generation jobs by their type. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<DataGenerationJob> GetGenerationJobsAsync(int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, DataGenerationJobScenario? scenario = default, IEnumerable<DataGenerationJobKind> kind = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<DataGenerationJob>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetGenerationJobsRequest(
                    foundryFeatures: default,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    scenario: localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    type: kind,
                    options: localRequestOptions),
            dataItemDeserializer: DataGenerationJob.DeserializeDataGenerationJob,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [scenario?.ToString()]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Creates a data generation job. </summary>
    /// <param name="body"> The job to create. </param>
    /// <param name="operationId"> Client-generated unique ID for idempotent retries. When absent, the server creates the job unconditionally. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<DataGenerationJob> CreateGenerationJob(DataGenerationJob body, string operationId = default, CancellationToken cancellationToken = default)
    {
        return CreateGenerationJob(
            job: body,
            foundryFeatures: default,
            operationId: operationId,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Creates a data generation job. </summary>
    /// <param name="body"> The job to create. </param>
    /// <param name="operationId"> Client-generated unique ID for idempotent retries. When absent, the server creates the job unconditionally. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public async virtual Task<ClientResult<DataGenerationJob>> CreateGenerationJobAsync(DataGenerationJob body, string operationId = default, CancellationToken cancellationToken = default)
    {
        return await CreateGenerationJobAsync(
            job: body,
            foundryFeatures: default,
            operationId: operationId,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Cancels a data generation job by its ID. </summary>
    /// <param name="jobId"> The ID of the job to cancel. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<DataGenerationJob> CancelGenerationJob(string jobId, CancellationToken cancellationToken = default)
    {
        return CancelGenerationJob(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Cancels a data generation job by its ID. </summary>
    /// <param name="jobId"> The ID of the job to cancel. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public async virtual Task<ClientResult<DataGenerationJob>> CancelGenerationJobAsync(string jobId, CancellationToken cancellationToken = default)
    {
        return await CancelGenerationJobAsync(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Deletes a data generation job by its ID. </summary>
    /// <param name="jobId"> The ID of the job to delete. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual void DeleteGenerationJob(string jobId, CancellationToken cancellationToken = default)
    {
        DeleteGenerationJob(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken);
    }

    /// <summary> Deletes a data generation job by its ID. </summary>
    /// <param name="jobId"> The ID of the job to delete. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public async virtual Task DeleteGenerationJobAsync(string jobId, CancellationToken cancellationToken = default)
    {
        await DeleteGenerationJobAsync(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}
