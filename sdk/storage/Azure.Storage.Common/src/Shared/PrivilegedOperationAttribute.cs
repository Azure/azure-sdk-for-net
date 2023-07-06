// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Decorates a potentially privileged operation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    internal class PrivilegedOperationAttribute : Attribute
    {
    }
}
