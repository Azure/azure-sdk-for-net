// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class RequestStatistics : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("documentsCount");
            writer.WriteNumberValue(DocumentsCount);
            writer.WritePropertyName("validDocumentsCount");
            writer.WriteNumberValue(ValidDocumentsCount);
            writer.WritePropertyName("erroneousDocumentsCount");
            writer.WriteNumberValue(ErroneousDocumentsCount);
            writer.WritePropertyName("transactionsCount");
            writer.WriteNumberValue(TransactionsCount);
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
        }

        internal static RequestStatistics DeserializeRequestStatistics(JsonElement element)
        {
            int documentsCount = default;
            int validDocumentsCount = default;
            int erroneousDocumentsCount = default;
            long transactionsCount = default;
            IDictionary<string, object> additionalProperties = default;
            Dictionary<string, object> additionalPropertiesDictionary = new Dictionary<string, object>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("documentsCount"))
                {
                    documentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("validDocumentsCount"))
                {
                    validDocumentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("erroneousDocumentsCount"))
                {
                    erroneousDocumentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("transactionsCount"))
                {
                    transactionsCount = property.Value.GetInt64();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetObject());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new RequestStatistics(documentsCount, validDocumentsCount, erroneousDocumentsCount, transactionsCount, additionalProperties);
        }
    }
}
