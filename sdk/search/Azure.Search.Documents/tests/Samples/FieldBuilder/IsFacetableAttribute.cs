// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Samples
{

    /// <summary>
    /// Indicates that it is possible to facet on this field. Not valid for
    /// geo-point fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsFacetableAttribute : Attribute
    {
    }
}
