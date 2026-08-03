// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Memory;

namespace Azure.AI.Projects;

[Experimental("AAIP001")]
[CodeGenSuppress("GetGenerationJobs", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetGenerationJobsAsync", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetGenerationJobs", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetGenerationJobsAsync", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
public partial class DataGenerationJobs
{
    /// <summary> Gets the details of a data generation job by its ID. </summary>
    /// <param name="jobId"> The ID of the job. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<DataGenerationJob> Get(string jobId, CancellationToken cancellationToken = default)
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
    public virtual async Task<ClientResult<DataGenerationJob>> GetAsync(string jobId, CancellationToken cancellationToken = default)
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
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<DataGenerationJob> GetAll(int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
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
                    options: localRequestOptions),
            dataItemDeserializer: DataGenerationJob.DeserializeDataGenerationJob,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before),
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
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<DataGenerationJob> GetAllAsync(int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
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
                    options: localRequestOptions),
            dataItemDeserializer: DataGenerationJob.DeserializeDataGenerationJob,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Creates a data generation job. </summary>
    /// <param name="job"> The job to create. </param>
    /// <param name="operationId"> Client-generated unique ID for idempotent retries. When absent, the server creates the job unconditionally. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="job"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<DataGenerationJob> Create(DataGenerationJob job, string operationId = default, CancellationToken cancellationToken = default)
    {
        return CreateGenerationJob(
            job: job,
            foundryFeatures: default,
            operationId: operationId,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Creates a data generation job. </summary>
    /// <param name="job"> The job to create. </param>
    /// <param name="operationId"> Client-generated unique ID for idempotent retries. When absent, the server creates the job unconditionally. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="job"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<DataGenerationJob>> CreateAsync(DataGenerationJob job, string operationId = default, CancellationToken cancellationToken = default)
    {
        return await CreateGenerationJobAsync(
            job: job,
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
    public virtual ClientResult<DataGenerationJob> Cancel(string jobId, CancellationToken cancellationToken = default)
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
    public async virtual Task<ClientResult<DataGenerationJob>> CancelAsync(string jobId, CancellationToken cancellationToken = default)
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
    public virtual ClientResult Delete(string jobId, CancellationToken cancellationToken = default)
    {
        return DeleteGenerationJob(
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
    public async virtual Task<ClientResult> DeleteAsync(string jobId, CancellationToken cancellationToken = default)
    {
        return await DeleteGenerationJobAsync(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}
