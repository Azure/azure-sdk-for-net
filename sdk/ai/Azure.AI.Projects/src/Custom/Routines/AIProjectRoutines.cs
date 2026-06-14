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
//                GetRoutineRuns(string routineName, string foundryFeatures, string filter, int? limit, string order, string after, string before, RequestOptions options)
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
    /// <param name="routineName"> The unique name of the routine. </param>
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
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<RoutineRun> GetRoutineRuns(string routineName, string filter = default, int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(routineName, nameof(routineName));
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
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [routineName, filter]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> List prior runs for a routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
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
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<RoutineRun> GetRoutineRunsAsync(string routineName, string filter = default, int? limit = default, MemoryStoreListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(routineName, nameof(routineName));
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
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [routineName, filter]),
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
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="triggers"> The triggers configured for the routine. In v1, exactly one trigger entry is supported. </param>
    /// <param name="action"> The action executed when the routine fires. </param>
    /// <param name="description"> A human-readable description of the routine. </param>
    /// <param name="enabled"> Whether the routine is enabled. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/>, <paramref name="triggers"/> or <paramref name="action"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<ProjectsRoutine> CreateOrUpdateRoutine(string routineName, IDictionary<string, RoutineTrigger> triggers, RoutineAction action, string description = default, bool? enabled = default, CancellationToken cancellationToken = default)
    {
        return CreateOrUpdateRoutine(
            routineName: routineName,
            triggers: triggers,
            action: action,
            description: description,
            enabled: enabled,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Create or update a routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="triggers"> The triggers configured for the routine. In v1, exactly one trigger entry is supported. </param>
    /// <param name="action"> The action executed when the routine fires. </param>
    /// <param name="description"> A human-readable description of the routine. </param>
    /// <param name="enabled"> Whether the routine is enabled. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/>, <paramref name="triggers"/> or <paramref name="action"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ProjectsRoutine>> CreateOrUpdateRoutineAsync(string routineName, IDictionary<string, RoutineTrigger> triggers, RoutineAction action, string description = default, bool? enabled = default, CancellationToken cancellationToken = default)
    {
        return await CreateOrUpdateRoutineAsync(
            routineName: routineName,
            triggers: triggers,
            action: action,
            description: description,
            enabled: enabled,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Retrieve a routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<ProjectsRoutine> GetRoutine(string routineName, CancellationToken cancellationToken = default)
    {
        return GetRoutine(
            routineName: routineName,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Retrieve a routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ProjectsRoutine>> GetRoutineAsync(string routineName, CancellationToken cancellationToken = default)
    {
        return await GetRoutineAsync(
            routineName: routineName,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Enable a routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<ProjectsRoutine> EnableRoutine(string routineName, CancellationToken cancellationToken = default)
    {
        return EnableRoutine(
            routineName: routineName,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Enable a routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ProjectsRoutine>> EnableRoutineAsync(string routineName, CancellationToken cancellationToken = default)
    {
        return await EnableRoutineAsync(
            routineName: routineName,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Disable a routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<ProjectsRoutine> DisableRoutine(string routineName, CancellationToken cancellationToken = default)
    {
        return DisableRoutine(
            routineName: routineName,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Disable a routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ProjectsRoutine>> DisableRoutineAsync(string routineName, CancellationToken cancellationToken = default)
    {
        return await DisableRoutineAsync(
            routineName: routineName,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Delete a routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult DeleteRoutine(string routineName, CancellationToken cancellationToken = default)
    {
        return DeleteRoutine(
            routineName: routineName,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Delete a routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult> DeleteRoutineAsync(string routineName, CancellationToken cancellationToken = default)
    {
        return await DeleteRoutineAsync(
            routineName: routineName,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Queue an asynchronous routine dispatch. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="payload"> A direct action-input override sent downstream when testing a routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<DispatchRoutineResponse> DispatchAsyncRoutine(string routineName, RoutineDispatchPayload payload = default, CancellationToken cancellationToken = default)
    {
        return DispatchAsyncRoutine(
            routineName: routineName,
            payload: payload,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Queue an asynchronous routine dispatch. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="payload"> A direct action-input override sent downstream when testing a routine. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual Task<ClientResult<DispatchRoutineResponse>> DispatchAsyncRoutineAsync(string routineName, RoutineDispatchPayload payload = default, CancellationToken cancellationToken = default)
    {
        return DispatchAsyncRoutineAsync(
            routineName: routineName,
            payload: payload,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }
}
