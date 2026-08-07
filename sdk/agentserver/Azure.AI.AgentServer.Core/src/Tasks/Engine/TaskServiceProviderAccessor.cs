// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// A late-bound holder for the application's <see cref="IServiceProvider"/>. The resilient-task
/// builder is created during <c>AddResilientTasks</c> — before the container is built — so the
/// provider-aware handler overloads cannot capture a provider at registration time. This holder is
/// populated when the <see cref="TaskEngine"/> singleton is constructed (which always happens
/// before any handler runs, because invocation flows through the engine), letting those overloads
/// resolve services at handler-invocation time without forcing callers to call
/// <c>BuildServiceProvider()</c> themselves.
/// </summary>
internal sealed class TaskServiceProviderAccessor
{
    /// <summary>The application service provider, set once the container is built.</summary>
    public IServiceProvider? Provider { get; set; }

    /// <summary>Returns the provider or throws if it has not been populated yet.</summary>
    public IServiceProvider Require()
        => Provider ?? throw new InvalidOperationException(
            "The service provider is not available yet. Provider-aware task handlers can only " +
            "resolve services once the application container has been built.");
}
