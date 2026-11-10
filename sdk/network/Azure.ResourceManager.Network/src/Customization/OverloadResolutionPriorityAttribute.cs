// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !NET9_0_OR_GREATER
namespace System.Runtime.CompilerServices
{
    // Keep optional compatibility overloads from making calls to the current factory ambiguous.
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    internal sealed class OverloadResolutionPriorityAttribute : Attribute
    {
        public OverloadResolutionPriorityAttribute(int priority) => Priority = priority;

        public int Priority { get; }
    }
}
#endif
