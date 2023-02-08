// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class QueryFilters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(MetadataFilter))
            {
                writer.WritePropertyName("metadataFilter");
                writer.WriteObjectValue(MetadataFilter);
            }
            if (Optional.IsCollectionDefined(SourceFilter))
            {
                writer.WritePropertyName("sourceFilter");
                writer.WriteStartArray();
                foreach (var item in SourceFilter)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(LogicalOperation))
            {
                writer.WritePropertyName("logicalOperation");
                writer.WriteStringValue(LogicalOperation.Value.ToString());
            }
            writer.WriteEndObject();
        }
    }
}
