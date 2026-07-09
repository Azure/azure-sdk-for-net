// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// The in-process catalog of registered tasks, keyed by name. The engine routes an
/// incoming task record to its handler via the wire <c>source.name</c>.
/// </summary>
internal sealed class TaskRegistry
{
    private readonly ConcurrentDictionary<string, TaskRegistration> _registrations =
        new(StringComparer.Ordinal);

    /// <summary>Adds a registration, rejecting duplicate names.</summary>
    /// <param name="registration">The registration to add.</param>
    /// <exception cref="InvalidOperationException">A task with the same name is already registered.</exception>
    public void Add(TaskRegistration registration)
    {
        if (!_registrations.TryAdd(registration.Name, registration))
        {
            throw new InvalidOperationException($"A task named '{registration.Name}' is already registered.");
        }
    }

    /// <summary>Tries to get a registration by name.</summary>
    /// <param name="name">The task name.</param>
    /// <param name="registration">The registration when found.</param>
    /// <returns><see langword="true"/> if found.</returns>
    public bool TryGet(string name, out TaskRegistration registration)
        => _registrations.TryGetValue(name, out registration!);

    /// <summary>Gets a registration by name or throws when unknown.</summary>
    /// <param name="name">The task name.</param>
    /// <returns>The registration.</returns>
    public TaskRegistration Get(string name)
        => _registrations.TryGetValue(name, out TaskRegistration? r)
            ? r
            : throw new InvalidOperationException($"No task named '{name}' is registered.");

    /// <summary>All registered task names.</summary>
    public IReadOnlyCollection<string> Names => (IReadOnlyCollection<string>)_registrations.Keys;
}
