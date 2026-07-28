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
[CodeGenSuppress("GetRoutineRuns", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetRoutineRunsAsync", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetRoutineRuns", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetRoutineRunsAsync", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetRoutines", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetRoutinesAsync", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetRoutines", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetRoutinesAsync", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
public partial class AIProjectRoutines
{
    /// <summary> List prior runs for a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="filter"> An optional MLflow search-runs filter expression applied within the routine's experiment. </param>
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
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<RoutineRun> GetRoutineRuns(string name, string filter = default, int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return new InternalOpenAICollectionResultOfT<RoutineRun>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetRoutineRunsRequest(
                    routineName: localCollectionOptions.Filters[0],
                    foundryFeatures: default,
                    filter: localCollectionOptions.Filters.Count > 1 ? localCollectionOptions.Filters[1] : null,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: RoutineRun.DeserializeRoutineRun,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [name, filter]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> List prior runs for a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="filter"> An optional MLflow search-runs filter expression applied within the routine's experiment. </param>
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
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<RoutineRun> GetRoutineRunsAsync(string name, string filter = default, int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return new InternalOpenAIAsyncCollectionResultOfT<RoutineRun>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetRoutineRunsRequest(
                    routineName: localCollectionOptions.Filters[0],
                    foundryFeatures: default,
                    filter: localCollectionOptions.Filters.Count > 1 ? localCollectionOptions.Filters[1] : null,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: RoutineRun.DeserializeRoutineRun,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [name, filter]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> List routines. </summary>
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
    public virtual CollectionResult<ProjectsRoutine> GetRoutines(int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<ProjectsRoutine>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetRoutinesRequest(
                    foundryFeatures: default,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: ProjectsRoutine.DeserializeProjectsRoutine,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> List routines. </summary>
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
    public virtual AsyncCollectionResult<ProjectsRoutine> GetRoutinesAsync(int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<ProjectsRoutine>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetRoutinesRequest(
                    foundryFeatures: default,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: ProjectsRoutine.DeserializeProjectsRoutine,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Create or update a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="options"> The options for routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="options"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<ProjectsRoutine> CreateOrUpdate(string name, ProjectsRoutineOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(options, nameof(options));
        return CreateOrUpdate(
            routineName: name,
            triggers: options.Triggers,
            action: options.Action,
            description: options.Description,
            enabled: options.IsEnabled,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Create or update a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="options"> The options for routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="options"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ProjectsRoutine>> CreateOrUpdateAsync(string name, ProjectsRoutineOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(options, nameof(options));
        return await CreateOrUpdateAsync(
            routineName: name,
            triggers: options.Triggers,
            action: options.Action,
            description: options.Description,
            enabled: options.IsEnabled,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Retrieve a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<ProjectsRoutine> Get(string name, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return Get(
            routineName: name,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Retrieve a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ProjectsRoutine>> GetAsync(string name, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return await GetAsync(
            routineName: name,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Enable a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<ProjectsRoutine> Enable(string name, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return Enable(
            routineName: name,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Enable a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ProjectsRoutine>> EnableAsync(string name, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return await EnableAsync(
            routineName: name,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Disable a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<ProjectsRoutine> Disable(string name, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return Disable(
            routineName: name,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Disable a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ProjectsRoutine>> DisableAsync(string name, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return await DisableAsync(
            routineName: name,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Delete a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult Delete(string name, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return Delete(
            routineName: name,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Delete a routine. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult> DeleteAsync(string name, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return await DeleteAsync(
            routineName: name,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Queue an asynchronous routine dispatch. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="payload"> A direct action-input override sent downstream when testing a routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<DispatchRoutineResult> Dispatch(string name, RoutineDispatchPayload payload = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return Dispatch(
            routineName: name,
            payload: payload,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Queue an asynchronous routine dispatch. </summary>
    /// <param name="name"> The unique name of the routine. </param>
    /// <param name="payload"> A direct action-input override sent downstream when testing a routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual Task<ClientResult<DispatchRoutineResult>> DispatchAsync(string name, RoutineDispatchPayload payload = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        return DispatchAsync(
            routineName: name,
            payload: payload,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }
}
