// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
    // Uri can be absent; write JSON null instead of dereferencing it.
    [CodeGenSerialization(nameof(Uri), SerializationValueHook = nameof(WriteUriValue))]
    public partial class MultimodalEmbeddingOutput
    {
        private void WriteUriValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (Uri == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStringValue(Uri.AbsoluteUri);
        }
    }
}
