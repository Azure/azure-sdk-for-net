// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Samples
{
    /// <summary>
    /// Indicates that the target property should be ignored by <see cref="FieldBuilder"/>.
    /// </summary>
    /// <remarks>
    /// This attribute is useful in situations where a property definition doesn't cleanly map to a <see cref="SearchField"/>
    /// object, but its values still need to be converted to and from JSON. In that case,
    /// <see cref="JsonIgnoreAttribute"/> can't be used since it would disable JSON conversion.
    /// An example of a scenario where this is useful is when mapping between a string field in Azure Cognitive Search and an enum
    /// property.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldBuilderIgnoreAttribute : Attribute
    {
    }
}
