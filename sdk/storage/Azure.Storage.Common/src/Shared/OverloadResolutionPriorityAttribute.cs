// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !NET9_0_OR_GREATER

namespace System.Runtime.CompilerServices;

/// <summary>
/// Specifies the priority of a member in overload resolution. When unspecified, the default priority is 0.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
internal sealed class OverloadResolutionPriorityAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OverloadResolutionPriorityAttribute"/> class.
    /// </summary>
    /// <param name="priority">The priority of the attributed member. Higher numbers are prioritized, lower numbers are deprioritized. 0 is the default if no attribute is present.</param>
    public OverloadResolutionPriorityAttribute(int priority)
    {
        Priority = priority;
    }

    /// <summary>
    /// The priority of the member.
    /// </summary>
    public int Priority { get; }
}

#endif
