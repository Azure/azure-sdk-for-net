// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("ItemParam")]
internal partial class InternalItemParam
{
    internal static InternalItemParam DeserializeInternalItemParam(JsonElement element, ModelReaderWriterOptions options)
        => throw new NotImplementedException();
}
