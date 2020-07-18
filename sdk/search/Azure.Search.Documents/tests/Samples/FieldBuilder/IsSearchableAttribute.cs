// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Samples
{
    /// <summary>
    /// Causes the field to be included in full-text searches. Valid only for
    /// string or string collection fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsSearchableAttribute : Attribute
    {
    }
}
