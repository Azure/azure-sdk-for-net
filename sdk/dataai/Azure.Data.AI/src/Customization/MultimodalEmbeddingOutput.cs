// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
    // Url can be absent; write JSON null instead of dereferencing it.
    [CodeGenSerialization(nameof(Url), SerializationValueHook = nameof(WriteUrlValue))]
    public partial class MultimodalEmbeddingOutput
    {
        private void WriteUrlValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (Url == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStringValue(Url.AbsoluteUri);
        }
    }
}
