// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Samples
{
    /// <summary>
    /// Indicates that the field can be used in filter expressions.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsFilterableAttribute : Attribute
    {
    }
}
