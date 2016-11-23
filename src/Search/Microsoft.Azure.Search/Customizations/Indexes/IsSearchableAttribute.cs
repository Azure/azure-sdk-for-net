// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using Microsoft.Azure.Search.Models;

    /// <summary>
    /// Causes the field to be included in full-text searches. Valid only for
    /// string or string collection fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsSearchableAttribute : Attribute
    {
    }
}
