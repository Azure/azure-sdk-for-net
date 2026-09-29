// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Memory;

namespace Azure.AI.Projects;

[Experimental("AAIP001")]
[CodeGenSuppress("GetRoutineRuns", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(string), typeof(int?), typeof(string), typeof(MemoryStoreListOrder?), typeof(CancellationToken))]
[CodeGenSuppress("GetRoutineRunsAsync", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(string), typeof(int?), typeof(string), typeof(MemoryStoreListOrder?), typeof(CancellationToken))]
[CodeGenSuppress("GetRoutines", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(string), typeof(MemoryStoreListOrder?), typeof(CancellationToken))]
[CodeGenSuppress("GetRoutinesAsync", typeof(FoundryFeaturesOptInKeys?), typeof(int?), typeof(string), typeof(MemoryStoreListOrder?), typeof(CancellationToken))]
public partial class AIProjectRoutines
{
    /// <summary> Returns prior runs recorded for the specified routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="filter"> An optional MLflow search-runs filter expression applied within the routine's experiment. </param>
    /// <param name="limit"> The maximum number of runs to return. </param>
    /// <param name="after"> An opaque continuation token identifying where to resume the list. Prefer following the `next_link` returned by the previous response, which embeds this value. </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<RoutineRun> GetRoutineRuns(string routineName, string filter = default, int? limit = default, string after = default, MemoryStoreListOrder? order = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(routineName, nameof(routineName));

        return new AIProjectRoutinesGetRoutineRunsCollectionResultOfT(
            client: this,
            routineName: routineName,
            foundryFeatures: default,
            filter: filter,
            limit: limit,
            after: after,
            order: order?.ToString(),
            options: cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns prior runs recorded for the specified routine. </summary>
    /// <param name="routineName"> The unique name of the routine. </param>
    /// <param name="filter"> An optional MLflow search-runs filter expression applied within the routine's experiment. </param>
    /// <param name="limit"> The maximum number of runs to return. </param>
    /// <param name="after"> An opaque continuation token identifying where to resume the list. Prefer following the `next_link` returned by the previous response, which embeds this value. </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="routineName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="routineName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<RoutineRun> GetRoutineRunsAsync(string routineName, string filter = default, int? limit = default, string after = default, MemoryStoreListOrder? order = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(routineName, nameof(routineName));

        return new AIProjectRoutinesGetRoutineRunsAsyncCollectionResultOfT(
            client: this,
            routineName: routineName,
            foundryFeatures: default,
            filter: filter,
            limit: limit,
            after: after,
            order: order?.ToString(),
            options: cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns the routines available in the current project. </summary>
    /// <param name="limit"> The maximum number of routines to return. </param>
    /// <param name="after"> An opaque continuation token identifying where to resume the list. Prefer following the `next_link` returned by the previous response, which embeds this value. </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<ProjectsRoutine> GetRoutines(int? limit = default, string after = default, MemoryStoreListOrder? order = default, CancellationToken cancellationToken = default)
    {
        return new AIProjectRoutinesGetRoutinesCollectionResultOfT(
                client: this,
                foundryFeatures: default,
                limit: limit,
                after: after,
                order: order?.ToString(),
                options: cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns the routines available in the current project. </summary>
    /// <param name="limit"> The maximum number of routines to return. </param>
    /// <param name="after"> An opaque continuation token identifying where to resume the list. Prefer following the `next_link` returned by the previous response, which embeds this value. </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<ProjectsRoutine> GetRoutinesAsync(int? limit = default, string after = default, MemoryStoreListOrder? order = default, CancellationToken cancellationToken = default)
    {
        return new AIProjectRoutinesGetRoutinesAsyncCollectionResultOfT(
                client: this,
                foundryFeatures: default,
                limit: limit,
                after: after,
                order: order?.ToString(),
                options: cancellationToken.ToRequestOptions());
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
