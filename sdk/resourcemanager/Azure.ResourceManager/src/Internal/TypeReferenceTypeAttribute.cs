// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager
{
    /// <summary>
    /// An attribute class indicating a reference type which can replace a type in target RPs.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class TypeReferenceTypeAttribute : Attribute
    {
    }
}
