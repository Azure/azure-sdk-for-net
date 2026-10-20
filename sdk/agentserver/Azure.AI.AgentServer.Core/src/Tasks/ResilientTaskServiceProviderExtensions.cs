// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Resolves a registered resilient task's typed <see cref="TaskDefinition{TInput, TOutput}"/>
/// handle from a built <see cref="IServiceProvider"/>. Every task registered with
/// <c>AddResilientTask</c>/<c>AddResilientMultiTurnTask</c> is also registered as a keyed singleton
/// service, keyed by its task name — this is the sanctioned way to resolve it. Resolution is always
/// by name (never ambiguous), because multiple tasks may share the same
/// <c>TInput</c>/<c>TOutput</c> pair.
/// </summary>
public static class ResilientTaskServiceProviderExtensions
{
    /// <summary>
    /// Resolves the typed <see cref="TaskDefinition{TInput, TOutput}"/> handle for the task
    /// registered under <paramref name="name"/>.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="provider">The service provider.</param>
    /// <param name="name">The task name it was registered with.</param>
    /// <returns>The typed <see cref="TaskDefinition{TInput, TOutput}"/> handle.</returns>
    public static TaskDefinition<TInput, TOutput> GetResilientTask<TInput, TOutput>(
        this IServiceProvider provider,
        string name)
    {
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        return provider.GetRequiredKeyedService<TaskDefinition<TInput, TOutput>>(name);
    }
}
