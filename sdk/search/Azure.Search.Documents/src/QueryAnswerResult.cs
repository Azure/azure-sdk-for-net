// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Models
{
    public partial class QueryAnswerResult
    {
        /// <summary> Additional Properties. </summary>
        public IReadOnlyDictionary<string, object> AdditionalProperties =>
            (IReadOnlyDictionary<string, object>) _additionalBinaryDataProperties;

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static QueryAnswerResult DeserializeQueryAnswerResult(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            double? score = default;
            string key = default;
            string text = default;
            string highlights = default;
            IDictionary<string, object> additionalProperties = new ChangeTrackingDictionary<string, object>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("score"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    score = prop.Value.GetDouble();
                    continue;
                }
                if (prop.NameEquals("key"u8))
                {
                    key = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("text"u8))
                {
                    text = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("highlights"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        highlights = null;
                        continue;
                    }
                    highlights = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalProperties.Add(prop.Name, prop.Value.GetObject());
                }
            }
            return new QueryAnswerResult(score, key, text, highlights, additionalProperties);
        }
    }
}
