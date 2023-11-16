// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Text.Json;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class KnowledgeStoreProjectionSelector
    {
        internal static KnowledgeStoreProjectionSelector DeserializeKnowledgeStoreProjectionSelector(JsonElement element, ModelReaderWriterOptions options = null)
        {
            throw new NotSupportedException("Deserialization of abstract type 'global::Azure.Search.Documents.Indexes.Models.KnowledgeStoreProjectionSelector' not supported.");
        }
    }
}
