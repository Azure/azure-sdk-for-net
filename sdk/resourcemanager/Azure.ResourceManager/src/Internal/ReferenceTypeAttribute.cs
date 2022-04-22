// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// An attribute class indicating a reference type for code generation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class ReferenceTypeAttribute : Attribute
    {
    }
}
