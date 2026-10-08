// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Azure.AI.Projects.Memory;

namespace Azure.AI.Projects.Evaluation;

[Experimental("AAIP001")]

[CodeGenSuppress("GetAll", typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAllAsync", typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAll", typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAllAsync", typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenType("EvaluatorGenerationJobs")]
public partial class EvaluatorGenerationJobs
{
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
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<EvaluatorGenerationJob> GetAll(int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<EvaluatorGenerationJob>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAllRequest(
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: EvaluatorGenerationJob.DeserializeEvaluatorGenerationJob,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: []),
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
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<EvaluatorGenerationJob> GetAllAsync(int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<EvaluatorGenerationJob>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAllRequest(
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: EvaluatorGenerationJob.DeserializeEvaluatorGenerationJob,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: []),
            cancellationToken.ToRequestOptions());
    }
}
