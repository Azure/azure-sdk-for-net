// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !NET9_0_OR_GREATER

using System;

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    internal sealed class OverloadResolutionPriorityAttribute : Attribute
    {
        public OverloadResolutionPriorityAttribute(int priority)
        {
            Priority = priority;
        }

        public int Priority { get; }
    }
}

#endif
