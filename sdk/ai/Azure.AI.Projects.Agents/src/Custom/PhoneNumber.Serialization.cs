// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.Projects.Agents;

[CodeGenType("PhoneNumber")]
public partial class PhoneNumber
{
    /// <inheritdoc/>
    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        // The base writer already serializes the overridden Value property.
        base.JsonModelWriteCore(writer, options);
    }
}
