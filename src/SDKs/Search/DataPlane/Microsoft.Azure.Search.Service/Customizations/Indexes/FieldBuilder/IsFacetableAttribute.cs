﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using Microsoft.Azure.Search.Models;

    /// <summary>
    /// Indicates that it is possible to facet on this field. Not valid for
    /// geo-point fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsFacetableAttribute : Attribute
    {
    }
}
