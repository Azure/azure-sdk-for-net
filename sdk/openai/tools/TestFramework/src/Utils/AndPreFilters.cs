// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using NUnit.Framework.Interfaces;

namespace OpenAI.TestFramework.Utils;

/// <summary>
/// Represents a pre-filter that combines multiple pre-filters using a logical AND operation.
/// </summary>
public class AndPreFilter : IPreFilter
{
    private IEnumerable<IPreFilter> _filters;

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="filters">The pre-filters to combine.</param>
    public AndPreFilter(params IPreFilter[] filters) : this((IEnumerable<IPreFilter>)filters)
    { }

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="filters">The pre-filters to combine.</param>
    public AndPreFilter(IEnumerable<IPreFilter> filters)
    {
        _filters = filters?.Where(p => p != null) ?? Array.Empty<IPreFilter>();
    }

    /// <inheritdoc />
    public bool IsMatch(Type type) => _filters.All(p => p.IsMatch(type));

    /// <inheritdoc />
    public bool IsMatch(Type type, MethodInfo method) => _filters.All(p => p.IsMatch(type, method));
}
