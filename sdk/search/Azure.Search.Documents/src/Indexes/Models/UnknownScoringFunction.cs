// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenSuppress("DeserializeUnknownScoringFunction", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    internal partial class UnknownScoringFunction
    {
        internal static UnknownScoringFunction DeserializeUnknownScoringFunction(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string type = null;
            string fieldName = null;
            double boost = default;
            ScoringFunctionInterpolation? interpolation = null;
            var additionalProperties = new Dictionary<string, BinaryData>();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                switch (property.Name)
                {
                    case "type":
                        type = property.Value.GetString();
                        break;
                    case "fieldName":
                        fieldName = property.Value.GetString();
                        break;
                    case "boost":
                        boost = property.Value.GetDouble();
                        break;
                    case "interpolation":
                        if (property.Value.ValueKind != JsonValueKind.Null)
                        {
                            interpolation = property.Value.GetString().ToScoringFunctionInterpolation();
                        }
                        break;
                    default:
                        if (options.Format != "W")
                        {
                            additionalProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                        }
                        break;
                }
            }

            return new UnknownScoringFunction(interpolation, type, additionalProperties)
            {
                FieldName = fieldName,
                Boost = boost
            };
        }
    }
}
