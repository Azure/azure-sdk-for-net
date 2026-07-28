// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects;

/// <summary>
/// The options for creating routines.
/// </summary>
[Experimental("AAIP001")]
public partial class ProjectsRoutineOptions
{
    /// <summary>
    /// Create the options for routines.
    /// </summary>
    /// <param name="action">The action executed when the routine fires.</param>
    /// <param name="description">A human-readable description of the routine.</param>
    /// <param name="enabled">Whether the routine is enabled.</param>
    /// <exception cref="ArgumentNullException"> <paramref name="action"/> is null. </exception>
    public ProjectsRoutineOptions(RoutineAction action, string description=default, bool? enabled=default)
    {
        Argument.AssertNotNull(action, nameof(action));

        Action = action;
        Description = description;
        Triggers = [];
        IsEnabled = enabled;
    }

    /// <summary>
    /// A human-readable description of the routine.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// The triggers configured for the routine. In v1, exactly one trigger entry is supported.
    /// </summary>
    public Dictionary<string, RoutineTrigger> Triggers { get; }

    /// <summary>
    /// The action executed when the routine fires.
    /// </summary>
    public RoutineAction Action { get; }

    /// <summary>
    /// Whether the routine is enabled.
    /// </summary>
    public bool? IsEnabled { get; }
}
