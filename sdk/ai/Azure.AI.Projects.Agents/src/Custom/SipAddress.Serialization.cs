// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.Projects.Agents;

[CodeGenType("SipAddress")]
public partial class SipAddress
{
    /// <inheritdoc/>
    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        base.JsonModelWriteCore(writer, options);
    }
}
