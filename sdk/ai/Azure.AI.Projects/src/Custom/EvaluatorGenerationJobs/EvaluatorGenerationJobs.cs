// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Evaluation;
using Azure.AI.Projects.Memory;

namespace Azure.AI.Projects;

[Experimental("AAIP001")]
[CodeGenSuppress("GetAll", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(string), typeof(EvaluatorCategory?), typeof(CancellationToken))]
[CodeGenSuppress("GetAllAsync", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(string), typeof(EvaluatorCategory?), typeof(CancellationToken))]
[CodeGenSuppress("GetAll", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAllAsync", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
public partial class EvaluatorGenerationJobs
{
    /// <summary>
    /// Creates an evaluator generation job. The service generates rubric-based evaluator
    /// definitions from the provided source materials asynchronously.
    /// </summary>
    /// <param name="job"> The job to create. </param>
    /// <param name="operationId"> Client-generated unique ID for idempotent retries. When absent, the server creates the job unconditionally. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="job"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<EvaluatorGenerationJob> Create(EvaluatorGenerationJob job, string operationId = default, CancellationToken cancellationToken = default)
    {
        return Create(
            job: job,
            foundryFeatures: default,
            operationId: operationId,
            cancellationToken: cancellationToken
        );
    }

    /// <summary>
    /// Creates an evaluator generation job. The service generates rubric-based evaluator
    /// definitions from the provided source materials asynchronously.
    /// </summary>
    /// <param name="job"> The job to create. </param>
    /// <param name="operationId"> Client-generated unique ID for idempotent retries. When absent, the server creates the job unconditionally. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="job"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<EvaluatorGenerationJob>> CreateAsync(EvaluatorGenerationJob job, string operationId = default, CancellationToken cancellationToken = default)
    {
        return await CreateAsync(
            job: job,
            foundryFeatures: default,
            operationId: operationId,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Gets the details of an evaluator generation job by its ID. </summary>
    /// <param name="jobId"> The ID of the job. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<EvaluatorGenerationJob> Get(string jobId, CancellationToken cancellationToken = default)
    {
        return Get(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Gets the details of an evaluator generation job by its ID. </summary>
    /// <param name="jobId"> The ID of the job. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<EvaluatorGenerationJob>> GetAsync(string jobId, CancellationToken cancellationToken = default)
    {
        return Get(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Returns a list of evaluator generation jobs. </summary>
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
    /// <param name="category"> Filter evaluator generation jobs by category. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<EvaluatorGenerationJob> GetAll(int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, EvaluatorCategory? category = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<EvaluatorGenerationJob>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAllRequest(
                    foundryFeatures: default,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    category: localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    options: localRequestOptions),
            dataItemDeserializer: EvaluatorGenerationJob.DeserializeEvaluatorGenerationJob,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [category?.ToString()]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns a list of evaluator generation jobs. </summary>
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
    /// <param name="category"> Filter evaluator generation jobs by category. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<EvaluatorGenerationJob> GetAllAsync(int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, EvaluatorCategory? category = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<EvaluatorGenerationJob>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAllRequest(
                    foundryFeatures: default,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    category: localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    options: localRequestOptions),
            dataItemDeserializer: EvaluatorGenerationJob.DeserializeEvaluatorGenerationJob,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [category?.ToString()]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Cancels an evaluator generation job by its ID. </summary>
    /// <param name="jobId"> The ID of the job to cancel. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<EvaluatorGenerationJob> Cancel(string jobId, CancellationToken cancellationToken = default)
    {
        return Cancel(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Cancels an evaluator generation job by its ID. </summary>
    /// <param name="jobId"> The ID of the job to cancel. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<EvaluatorGenerationJob>> CancelAsync(string jobId, CancellationToken cancellationToken = default)
    {
        return await CancelAsync(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary>
    /// Deletes an evaluator generation job by its ID. Deletes the job record only;
    /// the generated evaluator (if any) is preserved.
    /// </summary>
    /// <param name="jobId"> The ID of the job to delete. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult Delete(string jobId, CancellationToken cancellationToken = default)
    {
        return Delete(
            jobId: jobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken);
    }
}
